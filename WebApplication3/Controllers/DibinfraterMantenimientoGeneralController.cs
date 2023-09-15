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

    public class DibinfraterMantenimientoGeneralController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        MantenimientoGeneral mantenimientoGeneralBL = new();
        AreaDiperadmon areaDiperadmonBL = new();
        ZonaNaval zonaNavalBL = new();
        TipoMantenimiento tipoMantenimientoBL = new();
        Carga cargaBL = new();

        public DibinfraterMantenimientoGeneralController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Mantenimiento General", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<AreaDiperadmonDTO> areaDiperadmonDTO = areaDiperadmonBL.ObtenerAreaDiperadmons();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<TipoMantenimientoDTO> tipoMantenimientoDTO = tipoMantenimientoBL.ObtenerTipoMantenimientos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("MantenimientoGeneral");
            return Json(new
            {
                data1 = areaDiperadmonDTO,
                data2 = zonaNavalDTO,
                data3 = tipoMantenimientoDTO,
                data4 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<MantenimientoGeneralDTO> select = mantenimientoGeneralBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string SolicitudMantenimiento, string CodigoAreaDiperadmon, string CodigoZonaNaval, string EstadoSolicitud,
            string CodigoTipoMantenimiento, string FechaInicioMantenimiento, string FechaTerminoMantenimiento, int CargaId, string Fecha)
        {
            MantenimientoGeneralDTO mantenimientoGeneralDTO = new();
            mantenimientoGeneralDTO.SolicitudMantenimiento = SolicitudMantenimiento;
            mantenimientoGeneralDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            mantenimientoGeneralDTO.CodigoZonaNaval = CodigoZonaNaval;
            mantenimientoGeneralDTO.EstadoSolicitud = EstadoSolicitud;
            mantenimientoGeneralDTO.CodigoTipoMantenimiento = CodigoTipoMantenimiento;
            mantenimientoGeneralDTO.FechaInicioMantenimiento = FechaInicioMantenimiento;
            mantenimientoGeneralDTO.FechaTerminoMantenimiento = FechaTerminoMantenimiento;
            mantenimientoGeneralDTO.CargaId = CargaId;
            mantenimientoGeneralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = mantenimientoGeneralBL.AgregarRegistro(mantenimientoGeneralDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(mantenimientoGeneralBL.EditarFormato(Id));
        }


        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id,  string SolicitudMantenimiento, string CodigoAreaDiperadmon, string CodigoZonaNaval, string EstadoSolicitud,
            string CodigoTipoMantenimiento, string FechaInicioMantenimiento, string FechaTerminoMantenimiento)
        {
            MantenimientoGeneralDTO mantenimientoGeneralDTO = new();
            mantenimientoGeneralDTO.MantenimientoGeneralId = Id;
            mantenimientoGeneralDTO.SolicitudMantenimiento = SolicitudMantenimiento;
            mantenimientoGeneralDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            mantenimientoGeneralDTO.CodigoZonaNaval = CodigoZonaNaval;
            mantenimientoGeneralDTO.EstadoSolicitud = EstadoSolicitud;
            mantenimientoGeneralDTO.CodigoTipoMantenimiento = CodigoTipoMantenimiento;
            mantenimientoGeneralDTO.FechaInicioMantenimiento = FechaInicioMantenimiento;
            mantenimientoGeneralDTO.FechaTerminoMantenimiento = FechaTerminoMantenimiento;
            mantenimientoGeneralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = mantenimientoGeneralBL.ActualizarFormato(mantenimientoGeneralDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            MantenimientoGeneralDTO mantenimientoGeneralDTO = new();
            mantenimientoGeneralDTO.MantenimientoGeneralId = Id;
            mantenimientoGeneralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (mantenimientoGeneralBL.EliminarFormato(mantenimientoGeneralDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            MantenimientoGeneralDTO mantenimientoGeneralDTO = new();
            mantenimientoGeneralDTO.CargaId = Id;
            mantenimientoGeneralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (mantenimientoGeneralBL.EliminarCarga(mantenimientoGeneralDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<MantenimientoGeneralDTO> lista = new List<MantenimientoGeneralDTO>();
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

                    lista.Add(new MantenimientoGeneralDTO
                    {
                        SolicitudMantenimiento = fila.GetCell(0).ToString(),
                        CodigoAreaDiperadmon = fila.GetCell(1).ToString(),
                        CodigoZonaNaval = fila.GetCell(2).ToString(),
                        EstadoSolicitud = fila.GetCell(3).ToString(),
                        CodigoTipoMantenimiento = fila.GetCell(4).ToString(),
                        FechaInicioMantenimiento = UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                        FechaTerminoMantenimiento = UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString())
                    });
                }
            }
            catch (Exception)
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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("SolicitudMantenimiento", typeof(string)),
                    new DataColumn("CodigoAreaDiperadmon", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("EstadoSolicitud", typeof(string)),
                    new DataColumn("CodigoTipoMantenimiento", typeof(string)),
                    new DataColumn("FechaInicioMantenimiento", typeof(string)),
                    new DataColumn("FechaTerminoMantenimiento", typeof(string)),
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
                            UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                            UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                            User.obtenerUsuario());
            }
            var IND_OPERACION = mantenimientoGeneralBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = mantenimientoGeneralBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DibinfraterMantenimientoGeneral.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DibinfraterMantenimientoGeneral.xlsx");
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

