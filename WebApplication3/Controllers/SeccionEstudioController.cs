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
    public class SeccionEstudioController : Controller
    {
        readonly ILogger<SeccionEstudioController> _logger;

        public SeccionEstudioController(ILogger<SeccionEstudioController> logger)
        {
            _logger = logger;
        }

        readonly SeccionEstudioDAO SeccionEstudioBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Secciones Estudios", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SeccionEstudioDTO> listaSeccionEstudios = SeccionEstudioBL.ObtenerSeccionEstudios();
            return Json(new { data = listaSeccionEstudios });
        }

        public ActionResult InsertarSeccionEstudio(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                SeccionEstudioDTO SeccionEstudioDTO = new();
                SeccionEstudioDTO.DescSeccionEstudio = Descripcion;
                SeccionEstudioDTO.CodigoSeccionEstudio = Codigo;
                SeccionEstudioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = SeccionEstudioBL.AgregarSeccionEstudio(SeccionEstudioDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSeccionEstudio(int SeccionEstudioId)
        {
            return Json(SeccionEstudioBL.BuscarSeccionEstudioID(SeccionEstudioId));
        }

        public ActionResult ActualizarSeccionEstudio(int SeccionEstudioId, string Codigo, string Descripcion)
        {
            SeccionEstudioDTO SeccionEstudioDTO = new();
            SeccionEstudioDTO.SeccionEstudioId = SeccionEstudioId;
            SeccionEstudioDTO.DescSeccionEstudio = Descripcion;
            SeccionEstudioDTO.CodigoSeccionEstudio = Codigo;
            SeccionEstudioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = SeccionEstudioBL.ActualizarSeccionEstudio(SeccionEstudioDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSeccionEstudio(int SeccionEstudioId)
        {
            SeccionEstudioDTO SeccionEstudioDTO = new();
            SeccionEstudioDTO.SeccionEstudioId = SeccionEstudioId;
            SeccionEstudioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = SeccionEstudioBL.EliminarSeccionEstudio(SeccionEstudioDTO);

            return Content(IND_OPERACION);
        }
    }
}
