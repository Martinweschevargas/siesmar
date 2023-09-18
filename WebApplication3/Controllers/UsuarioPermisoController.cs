using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class UsuarioPermisoController : Controller
    {
        UsuarioPermiso usuarioPermisoBl = new();
        Usuario usuarioBl = new();
        UsuarioFormato usuarioFormatoBL = new();
        Dependencia dependenciaBl = new();
        DependenciaSubordinado dependenciaSubordinadoBl = new();
        Permiso permisoBl = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargarCombos()
        {
            List<UsuarioDTO> lstUsuarios = null;
            if (User.Identity.IsAuthenticated)
            {
                int RolId = User.obtenerRolId();
                if (RolId == 1)
                    lstUsuarios = usuarioBl.ObtenerUsuarios();
                if (RolId == 2)
                    lstUsuarios = usuarioBl.ObtenerUsuarios(3);
            }
            List<DependenciaDTO> lstDependencias = dependenciaBl.ObtenerDependenciasSegundoNivel();
            List<DependenciaSubordinadoDTO> lstDependenciasSubordinado = dependenciaSubordinadoBl.ObtenerDependenciaSubordinados();
            List<PermisoDTO> lstPermisos = permisoBl.ObtenerPermisos();
            return Json(new { lstPermisos = lstPermisos, lstUsuarios = lstUsuarios, lstDependencia = lstDependencias, lstDependenciasSubordinado = lstDependenciasSubordinado });
        }

        public IActionResult cargarFormatoUsuario(int usuario)
        {
            List<UsuarioFormatoDTO> lstFormatos = usuarioFormatoBL.ObtenerUsuarioFormatos(usuario);
            return Json(new { lstFormatos = lstFormatos });
        }

        public IActionResult cargarTabla()
        {
            List<UsuarioPermisoDTO> lstUsuarioPermisos = usuarioPermisoBl.ObtenerUsuarioPermiso();
            return Json(new { data = lstUsuarioPermisos });
        }

        public ActionResult InsertarUsuarioPermiso(int UsuarioFormatoId, int Permisoid, int Estado)
        {
            UsuarioPermisoDTO usuarioPermisoDTO = new();
            usuarioPermisoDTO.UsuarioFormatoId = UsuarioFormatoId;
            usuarioPermisoDTO.PermisoId = Permisoid;
            usuarioPermisoDTO.EstadoId = Estado;
            usuarioPermisoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = usuarioPermisoBl.AgregarUsuarioPermiso(usuarioPermisoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarUsuarioPermiso(int UsuarioPermisoId)
        {
            return Json(usuarioPermisoBl.EditarUsuarioPermiso(UsuarioPermisoId));
        }

        public ActionResult ActualizarUsuarioPermiso(int Codigo, int UsuarioFormatoId, int Permisoid, int Estado)
        {
            UsuarioPermisoDTO usuarioPermisoDTO = new();

            usuarioPermisoDTO.UsuarioFormatoId = UsuarioFormatoId;
            usuarioPermisoDTO.UsuarioPermisoId = Codigo;
            usuarioPermisoDTO.PermisoId = Permisoid;
            usuarioPermisoDTO.EstadoId = Estado;
            usuarioPermisoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (usuarioPermisoBl.ActualizaUsuarioPermiso(usuarioPermisoDTO) == true)
                mensaje = "..UsuarioRol Actualizada..";
            else
                mensaje = "..UsuarioRol No Actualizada..";

            return Content(mensaje);
        }

        public ActionResult EliminarUsuarioPermiso(int UsuarioPermisoId)
        {
            var IND_OPERACION = "";
            try
            {
                UsuarioPermisoDTO usuarioPermisoDTO = new();
                usuarioPermisoDTO.UsuarioPermisoId = UsuarioPermisoId;
                usuarioPermisoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = usuarioPermisoBl.EliminarUsuarioPermiso(usuarioPermisoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message);
            }
            return Content(IND_OPERACION);
        }

    }

}
