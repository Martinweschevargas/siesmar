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
    public class EjercicioEntrenamientoComfasController : Controller
    {
        readonly ILogger<EjercicioEntrenamientoComfasController> _logger;

        public EjercicioEntrenamientoComfasController(ILogger<EjercicioEntrenamientoComfasController> logger)
        {
            _logger = logger;
        }

        readonly EjercicioEntrenamientoComfasDAO EjercicioEntrenamientoComfasBL = new();
        Usuario usuarioBL = new();

        CapacidadOperativaDAO CapacidadOperativaBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Ejercicios Entrenamientos Comfas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<CapacidadOperativaDTO> CapacidadOperativaDTO = CapacidadOperativaBL.ObtenerCapacidadOperativas();

            return Json(new { data = CapacidadOperativaDTO });
        }

        public JsonResult CargarDatos()
        {
            List<EjercicioEntrenamientoComfasDTO> listaEjercicioEntrenamientoComfases = EjercicioEntrenamientoComfasBL.ObtenerEjercicioEntrenamientoComfass();
            return Json(new { data = listaEjercicioEntrenamientoComfases });
        }

        public ActionResult InsertarEjercicioEntrenamientoComfas(string Descripcion, string Codigo, int CapacidadOperativaId, string NivelEjercicio, int FFMM, int CMM, int DDTT)
        {
            var IND_OPERACION = "";
            try
            {
                EjercicioEntrenamientoComfasDTO EjercicioEntrenamientoComfasDTO = new();
                EjercicioEntrenamientoComfasDTO.CapacidadOperativaId = CapacidadOperativaId;
                EjercicioEntrenamientoComfasDTO.DescEjercicioEntrenamientoComfas = Descripcion;
                EjercicioEntrenamientoComfasDTO.CodigoEjercicioEntrenamientoComfas = Codigo;
                EjercicioEntrenamientoComfasDTO.NivelEjercicio = NivelEjercicio;
                EjercicioEntrenamientoComfasDTO.FFMM = FFMM;
                EjercicioEntrenamientoComfasDTO.CMM = CMM;
                EjercicioEntrenamientoComfasDTO.DDTT = DDTT;
                EjercicioEntrenamientoComfasDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = EjercicioEntrenamientoComfasBL.AgregarEjercicioEntrenamientoComfas(EjercicioEntrenamientoComfasDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEjercicioEntrenamientoComfas(int EjercicioEntrenamientoComfasId)
        {
            return Json(EjercicioEntrenamientoComfasBL.BuscarEjercicioEntrenamientoComfasID(EjercicioEntrenamientoComfasId));
        }

        public ActionResult ActualizarEjercicioEntrenamientoComfas(int EjercicioEntrenamientoComfasId, string Descripcion, string Codigo, int CapacidadOperativaId, string NivelEjercicio, int FFMM, int CMM, int DDTT)
        {
            EjercicioEntrenamientoComfasDTO EjercicioEntrenamientoComfasDTO = new();
            EjercicioEntrenamientoComfasDTO.EjercicioEntrenamientoComfasId = EjercicioEntrenamientoComfasId;
            EjercicioEntrenamientoComfasDTO.CapacidadOperativaId = CapacidadOperativaId;
            EjercicioEntrenamientoComfasDTO.DescEjercicioEntrenamientoComfas = Descripcion;
            EjercicioEntrenamientoComfasDTO.CodigoEjercicioEntrenamientoComfas = Codigo;
            EjercicioEntrenamientoComfasDTO.NivelEjercicio = NivelEjercicio;
            EjercicioEntrenamientoComfasDTO.FFMM = FFMM;
            EjercicioEntrenamientoComfasDTO.CMM = CMM;
            EjercicioEntrenamientoComfasDTO.DDTT = DDTT;
            EjercicioEntrenamientoComfasDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = EjercicioEntrenamientoComfasBL.ActualizarEjercicioEntrenamientoComfas(EjercicioEntrenamientoComfasDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEjercicioEntrenamientoComfas(int EjercicioEntrenamientoComfasId)
        {
            EjercicioEntrenamientoComfasDTO EjercicioEntrenamientoComfasDTO = new();
            EjercicioEntrenamientoComfasDTO.EjercicioEntrenamientoComfasId = EjercicioEntrenamientoComfasId;
            EjercicioEntrenamientoComfasDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = EjercicioEntrenamientoComfasBL.EliminarEjercicioEntrenamientoComfas(EjercicioEntrenamientoComfasDTO);

            return Content(IND_OPERACION);
        }
    }
}
