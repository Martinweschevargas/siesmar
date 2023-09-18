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

    public class ComoperguardArriboNaveController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        ArriboNave arriboNaveBL = new();
        JefaturaDistritoCapitania jefaturaDistritoCapitaniaBL = new();
        Capitania capitaniaBL = new();
        Mes mesBL = new();
        PuertoPeru puertoPeruBL = new();
        PaisUbigeo paisUbigeoBL = new();
        TipoNave tipoNaveBL = new();
        UnidadMedida unidadMedidaBL = new();
        TipoCarga tipoCargaBL = new();

        public ComoperguardArriboNaveController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Arribo de Naves", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<JefaturaDistritoCapitaniaDTO> jefaturaDistritoCapitaniaDTO = jefaturaDistritoCapitaniaBL.ObtenerJefaturaDistritoCapitanias();
            List<CapitaniaDTO> capitaniaDTO = capitaniaBL.ObtenerCapitanias();
            List<MesDTO> mesDTO = mesBL.ObtenerMess();
            List<PuertoPeruDTO> puertoPeruDTO = puertoPeruBL.ObtenerPuertoPerus();
            List<PaisUbigeoDTO> paisUbigeoDTO = paisUbigeoBL.ObtenerPaisUbigeos();
            List<TipoNaveDTO> tipoNaveDTO = tipoNaveBL.ObtenerTipoNaves();
            List<UnidadMedidaDTO> unidadMedidaDTO = unidadMedidaBL.ObtenerUnidadMedidas();
            List<TipoCargaDTO> tipoCargaDTO = tipoCargaBL.ObtenerCapintanias();

            return Json(new { data1 = jefaturaDistritoCapitaniaDTO, data2 = capitaniaDTO, data3 = mesDTO, data4 = puertoPeruDTO,
                data5 = paisUbigeoDTO, data6 = tipoNaveDTO,data7 = unidadMedidaDTO,  unidadMedidaDTO = tipoCargaDTO, });
        }

        public IActionResult CargaTabla()
        {
            List<ArriboNaveDTO> select = arriboNaveBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar( int JefaturaDistritoCapitaniaId, int CapitaniaId, string HoraArribo, int DiaArribo, int MesId, int AnioArribo,
            int PuertoPeruId, string IndicativoNave, string NombreNave, int PaisUbigeoId, int TipoNaveId, string NumeroOMI, string AB,
            string AgenciaMaritima, int PaisProcedencia, string PuertoProcedencia, int TripulantesChilenos, int TripulantesEcuatorianos, 
            int TripulantesTotal, int PasajerosChilenos, int PasajerosEcuatorianos, int PasajerosTotal, int CantidadCargaDesembarcada, 
            int UnidadMedidaId, int TipoCargaId, int CantidadCargaPeligrosa, int UnidadMedidaPeligrosa, int TipoCargaPeligrosa, 
            string Observaciones)
        {
            ArriboNaveDTO arriboNaveDTO = new();
            arriboNaveDTO.JefaturaDistritoCapitaniaId = JefaturaDistritoCapitaniaId;
            arriboNaveDTO.CapitaniaId = CapitaniaId;
            arriboNaveDTO.HoraArribo = HoraArribo;
            arriboNaveDTO.DiaArribo = DiaArribo;
            arriboNaveDTO.MesId = MesId;
            arriboNaveDTO.AnioArribo = AnioArribo;
            arriboNaveDTO.PuertoPeruId = PuertoPeruId;
            arriboNaveDTO.IndicativoNave = IndicativoNave;
            arriboNaveDTO.NombreNave = NombreNave;
            arriboNaveDTO.PaisUbigeoId = PaisUbigeoId;
            arriboNaveDTO.TipoNaveId = TipoNaveId;
            arriboNaveDTO.NumeroOMI = NumeroOMI;
            arriboNaveDTO.AB = AB;
            arriboNaveDTO.AgenciaMaritima = AgenciaMaritima;
            arriboNaveDTO.PaisProcedencia = PaisProcedencia;
            arriboNaveDTO.PuertoProcedencia = PuertoProcedencia;
            arriboNaveDTO.TripulantesChilenos = TripulantesChilenos;
            arriboNaveDTO.TripulantesEcuatorianos = TripulantesEcuatorianos;
            arriboNaveDTO.TripulantesTotal = TripulantesTotal;
            arriboNaveDTO.PasajerosChilenos = PasajerosChilenos;
            arriboNaveDTO.PasajerosEcuatorianos = PasajerosEcuatorianos;
            arriboNaveDTO.PasajerosTotal = PasajerosTotal;
            arriboNaveDTO.CantidadCargaDesembarcada = CantidadCargaDesembarcada;
            arriboNaveDTO.UnidadMedidaId = UnidadMedidaId;
            arriboNaveDTO.TipoCargaId = TipoCargaId;
            arriboNaveDTO.CantidadCargaPeligrosa = CantidadCargaPeligrosa;
            arriboNaveDTO.UnidadMedidaPeligrosa = UnidadMedidaPeligrosa;
            arriboNaveDTO.TipoCargaPeligrosa = TipoCargaPeligrosa;
            arriboNaveDTO.Observaciones = Observaciones;
            arriboNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = arriboNaveBL.AgregarRegistro(arriboNaveDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(arriboNaveBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int JefaturaDistritoCapitaniaId, int CapitaniaId, string HoraArribo, int DiaArribo, int MesId, 
            int AnioArribo, int PuertoPeruId, string IndicativoNave, string NombreNave, int PaisUbigeoId, int TipoNaveId, string NumeroOMI,
            string AB, string AgenciaMaritima, int PaisProcedencia, string PuertoProcedencia, int TripulantesChilenos, int TripulantesEcuatorianos, 
            int TripulantesTotal, int PasajerosChilenos, int PasajerosEcuatorianos, int PasajerosTotal, int CantidadCargaDesembarcada, 
            int UnidadMedidaId, int TipoCargaId, int CantidadCargaPeligrosa, int UnidadMedidaPeligrosa, int TipoCargaPeligrosa,
            string Observaciones)
        {
            ArriboNaveDTO arriboNaveDTO = new();
            arriboNaveDTO.ArriboNaveId = Id;
            arriboNaveDTO.JefaturaDistritoCapitaniaId = JefaturaDistritoCapitaniaId;
            arriboNaveDTO.CapitaniaId = CapitaniaId;
            arriboNaveDTO.HoraArribo = HoraArribo;
            arriboNaveDTO.DiaArribo = DiaArribo;
            arriboNaveDTO.MesId = MesId;
            arriboNaveDTO.AnioArribo = AnioArribo;
            arriboNaveDTO.PuertoPeruId = PuertoPeruId;
            arriboNaveDTO.IndicativoNave = IndicativoNave;
            arriboNaveDTO.NombreNave = NombreNave;
            arriboNaveDTO.PaisUbigeoId = PaisUbigeoId;
            arriboNaveDTO.TipoNaveId = TipoNaveId;
            arriboNaveDTO.NumeroOMI = NumeroOMI;
            arriboNaveDTO.AB = AB;
            arriboNaveDTO.AgenciaMaritima = AgenciaMaritima;
            arriboNaveDTO.PaisProcedencia = PaisProcedencia;
            arriboNaveDTO.PuertoProcedencia = PuertoProcedencia;
            arriboNaveDTO.TripulantesChilenos = TripulantesChilenos;
            arriboNaveDTO.TripulantesEcuatorianos = TripulantesEcuatorianos;
            arriboNaveDTO.TripulantesTotal = TripulantesTotal;
            arriboNaveDTO.PasajerosChilenos = PasajerosChilenos;
            arriboNaveDTO.PasajerosEcuatorianos = PasajerosEcuatorianos;
            arriboNaveDTO.PasajerosTotal = PasajerosTotal;
            arriboNaveDTO.CantidadCargaDesembarcada = CantidadCargaDesembarcada;
            arriboNaveDTO.UnidadMedidaId = UnidadMedidaId;
            arriboNaveDTO.TipoCargaId = TipoCargaId;
            arriboNaveDTO.CantidadCargaPeligrosa = CantidadCargaPeligrosa;
            arriboNaveDTO.UnidadMedidaPeligrosa = UnidadMedidaPeligrosa;
            arriboNaveDTO.TipoCargaPeligrosa = TipoCargaPeligrosa;
            arriboNaveDTO.Observaciones = Observaciones;
            arriboNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = arriboNaveBL.ActualizarFormato(arriboNaveDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ArriboNaveDTO arriboNaveDTO = new();
            arriboNaveDTO.ArriboNaveId = Id;
            arriboNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (arriboNaveBL.EliminarFormato(arriboNaveDTO) == true)
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

            List<ArriboNaveDTO> lista = new List<ArriboNaveDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new ArriboNaveDTO
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
            List<ArriboNaveDTO> lista = new List<ArriboNaveDTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new ArriboNaveDTO
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
                var estado = arriboNaveBL.InsercionMasiva(lista);
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
            var estudioInvestigacionesHistoricasNavales = arriboNaveBL.ObtenerLista();
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

