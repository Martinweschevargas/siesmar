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
    public class VestimentaUniformeController : Controller
    {
        readonly ILogger<VestimentaUniformeController> _logger;

        public VestimentaUniformeController(ILogger<VestimentaUniformeController> logger)
        {
            _logger = logger;
        }

        readonly VestimentaUniformeDAO vestimentaUniformeBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Vestimentas Uniformes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<VestimentaUniformeDTO> listaVestimentaUniformes = vestimentaUniformeBL.ObtenerVestimentaUniformes();
            return Json(new { data = listaVestimentaUniformes });
        }

        public ActionResult InsertarVestimentaUniforme(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                VestimentaUniformeDTO vestimentaUniformeDTO = new();
                vestimentaUniformeDTO.DescVestimentaUniforme = Descripcion;
                vestimentaUniformeDTO.CodigoVestimentaUniforme = Codigo;
                vestimentaUniformeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = vestimentaUniformeBL.AgregarVestimentaUniforme(vestimentaUniformeDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarVestimentaUniforme(int VestimentaUniformeId)
        {
            return Json(vestimentaUniformeBL.BuscarVestimentaUniformeID(VestimentaUniformeId));
        }

        public ActionResult ActualizarVestimentaUniforme(int VestimentaUniformeId, string Codigo, string Descripcion)
        {
            VestimentaUniformeDTO vestimentaUniformeDTO = new();
            vestimentaUniformeDTO.VestimentaUniformeId = VestimentaUniformeId;
            vestimentaUniformeDTO.DescVestimentaUniforme = Descripcion;
            vestimentaUniformeDTO.CodigoVestimentaUniforme = Codigo;
            vestimentaUniformeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = vestimentaUniformeBL.ActualizarVestimentaUniforme(vestimentaUniformeDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarVestimentaUniforme(int VestimentaUniformeId)
        {
            VestimentaUniformeDTO vestimentaUniformeDTO = new();
            vestimentaUniformeDTO.VestimentaUniformeId = VestimentaUniformeId;
            vestimentaUniformeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = vestimentaUniformeBL.EliminarVestimentaUniforme(vestimentaUniformeDTO);

            return Content(IND_OPERACION);
        }
    }
}
