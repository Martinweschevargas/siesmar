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
    public class DirintemarVisitaMuseoNavalController : Controller
    {

        CapitaniaDAO capitaniaBL = new();
        private readonly IWebHostEnvironment _webHostEnviroment;
        VisitaMuseoNavalDAO visitamuseonavalBL = new();
        MuseoNavalDAO museonaval = new();

        public DirintemarVisitaMuseoNavalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Visita Registrada a los Museos Navales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MuseoNavalDTO> museoNavalDTO = museonaval.ObtenerMuseoNavals();
            return Json(new { data= museoNavalDTO });
        }

        public IActionResult CargaTabla()
        {
            List<VisitaMuseoNavalDTO> visitamuseonavalDTO = visitamuseonavalBL.ObtenerLista();
            return Json(new { data = visitamuseonavalDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]

        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(int MuseoNavalId, string PeriodoVisitaMuseoNaval, int QNinos,
           int QAdultos, int QEstudianteEscolar, int QEstudianteUniversitario, int QDocente,
           int QMilitar, int QFamiliaNavalAdulto, int QFamiliaNavalNino, int QPersonaDiscapacitada, int QAdultosCivilMayor65,
           int QExtranjera, int QOtroExtranjero, int QNochesLima, int TotalQVisita,
           int RacaudacionTotal)
        {
            VisitaMuseoNavalDTO visitamuseoDTO = new();
            visitamuseoDTO.MuseoNavalId = MuseoNavalId;
            visitamuseoDTO.PeriodoVisitaMuseoNaval = PeriodoVisitaMuseoNaval;
            visitamuseoDTO.QNinos = QNinos;
            visitamuseoDTO.QAdultos = QAdultos;
            visitamuseoDTO.QEstudianteEscolar = QEstudianteEscolar;
            visitamuseoDTO.QEstudianteUniversitario = QEstudianteUniversitario;
            visitamuseoDTO.QDocente = QDocente;
            visitamuseoDTO.QMilitar = QMilitar;
            visitamuseoDTO.QFamiliaNavalAdulto = QFamiliaNavalAdulto;
            visitamuseoDTO.QFamiliaNavalNino = QFamiliaNavalNino;
            visitamuseoDTO.QPersonaDiscapacitada = QPersonaDiscapacitada;
            visitamuseoDTO.QAdultosCivilMayor65 = QAdultosCivilMayor65;
            visitamuseoDTO.QExtranjera = QExtranjera;
            visitamuseoDTO.QOtroExtranjero = QOtroExtranjero;
            visitamuseoDTO.QNochesLima = QNochesLima;
            visitamuseoDTO.TotalQVisita = TotalQVisita;
            visitamuseoDTO.RacaudacionTotal = RacaudacionTotal;
            visitamuseoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = visitamuseonavalBL.AgregarRegistro(visitamuseoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(visitamuseonavalBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int MuseoNavalId, string PeriodoVisitaMuseoNaval, int QNinos,
           int QAdultos, int QEstudianteEscolar, int QEstudianteUniversitario, int QDocente,
           int QMilitar, int QFamiliaNavalAdulto, int QFamiliaNavalNino, int QPersonaDiscapacitada, int QAdultosCivilMayor65,
           int QExtranjera, int QOtroExtranjero, int QNochesLima, int TotalQVisita,
           int RacaudacionTotal)
        {
            VisitaMuseoNavalDTO visitamuseoDTO = new();
            visitamuseoDTO.VisitaMuseoNavalId = Id;
            visitamuseoDTO.MuseoNavalId = MuseoNavalId;
            visitamuseoDTO.PeriodoVisitaMuseoNaval = PeriodoVisitaMuseoNaval;
            visitamuseoDTO.QNinos = QNinos;
            visitamuseoDTO.QAdultos = QAdultos;
            visitamuseoDTO.QEstudianteEscolar = QEstudianteEscolar;
            visitamuseoDTO.QEstudianteUniversitario = QEstudianteUniversitario;
            visitamuseoDTO.QDocente = QDocente;
            visitamuseoDTO.QMilitar = QMilitar;
            visitamuseoDTO.QFamiliaNavalAdulto = QFamiliaNavalAdulto;
            visitamuseoDTO.QFamiliaNavalNino = QFamiliaNavalNino;
            visitamuseoDTO.QPersonaDiscapacitada = QPersonaDiscapacitada;
            visitamuseoDTO.QAdultosCivilMayor65 = QAdultosCivilMayor65;
            visitamuseoDTO.QExtranjera = QExtranjera;
            visitamuseoDTO.QOtroExtranjero = QOtroExtranjero;
            visitamuseoDTO.QNochesLima = QNochesLima;
            visitamuseoDTO.TotalQVisita = TotalQVisita;
            visitamuseoDTO.RacaudacionTotal = RacaudacionTotal;
            visitamuseoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = visitamuseonavalBL.ActualizaFormato(visitamuseoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            VisitaMuseoNavalDTO visitamuseoDTO = new();
            visitamuseoDTO.VisitaMuseoNavalId = Id;
            visitamuseoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (visitamuseonavalBL.EliminarFormato(visitamuseoDTO) == true)
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

            List<VisitaMuseoNavalDTO> lista = new List<VisitaMuseoNavalDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new VisitaMuseoNavalDTO
                {
                    VisitaMuseoNavalId = int.Parse(fila.GetCell(0).ToString()),
                    MuseoNavalId = int.Parse(fila.GetCell(1).ToString()),
                    PeriodoVisitaMuseoNaval = fila.GetCell(2).ToString(),
                    QNinos = int.Parse(fila.GetCell(3).ToString()),
                    QAdultos = int.Parse(fila.GetCell(4).ToString()),
                    QEstudianteEscolar = int.Parse(fila.GetCell(5).ToString()),
                    QEstudianteUniversitario = int.Parse(fila.GetCell(6).ToString()),
                    QDocente = int.Parse(fila.GetCell(7).ToString()),
                    QMilitar = int.Parse(fila.GetCell(8).ToString()),
                    QFamiliaNavalAdulto = int.Parse(fila.GetCell(9).ToString()),
                    QFamiliaNavalNino = int.Parse(fila.GetCell(10).ToString()),
                    QPersonaDiscapacitada = int.Parse(fila.GetCell(11).ToString()),
                    QAdultosCivilMayor65 = int.Parse(fila.GetCell(12).ToString()),
                    QExtranjera = int.Parse(fila.GetCell(13).ToString()),
                    QOtroExtranjero = int.Parse(fila.GetCell(14).ToString()),
                    QNochesLima = int.Parse(fila.GetCell(15).ToString()),
                    TotalQVisita = int.Parse(fila.GetCell(16).ToString()),
                    RacaudacionTotal = decimal.Parse(fila.GetCell(17).ToString())
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

            dt.Columns.AddRange(new DataColumn[18]
            {
                    new DataColumn("MuseoNavalId", typeof(int)),
                    new DataColumn("PeriodoVisitaMuseoNaval", typeof(string)),
                    new DataColumn("QNinos", typeof(int)),
                    new DataColumn("QAdultos", typeof(int)),
                    new DataColumn("QEstudianteEscolar", typeof(int)),
                    new DataColumn("QEstudianteUniversitario", typeof(int)),
                    new DataColumn("QDocente", typeof(int)),
                    new DataColumn("QMilitar", typeof(int)),
                    new DataColumn("QFamiliaNavalAdulto", typeof(int)),
                    new DataColumn("QFamiliaNavalNino", typeof(int)),
                    new DataColumn("QPersonaDiscapacitada", typeof(int)),
                    new DataColumn("QAdultosCivilMayor65", typeof(int)),
                    new DataColumn("QExtranjera", typeof(int)),
                    new DataColumn("QOtroExtranjero", typeof(int)),
                    new DataColumn("QNochesLima", typeof(int)),
                    new DataColumn("TotalQVisita", typeof(int)),
                    new DataColumn("RacaudacionTotal", typeof(int)),


                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    int.Parse(fila.GetCell(2).ToString()),
                    int.Parse(fila.GetCell(3).ToString()),
                    int.Parse(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    int.Parse(fila.GetCell(6).ToString()),
                    int.Parse(fila.GetCell(7).ToString()),
                    int.Parse(fila.GetCell(8).ToString()),
                    int.Parse(fila.GetCell(9).ToString()),
                    int.Parse(fila.GetCell(10).ToString()),
                    int.Parse(fila.GetCell(11).ToString()),
                    int.Parse(fila.GetCell(12).ToString()),
                    int.Parse(fila.GetCell(13).ToString()),
                    int.Parse(fila.GetCell(14).ToString()),
                    int.Parse(fila.GetCell(15).ToString()),
                    int.Parse(fila.GetCell(16).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = visitamuseonavalBL.InsertarDatos(dt);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirintemarVisitaMuseoNaval.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirintemarVisitaMuseoNaval.xlsx");
        }

    }

}