using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comestre;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Formatos.Comestre;
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
    public class ComestreEvaluacionAlistamientoEntrenamientoComestreController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        EvaluacionAlistamientoEntrenamientoComestre evaluacionAlistamientoEntrenamientoComestreBL = new();

        UnidadNaval unidadNavalBL = new ();
        CapacidadOperativa capacidadOperativaBL = new();
        EjercicioEntrenamiento ejercicioEntrenamientoBL = new();
        EjercicioEntrenamientoAspecto ejercicioEntrenamientoAspectoBL = new();
        CalificativoAsignadoEjercicio calificativoAsignadoEjercicioBL = new();

        public ComestreEvaluacionAlistamientoEntrenamientoComestreController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Evaluacion de Alistamiento del Entrenamiento", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<CapacidadOperativaDTO> capacidadOperativaDTO = capacidadOperativaBL.ObtenerCapacidadOperativas();
            List<EjercicioEntrenamientoDTO> ejercicioEntrenamientoDTO = ejercicioEntrenamientoBL.ObtenerEjercicioEntrenamientos();
            List<EjercicioEntrenamientoAspectoDTO> ejercicioEntrenamientoAspectoDTO = ejercicioEntrenamientoAspectoBL.ObtenerEjercicioEntrenamientoAspectos();
            List<CalificativoAsignadoEjercicioDTO> calificativoAsignadoEjercicioDTO = calificativoAsignadoEjercicioBL.ObtenerCalificativoAsignadoEjercicios();

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = capacidadOperativaDTO,
                data3 = ejercicioEntrenamientoDTO,
                data4 = ejercicioEntrenamientoAspectoDTO,
                data5 = calificativoAsignadoEjercicioDTO,
            });
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionAlistamientoEntrenamientoComestreDTO> evaluacionAlistamientoEntrenamientoComestreDTO = evaluacionAlistamientoEntrenamientoComestreBL.ObtenerLista();
            return Json(new { data = evaluacionAlistamientoEntrenamientoComestreDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int UnidadNavalId, string NivelEntrenamiento, int CapacidadOperativaId,
            string TipoCapacidadOperativo, int CodigoEjercicioEntrenamiento, int EjercicioEntrenamientoId, int EjercicioEntrenamientoAspectoId, 
            int PesoEjercicioEntrenamiento, int CalificativoAsignadoEjercicioId, int PuntajeObtenido, string FechaPeriodoEvaluar,
            int TiempoVigencia, string FechaRealizacionEjercicio, string FechaCaducidadEjercicio)
        {
            EvaluacionAlistamientoEntrenamientoComestreDTO evaluacionAlistamientoEntrenamientoComestreDTO = new();
            evaluacionAlistamientoEntrenamientoComestreDTO.UnidadNavalId = UnidadNavalId;
            evaluacionAlistamientoEntrenamientoComestreDTO.NivelEntrenamiento = NivelEntrenamiento;
            evaluacionAlistamientoEntrenamientoComestreDTO.CapacidadOperativaId = CapacidadOperativaId;
            evaluacionAlistamientoEntrenamientoComestreDTO.TipoCapacidadOperativo = TipoCapacidadOperativo;
            evaluacionAlistamientoEntrenamientoComestreDTO.CodigoEjercicioEntrenamiento = CodigoEjercicioEntrenamiento;
            evaluacionAlistamientoEntrenamientoComestreDTO.EjercicioEntrenamientoId = EjercicioEntrenamientoId;
            evaluacionAlistamientoEntrenamientoComestreDTO.EjercicioEntrenamientoAspectoId = EjercicioEntrenamientoAspectoId;
            evaluacionAlistamientoEntrenamientoComestreDTO.PesoEjercicioEntrenamiento = PesoEjercicioEntrenamiento;
            evaluacionAlistamientoEntrenamientoComestreDTO.CalificativoAsignadoEjercicioId = CalificativoAsignadoEjercicioId;
            evaluacionAlistamientoEntrenamientoComestreDTO.PuntajeObtenido = PuntajeObtenido;
            evaluacionAlistamientoEntrenamientoComestreDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistamientoEntrenamientoComestreDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistamientoEntrenamientoComestreDTO.TiempoVigencia = TiempoVigencia;
            evaluacionAlistamientoEntrenamientoComestreDTO.FechaCaducidadEjercicio = FechaCaducidadEjercicio;
            evaluacionAlistamientoEntrenamientoComestreDTO.Año = DateTime.Now.Year; ;
            evaluacionAlistamientoEntrenamientoComestreDTO.Mes = DateTime.Now.Month;
            evaluacionAlistamientoEntrenamientoComestreDTO.Dia = DateTime.Now.Day;
            evaluacionAlistamientoEntrenamientoComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComestreBL.AgregarRegistro(evaluacionAlistamientoEntrenamientoComestreDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistamientoEntrenamientoComestreBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int EvaluacionAlistamientoEntrenamientoComestreId, int UnidadNavalId, string NivelEntrenamiento, int CapacidadOperativaId,
            string TipoCapacidadOperativo, int CodigoEjercicioEntrenamiento, int EjercicioEntrenamientoId, int EjercicioEntrenamientoAspectoId,
            int PesoEjercicioEntrenamiento, int CalificativoAsignadoEjercicioId, int PuntajeObtenido, string FechaPeriodoEvaluar,
            int TiempoVigencia, string FechaRealizacionEjercicio, string FechaCaducidadEjercicio)
        {
            EvaluacionAlistamientoEntrenamientoComestreDTO evaluacionAlistamientoEntrenamientoComestreDTO = new();
            evaluacionAlistamientoEntrenamientoComestreDTO.EvaluacionAlistamientoEntrenamientoComestreId = EvaluacionAlistamientoEntrenamientoComestreId;
            evaluacionAlistamientoEntrenamientoComestreDTO.UnidadNavalId = UnidadNavalId;
            evaluacionAlistamientoEntrenamientoComestreDTO.NivelEntrenamiento = NivelEntrenamiento;
            evaluacionAlistamientoEntrenamientoComestreDTO.CapacidadOperativaId = CapacidadOperativaId;
            evaluacionAlistamientoEntrenamientoComestreDTO.TipoCapacidadOperativo = TipoCapacidadOperativo;
            evaluacionAlistamientoEntrenamientoComestreDTO.CodigoEjercicioEntrenamiento = CodigoEjercicioEntrenamiento;
            evaluacionAlistamientoEntrenamientoComestreDTO.EjercicioEntrenamientoId = EjercicioEntrenamientoId;
            evaluacionAlistamientoEntrenamientoComestreDTO.EjercicioEntrenamientoAspectoId = EjercicioEntrenamientoAspectoId;
            evaluacionAlistamientoEntrenamientoComestreDTO.PesoEjercicioEntrenamiento = PesoEjercicioEntrenamiento;
            evaluacionAlistamientoEntrenamientoComestreDTO.CalificativoAsignadoEjercicioId = CalificativoAsignadoEjercicioId;
            evaluacionAlistamientoEntrenamientoComestreDTO.PuntajeObtenido = PuntajeObtenido;
            evaluacionAlistamientoEntrenamientoComestreDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistamientoEntrenamientoComestreDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistamientoEntrenamientoComestreDTO.TiempoVigencia = TiempoVigencia;
            evaluacionAlistamientoEntrenamientoComestreDTO.FechaCaducidadEjercicio = FechaCaducidadEjercicio;
            evaluacionAlistamientoEntrenamientoComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComestreBL.ActualizarFormato(evaluacionAlistamientoEntrenamientoComestreDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoEntrenamientoComestreDTO evaluacionAlistamientoEntrenamientoComestreDTO = new();
            evaluacionAlistamientoEntrenamientoComestreDTO.EvaluacionAlistamientoEntrenamientoComestreId = Id;
            evaluacionAlistamientoEntrenamientoComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionAlistamientoEntrenamientoComestreBL.EliminarFormato(evaluacionAlistamientoEntrenamientoComestreDTO) == true)
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

            List<EvaluacionAlistamientoEntrenamientoComestreDTO> lista = new List<EvaluacionAlistamientoEntrenamientoComestreDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new EvaluacionAlistamientoEntrenamientoComestreDTO
                {/*
                    NombreActividadCultural = fila.GetCell(0).ToString(),
                    TipoActividadCulturalId = fila.GetCell(1).ToString(),
                    FechaInicioActCultural = fila.GetCell(2).ToString(),
                    FechaTerminoActCultural = fila.GetCell(3).ToString(),
                    LugarActCultural = fila.GetCell(4).ToString(),
                    AuspiciadoresActCultural = fila.GetCell(5).ToString(),
                    NParticipantesActCultural = fila.GetCell(4).ToString(),
                    InversionActCultural = fila.GetCell(5).ToString()*/
                });
            }
            return StatusCode(StatusCodes.Status200OK, lista);
        }


        [HttpPost]
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
        {
            Stream stream = ArchivoExcel.OpenReadStream();
            var mensaje="";

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
            List<EvaluacionAlistamientoEntrenamientoComestreDTO> lista = new List<EvaluacionAlistamientoEntrenamientoComestreDTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new EvaluacionAlistamientoEntrenamientoComestreDTO
                {/*
                    NombreActividadCultural = fila.GetCell(0).ToString(),
                    TipoActividadCulturalId = fila.GetCell(1).ToString(),
                    FechaInicioActCultural = fila.GetCell(2).ToString(),
                    FechaTerminoActCultural = fila.GetCell(3).ToString(),
                    LugarActCultural = fila.GetCell(4).ToString(),
                    AuspiciadoresActCultural = fila.GetCell(5).ToString(),
                    NParticipantesActCultural = fila.GetCell(4).ToString(),
                    InversionActCultural = fila.GetCell(5).ToString(),
                    UsuarioIngresoRegistro = User.obtenerUsuario(),*/
                });
            }
            try
            {
                var estado = evaluacionAlistamientoEntrenamientoComestreBL.InsercionMasiva(lista);
                if (estado==true)
                {
                    mensaje = "ok";
                }
                else
                {
                    mensaje = "error";
                }
                 
            }
            catch(Exception e)
            {
                mensaje = e.Message;
            }
            return StatusCode(StatusCodes.Status200OK, new { mensaje });
        }

        public IActionResult Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            LocalReport localReport = new LocalReport(path);
            var result=localReport.Execute(RenderType.Pdf,extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        public IActionResult Print2()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report2.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            var Capitanias = evaluacionAlistamientoEntrenamientoComestreBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirintemarActividadCultural.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirintemarActividadCultural.xlsx");
        }
    }

}