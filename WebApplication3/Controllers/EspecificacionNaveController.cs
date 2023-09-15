using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class EspecificacionNaveController : Controller
    {
        readonly ILogger<EspecificacionNaveController> _logger;

        public EspecificacionNaveController(ILogger<EspecificacionNaveController> logger)
        {
            _logger = logger;
        }

        readonly EspecificacionNave especificacionNaveBL = new();
        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]

        [Breadcrumb(FromAction = "Index", Title = "Especificaciones Naves", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EspecificacionNaveDTO> listaEspecificacionNaves = especificacionNaveBL.ObtenerEspecificacionNaves();
            return Json(new { data = listaEspecificacionNaves });
        }

        public ActionResult InsertarEspecificacionNave(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                EspecificacionNaveDTO especificacionNaveDTO = new();
                especificacionNaveDTO.DescEspecificacionNave = Descripcion;
                especificacionNaveDTO.CodigoEspecificacionNave = Codigo;
                especificacionNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = especificacionNaveBL.AgregarEspecificacionNave(especificacionNaveDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEspecificacionNave(int EspecificacionNaveId)
        {
            return Json(especificacionNaveBL.BuscarEspecificacionNaveID(EspecificacionNaveId));
        }

        public ActionResult ActualizarEspecificacionNave(int EspecificacionNaveId, string Codigo, string Descripcion)
        {
            EspecificacionNaveDTO especificacionNaveDTO = new();
            especificacionNaveDTO.EspecificacionNaveId = EspecificacionNaveId;
            especificacionNaveDTO.DescEspecificacionNave = Descripcion;
            especificacionNaveDTO.CodigoEspecificacionNave = Codigo;
            especificacionNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = especificacionNaveBL.ActualizarEspecificacionNave(especificacionNaveDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEspecificacionNave(int EspecificacionNaveId)
        {
            EspecificacionNaveDTO especificacionNaveDTO = new();
            especificacionNaveDTO.EspecificacionNaveId = EspecificacionNaveId;
            especificacionNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = especificacionNaveBL.EliminarEspecificacionNave(especificacionNaveDTO);

            return Content(IND_OPERACION);
        }
    }
}
