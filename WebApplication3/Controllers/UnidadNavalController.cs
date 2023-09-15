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
    public class UnidadNavalController : Controller
    {
        readonly ILogger<UnidadNavalController> _logger;

        public UnidadNavalController(ILogger<UnidadNavalController> logger)
        {
            _logger = logger;
        }

        readonly UnidadNavalDAO unidadNavalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Unidades Navales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<UnidadNavalDTO> listaUnidadNavals = unidadNavalBL.ObtenerUnidadNavals();
            return Json(new { data = listaUnidadNavals });
        }

        public ActionResult InsertarUnidadNaval(string Casco, string Descripcion, string CodigoUnidadNaval)
        {
            var IND_OPERACION = "";
            try
            {
                UnidadNavalDTO unidadNavalDTO = new();
                unidadNavalDTO.CodigoUnidadNaval = CodigoUnidadNaval;
                unidadNavalDTO.DescUnidadNaval = Descripcion;
                unidadNavalDTO.CascoNave = Casco;
                unidadNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = unidadNavalBL.AgregarUnidadNaval(unidadNavalDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarUnidadNaval(int UnidadNavalId)
        {
            return Json(unidadNavalBL.BuscarUnidadNavalID(UnidadNavalId));
        }

        public ActionResult ActualizarUnidadNaval(int UnidadNavalId, string Casco, string Descripcion , string CodigoUnidadNaval)
        {
            UnidadNavalDTO unidadNavalDTO = new();
            unidadNavalDTO.UnidadNavalId = UnidadNavalId;
            unidadNavalDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            unidadNavalDTO.DescUnidadNaval = Descripcion;
            unidadNavalDTO.CascoNave = Casco;
            unidadNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadNavalBL.ActualizarUnidadNaval(unidadNavalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarUnidadNaval(int UnidadNavalId)
        {
            UnidadNavalDTO unidadNavalDTO = new();
            unidadNavalDTO.UnidadNavalId = UnidadNavalId;
            unidadNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadNavalBL.EliminarUnidadNaval(unidadNavalDTO);

            return Content(IND_OPERACION);
        }
    }
}
