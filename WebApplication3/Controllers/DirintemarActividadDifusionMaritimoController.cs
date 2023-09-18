using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dirintemar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
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
    public class DirintemarActividadDifusionMaritimoController : Controller
    {

        CapitaniaDAO capitaniaBL = new();
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        ActividadDifusionMaritimoDAO actividadddifusionMBL = new();
        TipoActividadDifusionDAO tipoactividaddifusionBL = new();
        public DirintemarActividadDifusionMaritimoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        [Breadcrumb(FromAction = "Index", Title = "Actividades de Difusión e Intereses Maritimos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoActividadDifusionDTO> tipoactivdifusionDTO = tipoactividaddifusionBL.ObtenerTipoActividadDifusions();
            return Json(new { data= tipoactivdifusionDTO });
        }

        public IActionResult CargaTabla()
        {
            List<ActividadDifusionMaritimoDTO> actividaddifusionMDTO = actividadddifusionMBL.ObtenerLista();
            return Json(new { data = actividaddifusionMDTO });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(int TipoActividadDifusionId, string NombreActDifusionMar, string AreaActDifusionMar,
           string ResponsableActDifusionMar, string InicioActDifusionMar, string TerminoActDifusionMar, string LugarActDifusionMar,
           int QParticipanteActDifusionMar, int QParticipanteEncuesta, int QPreguntaEncuestaOBS, int RptaCorrectasEncuenta,
           int RptaIncorrectaEncuenta, int PorcentRptaCorrectaEncuenta)
        {
            ActividadDifusionMaritimoDTO actividadDifusionMaritimoDTO = new();
            actividadDifusionMaritimoDTO.TipoActividadDifusionId = TipoActividadDifusionId;
            actividadDifusionMaritimoDTO.NombreActDifusionMar = NombreActDifusionMar;
            actividadDifusionMaritimoDTO.AreaActDifusionMar = AreaActDifusionMar;
            actividadDifusionMaritimoDTO.ResponsableActDifusionMar = ResponsableActDifusionMar;
            actividadDifusionMaritimoDTO.InicioActDifusionMar = InicioActDifusionMar;
            actividadDifusionMaritimoDTO.TerminoActDifusionMar = TerminoActDifusionMar;
            actividadDifusionMaritimoDTO.LugarActDifusionMar = LugarActDifusionMar;
            actividadDifusionMaritimoDTO.QParticipanteActDifusionMar = QParticipanteActDifusionMar;
            actividadDifusionMaritimoDTO.QParticipanteEncuesta = QParticipanteEncuesta;
            actividadDifusionMaritimoDTO.QPreguntaEncuestaOBS = QPreguntaEncuestaOBS;
            actividadDifusionMaritimoDTO.RptaCorrectasEncuenta = RptaCorrectasEncuenta;
            actividadDifusionMaritimoDTO.RptaIncorrectaEncuenta = RptaIncorrectaEncuenta;
            actividadDifusionMaritimoDTO.PorcentRptaCorrectaEncuenta = PorcentRptaCorrectaEncuenta;
            actividadDifusionMaritimoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actividadddifusionMBL.AgregarRegistro(actividadDifusionMaritimoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(actividadddifusionMBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int TipoActividadDifusionId, string NombreActDifusionMar, string AreaActDifusionMar,
           string ResponsableActDifusionMar, string InicioActDifusionMar, string TerminoActDifusionMar, string LugarActDifusionMar,
           int QParticipanteActDifusionMar, int QParticipanteEncuesta, int QPreguntaEncuestaOBS, int RptaCorrectasEncuenta,
           int RptaIncorrectaEncuenta, int PorcentRptaCorrectaEncuenta)
        {
            ActividadDifusionMaritimoDTO actividadDifusionMaritimoDTO = new();
            actividadDifusionMaritimoDTO.ActividadDifusionMaritimoId = Id;
            actividadDifusionMaritimoDTO.TipoActividadDifusionId = TipoActividadDifusionId;
            actividadDifusionMaritimoDTO.NombreActDifusionMar = NombreActDifusionMar;
            actividadDifusionMaritimoDTO.AreaActDifusionMar = AreaActDifusionMar;
            actividadDifusionMaritimoDTO.ResponsableActDifusionMar = ResponsableActDifusionMar;
            actividadDifusionMaritimoDTO.InicioActDifusionMar = InicioActDifusionMar;
            actividadDifusionMaritimoDTO.TerminoActDifusionMar = TerminoActDifusionMar;
            actividadDifusionMaritimoDTO.LugarActDifusionMar = LugarActDifusionMar;
            actividadDifusionMaritimoDTO.QParticipanteActDifusionMar = QParticipanteActDifusionMar;
            actividadDifusionMaritimoDTO.QParticipanteEncuesta = QParticipanteEncuesta;
            actividadDifusionMaritimoDTO.QPreguntaEncuestaOBS = QPreguntaEncuestaOBS;
            actividadDifusionMaritimoDTO.RptaCorrectasEncuenta = RptaCorrectasEncuenta;
            actividadDifusionMaritimoDTO.RptaIncorrectaEncuenta = RptaIncorrectaEncuenta;
            actividadDifusionMaritimoDTO.PorcentRptaCorrectaEncuenta = PorcentRptaCorrectaEncuenta;
            actividadDifusionMaritimoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actividadddifusionMBL.ActualizaFormato(actividadDifusionMaritimoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ActividadDifusionMaritimoDTO actividadDifusionMaritimoDTO = new();

            actividadDifusionMaritimoDTO.ActividadDifusionMaritimoId = Id;
            actividadDifusionMaritimoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (actividadddifusionMBL.EliminarFormato(actividadDifusionMaritimoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
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

            List<ActividadDifusionMaritimoDTO> lista = new List<ActividadDifusionMaritimoDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new ActividadDifusionMaritimoDTO
                {
                    ActividadDifusionMaritimoId = int.Parse(fila.GetCell(0).ToString()),
                    TipoActividadDifusionId = int.Parse(fila.GetCell(1).ToString()),
                    NombreActDifusionMar = fila.GetCell(2).ToString(),
                    AreaActDifusionMar = fila.GetCell(3).ToString(),
                    ResponsableActDifusionMar = fila.GetCell(4).ToString(),
                    InicioActDifusionMar = fila.GetCell(5).ToString(),
                    TerminoActDifusionMar = fila.GetCell(6).ToString(),
                    LugarActDifusionMar = fila.GetCell(7).ToString(),
                    QParticipanteActDifusionMar = int.Parse(fila.GetCell(8).ToString()),
                    QParticipanteEncuesta = int.Parse(fila.GetCell(9).ToString()),
                    QPreguntaEncuestaOBS = int.Parse(fila.GetCell(10).ToString()),
                    RptaCorrectasEncuenta = int.Parse(fila.GetCell(11).ToString()),
                    RptaIncorrectaEncuenta = int.Parse(fila.GetCell(12).ToString()),
                    PorcentRptaCorrectaEncuenta = int.Parse(fila.GetCell(13).ToString())
                });
            }
            return StatusCode(StatusCodes.Status200OK, lista);
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

            dt.Columns.AddRange(new DataColumn[14]
            {
                    new DataColumn("TipoActividadDifusionId", typeof(int)),
                    new DataColumn("NombreActDifusionMar", typeof(string)),
                    new DataColumn("AreaActDifusionMar", typeof(string)),
                    new DataColumn("ResponsableActDifusionMar", typeof(string)),
                    new DataColumn("InicioActDifusionMar", typeof(string)),
                    new DataColumn("TerminoActDifusionMar", typeof(string)),
                    new DataColumn("LugarActDifusionMar", typeof(string)),
                    new DataColumn("QParticipanteActDifusionMar", typeof(int)),
                    new DataColumn("QParticipanteEncuesta", typeof(int)),
                    new DataColumn("QPreguntaEncuestaOBS", typeof(int)),
                    new DataColumn("RptaCorrectasEncuenta", typeof(int)),
                    new DataColumn("RptaIncorrectaEncuenta", typeof(int)),
                    new DataColumn("PorcentRptaCorrectaEncuenta", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(4).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                    fila.GetCell(6).ToString(),
                    int.Parse(fila.GetCell(7).ToString()),
                    int.Parse(fila.GetCell(8).ToString()),
                    int.Parse(fila.GetCell(9).ToString()),
                    int.Parse(fila.GetCell(10).ToString()),
                    int.Parse(fila.GetCell(11).ToString()),
                    int.Parse(fila.GetCell(12).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = actividadddifusionMBL.InsertarDatos(dt);
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
            var result=localReport.Execute(RenderType.Pdf,extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        public IActionResult Print2()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report2.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            var Capitanias = capitaniaBL.ObtenerCapitanias();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirintemarActividadDifusionMaritimo.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirintemarActividadDifusionMaritimo.xlsx");
        }

    }

}