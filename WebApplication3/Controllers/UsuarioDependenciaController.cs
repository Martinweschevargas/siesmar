using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Microsoft.AspNetCore.Mvc;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class UsuarioDependenciaController : Controller
    {        
        UsuarioDependencia usuarioDependenciaBL = new();
        Usuario usuariosBL = new();
        Dependencia dependenciaBl = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargarDatos()
        {
            List<UsuarioDTO> lstUsuarios = usuariosBL.ObtenerUsuarios();
            List<DependenciaDTO> lstDependencias = dependenciaBl.ObtenerDependenciasSegundoNivel();
            return Json(new {lstUsuarios = lstUsuarios, lstDependencias = lstDependencias });
        }

        public IActionResult cargarTabla()
        {
            List<UsuarioDependenciaDTO> lstUsuarioDependencias = usuarioDependenciaBL.ObtenerUsuarioDependencia();
            return Json(new { data = lstUsuarioDependencias });
        }

        public ActionResult InsertarUsuarioDependencia(int UsuarioId, int DependenciaId)
        {
            UsuarioDependenciaDTO usuarioDependenciaDTO = new();
            usuarioDependenciaDTO.UsuarioId = UsuarioId;
            usuarioDependenciaDTO.Dependencia = DependenciaId;

            var IND_OPERACION = usuarioDependenciaBL.AgregarUsuarioDependencia(usuarioDependenciaDTO);

            return Content(IND_OPERACION);
        }
        public ActionResult MostrarUsuarioDependencia(int UsuarioDependenciaId)
        {
            return Json(usuarioDependenciaBL.EditarUsuarioDependencia(UsuarioDependenciaId));
        }

        public ActionResult ActualizarUsuarioDependencia(int UsuarioDependenciaId, int UsuarioId, int DependenciaId)
        {
            UsuarioDependenciaDTO usuarioDependenciaDTO = new();
            usuarioDependenciaDTO.UsuarioDependenciaId = UsuarioDependenciaId;
            usuarioDependenciaDTO.UsuarioId = UsuarioId;
            usuarioDependenciaDTO.Dependencia = DependenciaId;

            var IND_OPERACION = usuarioDependenciaBL.ActualizarUsuarioDependencia(usuarioDependenciaDTO);

            return Content(IND_OPERACION);
        }
        public ActionResult EliminarUsuarioDependencia(int UsuarioDependenciaId)
        {
            var IND_OPERACION = usuarioDependenciaBL.EliminarUsuarioDependencia(UsuarioDependenciaId);

            return Content(IND_OPERACION);
        }
    }

}
