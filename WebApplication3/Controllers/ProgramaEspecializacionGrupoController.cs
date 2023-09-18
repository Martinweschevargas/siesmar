using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class ProgramaEspecializacionGrupoController : Controller
    {
        readonly ILogger<ProgramaEspecializacionGrupoController> _logger;

        public ProgramaEspecializacionGrupoController(ILogger<ProgramaEspecializacionGrupoController> logger)
        {
            _logger = logger;
        }

        readonly ProgramaEspecializacionGrupo programaEspecializacionGrupoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Programas Especializaciones Grupos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ProgramaEspecializacionGrupoDTO> listaProgramaEspecializacionGrupos = programaEspecializacionGrupoBL.ObtenerProgramaEspecializacionGrupos();
            return Json(new { data = listaProgramaEspecializacionGrupos });
        }

        public ActionResult InsertarProgramaEspecializacionGrupo(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ProgramaEspecializacionGrupoDTO programaEspecializacionGrupoDTO = new();
                programaEspecializacionGrupoDTO.DescProgramaEspecializacionGrupo = Descripcion;
                programaEspecializacionGrupoDTO.CodigoProgramaEspecializacionGrupo = Codigo;
                programaEspecializacionGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = programaEspecializacionGrupoBL.AgregarProgramaEspecializacionGrupo(programaEspecializacionGrupoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarProgramaEspecializacionGrupo(int ProgramaEspecializacionGrupoId)
        {
            return Json(programaEspecializacionGrupoBL.BuscarProgramaEspecializacionGrupoID(ProgramaEspecializacionGrupoId));
        }

        public ActionResult ActualizarProgramaEspecializacionGrupo(int ProgramaEspecializacionGrupoId, string Codigo, string Descripcion)
        {
            ProgramaEspecializacionGrupoDTO programaEspecializacionGrupoDTO = new();
            programaEspecializacionGrupoDTO.ProgramaEspecializacionGrupoId = ProgramaEspecializacionGrupoId;
            programaEspecializacionGrupoDTO.DescProgramaEspecializacionGrupo = Descripcion;
            programaEspecializacionGrupoDTO.CodigoProgramaEspecializacionGrupo = Codigo;
            programaEspecializacionGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = programaEspecializacionGrupoBL.ActualizarProgramaEspecializacionGrupo(programaEspecializacionGrupoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarProgramaEspecializacionGrupo(int ProgramaEspecializacionGrupoId)
        {
            ProgramaEspecializacionGrupoDTO programaEspecializacionGrupoDTO = new();
            programaEspecializacionGrupoDTO.ProgramaEspecializacionGrupoId = ProgramaEspecializacionGrupoId;
            programaEspecializacionGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = programaEspecializacionGrupoBL.EliminarProgramaEspecializacionGrupo(programaEspecializacionGrupoDTO);

            return Content(IND_OPERACION);
        }
    }
}
