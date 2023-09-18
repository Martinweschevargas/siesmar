using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dincydet;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Data;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DincydetArchivoActividadEjecucionController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ArchivoActividadEjecucion archivoActividadEjecucionBL = new();
        Carga cargaBL = new();

        public DincydetArchivoActividadEjecucionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Archivo Actividades Trabajos de Investigación e Innovación Ejecución", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ArchivoActividadEjecucion");
            return Json(new { data1 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<ArchivoActividadEjecucionDTO> select = archivoActividadEjecucionBL.ObtenerLista();
            return Json(new { data = select });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato:43,Permiso:1)]//registrar

        public ActionResult Insertar(string DenominacionActividadEjecucion, string TipoTrabajoActividadEjecucion, int SituacionActualActividadEjecucion, 
            decimal FinanciamientoTPActividadEjecucion, decimal FinanciamientoRDRActividadEjecucion, decimal FinanciamientoTransferenciaActividadEjecucion,
            int CargaId, string Fecha)
        {
            ArchivoActividadEjecucionDTO archivoActividadEjecucionDTO = new();
            archivoActividadEjecucionDTO.DenominacionActividadEjecucion = DenominacionActividadEjecucion;
            archivoActividadEjecucionDTO.TipoTrabajoActividadEjecucion = TipoTrabajoActividadEjecucion;
            archivoActividadEjecucionDTO.SituacionActualActividadEjecucion = SituacionActualActividadEjecucion;
            archivoActividadEjecucionDTO.FinanciamientoTPActividadEjecucion = FinanciamientoTPActividadEjecucion;
            archivoActividadEjecucionDTO.FinanciamientoRDRActividadEjecucion = FinanciamientoRDRActividadEjecucion;
            archivoActividadEjecucionDTO.FinanciamientoTransferenciaActividadEjecucion = FinanciamientoTransferenciaActividadEjecucion;
            archivoActividadEjecucionDTO.CargaId = CargaId;
            archivoActividadEjecucionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = archivoActividadEjecucionBL.AgregarRegistro(archivoActividadEjecucionDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(archivoActividadEjecucionBL.BuscarFormato(Id));
        }

        //[AuthorizePermission(Formato: 43, Permiso: 2)]//Actualizar

        public ActionResult Actualizar(int Id, string DenominacionActividadEjecucion, string TipoTrabajoActividadEjecucion, int SituacionActualActividadEjecucion,
            decimal FinanciamientoTPActividadEjecucion, decimal FinanciamientoRDRActividadEjecucion, decimal FinanciamientoTransferenciaActividadEjecucion)
        {
            ArchivoActividadEjecucionDTO archivoActividadEjecucionDTO = new();
            archivoActividadEjecucionDTO.ArchivoActividadEjecucionId = Id;
            archivoActividadEjecucionDTO.DenominacionActividadEjecucion = DenominacionActividadEjecucion;
            archivoActividadEjecucionDTO.TipoTrabajoActividadEjecucion = TipoTrabajoActividadEjecucion;
            archivoActividadEjecucionDTO.SituacionActualActividadEjecucion = SituacionActualActividadEjecucion;
            archivoActividadEjecucionDTO.FinanciamientoTPActividadEjecucion = FinanciamientoTPActividadEjecucion;
            archivoActividadEjecucionDTO.FinanciamientoRDRActividadEjecucion = FinanciamientoRDRActividadEjecucion;
            archivoActividadEjecucionDTO.FinanciamientoTransferenciaActividadEjecucion = FinanciamientoTransferenciaActividadEjecucion;
            archivoActividadEjecucionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = archivoActividadEjecucionBL.ActualizarFormato(archivoActividadEjecucionDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 3)]//Eliminar

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ArchivoActividadEjecucionDTO archivoActividadEjecucionDTO = new();
            archivoActividadEjecucionDTO.ArchivoActividadEjecucionId = Id;
            archivoActividadEjecucionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (archivoActividadEjecucionBL.EliminarFormato(archivoActividadEjecucionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 5)]//Eliminar Carga

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ArchivoActividadEjecucionDTO archivoActividadEjecucionDTO = new();
            archivoActividadEjecucionDTO.CargaId = Id;
            archivoActividadEjecucionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (archivoActividadEjecucionBL.EliminarCarga(archivoActividadEjecucionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ArchivoActividadEjecucionDTO> lista = new List<ArchivoActividadEjecucionDTO>();
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

                    lista.Add(new ArchivoActividadEjecucionDTO
                    {
                        DenominacionActividadEjecucion = fila.GetCell(0).ToString(),
                        TipoTrabajoActividadEjecucion = fila.GetCell(1).ToString(),
                        SituacionActualActividadEjecucion = int.Parse(fila.GetCell(2).ToString()),
                        FinanciamientoTPActividadEjecucion = decimal.Parse(fila.GetCell(3).ToString()),
                        FinanciamientoRDRActividadEjecucion = decimal.Parse(fila.GetCell(4).ToString()),
                        FinanciamientoTransferenciaActividadEjecucion = decimal.Parse(fila.GetCell(5).ToString()),
 
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

            dt.Columns.AddRange(new DataColumn[7]
            {
                    new DataColumn("DenominacionActividadEjecucion", typeof(string)),
                    new DataColumn("TipoTrabajoActividadEjecucion", typeof(string)),
                    new DataColumn("SituacionActualActividadEjecucion", typeof(int)),
                    new DataColumn("FinanciamientoTPActividadEjecucion", typeof(decimal)),
                    new DataColumn("FinanciamientoRDRActividadEjecucion", typeof(decimal)),
                    new DataColumn("FinanciamientoTransferenciaActividadEjecucion", typeof(decimal)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    int.Parse(fila.GetCell(2).ToString()),
                    decimal.Parse(fila.GetCell(3).ToString()),
                    decimal.Parse(fila.GetCell(4).ToString()),
                    decimal.Parse(fila.GetCell(5).ToString()),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = archivoActividadEjecucionBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }
        
        public IActionResult Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            LocalReport localReport = new LocalReport(path);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DincydetArchivoActividadEjecucion.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DincydetArchivoActividadEjecucion.xlsx");
        }

    }

}