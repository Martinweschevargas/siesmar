using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class PermisoController : Controller
    {
        Permiso permisoBL = new();
        Usuario usuarioBL = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargarDatos()
        {
            List<PermisoDTO> listaPermisos = permisoBL.ObtenerPermisos();
            return Json(listaPermisos);
        }

        public ActionResult InsertarPermiso(string Nombre)
        {
            PermisoDTO permisoDTO = new PermisoDTO();
            permisoDTO.Nombre = Nombre;

            string mensaje = "";
            if (permisoBL.AgregarPermiso(permisoDTO) == true)
                mensaje = "..Permiso Resgistrado..";
            else
                mensaje = "..Permiso No Resgistrado..";

            return Content(mensaje);
        }
        public ActionResult MostrarPermiso(int PermisoId)
        {
            return Json(permisoBL.EditarPermiso(PermisoId));
        }


        public ActionResult ActualizarPermiso(int PermisoId, string Nombre)
        {
            PermisoDTO permisoDTO = new PermisoDTO();

            permisoDTO.PermisoId = PermisoId;
            permisoDTO.Nombre = Nombre;

            string mensaje = "";

            if (permisoBL.ActualizaPermiso(permisoDTO) == true)
                mensaje = "..Permiso Actualizado..";
            else
                mensaje = "..Permiso No Actualizado..";

            return Content(mensaje);
        }

        public ActionResult EliminarPermiso(int PermisoId)
        {
            string mensaje = "";

            if (permisoBL.EliminarPermiso(PermisoId) == true)
                mensaje = "..Permiso Eliminada..";
            else
                mensaje = "..Permiso No Eliminado..";

            return Content(mensaje);
        }

    }

}
