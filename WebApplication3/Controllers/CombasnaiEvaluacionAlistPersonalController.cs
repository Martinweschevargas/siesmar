using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Combasnai;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Formatos.Combasnai;
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

    public class CombasnaiEvaluacionAlistPersonalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        EvaluacionAlistPersonalCombasnai evaluacionAlistPersonalCombasnaiBL = new();

        UnidadNaval unidadNavalBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EspecialidadGenericaPersonal especialidadGenericaPersonalBL = new();

        public CombasnaiEvaluacionAlistPersonalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Evaluación deL Alistamiento de Personal", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = gradoPersonalMilitarDTO,
                data3 = especialidadGenericaPersonalDTO
            });
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionAlistPersonalCombasnaiDTO> select = evaluacionAlistPersonalCombasnaiBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(int UnidadNavalId, string FechaEvaluacion, int DNIPersonal, int CIPPersonal, string Cargo, int GradoPersonalMilitarEsperado,
            int EspecialidadGenericaEsperado, int GradoPersonalMilitarActual, int EspecialidadGenericaActual, decimal GradoJerarquico, decimal ServicioExperiencia,
            decimal EspecializacionProfesional, decimal CursoProfesionalRequerido)
        {
            EvaluacionAlistPersonalCombasnaiDTO evaluacionAlistPersonalCombasnaiDTO = new();
            evaluacionAlistPersonalCombasnaiDTO.UnidadNavalId = UnidadNavalId;
            evaluacionAlistPersonalCombasnaiDTO.FechaEvaluacion = FechaEvaluacion;
            evaluacionAlistPersonalCombasnaiDTO.DNIPersonal = DNIPersonal;
            evaluacionAlistPersonalCombasnaiDTO.CIPPersonal = CIPPersonal;
            evaluacionAlistPersonalCombasnaiDTO.Cargo = Cargo;
            evaluacionAlistPersonalCombasnaiDTO.GradoPersonalMilitarEsperado = GradoPersonalMilitarEsperado;
            evaluacionAlistPersonalCombasnaiDTO.EspecialidadGenericaEsperado = EspecialidadGenericaEsperado;
            evaluacionAlistPersonalCombasnaiDTO.GradoPersonalMilitarActual = GradoPersonalMilitarActual;
            evaluacionAlistPersonalCombasnaiDTO.EspecialidadGenericaActual = EspecialidadGenericaActual;
            evaluacionAlistPersonalCombasnaiDTO.GradoJerarquico = GradoJerarquico;
            evaluacionAlistPersonalCombasnaiDTO.ServicioExperiencia = ServicioExperiencia;
            evaluacionAlistPersonalCombasnaiDTO.EspecializacionProfesional = EspecializacionProfesional;
            evaluacionAlistPersonalCombasnaiDTO.CursoProfesionalRequerido = CursoProfesionalRequerido;
            evaluacionAlistPersonalCombasnaiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistPersonalCombasnaiBL.AgregarRegistro(evaluacionAlistPersonalCombasnaiDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistPersonalCombasnaiBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int UnidadNavalId, string FechaEvaluacion, int DNIPersonal, int CIPPersonal, string Cargo,
            int GradoPersonalMilitarEsperado, int EspecialidadGenericaEsperado, int GradoPersonalMilitarActual, int EspecialidadGenericaActual,
            decimal GradoJerarquico, decimal ServicioExperiencia, decimal EspecializacionProfesional, decimal CursoProfesionalRequerido)
        {
            EvaluacionAlistPersonalCombasnaiDTO evaluacionAlistPersonalCombasnaiDTO = new();
            evaluacionAlistPersonalCombasnaiDTO.EvaluacionAlistamientoPersonalId = Id;
            evaluacionAlistPersonalCombasnaiDTO.UnidadNavalId = UnidadNavalId;
            evaluacionAlistPersonalCombasnaiDTO.FechaEvaluacion = FechaEvaluacion;
            evaluacionAlistPersonalCombasnaiDTO.DNIPersonal = DNIPersonal;
            evaluacionAlistPersonalCombasnaiDTO.CIPPersonal = CIPPersonal;
            evaluacionAlistPersonalCombasnaiDTO.Cargo = Cargo;
            evaluacionAlistPersonalCombasnaiDTO.GradoPersonalMilitarEsperado = GradoPersonalMilitarEsperado;
            evaluacionAlistPersonalCombasnaiDTO.EspecialidadGenericaEsperado = EspecialidadGenericaEsperado;
            evaluacionAlistPersonalCombasnaiDTO.GradoPersonalMilitarActual = GradoPersonalMilitarActual;
            evaluacionAlistPersonalCombasnaiDTO.EspecialidadGenericaActual = EspecialidadGenericaActual;
            evaluacionAlistPersonalCombasnaiDTO.GradoJerarquico = GradoJerarquico;
            evaluacionAlistPersonalCombasnaiDTO.ServicioExperiencia = ServicioExperiencia;
            evaluacionAlistPersonalCombasnaiDTO.EspecializacionProfesional = EspecializacionProfesional;
            evaluacionAlistPersonalCombasnaiDTO.CursoProfesionalRequerido = CursoProfesionalRequerido;
            evaluacionAlistPersonalCombasnaiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistPersonalCombasnaiBL.ActualizarFormato(evaluacionAlistPersonalCombasnaiDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistPersonalCombasnaiDTO evaluacionAlistPersonalCombasnaiDTO = new();
            evaluacionAlistPersonalCombasnaiDTO.EvaluacionAlistamientoPersonalId = Id;
            evaluacionAlistPersonalCombasnaiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionAlistPersonalCombasnaiBL.EliminarFormato(evaluacionAlistPersonalCombasnaiDTO) == true)
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

            List<EvaluacionAlistPersonalCombasnaiDTO> lista = new List<EvaluacionAlistPersonalCombasnaiDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new EvaluacionAlistPersonalCombasnaiDTO
                {

                    UnidadNavalId = int.Parse(fila.GetCell(0).ToString()),
                    FechaEvaluacion = fila.GetCell(1).ToString(),
                    DNIPersonal = int.Parse(fila.GetCell(2).ToString()),
                    CIPPersonal = int.Parse(fila.GetCell(3).ToString()),
                    Cargo = fila.GetCell(4).ToString(),
                    GradoPersonalMilitarEsperado = int.Parse(fila.GetCell(5).ToString()),
                    EspecialidadGenericaEsperado = int.Parse(fila.GetCell(6).ToString()),
                    GradoPersonalMilitarActual = int.Parse(fila.GetCell(7).ToString()),
                    EspecialidadGenericaActual = int.Parse(fila.GetCell(8).ToString()),
                    GradoJerarquico = decimal.Parse(fila.GetCell(9).ToString()),
                    ServicioExperiencia = decimal.Parse(fila.GetCell(10).ToString()),
                    EspecializacionProfesional = decimal.Parse(fila.GetCell(11).ToString()),
                    CursoProfesionalRequerido = decimal.Parse(fila.GetCell(12).ToString()),

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

            dt.Columns.AddRange(new DataColumn[13]
            {
                    new DataColumn("UnidadNavalId", typeof(int)),
                    new DataColumn("FechaEvaluacion", typeof(string)),
                    new DataColumn("DNIPersonal", typeof(int)),
                    new DataColumn("CIPPersonal", typeof(int)),
                    new DataColumn("Cargo", typeof(string)),
                    new DataColumn("GradoPersonalMilitarEsperado", typeof(int)),
                    new DataColumn("EspecialidadGenericaEsperado", typeof(int)),
                    new DataColumn("GradoPersonalMilitarActual", typeof(int)),
                    new DataColumn("EspecialidadGenericaActual", typeof(int)),
                    new DataColumn("GradoJerarquico", typeof(decimal)),
                    new DataColumn("ServicioExperiencia", typeof(decimal)),
                    new DataColumn("EspecializacionProfesional", typeof(decimal)),
                    new DataColumn("CursoProfesionalRequerido", typeof(decimal)),
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                    int.Parse(fila.GetCell(2).ToString()),
                    int.Parse(fila.GetCell(3).ToString()),
                    fila.GetCell(4).ToString(),
                    int.Parse(fila.GetCell(5).ToString()),
                    int.Parse(fila.GetCell(6).ToString()),
                    int.Parse(fila.GetCell(7).ToString()),
                    int.Parse(fila.GetCell(8).ToString()),
                    decimal.Parse(fila.GetCell(9).ToString()),
                    decimal.Parse(fila.GetCell(10).ToString()),
                    decimal.Parse(fila.GetCell(11).ToString()),
                    decimal.Parse(fila.GetCell(12).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = evaluacionAlistPersonalCombasnaiBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //Alistamiento Material Combasnai
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Combasnai\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var evaluacionAlistPersonalCombasnais = evaluacionAlistPersonalCombasnaiBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EvaluacionAlistPersonalCombasnai", evaluacionAlistPersonalCombasnais);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\EvaluacionAlistPersonalCombasnai.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "EvaluacionAlistPersonalCombasnai.xlsx");
        }

        //public IActionResult ReportePMPIACR()
        //{
        //    //PROMEDIO MENSUAL DE PARTICIPANTES Y DE INVERSIÓN EN ACTIVIDADES CULTURALES REALIZADAS
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMPIACR.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReportePII()
        //{
        //    //PUBLICACIONES DE INTERÉS INSTITUCIONAL
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePII.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReportePMCB()
        //{
        //    //PROMEDIO MENSUAL DE CONSULTAS BIBLIOGRÁFICAS
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMCB.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReportePMVAHM()
        //{
        //    //PROMEDIO MENSUAL DE VISITAS AL ARCHIVO HISTÓRICO DE LA MARINA
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMVAHM.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReportePMVRMN()
        //{
        //    //PROMEDIO MENSUAL DE VISITAS REGISTRADAS A LOS MUSEOS NAVALES
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMVRMN.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReporteTRC()
        //{
        //    //TRABAJOS DE RESTAURACIÓN Y/O CONSERVACIÓN
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReporteTRC.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReporteRMHPRM()
        //{
        //    //REPRESENTACIÓN Y/ O MONUMENTOS HISTORICOS EN EL PAIS RELACIONADOS A LA MARINA
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReporteRMHPRM.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReporteAAD()
        //{
        //    //APOYO A LAS ACTIVIDADES DE DIFUSIÓN
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReporteAAD.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReportePMPADRIM()
        //{
        //    //PROMEDIO MENSUAL DE PARTICIPANTES A ACTIVIDADES DE DIFUSIÓN DE REALIDAD E INTERESES MARITIMOS
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMPADRIM.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    //localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReportePMPOADRIM()
        //{
        //    //PROMEDIO MENSUAL DE PARTICIPANTES A OTRAS ACTIVIDADES DE DIFUSIÓN DE REALIDAD E INTERESES MARITIMOS
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMPOADRIM.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    var estudioInvestigacionesHistoricasNavales = documentoIntelFrenteInternoBL.ObtenerLista();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("EstudioInvestigacionHistoricasNavales", estudioInvestigacionesHistoricasNavales);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

    }

}

