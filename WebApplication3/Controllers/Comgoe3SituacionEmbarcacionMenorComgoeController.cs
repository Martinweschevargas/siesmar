using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Comflotflu;
using Marina.Siesmar.Entidades.Formatos.Comgoe3;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Formatos.Comflotflu;
using Marina.Siesmar.LogicaNegocios.Formatos.Comgoe3;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class Comgoe3SituacionEmbarcacionMenorComgoeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        SituacionEmbarcacionMenorComgoe situacionEmbarcacionMenorComgoeBL = new();

        UnidadNaval unidadNavalBL = new();
        TipoNave tipoNaveBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        Condicion condicionBL = new();
        CapacidadOperativaRequerida capacidadOperativaRequeridaBL = new();

        public Comgoe3SituacionEmbarcacionMenorComgoeController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Situación de embarcaciones menores", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<TipoNaveDTO> tipoNaveDTO = tipoNaveBL.ObtenerTipoNaves();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<CondicionDTO> condicionDTO = condicionBL.ObtenerCondicions();
            List<CapacidadOperativaRequeridaDTO> capacidadOperativaRequeridaDTO = capacidadOperativaRequeridaBL.ObtenerCapacidadOperativaRequeridas();

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = tipoNaveDTO,
                data3 = departamentoUbigeoDTO,
                data4 = provinciaUbigeoDTO,
                data5 = distritoUbigeoDTO,
                data6 = condicionDTO,
                data7 = capacidadOperativaRequeridaDTO,
            });
        }

        public IActionResult CargaTabla()
        {
            List<SituacionEmbarcacionMenorComgoeDTO> select = situacionEmbarcacionMenorComgoeBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(int UnidadNavalId, int TipoNaveId, string TipoPlataforma, int UnidadNavalDestino, string Ubicacion, int DepartamentoUbigeoId, int ProvinciaUbigeoId, int DistritoUbigeoId, int CapacidadOperativaRequeridaId, int CondicionId, string Observaciones)
        {
            SituacionEmbarcacionMenorComgoeDTO situacionEmbarcacionMenorComgoeDTO = new();
            situacionEmbarcacionMenorComgoeDTO.UnidadNavalId = UnidadNavalId;
            situacionEmbarcacionMenorComgoeDTO.TipoNaveId = TipoNaveId;
            situacionEmbarcacionMenorComgoeDTO.TipoPlataforma = TipoPlataforma;
            situacionEmbarcacionMenorComgoeDTO.UnidadNavalDestino = UnidadNavalDestino;
            situacionEmbarcacionMenorComgoeDTO.Ubicacion = Ubicacion;
            situacionEmbarcacionMenorComgoeDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            situacionEmbarcacionMenorComgoeDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            situacionEmbarcacionMenorComgoeDTO.DistritoUbigeoId = DistritoUbigeoId;
            situacionEmbarcacionMenorComgoeDTO.CapacidadOperativaRequeridaId = CapacidadOperativaRequeridaId;
            situacionEmbarcacionMenorComgoeDTO.CondicionId = CondicionId;
            situacionEmbarcacionMenorComgoeDTO.Observaciones = Observaciones;
            
            situacionEmbarcacionMenorComgoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionEmbarcacionMenorComgoeBL.AgregarRegistro(situacionEmbarcacionMenorComgoeDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(situacionEmbarcacionMenorComgoeBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int UnidadNavalId, int TipoNaveId, string TipoPlataforma, int UnidadNavalDestino, string Ubicacion, int DepartamentoUbigeoId, int ProvinciaUbigeoId, int DistritoUbigeoId, int CapacidadOperativaRequeridaId, int CondicionId, string Observaciones)
        {
            SituacionEmbarcacionMenorComgoeDTO situacionEmbarcacionMenorComgoeDTO = new();
            situacionEmbarcacionMenorComgoeDTO.SituacionEmbarcacionMenorId = Id;
            situacionEmbarcacionMenorComgoeDTO.UnidadNavalId = UnidadNavalId;
            situacionEmbarcacionMenorComgoeDTO.TipoNaveId = TipoNaveId;
            situacionEmbarcacionMenorComgoeDTO.TipoPlataforma = TipoPlataforma;
            situacionEmbarcacionMenorComgoeDTO.UnidadNavalDestino = UnidadNavalDestino;
            situacionEmbarcacionMenorComgoeDTO.Ubicacion = Ubicacion;
            situacionEmbarcacionMenorComgoeDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            situacionEmbarcacionMenorComgoeDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            situacionEmbarcacionMenorComgoeDTO.DistritoUbigeoId = DistritoUbigeoId;
            situacionEmbarcacionMenorComgoeDTO.CapacidadOperativaRequeridaId = CapacidadOperativaRequeridaId;
            situacionEmbarcacionMenorComgoeDTO.CondicionId = CondicionId;
            situacionEmbarcacionMenorComgoeDTO.Observaciones = Observaciones;
            
            situacionEmbarcacionMenorComgoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionEmbarcacionMenorComgoeBL.ActualizarFormato(situacionEmbarcacionMenorComgoeDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            SituacionEmbarcacionMenorComgoeDTO situacionEmbarcacionMenorComgoeDTO = new();
            situacionEmbarcacionMenorComgoeDTO.SituacionEmbarcacionMenorId = Id;
            situacionEmbarcacionMenorComgoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (situacionEmbarcacionMenorComgoeBL.EliminarFormato(situacionEmbarcacionMenorComgoeDTO) == true)
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

            List<SituacionEmbarcacionMenorComgoeDTO> lista = new List<SituacionEmbarcacionMenorComgoeDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new SituacionEmbarcacionMenorComgoeDTO
                {
                    //NombreTemaEstudioInvestigacion = fila.GetCell(0).ToString(),
                    //TipoEstudioInvestigacionIds = fila.GetCell(1).ToString(),
                    //FechaInicio = fila.GetCell(2).ToString(),
                    //FechaTermino = fila.GetCell(3).ToString(),
                    //Responsable = fila.GetCell(4).ToString(),
                    //Solicitante = fila.GetCell(5).ToString()
                });
            }
            return StatusCode(StatusCodes.Status200OK, lista);
        }


        [HttpPost]
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
        {
            Stream stream = ArchivoExcel.OpenReadStream();
            var mensaje = "";

            IWorkbook MiExcel = null;

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
            List<SituacionEmbarcacionMenorComgoeDTO> lista = new List<SituacionEmbarcacionMenorComgoeDTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new SituacionEmbarcacionMenorComgoeDTO
                {
                    //NombreTemaEstudioInvestigacion = fila.GetCell(0).ToString(),
                    //TipoEstudioInvestigacionIds = fila.GetCell(1).ToString(),
                    //FechaInicio = fila.GetCell(2).ToString(),
                    //FechaTermino = fila.GetCell(3).ToString(),
                    //Responsable = fila.GetCell(4).ToString(),
                    //Solicitante = fila.GetCell(5).ToString(),
                    //UsuarioIngresoRegistro = User.obtenerUsuario(),                    
                });
            }
            try
            {
                var estado = situacionEmbarcacionMenorComgoeBL.InsercionMasiva(lista);
                if (estado == true)
                {
                    mensaje = "ok";
                }
                else
                {
                    mensaje = "error";
                }

            }
            catch (Exception e)
            {
                mensaje = e.Message;
            }
            return StatusCode(StatusCodes.Status200OK, new { mensaje });
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = situacionEmbarcacionMenorComgoeBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
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

