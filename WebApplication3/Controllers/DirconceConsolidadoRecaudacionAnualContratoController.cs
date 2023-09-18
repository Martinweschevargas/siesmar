using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dirconce;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dirconce;
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
    public class DirconceConsolidadoRecaudacionAnualContratoController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ConsolidadoRecaudacionAnualContrato consolidadoRecaudacionAnualContratoBL = new();
        Carga cargaBL = new();
        public DirconceConsolidadoRecaudacionAnualContratoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Consolidacion de Recaudacion Anual de los Contratos Vigentes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ConsolidadoRecaudacionAnualContrato");
            return Json(new { data1 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<ConsolidadoRecaudacionAnualContratoDTO> consolidadoRecaudacionAnualContratoDTO = consolidadoRecaudacionAnualContratoBL.ObtenerLista();
            return Json(new { data = consolidadoRecaudacionAnualContratoDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar( decimal ConsolidadoRecaudacionAnual, int CargaId, string Fecha)
        {
            ConsolidadoRecaudacionAnualContratoDTO consolidadoRecaudacionAnualContratoDTO = new();
            consolidadoRecaudacionAnualContratoDTO.ConsolidadoRecaudacionAnual = ConsolidadoRecaudacionAnual;
            consolidadoRecaudacionAnualContratoDTO.CargaId = CargaId;
            consolidadoRecaudacionAnualContratoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = consolidadoRecaudacionAnualContratoBL.AgregarRegistro(consolidadoRecaudacionAnualContratoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(consolidadoRecaudacionAnualContratoBL.EditarFormado(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int ConsolidadoRecaudacionAnualContratoId, decimal ConsolidadoRecaudacionAnual)
        {
            ConsolidadoRecaudacionAnualContratoDTO consolidadoRecaudacionAnualContratoDTO = new();
            consolidadoRecaudacionAnualContratoDTO.ConsolidadoRecaudacionAnualContratoId = ConsolidadoRecaudacionAnualContratoId;
            consolidadoRecaudacionAnualContratoDTO.ConsolidadoRecaudacionAnual = ConsolidadoRecaudacionAnual;
            consolidadoRecaudacionAnualContratoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = consolidadoRecaudacionAnualContratoBL.ActualizarFormato(consolidadoRecaudacionAnualContratoDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ConsolidadoRecaudacionAnualContratoDTO consolidadoRecaudacionAnualContratoDTO = new();
            consolidadoRecaudacionAnualContratoDTO.ConsolidadoRecaudacionAnualContratoId = Id;
            consolidadoRecaudacionAnualContratoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (consolidadoRecaudacionAnualContratoBL.EliminarFormato(consolidadoRecaudacionAnualContratoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }


        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ConsolidadoRecaudacionAnualContratoDTO consolidadoRecaudacionAnualContratoDTO = new();
            consolidadoRecaudacionAnualContratoDTO.CargaId = Id;
            consolidadoRecaudacionAnualContratoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (consolidadoRecaudacionAnualContratoBL.EliminarCarga(consolidadoRecaudacionAnualContratoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ConsolidadoRecaudacionAnualContratoDTO> lista = new List<ConsolidadoRecaudacionAnualContratoDTO>();
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

                    lista.Add(new ConsolidadoRecaudacionAnualContratoDTO
                    {
                        ConsolidadoRecaudacionAnual = decimal.Parse(fila.GetCell(0).ToString())
 
                    });
                }
            }
            catch (Exception)
            {
                Mensaje = "0";
            }
            return Json(new { data = Mensaje, data1 = lista });
        }

        [HttpPost]
        //Registrar Masivo[AuthorizePermission(Formato: 43, Permiso: 4)]
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

            dt.Columns.AddRange(new DataColumn[2]
            {
                    new DataColumn("ConsolidadoRecaudacionAnual", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    decimal.Parse(fila.GetCell(0).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = consolidadoRecaudacionAnualContratoBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteCRAC(int? CargaId = null)
        {

            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirconce\\ConsolidadoRecaudacionAnualContrato.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var consolidadoRecaudacionAnualContrato = consolidadoRecaudacionAnualContratoBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ConsolidadoRecaudacionAnualContrato", consolidadoRecaudacionAnualContrato);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirconceConsolidadoRecaudacionAnualContrato.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirconceConsolidadoRecaudacionAnualContrato.xlsx");
        }
    }

}