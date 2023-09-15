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
    public class SistemaRepuestoCriticoController : Controller
    {
        readonly ILogger<SistemaRepuestoCriticoController> _logger;

        public SistemaRepuestoCriticoController(ILogger<SistemaRepuestoCriticoController> logger)
        {
            _logger = logger;
        }

        readonly SistemaRepuestoCriticoDAO sistemaRepuestoCriticoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Sistemas Repuestos Críticos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SistemaRepuestoCriticoDTO> listaSistemaRepuestoCriticos = sistemaRepuestoCriticoBL.ObtenerSistemaRepuestoCriticos();
            return Json(new { data = listaSistemaRepuestoCriticos });
        }

        public ActionResult InsertarSistemaRepuestoCritico(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                SistemaRepuestoCriticoDTO sistemaRepuestoCriticoDTO = new();
                sistemaRepuestoCriticoDTO.DescSistemaRepuestoCritico = Descripcion;
                sistemaRepuestoCriticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = sistemaRepuestoCriticoBL.AgregarSistemaRepuestoCritico(sistemaRepuestoCriticoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSistemaRepuestoCritico(int SistemaRepuestoCriticoId)
        {
            return Json(sistemaRepuestoCriticoBL.BuscarSistemaRepuestoCriticoID(SistemaRepuestoCriticoId));
        }

        public ActionResult ActualizarSistemaRepuestoCritico(int SistemaRepuestoCriticoId, string Descripcion)
        {
            SistemaRepuestoCriticoDTO sistemaRepuestoCriticoDTO = new();
            sistemaRepuestoCriticoDTO.SistemaRepuestoCriticoId = SistemaRepuestoCriticoId;
            sistemaRepuestoCriticoDTO.DescSistemaRepuestoCritico = Descripcion;
            sistemaRepuestoCriticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = sistemaRepuestoCriticoBL.ActualizarSistemaRepuestoCritico(sistemaRepuestoCriticoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSistemaRepuestoCritico(int SistemaRepuestoCriticoId)
        {
            SistemaRepuestoCriticoDTO sistemaRepuestoCriticoDTO = new();
            sistemaRepuestoCriticoDTO.SistemaRepuestoCriticoId = SistemaRepuestoCriticoId;
            sistemaRepuestoCriticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = sistemaRepuestoCriticoBL.EliminarSistemaRepuestoCritico(sistemaRepuestoCriticoDTO);

            return Content(IND_OPERACION);
        }
    }
}
