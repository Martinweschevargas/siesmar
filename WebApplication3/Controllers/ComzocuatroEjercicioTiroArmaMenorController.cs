using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzocuatro;
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

    public class ComzocuatroEjercicioTiroArmaMenorController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        EjercicioTiroArmaMenorComzocuatro ejercicioTiroArmaMenorComzocuatroBL = new();

        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        TipoArmamento tipoArmamentoBL = new();
        PosicionTipoArma posicionTipoArmaBL = new();

        Carga cargaBL = new();

        public ComzocuatroEjercicioTiroArmaMenorController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Ejercicios de Tiro con Armas Menores", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<TipoArmamentoDTO> tipoArmamentoDTO = tipoArmamentoBL.ObtenerTipoArmamentos();
            List<PosicionTipoArmaDTO> posicionTipoArmaDTO = posicionTipoArmaBL.ObtenerPosicionTipoArmas();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EjercicioTiroArmaMenorComzocuatro");

            return Json(new { data1 = tipoPersonalMilitarDTO, data2 = gradoPersonalMilitarDTO, data3 = tipoArmamentoDTO, data4 = posicionTipoArmaDTO, data5 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<EjercicioTiroArmaMenorComzocuatroDTO> select = ejercicioTiroArmaMenorComzocuatroBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar, string FechaEjercicio, string CodigoTipoArmamento,
            string CodigoPosicionTipoArma, decimal DistanciaMetros, int CantidadTiro, int CargaId)
        {
            EjercicioTiroArmaMenorComzocuatroDTO ejercicioTiroArmaMenorComzocuatro= new();
            ejercicioTiroArmaMenorComzocuatro.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            ejercicioTiroArmaMenorComzocuatro.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            ejercicioTiroArmaMenorComzocuatro.FechaEjercicio = FechaEjercicio;
            ejercicioTiroArmaMenorComzocuatro.CodigoTipoArmamento = CodigoTipoArmamento;
            ejercicioTiroArmaMenorComzocuatro.CodigoPosicionTipoArma = CodigoPosicionTipoArma;
            ejercicioTiroArmaMenorComzocuatro.DistanciaMetros = DistanciaMetros;
            ejercicioTiroArmaMenorComzocuatro.CantidadTiro = CantidadTiro;
            ejercicioTiroArmaMenorComzocuatro.CargaId = CargaId;
            ejercicioTiroArmaMenorComzocuatro.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ejercicioTiroArmaMenorComzocuatroBL.AgregarRegistro(ejercicioTiroArmaMenorComzocuatro);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(ejercicioTiroArmaMenorComzocuatroBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar, string FechaEjercicio, string CodigoTipoArmamento,
            string CodigoPosicionTipoArma, decimal DistanciaMetros, int CantidadTiro)
        {
            EjercicioTiroArmaMenorComzocuatroDTO ejercicioTiroArmaMenorComzocuatro= new();
            ejercicioTiroArmaMenorComzocuatro.EjercicioTiroArmaMenorId = Id;
            ejercicioTiroArmaMenorComzocuatro.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            ejercicioTiroArmaMenorComzocuatro.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            ejercicioTiroArmaMenorComzocuatro.FechaEjercicio = FechaEjercicio;
            ejercicioTiroArmaMenorComzocuatro.CodigoTipoArmamento = CodigoTipoArmamento;
            ejercicioTiroArmaMenorComzocuatro.CodigoPosicionTipoArma = CodigoPosicionTipoArma;
            ejercicioTiroArmaMenorComzocuatro.DistanciaMetros = DistanciaMetros;
            ejercicioTiroArmaMenorComzocuatro.CantidadTiro = CantidadTiro;
            ejercicioTiroArmaMenorComzocuatro.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ejercicioTiroArmaMenorComzocuatroBL.ActualizarFormato(ejercicioTiroArmaMenorComzocuatro);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EjercicioTiroArmaMenorComzocuatroDTO ejercicioTiroArmaMenorComzocuatro= new();
            ejercicioTiroArmaMenorComzocuatro.EjercicioTiroArmaMenorId = Id;
            ejercicioTiroArmaMenorComzocuatro.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (ejercicioTiroArmaMenorComzocuatroBL.EliminarFormato(ejercicioTiroArmaMenorComzocuatro) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EjercicioTiroArmaMenorComzocuatroDTO> lista = new List<EjercicioTiroArmaMenorComzocuatroDTO>();
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

                    lista.Add(new EjercicioTiroArmaMenorComzocuatroDTO
                    {
                        CodigoTipoPersonalMilitar = fila.GetCell(0).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(1).ToString(),
                        FechaEjercicio = fila.GetCell(2).ToString(),
                        CodigoTipoArmamento = fila.GetCell(3).ToString(),
                        DistanciaMetros = int.Parse(fila.GetCell(4).ToString()),
                        CantidadTiro = int.Parse(fila.GetCell(5).ToString())

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

            dt.Columns.AddRange(new DataColumn[7]
            {
                    new DataColumn("CodigoTipoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("FechaEjercicio", typeof(string)),
                    new DataColumn("CodigoTipoArmamento", typeof(string)),
                    new DataColumn("DistanciaMetros", typeof(int)),
                     new DataColumn("CantidadTiro", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                              fila.GetCell(0).ToString(),
                              fila.GetCell(1).ToString(),
                              UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                              fila.GetCell(3).ToString(),
                              int.Parse(fila.GetCell(4).ToString()),
                              int.Parse(fila.GetCell(5).ToString()),
                              User.obtenerUsuario());
            }
            var IND_OPERACION = ejercicioTiroArmaMenorComzocuatroBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = ejercicioTiroArmaMenorComzocuatroBL.ObtenerLista();
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

