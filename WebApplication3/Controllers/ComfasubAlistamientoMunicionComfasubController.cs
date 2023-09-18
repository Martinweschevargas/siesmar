using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comfasub;
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

    public class ComfasubAlistamientoMunicionComfasubController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        AlistamientoMunicionComfasub alistamientoMunicionComfasubBL = new();

        UnidadNaval unidadNavalBL = new();
        AlistamientoMunicion alistamientoMunicionBL = new();
        Carga cargaBL = new();
        public ComfasubAlistamientoMunicionComfasubController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Alistamiento de munición (AMU)", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<AlistamientoMunicionDTO> alistamientoMunicionDTO = alistamientoMunicionBL.ObtenerAlistamientoMunicions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoMunicionComfasub");

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = alistamientoMunicionDTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<AlistamientoMunicionComfasubDTO> select = alistamientoMunicionComfasubBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoAlistamientoMunicion, int CargaId, string Fecha)
        {
            AlistamientoMunicionComfasubDTO alistamientoMunicionComfasubDTO = new();
            alistamientoMunicionComfasubDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMunicionComfasubDTO.CodigoAlistamientoMunicion = CodigoAlistamientoMunicion;
            alistamientoMunicionComfasubDTO.CargaId = CargaId;
            alistamientoMunicionComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMunicionComfasubBL.AgregarRegistro(alistamientoMunicionComfasubDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistamientoMunicionComfasubBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoAlistamientoMunicion)
        {
            AlistamientoMunicionComfasubDTO alistamientoMunicionComfasubDTO = new();
            alistamientoMunicionComfasubDTO.AlistamientoMunicionComfasubId = Id;
            alistamientoMunicionComfasubDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMunicionComfasubDTO.CodigoAlistamientoMunicion = CodigoAlistamientoMunicion;


            alistamientoMunicionComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMunicionComfasubBL.ActualizarFormato(alistamientoMunicionComfasubDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistamientoMunicionComfasubDTO alistamientoMunicionComfasubDTO = new();
            alistamientoMunicionComfasubDTO.AlistamientoMunicionComfasubId = Id;
            alistamientoMunicionComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistamientoMunicionComfasubBL.EliminarFormato(alistamientoMunicionComfasubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AlistamientoMunicionComfasubDTO alistamientoMunicionComfasubDTO = new();
            alistamientoMunicionComfasubDTO.CargaId = Id;
            alistamientoMunicionComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (alistamientoMunicionComfasubBL.EliminarCarga(alistamientoMunicionComfasubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistamientoMunicionComfasubDTO> lista = new List<AlistamientoMunicionComfasubDTO>();
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

                    lista.Add(new AlistamientoMunicionComfasubDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoAlistamientoMunicion = fila.GetCell(1).ToString(),
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

            dt.Columns.AddRange(new DataColumn[3]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoAlistamientoMunicion", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = alistamientoMunicionComfasubBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = alistamientoMunicionComfasubBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfasubAlistamientoMunicionComfasub.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfasubAlistamientoMunicionComfasub.xlsx");
        }
    }

}

