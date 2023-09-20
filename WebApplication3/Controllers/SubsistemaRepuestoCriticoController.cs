using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class SubsistemaRepuestoCriticoController : Controller
    {
        readonly ILogger<SubsistemaRepuestoCriticoController> _logger;

        public SubsistemaRepuestoCriticoController(ILogger<SubsistemaRepuestoCriticoController> logger)
        {
            _logger = logger;
        }

        readonly SubsistemaRepuestoCriticoDAO SubsistemaRepuestoCriticoBL = new();
        Usuario usuarioBL = new();

        SistemaRepuestoCriticoDAO SistemaRepuestoCriticoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Subsistemas Repuestos Críticos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<SistemaRepuestoCriticoDTO> SistemaRepuestoCriticoDTO = SistemaRepuestoCriticoBL.ObtenerSistemaRepuestoCriticos();

            return Json(new { data = SistemaRepuestoCriticoDTO });
        }

        public JsonResult CargarDatos()
        {
            List<SubsistemaRepuestoCriticoDTO> listaSubsistemaRepuestoCriticoes = SubsistemaRepuestoCriticoBL.ObtenerSubsistemaRepuestoCriticos();
            return Json(new { data = listaSubsistemaRepuestoCriticoes });
        }

        public ActionResult InsertarSubsistemaRepuestoCritico(string CodigoSubsistemaRepuestoCritico, string Descripcion, string CodigoSistemaRepuestoCritico)
        {
            var IND_OPERACION = "";
            try
            {
                SubsistemaRepuestoCriticoDTO SubsistemaRepuestoCriticoDTO = new();
                SubsistemaRepuestoCriticoDTO.CodigoSubsistemaRepuestoCritico = CodigoSubsistemaRepuestoCritico;
                SubsistemaRepuestoCriticoDTO.DescSubsistemaRepuestoCritico = Descripcion;
                SubsistemaRepuestoCriticoDTO.CodigoSistemaRepuestoCritico = CodigoSistemaRepuestoCritico;
                SubsistemaRepuestoCriticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = SubsistemaRepuestoCriticoBL.AgregarSubsistemaRepuestoCritico(SubsistemaRepuestoCriticoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSubsistemaRepuestoCritico(int SubsistemaRepuestoCriticoId)
        {
            return Json(SubsistemaRepuestoCriticoBL.BuscarSubsistemaRepuestoCriticoID(SubsistemaRepuestoCriticoId));
        }

        public ActionResult ActualizarSubsistemaRepuestoCritico(int SubsistemaRepuestoCriticoId, string CodigoSubsistemaRepuestoCritico, string Descripcion, string CodigoSistemaRepuestoCritico)
        {
            SubsistemaRepuestoCriticoDTO SubsistemaRepuestoCriticoDTO = new();
            SubsistemaRepuestoCriticoDTO.SubsistemaRepuestoCriticoId = SubsistemaRepuestoCriticoId;
            SubsistemaRepuestoCriticoDTO.CodigoSubsistemaRepuestoCritico = CodigoSubsistemaRepuestoCritico;
            SubsistemaRepuestoCriticoDTO.DescSubsistemaRepuestoCritico = Descripcion;
            SubsistemaRepuestoCriticoDTO.CodigoSistemaRepuestoCritico = CodigoSistemaRepuestoCritico;
            SubsistemaRepuestoCriticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = SubsistemaRepuestoCriticoBL.ActualizarSubsistemaRepuestoCritico(SubsistemaRepuestoCriticoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSubsistemaRepuestoCritico(int SubsistemaRepuestoCriticoId)
        {
            SubsistemaRepuestoCriticoDTO SubsistemaRepuestoCriticoDTO = new();
            SubsistemaRepuestoCriticoDTO.SubsistemaRepuestoCriticoId = SubsistemaRepuestoCriticoId;
            SubsistemaRepuestoCriticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = SubsistemaRepuestoCriticoBL.EliminarSubsistemaRepuestoCritico(SubsistemaRepuestoCriticoDTO);

            return Content(IND_OPERACION);
        }
    }
}
