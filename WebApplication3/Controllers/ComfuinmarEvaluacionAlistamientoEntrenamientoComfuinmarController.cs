using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Comfuinmar;
using Marina.Siesmar.Entidades.Formatos.Diali;
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

    public class ComfuinmarEvaluacionAlistamientoEntrenamientoComfuinmarController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EvaluacionAlistamientoEntrenamientoComfuinmar evaluacionAlistamientoEntrenamientoComfuinmarBL = new();
        UnidadNaval unidadNavalBL = new();
        NivelEntrenamientoDAO nivelEntrenamientoBL = new();
        CapacidadOperativa capacidadOperativaBL = new();
        EjercicioEntrenamientoAspecto ejercicioEntrenamientoAspectoBL = new();
        CalificativoAsignadoEjercicio calificativoAsignadoEjercicioBL = new();
        Carga cargaBL = new();

        public ComfuinmarEvaluacionAlistamientoEntrenamientoComfuinmarController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Evaluación del Alistamiento del entrenamiento", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<NivelEntrenamientoDTO> nivelEntrenamientoDTO = nivelEntrenamientoBL.ObtenerNivelEntrenamientos();
            List<CapacidadOperativaDTO> capacidadOperativaDTO = capacidadOperativaBL.ObtenerCapacidadOperativas();
            List<EjercicioEntrenamientoAspectoDTO> ejercicioEntrenamientoAspectoDTO = ejercicioEntrenamientoAspectoBL.ObtenerEjercicioEntrenamientoAspectos();
            List<CalificativoAsignadoEjercicioDTO> calificativoAsignadoEjercicioDTO = calificativoAsignadoEjercicioBL.ObtenerCalificativoAsignadoEjercicios();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EvaluacionAlistamientoEntrenamientoComfuinmar");
            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = nivelEntrenamientoDTO,
                data3 = capacidadOperativaDTO,
                data4 = ejercicioEntrenamientoAspectoDTO,
                data5 = calificativoAsignadoEjercicioDTO,
                data6 = listaCargas,
            });
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionAlistamientoEntrenamientoComfuinmarDTO> select = evaluacionAlistamientoEntrenamientoComfuinmarBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        ////[AuthorizePermission(Formato: 157, Permiso: 1)]//Registrar
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoNivelEntrenamiento, 
            string CodigoCapacidadOperativa, string TipoCapacidadOperativa, string CodigoEjercicioEntrenamientoAspecto, 
            string CodigoCalificativoAsignadoEjercicio, string FechaPeriodoEvaluar, string FechaRealizacionEjercicio, 
            int TiempoVigencia, int CargaId, string Fecha)
        {
            EvaluacionAlistamientoEntrenamientoComfuinmarDTO evaluacionAlistamientoEntrenamientoComfuinmarDTO = new();
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.CodigoNivelEntrenamiento = CodigoNivelEntrenamiento;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.TipoCapacidadOperativa = TipoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.CodigoEjercicioEntrenamientoAspecto = CodigoEjercicioEntrenamientoAspecto;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.CodigoCalificativoAsignadoEjercicio = CodigoCalificativoAsignadoEjercicio;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.TiempoVigencia = TiempoVigencia;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.CargaId = CargaId;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComfuinmarBL.AgregarRegistro(evaluacionAlistamientoEntrenamientoComfuinmarDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistamientoEntrenamientoComfuinmarBL.EditarFormato(Id));
        }

        //////[AuthorizePermission(Formato: 157, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoNivelEntrenamiento,
            string CodigoCapacidadOperativa, string TipoCapacidadOperativa, string CodigoEjercicioEntrenamientoAspecto,
            string CodigoCalificativoAsignadoEjercicio, string FechaPeriodoEvaluar, string FechaRealizacionEjercicio,
            int TiempoVigencia)
        {
            EvaluacionAlistamientoEntrenamientoComfuinmarDTO evaluacionAlistamientoEntrenamientoComfuinmarDTO = new();
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.EvaluacionAlistamientoEntrenamientoId = Id;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.CodigoNivelEntrenamiento = CodigoNivelEntrenamiento;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.TipoCapacidadOperativa = TipoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.CodigoEjercicioEntrenamientoAspecto = CodigoEjercicioEntrenamientoAspecto;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.CodigoCalificativoAsignadoEjercicio = CodigoCalificativoAsignadoEjercicio;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.TiempoVigencia = TiempoVigencia;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComfuinmarBL.ActualizarFormato(evaluacionAlistamientoEntrenamientoComfuinmarDTO);

            return Content(IND_OPERACION);
        }

        ////[AuthorizePermission(Formato: 157, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoEntrenamientoComfuinmarDTO evaluacionAlistamientoEntrenamientoComfuinmarDTO = new();
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.EvaluacionAlistamientoEntrenamientoId = Id;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionAlistamientoEntrenamientoComfuinmarBL.EliminarFormato(evaluacionAlistamientoEntrenamientoComfuinmarDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        ////[AuthorizePermission(Formato: 157, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoEntrenamientoComfuinmarDTO evaluacionAlistamientoEntrenamientoComfuinmarDTO = new();
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.CargaId = Id;
            evaluacionAlistamientoEntrenamientoComfuinmarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (evaluacionAlistamientoEntrenamientoComfuinmarBL.EliminarCarga(evaluacionAlistamientoEntrenamientoComfuinmarDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionAlistamientoEntrenamientoComfuinmarDTO> lista = new List<EvaluacionAlistamientoEntrenamientoComfuinmarDTO>();
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

                    lista.Add(new EvaluacionAlistamientoEntrenamientoComfuinmarDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoNivelEntrenamiento = fila.GetCell(1).ToString(),
                        CodigoCapacidadOperativa = fila.GetCell(2).ToString(),
                        TipoCapacidadOperativa = fila.GetCell(3).ToString(),
                        CodigoEjercicioEntrenamientoAspecto = fila.GetCell(4).ToString(),
                        CodigoCalificativoAsignadoEjercicio = fila.GetCell(5).ToString(),
                        FechaPeriodoEvaluar = fila.GetCell(6).ToString(),
                        FechaRealizacionEjercicio = fila.GetCell(7).ToString(),
                        TiempoVigencia = int.Parse(fila.GetCell(8).ToString())
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

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoNivelEntrenamiento", typeof(string)),
                    new DataColumn("CodigoCapacidadOperativa", typeof(string)),
                    new DataColumn("TipoCapacidadOperativa", typeof(string)),
                    new DataColumn("CodigoEjercicioEntrenamientoAspecto", typeof(string)),
                    new DataColumn("CodigoCalificativoAsignadoEjercicio", typeof(string)),
                    new DataColumn("FechaPeriodoEvaluar", typeof(string)),
                    new DataColumn("FechaRealizacionEjercicio", typeof(string)),
                    new DataColumn("TiempoVigencia", typeof(int)),
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
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(7).ToString()),
                    int.Parse(fila.GetCell(8).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComfuinmarBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfuinmarEvaluacionAlistamientoEntrenamiento.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfuinmarEvaluacionAlistamientoEntrenamiento.xlsx");
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

