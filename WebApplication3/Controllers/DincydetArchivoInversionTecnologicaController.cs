using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dincydet;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dincydet;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Presentacion.Filters;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Atp;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DincydetArchivoInversionTecnologicaController : Controller
    {

        CapitaniaDAO capitaniaBL = new();
        private readonly IWebHostEnvironment _webHostEnviroment;
        ArchivoInversionTecnologica archivoInversionTecnologicaBL = new();
        AreaCT areaCTBL = new();
        Carga cargaBL = new();

        public DincydetArchivoInversionTecnologicaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Archivo Inversión Investigación, Desarrollo e Innovación Tecnológica", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<AreaCTDTO> AreaCTDTO = areaCTBL.ObtenerAreaCTs();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ArchivoInversionTecnologica");
            return Json(new { data1 = AreaCTDTO, data2 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<ArchivoInversionTecnologicaDTO> select = archivoInversionTecnologicaBL.ObtenerLista();
            return Json(new { data = select });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 43, Permiso: 1)]//registrar
        public ActionResult Insertar(string CodigoAreaCT, string TipoActividadInversionTec, decimal FinanciamientoTPInversionTec, 
            decimal FinanciamientoRDRInversionTec, decimal FinanciamientoTransferenciaInversionTec, int CargaId, string Fecha)
        {
            ArchivoInversionTecnologicaDTO archivoInversionTecnologicaDTO = new();
            archivoInversionTecnologicaDTO.CodigoAreaCT = CodigoAreaCT;
            archivoInversionTecnologicaDTO.TipoActividadInversionTec = TipoActividadInversionTec;
            archivoInversionTecnologicaDTO.FinanciamientoTPInversionTec = FinanciamientoTPInversionTec;
            archivoInversionTecnologicaDTO.FinanciamientoRDRInversionTec = FinanciamientoRDRInversionTec;
            archivoInversionTecnologicaDTO.FinanciamientoTransferenciaInversionTec = FinanciamientoTransferenciaInversionTec;
            archivoInversionTecnologicaDTO.CargaId = CargaId;
            archivoInversionTecnologicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = archivoInversionTecnologicaBL.AgregarRegistro(archivoInversionTecnologicaDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(archivoInversionTecnologicaBL.BuscarFormato(Id));
        }

        //[AuthorizePermission(Formato: 43, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string CodigoAreaCT, string TipoActividadInversionTec, decimal FinanciamientoTPInversionTec,
            decimal FinanciamientoRDRInversionTec, decimal FinanciamientoTransferenciaInversionTec)
        {
            ArchivoInversionTecnologicaDTO archivoInversionTecnologicaDTO = new();
            archivoInversionTecnologicaDTO.ArchivoInversionTecnologicaId = Id;
            archivoInversionTecnologicaDTO.CodigoAreaCT = CodigoAreaCT;
            archivoInversionTecnologicaDTO.TipoActividadInversionTec = TipoActividadInversionTec;
            archivoInversionTecnologicaDTO.FinanciamientoTPInversionTec = FinanciamientoTPInversionTec;
            archivoInversionTecnologicaDTO.FinanciamientoRDRInversionTec = FinanciamientoRDRInversionTec;
            archivoInversionTecnologicaDTO.FinanciamientoTransferenciaInversionTec = FinanciamientoTransferenciaInversionTec;
            archivoInversionTecnologicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = archivoInversionTecnologicaBL.ActualizarFormato(archivoInversionTecnologicaDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ArchivoInversionTecnologicaDTO archivoInversionTecnologicaDTO = new();
            archivoInversionTecnologicaDTO.ArchivoInversionTecnologicaId = Id;
            archivoInversionTecnologicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (archivoInversionTecnologicaBL.EliminarFormato(archivoInversionTecnologicaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //[AuthorizePermission(Formato: 43, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ArchivoInversionTecnologicaDTO archivoInversionTecnologicaDTO = new();
            archivoInversionTecnologicaDTO.CargaId = Id;
            archivoInversionTecnologicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (archivoInversionTecnologicaBL.EliminarCarga(archivoInversionTecnologicaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ArchivoInversionTecnologicaDTO> lista = new List<ArchivoInversionTecnologicaDTO>();
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

                    lista.Add(new ArchivoInversionTecnologicaDTO
                    {
                        CodigoAreaCT = fila.GetCell(0).ToString(),
                        TipoActividadInversionTec = fila.GetCell(1).ToString(),
                        FinanciamientoTPInversionTec = decimal.Parse(fila.GetCell(2).ToString()),
                        FinanciamientoRDRInversionTec = decimal.Parse(fila.GetCell(3).ToString()),
                        FinanciamientoTransferenciaInversionTec = decimal.Parse(fila.GetCell(4).ToString())
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
        //[AuthorizePermission(Formato: 43, Permiso: 4)]//Registrar Masivo
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string Fecha)
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

            dt.Columns.AddRange(new DataColumn[6]
            {
                    new DataColumn("CodigoAreaCT", typeof(string)),
                    new DataColumn("TipoActividadInversionTec", typeof(string)),
                    new DataColumn("FinanciamientoTPInversionTec", typeof(decimal)),
                    new DataColumn("FinanciamientoRDRInversionTec", typeof(decimal)),
                    new DataColumn("FinanciamientoTransferenciaInversionTec", typeof(decimal)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    decimal.Parse(fila.GetCell(2).ToString()),
                    decimal.Parse(fila.GetCell(3).ToString()),
                    decimal.Parse(fila.GetCell(4).ToString()),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = archivoInversionTecnologicaBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteAIT(int? CargaId = null)
        {

            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dincydet\\ArchivoInversionTecnologica.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var archivoInversionTecnologica = archivoInversionTecnologicaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ArchivoInversionTecnologica", archivoInversionTecnologica);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DincydetArchivoInversionTecnologica.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DincydetArchivoInversionTecnologica.xlsx");
        }
    }

}