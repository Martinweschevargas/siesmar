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
    public class RedSocialController : Controller
    {
        readonly ILogger<RedSocialController> _logger;

        public RedSocialController(ILogger<RedSocialController> logger)
        {
            _logger = logger;
        }

        readonly RedSocialDAO capitaniaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Redes Sociales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<RedSocialDTO> listaRedSocials = capitaniaBL.ObtenerRedSocials();
            return Json(new { data = listaRedSocials });
        }

        public ActionResult InsertarRedSocial(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                RedSocialDTO capitaniaDTO = new();
                capitaniaDTO.DescRedSocial = Descripcion;
                capitaniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = capitaniaBL.AgregarRedSocial(capitaniaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarRedSocial(int RedSocialId)
        {
            return Json(capitaniaBL.BuscarRedSocialID(RedSocialId));
        }

        public ActionResult ActualizarRedSocial(int RedSocialId, string Descripcion)
        {
            RedSocialDTO capitaniaDTO = new();
            capitaniaDTO.RedSocialId = RedSocialId;
            capitaniaDTO.DescRedSocial = Descripcion;
            capitaniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capitaniaBL.ActualizarRedSocial(capitaniaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarRedSocial(int RedSocialId)
        {
            RedSocialDTO capitaniaDTO = new();
            capitaniaDTO.RedSocialId = RedSocialId;
            capitaniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capitaniaBL.EliminarRedSocial(capitaniaDTO);

            return Content(IND_OPERACION);
        }
    }
}
