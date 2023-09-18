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
    public class MotivoTerminoCursoController : Controller
    {
        readonly ILogger<MotivoTerminoCursoController> _logger;

        public MotivoTerminoCursoController(ILogger<MotivoTerminoCursoController> logger)
        {
            _logger = logger;
        }

        readonly MotivoTerminoCursoDAO motivoTerminoCursoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Motivos Termino Cursos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MotivoTerminoCursoDTO> listaMotivoTerminoCursos = motivoTerminoCursoBL.ObtenerMotivoTerminoCursos();
            return Json(new { data = listaMotivoTerminoCursos });
        }

        public ActionResult InsertarMotivoTerminoCurso(string DescMotivoTerminoCurso, string CodigoMotivoTerminoCurso)
        {
            var IND_OPERACION = "";
            try
            {
                MotivoTerminoCursoDTO motivoTerminoCursoDTO = new();
                motivoTerminoCursoDTO.DescMotivoTerminoCurso = DescMotivoTerminoCurso;
                motivoTerminoCursoDTO.CodigoMotivoTerminoCurso = CodigoMotivoTerminoCurso;
                motivoTerminoCursoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = motivoTerminoCursoBL.AgregarMotivoTerminoCurso(motivoTerminoCursoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMotivoTerminoCurso(int MotivoTerminoCursoId)
        {
            return Json(motivoTerminoCursoBL.BuscarMotivoTerminoCursoID(MotivoTerminoCursoId));
        }

        public ActionResult ActualizarMotivoTerminoCurso(int MotivoTerminoCursoId, string DescMotivoTerminoCurso, string CodigoMotivoTerminoCurso)
        {
            MotivoTerminoCursoDTO motivoTerminoCursoDTO = new();
            motivoTerminoCursoDTO.MotivoTerminoCursoId = MotivoTerminoCursoId;
            motivoTerminoCursoDTO.DescMotivoTerminoCurso = DescMotivoTerminoCurso;
            motivoTerminoCursoDTO.CodigoMotivoTerminoCurso = CodigoMotivoTerminoCurso;
            motivoTerminoCursoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = motivoTerminoCursoBL.ActualizarMotivoTerminoCurso(motivoTerminoCursoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMotivoTerminoCurso(int MotivoTerminoCursoId)
        {
            MotivoTerminoCursoDTO motivoTerminoCursoDTO = new();
            motivoTerminoCursoDTO.MotivoTerminoCursoId = MotivoTerminoCursoId;
            motivoTerminoCursoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = motivoTerminoCursoBL.EliminarMotivoTerminoCurso(motivoTerminoCursoDTO);

            return Content(IND_OPERACION);
        }
    }
}
