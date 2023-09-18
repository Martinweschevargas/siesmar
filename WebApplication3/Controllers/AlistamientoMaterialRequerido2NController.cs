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
    public class AlistamientoMaterialRequerido2NController : Controller
    {
        readonly ILogger<AlistamientoMaterialRequerido2NController> _logger;

        public AlistamientoMaterialRequerido2NController(ILogger<AlistamientoMaterialRequerido2NController> logger)
        {
            _logger = logger;
        }

        readonly AlistamientoMaterialRequerido2N alistamientoMaterialRequerido2NBL = new();
        Usuario usuarioBL = new();

        AlistamientoMaterialRequerido1N alistamientoMaterialRequerido1NBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Alistamientos Materiales Requeridos 2N", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<AlistamientoMaterialRequerido1NDTO> alistamientoMaterialRequerido1NDTO = alistamientoMaterialRequerido1NBL.ObtenerAlistamientoMaterialRequerido1Ns();

            return Json(new { data = alistamientoMaterialRequerido1NDTO });
        }

        public JsonResult CargarDatos()
        {
            List<AlistamientoMaterialRequerido2NDTO> listaAlistamientoMaterialRequerido2Nes = alistamientoMaterialRequerido2NBL.ObtenerAlistamientoMaterialRequerido2Ns();
            return Json(new { data = listaAlistamientoMaterialRequerido2Nes });
        }

        public ActionResult InsertarAlistamientoMaterialRequerido2N(string Subclasificacion, string Ponderado, string Equipo, string CodigoAlistamientoMaterialRequerido2N, string CodigoAlistamientoMaterialRequerido1N)
        {
            var IND_OPERACION = "";
            try
            {
                AlistamientoMaterialRequerido2NDTO alistamientoMaterialRequerido2NDTO = new();
                alistamientoMaterialRequerido2NDTO.Subclasificacion = Subclasificacion;
                alistamientoMaterialRequerido2NDTO.Ponderado2Nivel = Convert.ToDecimal(Ponderado);
                alistamientoMaterialRequerido2NDTO.Equipo = Equipo;
                alistamientoMaterialRequerido2NDTO.CodigoAlistamientoMaterialRequerido2N = CodigoAlistamientoMaterialRequerido2N;
                alistamientoMaterialRequerido2NDTO.CodigoAlistamientoMaterialRequerido1N = CodigoAlistamientoMaterialRequerido1N;
                alistamientoMaterialRequerido2NDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = alistamientoMaterialRequerido2NBL.AgregarAlistamientoMaterialRequerido2N(alistamientoMaterialRequerido2NDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAlistamientoMaterialRequerido2N(int AlistamientoMaterialRequerido2NId)
        {
            return Json(alistamientoMaterialRequerido2NBL.BuscarAlistamientoMaterialRequerido2NID(AlistamientoMaterialRequerido2NId));
        }

        public ActionResult ActualizarAlistamientoMaterialRequerido2N(int AlistamientoMaterialRequerido2NId, string Subclasificacion, decimal Ponderado, string Equipo, string CodigoAlistamientoMaterialRequerido2N, string CodigoAlistamientoMaterialRequerido1N)
        {
            AlistamientoMaterialRequerido2NDTO alistamientoMaterialRequerido2NDTO = new();
            alistamientoMaterialRequerido2NDTO.AlistamientoMaterialRequerido2NId = AlistamientoMaterialRequerido2NId;
            alistamientoMaterialRequerido2NDTO.Subclasificacion = Subclasificacion;
            alistamientoMaterialRequerido2NDTO.Ponderado2Nivel = Convert.ToDecimal(Ponderado);
            alistamientoMaterialRequerido2NDTO.Equipo = Equipo;
            alistamientoMaterialRequerido2NDTO.CodigoAlistamientoMaterialRequerido2N = CodigoAlistamientoMaterialRequerido2N;
            alistamientoMaterialRequerido2NDTO.CodigoAlistamientoMaterialRequerido1N = CodigoAlistamientoMaterialRequerido1N;
            alistamientoMaterialRequerido2NDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialRequerido2NBL.ActualizarAlistamientoMaterialRequerido2N(alistamientoMaterialRequerido2NDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAlistamientoMaterialRequerido2N(int AlistamientoMaterialRequerido2NId)
        {
            AlistamientoMaterialRequerido2NDTO alistamientoMaterialRequerido2NDTO = new();
            alistamientoMaterialRequerido2NDTO.AlistamientoMaterialRequerido2NId = AlistamientoMaterialRequerido2NId;
            alistamientoMaterialRequerido2NDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialRequerido2NBL.EliminarAlistamientoMaterialRequerido2N(alistamientoMaterialRequerido2NDTO);

            return Content(IND_OPERACION);
        }
    }
}
