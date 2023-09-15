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
    public class ActividadIlicitaController : Controller
    {
        readonly ILogger<ActividadIlicitaController> _logger;

        public ActividadIlicitaController(ILogger<ActividadIlicitaController> logger)
        {
            _logger = logger;
        }

        readonly ActividadIlicitaDAO ActividadIlicitaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Actividades Ilicitas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ActividadIlicitaDTO> listaActividadIlicitas = ActividadIlicitaBL.ObtenerActividadIlicitas();
            return Json(new { data = listaActividadIlicitas });
        }

        public ActionResult InsertarActividadIlicita(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ActividadIlicitaDTO ActividadIlicitaDTO = new();
                ActividadIlicitaDTO.DescActividadIlicita = Descripcion;
                ActividadIlicitaDTO.CodigoActividadIlicita = Codigo;
                ActividadIlicitaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ActividadIlicitaBL.AgregarActividadIlicita(ActividadIlicitaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarActividadIlicita(int ActividadIlicitaId)
        {
            return Json(ActividadIlicitaBL.BuscarActividadIlicitaID(ActividadIlicitaId));
        }

        public ActionResult ActualizarActividadIlicita(int ActividadIlicitaId, string Codigo, string Descripcion)
        {
            ActividadIlicitaDTO ActividadIlicitaDTO = new();
            ActividadIlicitaDTO.ActividadIlicitaId = ActividadIlicitaId;
            ActividadIlicitaDTO.DescActividadIlicita = Descripcion;
            ActividadIlicitaDTO.CodigoActividadIlicita = Codigo;
            ActividadIlicitaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ActividadIlicitaBL.ActualizarActividadIlicita(ActividadIlicitaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarActividadIlicita(int ActividadIlicitaId)
        {
            ActividadIlicitaDTO ActividadIlicitaDTO = new();
            ActividadIlicitaDTO.ActividadIlicitaId = ActividadIlicitaId;
            ActividadIlicitaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ActividadIlicitaBL.EliminarActividadIlicita(ActividadIlicitaDTO);

            return Content(IND_OPERACION);
        }
    }
}
