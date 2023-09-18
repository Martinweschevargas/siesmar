using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dimar;
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

    public class DimarComisionAudiovisualController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        ComisionAudiovisual comisionAudiovisualBL = new();
        PersonalComision personalComisionBL = new();
        Dependencia dependenciaBL = new();
        Comision comisionBL = new();
        Carga cargaBL = new();

        public DimarComisionAudiovisualController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Comisiones de audiovisuales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<PersonalComisionDTO> personalComisionDTO = personalComisionBL.ObtenerPersonalComisions();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<ComisionDTO> comisionDTO = comisionBL.ObtenerComisions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ComisionAudiovisual");
            return Json(new
            {
                data1 = personalComisionDTO,
                data2 = dependenciaDTO,
                data3 = comisionDTO,
                data4 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ComisionAudiovisualDTO> select = comisionAudiovisualBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Comisiones de audiovisuales")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string FechaComisionAudiovisual, string CodigoPersonalComision, string CodigoDependencia,
            string Motivo, string CodigoComision, decimal Costo, int CargaId)
        {
            ComisionAudiovisualDTO comisionAudiovisualDTO = new();
            comisionAudiovisualDTO.FechaComisionAudiovisual = FechaComisionAudiovisual;
            comisionAudiovisualDTO.CodigoPersonalComision = CodigoPersonalComision;
            comisionAudiovisualDTO.CodigoDependencia = CodigoDependencia;
            comisionAudiovisualDTO.Motivo = Motivo;
            comisionAudiovisualDTO.CodigoComision = CodigoComision;
            comisionAudiovisualDTO.Costo = Costo;
            comisionAudiovisualDTO.CargaId = CargaId;
            comisionAudiovisualDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = comisionAudiovisualBL.AgregarRegistro(comisionAudiovisualDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(comisionAudiovisualBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaComisionAudiovisual, string CodigoPersonalComision, string CodigoDependencia,
            string Motivo, string CodigoComision, decimal Costo)
        {
            ComisionAudiovisualDTO comisionAudiovisualDTO = new();
            comisionAudiovisualDTO.ComisionAudiovisualId = Id;
            comisionAudiovisualDTO.FechaComisionAudiovisual = FechaComisionAudiovisual;
            comisionAudiovisualDTO.CodigoPersonalComision = CodigoPersonalComision;
            comisionAudiovisualDTO.CodigoDependencia = CodigoDependencia;
            comisionAudiovisualDTO.Motivo = Motivo;
            comisionAudiovisualDTO.CodigoComision = CodigoComision;
            comisionAudiovisualDTO.Costo = Costo;

            comisionAudiovisualDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = comisionAudiovisualBL.ActualizarFormato(comisionAudiovisualDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ComisionAudiovisualDTO comisionAudiovisualDTO = new();
            comisionAudiovisualDTO.ComisionAudiovisualId = Id;
            comisionAudiovisualDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (comisionAudiovisualBL.EliminarFormato(comisionAudiovisualDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ComisionAudiovisualDTO> lista = new List<ComisionAudiovisualDTO>();
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

                    lista.Add(new ComisionAudiovisualDTO
                    {
                        FechaComisionAudiovisual = fila.GetCell(0).ToString(),
                        CodigoPersonalComision = fila.GetCell(1).ToString(),
                        CodigoDependencia = fila.GetCell(2).ToString(),
                        Motivo = fila.GetCell(3).ToString(),
                        CodigoComision = fila.GetCell(4).ToString(),
                        Costo = decimal.Parse(fila.GetCell(5).ToString()),


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

            dt.Columns.AddRange(new DataColumn[7]
            {
                    new DataColumn("FechaComisionAudiovisual", typeof(string)),
                    new DataColumn("CodigoPersonalComision", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("Motivo", typeof(string)),
                    new DataColumn("CodigoComision", typeof(string)),
                    new DataColumn("Costo", typeof(decimal)),  

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(

                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    decimal.Parse(fila.GetCell(5).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = comisionAudiovisualBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDCA(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dimar\\ComisionAudiovisual.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = comisionAudiovisualBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ComisionAudiovisual", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComisionAudiovisual.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComisionAudiovisual.xlsx");
        }
    }

}
