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

    public class CombasnaiMovilidadFlotaPesadaLivianaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        MovilidadFlotaPesadaLivianaCombasnai movilidadFlotaPesadaLivianaCombasnaiBL = new();

        UnidadNaval unidadNavalBL = new();
        ClaseFlota claseFlotaBL = new();
        Dependencia dependenciaBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        CapacidadOperativaRequerida capacidadOperativaRequeridaBL = new();
        Condicion condicionBL = new();

        public CombasnaiMovilidadFlotaPesadaLivianaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Situación de Movilidades de Flota Pesada y Liviana", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<ClaseFlotaDTO> claseFlotaDTO = claseFlotaBL.ObtenerClaseFlotas();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<CapacidadOperativaRequeridaDTO> capacidadOperativaRequeridaDTO = capacidadOperativaRequeridaBL.ObtenerCapacidadOperativaRequeridas();
            List<CondicionDTO> condicionDTO = condicionBL.ObtenerCondicions();

            return Json(new { data1 = unidadNavalDTO, data2 = claseFlotaDTO, data3 = dependenciaDTO, data4 = departamentoUbigeoDTO, data5 = provinciaUbigeoDTO, 
                data6 = distritoUbigeoDTO, data7 = capacidadOperativaRequeridaDTO, data8 = condicionDTO });
        }

        public IActionResult CargaTabla()
        {
            List<MovilidadFlotaPesadaLivianaCombasnaiDTO> select = movilidadFlotaPesadaLivianaCombasnaiBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar( int UnidadNavalId, int ClaseFlotaId, int DependenciaId, string Ubicacion, int DepartamentoUbigeoId, int ProvinciaUbigeoId,
            int DistritoUbigeoId, int CapacidadOperativaRequeridaId, int CondicionId, string Observacion)
        {
            MovilidadFlotaPesadaLivianaCombasnaiDTO movilidadFlotaPesadaLivianaCombasnaiDTO = new();
            movilidadFlotaPesadaLivianaCombasnaiDTO.UnidadNavalId = UnidadNavalId;
            movilidadFlotaPesadaLivianaCombasnaiDTO.ClaseFlotaId = ClaseFlotaId;
            movilidadFlotaPesadaLivianaCombasnaiDTO.DependenciaId = DependenciaId;
            movilidadFlotaPesadaLivianaCombasnaiDTO.Ubicacion = Ubicacion;
            movilidadFlotaPesadaLivianaCombasnaiDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            movilidadFlotaPesadaLivianaCombasnaiDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            movilidadFlotaPesadaLivianaCombasnaiDTO.DistritoUbigeoId = DistritoUbigeoId;
            movilidadFlotaPesadaLivianaCombasnaiDTO.CapacidadOperativaRequeridaId = CapacidadOperativaRequeridaId;
            movilidadFlotaPesadaLivianaCombasnaiDTO.CondicionId = CondicionId;
            movilidadFlotaPesadaLivianaCombasnaiDTO.Observacion = Observacion;
            movilidadFlotaPesadaLivianaCombasnaiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = movilidadFlotaPesadaLivianaCombasnaiBL.AgregarRegistro(movilidadFlotaPesadaLivianaCombasnaiDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(movilidadFlotaPesadaLivianaCombasnaiBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id,  int UnidadNavalId, int ClaseFlotaId, int DependenciaId, string Ubicacion, int DepartamentoUbigeoId,
            int ProvinciaUbigeoId, int DistritoUbigeoId, int CapacidadOperativaRequeridaId, int CondicionId, string Observacion)
        {
            MovilidadFlotaPesadaLivianaCombasnaiDTO movilidadFlotaPesadaLivianaCombasnaiDTO = new();
            movilidadFlotaPesadaLivianaCombasnaiDTO.MovilidadFlotaPesadaLivianaId = Id;
            movilidadFlotaPesadaLivianaCombasnaiDTO.UnidadNavalId = UnidadNavalId;
            movilidadFlotaPesadaLivianaCombasnaiDTO.ClaseFlotaId = ClaseFlotaId;
            movilidadFlotaPesadaLivianaCombasnaiDTO.DependenciaId = DependenciaId;
            movilidadFlotaPesadaLivianaCombasnaiDTO.Ubicacion = Ubicacion;
            movilidadFlotaPesadaLivianaCombasnaiDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            movilidadFlotaPesadaLivianaCombasnaiDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            movilidadFlotaPesadaLivianaCombasnaiDTO.DistritoUbigeoId = DistritoUbigeoId;
            movilidadFlotaPesadaLivianaCombasnaiDTO.CapacidadOperativaRequeridaId = CapacidadOperativaRequeridaId;
            movilidadFlotaPesadaLivianaCombasnaiDTO.CondicionId = CondicionId;
            movilidadFlotaPesadaLivianaCombasnaiDTO.Observacion = Observacion;
            movilidadFlotaPesadaLivianaCombasnaiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = movilidadFlotaPesadaLivianaCombasnaiBL.ActualizarFormato(movilidadFlotaPesadaLivianaCombasnaiDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            MovilidadFlotaPesadaLivianaCombasnaiDTO movilidadFlotaPesadaLivianaCombasnaiDTO = new();
            movilidadFlotaPesadaLivianaCombasnaiDTO.MovilidadFlotaPesadaLivianaId = Id;
            movilidadFlotaPesadaLivianaCombasnaiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (movilidadFlotaPesadaLivianaCombasnaiBL.EliminarFormato(movilidadFlotaPesadaLivianaCombasnaiDTO) == true)
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

            List<MovilidadFlotaPesadaLivianaCombasnaiDTO> lista = new List<MovilidadFlotaPesadaLivianaCombasnaiDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new MovilidadFlotaPesadaLivianaCombasnaiDTO
                {

                    UnidadNavalId = int.Parse(fila.GetCell(0).ToString()),
                    ClaseFlotaId = int.Parse(fila.GetCell(1).ToString()),
                    DependenciaId = int.Parse(fila.GetCell(3).ToString()),
                    Ubicacion = fila.GetCell(4).ToString(),
                    DepartamentoUbigeoId = int.Parse(fila.GetCell(5).ToString()),
                    ProvinciaUbigeoId = int.Parse(fila.GetCell(6).ToString()),
                    DistritoUbigeoId = int.Parse(fila.GetCell(7).ToString()),
                    CapacidadOperativaRequeridaId = int.Parse(fila.GetCell(8).ToString()),
                    CondicionId = int.Parse(fila.GetCell(9).ToString()),
                    Observacion = fila.GetCell(10).ToString(),

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

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("UnidadNavalId", typeof(int)),
                    new DataColumn("ClaseFlotaId", typeof(int)),
                    new DataColumn("DependenciaId", typeof(int)),
                    new DataColumn("Ubicacion", typeof(string)),
                    new DataColumn("DepartamentoUbigeoId", typeof(int)),
                    new DataColumn("ProvinciaUbigeoId", typeof(int)),
                    new DataColumn("DistritoUbigeoId", typeof(int)),
                    new DataColumn("CapacidadOperativaRequeridaId", typeof(int)),
                    new DataColumn("CondicionId", typeof(int)),
                    new DataColumn("Observacion", typeof(string)),
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    int.Parse(fila.GetCell(1).ToString()),
                    int.Parse(fila.GetCell(2).ToString()),
                    fila.GetCell(3).ToString(),
                    int.Parse(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    int.Parse(fila.GetCell(6).ToString()),
                    fila.GetCell(7).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = movilidadFlotaPesadaLivianaCombasnaiBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //Alistamiento Material Combasnai
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Combasnai\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var CombasnaiMovilidadFlotaPesadaLivianas = movilidadFlotaPesadaLivianaCombasnaiBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("CombasnaiMovilidadFlotaPesadaLiviana", CombasnaiMovilidadFlotaPesadaLivianas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\CombasnaiMovilidadFlotaPesadaLiviana.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "CombasnaiMovilidadFlotaPesadaLiviana.xlsx");
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

