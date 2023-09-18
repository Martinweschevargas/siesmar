using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard;
using Marina.Siesmar.LogicaNegocios.Formatos.Dibinfrater;
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

    public class ComoperguardSiniestroAcuaticoActivRadiobalizaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        SiniestroAcuaticoActivacionRadiobaliza siniestroAcuaticoActivacionRadiobalizaBL = new();

        JefaturaDistritoCapitania jefaturaDistritoCapitaniaBL = new();
        Capitania capitaniaBL = new();
        TipoNave tipoNaveBL = new();
        PaisUbigeo paisUbigeoBL = new();
        TipoSiniestro tipoSiniestroBL = new();
        TipoRadiobaliza tipoRadiobalizaBL = new();
        AmbitoNave ambitoNaveBL = new();
        UnidadNaval unidadNavalBL = new();

        public ComoperguardSiniestroAcuaticoActivRadiobalizaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Siniestros Acuáticos y Activaciones de Radiobalizas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<JefaturaDistritoCapitaniaDTO> jefaturaDistritoCapitaniaDTO = jefaturaDistritoCapitaniaBL.ObtenerJefaturaDistritoCapitanias();
            List<CapitaniaDTO> capitaniaDTO = capitaniaBL.ObtenerCapitanias();
            List<TipoNaveDTO> tipoNaveDTO = tipoNaveBL.ObtenerTipoNaves();
            List<PaisUbigeoDTO> paisUbigeoDTO = paisUbigeoBL.ObtenerPaisUbigeos();
            List<TipoSiniestroDTO> tipoSiniestroDTO = tipoSiniestroBL.ObtenerCapintanias();
            List<TipoRadiobalizaDTO> tipoRadiobalizaDTO = tipoRadiobalizaBL.ObtenerTipoRadiobalizas();
            List<AmbitoNaveDTO> ambitoNaveDTO = ambitoNaveBL.ObtenerCapintanias();
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();

            return Json(new { data1 = jefaturaDistritoCapitaniaDTO, data2 = capitaniaDTO, data3 = tipoNaveDTO, data4 = paisUbigeoDTO,
                data5 = tipoSiniestroDTO,data6 = tipoRadiobalizaDTO,  data7 = ambitoNaveDTO,  data8 = unidadNavalDTO });
        }

        public IActionResult CargaTabla()
        {
            List<SiniestroAcuaticoActivacionRadiobalizaDTO> select = siniestroAcuaticoActivacionRadiobalizaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar( int JefaturaDistritoCapitaniaId, int CapitaniaId, string HoraSiniestro, string FechaSiniestro, int TipoNaveId,
            string NombreNaveSiniestro, string MatriculaNaveSiniestro, int ABEdad, int PaisUbigeoId, int TipoSiniestroId, string CuentaRadiobaliza,
            string ActivoRadiobaliza, string TipoActivacionRadiobaliza, int TipoRadiobalizaId, string CodigoHexadecimal, string ActivoPlanBusqueda,
            string MNReferenciaActivacion, string MNReferenciaDesactiva, int TiempoDuracionHoras, string LatitudUbicacionNave,
            string LongitudUbicacionNave, int AmbitoNaveId, int PersonasRescatadasVida, int PersonasFallecidas, int PersonasDesaparecida,
            int TotalPersonas, int UnidadNavalId, string UnidadesParticulares, string ResumenCaso)
        {
            SiniestroAcuaticoActivacionRadiobalizaDTO siniestroAcuaticoActivacionRadiobalizaDTO = new();
            siniestroAcuaticoActivacionRadiobalizaDTO.JefaturaDistritoCapitaniaId = JefaturaDistritoCapitaniaId;
            siniestroAcuaticoActivacionRadiobalizaDTO.CapitaniaId = CapitaniaId;
            siniestroAcuaticoActivacionRadiobalizaDTO.HoraSiniestro = HoraSiniestro;
            siniestroAcuaticoActivacionRadiobalizaDTO.FechaSiniestro = FechaSiniestro;
            siniestroAcuaticoActivacionRadiobalizaDTO.TipoNaveId = TipoNaveId;
            siniestroAcuaticoActivacionRadiobalizaDTO.NombreNaveSiniestro = NombreNaveSiniestro;
            siniestroAcuaticoActivacionRadiobalizaDTO.MatriculaNaveSiniestro = MatriculaNaveSiniestro;
            siniestroAcuaticoActivacionRadiobalizaDTO.ABEdad = ABEdad;
            siniestroAcuaticoActivacionRadiobalizaDTO.PaisUbigeoId = PaisUbigeoId;
            siniestroAcuaticoActivacionRadiobalizaDTO.TipoSiniestroId = TipoSiniestroId;
            siniestroAcuaticoActivacionRadiobalizaDTO.CuentaRadiobaliza = CuentaRadiobaliza;
            siniestroAcuaticoActivacionRadiobalizaDTO.ActivoRadiobaliza = ActivoRadiobaliza;
            siniestroAcuaticoActivacionRadiobalizaDTO.TipoActivacionRadiobaliza = TipoActivacionRadiobaliza;
            siniestroAcuaticoActivacionRadiobalizaDTO.TipoRadiobalizaId = TipoRadiobalizaId;
            siniestroAcuaticoActivacionRadiobalizaDTO.CodigoHexadecimal = CodigoHexadecimal;
            siniestroAcuaticoActivacionRadiobalizaDTO.ActivoPlanBusqueda = ActivoPlanBusqueda;
            siniestroAcuaticoActivacionRadiobalizaDTO.MNReferenciaActivacion = MNReferenciaActivacion;
            siniestroAcuaticoActivacionRadiobalizaDTO.MNReferenciaDesactiva = MNReferenciaDesactiva;
            siniestroAcuaticoActivacionRadiobalizaDTO.TiempoDuracionHoras = TiempoDuracionHoras;
            siniestroAcuaticoActivacionRadiobalizaDTO.LatitudUbicacionNave = LatitudUbicacionNave;
            siniestroAcuaticoActivacionRadiobalizaDTO.LongitudUbicacionNave = LongitudUbicacionNave;
            siniestroAcuaticoActivacionRadiobalizaDTO.AmbitoNaveId = AmbitoNaveId;
            siniestroAcuaticoActivacionRadiobalizaDTO.PersonasRescatadasVida = PersonasRescatadasVida;
            siniestroAcuaticoActivacionRadiobalizaDTO.PersonasFallecidas = PersonasFallecidas;
            siniestroAcuaticoActivacionRadiobalizaDTO.PersonasDesaparecida = PersonasDesaparecida;
            siniestroAcuaticoActivacionRadiobalizaDTO.TotalPersonas = TotalPersonas;
            siniestroAcuaticoActivacionRadiobalizaDTO.UnidadNavalId = UnidadNavalId;
            siniestroAcuaticoActivacionRadiobalizaDTO.UnidadesParticulares = UnidadesParticulares;
            siniestroAcuaticoActivacionRadiobalizaDTO.ResumenCaso = ResumenCaso;
            siniestroAcuaticoActivacionRadiobalizaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = siniestroAcuaticoActivacionRadiobalizaBL.AgregarRegistro(siniestroAcuaticoActivacionRadiobalizaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(siniestroAcuaticoActivacionRadiobalizaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int JefaturaDistritoCapitaniaId, int CapitaniaId, string HoraSiniestro, string FechaSiniestro,
            int TipoNaveId, string NombreNaveSiniestro, string MatriculaNaveSiniestro, int ABEdad, int PaisUbigeoId, int TipoSiniestroId,
            string CuentaRadiobaliza, string ActivoRadiobaliza, string TipoActivacionRadiobaliza, int TipoRadiobalizaId, string CodigoHexadecimal, 
            string ActivoPlanBusqueda, string MNReferenciaActivacion, string MNReferenciaDesactiva, int TiempoDuracionHoras,
            string LatitudUbicacionNave, string LongitudUbicacionNave, int AmbitoNaveId, int PersonasRescatadasVida, int PersonasFallecidas,
            int PersonasDesaparecida, int TotalPersonas, int UnidadNavalId, string UnidadesParticulares, string ResumenCaso)
        {
            SiniestroAcuaticoActivacionRadiobalizaDTO siniestroAcuaticoActivacionRadiobalizaDTO = new();
            siniestroAcuaticoActivacionRadiobalizaDTO.SiniestroAcuaticoActivacionRadiobalizaId = Id;
            siniestroAcuaticoActivacionRadiobalizaDTO.JefaturaDistritoCapitaniaId = JefaturaDistritoCapitaniaId;
            siniestroAcuaticoActivacionRadiobalizaDTO.CapitaniaId = CapitaniaId;
            siniestroAcuaticoActivacionRadiobalizaDTO.HoraSiniestro = HoraSiniestro;
            siniestroAcuaticoActivacionRadiobalizaDTO.FechaSiniestro = FechaSiniestro;
            siniestroAcuaticoActivacionRadiobalizaDTO.TipoNaveId = TipoNaveId;
            siniestroAcuaticoActivacionRadiobalizaDTO.NombreNaveSiniestro = NombreNaveSiniestro;
            siniestroAcuaticoActivacionRadiobalizaDTO.MatriculaNaveSiniestro = MatriculaNaveSiniestro;
            siniestroAcuaticoActivacionRadiobalizaDTO.ABEdad = ABEdad;
            siniestroAcuaticoActivacionRadiobalizaDTO.PaisUbigeoId = PaisUbigeoId;
            siniestroAcuaticoActivacionRadiobalizaDTO.TipoSiniestroId = TipoSiniestroId;
            siniestroAcuaticoActivacionRadiobalizaDTO.CuentaRadiobaliza = CuentaRadiobaliza;
            siniestroAcuaticoActivacionRadiobalizaDTO.ActivoRadiobaliza = ActivoRadiobaliza;
            siniestroAcuaticoActivacionRadiobalizaDTO.TipoActivacionRadiobaliza = TipoActivacionRadiobaliza;
            siniestroAcuaticoActivacionRadiobalizaDTO.TipoRadiobalizaId = TipoRadiobalizaId;
            siniestroAcuaticoActivacionRadiobalizaDTO.CodigoHexadecimal = CodigoHexadecimal;
            siniestroAcuaticoActivacionRadiobalizaDTO.ActivoPlanBusqueda = ActivoPlanBusqueda;
            siniestroAcuaticoActivacionRadiobalizaDTO.MNReferenciaActivacion = MNReferenciaActivacion;
            siniestroAcuaticoActivacionRadiobalizaDTO.MNReferenciaDesactiva = MNReferenciaDesactiva;
            siniestroAcuaticoActivacionRadiobalizaDTO.TiempoDuracionHoras = TiempoDuracionHoras;
            siniestroAcuaticoActivacionRadiobalizaDTO.LatitudUbicacionNave = LatitudUbicacionNave;
            siniestroAcuaticoActivacionRadiobalizaDTO.LongitudUbicacionNave = LongitudUbicacionNave;
            siniestroAcuaticoActivacionRadiobalizaDTO.AmbitoNaveId = AmbitoNaveId;
            siniestroAcuaticoActivacionRadiobalizaDTO.PersonasRescatadasVida = PersonasRescatadasVida;
            siniestroAcuaticoActivacionRadiobalizaDTO.PersonasFallecidas = PersonasFallecidas;
            siniestroAcuaticoActivacionRadiobalizaDTO.PersonasDesaparecida = PersonasDesaparecida;
            siniestroAcuaticoActivacionRadiobalizaDTO.TotalPersonas = TotalPersonas;
            siniestroAcuaticoActivacionRadiobalizaDTO.UnidadNavalId = UnidadNavalId;
            siniestroAcuaticoActivacionRadiobalizaDTO.UnidadesParticulares = UnidadesParticulares;
            siniestroAcuaticoActivacionRadiobalizaDTO.ResumenCaso = ResumenCaso;
            siniestroAcuaticoActivacionRadiobalizaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = siniestroAcuaticoActivacionRadiobalizaBL.ActualizarFormato(siniestroAcuaticoActivacionRadiobalizaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            SiniestroAcuaticoActivacionRadiobalizaDTO siniestroAcuaticoActivacionRadiobalizaDTO = new();
            siniestroAcuaticoActivacionRadiobalizaDTO.SiniestroAcuaticoActivacionRadiobalizaId = Id;
            siniestroAcuaticoActivacionRadiobalizaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (siniestroAcuaticoActivacionRadiobalizaBL.EliminarFormato(siniestroAcuaticoActivacionRadiobalizaDTO) == true)
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

            List<SiniestroAcuaticoActivacionRadiobalizaDTO> lista = new List<SiniestroAcuaticoActivacionRadiobalizaDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new SiniestroAcuaticoActivacionRadiobalizaDTO
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
            List<SiniestroAcuaticoActivacionRadiobalizaDTO> lista = new List<SiniestroAcuaticoActivacionRadiobalizaDTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new SiniestroAcuaticoActivacionRadiobalizaDTO
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
                var estado = siniestroAcuaticoActivacionRadiobalizaBL.InsercionMasiva(lista);
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
            var estudioInvestigacionesHistoricasNavales = siniestroAcuaticoActivacionRadiobalizaBL.ObtenerLista();
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

