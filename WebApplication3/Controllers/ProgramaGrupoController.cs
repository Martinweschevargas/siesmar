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
    public class ProgramaGrupoController : Controller
    {
        readonly ProgramaGrupoDAO programaGrupoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Programas Grupos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ProgramaGrupoDTO> listaProgramaGrupos = programaGrupoBL.ObtenerProgramaGrupos();
            return Json(new { data = listaProgramaGrupos });
        }

        public ActionResult InsertarProgramaGrupo(string DescProgramaGrupo, string CodigoProgramaGrupo)
        {
            ProgramaGrupoDTO programaGrupoDTO = new();
            programaGrupoDTO.DescProgramaGrupo = DescProgramaGrupo;
            programaGrupoDTO.CodigoProgramaGrupo = CodigoProgramaGrupo;
            programaGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = programaGrupoBL.AgregarProgramaGrupo(programaGrupoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarProgramaGrupo(int ProgramaGrupoId)
        {
            return Json(programaGrupoBL.BuscarProgramaGrupoID(ProgramaGrupoId));
        }

        public ActionResult ActualizarProgramaGrupo(int ProgramaGrupoId, string DescProgramaGrupo, string CodigoProgramaGrupo)
        {
            ProgramaGrupoDTO programaGrupoDTO = new();
            programaGrupoDTO.ProgramaGrupoId = ProgramaGrupoId;
            programaGrupoDTO.DescProgramaGrupo = DescProgramaGrupo;
            programaGrupoDTO.CodigoProgramaGrupo = CodigoProgramaGrupo;
            programaGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = programaGrupoBL.ActualizarProgramaGrupo(programaGrupoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarProgramaGrupo(int ProgramaGrupoId)
        {
            ProgramaGrupoDTO programaGrupoDTO = new();
            programaGrupoDTO.ProgramaGrupoId = ProgramaGrupoId;
            programaGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (programaGrupoBL.EliminarProgramaGrupo(programaGrupoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
