using Marina.Siesmar.AccesoDatos.Mantenimiento;
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
    public class EjercicioEntrenamientoComfasubController : Controller
    {
        readonly ILogger<EjercicioEntrenamientoComfasubController> _logger;

        public EjercicioEntrenamientoComfasubController(ILogger<EjercicioEntrenamientoComfasubController> logger)
        {
            _logger = logger;
        }

        readonly EjercicioEntrenamientoComfasubDAO EjercicioEntrenamientoComfasubBL = new();
        CapacidadOperativaDAO CapacidadOperativaBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Ejercicios Entrenamientos Comfasub", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult cargaCombs()
        {
            List<CapacidadOperativaDTO> CapacidadOperativaDTO = CapacidadOperativaBL.ObtenerCapacidadOperativas();
            return Json(new { data = CapacidadOperativaDTO });
        }

        public JsonResult CargarDatos()
        {
            List<EjercicioEntrenamientoComfasubDTO> listaEjercicioEntrenamientoComfasubes = EjercicioEntrenamientoComfasubBL.ObtenerEjercicioEntrenamientoComfasubs();
            return Json(new { data = listaEjercicioEntrenamientoComfasubes });
        }

        public ActionResult InsertarEjercicioEntrenamientoComfasub(string DescEjercicioEntrenamiento, string CodigoEjercicioEntrenamiento, string CodigoCapacidadOperativa, string NivelEjercicio, int VigenciaIslay, int VigenciaAngamos)
        {
            var IND_OPERACION = "";
            try
            {
                EjercicioEntrenamientoComfasubDTO EjercicioEntrenamientoComfasubDTO = new();
                EjercicioEntrenamientoComfasubDTO.CodigoEjercicioEntrenamiento = CodigoEjercicioEntrenamiento;
                EjercicioEntrenamientoComfasubDTO.DescEjercicioEntrenamiento = DescEjercicioEntrenamiento;
                EjercicioEntrenamientoComfasubDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
                EjercicioEntrenamientoComfasubDTO.NivelEjercicio = NivelEjercicio;
                EjercicioEntrenamientoComfasubDTO.VigenciaDiasClaseIslay = VigenciaIslay;
                EjercicioEntrenamientoComfasubDTO.VigenciaDiasClaseAngamos = VigenciaAngamos;
                EjercicioEntrenamientoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = EjercicioEntrenamientoComfasubBL.AgregarEjercicioEntrenamientoComfasub(EjercicioEntrenamientoComfasubDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEjercicioEntrenamientoComfasub(int EjercicioEntrenamientoComfasubId)
        {
            return Json(EjercicioEntrenamientoComfasubBL.BuscarEjercicioEntrenamientoComfasubID(EjercicioEntrenamientoComfasubId));
        }

        public ActionResult ActualizarEjercicioEntrenamientoComfasub(int EjercicioEntrenamientoComfasubId, string DescEjercicioEntrenamiento, string CodigoEjercicioEntrenamiento, string CodigoCapacidadOperativa, string NivelEjercicio, int VigenciaIslay, int VigenciaAngamos)
        {
            EjercicioEntrenamientoComfasubDTO EjercicioEntrenamientoComfasubDTO = new();
            EjercicioEntrenamientoComfasubDTO.EjercicioEntrenamientoComfasubId = EjercicioEntrenamientoComfasubId;
            EjercicioEntrenamientoComfasubDTO.CodigoEjercicioEntrenamiento = CodigoEjercicioEntrenamiento;
            EjercicioEntrenamientoComfasubDTO.DescEjercicioEntrenamiento = DescEjercicioEntrenamiento;
            EjercicioEntrenamientoComfasubDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            EjercicioEntrenamientoComfasubDTO.NivelEjercicio = NivelEjercicio;
            EjercicioEntrenamientoComfasubDTO.VigenciaDiasClaseIslay = VigenciaIslay;
            EjercicioEntrenamientoComfasubDTO.VigenciaDiasClaseAngamos = VigenciaAngamos;
            EjercicioEntrenamientoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = EjercicioEntrenamientoComfasubBL.ActualizarEjercicioEntrenamientoComfasub(EjercicioEntrenamientoComfasubDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEjercicioEntrenamientoComfasub(int EjercicioEntrenamientoComfasubId)
        {
            EjercicioEntrenamientoComfasubDTO EjercicioEntrenamientoComfasubDTO = new();
            EjercicioEntrenamientoComfasubDTO.EjercicioEntrenamientoComfasubId = EjercicioEntrenamientoComfasubId;
            EjercicioEntrenamientoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = EjercicioEntrenamientoComfasubBL.EliminarEjercicioEntrenamientoComfasub(EjercicioEntrenamientoComfasubDTO);

            return Content(IND_OPERACION);
        }
    }
}
