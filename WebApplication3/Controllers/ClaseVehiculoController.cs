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
    public class ClaseVehiculoController : Controller
    {
        readonly ILogger<ClaseVehiculoController> _logger;

        public ClaseVehiculoController(ILogger<ClaseVehiculoController> logger)
        {
            _logger = logger;
        }

        readonly ClaseVehiculo ClaseVehiculoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clases Vehiculos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClaseVehiculoDTO> listaClaseVehiculos = ClaseVehiculoBL.ObtenerClaseVehiculos();
            return Json(new { data = listaClaseVehiculos });
        }

        public ActionResult InsertarClaseVehiculo(string Clasificacion)
        {
            var IND_OPERACION = "";
            try
            {
                ClaseVehiculoDTO ClaseVehiculoDTO = new();
                ClaseVehiculoDTO.Clasificacion = Clasificacion;
                ClaseVehiculoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ClaseVehiculoBL.AgregarClaseVehiculo(ClaseVehiculoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClaseVehiculo(int ClaseVehiculoId)
        {
            return Json(ClaseVehiculoBL.BuscarClaseVehiculoID(ClaseVehiculoId));
        }

        public ActionResult ActualizarClaseVehiculo(int ClaseVehiculoId, string Clasificacion)
        {
            ClaseVehiculoDTO ClaseVehiculoDTO = new();
            ClaseVehiculoDTO.ClaseVehiculoId = ClaseVehiculoId;
            ClaseVehiculoDTO.Clasificacion = Clasificacion;
            ClaseVehiculoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ClaseVehiculoBL.ActualizarClaseVehiculo(ClaseVehiculoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClaseVehiculo(int ClaseVehiculoId)
        {
            ClaseVehiculoDTO ClaseVehiculoDTO = new();
            ClaseVehiculoDTO.ClaseVehiculoId = ClaseVehiculoId;
            ClaseVehiculoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ClaseVehiculoBL.EliminarClaseVehiculo(ClaseVehiculoDTO);

            return Content(IND_OPERACION);
        }
    }
}
