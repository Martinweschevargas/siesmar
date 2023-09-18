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
    public class ClaseCombustibleController : Controller
    {
        readonly ILogger<ClaseCombustibleController> _logger;

        public ClaseCombustibleController(ILogger<ClaseCombustibleController> logger)
        {
            _logger = logger;
        }

        readonly ClaseCombustibleDAO ClaseCombustibleBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clases Combustibles", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClaseCombustibleDTO> listaClaseCombustibles = ClaseCombustibleBL.ObtenerClaseCombustibles();
            return Json(new { data = listaClaseCombustibles });
        }

        public ActionResult InsertarClaseCombustible(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ClaseCombustibleDTO ClaseCombustibleDTO = new();
                ClaseCombustibleDTO.DescClaseCombustible = Descripcion;
                ClaseCombustibleDTO.CodigoClaseCombustible = Codigo;
                ClaseCombustibleDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ClaseCombustibleBL.AgregarClaseCombustible(ClaseCombustibleDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClaseCombustible(int ClaseCombustibleId)
        {
            return Json(ClaseCombustibleBL.BuscarClaseCombustibleID(ClaseCombustibleId));
        }

        public ActionResult ActualizarClaseCombustible(int ClaseCombustibleId, string Codigo, string Descripcion)
        {
            ClaseCombustibleDTO ClaseCombustibleDTO = new();
            ClaseCombustibleDTO.ClaseCombustibleId = ClaseCombustibleId;
            ClaseCombustibleDTO.DescClaseCombustible = Descripcion;
            ClaseCombustibleDTO.CodigoClaseCombustible = Codigo;
            ClaseCombustibleDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ClaseCombustibleBL.ActualizarClaseCombustible(ClaseCombustibleDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClaseCombustible(int ClaseCombustibleId)
        {
            ClaseCombustibleDTO ClaseCombustibleDTO = new();
            ClaseCombustibleDTO.ClaseCombustibleId = ClaseCombustibleId;
            ClaseCombustibleDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ClaseCombustibleBL.EliminarClaseCombustible(ClaseCombustibleDTO);

            return Content(IND_OPERACION);
        }
    }
}
