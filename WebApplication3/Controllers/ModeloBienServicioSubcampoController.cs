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
    public class ModeloBienServicioSubcampoController : Controller
    {
        readonly ILogger<ModeloBienServicioSubcampoController> _logger;

        public ModeloBienServicioSubcampoController(ILogger<ModeloBienServicioSubcampoController> logger)
        {
            _logger = logger;
        }

        readonly ModeloBienServicioSubcampoDAO modeloBienServicioSubcampoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Modelos Bien Servicios Subcampos", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ModeloBienServicioSubcampoDTO> listaModeloBienServicioSubcampos = modeloBienServicioSubcampoBL.ObtenerModeloBienServicioSubcampos();
            return Json(new { data = listaModeloBienServicioSubcampos });
        }

        public ActionResult InsertarModeloBienServicioSubcampo(string DescModeloBienServicioSubcampo, string CodigoModeloBienServicioSubcampo)
        {
            var IND_OPERACION="";
            try
            {
                ModeloBienServicioSubcampoDTO modeloBienServicioSubcampoDTO = new();
                modeloBienServicioSubcampoDTO.DescModeloBienServicioSubcampo = DescModeloBienServicioSubcampo;
                modeloBienServicioSubcampoDTO.CodigoModeloBienServicioSubcampo = CodigoModeloBienServicioSubcampo;
                modeloBienServicioSubcampoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = modeloBienServicioSubcampoBL.AgregarModeloBienServicioSubcampo(modeloBienServicioSubcampoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarModeloBienServicioSubcampo(int ModeloBienServicioSubcampoId)
        {
            return Json(modeloBienServicioSubcampoBL.BuscarModeloBienServicioSubcampoID(ModeloBienServicioSubcampoId));
        }

        public ActionResult ActualizarModeloBienServicioSubcampo(int ModeloBienServicioSubcampoId, string DescModeloBienServicioSubcampo, string CodigoModeloBienServicioSubcampo)
        {
            ModeloBienServicioSubcampoDTO modeloBienServicioSubcampoDTO = new();
            modeloBienServicioSubcampoDTO.ModeloBienServicioSubcampoId = ModeloBienServicioSubcampoId;
            modeloBienServicioSubcampoDTO.DescModeloBienServicioSubcampo = DescModeloBienServicioSubcampo;
            modeloBienServicioSubcampoDTO.CodigoModeloBienServicioSubcampo = CodigoModeloBienServicioSubcampo;
            modeloBienServicioSubcampoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = modeloBienServicioSubcampoBL.ActualizarModeloBienServicioSubcampo(modeloBienServicioSubcampoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarModeloBienServicioSubcampo(int ModeloBienServicioSubcampoId)
        {
            ModeloBienServicioSubcampoDTO modeloBienServicioSubcampoDTO = new();
            modeloBienServicioSubcampoDTO.ModeloBienServicioSubcampoId = ModeloBienServicioSubcampoId;
            modeloBienServicioSubcampoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = modeloBienServicioSubcampoBL.EliminarModeloBienServicioSubcampo(modeloBienServicioSubcampoDTO);

            return Content(IND_OPERACION);
        }
    }
}
