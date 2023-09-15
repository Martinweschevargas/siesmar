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
    public class ProgramaEspecializacionEspecificoController : Controller
    {
        readonly ILogger<ProgramaEspecializacionEspecificoController> _logger;

        public ProgramaEspecializacionEspecificoController(ILogger<ProgramaEspecializacionEspecificoController> logger)
        {
            _logger = logger;
        }

        readonly ProgramaEspecializacionEspecifico programaEspecializacionEspecificoBL = new();
        Usuario usuarioBL = new();

        ProgramaEspecializacionGrupo programaEspecializacionGrupoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Programa Especialización Específico", FromController = typeof(HomeController))]
        public IActionResult Index()
        {

            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<ProgramaEspecializacionGrupoDTO> programaEspecializacionGrupoDTO = programaEspecializacionGrupoBL.ObtenerProgramaEspecializacionGrupos();

            return Json(new { data = programaEspecializacionGrupoDTO });
        }

        public JsonResult CargarDatos()
        {
            List<ProgramaEspecializacionEspecificoDTO> listaProgramaEspecializacionEspecificoes = programaEspecializacionEspecificoBL.ObtenerProgramaEspecializacionEspecificos();
            return Json(new { data = listaProgramaEspecializacionEspecificoes });
        }

        public ActionResult InsertarProgramaEspecializacionEspecifico(string Descripcion, string Codigo, int ProgramaEspecializacionGrupoId)
        {
            var IND_OPERACION = "";
            try
            {
                ProgramaEspecializacionEspecificoDTO programaEspecializacionEspecificoDTO = new();
                programaEspecializacionEspecificoDTO.DescProgramaEspecializacionEspecifico = Descripcion;
                programaEspecializacionEspecificoDTO.CodigoProgramaEspecializacionEspecifico = Codigo;
                programaEspecializacionEspecificoDTO.ProgramaEspecializacionGrupoId = ProgramaEspecializacionGrupoId;
                programaEspecializacionEspecificoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = programaEspecializacionEspecificoBL.AgregarProgramaEspecializacionEspecifico(programaEspecializacionEspecificoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarProgramaEspecializacionEspecifico(int ProgramaEspecializacionEspecificoId)
        {
            return Json(programaEspecializacionEspecificoBL.BuscarProgramaEspecializacionEspecificoID(ProgramaEspecializacionEspecificoId));
        }

        public ActionResult ActualizarProgramaEspecializacionEspecifico(int ProgramaEspecializacionEspecificoId, string Descripcion, string Codigo, int ProgramaEspecializacionGrupoId)
        {
            ProgramaEspecializacionEspecificoDTO programaEspecializacionEspecificoDTO = new();
            programaEspecializacionEspecificoDTO.ProgramaEspecializacionEspecificoId = ProgramaEspecializacionEspecificoId;
            programaEspecializacionEspecificoDTO.DescProgramaEspecializacionEspecifico = Descripcion;
            programaEspecializacionEspecificoDTO.CodigoProgramaEspecializacionEspecifico = Codigo;
            programaEspecializacionEspecificoDTO.ProgramaEspecializacionGrupoId = ProgramaEspecializacionGrupoId;
            programaEspecializacionEspecificoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = programaEspecializacionEspecificoBL.ActualizarProgramaEspecializacionEspecifico(programaEspecializacionEspecificoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarProgramaEspecializacionEspecifico(int ProgramaEspecializacionEspecificoId)
        {
            ProgramaEspecializacionEspecificoDTO programaEspecializacionEspecificoDTO = new();
            programaEspecializacionEspecificoDTO.ProgramaEspecializacionEspecificoId = ProgramaEspecializacionEspecificoId;
            programaEspecializacionEspecificoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = programaEspecializacionEspecificoBL.EliminarProgramaEspecializacionEspecifico(programaEspecializacionEspecificoDTO);

            return Content(IND_OPERACION);
        }
    }
}
