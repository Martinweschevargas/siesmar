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
    public class DincydetArchivoActividadCulminadoExitoController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ArchivoActividadCulminadoExito archivoActividadCulminadoExitoBL = new();
        AreaCT areaCTBL = new();
        Carga cargaBL = new();

        public DincydetArchivoActividadCulminadoExitoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        [Breadcrumb(FromAction = "Index", Title = "Archivo Actividades Trabajos de Investigación e Innovación Culminados con Éxito", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<AreaCTDTO> AreaCTDTO = areaCTBL.ObtenerAreaCTs();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ArchivoActividadCulminadoExito");
            return Json(new { data1 = AreaCTDTO, data2 = listaCargas 
            });
        }

        public IActionResult CargaTabla()
        {
            List<ArchivoActividadCulminadoExitoDTO> select = archivoActividadCulminadoExitoBL.ObtenerLista();
            return Json(new { data = select });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 43, Permiso: 1)]//registrar
        public ActionResult Insertar(string DenominacionActividadCulminado, string TipoTrabajoActividadCulminado, string EtapaActividadCulminado, 
            decimal FinanciamientoTPActividadCulminado, decimal FinanciamientoRDRActividadCulminado, decimal FinanciamientoTransferenciaActividadCulminado,
            string CodigoAreaCT, int CargaId, string Fecha)
        {
            ArchivoActividadCulminadoExitoDTO archivoActividadCulminadoExitoDTO = new();
            archivoActividadCulminadoExitoDTO.DenominacionActividadCulminado = DenominacionActividadCulminado;
            archivoActividadCulminadoExitoDTO.TipoTrabajoActividadCulminado = TipoTrabajoActividadCulminado;
            archivoActividadCulminadoExitoDTO.EtapaActividadCulminado = EtapaActividadCulminado;
            archivoActividadCulminadoExitoDTO.FinanciamientoTPActividadCulminado = FinanciamientoTPActividadCulminado;
            archivoActividadCulminadoExitoDTO.FinanciamientoRDRActividadCulminado = FinanciamientoRDRActividadCulminado;
            archivoActividadCulminadoExitoDTO.FinanciamientoTransferenciaActividadCulminado = FinanciamientoTransferenciaActividadCulminado;
            archivoActividadCulminadoExitoDTO.CodigoAreaCT = CodigoAreaCT;
            archivoActividadCulminadoExitoDTO.CargaId = CargaId;
            archivoActividadCulminadoExitoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = archivoActividadCulminadoExitoBL.AgregarRegistro(archivoActividadCulminadoExitoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(archivoActividadCulminadoExitoBL.EditarFormato(Id));
        }

        //[AuthorizePermission(Formato: 43, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string DenominacionActividadCulminado, string TipoTrabajoActividadCulminado, string EtapaActividadCulminado,
            decimal FinanciamientoTPActividadCulminado, decimal FinanciamientoRDRActividadCulminado, decimal FinanciamientoTransferenciaActividadCulminado,
            string CodigoAreaCT)
        {

            ArchivoActividadCulminadoExitoDTO archivoActividadCulminadoExitoDTO = new();
            archivoActividadCulminadoExitoDTO.ArchivoActividadCulminadoExitoId = Id;
            archivoActividadCulminadoExitoDTO.DenominacionActividadCulminado = DenominacionActividadCulminado;
            archivoActividadCulminadoExitoDTO.TipoTrabajoActividadCulminado = TipoTrabajoActividadCulminado;
            archivoActividadCulminadoExitoDTO.EtapaActividadCulminado = EtapaActividadCulminado;
            archivoActividadCulminadoExitoDTO.FinanciamientoTPActividadCulminado = FinanciamientoTPActividadCulminado;
            archivoActividadCulminadoExitoDTO.FinanciamientoRDRActividadCulminado = FinanciamientoRDRActividadCulminado;
            archivoActividadCulminadoExitoDTO.FinanciamientoTransferenciaActividadCulminado = FinanciamientoTransferenciaActividadCulminado;
            archivoActividadCulminadoExitoDTO.CodigoAreaCT = CodigoAreaCT;
            archivoActividadCulminadoExitoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = archivoActividadCulminadoExitoBL.ActualizarFormato(archivoActividadCulminadoExitoDTO);
            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ArchivoActividadCulminadoExitoDTO archivoActividadCulminadoExitoDTO = new();
            archivoActividadCulminadoExitoDTO.ArchivoActividadCulminadoExitoId = Id;
            archivoActividadCulminadoExitoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (archivoActividadCulminadoExitoBL.EliminarFormato(archivoActividadCulminadoExitoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ArchivoActividadCulminadoExitoDTO archivoActividadCulminadoExitoDTO = new();
            archivoActividadCulminadoExitoDTO.CargaId = Id;
            archivoActividadCulminadoExitoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (archivoActividadCulminadoExitoBL.EliminarCarga(archivoActividadCulminadoExitoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ArchivoActividadCulminadoExitoDTO> lista = new List<ArchivoActividadCulminadoExitoDTO>();
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

                    lista.Add(new ArchivoActividadCulminadoExitoDTO
                    {
                        DenominacionActividadCulminado = fila.GetCell(0).ToString(),
                        TipoTrabajoActividadCulminado = fila.GetCell(1).ToString(),
                        EtapaActividadCulminado = fila.GetCell(2).ToString(),
                        FinanciamientoTPActividadCulminado = decimal.Parse(fila.GetCell(3).ToString()),
                        FinanciamientoRDRActividadCulminado = decimal.Parse(fila.GetCell(4).ToString()),
                        FinanciamientoTransferenciaActividadCulminado = decimal.Parse(fila.GetCell(5).ToString()),
                        CodigoAreaCT = fila.GetCell(6).ToString()
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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("DenominacionActividadCulminado", typeof(string)),
                    new DataColumn("TipoTrabajoActividadCulminado", typeof(string)),
                    new DataColumn("EtapaActividadCulminado", typeof(string)),
                    new DataColumn("FinanciamientoTPActividadCulminado", typeof(decimal)),
                    new DataColumn("FinanciamientoRDRActividadCulminado", typeof(decimal)),
                    new DataColumn("FinanciamientoTransferenciaActividadCulminado", typeof(decimal)),
                    new DataColumn("CodigoAreaCT", typeof(string)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    decimal.Parse(fila.GetCell(3).ToString()),
                    decimal.Parse(fila.GetCell(4).ToString()),
                    decimal.Parse(fila.GetCell(5).ToString()),
                    fila.GetCell(6).ToString(),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = archivoActividadCulminadoExitoBL.InsertarDatos(dt,Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            LocalReport localReport = new LocalReport(path);
            var result=localReport.Execute(RenderType.Pdf,extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DincydetArchivoActividadCulminadoExito.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DincydetArchivoActividadCulminadoExito.xlsx");
        }
    }

}