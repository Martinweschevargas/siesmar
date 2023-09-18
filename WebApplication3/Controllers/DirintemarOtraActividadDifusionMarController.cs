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
    public class DirintemarOtraActividadDifusionMarController : Controller
    {

        CapitaniaDAO capitaniaBL = new();
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        OtraActividadDifusionMarDAO otraactividadfusionmarBL = new();
        TipoActividadDifusionDAO tipoactividaddifusionBL = new();
        DirigidoADAO dirigidoABL = new();
        public DirintemarOtraActividadDifusionMarController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        [Breadcrumb(FromAction = "Index", Title = "Otra Actividades de Difusión e Interés Maritimo", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoActividadDifusionDTO> tipoactivdifusionDTO = tipoactividaddifusionBL.ObtenerTipoActividadDifusions();
            List<DirigidoADTO> dirigidoADTO = dirigidoABL.ObtenerDirigidoAs();
            return Json(new { data1 = tipoactivdifusionDTO, data2 = dirigidoADTO });
        }

        public IActionResult CargaTabla()
        {
            List<OtraActividadDifusionMarDTO> otraActividadDifusionMarDTO = otraactividadfusionmarBL.ObtenerLista();
            return Json(new { data = otraActividadDifusionMarDTO });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(int TipoActividadDifusionId, string NombreOtraActDifusionMar, string AreaOtraActDifusionMar,
           string ResponsableOtraActDifusionMar, string InicioOtraActDifusionMar, string TerminoOtraActDifusionMar, string LugarOtraActDifusionMar,
           int DirigidoAId, int QParticipanteOtraActDifusionMar, int QParticipanteEncuestaOtra,
           int QPreguntaEncuestaOtraOBS, int RptaCorrectaEncuentaOtra, int RptaIncorrectaEncuentaOtra,
           int PorcentRptaCorrectaEncuentaOtra)
        {
            OtraActividadDifusionMarDTO otraActividadDifusionMarDTO = new();
            otraActividadDifusionMarDTO.TipoActividadDifusionId = TipoActividadDifusionId;
            otraActividadDifusionMarDTO.NombreOtraActDifusionMar = NombreOtraActDifusionMar;
            otraActividadDifusionMarDTO.AreaOtraActDifusionMar = AreaOtraActDifusionMar;
            otraActividadDifusionMarDTO.ResponsableOtraActDifusionMar = ResponsableOtraActDifusionMar;
            otraActividadDifusionMarDTO.InicioOtraActDifusionMar = InicioOtraActDifusionMar;
            otraActividadDifusionMarDTO.TerminoOtraActDifusionMar = TerminoOtraActDifusionMar;
            otraActividadDifusionMarDTO.LugarOtraActDifusionMar = LugarOtraActDifusionMar;
            otraActividadDifusionMarDTO.DirigidoAId = DirigidoAId;
            otraActividadDifusionMarDTO.QParticipanteOtraActDifusionMar = QParticipanteOtraActDifusionMar;
            otraActividadDifusionMarDTO.QParticipanteEncuestaOtra = QParticipanteEncuestaOtra;
            otraActividadDifusionMarDTO.QPreguntaEncuestaOtraOBS = QPreguntaEncuestaOtraOBS;
            otraActividadDifusionMarDTO.RptaCorrectaEncuentaOtra = RptaCorrectaEncuentaOtra;
            otraActividadDifusionMarDTO.RptaIncorrectaEncuentaOtra = RptaIncorrectaEncuentaOtra;
            otraActividadDifusionMarDTO.PorcentRptaCorrectaEncuentaOtra = PorcentRptaCorrectaEncuentaOtra;
            otraActividadDifusionMarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = otraactividadfusionmarBL.AgregarRegistro(otraActividadDifusionMarDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(otraactividadfusionmarBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int TipoActividadDifusionId, string NombreOtraActDifusionMar, string AreaOtraActDifusionMar,
           string ResponsableOtraActDifusionMar, string InicioOtraActDifusionMar, string TerminoOtraActDifusionMar, string LugarOtraActDifusionMar,
           int DirigidoAId, int QParticipanteOtraActDifusionMar, int QParticipanteEncuestaOtra,
           int QPreguntaEncuestaOtraOBS, int RptaCorrectaEncuentaOtra, int RptaIncorrectaEncuentaOtra,
           int PorcentRptaCorrectaEncuentaOtra)
        {
            OtraActividadDifusionMarDTO otraActividadDifusionMarDTO = new();
            otraActividadDifusionMarDTO.OtraActDifusionMarId = Id;
            otraActividadDifusionMarDTO.TipoActividadDifusionId = TipoActividadDifusionId;
            otraActividadDifusionMarDTO.NombreOtraActDifusionMar = NombreOtraActDifusionMar;
            otraActividadDifusionMarDTO.AreaOtraActDifusionMar = AreaOtraActDifusionMar;
            otraActividadDifusionMarDTO.ResponsableOtraActDifusionMar = ResponsableOtraActDifusionMar;
            otraActividadDifusionMarDTO.InicioOtraActDifusionMar = InicioOtraActDifusionMar;
            otraActividadDifusionMarDTO.TerminoOtraActDifusionMar = TerminoOtraActDifusionMar;
            otraActividadDifusionMarDTO.LugarOtraActDifusionMar = LugarOtraActDifusionMar;
            otraActividadDifusionMarDTO.DirigidoAId = DirigidoAId;
            otraActividadDifusionMarDTO.QParticipanteOtraActDifusionMar = QParticipanteOtraActDifusionMar;
            otraActividadDifusionMarDTO.QParticipanteEncuestaOtra = QParticipanteEncuestaOtra;
            otraActividadDifusionMarDTO.QPreguntaEncuestaOtraOBS = QPreguntaEncuestaOtraOBS;
            otraActividadDifusionMarDTO.RptaCorrectaEncuentaOtra = RptaCorrectaEncuentaOtra;
            otraActividadDifusionMarDTO.RptaIncorrectaEncuentaOtra = RptaIncorrectaEncuentaOtra;
            otraActividadDifusionMarDTO.PorcentRptaCorrectaEncuentaOtra = PorcentRptaCorrectaEncuentaOtra;
            otraActividadDifusionMarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = otraactividadfusionmarBL.ActualizaFormato(otraActividadDifusionMarDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            OtraActividadDifusionMarDTO otraActividadDifusionMarDTO = new();
            otraActividadDifusionMarDTO.OtraActDifusionMarId = Id;
            otraActividadDifusionMarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (otraactividadfusionmarBL.EliminarFormato(otraActividadDifusionMarDTO) == true)
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

            List<OtraActividadDifusionMarDTO> lista = new List<OtraActividadDifusionMarDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new OtraActividadDifusionMarDTO
                {
                    OtraActDifusionMarId = int.Parse(fila.GetCell(0).ToString()),
                    TipoActividadDifusionId = int.Parse(fila.GetCell(1).ToString()),
                    NombreOtraActDifusionMar = fila.GetCell(2).ToString(),
                    AreaOtraActDifusionMar = fila.GetCell(3).ToString(),
                    ResponsableOtraActDifusionMar = fila.GetCell(4).ToString(),
                    InicioOtraActDifusionMar = fila.GetCell(5).ToString(),
                    TerminoOtraActDifusionMar = fila.GetCell(6).ToString(),
                    LugarOtraActDifusionMar = fila.GetCell(7).ToString(),
                    DirigidoAId = int.Parse(fila.GetCell(8).ToString()),
                    QParticipanteOtraActDifusionMar = int.Parse(fila.GetCell(9).ToString()),
                    QParticipanteEncuestaOtra = int.Parse(fila.GetCell(10).ToString()),
                    QPreguntaEncuestaOtraOBS = int.Parse(fila.GetCell(11).ToString()),
                    RptaCorrectaEncuentaOtra = int.Parse(fila.GetCell(12).ToString()),
                    RptaIncorrectaEncuentaOtra = int.Parse(fila.GetCell(13).ToString()),
                    PorcentRptaCorrectaEncuentaOtra = int.Parse(fila.GetCell(14).ToString())
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

            dt.Columns.AddRange(new DataColumn[15]
            {
                    new DataColumn("TipoActividadDifusionId", typeof(int)),
                    new DataColumn("NombreOtraActDifusionMar", typeof(string)),
                    new DataColumn("AreaOtraActDifusionMar", typeof(string)),
                    new DataColumn("ResponsableOtraActDifusionMar", typeof(string)),
                    new DataColumn("InicioOtraActDifusionMar", typeof(string)),
                    new DataColumn("TerminoOtraActDifusionMar", typeof(string)),
                    new DataColumn("LugarOtraActDifusionMar", typeof(string)),
                    new DataColumn("DirigidoAId", typeof(int)),
                    new DataColumn("QParticipanteOtraActDifusionMar", typeof(int)),
                    new DataColumn("QParticipanteEncuestaOtra", typeof(int)),
                    new DataColumn("QPreguntaEncuestaOtraOBS", typeof(int)),
                    new DataColumn("RptaCorrectaEncuentaOtra", typeof(int)),
                    new DataColumn("RptaIncorrectaEncuentaOtra", typeof(int)),
                    new DataColumn("PorcentRptaCorrectaEncuentaOtra", typeof(int)),
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
                    int.Parse(fila.GetCell(13).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = otraactividadfusionmarBL.InsertarDatos(dt);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirintemarOtraActividadDifusionMar.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirintemarOtraActividadDifusionMar.xlsx");
        }

    }

}