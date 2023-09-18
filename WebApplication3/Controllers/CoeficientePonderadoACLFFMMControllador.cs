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
    public class CoeficientePonderadoACLFFMMController : Controller
    {
        readonly ILogger<CoeficientePonderadoACLFFMMController> _logger;

        public CoeficientePonderadoACLFFMMController(ILogger<CoeficientePonderadoACLFFMMController> logger)
        {
            _logger = logger;
        }

        readonly CoeficientePonderadoACLFFMMDAO coeficientePonderadoACLFFMMBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Coeficientes Ponderados ACLFFMM", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CoeficientePonderadoACLFFMMDTO> listaCoeficientePonderadoACLFFMMs = coeficientePonderadoACLFFMMBL.ObtenerCoeficientePonderadoACLFFMMs();
            return Json(new { data = listaCoeficientePonderadoACLFFMMs });
        }

        public ActionResult InsertarCoeficientePonderadoACLFFMM(string CombustibleLubricante, int CoeficientePonderacion, int CLExistente, int CLRequerido, int Total)
        {
            var IND_OPERACION = "";
            try
            {
                CoeficientePonderadoACLFFMMDTO coeficientePonderadoACLFFMMDTO = new();
                coeficientePonderadoACLFFMMDTO.CombustibleLubricante = CombustibleLubricante;
                coeficientePonderadoACLFFMMDTO.CoeficientePonderacion = CoeficientePonderacion;
                coeficientePonderadoACLFFMMDTO.CLExistente = CLExistente;
                coeficientePonderadoACLFFMMDTO.CLRequerido = CLRequerido;
                coeficientePonderadoACLFFMMDTO.Total = Total;
                coeficientePonderadoACLFFMMDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = coeficientePonderadoACLFFMMBL.AgregarCoeficientePonderadoACLFFMM(coeficientePonderadoACLFFMMDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCoeficientePonderadoACLFFMM(int CoeficientePonderadoACLFFMMId)
        {
            return Json(coeficientePonderadoACLFFMMBL.BuscarCoeficientePonderadoACLFFMMID(CoeficientePonderadoACLFFMMId));
        }

        public ActionResult ActualizarCoeficientePonderadoACLFFMM(int CoeficientePonderadoACLFFMMId, string CombustibleLubricante, int CoeficientePonderacion, int CLExistente, int CLRequerido, int Total)
        {
            CoeficientePonderadoACLFFMMDTO coeficientePonderadoACLFFMMDTO = new();
            coeficientePonderadoACLFFMMDTO.CoeficientePonderadoACLFFMMId = CoeficientePonderadoACLFFMMId;
            coeficientePonderadoACLFFMMDTO.CombustibleLubricante = CombustibleLubricante;
            coeficientePonderadoACLFFMMDTO.CoeficientePonderacion = CoeficientePonderacion;
            coeficientePonderadoACLFFMMDTO.CLExistente = CLExistente;
            coeficientePonderadoACLFFMMDTO.CLRequerido = CLRequerido;
            coeficientePonderadoACLFFMMDTO.Total = Total;
            coeficientePonderadoACLFFMMDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = coeficientePonderadoACLFFMMBL.ActualizarCoeficientePonderadoACLFFMM(coeficientePonderadoACLFFMMDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCoeficientePonderadoACLFFMM(int CoeficientePonderadoACLFFMMId)
        {
            CoeficientePonderadoACLFFMMDTO coeficientePonderadoACLFFMMDTO = new();
            coeficientePonderadoACLFFMMDTO.CoeficientePonderadoACLFFMMId = CoeficientePonderadoACLFFMMId;
            coeficientePonderadoACLFFMMDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = coeficientePonderadoACLFFMMBL.EliminarCoeficientePonderadoACLFFMM(coeficientePonderadoACLFFMMDTO);

            return Content(IND_OPERACION);
        }
    }
}
