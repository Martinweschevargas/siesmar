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
    public class CapacidadOperativaController : Controller
    {
        readonly ILogger<CapacidadOperativaController> _logger;

        public CapacidadOperativaController(ILogger<CapacidadOperativaController> logger)
        {
            _logger = logger;
        }

        readonly CapacidadOperativa CapacidadOperativaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Capacidades Operativas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult CargarDatos()
        {
            List<CapacidadOperativaDTO> listaCapacidadOperativaes = CapacidadOperativaBL.ObtenerCapacidadOperativas();
            return Json(new { data = listaCapacidadOperativaes });
        }

        public ActionResult InsertarCapacidadOperativa(string Descripcion, int DependenciaId)
        {
            var IND_OPERACION = "";
            try
            {
                CapacidadOperativaDTO CapacidadOperativaDTO = new();
                CapacidadOperativaDTO.DescCapacidadOperativa = Descripcion;
                CapacidadOperativaDTO.CodigoCapacidadOperativa = DependenciaId;
                CapacidadOperativaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = CapacidadOperativaBL.AgregarCapacidadOperativa(CapacidadOperativaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCapacidadOperativa(int CapacidadOperativaId)
        {
            return Json(CapacidadOperativaBL.BuscarCapacidadOperativaID(CapacidadOperativaId));
        }

        public ActionResult ActualizarCapacidadOperativa(int CapacidadOperativaId, string Descripcion, int DependenciaId)
        {
            CapacidadOperativaDTO CapacidadOperativaDTO = new();
            CapacidadOperativaDTO.CapacidadOperativaId = CapacidadOperativaId;
            CapacidadOperativaDTO.DescCapacidadOperativa = Descripcion;
            CapacidadOperativaDTO.CodigoCapacidadOperativa = DependenciaId;
            CapacidadOperativaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CapacidadOperativaBL.ActualizarCapacidadOperativa(CapacidadOperativaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCapacidadOperativa(int CapacidadOperativaId)
        {
            CapacidadOperativaDTO CapacidadOperativaDTO = new();
            CapacidadOperativaDTO.CapacidadOperativaId = CapacidadOperativaId;
            CapacidadOperativaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CapacidadOperativaBL.EliminarCapacidadOperativa(CapacidadOperativaDTO);

            return Content(IND_OPERACION);
        }
    }
}
