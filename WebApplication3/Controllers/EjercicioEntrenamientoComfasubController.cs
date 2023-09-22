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

        readonly EjercicioEntrenamientoComfasub EjercicioEntrenamientoComfasubBL = new();
        CapacidadOperativa CapacidadOperativaBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Ejercicios Entrenamientos Comfasub", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult cargaCombs()
        {
            List<CapacidadOperativaDTO> capacidadOperativaDTO = CapacidadOperativaBL.ObtenerCapacidadOperativas();
            return Json(new { data = capacidadOperativaDTO });
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
                EjercicioEntrenamientoComfasubDTO ejercicioEntrenamientoComfasubDTO = new();
                ejercicioEntrenamientoComfasubDTO.CodigoEjercicioEntrenamiento = CodigoEjercicioEntrenamiento;
                ejercicioEntrenamientoComfasubDTO.DescEjercicioEntrenamiento = DescEjercicioEntrenamiento;
                ejercicioEntrenamientoComfasubDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
                ejercicioEntrenamientoComfasubDTO.NivelEjercicio = NivelEjercicio;
                ejercicioEntrenamientoComfasubDTO.VigenciaDiasClaseIslay = VigenciaIslay;
                ejercicioEntrenamientoComfasubDTO.VigenciaDiasClaseAngamos = VigenciaAngamos;
                ejercicioEntrenamientoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = EjercicioEntrenamientoComfasubBL.AgregarEjercicioEntrenamientoComfasub(ejercicioEntrenamientoComfasubDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEjercicioEntrenamientoComfasub(int Id)
        {
            return Json(EjercicioEntrenamientoComfasubBL.BuscarEjercicioEntrenamientoComfasubID(Id));
        }

        public ActionResult ActualizarEjercicioEntrenamientoComfasub(int Id, string DescEjercicioEntrenamiento, string CodigoEjercicioEntrenamiento, string CodigoCapacidadOperativa, string NivelEjercicio, int VigenciaIslay, int VigenciaAngamos)
        {
            EjercicioEntrenamientoComfasubDTO ejercicioEntrenamientoComfasubDTO = new();
            ejercicioEntrenamientoComfasubDTO.EjercicioEntrenamientoComfasubId = Id;
            ejercicioEntrenamientoComfasubDTO.CodigoEjercicioEntrenamiento = CodigoEjercicioEntrenamiento;
            ejercicioEntrenamientoComfasubDTO.DescEjercicioEntrenamiento = DescEjercicioEntrenamiento;
            ejercicioEntrenamientoComfasubDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            ejercicioEntrenamientoComfasubDTO.NivelEjercicio = NivelEjercicio;
            ejercicioEntrenamientoComfasubDTO.VigenciaDiasClaseIslay = VigenciaIslay;
            ejercicioEntrenamientoComfasubDTO.VigenciaDiasClaseAngamos = VigenciaAngamos;
            ejercicioEntrenamientoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = EjercicioEntrenamientoComfasubBL.ActualizarEjercicioEntrenamientoComfasub(ejercicioEntrenamientoComfasubDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEjercicioEntrenamientoComfasub(int Id)
        {
            EjercicioEntrenamientoComfasubDTO ejercicioEntrenamientoComfasubDTO = new();
            ejercicioEntrenamientoComfasubDTO.EjercicioEntrenamientoComfasubId = Id;
            ejercicioEntrenamientoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = EjercicioEntrenamientoComfasubBL.EliminarEjercicioEntrenamientoComfasub(ejercicioEntrenamientoComfasubDTO);

            return Content(IND_OPERACION);
        }
    }
}
