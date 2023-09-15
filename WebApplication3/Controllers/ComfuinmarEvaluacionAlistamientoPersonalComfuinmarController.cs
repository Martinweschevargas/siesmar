using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comfuinmar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comfuinmar;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Presentacion.Filters;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Data;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class ComfuinmarEvaluacionAlistamientoPersonalComfuinmarController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EvaluacionAlistamientoPersonalComfuinmar evaluacionAlistamientoPersonalComfuinmarBL = new();
        UnidadNaval unidadNavalBL = new();
        Cargo cargoBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EspecialidadGenericaPersonal especialidadGenericaPersonalBL = new();
        Carga cargaBL = new();

        public ComfuinmarEvaluacionAlistamientoPersonalComfuinmarController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Evaluación del alistamiento de personal", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<CargoDTO> cargoDTO = cargoBL.ObtenerCargos();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EvaluacionAlistamientoPersonalComfuinmar");
            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = cargoDTO,
                data3 = gradoPersonalMilitarDTO,
                data4 = especialidadGenericaPersonalDTO,
                data5 = listaCargas
            });
        }


        public IActionResult CargaTabla()
        {
            List<EvaluacionAlistamientoPersonalComfuinmarDTO> select = evaluacionAlistamientoPersonalComfuinmarBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        ////[AuthorizePermission(Formato: 157, Permiso: 1)]//Registrar
        public ActionResult Insertar(string CodigoUnidadNaval, string FechaEvaluacion, string DNIPersonal, 
            string CIPPersonal, string CodigoCargo, string CodigoGradoPersonalMilitarEsperado, 
            string CodigoEspecialidadGenericaPersonalEsperado, string CodigoGradoPersonalMilitarActual, 
            string CodigoEspecialidadGenericaPersonalActual, decimal GradoJerarquico, decimal ServicioExperiencia, 
            decimal EspecializacionProfesional, decimal CursoProfesionalRequerido, int CargaId, string Fecha)
        {
            EvaluacionAlistamientoPersonalComfuinmarDTO evaluacionAlistamientoPersonalComfuinmarDTO = new();
            evaluacionAlistamientoPersonalComfuinmarDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoPersonalComfuinmarDTO.FechaEvaluacion = FechaEvaluacion;
            evaluacionAlistamientoPersonalComfuinmarDTO.DNIPersonal = DNIPersonal;
            evaluacionAlistamientoPersonalComfuinmarDTO.CIPPersonal = CIPPersonal;
            evaluacionAlistamientoPersonalComfuinmarDTO.CodigoCargo = CodigoCargo;
            evaluacionAlistamientoPersonalComfuinmarDTO.CodigoGradoPersonalMilitarEsperado = CodigoGradoPersonalMilitarEsperado;
            evaluacionAlistamientoPersonalComfuinmarDTO.CodigoEspecialidadGenericaPersonalEsperado = CodigoEspecialidadGenericaPersonalEsperado;
            evaluacionAlistamientoPersonalComfuinmarDTO.CodigoGradoPersonalMilitarActual = CodigoGradoPersonalMilitarActual;
            evaluacionAlistamientoPersonalComfuinmarDTO.CodigoEspecialidadGenericaPersonalActual = CodigoEspecialidadGenericaPersonalActual;
            evaluacionAlistamientoPersonalComfuinmarDTO.GradoJerarquico = GradoJerarquico;
            evaluacionAlistamientoPersonalComfuinmarDTO.ServicioExperiencia = ServicioExperiencia;
            evaluacionAlistamientoPersonalComfuinmarDTO.EspecializacionProfesional = EspecializacionProfesional;
            evaluacionAlistamientoPersonalComfuinmarDTO.CursoProfesionalRequerido = CursoProfesionalRequerido;
            evaluacionAlistamientoPersonalComfuinmarDTO.CargaId = CargaId;
            evaluacionAlistamientoPersonalComfuinmarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoPersonalComfuinmarBL.AgregarRegistro(evaluacionAlistamientoPersonalComfuinmarDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistamientoPersonalComfuinmarBL.EditarFormato(Id));
        }

        ////[AuthorizePermission(Formato: 157, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string FechaEvaluacion, string DNIPersonal,
            string CIPPersonal, string CodigoCargo, string CodigoGradoPersonalMilitarEsperado,
            string CodigoEspecialidadGenericaPersonalEsperado, string CodigoGradoPersonalMilitarActual,
            string CodigoEspecialidadGenericaPersonalActual, decimal GradoJerarquico, decimal ServicioExperiencia,
            decimal EspecializacionProfesional, decimal CursoProfesionalRequerido)
        {
            EvaluacionAlistamientoPersonalComfuinmarDTO evaluacionAlistamientoPersonalComfuinmarDTO = new();
            evaluacionAlistamientoPersonalComfuinmarDTO.EvaluacionAlistamientoPersonalId = Id;
            evaluacionAlistamientoPersonalComfuinmarDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoPersonalComfuinmarDTO.FechaEvaluacion = FechaEvaluacion;
            evaluacionAlistamientoPersonalComfuinmarDTO.DNIPersonal = DNIPersonal;
            evaluacionAlistamientoPersonalComfuinmarDTO.CIPPersonal = CIPPersonal;
            evaluacionAlistamientoPersonalComfuinmarDTO.CodigoCargo = CodigoCargo;
            evaluacionAlistamientoPersonalComfuinmarDTO.CodigoGradoPersonalMilitarEsperado = CodigoGradoPersonalMilitarEsperado;
            evaluacionAlistamientoPersonalComfuinmarDTO.CodigoEspecialidadGenericaPersonalEsperado = CodigoEspecialidadGenericaPersonalEsperado;
            evaluacionAlistamientoPersonalComfuinmarDTO.CodigoGradoPersonalMilitarActual = CodigoGradoPersonalMilitarActual;
            evaluacionAlistamientoPersonalComfuinmarDTO.CodigoEspecialidadGenericaPersonalActual = CodigoEspecialidadGenericaPersonalActual;
            evaluacionAlistamientoPersonalComfuinmarDTO.GradoJerarquico = GradoJerarquico;
            evaluacionAlistamientoPersonalComfuinmarDTO.ServicioExperiencia = ServicioExperiencia;
            evaluacionAlistamientoPersonalComfuinmarDTO.EspecializacionProfesional = EspecializacionProfesional;
            evaluacionAlistamientoPersonalComfuinmarDTO.CursoProfesionalRequerido = CursoProfesionalRequerido;
            evaluacionAlistamientoPersonalComfuinmarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoPersonalComfuinmarBL.ActualizarFormato(evaluacionAlistamientoPersonalComfuinmarDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 157, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoPersonalComfuinmarDTO evaluacionAlistamientoPersonalComfuinmarDTO = new();
            evaluacionAlistamientoPersonalComfuinmarDTO.EvaluacionAlistamientoPersonalId = Id;
            evaluacionAlistamientoPersonalComfuinmarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionAlistamientoPersonalComfuinmarBL.EliminarFormato(evaluacionAlistamientoPersonalComfuinmarDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        ////[AuthorizePermission(Formato: 157, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoPersonalComfuinmarDTO evaluacionAlistamientoPersonalComfuinmarDTO = new();
            evaluacionAlistamientoPersonalComfuinmarDTO.CargaId = Id;
            evaluacionAlistamientoPersonalComfuinmarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (evaluacionAlistamientoPersonalComfuinmarBL.EliminarCarga(evaluacionAlistamientoPersonalComfuinmarDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionAlistamientoPersonalComfuinmarDTO> lista = new List<EvaluacionAlistamientoPersonalComfuinmarDTO>();
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

                    lista.Add(new EvaluacionAlistamientoPersonalComfuinmarDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        FechaEvaluacion = fila.GetCell(1).ToString(),
                        DNIPersonal = fila.GetCell(2).ToString(),
                        CIPPersonal = fila.GetCell(3).ToString(),
                        CodigoCargo = fila.GetCell(4).ToString(),
                        CodigoGradoPersonalMilitarEsperado = fila.GetCell(5).ToString(),
                        CodigoEspecialidadGenericaPersonalEsperado = fila.GetCell(6).ToString(),
                        CodigoGradoPersonalMilitarActual = fila.GetCell(7).ToString(),
                        CodigoEspecialidadGenericaPersonalActual = fila.GetCell(8).ToString(),
                        GradoJerarquico = decimal.Parse(fila.GetCell(9).ToString()),
                        ServicioExperiencia = decimal.Parse(fila.GetCell(10).ToString()),
                        EspecializacionProfesional = decimal.Parse(fila.GetCell(11).ToString()),
                        CursoProfesionalRequerido = decimal.Parse(fila.GetCell(12).ToString())
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
        ////[AuthorizePermission(Formato: 157, Permiso: 4)]//Registrar Masivo
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string Fecha)
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

            dt.Columns.AddRange(new DataColumn[14]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("FechaEvaluacion", typeof(string)),
                    new DataColumn("DNIPersonal", typeof(string)),
                    new DataColumn("CIPPersonal", typeof(string)),
                    new DataColumn("CodigoCargo", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitarEsperado", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaPersonalEsperado", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitarActual", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaPersonalActual", typeof(string)),
                    new DataColumn("GradoJerarquico", typeof(decimal)),
                    new DataColumn("ServicioExperiencia", typeof(decimal)),
                    new DataColumn("EspecializacionProfesional", typeof(decimal)),
                    new DataColumn("CursoProfesionalRequerido", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    decimal.Parse(fila.GetCell(9).ToString()),
                    decimal.Parse(fila.GetCell(10).ToString()),
                    decimal.Parse(fila.GetCell(11).ToString()),
                    decimal.Parse(fila.GetCell(12).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = evaluacionAlistamientoPersonalComfuinmarBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            LocalReport localReport = new LocalReport(path);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfuinmarEvaluacionAlistamientoPersonal.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfuinmarEvaluacionAlistamientoPersonal.xlsx");
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

