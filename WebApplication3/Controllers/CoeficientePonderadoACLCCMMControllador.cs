using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class CoeficientePonderadoACLCCMMController : Controller
    {
        readonly ILogger<CoeficientePonderadoACLCCMMController> _logger;

        public CoeficientePonderadoACLCCMMController(ILogger<CoeficientePonderadoACLCCMMController> logger)
        {
            _logger = logger;
        }

        readonly CoeficientePonderadoACLCCMMDAO coeficientePonderadoACLCCMMBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Coeficientes Ponderados ACLCCMM", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CoeficientePonderadoACLCCMMDTO> listaCoeficientePonderadoACLCCMMs = coeficientePonderadoACLCCMMBL.ObtenerCoeficientePonderadoACLCCMMs();
            return Json(new { data = listaCoeficientePonderadoACLCCMMs });
        }

        public ActionResult InsertarCoeficientePonderadoACLCCMM(string CombustibleLubricante, int CoeficientePonderacion, int CLExistente, int CLRequerido, int Total)
        {
            var IND_OPERACION = "";
            try
            {
                CoeficientePonderadoACLCCMMDTO coeficientePonderadoACLCCMMDTO = new();
                coeficientePonderadoACLCCMMDTO.CombustibleLubricante = CombustibleLubricante;
                coeficientePonderadoACLCCMMDTO.CoeficientePonderacion = CoeficientePonderacion;
                coeficientePonderadoACLCCMMDTO.CLExistente = CLExistente;
                coeficientePonderadoACLCCMMDTO.CLRequerido = CLRequerido;
                coeficientePonderadoACLCCMMDTO.Total = Total;
                coeficientePonderadoACLCCMMDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = coeficientePonderadoACLCCMMBL.AgregarCoeficientePonderadoACLCCMM(coeficientePonderadoACLCCMMDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCoeficientePonderadoACLCCMM(int CoeficientePonderadoACLCCMMId)
        {
            return Json(coeficientePonderadoACLCCMMBL.BuscarCoeficientePonderadoACLCCMMID(CoeficientePonderadoACLCCMMId));
        }

        public ActionResult ActualizarCoeficientePonderadoACLCCMM(int CoeficientePonderadoACLCCMMId, string CombustibleLubricante, int CoeficientePonderacion, int CLExistente, int CLRequerido, int Total)
        {
            CoeficientePonderadoACLCCMMDTO coeficientePonderadoACLCCMMDTO = new();
            coeficientePonderadoACLCCMMDTO.CoeficientePonderadoACLCCMMId = CoeficientePonderadoACLCCMMId;
            coeficientePonderadoACLCCMMDTO.CombustibleLubricante = CombustibleLubricante;
            coeficientePonderadoACLCCMMDTO.CoeficientePonderacion = CoeficientePonderacion;
            coeficientePonderadoACLCCMMDTO.CLExistente = CLExistente;
            coeficientePonderadoACLCCMMDTO.CLRequerido = CLRequerido;
            coeficientePonderadoACLCCMMDTO.Total = Total;
            coeficientePonderadoACLCCMMDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = coeficientePonderadoACLCCMMBL.ActualizarCoeficientePonderadoACLCCMM(coeficientePonderadoACLCCMMDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCoeficientePonderadoACLCCMM(int CoeficientePonderadoACLCCMMId)
        {
            CoeficientePonderadoACLCCMMDTO coeficientePonderadoACLCCMMDTO = new();
            coeficientePonderadoACLCCMMDTO.CoeficientePonderadoACLCCMMId = CoeficientePonderadoACLCCMMId;
            coeficientePonderadoACLCCMMDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = coeficientePonderadoACLCCMMBL.EliminarCoeficientePonderadoACLCCMM(coeficientePonderadoACLCCMMDTO);

            return Content(IND_OPERACION);
        }
    }
}
