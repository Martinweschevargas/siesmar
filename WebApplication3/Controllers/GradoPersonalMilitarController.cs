using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class GradoPersonalMilitarController : Controller
    {
        readonly ILogger<GradoPersonalMilitarController> _logger;

        public GradoPersonalMilitarController(ILogger<GradoPersonalMilitarController> logger)
        {
            _logger = logger;
        }

        readonly GradoPersonalMilitarDAO gradoPersonalMilitarBL = new();
        GradoPersonal gradoPersonalBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Grados Personales Militares", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<GradoPersonalDTO> gradoPersonalDTO = gradoPersonalBL.ObtenerGradoPersonals();
            return Json(new { data = gradoPersonalDTO });
        }

        public JsonResult CargarDatos()
        {
            List<GradoPersonalMilitarDTO> listaGradoPersonalMilitares = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            return Json(new { data = listaGradoPersonalMilitares });
        }

        public ActionResult InsertarGradoPersonalMilitar(string DescGrado, string Abreviatura,string CodigoGradoPersonalMilitar,
            string CodigoGradoPersonal)
        {
            var IND_OPERACION = "";
            try
            {
                GradoPersonalMilitarDTO gradoPersonalMilitarDTO = new();
                gradoPersonalMilitarDTO.DescGrado = DescGrado;
                gradoPersonalMilitarDTO.Abreviatura = Abreviatura;
                gradoPersonalMilitarDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
                gradoPersonalMilitarDTO.CodigoGradoPersonal = CodigoGradoPersonal;
                gradoPersonalMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = gradoPersonalMilitarBL.AgregarGradoPersonalMilitar(gradoPersonalMilitarDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarGradoPersonalMilitar(int GradoPersonalMilitarId)
        {
            return Json(gradoPersonalMilitarBL.BuscarGradoPersonalMilitarID(GradoPersonalMilitarId));
        }

        public ActionResult ActualizarGradoPersonalMilitar(int GradoPersonalMilitarId, string DescGrado, string Abreviatura, 
            string CodigoGradoPersonalMilitar, string CodigoGradoPersonal)
        {
            GradoPersonalMilitarDTO gradoPersonalMilitarDTO = new();
            gradoPersonalMilitarDTO.GradoPersonalMilitarId = GradoPersonalMilitarId;
            gradoPersonalMilitarDTO.DescGrado = DescGrado;
            gradoPersonalMilitarDTO.Abreviatura = Abreviatura;
            gradoPersonalMilitarDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            gradoPersonalMilitarDTO.CodigoGradoPersonal = CodigoGradoPersonal;
            gradoPersonalMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = gradoPersonalMilitarBL.ActualizarGradoPersonalMilitar(gradoPersonalMilitarDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarGradoPersonalMilitar(int GradoPersonalMilitarId)
        {
            GradoPersonalMilitarDTO gradoPersonalMilitarDTO = new();
            gradoPersonalMilitarDTO.GradoPersonalMilitarId = GradoPersonalMilitarId;
            gradoPersonalMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = gradoPersonalMilitarBL.EliminarGradoPersonalMilitar(gradoPersonalMilitarDTO);

            return Content(IND_OPERACION);
        }
    }
}
