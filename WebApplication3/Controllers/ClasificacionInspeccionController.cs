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
    public class ClasificacionInspeccionController : Controller
    {
        readonly ILogger<ClasificacionInspeccionController> _logger;

        public ClasificacionInspeccionController(ILogger<ClasificacionInspeccionController> logger)
        {
            _logger = logger;
        }

        readonly ClasificacionInspeccion ClasificacionInspeccionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clasificaciones Inspecciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClasificacionInspeccionDTO> listaClasificacionInspeccions = ClasificacionInspeccionBL.ObtenerClasificacionInspeccions();
            return Json(new { data = listaClasificacionInspeccions });
        }

        public ActionResult InsertarClasificacionInspeccion(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ClasificacionInspeccionDTO ClasificacionInspeccionDTO = new();
                ClasificacionInspeccionDTO.DescClasificacionInspeccion = Descripcion;
                ClasificacionInspeccionDTO.CodigoClasificacionInspeccion = Codigo;
                ClasificacionInspeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ClasificacionInspeccionBL.AgregarClasificacionInspeccion(ClasificacionInspeccionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClasificacionInspeccion(int ClasificacionInspeccionId)
        {
            return Json(ClasificacionInspeccionBL.BuscarClasificacionInspeccionID(ClasificacionInspeccionId));
        }

        public ActionResult ActualizarClasificacionInspeccion(int ClasificacionInspeccionId, string Codigo, string Descripcion)
        {
            ClasificacionInspeccionDTO ClasificacionInspeccionDTO = new();
            ClasificacionInspeccionDTO.ClasificacionInspeccionId = ClasificacionInspeccionId;
            ClasificacionInspeccionDTO.DescClasificacionInspeccion = Descripcion;
            ClasificacionInspeccionDTO.CodigoClasificacionInspeccion = Codigo;
            ClasificacionInspeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ClasificacionInspeccionBL.ActualizarClasificacionInspeccion(ClasificacionInspeccionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClasificacionInspeccion(int ClasificacionInspeccionId)
        {
            ClasificacionInspeccionDTO ClasificacionInspeccionDTO = new();
            ClasificacionInspeccionDTO.ClasificacionInspeccionId = ClasificacionInspeccionId;
            ClasificacionInspeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ClasificacionInspeccionBL.EliminarClasificacionInspeccion(ClasificacionInspeccionDTO);

            return Content(IND_OPERACION);
        }
    }
}
