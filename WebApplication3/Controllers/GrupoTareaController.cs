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
    public class GrupoTareaController : Controller
    {
        readonly GrupoTareaDAO grupoTareaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Grupos Tareas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<GrupoTareaDTO> listaGrupoTareas = grupoTareaBL.ObtenerGrupoTareas();
            return Json(new { data = listaGrupoTareas });
        }

        public ActionResult InsertarGrupoTarea(string DescGrupoTarea, string CodigoGrupoTarea)
        {
            GrupoTareaDTO grupoTareaDTO = new();
            grupoTareaDTO.DescGrupoTarea = DescGrupoTarea;
            grupoTareaDTO.CodigoGrupoTarea = CodigoGrupoTarea;
            grupoTareaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = grupoTareaBL.AgregarGrupoTarea(grupoTareaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarGrupoTarea(int GrupoTareaId)
        {
            return Json(grupoTareaBL.BuscarGrupoTareaID(GrupoTareaId));
        }

        public ActionResult ActualizarGrupoTarea(int GrupoTareaId, string DescGrupoTarea, string CodigoGrupoTarea)
        {
            GrupoTareaDTO grupoTareaDTO = new();
            grupoTareaDTO.GrupoTareaId = GrupoTareaId;
            grupoTareaDTO.DescGrupoTarea = DescGrupoTarea;
            grupoTareaDTO.CodigoGrupoTarea = CodigoGrupoTarea;
            grupoTareaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = grupoTareaBL.ActualizarGrupoTarea(grupoTareaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarGrupoTarea(int GrupoTareaId)
        {
            string mensaje = "";

            if (grupoTareaBL.EliminarGrupoTarea(GrupoTareaId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
