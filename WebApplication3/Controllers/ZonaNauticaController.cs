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
    public class ZonaNauticaController : Controller
    {
        readonly ILogger<ZonaNauticaController> _logger;

        public ZonaNauticaController(ILogger<ZonaNauticaController> logger)
        {
            _logger = logger;
        }

        readonly ZonaNauticaDAO zonaNauticaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Zonas Náuticas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
          
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ZonaNauticaDTO> listaZonaNauticas = zonaNauticaBL.ObtenerZonaNauticas();
            return Json(new { data = listaZonaNauticas });
        }

        public ActionResult InsertarZonaNautica(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ZonaNauticaDTO zonaNauticaDTO = new();
                zonaNauticaDTO.DescZonaNautica = Descripcion;
                zonaNauticaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = zonaNauticaBL.AgregarZonaNautica(zonaNauticaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarZonaNautica(int ZonaNauticaId)
        {
            return Json(zonaNauticaBL.BuscarZonaNauticaID(ZonaNauticaId));
        }

        public ActionResult ActualizarZonaNautica(int ZonaNauticaId, string Descripcion)
        {
            ZonaNauticaDTO zonaNauticaDTO = new();
            zonaNauticaDTO.ZonaNauticaId = ZonaNauticaId;
            zonaNauticaDTO.DescZonaNautica = Descripcion;
            zonaNauticaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = zonaNauticaBL.ActualizarZonaNautica(zonaNauticaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarZonaNautica(int ZonaNauticaId)
        {
            ZonaNauticaDTO zonaNauticaDTO = new();
            zonaNauticaDTO.ZonaNauticaId = ZonaNauticaId;
            zonaNauticaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = zonaNauticaBL.EliminarZonaNautica(zonaNauticaDTO);

            return Content(IND_OPERACION);
        }
    }
}
