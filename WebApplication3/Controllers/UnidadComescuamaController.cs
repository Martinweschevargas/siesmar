using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class UnidadComescuamaController : Controller
    {
        readonly ILogger<UnidadComescuamaController> _logger;

        public UnidadComescuamaController(ILogger<UnidadComescuamaController> logger)
        {
            _logger = logger;
        }

        readonly UnidadComescuamaDAO unidadComescuamaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Unidades Comescuama", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<UnidadComescuamaDTO> lista = unidadComescuamaBL.ObtenerUnidadComescuamas();
            return Json(new { data = lista });
        }

        public ActionResult InsertarUnidadComescuama(string CodigoUnidadComescuama, string DescUnidadComescuama)
        {
            var IND_OPERACION = "";
            try
            {
                UnidadComescuamaDTO unidadComescuamaDTO = new();
                unidadComescuamaDTO.CodigoUnidadComescuama = CodigoUnidadComescuama;
                unidadComescuamaDTO.DescUnidadComescuama = DescUnidadComescuama;
                unidadComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = unidadComescuamaBL.AgregarUnidadComescuama(unidadComescuamaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarUnidadComescuama(int UnidadComescuamaId)
        {
            return Json(unidadComescuamaBL.BuscarUnidadComescuama(UnidadComescuamaId));
        }

        public ActionResult ActualizarUnidadComescuama(int UnidadComescuamaId, string CodigoUnidadComescuama, 
            string DescUnidadComescuama)
        {
            UnidadComescuamaDTO unidadComescuamaDTO = new();
            unidadComescuamaDTO.UnidadComescuamaId = UnidadComescuamaId;
            unidadComescuamaDTO.CodigoUnidadComescuama = CodigoUnidadComescuama;
            unidadComescuamaDTO.DescUnidadComescuama = DescUnidadComescuama;
            unidadComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadComescuamaBL.ActualizarUnidadComescuama(unidadComescuamaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarUnidadComescuama(int UnidadComescuamaId)
        {
            UnidadComescuamaDTO unidadComescuamaDTO = new();
            unidadComescuamaDTO.UnidadComescuamaId = UnidadComescuamaId;
            unidadComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadComescuamaBL.EliminarUnidadComescuama(unidadComescuamaDTO);

            return Content(IND_OPERACION);
        }
    }
}
