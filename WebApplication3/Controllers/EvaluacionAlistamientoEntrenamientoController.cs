using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class EvaluacionAlistamientoEntrenamientoController : Controller
    {
        readonly ILogger<EvaluacionAlistamientoEntrenamientoController> _logger;

        public EvaluacionAlistamientoEntrenamientoController(ILogger<EvaluacionAlistamientoEntrenamientoController> logger)
        {
            _logger = logger;
        }

        readonly EvaluacionAlistamientoEntrenamiento evaluacionAlistamientoEntrenamientoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Evaluaciones Alistamientos Entrenamientos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EvaluacionAlistamientoEntrenamientoDTO> listaEvaluacionAlistamientoEntrenamientos = evaluacionAlistamientoEntrenamientoBL.ObtenerEvaluacionAlistamientoEntrenamientos();
            return Json(new { data = listaEvaluacionAlistamientoEntrenamientos });
        }

        public ActionResult InsertarEvaluacionAlistamientoEntrenamiento(string Nivel, int CodigoCapacidad, string TipoCapacidad, string CodigoEjercicio, string Calificativo,
                                                                        string FechaPeriodo, string FechaRealizacion, string Tiempo)
        {
            var IND_OPERACION = "";
            try
            {
                EvaluacionAlistamientoEntrenamientoDTO evaluacionAlistamientoEntrenamientoDTO = new();
                evaluacionAlistamientoEntrenamientoDTO.NivelEntrenamiento = Nivel;
                evaluacionAlistamientoEntrenamientoDTO.CodigoCapacidadOperativa = CodigoCapacidad;
                evaluacionAlistamientoEntrenamientoDTO.TipoCapacidadOperativa = TipoCapacidad;
                evaluacionAlistamientoEntrenamientoDTO.CodigoEjercicio = CodigoEjercicio;
                evaluacionAlistamientoEntrenamientoDTO.Calificativo = Calificativo;
                evaluacionAlistamientoEntrenamientoDTO.FechaPeriodoEvaluacionEjercicio = FechaPeriodo;
                evaluacionAlistamientoEntrenamientoDTO.FechaRealizacionEjercicio = FechaRealizacion;
                evaluacionAlistamientoEntrenamientoDTO.TiempoVigencia = Tiempo;
                evaluacionAlistamientoEntrenamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = evaluacionAlistamientoEntrenamientoBL.AgregarEvaluacionAlistamientoEntrenamiento(evaluacionAlistamientoEntrenamientoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEvaluacionAlistamientoEntrenamiento(int EvaluacionAlistamientoEntrenamientoId)
        {
            return Json(evaluacionAlistamientoEntrenamientoBL.BuscarEvaluacionAlistamientoEntrenamientoID(EvaluacionAlistamientoEntrenamientoId));
        }

        public ActionResult ActualizarEvaluacionAlistamientoEntrenamiento(int EvaluacionAlistamientoEntrenamientoId, string Nivel, int CodigoCapacidad, string TipoCapacidad, string CodigoEjercicio, string Calificativo,
                                                                        string FechaPeriodo, string FechaRealizacion, string Tiempo)
        {
            EvaluacionAlistamientoEntrenamientoDTO evaluacionAlistamientoEntrenamientoDTO = new();
            evaluacionAlistamientoEntrenamientoDTO.EvaluacionAlistamientoEntrenamientoId = EvaluacionAlistamientoEntrenamientoId;
            evaluacionAlistamientoEntrenamientoDTO.NivelEntrenamiento = Nivel;
            evaluacionAlistamientoEntrenamientoDTO.CodigoCapacidadOperativa = CodigoCapacidad;
            evaluacionAlistamientoEntrenamientoDTO.TipoCapacidadOperativa = TipoCapacidad;
            evaluacionAlistamientoEntrenamientoDTO.CodigoEjercicio = CodigoEjercicio;
            evaluacionAlistamientoEntrenamientoDTO.Calificativo = Calificativo;
            evaluacionAlistamientoEntrenamientoDTO.FechaPeriodoEvaluacionEjercicio = FechaPeriodo;
            evaluacionAlistamientoEntrenamientoDTO.FechaRealizacionEjercicio = FechaRealizacion;
            evaluacionAlistamientoEntrenamientoDTO.TiempoVigencia = Tiempo;
            evaluacionAlistamientoEntrenamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoEntrenamientoBL.ActualizarEvaluacionAlistamientoEntrenamiento(evaluacionAlistamientoEntrenamientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEvaluacionAlistamientoEntrenamiento(int EvaluacionAlistamientoEntrenamientoId)
        {
            EvaluacionAlistamientoEntrenamientoDTO evaluacionAlistamientoEntrenamientoDTO = new();
            evaluacionAlistamientoEntrenamientoDTO.EvaluacionAlistamientoEntrenamientoId = EvaluacionAlistamientoEntrenamientoId;
            evaluacionAlistamientoEntrenamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoEntrenamientoBL.EliminarEvaluacionAlistamientoEntrenamiento(evaluacionAlistamientoEntrenamientoDTO);

            return Content(IND_OPERACION);
        }
    }
}
