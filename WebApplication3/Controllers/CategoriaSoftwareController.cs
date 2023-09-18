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
    public class CategoriaSoftwareController : Controller
    {
        readonly ILogger<CategoriaSoftwareController> _logger;

        public CategoriaSoftwareController(ILogger<CategoriaSoftwareController> logger)
        {
            _logger = logger;
        }

        readonly CategoriaSoftwareDAO CategoriaSoftwareBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Categorias Software", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CategoriaSoftwareDTO> listaCategoriaSoftwares = CategoriaSoftwareBL.ObtenerCategoriaSoftwares();
            return Json(new { data = listaCategoriaSoftwares });
        }

        public ActionResult InsertarCategoriaSoftware(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CategoriaSoftwareDTO CategoriaSoftwareDTO = new();
                CategoriaSoftwareDTO.DescCategoriaSoftware = Descripcion;
                CategoriaSoftwareDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = CategoriaSoftwareBL.AgregarCategoriaSoftware(CategoriaSoftwareDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCategoriaSoftware(int CategoriaSoftwareId)
        {
            return Json(CategoriaSoftwareBL.BuscarCategoriaSoftwareID(CategoriaSoftwareId));
        }

        public ActionResult ActualizarCategoriaSoftware(int CategoriaSoftwareId, string Descripcion)
        {
            CategoriaSoftwareDTO CategoriaSoftwareDTO = new();
            CategoriaSoftwareDTO.CategoriaSoftwareId = CategoriaSoftwareId;
            CategoriaSoftwareDTO.DescCategoriaSoftware = Descripcion;
            CategoriaSoftwareDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CategoriaSoftwareBL.ActualizarCategoriaSoftware(CategoriaSoftwareDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCategoriaSoftware(int CategoriaSoftwareId)
        {
            CategoriaSoftwareDTO CategoriaSoftwareDTO = new();
            CategoriaSoftwareDTO.CategoriaSoftwareId = CategoriaSoftwareId;
            CategoriaSoftwareDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CategoriaSoftwareBL.EliminarCategoriaSoftware(CategoriaSoftwareDTO);

            return Content(IND_OPERACION);
        }
    }
}
