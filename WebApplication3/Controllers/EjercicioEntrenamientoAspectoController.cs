using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class EjercicioEntrenamientoAspectoController : Controller
    {
        readonly ILogger<EjercicioEntrenamientoAspectoController> _logger;

        public EjercicioEntrenamientoAspectoController(ILogger<EjercicioEntrenamientoAspectoController> logger)
        {
            _logger = logger;
        }

        readonly EjercicioEntrenamientoAspecto ejercicioEntrenamientoAspectoBL = new();
        Usuario usuarioBL = new();

        EjercicioEntrenamiento ejercicioEntrenamientoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "EjercicioEntrenamientoAspectos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<EjercicioEntrenamientoDTO> ejercicioEntrenamientoDTO = ejercicioEntrenamientoBL.ObtenerEjercicioEntrenamientos();

            return Json(new { data = ejercicioEntrenamientoDTO });
        }

        public JsonResult CargarDatos()
        {
            List<EjercicioEntrenamientoAspectoDTO> listaEjercicioEntrenamientoAspectoes = ejercicioEntrenamientoAspectoBL.ObtenerEjercicioEntrenamientoAspectos();
            return Json(new { data = listaEjercicioEntrenamientoAspectoes });
        }

        public ActionResult InsertarEjercicioEntrenamientoAspecto(string AspectoEvaluacion, string Peso, string CodigoEjercicioEntrenamientoAspecto, string CodigoEjercicioEntrenamiento)
        {
            var IND_OPERACION = "";
            try
            {
                EjercicioEntrenamientoAspectoDTO ejercicioEntrenamientoAspectoDTO = new();
                ejercicioEntrenamientoAspectoDTO.AspectoEvaluacion = AspectoEvaluacion;
                ejercicioEntrenamientoAspectoDTO.Peso = Peso;
                ejercicioEntrenamientoAspectoDTO.CodigoEjercicioEntrenamientoAspecto = CodigoEjercicioEntrenamientoAspecto;
                ejercicioEntrenamientoAspectoDTO.CodigoEjercicioEntrenamiento = CodigoEjercicioEntrenamiento;
                ejercicioEntrenamientoAspectoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ejercicioEntrenamientoAspectoBL.AgregarEjercicioEntrenamientoAspecto(ejercicioEntrenamientoAspectoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEjercicioEntrenamientoAspecto(int EjercicioEntrenamientoAspectoId)
        {
            return Json(ejercicioEntrenamientoAspectoBL.BuscarEjercicioEntrenamientoAspectoID(EjercicioEntrenamientoAspectoId));
        }

        public ActionResult ActualizarEjercicioEntrenamientoAspecto(int EjercicioEntrenamientoAspectoId, string AspectoEvaluacion, string Peso, string CodigoEjercicioEntrenamientoAspecto, string CodigoEjercicioEntrenamiento)
        {
            EjercicioEntrenamientoAspectoDTO ejercicioEntrenamientoAspectoDTO = new();
            ejercicioEntrenamientoAspectoDTO.EjercicioEntrenamientoAspectoId = EjercicioEntrenamientoAspectoId;
            ejercicioEntrenamientoAspectoDTO.AspectoEvaluacion = AspectoEvaluacion;
            ejercicioEntrenamientoAspectoDTO.Peso = Peso;
            ejercicioEntrenamientoAspectoDTO.CodigoEjercicioEntrenamientoAspecto = CodigoEjercicioEntrenamientoAspecto;
            ejercicioEntrenamientoAspectoDTO.CodigoEjercicioEntrenamiento = CodigoEjercicioEntrenamiento;
            ejercicioEntrenamientoAspectoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ejercicioEntrenamientoAspectoBL.ActualizarEjercicioEntrenamientoAspecto(ejercicioEntrenamientoAspectoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEjercicioEntrenamientoAspecto(int EjercicioEntrenamientoAspectoId)
        {
            EjercicioEntrenamientoAspectoDTO ejercicioEntrenamientoAspectoDTO = new();
            ejercicioEntrenamientoAspectoDTO.EjercicioEntrenamientoAspectoId = EjercicioEntrenamientoAspectoId;
            ejercicioEntrenamientoAspectoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ejercicioEntrenamientoAspectoBL.EliminarEjercicioEntrenamientoAspecto(ejercicioEntrenamientoAspectoDTO);

            return Content(IND_OPERACION);
        }
    }
}
