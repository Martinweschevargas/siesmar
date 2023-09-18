using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class EjercicioEntrenamientoController : Controller
    {
        readonly ILogger<EjercicioEntrenamientoController> _logger;

        public EjercicioEntrenamientoController(ILogger<EjercicioEntrenamientoController> logger)
        {
            _logger = logger;
        }

        readonly EjercicioEntrenamientoDAO ejercicioEntrenamientoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Ejercicios Entrenamientos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EjercicioEntrenamientoDTO> listaEjercicioEntrenamientos = ejercicioEntrenamientoBL.ObtenerEjercicioEntrenamientos();
            return Json(new { data = listaEjercicioEntrenamientos });
        }

        public ActionResult InsertarEjercicioEntrenamiento(string Descripcion, string Codigo)
        {
            var IND_OPERACION = "";
            try
            {
                EjercicioEntrenamientoDTO ejercicioEntrenamientoDTO = new();
                ejercicioEntrenamientoDTO.DescEjercicioEntrenamiento = Descripcion;
                ejercicioEntrenamientoDTO.CodigoEjercicioEntrenamiento = Codigo;
                ejercicioEntrenamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ejercicioEntrenamientoBL.AgregarEjercicioEntrenamiento(ejercicioEntrenamientoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEjercicioEntrenamiento(int EjercicioEntrenamientoId)
        {
            return Json(ejercicioEntrenamientoBL.BuscarEjercicioEntrenamientoID(EjercicioEntrenamientoId));
        }

        public ActionResult ActualizarEjercicioEntrenamiento(int EjercicioEntrenamientoId, string Descripcion, string Codigo)
        {
            EjercicioEntrenamientoDTO ejercicioEntrenamientoDTO = new();
            ejercicioEntrenamientoDTO.EjercicioEntrenamientoId = EjercicioEntrenamientoId;
            ejercicioEntrenamientoDTO.DescEjercicioEntrenamiento = Descripcion;
            ejercicioEntrenamientoDTO.CodigoEjercicioEntrenamiento = Codigo;
            ejercicioEntrenamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ejercicioEntrenamientoBL.ActualizarEjercicioEntrenamiento(ejercicioEntrenamientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEjercicioEntrenamiento(int EjercicioEntrenamientoId)
        {
            EjercicioEntrenamientoDTO ejercicioEntrenamientoDTO = new();
            ejercicioEntrenamientoDTO.EjercicioEntrenamientoId = EjercicioEntrenamientoId;
            ejercicioEntrenamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ejercicioEntrenamientoBL.EliminarEjercicioEntrenamiento(ejercicioEntrenamientoDTO);

            return Content(IND_OPERACION);
        }
    }
}
