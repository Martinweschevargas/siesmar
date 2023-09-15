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
    public class AsuntoApelacionReconsideracionController : Controller
    {
        readonly ILogger<AsuntoApelacionReconsideracionController> _logger;

        public AsuntoApelacionReconsideracionController(ILogger<AsuntoApelacionReconsideracionController> logger)
        {
            _logger = logger;
        }

        readonly AsuntoApelacionReconsideracionDAO AsuntoApelacionReconsideracionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Asuntos Apelaciones Reconsideraciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<AsuntoApelacionReconsideracionDTO> listaAsuntoApelacionReconsideracions = AsuntoApelacionReconsideracionBL.ObtenerAsuntoApelacionReconsideraciones();
            return Json(new { data = listaAsuntoApelacionReconsideracions });
        }

        public ActionResult InsertarAsuntoApelacionReconsideracion(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                AsuntoApelacionReconsideracionDTO AsuntoApelacionReconsideracionDTO = new();
                AsuntoApelacionReconsideracionDTO.DescAsuntoApelacionReconsideracion = Descripcion;
                AsuntoApelacionReconsideracionDTO.CodigoAsuntoApelacionReconsideracion = Codigo;
                AsuntoApelacionReconsideracionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = AsuntoApelacionReconsideracionBL.AgregarAsuntoApelacionReconsideracion(AsuntoApelacionReconsideracionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAsuntoApelacionReconsideracion(int AsuntoApelacionReconsideracionId)
        {
            return Json(AsuntoApelacionReconsideracionBL.BuscarAsuntoApelacionReconsideracionID(AsuntoApelacionReconsideracionId));
        }

        public ActionResult ActualizarAsuntoApelacionReconsideracion(int AsuntoApelacionReconsideracionId, string Codigo, string Descripcion)
        {
            AsuntoApelacionReconsideracionDTO AsuntoApelacionReconsideracionDTO = new();
            AsuntoApelacionReconsideracionDTO.AsuntoApelacionReconsideracionId = AsuntoApelacionReconsideracionId;
            AsuntoApelacionReconsideracionDTO.DescAsuntoApelacionReconsideracion = Descripcion;
            AsuntoApelacionReconsideracionDTO.CodigoAsuntoApelacionReconsideracion = Codigo;
            AsuntoApelacionReconsideracionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AsuntoApelacionReconsideracionBL.ActualizarAsuntoApelacionReconsideracion(AsuntoApelacionReconsideracionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAsuntoApelacionReconsideracion(int AsuntoApelacionReconsideracionId)
        {
            AsuntoApelacionReconsideracionDTO AsuntoApelacionReconsideracionDTO = new();
            AsuntoApelacionReconsideracionDTO.AsuntoApelacionReconsideracionId = AsuntoApelacionReconsideracionId;
            AsuntoApelacionReconsideracionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AsuntoApelacionReconsideracionBL.EliminarAsuntoApelacionReconsideracion(AsuntoApelacionReconsideracionDTO);

            return Content(IND_OPERACION);
        }
    }
}
