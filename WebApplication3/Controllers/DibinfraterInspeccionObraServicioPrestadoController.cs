using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dibinfrater;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dibinfrater;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dibinfrater;
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

    public class DibinfraterInspeccionObraServicioPrestadoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        InspeccionObraServicioPrestado inspeccionObraServicioPrestadoBL = new();
        AreaDiperadmon areaDiperadmonBL = new();
        ZonaNaval zonaNavalBL = new();
        TipoObraServicio tipoObraServicioBL = new();
        TipoProceso tipoProcesoBL = new();
        Carga cargaBL = new();

        public DibinfraterInspeccionObraServicioPrestadoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Inspecciones de Obras y Servicios Prestados", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<AreaDiperadmonDTO> areaDiperadmonDTO = areaDiperadmonBL.ObtenerAreaDiperadmons();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<TipoObraServicioDTO> tipoObraServicioDTO = tipoObraServicioBL.ObtenerTipoObraServicios();
            List<TipoProcesoDTO> tipoProcesoDTO = tipoProcesoBL.ObtenerTipoProcesos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("InspeccionObraServicioPrestado");
            return Json(new { data1 = areaDiperadmonDTO, data2 = zonaNavalDTO, data3 = tipoObraServicioDTO, data4 = tipoProcesoDTO, data5 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<InspeccionObraServicioPrestadoDTO> select = inspeccionObraServicioPrestadoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string IdentificacionSolicitud, string NombreObra, string CodigoAreaDiperadmon, string CodigoZonaNaval,
            string EstadoSolicitud, string IdentificacionContrato, string CodigoTipoObraServicio, string CodigoTipoProceso, decimal MontoContrato,
            string FechaInicioObraServicio, string FechaTerminoEstimada, int PorcentajeAvanceFisico, int CargaId, string Fecha)
        {
            InspeccionObraServicioPrestadoDTO inspeccionObraServicioPrestadoDTO = new();
            inspeccionObraServicioPrestadoDTO.IdentificacionSolicitud = IdentificacionSolicitud;
            inspeccionObraServicioPrestadoDTO.NombreObra = NombreObra;
            inspeccionObraServicioPrestadoDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            inspeccionObraServicioPrestadoDTO.CodigoZonaNaval = CodigoZonaNaval;
            inspeccionObraServicioPrestadoDTO.EstadoSolicitud = EstadoSolicitud;
            inspeccionObraServicioPrestadoDTO.IdentificacionContrato = IdentificacionContrato;
            inspeccionObraServicioPrestadoDTO.CodigoTipoObraServicio = CodigoTipoObraServicio;
            inspeccionObraServicioPrestadoDTO.CodigoTipoProceso = CodigoTipoProceso;
            inspeccionObraServicioPrestadoDTO.MontoContrato = MontoContrato;
            inspeccionObraServicioPrestadoDTO.FechaInicioObraServicio = FechaInicioObraServicio;
            inspeccionObraServicioPrestadoDTO.FechaTerminoEstimada = FechaTerminoEstimada;
            inspeccionObraServicioPrestadoDTO.PorcentajeAvanceFisico = PorcentajeAvanceFisico;
            inspeccionObraServicioPrestadoDTO.CargaId = CargaId;
            inspeccionObraServicioPrestadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = inspeccionObraServicioPrestadoBL.AgregarRegistro(inspeccionObraServicioPrestadoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(inspeccionObraServicioPrestadoBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string IdentificacionSolicitud, string NombreObra, string CodigoAreaDiperadmon, string CodigoZonaNaval,
            string EstadoSolicitud, string IdentificacionContrato, string CodigoTipoObraServicio, string CodigoTipoProceso, decimal MontoContrato,
            string FechaInicioObraServicio, string FechaTerminoEstimada, int PorcentajeAvanceFisico)
        {
            InspeccionObraServicioPrestadoDTO inspeccionObraServicioPrestadoDTO = new();
            inspeccionObraServicioPrestadoDTO.InspeccionObraServicioPrestadoId = Id;
            inspeccionObraServicioPrestadoDTO.IdentificacionSolicitud = IdentificacionSolicitud;
            inspeccionObraServicioPrestadoDTO.NombreObra = NombreObra;
            inspeccionObraServicioPrestadoDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            inspeccionObraServicioPrestadoDTO.CodigoZonaNaval = CodigoZonaNaval;
            inspeccionObraServicioPrestadoDTO.EstadoSolicitud = EstadoSolicitud;
            inspeccionObraServicioPrestadoDTO.IdentificacionContrato = IdentificacionContrato;
            inspeccionObraServicioPrestadoDTO.CodigoTipoObraServicio = CodigoTipoObraServicio;
            inspeccionObraServicioPrestadoDTO.CodigoTipoProceso = CodigoTipoProceso;
            inspeccionObraServicioPrestadoDTO.MontoContrato = MontoContrato;
            inspeccionObraServicioPrestadoDTO.FechaInicioObraServicio = FechaInicioObraServicio;
            inspeccionObraServicioPrestadoDTO.FechaTerminoEstimada = FechaTerminoEstimada;
            inspeccionObraServicioPrestadoDTO.PorcentajeAvanceFisico = PorcentajeAvanceFisico;
            inspeccionObraServicioPrestadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = inspeccionObraServicioPrestadoBL.ActualizarFormato(inspeccionObraServicioPrestadoDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            InspeccionObraServicioPrestadoDTO inspeccionObraServicioPrestadoDTO = new();
            inspeccionObraServicioPrestadoDTO.InspeccionObraServicioPrestadoId = Id;
            inspeccionObraServicioPrestadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (inspeccionObraServicioPrestadoBL.EliminarFormato(inspeccionObraServicioPrestadoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            InspeccionObraServicioPrestadoDTO inspeccionObraServicioPrestadoDTO = new();
            inspeccionObraServicioPrestadoDTO.CargaId = Id;
            inspeccionObraServicioPrestadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (inspeccionObraServicioPrestadoBL.EliminarCarga(inspeccionObraServicioPrestadoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<InspeccionObraServicioPrestadoDTO> lista = new List<InspeccionObraServicioPrestadoDTO>();
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

                    lista.Add(new InspeccionObraServicioPrestadoDTO
                    {
                        IdentificacionSolicitud = fila.GetCell(0).ToString(),
                        NombreObra = fila.GetCell(1).ToString(),
                        CodigoAreaDiperadmon = fila.GetCell(2).ToString(),
                        CodigoZonaNaval = fila.GetCell(3).ToString(),
                        EstadoSolicitud = fila.GetCell(4).ToString(),
                        IdentificacionContrato = fila.GetCell(5).ToString(),
                        CodigoTipoObraServicio = fila.GetCell(6).ToString(),
                        CodigoTipoProceso = fila.GetCell(7).ToString(),
                        MontoContrato = decimal.Parse(fila.GetCell(8).ToString()),
                        FechaInicioObraServicio = UtilitariosGlobales.obtenerFecha(fila.GetCell(9).ToString()),
                        FechaTerminoEstimada = UtilitariosGlobales.obtenerFecha(fila.GetCell(10).ToString()),
                        PorcentajeAvanceFisico = int.Parse(fila.GetCell(11).ToString())
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
        //Registrar Masivo[AuthorizePermission(Formato: 43, Permiso: 4)]
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string Fecha)
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
            DataTable dt = new();

            dt.Columns.AddRange(new DataColumn[13]
            {
                    new DataColumn("IdentificacionSolicitud", typeof(string)),
                    new DataColumn("NombreObra", typeof(string)),
                    new DataColumn("CodigoAreaDiperadmon", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("EstadoSolicitud", typeof(string)),
                    new DataColumn("IdentificacionContrato", typeof(string)),
                    new DataColumn("CodigoTipoObraServicio", typeof(string)),
                    new DataColumn("CodigoTipoProceso", typeof(string)),
                    new DataColumn("MontoContrato", typeof(decimal)),
                    new DataColumn("FechaInicioObraServicio", typeof(string)),
                    new DataColumn("FechaTerminoEstimada", typeof(string)),
                    new DataColumn("PorcentajeAvanceFisico", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    decimal.Parse(fila.GetCell(8).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(9).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(10).ToString()),
                    int.Parse(fila.GetCell(11).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = inspeccionObraServicioPrestadoBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = inspeccionObraServicioPrestadoBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DibinfraterInspeccionObraServicioPrestado.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DibinfraterInspeccionObraServicioPrestado.xlsx");
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

