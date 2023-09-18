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
    public class GrupoClasificacionEspecialidadController : Controller
    {
        readonly GrupoClasificacionEspecialidadDAO grupoClasificacionEspecialidadBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "GrupoClasificacionEspecialidad", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<GrupoClasificacionEspecialidadDTO> listaGrupoClasificacionEspecialidads = grupoClasificacionEspecialidadBL.ObtenerGrupoClasificacionEspecialidads();
            return Json(new { data = listaGrupoClasificacionEspecialidads });
        }

        public ActionResult InsertarGrupoClasificacionEspecialidad(string DescGrupoClasificacionEspecialidad, string CodigoGrupoClasificacionEspecialidad)
        {
            GrupoClasificacionEspecialidadDTO grupoClasificacionEspecialidadDTO = new();
            grupoClasificacionEspecialidadDTO.DescGrupoClasificacionEspecialidad = DescGrupoClasificacionEspecialidad;
            grupoClasificacionEspecialidadDTO.CodigoGrupoClasificacionEspecialidad = CodigoGrupoClasificacionEspecialidad;
            grupoClasificacionEspecialidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = grupoClasificacionEspecialidadBL.AgregarGrupoClasificacionEspecialidad(grupoClasificacionEspecialidadDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarGrupoClasificacionEspecialidad(int GrupoClasificacionEspecialidadId)
        {
            return Json(grupoClasificacionEspecialidadBL.BuscarGrupoClasificacionEspecialidadID(GrupoClasificacionEspecialidadId));
        }

        public ActionResult ActualizarGrupoClasificacionEspecialidad(int GrupoClasificacionEspecialidadId, string DescGrupoClasificacionEspecialidad, string CodigoGrupoClasificacionEspecialidad)
        {
            GrupoClasificacionEspecialidadDTO grupoClasificacionEspecialidadDTO = new();
            grupoClasificacionEspecialidadDTO.GrupoClasificacionEspecialidadId = GrupoClasificacionEspecialidadId;
            grupoClasificacionEspecialidadDTO.DescGrupoClasificacionEspecialidad = DescGrupoClasificacionEspecialidad;
            grupoClasificacionEspecialidadDTO.CodigoGrupoClasificacionEspecialidad = CodigoGrupoClasificacionEspecialidad;
            grupoClasificacionEspecialidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = grupoClasificacionEspecialidadBL.ActualizarGrupoClasificacionEspecialidad(grupoClasificacionEspecialidadDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarGrupoClasificacionEspecialidad(int GrupoClasificacionEspecialidadId)
        {
            GrupoClasificacionEspecialidadDTO grupoClasificacionEspecialidadDTO = new();
            grupoClasificacionEspecialidadDTO.GrupoClasificacionEspecialidadId = GrupoClasificacionEspecialidadId;
            grupoClasificacionEspecialidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (grupoClasificacionEspecialidadBL.EliminarGrupoClasificacionEspecialidad(grupoClasificacionEspecialidadDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
