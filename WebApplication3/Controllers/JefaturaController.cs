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
    public class JefaturaController : Controller
    {
        readonly ILogger<JefaturaController> _logger;

        public JefaturaController(ILogger<JefaturaController> logger)
        {
            _logger = logger;
        }

        readonly JefaturaDAO jefaturaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Jefaturas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<JefaturaDTO> listaJefaturas = jefaturaBL.ObtenerJefaturas();
            return Json(new { data = listaJefaturas });
        }

        public ActionResult InsertarJefatura(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                JefaturaDTO jefaturaDTO = new();
                jefaturaDTO.DescJefatura = Descripcion;
                jefaturaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = jefaturaBL.AgregarJefatura(jefaturaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarJefatura(int JefaturaId)
        {
            return Json(jefaturaBL.BuscarJefaturaID(JefaturaId));
        }

        public ActionResult ActualizarJefatura(int JefaturaId, string Descripcion)
        {
            JefaturaDTO jefaturaDTO = new();
            jefaturaDTO.JefaturaId = JefaturaId;
            jefaturaDTO.DescJefatura = Descripcion;
            jefaturaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = jefaturaBL.ActualizarJefatura(jefaturaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarJefatura(int JefaturaId)
        {
            JefaturaDTO jefaturaDTO = new();
            jefaturaDTO.JefaturaId = JefaturaId;
            jefaturaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = jefaturaBL.EliminarJefatura(jefaturaDTO);

            return Content(IND_OPERACION);
        }
    }
}
