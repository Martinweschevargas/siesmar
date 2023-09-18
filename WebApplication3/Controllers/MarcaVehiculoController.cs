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
    public class MarcaVehiculoController : Controller
    {
        readonly ILogger<MarcaVehiculoController> _logger;

        public MarcaVehiculoController(ILogger<MarcaVehiculoController> logger)
        {
            _logger = logger;
        }

        readonly MarcaVehiculoDAO MarcaVehiculoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Marcas Vehiculos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MarcaVehiculoDTO> listaMarcaVehiculos = MarcaVehiculoBL.ObtenerMarcaVehiculos();
            return Json(new { data = listaMarcaVehiculos });
        }

        public ActionResult InsertarMarcaVehiculo(string CodigoMarcaVehiculo, string ClasificacionVehiculo)
        {
            var IND_OPERACION = "";
            try
            {
                MarcaVehiculoDTO MarcaVehiculoDTO = new();
                MarcaVehiculoDTO.ClasificacionVehiculo = ClasificacionVehiculo;
                MarcaVehiculoDTO.CodigoMarcaVehiculo = CodigoMarcaVehiculo;
                MarcaVehiculoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = MarcaVehiculoBL.AgregarMarcaVehiculo(MarcaVehiculoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMarcaVehiculo(int MarcaVehiculoId)
        {
            return Json(MarcaVehiculoBL.BuscarMarcaVehiculoID(MarcaVehiculoId));
        }

        public ActionResult ActualizarMarcaVehiculo(int MarcaVehiculoId, string CodigoMarcaVehiculo, string ClasificacionVehiculo)
        {
            MarcaVehiculoDTO MarcaVehiculoDTO = new();
            MarcaVehiculoDTO.MarcaVehiculoId = MarcaVehiculoId;
            MarcaVehiculoDTO.ClasificacionVehiculo = ClasificacionVehiculo;
            MarcaVehiculoDTO.CodigoMarcaVehiculo = CodigoMarcaVehiculo;
            MarcaVehiculoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = MarcaVehiculoBL.ActualizarMarcaVehiculo(MarcaVehiculoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMarcaVehiculo(int MarcaVehiculoId)
        {
            MarcaVehiculoDTO MarcaVehiculoDTO = new();
            MarcaVehiculoDTO.MarcaVehiculoId = MarcaVehiculoId;
            MarcaVehiculoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = MarcaVehiculoBL.EliminarMarcaVehiculo(MarcaVehiculoDTO);

            return Content(IND_OPERACION);
        }
    }
}
