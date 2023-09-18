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
    public class ActividadIlicitaInterventorController : Controller
    {
        readonly ILogger<ActividadIlicitaInterventorController> _logger;

        public ActividadIlicitaInterventorController(ILogger<ActividadIlicitaInterventorController> logger)
        {
            _logger = logger;
        }

        readonly ActividadIlicitaInterventor actividadIlicitaInterventorBL = new();
        Usuario usuarioBL = new();

        ActividadIlicita actividadIlicitaBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Actividades Ilícitas Interventores", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<ActividadIlicitaDTO> actividadIlicitaDTO = actividadIlicitaBL.ObtenerActividadIlicitas();

            return Json(new { data = actividadIlicitaDTO });
        }

        public JsonResult CargarDatos()
        {
            List<ActividadIlicitaInterventorDTO> listaActividadIlicitaInterventores = actividadIlicitaInterventorBL.ObtenerActividadIlicitaInterventors();
            return Json(new { data = listaActividadIlicitaInterventores });
        }

        public ActionResult InsertarActividadIlicitaInterventor(int Codigo, int ActividadIlicitaId)
        {
            var IND_OPERACION = "";
            try
            {
                ActividadIlicitaInterventorDTO actividadIlicitaInterventorDTO = new();
                actividadIlicitaInterventorDTO.CodUnidad = Codigo;
                actividadIlicitaInterventorDTO.ActividadIlicitaId = ActividadIlicitaId;
                actividadIlicitaInterventorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = actividadIlicitaInterventorBL.AgregarActividadIlicitaInterventor(actividadIlicitaInterventorDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarActividadIlicitaInterventor(int ActividadIlicitaInterventorId)
        {
            return Json(actividadIlicitaInterventorBL.BuscarActividadIlicitaInterventorID(ActividadIlicitaInterventorId));
        }

        public ActionResult ActualizarActividadIlicitaInterventor(int ActividadIlicitaInterventorId, int Codigo, int ActividadIlicitaId)
        {
            ActividadIlicitaInterventorDTO actividadIlicitaInterventorDTO = new();
            actividadIlicitaInterventorDTO.ActividadIlicitaInterventorId = ActividadIlicitaInterventorId;
            actividadIlicitaInterventorDTO.CodUnidad = Codigo;
            actividadIlicitaInterventorDTO.ActividadIlicitaId = ActividadIlicitaId;
            actividadIlicitaInterventorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actividadIlicitaInterventorBL.ActualizarActividadIlicitaInterventor(actividadIlicitaInterventorDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarActividadIlicitaInterventor(int ActividadIlicitaInterventorId)
        {
            ActividadIlicitaInterventorDTO actividadIlicitaInterventorDTO = new();
            actividadIlicitaInterventorDTO.ActividadIlicitaInterventorId = ActividadIlicitaInterventorId;
            actividadIlicitaInterventorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actividadIlicitaInterventorBL.EliminarActividadIlicitaInterventor(actividadIlicitaInterventorDTO);

            return Content(IND_OPERACION);
        }
    }
}
