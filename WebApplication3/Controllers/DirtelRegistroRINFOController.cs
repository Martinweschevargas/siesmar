using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dirtel;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DirtelRegistroRINFOController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        RegistroRINFO registroRINFOBL = new();
        Dependencia dependenciaBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        Carga cargaBL = new();

        public DirtelRegistroRINFOController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Reportes de Infracción Contra la Seguridad de la Información", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("RegistroRINFO");

            return Json(new
            {
                data1 = dependenciaDTO,
                data2 = gradoPersonalMilitarDTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<RegistroRINFODTO> registroRINFODTO = registroRINFOBL.ObtenerLista();
            return Json(new { data = registroRINFODTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( string FechaReporte, string CodigoDependencia, string NombreInfractor,
            string TipoInfraccion, string MotivoIncumplimiento, string AplicacionSancion, string DisposicionEmitidaPrevencion,
            string OtroInformacionAdicional, string CodigoGradoPersonalMilitar, int CargaId)
        {
            RegistroRINFODTO registroRINFODTO = new();
            registroRINFODTO.CodigoDependencia = CodigoDependencia;
            registroRINFODTO.FechaReporte = FechaReporte;
            registroRINFODTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            registroRINFODTO.NombreInfractor = NombreInfractor;
            registroRINFODTO.TipoInfraccion = TipoInfraccion;
            registroRINFODTO.MotivoIncumplimiento = MotivoIncumplimiento;
            registroRINFODTO.AplicacionSancion = AplicacionSancion;
            registroRINFODTO.DisposicionEmitidaPrevencion = DisposicionEmitidaPrevencion;
            registroRINFODTO.OtroInformacionAdicional = OtroInformacionAdicional;
            registroRINFODTO.CargaId = CargaId;
            registroRINFODTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroRINFOBL.AgregarRegistro(registroRINFODTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(registroRINFOBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int RegistroRINFOId, string FechaReporte, string CodigoDependencia, string NombreInfractor,
            string TipoInfraccion, string MotivoIncumplimiento, string AplicacionSancion, string DisposicionEmitidaPrevencion,
            string OtroInformacionAdicional, string CodigoGradoPersonalMilitar)
        {
            RegistroRINFODTO registroRINFODTO = new();
            registroRINFODTO.RegistroRINFOId = RegistroRINFOId;
            registroRINFODTO.CodigoDependencia = CodigoDependencia;
            registroRINFODTO.FechaReporte = FechaReporte;
            registroRINFODTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            registroRINFODTO.NombreInfractor = NombreInfractor;
            registroRINFODTO.TipoInfraccion = TipoInfraccion;
            registroRINFODTO.MotivoIncumplimiento = MotivoIncumplimiento;
            registroRINFODTO.AplicacionSancion = AplicacionSancion;
            registroRINFODTO.DisposicionEmitidaPrevencion = DisposicionEmitidaPrevencion;
            registroRINFODTO.OtroInformacionAdicional = OtroInformacionAdicional;
            registroRINFODTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroRINFOBL.ActualizarFormato(registroRINFODTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RegistroRINFODTO registroRINFODTO = new();
            registroRINFODTO.RegistroRINFOId = Id;
            registroRINFODTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (registroRINFOBL.EliminarFormato(registroRINFODTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<RegistroRINFODTO> lista = new List<RegistroRINFODTO>();
            try
            {
                Stream stream = ArchivoExcel.OpenReadStream();
                IWorkbook? MiExcel = null;

                if (Path.GetExtension(ArchivoExcel.FileName) == ".xlsx")
                {
                    MiExcel = new XSSFWorkbook(stream);
                }
                else
                {
                    MiExcel = new HSSFWorkbook(stream);
                }
                ISheet HojaExcel = MiExcel.GetSheetAt(0);
                int cantidadFilas = HojaExcel.LastRowNum;

                for (int i = 1; i <= cantidadFilas; i++)
                {
                    IRow fila = HojaExcel.GetRow(i);

                    lista.Add(new RegistroRINFODTO
                    {
                        CodigoDependencia = fila.GetCell(0).ToString(),
                        FechaReporte = fila.GetCell(1).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(2).ToString(),
                        NombreInfractor = fila.GetCell(3).ToString(),
                        TipoInfraccion = fila.GetCell(4).ToString(),
                        MotivoIncumplimiento = fila.GetCell(5).ToString(),
                        AplicacionSancion = fila.GetCell(6).ToString(),
                        DisposicionEmitidaPrevencion = fila.GetCell(7).ToString(),
                        OtroInformacionAdicional = fila.GetCell(8).ToString(),

                    });
                }
            }
            catch (Exception e)
            {
                Mensaje = "0";
            }
            return Json(new { data = Mensaje, data1 = lista });
        }

        [HttpPost]
        [HttpPost]
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
        {
            Stream stream = ArchivoExcel.OpenReadStream();
            IWorkbook MiExcel = null;

            if (Path.GetExtension(ArchivoExcel.FileName) == ".xlsx")
                MiExcel = new XSSFWorkbook(stream);
            else
                MiExcel = new HSSFWorkbook(stream);

            ISheet HojaExcel = MiExcel.GetSheetAt(0);
            int cantidadFilas = HojaExcel.LastRowNum;

            DataTable dt = new();

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("CodigoDependencia ", typeof(string)),
                    new DataColumn("FechaReporte ", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar ", typeof(string)),
                    new DataColumn("NombreInfractor ", typeof(string)),
                    new DataColumn("TipoInfraccion ", typeof(string)),
                    new DataColumn("MotivoIncumplimiento ", typeof(string)),
                    new DataColumn("AplicacionSancion   ", typeof(string)),
                    new DataColumn("DisposicionEmitidaPrevencion ", typeof(string)),
                    new DataColumn("OtroInformacionAdicional ", typeof(string)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                   fila.GetCell(0).ToString(),
                   UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                   fila.GetCell(2).ToString(),
                   fila.GetCell(3).ToString(),
                   fila.GetCell(4).ToString(),
                   fila.GetCell(5).ToString(),
                   fila.GetCell(6).ToString(),
                   fila.GetCell(7).ToString(),
                   fila.GetCell(8).ToString(),

                   User.obtenerUsuario());
            }
            var IND_OPERACION = registroRINFOBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDRRINFO(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirtel\\RegistroRINFO.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = registroRINFOBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("RegistroRINFO", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\RegistroRINFO.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "RegistroRINFO.xlsx");
        }
    }

}