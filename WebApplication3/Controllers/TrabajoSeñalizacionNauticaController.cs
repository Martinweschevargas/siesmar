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
    public class TrabajoSeñalizacionNauticaController : Controller
    {
        readonly ILogger<TrabajoSeñalizacionNauticaController> _logger;

        public TrabajoSeñalizacionNauticaController(ILogger<TrabajoSeñalizacionNauticaController> logger)
        {
            _logger = logger;
        }

        readonly TrabajoSeñalizacionNauticaDAO trabajoSeñalizacionNauticaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Trabajos Señalizaciones Náuticas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TrabajoSeñalizacionNauticaDTO> listaTrabajoSeñalizacionNauticas = trabajoSeñalizacionNauticaBL.ObtenerTrabajoSeñalizacionNauticas();
            return Json(new { data = listaTrabajoSeñalizacionNauticas });
        }

        public ActionResult InsertarTrabajoSeñalizacionNautica(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TrabajoSeñalizacionNauticaDTO trabajoSeñalizacionNauticaDTO = new();
                trabajoSeñalizacionNauticaDTO.DescTrabajoSeñalizacionNautica = Descripcion;
                trabajoSeñalizacionNauticaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = trabajoSeñalizacionNauticaBL.AgregarTrabajoSeñalizacionNautica(trabajoSeñalizacionNauticaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTrabajoSeñalizacionNautica(int TrabajoSeñalizacionNauticaId)
        {
            return Json(trabajoSeñalizacionNauticaBL.BuscarTrabajoSeñalizacionNauticaID(TrabajoSeñalizacionNauticaId));
        }

        public ActionResult ActualizarTrabajoSeñalizacionNautica(int TrabajoSeñalizacionNauticaId, string Descripcion)
        {
            TrabajoSeñalizacionNauticaDTO trabajoSeñalizacionNauticaDTO = new();
            trabajoSeñalizacionNauticaDTO.TrabajoSeñalizacionNauticaId = TrabajoSeñalizacionNauticaId;
            trabajoSeñalizacionNauticaDTO.DescTrabajoSeñalizacionNautica = Descripcion;
            trabajoSeñalizacionNauticaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = trabajoSeñalizacionNauticaBL.ActualizarTrabajoSeñalizacionNautica(trabajoSeñalizacionNauticaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTrabajoSeñalizacionNautica(int TrabajoSeñalizacionNauticaId)
        {
            TrabajoSeñalizacionNauticaDTO trabajoSeñalizacionNauticaDTO = new();
            trabajoSeñalizacionNauticaDTO.TrabajoSeñalizacionNauticaId = TrabajoSeñalizacionNauticaId;
            trabajoSeñalizacionNauticaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = trabajoSeñalizacionNauticaBL.EliminarTrabajoSeñalizacionNautica(trabajoSeñalizacionNauticaDTO);

            return Content(IND_OPERACION);
        }
    }
}
