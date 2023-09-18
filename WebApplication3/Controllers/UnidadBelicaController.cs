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
    public class UnidadBelicaController : Controller
    {
        readonly ILogger<UnidadBelicaController> _logger;

        public UnidadBelicaController(ILogger<UnidadBelicaController> logger)
        {
            _logger = logger;
        }

        readonly UnidadBelicaDAO unidadBelicaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Unidades Bélicas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
             return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<UnidadBelicaDTO> listaUnidadBelicas = unidadBelicaBL.ObtenerUnidadBelicas();
            return Json(new { data = listaUnidadBelicas });
        }

        public ActionResult InsertarUnidadBelica(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                UnidadBelicaDTO unidadBelicaDTO = new();
                unidadBelicaDTO.DescUnidadBelica = Descripcion;
                unidadBelicaDTO.CodigoUnidadBelica = Codigo;
                unidadBelicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = unidadBelicaBL.AgregarUnidadBelica(unidadBelicaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarUnidadBelica(int UnidadBelicaId)
        {
            return Json(unidadBelicaBL.BuscarUnidadBelicaID(UnidadBelicaId));
        }

        public ActionResult ActualizarUnidadBelica(int UnidadBelicaId, string Codigo, string Descripcion)
        {
            UnidadBelicaDTO unidadBelicaDTO = new();
            unidadBelicaDTO.UnidadBelicaId = UnidadBelicaId;
            unidadBelicaDTO.DescUnidadBelica = Descripcion;
            unidadBelicaDTO.CodigoUnidadBelica = Codigo;
            unidadBelicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadBelicaBL.ActualizarUnidadBelica(unidadBelicaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarUnidadBelica(int UnidadBelicaId)
        {
            UnidadBelicaDTO unidadBelicaDTO = new();
            unidadBelicaDTO.UnidadBelicaId = UnidadBelicaId;
            unidadBelicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadBelicaBL.EliminarUnidadBelica(unidadBelicaDTO);

            return Content(IND_OPERACION);
        }
    }
}
