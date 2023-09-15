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
    public class AlistamientoMaterialRequerido1NController : Controller
    {
        readonly ILogger<AlistamientoMaterialRequerido1NController> _logger;

        public AlistamientoMaterialRequerido1NController(ILogger<AlistamientoMaterialRequerido1NController> logger)
        {
            _logger = logger;
        }

        readonly AlistamientoMaterialRequerido1NDAO AlistamientoMaterialRequerido1NBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Alistamientos Materiales Requeridos 1N", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<AlistamientoMaterialRequerido1NDTO> listaAlistamientoMaterialRequerido1Ns = AlistamientoMaterialRequerido1NBL.ObtenerAlistamientoMaterialRequerido1Ns();
            return Json(new { data = listaAlistamientoMaterialRequerido1Ns });
        }

        public ActionResult InsertarAlistamientoMaterialRequerido1N(string Capacidad, string Ponderado, string CodigoAlistamientoMaterialRequerido1N)
        {
            var IND_OPERACION = "";
            try
            {
                AlistamientoMaterialRequerido1NDTO AlistamientoMaterialRequerido1NDTO = new();
                AlistamientoMaterialRequerido1NDTO.CapacidadIntrinseca = Capacidad;
                AlistamientoMaterialRequerido1NDTO.Ponderado1N = Convert.ToDecimal(Ponderado);
                AlistamientoMaterialRequerido1NDTO.CodigoAlistamientoMaterialRequerido1N = CodigoAlistamientoMaterialRequerido1N;
                AlistamientoMaterialRequerido1NDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = AlistamientoMaterialRequerido1NBL.AgregarAlistamientoMaterialRequerido1N(AlistamientoMaterialRequerido1NDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAlistamientoMaterialRequerido1N(int AlistamientoMaterialRequerido1NId)
        {
            return Json(AlistamientoMaterialRequerido1NBL.BuscarAlistamientoMaterialRequerido1NID(AlistamientoMaterialRequerido1NId));
        }

        public ActionResult ActualizarAlistamientoMaterialRequerido1N(int AlistamientoMaterialRequerido1NId, string Capacidad, string Ponderado, string CodigoAlistamientoMaterialRequerido1N)
        {
            AlistamientoMaterialRequerido1NDTO AlistamientoMaterialRequerido1NDTO = new();
            AlistamientoMaterialRequerido1NDTO.AlistamientoMaterialRequerido1NId = AlistamientoMaterialRequerido1NId;
            AlistamientoMaterialRequerido1NDTO.CapacidadIntrinseca = Capacidad;
            AlistamientoMaterialRequerido1NDTO.Ponderado1N = Convert.ToDecimal(Ponderado);
            AlistamientoMaterialRequerido1NDTO.CodigoAlistamientoMaterialRequerido1N = CodigoAlistamientoMaterialRequerido1N;
            AlistamientoMaterialRequerido1NDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AlistamientoMaterialRequerido1NBL.ActualizarAlistamientoMaterialRequerido1N(AlistamientoMaterialRequerido1NDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAlistamientoMaterialRequerido1N(int AlistamientoMaterialRequerido1NId)
        {
            AlistamientoMaterialRequerido1NDTO AlistamientoMaterialRequerido1NDTO = new();
            AlistamientoMaterialRequerido1NDTO.AlistamientoMaterialRequerido1NId = AlistamientoMaterialRequerido1NId;
            AlistamientoMaterialRequerido1NDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AlistamientoMaterialRequerido1NBL.EliminarAlistamientoMaterialRequerido1N(AlistamientoMaterialRequerido1NDTO);

            return Content(IND_OPERACION);
        }
    }
}
