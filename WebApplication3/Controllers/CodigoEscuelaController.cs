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
    public class CodigoEscuelaController : Controller
    {
        readonly ILogger<CodigoEscuelaController> _logger;

        public CodigoEscuelaController(ILogger<CodigoEscuelaController> logger)
        {
            _logger = logger;
        }

        readonly CodigoEscuelaDAO codigoEscuelaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "CodigoEscuela", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CodigoEscuelaDTO> listaCodigoEscuelas = codigoEscuelaBL.ObtenerCodigoEscuelas();
            return Json(new { data = listaCodigoEscuelas });
        }

        public ActionResult InsertarCodigoEscuela(string DescCodigoEscuela, string CodigoCodigoEscuela)
        {
            var IND_OPERACION = "";
            try
            {
                CodigoEscuelaDTO codigoEscuelaDTO = new();
                codigoEscuelaDTO.DescCodigoEscuela = DescCodigoEscuela;
                codigoEscuelaDTO.CodigoCodigoEscuela = CodigoCodigoEscuela;
                codigoEscuelaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = codigoEscuelaBL.AgregarCodigoEscuela(codigoEscuelaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCodigoEscuela(int CodigoEscuelaId)
        {
            return Json(codigoEscuelaBL.BuscarCodigoEscuelaID(CodigoEscuelaId));
        }

        public ActionResult ActualizarCodigoEscuela(int CodigoEscuelaId, string DescCodigoEscuela, string CodigoCodigoEscuela)
        {
            CodigoEscuelaDTO codigoEscuelaDTO = new();
            codigoEscuelaDTO.CodigoEscuelaId = CodigoEscuelaId;
            codigoEscuelaDTO.DescCodigoEscuela = DescCodigoEscuela;
            codigoEscuelaDTO.CodigoCodigoEscuela = CodigoCodigoEscuela;
            codigoEscuelaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = codigoEscuelaBL.ActualizarCodigoEscuela(codigoEscuelaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCodigoEscuela(int CodigoEscuelaId)
        {
            CodigoEscuelaDTO codigoEscuelaDTO = new();
            codigoEscuelaDTO.CodigoEscuelaId = CodigoEscuelaId;
            codigoEscuelaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = codigoEscuelaBL.EliminarCodigoEscuela(codigoEscuelaDTO);

            return Content(IND_OPERACION);
        }
    }
}
