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
    public class ClaseNaveController : Controller
    {
        readonly ILogger<ClaseNaveController> _logger;

        public ClaseNaveController(ILogger<ClaseNaveController> logger)
        {
            _logger = logger;
        }

        readonly ClaseNave claseNaveBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clases Naves", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClaseNaveDTO> listaClaseNaves = claseNaveBL.ObtenerClaseNaves();
            return Json(new { data = listaClaseNaves });
        }

        public ActionResult InsertarClaseNave(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ClaseNaveDTO claseNaveDTO = new();
                claseNaveDTO.DescClaseNave = Descripcion;
                claseNaveDTO.CodigoClaseNave = Codigo;
                claseNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = claseNaveBL.AgregarClaseNave(claseNaveDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClaseNave(int ClaseNaveId)
        {
            return Json(claseNaveBL.BuscarClaseNaveID(ClaseNaveId));
        }

        public ActionResult ActualizarClaseNave(int ClaseNaveId, string Codigo, string Descripcion)
        {
            ClaseNaveDTO claseNaveDTO = new();
            claseNaveDTO.ClaseNaveId = ClaseNaveId;
            claseNaveDTO.DescClaseNave = Descripcion;
            claseNaveDTO.CodigoClaseNave = Codigo;
            claseNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = claseNaveBL.ActualizarClaseNave(claseNaveDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClaseNave(int ClaseNaveId)
        {
            ClaseNaveDTO claseNaveDTO = new();
            claseNaveDTO.ClaseNaveId = ClaseNaveId;
            claseNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = claseNaveBL.EliminarClaseNave(claseNaveDTO);

            return Content(IND_OPERACION);
        }
    }
}
