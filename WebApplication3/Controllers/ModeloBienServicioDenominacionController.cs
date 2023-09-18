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
    public class ModeloBienServicioDenominacionController : Controller
    {
        readonly ILogger<ModeloBienServicioDenominacionController> _logger;

        public ModeloBienServicioDenominacionController(ILogger<ModeloBienServicioDenominacionController> logger)
        {
            _logger = logger;
        }

        readonly ModeloBienServicioDenominacionDAO modeloBienServicioDenominacionBL = new();
        Usuario usuarioBL = new();
        ModeloBienServicioSubcampoDAO modeloBienServicioSubcampoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Modelos Bien Servicios Denominaciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<ModeloBienServicioSubcampoDTO> modeloBienServicioSubcampoDTO = modeloBienServicioSubcampoBL.ObtenerModeloBienServicioSubcampos();

            return Json(new { data = modeloBienServicioSubcampoDTO });
        }

        public JsonResult CargarDatos()
        {
            List<ModeloBienServicioDenominacionDTO> listaModeloBienServicioDenominaciones = modeloBienServicioDenominacionBL.ObtenerModeloBienServicioDenominacions();
            return Json(new { data = listaModeloBienServicioDenominaciones });
        }

        public ActionResult InsertarModeloBienServicioDenominacion(string DescModeloBienServicioDenominacion, string CodigoModeloBienServicioDenominacion, int ModeloBienServicioSubcampoId)
        {
            var IND_OPERACION = "";
            try
            {
                ModeloBienServicioDenominacionDTO modeloBienServicioDenominacionDTO = new();
                modeloBienServicioDenominacionDTO.DescModeloBienServicioDenominacion = DescModeloBienServicioDenominacion;
                modeloBienServicioDenominacionDTO.CodigoModeloBienServicioDenominacion = CodigoModeloBienServicioDenominacion;
                modeloBienServicioDenominacionDTO.ModeloBienServicioSubcampoId = ModeloBienServicioSubcampoId;
                modeloBienServicioDenominacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = modeloBienServicioDenominacionBL.AgregarModeloBienServicioDenominacion(modeloBienServicioDenominacionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarModeloBienServicioDenominacion(int ModeloBienServicioDenominacionId)
        {
            return Json(modeloBienServicioDenominacionBL.BuscarModeloBienServicioDenominacionID(ModeloBienServicioDenominacionId));
        }

        public ActionResult ActualizarModeloBienServicioDenominacion(int ModeloBienServicioDenominacionId, string DescModeloBienServicioDenominacion, string CodigoModeloBienServicioDenominacion, int ModeloBienServicioSubcampoId)
        {
            ModeloBienServicioDenominacionDTO modeloBienServicioDenominacionDTO = new();
            modeloBienServicioDenominacionDTO.ModeloBienServicioDenominacionId = ModeloBienServicioDenominacionId;
            modeloBienServicioDenominacionDTO.DescModeloBienServicioDenominacion = DescModeloBienServicioDenominacion;
            modeloBienServicioDenominacionDTO.CodigoModeloBienServicioDenominacion = CodigoModeloBienServicioDenominacion;
            modeloBienServicioDenominacionDTO.ModeloBienServicioSubcampoId = ModeloBienServicioSubcampoId;
            modeloBienServicioDenominacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = modeloBienServicioDenominacionBL.ActualizarModeloBienServicioDenominacion(modeloBienServicioDenominacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarModeloBienServicioDenominacion(int ModeloBienServicioDenominacionId)
        {
            ModeloBienServicioDenominacionDTO modeloBienServicioDenominacionDTO = new();
            modeloBienServicioDenominacionDTO.ModeloBienServicioDenominacionId = ModeloBienServicioDenominacionId;
            modeloBienServicioDenominacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = modeloBienServicioDenominacionBL.EliminarModeloBienServicioDenominacion(modeloBienServicioDenominacionDTO);

            return Content(IND_OPERACION);
        }
    }
}

