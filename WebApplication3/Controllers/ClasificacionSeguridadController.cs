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
    public class ClasificacionSeguridadController : Controller
    {
        readonly ILogger<ClasificacionSeguridadController> _logger;

        public ClasificacionSeguridadController(ILogger<ClasificacionSeguridadController> logger)
        {
            _logger = logger;
        }

        readonly ClasificacionSeguridadDAO ClasificacionSeguridadBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clasificaciones Seguridades", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClasificacionSeguridadDTO> listaClasificacionSeguridads = ClasificacionSeguridadBL.ObtenerClasificacionSeguridads();
            return Json(new { data = listaClasificacionSeguridads });
        }

        public ActionResult InsertarClasificacionSeguridad(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ClasificacionSeguridadDTO ClasificacionSeguridadDTO = new();
                ClasificacionSeguridadDTO.DescClasificacionSeguridad = Descripcion;
                ClasificacionSeguridadDTO.CodigoClasificacionSeguridad = Codigo;
                ClasificacionSeguridadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ClasificacionSeguridadBL.AgregarClasificacionSeguridad(ClasificacionSeguridadDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClasificacionSeguridad(int ClasificacionSeguridadId)
        {
            return Json(ClasificacionSeguridadBL.BuscarClasificacionSeguridadID(ClasificacionSeguridadId));
        }

        public ActionResult ActualizarClasificacionSeguridad(int ClasificacionSeguridadId, string Codigo, string Descripcion)
        {
            ClasificacionSeguridadDTO ClasificacionSeguridadDTO = new();
            ClasificacionSeguridadDTO.ClasificacionSeguridadId = ClasificacionSeguridadId;
            ClasificacionSeguridadDTO.DescClasificacionSeguridad = Descripcion;
            ClasificacionSeguridadDTO.CodigoClasificacionSeguridad = Codigo;
            ClasificacionSeguridadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ClasificacionSeguridadBL.ActualizarClasificacionSeguridad(ClasificacionSeguridadDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClasificacionSeguridad(int ClasificacionSeguridadId)
        {
            ClasificacionSeguridadDTO ClasificacionSeguridadDTO = new();
            ClasificacionSeguridadDTO.ClasificacionSeguridadId = ClasificacionSeguridadId;
            ClasificacionSeguridadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ClasificacionSeguridadBL.EliminarClasificacionSeguridad(ClasificacionSeguridadDTO);

            return Content(IND_OPERACION);
        }
    }
}
