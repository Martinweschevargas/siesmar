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

        readonly AlistamientoRepuestoCritico AlistamientoRepuestoCriticoBL = new();
        Usuario usuarioBL = new();

        SistemaRepuestoCritico SistemaRepuestoCriticoBL = new();
        SubsistemaRepuestoCritico SubsistemaRepuestoCriticoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Alistamientos Repuestos Críticos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           return View();
        }


        [HttpGet]
        public IActionResult cargaCombsSistemas()
        {

            List<SistemaRepuestoCriticoDTO> sistemaRepuestoCriticoDTO = SistemaRepuestoCriticoBL.ObtenerSistemaRepuestoCriticos();
            List<SubsistemaRepuestoCriticoDTO> subsistemaRepuestoCriticoDTO = SubsistemaRepuestoCriticoBL.ObtenerSubsistemaRepuestoCriticos();

            return Json(new
            {
                data1 = sistemaRepuestoCriticoDTO,
                data2 = subsistemaRepuestoCriticoDTO
            });
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
                AlistamientoRepuestoCriticoDTO alistamientoRepuestoCriticoDTO = new();
                alistamientoRepuestoCriticoDTO.CodigoAlistamientoRepuestoCritico = CodigoAlistamientoRepuestoCritico;
                alistamientoRepuestoCriticoDTO.CodigoSistemaRepuestoCritico = CodigoSistemaRepuestoCritico;
                alistamientoRepuestoCriticoDTO.CodigoSubsistemaRepuestoCritico = CodigoSubsistemaRepuestoCritico;
                alistamientoRepuestoCriticoDTO.Equipo = Equipo;
                alistamientoRepuestoCriticoDTO.Repuesto = Repuesto;
                alistamientoRepuestoCriticoDTO.Existente = Existente;
                alistamientoRepuestoCriticoDTO.Necesario = Necesario;
                alistamientoRepuestoCriticoDTO.CoeficientePonderacion = Coeficiente;
                alistamientoRepuestoCriticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = AlistamientoRepuestoCriticoBL.AgregarAlistamientoRepuestoCritico(alistamientoRepuestoCriticoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAlistamientoRepuestoCritico(int Id)
        {
            return Json(AlistamientoRepuestoCriticoBL.BuscarAlistamientoRepuestoCriticoID(Id));
        }

        public ActionResult ActualizarAlistamientoRepuestoCritico(int Id, string CodigoAlistamientoRepuestoCritico, string CodigoSistemaRepuestoCritico, string CodigoSubsistemaRepuestoCritico, string Equipo, string Repuesto, string Existente, string Necesario, string Coeficiente)
        {
            AlistamientoRepuestoCriticoDTO alistamientoRepuestoCriticoDTO = new();
            alistamientoRepuestoCriticoDTO.AlistamientoRepuestoCriticoId = Id;
            alistamientoRepuestoCriticoDTO.CodigoAlistamientoRepuestoCritico = CodigoAlistamientoRepuestoCritico;
            alistamientoRepuestoCriticoDTO.CodigoSistemaRepuestoCritico = CodigoSistemaRepuestoCritico;
            alistamientoRepuestoCriticoDTO.CodigoSubsistemaRepuestoCritico = CodigoSubsistemaRepuestoCritico;
            alistamientoRepuestoCriticoDTO.Equipo = Equipo;
            alistamientoRepuestoCriticoDTO.Repuesto = Repuesto;
            alistamientoRepuestoCriticoDTO.Existente = Existente;
            alistamientoRepuestoCriticoDTO.Necesario = Necesario;
            alistamientoRepuestoCriticoDTO.CoeficientePonderacion = Coeficiente;
            alistamientoRepuestoCriticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AlistamientoRepuestoCriticoBL.ActualizarAlistamientoRepuestoCritico(alistamientoRepuestoCriticoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAlistamientoRepuestoCritico(int Id)
        {
            AlistamientoRepuestoCriticoDTO alistamientoRepuestoCriticoDTO = new();
            alistamientoRepuestoCriticoDTO.AlistamientoRepuestoCriticoId = Id;
            alistamientoRepuestoCriticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AlistamientoRepuestoCriticoBL.EliminarAlistamientoRepuestoCritico(alistamientoRepuestoCriticoDTO);

            return Content(IND_OPERACION);
        }
    }
}
