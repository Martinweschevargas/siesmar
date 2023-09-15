using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Presentacion.Filters;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class AfeccionController : Controller
    {
        readonly ILogger<AfeccionController> _logger;

        public AfeccionController(ILogger<AfeccionController> logger)
        {
            _logger = logger;
        }

        readonly Afeccion afeccionBL = new();
        Usuario usuarioBL = new();
         
        [AuthorizePermission(Formato:43, Permiso:1)]
        [Breadcrumb(FromAction = "Index", Title = "Afecciones", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<AfeccionDTO> listaAfeccions = afeccionBL.ObtenerAfeccions();
            return Json(new { data = listaAfeccions });
        }

        public ActionResult InsertarAfeccion(string DescAfeccion, string CodigoAfeccion)
        {
            var IND_OPERACION="";
            try
            {
                AfeccionDTO afeccionDTO = new();
                afeccionDTO.DescAfeccion = DescAfeccion;
                afeccionDTO.CodigoAfeccion = CodigoAfeccion;
                afeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = afeccionBL.AgregarAfeccion(afeccionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAfeccion(int AfeccionId)
        {
            return Json(afeccionBL.BuscarAfeccionID(AfeccionId));
        }

        public ActionResult ActualizarAfeccion(int AfeccionId, string DescAfeccion, string CodigoAfeccion)
        {
            AfeccionDTO afeccionDTO = new();
            afeccionDTO.AfeccionId = AfeccionId;
            afeccionDTO.DescAfeccion = DescAfeccion;
            afeccionDTO.CodigoAfeccion = CodigoAfeccion;
            afeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = afeccionBL.ActualizarAfeccion(afeccionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAfeccion(int AfeccionId)
        {
            AfeccionDTO afeccionDTO = new();
            afeccionDTO.AfeccionId = AfeccionId;
            afeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = afeccionBL.EliminarAfeccion(afeccionDTO);

            return Content(IND_OPERACION);
        }
    }
}
