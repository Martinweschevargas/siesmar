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
    public class CoeficientePonderadoAMUCCMMController : Controller
    {
        readonly ILogger<CoeficientePonderadoAMUCCMMController> _logger;

        public CoeficientePonderadoAMUCCMMController(ILogger<CoeficientePonderadoAMUCCMMController> logger)
        {
            _logger = logger;
        }

        readonly CoeficientePonderadoAMUCCMMDAO coeficientePonderadoAMUCCMMBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Coeficientes Ponderados AMUCCMM", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CoeficientePonderadoAMUCCMMDTO> listaCoeficientePonderadoAMUCCMMs = coeficientePonderadoAMUCCMMBL.ObtenerCoeficientePonderadoAMUCCMMs();
            return Json(new { data = listaCoeficientePonderadoAMUCCMMs });
        }

        public ActionResult InsertarCoeficientePonderadoAMUCCMM(string Municion, int CoeficientePonderacion, int ExistenciaMunicion, int MunicionRequerida, int TotalPorcentaje)
        {
            var IND_OPERACION = "";
            try
            {
                CoeficientePonderadoAMUCCMMDTO coeficientePonderadoAMUCCMMDTO = new();
                coeficientePonderadoAMUCCMMDTO.Municion = Municion;
                coeficientePonderadoAMUCCMMDTO.CoeficientePonderacion = CoeficientePonderacion;
                coeficientePonderadoAMUCCMMDTO.ExistenciaMunicion = ExistenciaMunicion;
                coeficientePonderadoAMUCCMMDTO.MunicionRequerida = MunicionRequerida;
                coeficientePonderadoAMUCCMMDTO.TotalPorcentaje = TotalPorcentaje;
                coeficientePonderadoAMUCCMMDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = coeficientePonderadoAMUCCMMBL.AgregarCoeficientePonderadoAMUCCMM(coeficientePonderadoAMUCCMMDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCoeficientePonderadoAMUCCMM(int CoeficientePonderadoAMUCCMMId)
        {
            return Json(coeficientePonderadoAMUCCMMBL.BuscarCoeficientePonderadoAMUCCMMID(CoeficientePonderadoAMUCCMMId));
        }

        public ActionResult ActualizarCoeficientePonderadoAMUCCMM(int CoeficientePonderadoAMUCCMMId, string Municion, int CoeficientePonderacion, int ExistenciaMunicion, int MunicionRequerida, int TotalPorcentaje)
        {
            CoeficientePonderadoAMUCCMMDTO coeficientePonderadoAMUCCMMDTO = new();
            coeficientePonderadoAMUCCMMDTO.CoeficientePonderadoAMUCCMMId = CoeficientePonderadoAMUCCMMId;
            coeficientePonderadoAMUCCMMDTO.Municion = Municion;
            coeficientePonderadoAMUCCMMDTO.CoeficientePonderacion = CoeficientePonderacion;
            coeficientePonderadoAMUCCMMDTO.ExistenciaMunicion = ExistenciaMunicion;
            coeficientePonderadoAMUCCMMDTO.MunicionRequerida = MunicionRequerida;
            coeficientePonderadoAMUCCMMDTO.TotalPorcentaje = TotalPorcentaje;
            coeficientePonderadoAMUCCMMDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = coeficientePonderadoAMUCCMMBL.ActualizarCoeficientePonderadoAMUCCMM(coeficientePonderadoAMUCCMMDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCoeficientePonderadoAMUCCMM(int CoeficientePonderadoAMUCCMMId)
        {
            CoeficientePonderadoAMUCCMMDTO coeficientePonderadoAMUCCMMDTO = new();
            coeficientePonderadoAMUCCMMDTO.CoeficientePonderadoAMUCCMMId = CoeficientePonderadoAMUCCMMId;
            coeficientePonderadoAMUCCMMDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = coeficientePonderadoAMUCCMMBL.EliminarCoeficientePonderadoAMUCCMM(coeficientePonderadoAMUCCMMDTO);

            return Content(IND_OPERACION);
        }
    }
}
