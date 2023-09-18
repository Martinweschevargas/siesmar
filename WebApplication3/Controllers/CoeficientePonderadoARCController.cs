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
    public class CoeficientePonderadoARCController : Controller
    {
        readonly ILogger<CoeficientePonderadoARCController> _logger;

        public CoeficientePonderadoARCController(ILogger<CoeficientePonderadoARCController> logger)
        {
            _logger = logger;
        }

        readonly CoeficientePonderadoARCDAO coeficientePonderadoARCBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Coeficientes Ponderados ARC", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CoeficientePonderadoARCDTO> listaCoeficientePonderadoARCs = coeficientePonderadoARCBL.ObtenerCoeficientePonderadoARCs();
            return Json(new { data = listaCoeficientePonderadoARCs });
        }

        public ActionResult InsertarCoeficientePonderadoARC(string CapacidadIntrinseca, int CLM, int FM, int CM, int FT, int AUX)
        {
            var IND_OPERACION = "";
            try
            {
                CoeficientePonderadoARCDTO coeficientePonderadoARCDTO = new();
                coeficientePonderadoARCDTO.CapacidadIntrinseca = CapacidadIntrinseca;
                coeficientePonderadoARCDTO.CLM = CLM;
                coeficientePonderadoARCDTO.FM = FM;
                coeficientePonderadoARCDTO.CM = CM;
                coeficientePonderadoARCDTO.FT = FT;
                coeficientePonderadoARCDTO.AUX = AUX;
                coeficientePonderadoARCDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = coeficientePonderadoARCBL.AgregarCoeficientePonderadoARC(coeficientePonderadoARCDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCoeficientePonderadoARC(int CoeficientePonderadoARCId)
        {
            return Json(coeficientePonderadoARCBL.BuscarCoeficientePonderadoARCID(CoeficientePonderadoARCId));
        }

        public ActionResult ActualizarCoeficientePonderadoARC(int CoeficientePonderadoARCId, string CapacidadIntrinseca, int CLM, int FM, int CM, int FT, int AUX)
        {
            CoeficientePonderadoARCDTO coeficientePonderadoARCDTO = new();
            coeficientePonderadoARCDTO.CoeficientePonderadoARCId = CoeficientePonderadoARCId;
            coeficientePonderadoARCDTO.CapacidadIntrinseca = CapacidadIntrinseca;
            coeficientePonderadoARCDTO.CLM = CLM;
            coeficientePonderadoARCDTO.FM = FM;
            coeficientePonderadoARCDTO.CM = CM;
            coeficientePonderadoARCDTO.FT = FT;
            coeficientePonderadoARCDTO.AUX = AUX;
            coeficientePonderadoARCDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = coeficientePonderadoARCBL.ActualizarCoeficientePonderadoARC(coeficientePonderadoARCDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCoeficientePonderadoARC(int CoeficientePonderadoARCId)
        {
            CoeficientePonderadoARCDTO coeficientePonderadoARCDTO = new();
            coeficientePonderadoARCDTO.CoeficientePonderadoARCId = CoeficientePonderadoARCId;
            coeficientePonderadoARCDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = coeficientePonderadoARCBL.EliminarCoeficientePonderadoARC(coeficientePonderadoARCDTO);

            return Content(IND_OPERACION);
        }
    }
}
