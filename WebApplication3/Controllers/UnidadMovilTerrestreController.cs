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
    public class UnidadMovilTerrestreController : Controller
    {
        readonly ILogger<UnidadMovilTerrestreController> _logger;

        public UnidadMovilTerrestreController(ILogger<UnidadMovilTerrestreController> logger)
        {
            _logger = logger;
        }

        readonly UnidadMovilTerrestreDAO UnidadMovilTerrestreBL = new();
        Usuario usuarioBL = new();

        MarcaVehiculoDAO marcaVehiculoBL = new();
        TipoVehiculoMovilDAO tipoVehiculoMovilBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "UnidadMovilTerrestres Peru", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombsMarca()
        {
            List<MarcaVehiculoDTO> marcaVehiculoDTO = marcaVehiculoBL.ObtenerMarcaVehiculos();
            return Json(new { data = marcaVehiculoDTO });
        }

        [HttpGet]
        public IActionResult cargaCombsTipo()
        {
            List<TipoVehiculoMovilDTO> tipoVehiculoMovilDTO = tipoVehiculoMovilBL.ObtenerTipoVehiculoMovils();
            return Json(new { data = tipoVehiculoMovilDTO });
        }

        public JsonResult CargarDatos()
        {
            List<UnidadMovilTerrestreDTO> listaUnidadMovilTerrestrees = UnidadMovilTerrestreBL.ObtenerUnidadMovilTerrestres();
            return Json(new { data = listaUnidadMovilTerrestrees });
        }

        public ActionResult InsertarUnidadMovilTerrestre(string PlacaUnidadMovilTerrestre, int MarcaVehiculoId, int TipoVehiculoMovilId)
        {
            var IND_OPERACION = "";
            try
            {
                UnidadMovilTerrestreDTO UnidadMovilTerrestreDTO = new();
                UnidadMovilTerrestreDTO.PlacaUnidadMovilTerrestre = PlacaUnidadMovilTerrestre;
                UnidadMovilTerrestreDTO.MarcaVehiculoId = MarcaVehiculoId;
                UnidadMovilTerrestreDTO.TipoVehiculoMovilId = TipoVehiculoMovilId;
                UnidadMovilTerrestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = UnidadMovilTerrestreBL.AgregarUnidadMovilTerrestre(UnidadMovilTerrestreDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarUnidadMovilTerrestre(int UnidadMovilTerrestreId)
        {
            return Json(UnidadMovilTerrestreBL.BuscarUnidadMovilTerrestreID(UnidadMovilTerrestreId));
        }

        public ActionResult ActualizarUnidadMovilTerrestre(int UnidadMovilTerrestreId, string PlacaUnidadMovilTerrestre, int MarcaVehiculoId, int TipoVehiculoMovilId)
        {
            UnidadMovilTerrestreDTO UnidadMovilTerrestreDTO = new();
            UnidadMovilTerrestreDTO.UnidadMovilTerrestreId = UnidadMovilTerrestreId;
            UnidadMovilTerrestreDTO.PlacaUnidadMovilTerrestre = PlacaUnidadMovilTerrestre;
            UnidadMovilTerrestreDTO.MarcaVehiculoId = MarcaVehiculoId;
            UnidadMovilTerrestreDTO.TipoVehiculoMovilId = TipoVehiculoMovilId;
            UnidadMovilTerrestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = UnidadMovilTerrestreBL.ActualizarUnidadMovilTerrestre(UnidadMovilTerrestreDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarUnidadMovilTerrestre(int UnidadMovilTerrestreId)
        {
            UnidadMovilTerrestreDTO UnidadMovilTerrestreDTO = new();
            UnidadMovilTerrestreDTO.UnidadMovilTerrestreId = UnidadMovilTerrestreId;
            UnidadMovilTerrestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = UnidadMovilTerrestreBL.EliminarUnidadMovilTerrestre(UnidadMovilTerrestreDTO);

            return Content(IND_OPERACION);
        }
    }
}
