using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comoperpac;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Formatos.Comoperpac;
using Marina.Siesmar.LogicaNegocios.Formatos.Comoperpac;
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

    public class ComoperpacEfectivoAccionMilitarController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        EfectivoAccionMilitar efectivoAccionMilitarBL = new();

        ComandanciaNaval comandanciaNavalBL = new();
        DepartamentoUbigeo departamentoBL = new();
        ProvinciaUbigeo provinciaBL = new();
        DistritoUbigeo distritoBL = new();
        GradoPersonal gradoPersonalBL = new();



        public ComoperpacEfectivoAccionMilitarController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Efectivos que Participan en Acciones Militares", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<ComandanciaNavalDTO> comandanciaNavalDTO = comandanciaNavalBL.ObtenerComandanciaNavals();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoBL.ObtenerDistritoUbigeos();
            List<GradoPersonalDTO> gradoPersonalDTO = gradoPersonalBL.ObtenerGradoPersonals();

            return Json(new 
            { 
                data1 = comandanciaNavalDTO,
                data2 = departamentoUbigeoDTO, 
                data3 = provinciaUbigeoDTO,
                data4 = distritoUbigeoDTO, 
                data5 = gradoPersonalDTO
            });
        }

        public IActionResult CargaTabla()
        {
            List<EfectivoAccionMilitarDTO> select = efectivoAccionMilitarBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(int ComandanciaNavalId, int DepartamentoUbigeoId, int ProvinciaUbigeoId, int DistritoUbigeoId,
            string UnidadParticipante, int GradoPersonalId, string ObservacionesEfectivoAccionMilitar)
        {
            EfectivoAccionMilitarDTO efectivoAccionMilitarDTO = new();
            efectivoAccionMilitarDTO.ComandanciaNavalId = ComandanciaNavalId;
            efectivoAccionMilitarDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            efectivoAccionMilitarDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            efectivoAccionMilitarDTO.DistritoUbigeoId = DistritoUbigeoId;
            efectivoAccionMilitarDTO.UnidadParticipante = UnidadParticipante;
            efectivoAccionMilitarDTO.GradoPersonalId = GradoPersonalId;
            efectivoAccionMilitarDTO.ObservacionesEfectivoAccionMilitar = ObservacionesEfectivoAccionMilitar;
            efectivoAccionMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = efectivoAccionMilitarBL.AgregarRegistro(efectivoAccionMilitarDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(efectivoAccionMilitarBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int ComandanciaNavalId, int DepartamentoUbigeoId, int ProvinciaUbigeoId, int DistritoUbigeoId,
            string UnidadParticipante, int GradoPersonalId, string ObservacionesEfectivoAccionMilitar)
        {
            EfectivoAccionMilitarDTO efectivoAccionMilitarDTO = new();
            efectivoAccionMilitarDTO.EfectivoAccionMilitarId = Id;
            efectivoAccionMilitarDTO.ComandanciaNavalId = ComandanciaNavalId;
            efectivoAccionMilitarDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            efectivoAccionMilitarDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            efectivoAccionMilitarDTO.DistritoUbigeoId = DistritoUbigeoId;
            efectivoAccionMilitarDTO.UnidadParticipante = UnidadParticipante;
            efectivoAccionMilitarDTO.GradoPersonalId = GradoPersonalId;
            efectivoAccionMilitarDTO.ObservacionesEfectivoAccionMilitar = ObservacionesEfectivoAccionMilitar;
            efectivoAccionMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = efectivoAccionMilitarBL.ActualizarFormato(efectivoAccionMilitarDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EfectivoAccionMilitarDTO efectivoAccionMilitarDTO = new();
            efectivoAccionMilitarDTO.EfectivoAccionMilitarId = Id;
            efectivoAccionMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (efectivoAccionMilitarBL.EliminarFormato(efectivoAccionMilitarDTO) == true)
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

            List<EfectivoAccionMilitarDTO> lista = new List<EfectivoAccionMilitarDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new EfectivoAccionMilitarDTO
                {
                    ComandanciaNavalId = int.Parse(fila.GetCell(0).ToString()),
                    DistritoUbigeoId = int.Parse(fila.GetCell(1).ToString()),
                    UnidadParticipante = fila.GetCell(2).ToString(),
                    GradoPersonalId = int.Parse(fila.GetCell(3).ToString()),
                    ObservacionesEfectivoAccionMilitar = fila.GetCell(4).ToString(),
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
            DataTable dt = new();

            dt.Columns.AddRange(new DataColumn[6]
            {
                    new DataColumn("ComandanciaNavalId", typeof(int)),
                    new DataColumn("DistritoUbigeoId", typeof(int)),
                    new DataColumn("UnidadParticipante", typeof(string)),
                    new DataColumn("GradoPersonalId", typeof(int)),
                    new DataColumn("ObservacionesEfectivoAccionMilitar", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    int.Parse(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    int.Parse(fila.GetCell(3).ToString()),
                    fila.GetCell(4).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = efectivoAccionMilitarBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteCiberataque()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\prueba.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var capitania = efectivoAccionMilitarBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", capitania);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComoperpacEfectivoAccionMilitar.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComoperpacEfectivoAccionMilitar.xlsx");
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

