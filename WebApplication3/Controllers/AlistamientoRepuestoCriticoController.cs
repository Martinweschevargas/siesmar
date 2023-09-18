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
    public class AlistamientoRepuestoCriticoController : Controller
    {
        readonly ILogger<AlistamientoRepuestoCriticoController> _logger;

        public AlistamientoRepuestoCriticoController(ILogger<AlistamientoRepuestoCriticoController> logger)
        {
            _logger = logger;
        }

        readonly AlistamientoRepuestoCriticoDAO AlistamientoRepuestoCriticoBL = new();
        Usuario usuarioBL = new();

        SistemaRepuestoCriticoDAO SistemaRepuestoCriticoBL = new();
        SubsistemaRepuestoCriticoDAO SubsistemaRepuestoCriticoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Alistamientos Repuestos Críticos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           return View();
        }


        [HttpGet]
        public IActionResult cargaCombsSistemas()
        {

            List<SistemaRepuestoCriticoDTO> SistemaRepuestoCriticoDTO = SistemaRepuestoCriticoBL.ObtenerSistemaRepuestoCriticos();

            return Json(new { data = SistemaRepuestoCriticoDTO });
        }

        [HttpGet]
        public IActionResult cargaCombsSubsistemas()
        {

            List<SubsistemaRepuestoCriticoDTO> SubsistemaRepuestoCriticoDTO = SubsistemaRepuestoCriticoBL.ObtenerSubsistemaRepuestoCriticos();

            return Json(new { data = SubsistemaRepuestoCriticoDTO });
        }

        public JsonResult CargarDatos()
        {
            List<AlistamientoRepuestoCriticoDTO> listaAlistamientoRepuestoCriticoes = AlistamientoRepuestoCriticoBL.ObtenerAlistamientoRepuestoCriticos();
            return Json(new { data = listaAlistamientoRepuestoCriticoes });
        }

        public ActionResult InsertarAlistamientoRepuestoCritico(string CodigoAlistamientoRepuestoCritico, string CodigoSistemaRepuestoCritico, string CodigoSubsistemaRepuestoCritico, string Equipo, string Repuesto, string Existente, string Necesario, string Coeficiente)
        {
            var IND_OPERACION = "";
            try
            {
                AlistamientoRepuestoCriticoDTO AlistamientoRepuestoCriticoDTO = new();
                AlistamientoRepuestoCriticoDTO.CodigoAlistamientoRepuestoCritico = CodigoAlistamientoRepuestoCritico;
                AlistamientoRepuestoCriticoDTO.CodigoSistemaRepuestoCritico = CodigoSistemaRepuestoCritico;
                AlistamientoRepuestoCriticoDTO.CodigoSubsistemaRepuestoCritico = CodigoSubsistemaRepuestoCritico;
                AlistamientoRepuestoCriticoDTO.Equipo = Equipo;
                AlistamientoRepuestoCriticoDTO.Repuesto = Repuesto;
                AlistamientoRepuestoCriticoDTO.Existente = Existente;
                AlistamientoRepuestoCriticoDTO.Necesario = Necesario;
                AlistamientoRepuestoCriticoDTO.CoeficientePonderacion = Coeficiente;
                AlistamientoRepuestoCriticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = AlistamientoRepuestoCriticoBL.AgregarAlistamientoRepuestoCritico(AlistamientoRepuestoCriticoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAlistamientoRepuestoCritico(int AlistamientoRepuestoCriticoId)
        {
            return Json(AlistamientoRepuestoCriticoBL.BuscarAlistamientoRepuestoCriticoID(AlistamientoRepuestoCriticoId));
        }

        public ActionResult ActualizarAlistamientoRepuestoCritico(int AlistamientoRepuestoCriticoId, string CodigoAlistamientoRepuestoCritico, string CodigoSistemaRepuestoCritico, string CodigoSubsistemaRepuestoCritico, string Equipo, string Repuesto, string Existente, string Necesario, string Coeficiente)
        {
            AlistamientoRepuestoCriticoDTO AlistamientoRepuestoCriticoDTO = new();
            AlistamientoRepuestoCriticoDTO.AlistamientoRepuestoCriticoId = AlistamientoRepuestoCriticoId;
            AlistamientoRepuestoCriticoDTO.CodigoAlistamientoRepuestoCritico = CodigoAlistamientoRepuestoCritico;
            AlistamientoRepuestoCriticoDTO.CodigoSistemaRepuestoCritico = CodigoSistemaRepuestoCritico;
            AlistamientoRepuestoCriticoDTO.CodigoSubsistemaRepuestoCritico = CodigoSubsistemaRepuestoCritico;
            AlistamientoRepuestoCriticoDTO.Equipo = Equipo;
            AlistamientoRepuestoCriticoDTO.Repuesto = Repuesto;
            AlistamientoRepuestoCriticoDTO.Existente = Existente;
            AlistamientoRepuestoCriticoDTO.Necesario = Necesario;
            AlistamientoRepuestoCriticoDTO.CoeficientePonderacion = Coeficiente;
            AlistamientoRepuestoCriticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AlistamientoRepuestoCriticoBL.ActualizarAlistamientoRepuestoCritico(AlistamientoRepuestoCriticoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAlistamientoRepuestoCritico(int AlistamientoRepuestoCriticoId)
        {
            AlistamientoRepuestoCriticoDTO AlistamientoRepuestoCriticoDTO = new();
            AlistamientoRepuestoCriticoDTO.AlistamientoRepuestoCriticoId = AlistamientoRepuestoCriticoId;
            AlistamientoRepuestoCriticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AlistamientoRepuestoCriticoBL.EliminarAlistamientoRepuestoCritico(AlistamientoRepuestoCriticoDTO);

            return Content(IND_OPERACION);
        }
    }
}
