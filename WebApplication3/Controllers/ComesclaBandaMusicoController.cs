using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Comescla;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Comescla;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Formatos.Comescla;
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

    public class ComesclaBandaMusicoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        BandaMusicoComescla bandaMusicoComesclaBL = new();

        TipoComision tipoComisionBL = new();
        Evento eventoBL = new();
        GrupoComisionado grupoComisionadoBL = new();


        public ComesclaBandaMusicoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Banda de Músicos - COMESCLA", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<TipoComisionDTO> tipoComisionDTO = tipoComisionBL.ObtenerTipoComisions();
            List<EventoDTO> eventoDTO = eventoBL.ObtenerEventos();
            List<GrupoComisionadoDTO> grupoComisionadoDTO = grupoComisionadoBL.ObtenerGrupoComisionados();
          
            return Json(new { data1 = tipoComisionDTO, data2 = eventoDTO, data3 = grupoComisionadoDTO });
        }

        public IActionResult CargaTabla()
        {
            List<BandaMusicoComesclaDTO> select = bandaMusicoComesclaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar( int TipoComisionId, int EventoId, string SolicitudDocumentoReferencia, string InstitucionSolicitante,
            int GrupoComisionadoId, string VestimentaUniforme, string NombreEvento, string Lugar, string FechaHoraSalida, string FechaHoraInicio,
            string FechaHoraTermino, string RequerimientoMovilidad, string Observaciones)
        {
            BandaMusicoComesclaDTO bandaMusicoComesclaDTO = new();
            bandaMusicoComesclaDTO.TipoComisionId = TipoComisionId;
            bandaMusicoComesclaDTO.EventoId = EventoId;
            bandaMusicoComesclaDTO.SolicitudDocumentoReferencia = SolicitudDocumentoReferencia;
            bandaMusicoComesclaDTO.InstitucionSolicitante = InstitucionSolicitante;
            bandaMusicoComesclaDTO.GrupoComisionadoId = GrupoComisionadoId;
            bandaMusicoComesclaDTO.VestimentaUniforme = VestimentaUniforme;
            bandaMusicoComesclaDTO.NombreEvento = NombreEvento;
            bandaMusicoComesclaDTO.Lugar = Lugar;
            bandaMusicoComesclaDTO.FechaHoraSalida = FechaHoraSalida;
            bandaMusicoComesclaDTO.FechaHoraInicio = FechaHoraInicio;
            bandaMusicoComesclaDTO.FechaHoraTermino = FechaHoraTermino;
            bandaMusicoComesclaDTO.RequerimientoMovilidad = RequerimientoMovilidad;
            bandaMusicoComesclaDTO.Observaciones = Observaciones;
            bandaMusicoComesclaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = bandaMusicoComesclaBL.AgregarRegistro(bandaMusicoComesclaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(bandaMusicoComesclaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int TipoComisionId, int EventoId, string SolicitudDocumentoReferencia, string InstitucionSolicitante,
            int GrupoComisionadoId, string VestimentaUniforme, string NombreEvento, string Lugar, string FechaHoraSalida, string FechaHoraInicio,
            string FechaHoraTermino, string RequerimientoMovilidad, string Observaciones)
        {
            BandaMusicoComesclaDTO bandaMusicoComesclaDTO = new();
            bandaMusicoComesclaDTO.BandaMusicoId = Id;
            bandaMusicoComesclaDTO.TipoComisionId = TipoComisionId;
            bandaMusicoComesclaDTO.EventoId = EventoId;
            bandaMusicoComesclaDTO.SolicitudDocumentoReferencia = SolicitudDocumentoReferencia;
            bandaMusicoComesclaDTO.InstitucionSolicitante = InstitucionSolicitante;
            bandaMusicoComesclaDTO.GrupoComisionadoId = GrupoComisionadoId;
            bandaMusicoComesclaDTO.VestimentaUniforme = VestimentaUniforme;
            bandaMusicoComesclaDTO.NombreEvento = NombreEvento;
            bandaMusicoComesclaDTO.Lugar = Lugar;
            bandaMusicoComesclaDTO.FechaHoraSalida = FechaHoraSalida;
            bandaMusicoComesclaDTO.FechaHoraInicio = FechaHoraInicio;
            bandaMusicoComesclaDTO.FechaHoraTermino = FechaHoraTermino;
            bandaMusicoComesclaDTO.RequerimientoMovilidad = RequerimientoMovilidad;
            bandaMusicoComesclaDTO.Observaciones = Observaciones;
            bandaMusicoComesclaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = bandaMusicoComesclaBL.ActualizarFormato(bandaMusicoComesclaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            BandaMusicoComesclaDTO bandaMusicoComesclaDTO = new();
            bandaMusicoComesclaDTO.BandaMusicoId = Id;
            bandaMusicoComesclaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (bandaMusicoComesclaBL.EliminarFormato(bandaMusicoComesclaDTO) == true)
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

            List<BandaMusicoComesclaDTO> lista = new List<BandaMusicoComesclaDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new BandaMusicoComesclaDTO
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
            List<BandaMusicoComesclaDTO> lista = new List<BandaMusicoComesclaDTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new BandaMusicoComesclaDTO
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
                var estado = bandaMusicoComesclaBL.InsercionMasiva(lista);
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
            var estudioInvestigacionesHistoricasNavales = bandaMusicoComesclaBL.ObtenerLista();
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

