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
    public class ColorVehiculoController : Controller
    {
        readonly ILogger<ColorVehiculoController> _logger;

        public ColorVehiculoController(ILogger<ColorVehiculoController> logger)
        {
            _logger = logger;
        }

        readonly ColorVehiculoDAO ColorVehiculoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Colores Vehiculos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ColorVehiculoDTO> listaColorVehiculos = ColorVehiculoBL.ObtenerColorVehiculos();
            return Json(new { data = listaColorVehiculos });
        }

        public ActionResult InsertarColorVehiculo(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ColorVehiculoDTO ColorVehiculoDTO = new();
                ColorVehiculoDTO.DescColorVehiculo = Descripcion;
                ColorVehiculoDTO.CodigoColorVehiculo = Codigo;
                ColorVehiculoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ColorVehiculoBL.AgregarColorVehiculo(ColorVehiculoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarColorVehiculo(int ColorVehiculoId)
        {
            return Json(ColorVehiculoBL.BuscarColorVehiculoID(ColorVehiculoId));
        }

        public ActionResult ActualizarColorVehiculo(int ColorVehiculoId, string Codigo, string Descripcion)
        {
            ColorVehiculoDTO ColorVehiculoDTO = new();
            ColorVehiculoDTO.ColorVehiculoId = ColorVehiculoId;
            ColorVehiculoDTO.DescColorVehiculo = Descripcion;
            ColorVehiculoDTO.CodigoColorVehiculo = Codigo;
            ColorVehiculoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ColorVehiculoBL.ActualizarColorVehiculo(ColorVehiculoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarColorVehiculo(int ColorVehiculoId)
        {
            ColorVehiculoDTO ColorVehiculoDTO = new();
            ColorVehiculoDTO.ColorVehiculoId = ColorVehiculoId;
            ColorVehiculoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ColorVehiculoBL.EliminarColorVehiculo(ColorVehiculoDTO);

            return Content(IND_OPERACION);
        }
    }
}
