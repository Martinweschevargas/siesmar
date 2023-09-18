using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class GradoPersonalController : Controller
    {
        readonly ILogger<GradoPersonalController> _logger;

        public GradoPersonalController(ILogger<GradoPersonalController> logger)
        {
            _logger = logger;
        }

        readonly GradoPersonalDAO gradoPersonalBL = new();
        EntidadMilitarDAO entidadmilitarBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Grados Personales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult cargaCombs()
        {

            List<EntidadMilitarDTO> entidadMilitarDTO = entidadmilitarBL.ObtenerEntidadMilitars();

            return Json(new{data = entidadMilitarDTO });
        }
        public JsonResult CargarDatos()
        {
            List<GradoPersonalDTO> listaGradoPersonals = gradoPersonalBL.ObtenerGradoPersonals();
            return Json(new { data = listaGradoPersonals });
        }

        public ActionResult InsertarGradoPersonal(string DescGradoPersonal, string CodigoGradoPersonal, string CodigoEntidadMilitar)
        {
            var IND_OPERACION = "";
            try
            {
                GradoPersonalDTO gradoPersonalDTO = new();
                gradoPersonalDTO.DescGradoPersonal = DescGradoPersonal;
                gradoPersonalDTO.CodigoGradoPersonal = CodigoGradoPersonal;
                gradoPersonalDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
                gradoPersonalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = gradoPersonalBL.AgregarGradoPersonal(gradoPersonalDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarGradoPersonal(int GradoPersonalId)
        {
            return Json(gradoPersonalBL.BuscarGradoPersonalID(GradoPersonalId));
        }

        public ActionResult ActualizarGradoPersonal(int GradoPersonalId, string DescGradoPersonal, string CodigoGradoPersonal, string CodigoEntidadMilitar)
        {
            GradoPersonalDTO gradoPersonalDTO = new();
            gradoPersonalDTO.GradoPersonalId = GradoPersonalId;
            gradoPersonalDTO.DescGradoPersonal = DescGradoPersonal;
            gradoPersonalDTO.CodigoGradoPersonal = CodigoGradoPersonal;
            gradoPersonalDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            gradoPersonalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = gradoPersonalBL.ActualizarGradoPersonal(gradoPersonalDTO);
              
            return Content(IND_OPERACION);
        }

        public ActionResult EliminarGradoPersonal(int GradoPersonalId)
        {
            GradoPersonalDTO gradoPersonalDTO = new();
            gradoPersonalDTO.GradoPersonalId = GradoPersonalId;
            gradoPersonalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (gradoPersonalBL.EliminarGradoPersonal(gradoPersonalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
