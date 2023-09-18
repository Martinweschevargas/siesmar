using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
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

    public class ComzocuatroEvaluacionAlistPersonalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        EvaluacionAlistPersonalComzocuatro evaluacionAlistPersonalComzocuatroBL = new();

        UnidadNaval unidadNavalBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EspecialidadGenericaPersonal especialidadGenericaPersonalBL = new();

        Carga cargaBL = new();

        public ComzocuatroEvaluacionAlistPersonalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Evaluación del Alistamiento de Personal", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitaroDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EvaluacionAlistamientoPersonalComzocuatro");

            return Json(new { data1 = unidadNavalDTO, data2 = gradoPersonalMilitaroDTO, data3 = especialidadGenericaPersonalDTO, data4 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionAlistPersonalComzocuatroDTO> select = evaluacionAlistPersonalComzocuatroBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar( string CodigoUnidadNaval, string FechaEvaluacion, int DNIPersonal, int CIPPersonal, string CargoPersonal, int GradoPersonalMilitarEsperado,
            int EspecialidadGenericaEsperado, int GradoPersonalMilitarActual, int EspecialidadGenericaActual, decimal GradoJerarquico, decimal ServicioExperiencia,
            decimal EspecializacionProfesional, decimal CursoProfesionalRequerido, decimal PuntajeTotalPersonal, int CargaId)
        {
            EvaluacionAlistPersonalComzocuatroDTO evaluacionAlistPersonalComzocuatroDTO = new();
            evaluacionAlistPersonalComzocuatroDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistPersonalComzocuatroDTO.FechaEvaluacion = FechaEvaluacion;
            evaluacionAlistPersonalComzocuatroDTO.DNIPersonal = DNIPersonal;
            evaluacionAlistPersonalComzocuatroDTO.CIPPersonal = CIPPersonal;
            evaluacionAlistPersonalComzocuatroDTO.CargoPersonal = CargoPersonal;
            evaluacionAlistPersonalComzocuatroDTO.GradoPersonalMilitarEsperado = GradoPersonalMilitarEsperado;
            evaluacionAlistPersonalComzocuatroDTO.EspecialidadGenericaEsperado = EspecialidadGenericaEsperado;
            evaluacionAlistPersonalComzocuatroDTO.GradoPersonalMilitarActual = GradoPersonalMilitarActual;
            evaluacionAlistPersonalComzocuatroDTO.EspecialidadGenericaActual = EspecialidadGenericaActual;
            evaluacionAlistPersonalComzocuatroDTO.GradoJerarquico = GradoJerarquico;
            evaluacionAlistPersonalComzocuatroDTO.ServicioExperiencia = ServicioExperiencia;
            evaluacionAlistPersonalComzocuatroDTO.EspecializacionProfesional = EspecializacionProfesional;
            evaluacionAlistPersonalComzocuatroDTO.CursoProfesionalRequerido = CursoProfesionalRequerido;
            evaluacionAlistPersonalComzocuatroDTO.PuntajeTotalPersonal = PuntajeTotalPersonal;
            evaluacionAlistPersonalComzocuatroDTO.CargaId = CargaId;
            evaluacionAlistPersonalComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistPersonalComzocuatroBL.AgregarRegistro(evaluacionAlistPersonalComzocuatroDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistPersonalComzocuatroBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id,string CodigoUnidadNaval, string FechaEvaluacion, int DNIPersonal, int CIPPersonal, string CargoPersonal, int GradoPersonalMilitarEsperado, 
            int EspecialidadGenericaEsperado, int GradoPersonalMilitarActual, int EspecialidadGenericaActual, decimal GradoJerarquico, decimal ServicioExperiencia, 
            decimal EspecializacionProfesional, decimal CursoProfesionalRequerido, decimal PuntajeTotalPersonal)
        {
            EvaluacionAlistPersonalComzocuatroDTO evaluacionAlistPersonalComzocuatroDTO = new();
            evaluacionAlistPersonalComzocuatroDTO.EvaluacionAlistamientoPersonalId = Id;
            evaluacionAlistPersonalComzocuatroDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistPersonalComzocuatroDTO.FechaEvaluacion = FechaEvaluacion;
            evaluacionAlistPersonalComzocuatroDTO.DNIPersonal = DNIPersonal;
            evaluacionAlistPersonalComzocuatroDTO.CIPPersonal = CIPPersonal;
            evaluacionAlistPersonalComzocuatroDTO.CargoPersonal = CargoPersonal;
            evaluacionAlistPersonalComzocuatroDTO.GradoPersonalMilitarEsperado = GradoPersonalMilitarEsperado;
            evaluacionAlistPersonalComzocuatroDTO.EspecialidadGenericaEsperado = EspecialidadGenericaEsperado;
            evaluacionAlistPersonalComzocuatroDTO.GradoPersonalMilitarActual = GradoPersonalMilitarActual;
            evaluacionAlistPersonalComzocuatroDTO.EspecialidadGenericaActual = EspecialidadGenericaActual;
            evaluacionAlistPersonalComzocuatroDTO.GradoJerarquico = GradoJerarquico;
            evaluacionAlistPersonalComzocuatroDTO.ServicioExperiencia = ServicioExperiencia;
            evaluacionAlistPersonalComzocuatroDTO.EspecializacionProfesional = EspecializacionProfesional;
            evaluacionAlistPersonalComzocuatroDTO.CursoProfesionalRequerido = CursoProfesionalRequerido;
            evaluacionAlistPersonalComzocuatroDTO.PuntajeTotalPersonal = PuntajeTotalPersonal;
            evaluacionAlistPersonalComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistPersonalComzocuatroBL.ActualizarFormato(evaluacionAlistPersonalComzocuatroDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistPersonalComzocuatroDTO evaluacionAlistPersonalComzocuatroDTO = new();
            evaluacionAlistPersonalComzocuatroDTO.EvaluacionAlistamientoPersonalId = Id;
            evaluacionAlistPersonalComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionAlistPersonalComzocuatroBL.EliminarFormato(evaluacionAlistPersonalComzocuatroDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionAlistPersonalComzocuatroDTO> lista = new List<EvaluacionAlistPersonalComzocuatroDTO>();
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

                    lista.Add(new EvaluacionAlistPersonalComzocuatroDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        FechaEvaluacion = fila.GetCell(1).ToString(),
                        DNIPersonal = int.Parse(fila.GetCell(2).ToString()),
                        CIPPersonal = int.Parse(fila.GetCell(3).ToString()),
                        CargoPersonal = fila.GetCell(4).ToString(),
                        GradoPersonalMilitarEsperado = int.Parse(fila.GetCell(5).ToString()),
                        EspecialidadGenericaEsperado = int.Parse(fila.GetCell(6).ToString()),
                        GradoPersonalMilitarActual = int.Parse(fila.GetCell(7).ToString()),
                        EspecialidadGenericaActual = int.Parse(fila.GetCell(8).ToString()),
                        GradoJerarquico = int.Parse(fila.GetCell(9).ToString()),
                        ServicioExperiencia = int.Parse(fila.GetCell(10).ToString()),
                        EspecializacionProfesional = int.Parse(fila.GetCell(11).ToString()),
                        CursoProfesionalRequerido = int.Parse(fila.GetCell(12).ToString()),
                        PuntajeTotalPersonal = int.Parse(fila.GetCell(13).ToString())
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

            dt.Columns.AddRange(new DataColumn[15]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("FechaEvaluacion", typeof(string)),
                    new DataColumn("DNIPersonal", typeof(int)),
                    new DataColumn("CIPPersonal", typeof(int)),
                    new DataColumn("CargoPersonal", typeof(string)), 
                    new DataColumn("GradoPersonalMilitarEsperado", typeof(int)),
                    new DataColumn("EspecialidadGenericaEsperado", typeof(int)),
                    new DataColumn("GradoPersonalMilitarActual", typeof(int)),
                    new DataColumn("EspecialidadGenericaActual", typeof(int)),
                    new DataColumn("GradoJerarquico", typeof(int)), 
                    new DataColumn("ServicioExperiencia", typeof(int)),
                    new DataColumn("EspecializacionProfesional", typeof(int)),
                    new DataColumn("CursoProfesionalRequerido", typeof(int)),
                    new DataColumn("PuntajeTotalPersonal", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                             fila.GetCell(0).ToString(),
                             UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                             int.Parse(fila.GetCell(2).ToString()),
                             int.Parse(fila.GetCell(3).ToString()),
                             fila.GetCell(4).ToString(),
                             int.Parse(fila.GetCell(5).ToString()),
                             int.Parse(fila.GetCell(6).ToString()),
                             int.Parse(fila.GetCell(7).ToString()),
                             int.Parse(fila.GetCell(8).ToString()),
                             int.Parse(fila.GetCell(9).ToString()),
                             int.Parse(fila.GetCell(10).ToString()),
                             int.Parse(fila.GetCell(11).ToString()),
                             int.Parse(fila.GetCell(12).ToString()),
                             int.Parse(fila.GetCell(13).ToString()),
                             User.obtenerUsuario());
            }
            var IND_OPERACION = evaluacionAlistPersonalComzocuatroBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = evaluacionAlistPersonalComzocuatroBL.ObtenerLista();
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

