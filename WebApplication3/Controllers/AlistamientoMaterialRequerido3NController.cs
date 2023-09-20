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
    public class AlistamientoMaterialRequerido3NController : Controller
    {
        readonly ILogger<AlistamientoMaterialRequerido3NController> _logger;

        public AlistamientoMaterialRequerido3NController(ILogger<AlistamientoMaterialRequerido3NController> logger)
        {
            _logger = logger;
        }

        readonly AlistamientoMaterialRequerido3N alistamientoMaterialRequerido3NBL = new();

        AlistamientoMaterialRequerido2N alistamientoMaterialRequerido2NBL = new();


        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Alistamientos Materiales Requeridos 2N", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<AlistamientoMaterialRequerido2NDTO> alistamientoMaterialRequerido2NDTO = alistamientoMaterialRequerido2NBL.ObtenerAlistamientoMaterialRequerido2Ns();

            return Json(new { data = alistamientoMaterialRequerido2NDTO });
        }

        public JsonResult CargarDatos()
        {
            List<AlistamientoMaterialRequerido3NDTO> listaAlistamientoMaterialRequerido3Nes = alistamientoMaterialRequerido3NBL.ObtenerAlistamientoMaterialRequerido3Ns();
            return Json(new { data = listaAlistamientoMaterialRequerido3Nes });
        }

        public ActionResult InsertarAlistamientoMaterialRequerido3N(string Subclasificacion, decimal Ponderado, string CodigoAlistamientoMaterialRequerido3N, string CodigoAlistamientoMaterialRequerido2N)
        {
            var IND_OPERACION = "";
            try
            {
                AlistamientoMaterialRequerido3NDTO alistamientoMaterialRequerido3NDTO = new();
                alistamientoMaterialRequerido3NDTO.Subclasificacion = Subclasificacion;
                alistamientoMaterialRequerido3NDTO.Ponderado3Nivel = Ponderado;
                alistamientoMaterialRequerido3NDTO.CodigoAlistamientoMaterialRequerido3N = CodigoAlistamientoMaterialRequerido3N;
                alistamientoMaterialRequerido3NDTO.CodigoAlistamientoMaterialRequerido2N = CodigoAlistamientoMaterialRequerido2N;
                alistamientoMaterialRequerido3NDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = alistamientoMaterialRequerido3NBL.AgregarAlistamientoMaterialRequerido3N(alistamientoMaterialRequerido3NDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAlistamientoMaterialRequerido3N(int AlistamientoMaterialRequerido3NId)
        {
            return Json(alistamientoMaterialRequerido3NBL.BuscarAlistamientoMaterialRequerido3NID(AlistamientoMaterialRequerido3NId));
        }

        public ActionResult ActualizarAlistamientoMaterialRequerido3N(int AlistamientoMaterialRequerido3NId, string Subclasificacion, decimal Ponderado, string CodigoAlistamientoMaterialRequerido3N, string CodigoAlistamientoMaterialRequerido2N)
        {
            AlistamientoMaterialRequerido3NDTO alistamientoMaterialRequerido3NDTO = new();
            alistamientoMaterialRequerido3NDTO.AlistamientoMaterialRequerido3NId = AlistamientoMaterialRequerido3NId;
            alistamientoMaterialRequerido3NDTO.Subclasificacion = Subclasificacion;
            alistamientoMaterialRequerido3NDTO.Ponderado3Nivel = Ponderado;
            alistamientoMaterialRequerido3NDTO.CodigoAlistamientoMaterialRequerido3N = CodigoAlistamientoMaterialRequerido3N;
            alistamientoMaterialRequerido3NDTO.CodigoAlistamientoMaterialRequerido2N = CodigoAlistamientoMaterialRequerido2N;
            alistamientoMaterialRequerido3NDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialRequerido3NBL.ActualizarAlistamientoMaterialRequerido3N(alistamientoMaterialRequerido3NDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAlistamientoMaterialRequerido3N(int AlistamientoMaterialRequerido3NId)
        {
            AlistamientoMaterialRequerido3NDTO alistamientoMaterialRequerido3NDTO = new();
            alistamientoMaterialRequerido3NDTO.AlistamientoMaterialRequerido3NId = AlistamientoMaterialRequerido3NId;
            alistamientoMaterialRequerido3NDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialRequerido3NBL.EliminarAlistamientoMaterialRequerido3N(alistamientoMaterialRequerido3NDTO);

            return Content(IND_OPERACION);
        }
    }
}
