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
    public class DirtelRegistroIncidenteInformaticoController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        RegistroIncidenteInformatico registroIncidenteInformaticoBL = new();
        Dependencia dependenciaBL = new();
        TipoIncidenteSGSI tipoIncidenteSGSIBL = new();
        Carga cargaBL = new();

        public DirtelRegistroIncidenteInformaticoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Incidentes Informaticos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<TipoIncidenteSGSIDTO> tipoIncidenteSGSIDTO = tipoIncidenteSGSIBL.ObtenerTipoIncidenteSGSIs();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("RegistroIncidenteInformatico");

            return Json(new
            {
                data1 = dependenciaDTO,
                data2 = tipoIncidenteSGSIDTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<RegistroIncidenteInformaticoDTO> registroIncidenteInformaticoDTO = registroIncidenteInformaticoBL.ObtenerLista();
            return Json(new { data = registroIncidenteInformaticoDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( string FechaHoraIncidente, string CodigoTipoIncidenteSGS, string NombreQuienReporta, string DescripcionIncidente, 
            string NivelPrioridad, string EstrategiaErradicacion, string CodigoDependencia, int CargaId)
        {
            RegistroIncidenteInformaticoDTO registroIncidenteInformaticoDTO = new();
            registroIncidenteInformaticoDTO.CodigoDependencia = CodigoDependencia;
            registroIncidenteInformaticoDTO.FechaHoraIncidente = FechaHoraIncidente;
            registroIncidenteInformaticoDTO.NombreQuienReporta = NombreQuienReporta;
            registroIncidenteInformaticoDTO.DescripcionIncidente = DescripcionIncidente;
            registroIncidenteInformaticoDTO.CodigoTipoIncidenteSGS = CodigoTipoIncidenteSGS;
            registroIncidenteInformaticoDTO.NivelPrioridad = NivelPrioridad;
            registroIncidenteInformaticoDTO.EstrategiaErradicacion = EstrategiaErradicacion;
            registroIncidenteInformaticoDTO.CargaId = CargaId;
            registroIncidenteInformaticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroIncidenteInformaticoBL.AgregarRegistro(registroIncidenteInformaticoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(registroIncidenteInformaticoBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int RegistroIncidenteInformaticoId, string FechaHoraIncidente, string CodigoTipoIncidenteSGS, string NombreQuienReporta, string DescripcionIncidente,
            string NivelPrioridad, string EstrategiaErradicacion, string CodigoDependencia)
        {
            RegistroIncidenteInformaticoDTO registroIncidenteInformaticoDTO = new();
            registroIncidenteInformaticoDTO.RegistroIncidenteInformaticoId = RegistroIncidenteInformaticoId;
            registroIncidenteInformaticoDTO.CodigoDependencia = CodigoDependencia;
            registroIncidenteInformaticoDTO.FechaHoraIncidente = FechaHoraIncidente;
            registroIncidenteInformaticoDTO.NombreQuienReporta = NombreQuienReporta;
            registroIncidenteInformaticoDTO.DescripcionIncidente = DescripcionIncidente;
            registroIncidenteInformaticoDTO.CodigoTipoIncidenteSGS = CodigoTipoIncidenteSGS;
            registroIncidenteInformaticoDTO.NivelPrioridad = NivelPrioridad;
            registroIncidenteInformaticoDTO.EstrategiaErradicacion = EstrategiaErradicacion;
            registroIncidenteInformaticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroIncidenteInformaticoBL.ActualizarFormato(registroIncidenteInformaticoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RegistroIncidenteInformaticoDTO registroIncidenteInformaticoDTO = new();
            registroIncidenteInformaticoDTO.RegistroIncidenteInformaticoId = Id;
            registroIncidenteInformaticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (registroIncidenteInformaticoBL.EliminarFormato(registroIncidenteInformaticoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<RegistroIncidenteInformaticoDTO> lista = new List<RegistroIncidenteInformaticoDTO>();
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

                    lista.Add(new RegistroIncidenteInformaticoDTO
                    {
                        CodigoDependencia = fila.GetCell(0).ToString(),
                        FechaHoraIncidente = fila.GetCell(1).ToString(),
                        NombreQuienReporta = fila.GetCell(2).ToString(),
                        DescripcionIncidente = fila.GetCell(3).ToString(),
                        CodigoTipoIncidenteSGS = fila.GetCell(4).ToString(),
                        NivelPrioridad = fila.GetCell(5).ToString(),
                        EstrategiaErradicacion = fila.GetCell(6).ToString(),

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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("CodigoDependencia   ", typeof(string)),
                    new DataColumn("FechaHoraIncidente  ", typeof(string)),
                    new DataColumn("NombreQuienReporta  ", typeof(string)),
                    new DataColumn("DescripcionIncidente  ", typeof(string)),
                    new DataColumn("CodigoTipoIncidenteSGS   ", typeof(string)),
                    new DataColumn("NivelPrioridad  ", typeof(string)),
                    new DataColumn("EstrategiaErradicacion  ", typeof(string)),

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

                    User.obtenerUsuario());
            }
            var IND_OPERACION = registroIncidenteInformaticoBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDRII(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirtel\\RegistroIncidenteInformatico.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = registroIncidenteInformaticoBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("RegistroIncidenteInformatico", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\RegistroIncidenteInformatico.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "RegistroIncidenteInformatico.xlsx");
        }
    }

}