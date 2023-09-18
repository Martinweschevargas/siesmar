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
    public class InspeccionExtensionController : Controller
    {
        readonly ILogger<InspeccionExtensionController> _logger;

        public InspeccionExtensionController(ILogger<InspeccionExtensionController> logger)
        {
            _logger = logger;
        }

        readonly InspeccionExtensionDAO inspeccionExtensionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Inspecciones Extensiones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<InspeccionExtensionDTO> listaInspeccionExtensions = inspeccionExtensionBL.ObtenerInspeccionExtensions();
            return Json(new { data = listaInspeccionExtensions });
        }

        public ActionResult InsertarInspeccionExtension(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                InspeccionExtensionDTO inspeccionExtensionDTO = new();
                inspeccionExtensionDTO.DescInspeccionExtension = Descripcion;
                inspeccionExtensionDTO.CodigoInspeccionExtension = Codigo;
                inspeccionExtensionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = inspeccionExtensionBL.AgregarInspeccionExtension(inspeccionExtensionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarInspeccionExtension(int InspeccionExtensionId)
        {
            return Json(inspeccionExtensionBL.BuscarInspeccionExtensionID(InspeccionExtensionId));
        }

        public ActionResult ActualizarInspeccionExtension(int InspeccionExtensionId, string Codigo, string Descripcion)
        {
            InspeccionExtensionDTO inspeccionExtensionDTO = new();
            inspeccionExtensionDTO.InspeccionExtensionId = InspeccionExtensionId;
            inspeccionExtensionDTO.DescInspeccionExtension = Descripcion;
            inspeccionExtensionDTO.CodigoInspeccionExtension = Codigo;
            inspeccionExtensionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = inspeccionExtensionBL.ActualizarInspeccionExtension(inspeccionExtensionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarInspeccionExtension(int InspeccionExtensionId)
        {
            InspeccionExtensionDTO inspeccionExtensionDTO = new();
            inspeccionExtensionDTO.InspeccionExtensionId = InspeccionExtensionId;
            inspeccionExtensionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = inspeccionExtensionBL.EliminarInspeccionExtension(inspeccionExtensionDTO);

            return Content(IND_OPERACION);
        }
    }
}
