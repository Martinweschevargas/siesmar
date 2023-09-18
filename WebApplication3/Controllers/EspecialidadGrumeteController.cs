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
    public class EspecialidadGrumeteController : Controller
    {
        readonly ILogger<EspecialidadGrumeteController> _logger;

        public EspecialidadGrumeteController(ILogger<EspecialidadGrumeteController> logger)
        {
            _logger = logger;
        }

        readonly EspecialidadGrumeteDAO especialidadGrumeteBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Especialidades Grumetes", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EspecialidadGrumeteDTO> listaEspecialidadGrumetes = especialidadGrumeteBL.ObtenerEspecialidadGrumetes();
            return Json(new { data = listaEspecialidadGrumetes });
        }

        public ActionResult InsertarEspecialidadGrumete(string DescEspecialidadGrumete, string CodigoEspecialidadGrumete)
        {
            var IND_OPERACION="";
            try
            {
                EspecialidadGrumeteDTO especialidadGrumeteDTO = new();
                especialidadGrumeteDTO.DescEspecialidadGrumete = DescEspecialidadGrumete;
                especialidadGrumeteDTO.CodigoEspecialidadGrumete = CodigoEspecialidadGrumete;
                especialidadGrumeteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = especialidadGrumeteBL.AgregarEspecialidadGrumete(especialidadGrumeteDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEspecialidadGrumete(int EspecialidadGrumeteId)
        {
            return Json(especialidadGrumeteBL.BuscarEspecialidadGrumeteID(EspecialidadGrumeteId));
        }

        public ActionResult ActualizarEspecialidadGrumete(int EspecialidadGrumeteId, string DescEspecialidadGrumete, string CodigoEspecialidadGrumete)
        {
            EspecialidadGrumeteDTO especialidadGrumeteDTO = new();
            especialidadGrumeteDTO.EspecialidadGrumeteId = EspecialidadGrumeteId;
            especialidadGrumeteDTO.DescEspecialidadGrumete = DescEspecialidadGrumete;
            especialidadGrumeteDTO.CodigoEspecialidadGrumete = CodigoEspecialidadGrumete;
            especialidadGrumeteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = especialidadGrumeteBL.ActualizarEspecialidadGrumete(especialidadGrumeteDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEspecialidadGrumete(int EspecialidadGrumeteId)
        {
            EspecialidadGrumeteDTO especialidadGrumeteDTO = new();
            especialidadGrumeteDTO.EspecialidadGrumeteId = EspecialidadGrumeteId;
            especialidadGrumeteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = especialidadGrumeteBL.EliminarEspecialidadGrumete(especialidadGrumeteDTO);

            return Content(IND_OPERACION);
        }
    }
}
