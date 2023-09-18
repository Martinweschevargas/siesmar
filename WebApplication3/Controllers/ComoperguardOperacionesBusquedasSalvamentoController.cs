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

    public class ComoperguardOperacionesBusquedasSalvamentoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        OperacionesBusquedasSalvamento operacionesBusquedasSalvamentoBL = new();

        JefaturaDistritoCapitania jefaturaDistritoCapitaniaBL = new();
        Capitania capitaniaBL = new();
        TipoSiniestro tipoSiniestroBL = new();
        PaisUbigeo paisUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DepartamentoUbigeo departamentoUbigeoBL= new();
        AmbitoNave ambitoNaveBL = new();
        UnidadNaval unidadNavalBL = new();
        TipoVehiculoMovil tipoVehiculoMovilBL = new();
        MarcaVehiculo marcaVehiculoBL = new();

        public ComoperguardOperacionesBusquedasSalvamentoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Operaciones de Busqueda y Salvamento RSC", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<JefaturaDistritoCapitaniaDTO> jefaturaDistritoCapitaniaDTO = jefaturaDistritoCapitaniaBL.ObtenerJefaturaDistritoCapitanias();
            List<CapitaniaDTO> capitaniaDTO = capitaniaBL.ObtenerCapitanias();
            List<TipoSiniestroDTO> tipoSiniestroDTO = tipoSiniestroBL.ObtenerCapintanias();
            List<PaisUbigeoDTO> paisUbigeoDTO = paisUbigeoBL.ObtenerPaisUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<AmbitoNaveDTO> ambitoNaveDTO = ambitoNaveBL.ObtenerCapintanias();
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<TipoVehiculoMovilDTO> tipoVehiculoMovilDTO = tipoVehiculoMovilBL.ObtenerCapintanias();
            List<MarcaVehiculoDTO> marcaVehiculoDTO = marcaVehiculoBL.ObtenerMarcaVehiculos();

            return Json(new { data1 = jefaturaDistritoCapitaniaDTO, data2 = capitaniaDTO, data3 = tipoSiniestroDTO, data4 = paisUbigeoDTO,
                data5 = distritoUbigeoDTO,data6 = provinciaUbigeoDTO ,data7 = departamentoUbigeoDTO, data8 = ambitoNaveDTO,
                data9 = unidadNavalDTO, data10 = tipoVehiculoMovilDTO, data11 = marcaVehiculoDTO});
        }

        public IActionResult CargaTabla()
        {
            List<OperacionesBusquedasSalvamentoDTO> select = operacionesBusquedasSalvamentoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar( int JefaturaDistritoCapitaniaId, int CapitaniaId, string HoraSiniestro, 
            string FechaSiniestro, int TipoSiniestroId, string MensajeActivacionRSC, string MensajeDesactivacionRSC,
            string NombreNaveSiniestrada, string MatriculaNaveSiniestrada, int ABEdad, int PaisUbigeoId,
            int PersonasRescatadasVida, int PersonasFallecidas, int PersonasDesaparecidas, int PersonasEvacuadas,
            string LatitudUbicacionNave, string LongitudUbicacionNave, string ZonaSiniestro, int DistritoUbigeoId,
            int ProvinciaUbigeoId, int DepartamentoUbigeoId, int AmbitoNaveId, int UnidadNavalId, int TipoVehiculoMovilId,
            int MarcaVehiculoId, int Millas, int Kilometro, int Galones, string ResultadoTerminoOperaciones,
            string ObservacionesSiniestro)
        {
            OperacionesBusquedasSalvamentoDTO operacionesBusquedasSalvamentoDTO = new();
            operacionesBusquedasSalvamentoDTO.JefaturaDistritoCapitaniaId = JefaturaDistritoCapitaniaId;
            operacionesBusquedasSalvamentoDTO.CapitaniaId = CapitaniaId;
            operacionesBusquedasSalvamentoDTO.HoraSiniestro = HoraSiniestro;
            operacionesBusquedasSalvamentoDTO.FechaSiniestro = FechaSiniestro;
            operacionesBusquedasSalvamentoDTO.TipoSiniestroId = TipoSiniestroId;
            operacionesBusquedasSalvamentoDTO.MensajeActivacionRSC = MensajeActivacionRSC;
            operacionesBusquedasSalvamentoDTO.MensajeDesactivacionRSC = MensajeDesactivacionRSC;
            operacionesBusquedasSalvamentoDTO.NombreNaveSiniestrada = NombreNaveSiniestrada;
            operacionesBusquedasSalvamentoDTO.MatriculaNaveSiniestrada = MatriculaNaveSiniestrada;
            operacionesBusquedasSalvamentoDTO.ABEdad = ABEdad;
            operacionesBusquedasSalvamentoDTO.PaisUbigeoId = PaisUbigeoId;
            operacionesBusquedasSalvamentoDTO.PersonasRescatadasVida = PersonasRescatadasVida;
            operacionesBusquedasSalvamentoDTO.PersonasFallecidas = PersonasFallecidas;
            operacionesBusquedasSalvamentoDTO.PersonasDesaparecidas = PersonasDesaparecidas;
            operacionesBusquedasSalvamentoDTO.PersonasEvacuadas = PersonasEvacuadas;
            operacionesBusquedasSalvamentoDTO.LatitudUbicacionNave = LatitudUbicacionNave;
            operacionesBusquedasSalvamentoDTO.LongitudUbicacionNave = LongitudUbicacionNave;
            operacionesBusquedasSalvamentoDTO.ZonaSiniestro = ZonaSiniestro;
            operacionesBusquedasSalvamentoDTO.DistritoUbigeoId = DistritoUbigeoId;
            operacionesBusquedasSalvamentoDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            operacionesBusquedasSalvamentoDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            operacionesBusquedasSalvamentoDTO.AmbitoNaveId = AmbitoNaveId;
            operacionesBusquedasSalvamentoDTO.UnidadNavalId = UnidadNavalId;
            operacionesBusquedasSalvamentoDTO.TipoVehiculoMovilId = TipoVehiculoMovilId;
            operacionesBusquedasSalvamentoDTO.MarcaVehiculoId = MarcaVehiculoId;
            operacionesBusquedasSalvamentoDTO.Millas = Millas;
            operacionesBusquedasSalvamentoDTO.Kilometro = Kilometro;
            operacionesBusquedasSalvamentoDTO.Galones = Galones;
            operacionesBusquedasSalvamentoDTO.ResultadoTerminoOperaciones = ResultadoTerminoOperaciones;
            operacionesBusquedasSalvamentoDTO.ObservacionesSiniestro = ObservacionesSiniestro;
            operacionesBusquedasSalvamentoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = operacionesBusquedasSalvamentoBL.AgregarRegistro(operacionesBusquedasSalvamentoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(operacionesBusquedasSalvamentoBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id,  int JefaturaDistritoCapitaniaId, int CapitaniaId, string HoraSiniestro,
            string FechaSiniestro, int TipoSiniestroId, string MensajeActivacionRSC, string MensajeDesactivacionRSC,
            string NombreNaveSiniestrada, string MatriculaNaveSiniestrada, int ABEdad, int PaisUbigeoId, int PersonasRescatadasVida,
            int PersonasFallecidas, int PersonasDesaparecidas, int PersonasEvacuadas, string LatitudUbicacionNave,
            string LongitudUbicacionNave, string ZonaSiniestro, int DistritoUbigeoId, int ProvinciaUbigeoId,
            int DepartamentoUbigeoId, int AmbitoNaveId, int UnidadNavalId, int TipoVehiculoMovilId, int MarcaVehiculoId,
            int Millas, int Kilometro, int Galones, string ResultadoTerminoOperaciones, string ObservacionesSiniestro)
        {
            OperacionesBusquedasSalvamentoDTO operacionesBusquedasSalvamentoDTO = new();
            operacionesBusquedasSalvamentoDTO.OperacionBusquedaSalvamentoId = Id;
            operacionesBusquedasSalvamentoDTO.JefaturaDistritoCapitaniaId = JefaturaDistritoCapitaniaId;
            operacionesBusquedasSalvamentoDTO.CapitaniaId = CapitaniaId;
            operacionesBusquedasSalvamentoDTO.HoraSiniestro = HoraSiniestro;
            operacionesBusquedasSalvamentoDTO.FechaSiniestro = FechaSiniestro;
            operacionesBusquedasSalvamentoDTO.TipoSiniestroId = TipoSiniestroId;
            operacionesBusquedasSalvamentoDTO.MensajeActivacionRSC = MensajeActivacionRSC;
            operacionesBusquedasSalvamentoDTO.MensajeDesactivacionRSC = MensajeDesactivacionRSC;
            operacionesBusquedasSalvamentoDTO.NombreNaveSiniestrada = NombreNaveSiniestrada;
            operacionesBusquedasSalvamentoDTO.MatriculaNaveSiniestrada = MatriculaNaveSiniestrada;
            operacionesBusquedasSalvamentoDTO.ABEdad = ABEdad;
            operacionesBusquedasSalvamentoDTO.PaisUbigeoId = PaisUbigeoId;
            operacionesBusquedasSalvamentoDTO.PersonasRescatadasVida = PersonasRescatadasVida;
            operacionesBusquedasSalvamentoDTO.PersonasFallecidas = PersonasFallecidas;
            operacionesBusquedasSalvamentoDTO.PersonasDesaparecidas = PersonasDesaparecidas;
            operacionesBusquedasSalvamentoDTO.PersonasEvacuadas = PersonasEvacuadas;
            operacionesBusquedasSalvamentoDTO.LatitudUbicacionNave = LatitudUbicacionNave;
            operacionesBusquedasSalvamentoDTO.LongitudUbicacionNave = LongitudUbicacionNave;
            operacionesBusquedasSalvamentoDTO.ZonaSiniestro = ZonaSiniestro;
            operacionesBusquedasSalvamentoDTO.DistritoUbigeoId = DistritoUbigeoId;
            operacionesBusquedasSalvamentoDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            operacionesBusquedasSalvamentoDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            operacionesBusquedasSalvamentoDTO.AmbitoNaveId = AmbitoNaveId;
            operacionesBusquedasSalvamentoDTO.UnidadNavalId = UnidadNavalId;
            operacionesBusquedasSalvamentoDTO.TipoVehiculoMovilId = TipoVehiculoMovilId;
            operacionesBusquedasSalvamentoDTO.MarcaVehiculoId = MarcaVehiculoId;
            operacionesBusquedasSalvamentoDTO.Millas = Millas;
            operacionesBusquedasSalvamentoDTO.Kilometro = Kilometro;
            operacionesBusquedasSalvamentoDTO.Galones = Galones;
            operacionesBusquedasSalvamentoDTO.ResultadoTerminoOperaciones = ResultadoTerminoOperaciones;
            operacionesBusquedasSalvamentoDTO.ObservacionesSiniestro = ObservacionesSiniestro;
            operacionesBusquedasSalvamentoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = operacionesBusquedasSalvamentoBL.ActualizarFormato(operacionesBusquedasSalvamentoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            OperacionesBusquedasSalvamentoDTO operacionesBusquedasSalvamentoDTO = new();
            operacionesBusquedasSalvamentoDTO.OperacionBusquedaSalvamentoId = Id;
            operacionesBusquedasSalvamentoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (operacionesBusquedasSalvamentoBL.EliminarFormato(operacionesBusquedasSalvamentoDTO) == true)
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

            List<OperacionesBusquedasSalvamentoDTO> lista = new List<OperacionesBusquedasSalvamentoDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new OperacionesBusquedasSalvamentoDTO
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
            List<OperacionesBusquedasSalvamentoDTO> lista = new List<OperacionesBusquedasSalvamentoDTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new OperacionesBusquedasSalvamentoDTO
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
                var estado = operacionesBusquedasSalvamentoBL.InsercionMasiva(lista);
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
            var estudioInvestigacionesHistoricasNavales = operacionesBusquedasSalvamentoBL.ObtenerLista();
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

