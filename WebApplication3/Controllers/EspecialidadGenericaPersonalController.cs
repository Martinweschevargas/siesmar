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
    public class EspecialidadGenericaPersonalController : Controller
    {
        readonly ILogger<EspecialidadGenericaPersonalController> _logger;

        public EspecialidadGenericaPersonalController(ILogger<EspecialidadGenericaPersonalController> logger)
        {
            _logger = logger;
        }

        readonly EspecialidadGenericaPersonalDAO especialidadGenericaPersonalBL = new();
        Usuario usuarioBL = new();
        GradoPersonalMilitarDAO gradoPersonalMilitarBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Especialidades Genericas Personales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();

            return Json(new { data = gradoPersonalMilitarDTO });
        }

        public JsonResult CargarDatos()
        {
            List<EspecialidadGenericaPersonalDTO> listaEspecialidadGenericaPersonales = especialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();
            return Json(new { data = listaEspecialidadGenericaPersonales });
        }

        public ActionResult InsertarEspecialidadGenericaPersonal(string DescEspecialidad, string Abreviatura, string CodigoEspecialidadGenericaPersonal, int GradoPersonalMilitarId)
        {
            var IND_OPERACION = "";
            try
            {
                EspecialidadGenericaPersonalDTO especialidadGenericaPersonalDTO = new();
                especialidadGenericaPersonalDTO.DescEspecialidad = DescEspecialidad;
                especialidadGenericaPersonalDTO.Abreviatura = Abreviatura;
                especialidadGenericaPersonalDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
                especialidadGenericaPersonalDTO.GradoPersonalMilitarId = GradoPersonalMilitarId;
                especialidadGenericaPersonalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = especialidadGenericaPersonalBL.AgregarEspecialidadGenericaPersonal(especialidadGenericaPersonalDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEspecialidadGenericaPersonal(int EspecialidadGenericaPersonalId)
        {
            return Json(especialidadGenericaPersonalBL.BuscarEspecialidadGenericaPersonalID(EspecialidadGenericaPersonalId));
        }

        public ActionResult ActualizarEspecialidadGenericaPersonal(int EspecialidadGenericaPersonalId, string DescEspecialidad, string Abreviatura, string CodigoEspecialidadGenericaPersonal, int GradoPersonalMilitarId)
        {
            EspecialidadGenericaPersonalDTO especialidadGenericaPersonalDTO = new();
            especialidadGenericaPersonalDTO.EspecialidadGenericaPersonalId = EspecialidadGenericaPersonalId;
            especialidadGenericaPersonalDTO.DescEspecialidad = DescEspecialidad;
            especialidadGenericaPersonalDTO.Abreviatura = Abreviatura;
            especialidadGenericaPersonalDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            especialidadGenericaPersonalDTO.GradoPersonalMilitarId = GradoPersonalMilitarId;
            especialidadGenericaPersonalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = especialidadGenericaPersonalBL.ActualizarEspecialidadGenericaPersonal(especialidadGenericaPersonalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEspecialidadGenericaPersonal(int EspecialidadGenericaPersonalId)
        {
            EspecialidadGenericaPersonalDTO especialidadGenericaPersonalDTO = new();
            especialidadGenericaPersonalDTO.EspecialidadGenericaPersonalId = EspecialidadGenericaPersonalId;
            especialidadGenericaPersonalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = especialidadGenericaPersonalBL.EliminarEspecialidadGenericaPersonal(especialidadGenericaPersonalDTO);

            return Content(IND_OPERACION);
        }
    }
}

