using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DependenciaSubordinadoController : Controller
    {
        DependenciaSubordinado dependenciaSubordinadoBL = new();
        Usuario usuarioBL = new();
        Dependencia dependenciaBL = new();
        readonly ILogger<DependenciaSubordinadoController> _logger;

        public DependenciaSubordinadoController(ILogger<DependenciaSubordinadoController> logger)
        {
            _logger = logger;
        }

        [Breadcrumb(FromAction = "Index", Title = "Dependencias Subordinados", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargarDatos()
        {
            List<DependenciaSubordinadoDTO> listaDependenciaSubordinados = dependenciaSubordinadoBL.ObtenerDependenciaSubordinados();
            List<DependenciaDTO> listaDependencias = dependenciaBL.ObtenerDependencias();
            return Json(new { data = listaDependenciaSubordinados });
        }

        public ActionResult InsertarDependenciaSubordinado(string Nombre, int DependenciaId, int NivelDependenciaId)
        {
            var IND_OPERACION = "";
            try
            {
                DependenciaSubordinadoDTO dependenciaSubordinadoDTO = new DependenciaSubordinadoDTO();
                dependenciaSubordinadoDTO.Nombre = Nombre;
                dependenciaSubordinadoDTO.DependenciaId = DependenciaId;
                dependenciaSubordinadoDTO.NivelDependenciaId = NivelDependenciaId;
                dependenciaSubordinadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = dependenciaSubordinadoBL.AgregarDependenciaSubordinado(dependenciaSubordinadoDTO);
                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDependenciaSubordinado(int DependenciaSubordinadoId)
        {
            return Json(dependenciaSubordinadoBL.EditarDependenciaSubordinado(DependenciaSubordinadoId));
        }

        public IActionResult cargarDatosDependenciasCB()
        {
            List<DependenciaDTO> listaDependencias = dependenciaBL.ObtenerDependencias();

            return Json(listaDependencias);
        }

        public ActionResult ActualizarDependenciaSubordinado(int DependenciaSubordinadoId, string Nombre, int DependenciaId, int NivelDependenciaId)
        {
            var IND_OPERACION = "";
            try
            {
                DependenciaSubordinadoDTO dependenciaSubordinadoDTO = new DependenciaSubordinadoDTO();

                dependenciaSubordinadoDTO.DependenciaSubordinadoId = DependenciaSubordinadoId;
                dependenciaSubordinadoDTO.Nombre = Nombre;
                dependenciaSubordinadoDTO.DependenciaId = DependenciaId;
                dependenciaSubordinadoDTO.NivelDependenciaId = NivelDependenciaId;
                dependenciaSubordinadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = dependenciaSubordinadoBL.ActualizaDependenciaSubordinado(dependenciaSubordinadoDTO);
                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDependenciaSubordinado(int DependenciaSubordinadoId)
        {
            var IND_OPERACION = "";
            try
            {
                DependenciaSubordinadoDTO dependenciaSubordinadoDTO = new DependenciaSubordinadoDTO();
                dependenciaSubordinadoDTO.DependenciaSubordinadoId = DependenciaSubordinadoId;
                dependenciaSubordinadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = dependenciaSubordinadoBL.EliminarDependenciaSubordinado(dependenciaSubordinadoDTO);
                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Content(IND_OPERACION);
        }

    }

}
