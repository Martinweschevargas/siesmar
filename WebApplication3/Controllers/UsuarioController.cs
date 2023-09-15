using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class UsuarioController : Controller
    {
        Usuario usuarioBL = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargarTabla()
        {
            List<UsuarioDTO> lstUsuarios = usuarioBL.ObtenerUsuarios();
            return Json(new { data = lstUsuarios });
        }

        public ActionResult InsertarUsuario(string Email, string Contrasena, string Dni, int DependenciaId,
            string Nombre, string ApellidoP, string CIP, string ApellidoM, int GradoId, int EspecialidadId, 
            string Foto)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO();
          
            usuarioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";
            if (usuarioBL.AgregarUsuario(usuarioDTO) !="0")
                mensaje = "..Usuario Resgistrado..";
            else
                mensaje = "..Usuario No Resgistrado..";

            return Content(mensaje);
        }
        public ActionResult MostrarUsuario(int UsuarioId)
        {
            return Json(usuarioBL.BuscarUsuarioDNI(UsuarioId));
        }


        public ActionResult ActualizarUsuario(int UsuarioId, string Email, string Contrasena, string Dni,
            int DependenciaId, string Nombre, string ApellidoP, string CIP, string ApellidoM, int GradoId,
            int EspecialidadId,  string Foto)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO();

            usuarioDTO.Id = UsuarioId;
            usuarioDTO.ApellidoPaterno = ApellidoP;
            usuarioDTO.ApellidoMaterno = ApellidoM;
            usuarioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (usuarioBL.ActualizaUsuario(usuarioDTO) == true)
                mensaje = "..Usuario Actualizado..";
            else
                mensaje = "..Usuario No Actualizado..";

            return Content(mensaje);
        }

        public ActionResult EliminarUsuario(int UsuarioId)
        {
            string mensaje = "";

            if (usuarioBL.EliminarUsuario(UsuarioId) == true)
                mensaje = "..Usuario Eliminado..";
            else
                mensaje = "..Usuario No Eliminado..";

            return Content(mensaje);
        }

    }

}
