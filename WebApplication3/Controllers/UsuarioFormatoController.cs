using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class UsuarioFormatoController : Controller
    {
        UsuarioFormato usuarioFormatoBL = new();
        Usuario usuariosBL = new();
        FormatoReporte formatoReporteBL = new();
        Dependencia dependenciaBl = new();
        DependenciaSubordinado dependenciaSubordinadoBl = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargarDatos()
        {
            List<UsuarioDTO> lstUsuarios = null;
            if (User.Identity.IsAuthenticated)
            {
                int RolId = User.obtenerRolId();
                if (RolId == 1)
                    lstUsuarios = usuariosBL.ObtenerUsuarios();
                if (RolId == 2)
                    lstUsuarios = usuariosBL.ObtenerUsuarios(3);
            }
            List<FormatoReporteDTO> lstFormatos = formatoReporteBL.ObtenerFormatoReportes();
            List<DependenciaDTO> lstDependencias = dependenciaBl.ObtenerDependenciasSegundoNivel();
            List<DependenciaSubordinadoDTO> lstDependenciasSubordinado = dependenciaSubordinadoBl.ObtenerDependenciaSubordinados();
            return Json(new { lstUsuarios = lstUsuarios, lstFormatos = lstFormatos, lstDependencia = lstDependencias, lstDependenciasSubordinado = lstDependenciasSubordinado });
        }

        public IActionResult cargarTabla()
        {
            List<UsuarioFormatoDTO> listaUsuarioFormatos = usuarioFormatoBL.ObtenerUsuarioFormatos(null);
            return Json(new { data = listaUsuarioFormatos });
        }

        public ActionResult InsertarUsuarioFormato(int Usuario, int Formato)
        {
            var IND_OPERACION = "";
            try
            {
                UsuarioFormatoDTO usuarioFormatoDTO = new UsuarioFormatoDTO();
                usuarioFormatoDTO.UsuarioId = Usuario;
                usuarioFormatoDTO.FormatoId = Formato;
                usuarioFormatoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
                IND_OPERACION = usuarioFormatoBL.AgregarUsuarioFormato(usuarioFormatoDTO);
            }
            catch (Exception ex)
            {

            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarUsuarioFormato(int UsuarioFormatoId)
        {
            return Json(usuarioFormatoBL.EditarUsuarioFormato(UsuarioFormatoId));
        }

        public ActionResult ActualizarUsuarioFormato(int UsuarioFormatoId, int UsuarioId, string FormatoReporteSubordinado)
        {
            var IND_OPERACION = "";
            try
            {
                UsuarioFormatoDTO usuarioFormatoDTO = new UsuarioFormatoDTO();

                usuarioFormatoDTO.UsuarioFormatoId = UsuarioFormatoId;
                usuarioFormatoDTO.UsuarioId = UsuarioId;
                usuarioFormatoDTO.DescDependenciaSubordinado = FormatoReporteSubordinado;

                IND_OPERACION = usuarioFormatoBL.ActualizaUsuarioFormato(usuarioFormatoDTO);
            }
            catch (Exception ex)
            {

            }
            return Content(IND_OPERACION);
        }

        public ActionResult EliminarUsuarioFormato(int UsuarioFormatoId)
        {
            var IND_OPERACION = "";
            try
            {
                UsuarioFormatoDTO usuarioFormatoDTO = new();
                usuarioFormatoDTO.UsuarioFormatoId = UsuarioFormatoId;
                usuarioFormatoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = usuarioFormatoBL.EliminarUsuarioFormato(usuarioFormatoDTO);
            }
            catch (Exception ex)
            {
            }
            return Content(IND_OPERACION);
        }

    }

}
