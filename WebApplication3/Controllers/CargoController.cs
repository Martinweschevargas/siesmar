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
    public class CargoController : Controller
    {
        readonly ILogger<CargoController> _logger;

        public CargoController(ILogger<CargoController> logger)
        {
            _logger = logger;
        }

        readonly CargoDAO CargoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Cargos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CargoDTO> listaCargos = CargoBL.ObtenerCargos();
            return Json(new { data = listaCargos });
        }

        public ActionResult InsertarCargo(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CargoDTO CargoDTO = new();
                CargoDTO.DescCargo = Descripcion;
                CargoDTO.CodigoCargo = Codigo;
                CargoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = CargoBL.AgregarCargo(CargoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCargo(int CargoId)
        {
            return Json(CargoBL.BuscarCargoID(CargoId));
        }

        public ActionResult ActualizarCargo(int CargoId, string Codigo, string Descripcion)
        {
            CargoDTO CargoDTO = new();
            CargoDTO.CargoId = CargoId;
            CargoDTO.DescCargo = Descripcion;
            CargoDTO.CodigoCargo = Codigo;
            CargoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CargoBL.ActualizarCargo(CargoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCargo(int CargoId)
        {
            CargoDTO CargoDTO = new();
            CargoDTO.CargoId = CargoId;
            CargoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CargoBL.EliminarCargo(CargoDTO);

            return Content(IND_OPERACION);
        }
    }
}
