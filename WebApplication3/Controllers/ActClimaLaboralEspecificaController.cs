using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class ActClimaLaboralEspecificaController : Controller
    {
        readonly ILogger<ActClimaLaboralEspecificaController> _logger;

        public ActClimaLaboralEspecificaController(ILogger<ActClimaLaboralEspecificaController> logger)
        {
            _logger = logger;
        }

        readonly ActClimaLaboralEspecifica actClimaLaboralEspecificaBL = new();
        Usuario usuarioBL = new();

        ActClimaLaboralGeneral actClimaLaboralGeneralBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Act Clima Laboral Específica", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<ActClimaLaboralGeneralDTO> actClimaLaboralGeneralDTO = actClimaLaboralGeneralBL.ObtenerActClimaLaboralGenerals();

            return Json(new { data = actClimaLaboralGeneralDTO });
        }

        public JsonResult CargarDatos()
        {
            List<ActClimaLaboralEspecificaDTO> listaActClimaLaboralEspecificaes = actClimaLaboralEspecificaBL.ObtenerActClimaLaboralEspecificas();
            return Json(new { data = listaActClimaLaboralEspecificaes });
        }

        public ActionResult InsertarActClimaLaboralEspecifica(string Descripcion, string CodigoActClimaLaboralEspecifica, int ActClimaLaboralGeneralId)
        {
            var IND_OPERACION = "";
            try
            {
                ActClimaLaboralEspecificaDTO actClimaLaboralEspecificaDTO = new();
                actClimaLaboralEspecificaDTO.DescActClimaLaboralEspecifica = Descripcion;
                actClimaLaboralEspecificaDTO.CodigoActClimaLaboralEspecifica = CodigoActClimaLaboralEspecifica;
                actClimaLaboralEspecificaDTO.ActClimaLaboralGeneralId = ActClimaLaboralGeneralId;
                actClimaLaboralEspecificaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = actClimaLaboralEspecificaBL.AgregarActClimaLaboralEspecifica(actClimaLaboralEspecificaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarActClimaLaboralEspecifica(int ActClimaLaboralEspecificaId)
        {
            return Json(actClimaLaboralEspecificaBL.BuscarActClimaLaboralEspecificaID(ActClimaLaboralEspecificaId));
        }

        public ActionResult ActualizarActClimaLaboralEspecifica(int ActClimaLaboralEspecificaId, string Descripcion, string CodigoActClimaLaboralEspecifica, int ActClimaLaboralGeneralId)
        {
            ActClimaLaboralEspecificaDTO actClimaLaboralEspecificaDTO = new();
            actClimaLaboralEspecificaDTO.ActClimaLaboralEspecificaId = ActClimaLaboralEspecificaId;
            actClimaLaboralEspecificaDTO.DescActClimaLaboralEspecifica = Descripcion;
            actClimaLaboralEspecificaDTO.CodigoActClimaLaboralEspecifica = CodigoActClimaLaboralEspecifica;
            actClimaLaboralEspecificaDTO.ActClimaLaboralGeneralId = ActClimaLaboralGeneralId;
            actClimaLaboralEspecificaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actClimaLaboralEspecificaBL.ActualizarActClimaLaboralEspecifica(actClimaLaboralEspecificaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarActClimaLaboralEspecifica(int ActClimaLaboralEspecificaId)
        {
            ActClimaLaboralEspecificaDTO actClimaLaboralEspecificaDTO = new();
            actClimaLaboralEspecificaDTO.ActClimaLaboralEspecificaId = ActClimaLaboralEspecificaId;
            actClimaLaboralEspecificaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actClimaLaboralEspecificaBL.EliminarActClimaLaboralEspecifica(actClimaLaboralEspecificaDTO);

            return Content(IND_OPERACION);
        }
    }
}
