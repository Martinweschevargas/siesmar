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
    public class ActClimaLaboralGeneralController : Controller
    {
        readonly ILogger<ActClimaLaboralGeneralController> _logger;

        public ActClimaLaboralGeneralController(ILogger<ActClimaLaboralGeneralController> logger)
        {
            _logger = logger;
        }

        readonly ActClimaLaboralGeneral ActClimaLaboralGeneralBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Act Climas Laborales Generales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ActClimaLaboralGeneralDTO> listaActClimaLaboralGenerals = ActClimaLaboralGeneralBL.ObtenerActClimaLaboralGenerals();
            return Json(new { data = listaActClimaLaboralGenerals });
        }

        public ActionResult InsertarActClimaLaboralGeneral(string Descripcion, string CodigoActClimaLaboralGeneral)
        {
            var IND_OPERACION = "";
            try
            {
                ActClimaLaboralGeneralDTO ActClimaLaboralGeneralDTO = new();
                ActClimaLaboralGeneralDTO.DescActClimaLaboralGeneral = Descripcion;
                ActClimaLaboralGeneralDTO.CodigoActClimaLaboralGeneral = CodigoActClimaLaboralGeneral;
                ActClimaLaboralGeneralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ActClimaLaboralGeneralBL.AgregarActClimaLaboralGeneral(ActClimaLaboralGeneralDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarActClimaLaboralGeneral(int ActClimaLaboralGeneralId)
        {
            return Json(ActClimaLaboralGeneralBL.BuscarActClimaLaboralGeneralID(ActClimaLaboralGeneralId));
        }

        public ActionResult ActualizarActClimaLaboralGeneral(int ActClimaLaboralGeneralId, string Descripcion, string CodigoActClimaLaboralGeneral)
        {
            ActClimaLaboralGeneralDTO ActClimaLaboralGeneralDTO = new();
            ActClimaLaboralGeneralDTO.ActClimaLaboralGeneralId = ActClimaLaboralGeneralId;
            ActClimaLaboralGeneralDTO.DescActClimaLaboralGeneral = Descripcion;
            ActClimaLaboralGeneralDTO.CodigoActClimaLaboralGeneral = CodigoActClimaLaboralGeneral;
            ActClimaLaboralGeneralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ActClimaLaboralGeneralBL.ActualizarActClimaLaboralGeneral(ActClimaLaboralGeneralDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarActClimaLaboralGeneral(int ActClimaLaboralGeneralId)
        {
            ActClimaLaboralGeneralDTO ActClimaLaboralGeneralDTO = new();
            ActClimaLaboralGeneralDTO.ActClimaLaboralGeneralId = ActClimaLaboralGeneralId;
            ActClimaLaboralGeneralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ActClimaLaboralGeneralBL.EliminarActClimaLaboralGeneral(ActClimaLaboralGeneralDTO);

            return Content(IND_OPERACION);
        }
    }
}
