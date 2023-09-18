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
    public class EntidadMilitarController : Controller
    {
        readonly ILogger<EntidadMilitarController> _logger;

        public EntidadMilitarController(ILogger<EntidadMilitarController> logger)
        {
            _logger = logger;
        }

        readonly EntidadMilitarDAO entidadMilitarBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Entidades Militares", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EntidadMilitarDTO> listaEntidadMilitars = entidadMilitarBL.ObtenerEntidadMilitars();
            return Json(new { data = listaEntidadMilitars });
        }

        public ActionResult InsertarEntidadMilitar(string DescEntidadMilitar, string CodigoEntidadMilitar)
        {
            var IND_OPERACION = "";
            try
            {
                EntidadMilitarDTO entidadMilitarDTO = new();
                entidadMilitarDTO.DescEntidadMilitar = DescEntidadMilitar;
                entidadMilitarDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
                entidadMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = entidadMilitarBL.AgregarEntidadMilitar(entidadMilitarDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEntidadMilitar(int EntidadMilitarId)
        {
            return Json(entidadMilitarBL.BuscarEntidadMilitarID(EntidadMilitarId));
        }

        public ActionResult ActualizarEntidadMilitar(int EntidadMilitarId, string DescEntidadMilitar, string CodigoEntidadMilitar)
        {
            EntidadMilitarDTO entidadMilitarDTO = new();
            entidadMilitarDTO.EntidadMilitarId = EntidadMilitarId;
            entidadMilitarDTO.DescEntidadMilitar = DescEntidadMilitar;
            entidadMilitarDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            entidadMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = entidadMilitarBL.ActualizarEntidadMilitar(entidadMilitarDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEntidadMilitar(int EntidadMilitarId)
        {
            EntidadMilitarDTO entidadMilitarDTO = new();
            entidadMilitarDTO.EntidadMilitarId = EntidadMilitarId;
            entidadMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = entidadMilitarBL.EliminarEntidadMilitar(entidadMilitarDTO);

            return Content(IND_OPERACION);
        }
    }
}

