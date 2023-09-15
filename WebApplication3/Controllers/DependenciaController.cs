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
    public class DependenciaController : Controller
    {
        readonly ILogger<DependenciaController> _logger;

        public DependenciaController(ILogger<DependenciaController> logger)
        {
            _logger = logger;
        }

        readonly DependenciaDAO dependenciaBL = new();
        Usuario usuarioBL = new();
        NivelDependenciaDAO nivelDependenciaBl = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Dependencias", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargarCombs()
        {
            List<NivelDependenciaDTO> nivelDependenciaDTO = nivelDependenciaBl.ObtenerNivelDependencias();
            return Json(nivelDependenciaDTO);
        }

        public JsonResult CargarDatos()
        {
            List<DependenciaDTO> listaDependenciaes = dependenciaBL.ObtenerDependencias();
            return Json(new { data = listaDependenciaes });
        }

        public ActionResult InsertarDependencia(string NombreDependencia, string DescDependencia, int NivelDependenciaId, string CodigoDependencia)
        {
            var IND_OPERACION = "";
            try
            {
                DependenciaDTO dependenciaDTO = new();
                dependenciaDTO.NombreDependencia = NombreDependencia;
                dependenciaDTO.DescDependencia = DescDependencia;
                dependenciaDTO.NivelDependenciaId = NivelDependenciaId;
                dependenciaDTO.CodigoDependencia = CodigoDependencia;
                dependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = dependenciaBL.AgregarDependencia(dependenciaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDependencia(int DependenciaId)
        {
            return Json(dependenciaBL.BuscarDependenciaID(DependenciaId));
        }

        public ActionResult ActualizarDependencia(int DependenciaId, string NombreDependencia, string DescDependencia, int NivelDependenciaId, string CodigoDependencia)
        {
            DependenciaDTO dependenciaDTO = new();
            dependenciaDTO.DependenciaId = DependenciaId;
            dependenciaDTO.NombreDependencia = NombreDependencia;
            dependenciaDTO.DescDependencia = DescDependencia;
            dependenciaDTO.NivelDependenciaId = NivelDependenciaId;
            dependenciaDTO.CodigoDependencia = CodigoDependencia;
            dependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = dependenciaBL.ActualizarDependencia(dependenciaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDependencia(int DependenciaId)
        {
            DependenciaDTO dependenciaDTO = new();
            dependenciaDTO.DependenciaId = DependenciaId;
            dependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = dependenciaBL.EliminarDependencia(dependenciaDTO);

            return Content(IND_OPERACION);
        }
    }
}

