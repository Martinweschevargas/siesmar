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
    public class CoeficientePonderadoAMUFFMMController : Controller
    {
        readonly ILogger<CoeficientePonderadoAMUFFMMController> _logger;

        public CoeficientePonderadoAMUFFMMController(ILogger<CoeficientePonderadoAMUFFMMController> logger)
        {
            _logger = logger;
        }

        readonly CoeficientePonderadoAMUFFMMDAO coeficientePonderadoAMUFFMMBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Coeficientes Ponderados AMUFFMM", FromController = typeof(HomeController))]
        public IActionResult Index()
        {          
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CoeficientePonderadoAMUFFMMDTO> listaCoeficientePonderadoAMUFFMMs = coeficientePonderadoAMUFFMMBL.ObtenerCoeficientePonderadoAMUFFMMs();
            return Json(new { data = listaCoeficientePonderadoAMUFFMMs });
        }

        public ActionResult InsertarCoeficientePonderadoAMUFFMM(string Municion, int CoeficientePonderacion, int ExistenciaMunicion, int MunicionRequerida, int TotalPorcentaje)
        {
            var IND_OPERACION = "";
            try
            {
                CoeficientePonderadoAMUFFMMDTO coeficientePonderadoAMUFFMMDTO = new();
                coeficientePonderadoAMUFFMMDTO.Municion = Municion;
                coeficientePonderadoAMUFFMMDTO.CoeficientePonderacion = CoeficientePonderacion;
                coeficientePonderadoAMUFFMMDTO.ExistenciaMunicion = ExistenciaMunicion;
                coeficientePonderadoAMUFFMMDTO.MunicionRequerida = MunicionRequerida;
                coeficientePonderadoAMUFFMMDTO.TotalPorcentaje = TotalPorcentaje;
                coeficientePonderadoAMUFFMMDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = coeficientePonderadoAMUFFMMBL.AgregarCoeficientePonderadoAMUFFMM(coeficientePonderadoAMUFFMMDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCoeficientePonderadoAMUFFMM(int CoeficientePonderadoAMUFFMMId)
        {
            return Json(coeficientePonderadoAMUFFMMBL.BuscarCoeficientePonderadoAMUFFMMID(CoeficientePonderadoAMUFFMMId));
        }

        public ActionResult ActualizarCoeficientePonderadoAMUFFMM(int CoeficientePonderadoAMUFFMMId, string Municion, int CoeficientePonderacion, int ExistenciaMunicion, int MunicionRequerida, int TotalPorcentaje)
        {
            CoeficientePonderadoAMUFFMMDTO coeficientePonderadoAMUFFMMDTO = new();
            coeficientePonderadoAMUFFMMDTO.CoeficientePonderadoAMUFFMMId = CoeficientePonderadoAMUFFMMId;
            coeficientePonderadoAMUFFMMDTO.Municion = Municion;
            coeficientePonderadoAMUFFMMDTO.CoeficientePonderacion = CoeficientePonderacion;
            coeficientePonderadoAMUFFMMDTO.ExistenciaMunicion = ExistenciaMunicion;
            coeficientePonderadoAMUFFMMDTO.MunicionRequerida = MunicionRequerida;
            coeficientePonderadoAMUFFMMDTO.TotalPorcentaje = TotalPorcentaje;
            coeficientePonderadoAMUFFMMDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = coeficientePonderadoAMUFFMMBL.ActualizarCoeficientePonderadoAMUFFMM(coeficientePonderadoAMUFFMMDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCoeficientePonderadoAMUFFMM(int CoeficientePonderadoAMUFFMMId)
        {
            CoeficientePonderadoAMUFFMMDTO coeficientePonderadoAMUFFMMDTO = new();
            coeficientePonderadoAMUFFMMDTO.CoeficientePonderadoAMUFFMMId = CoeficientePonderadoAMUFFMMId;
            coeficientePonderadoAMUFFMMDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = coeficientePonderadoAMUFFMMBL.EliminarCoeficientePonderadoAMUFFMM(coeficientePonderadoAMUFFMMDTO);

            return Content(IND_OPERACION);
        }
    }
}
