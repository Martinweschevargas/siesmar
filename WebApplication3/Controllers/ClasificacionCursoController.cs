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
    public class ClasificacionCursoController : Controller
    {
        readonly ILogger<ClasificacionCursoController> _logger;

        public ClasificacionCursoController(ILogger<ClasificacionCursoController> logger)
        {
            _logger = logger;
        }

        readonly ClasificacionCursoDAO clasificacionCursoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clasificaciones Cursos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClasificacionCursoDTO> listaClasificacionCursos = clasificacionCursoBL.ObtenerClasificacionCursos();
            return Json(new { data = listaClasificacionCursos });
        }

        public ActionResult InsertarClasificacionCurso(string DescClasificacionCurso, string CodigoClasificacionCurso)
        {
            var IND_OPERACION = "";
            try
            {
                ClasificacionCursoDTO clasificacionCursoDTO = new();
                clasificacionCursoDTO.DescClasificacionCurso = DescClasificacionCurso;
                clasificacionCursoDTO.CodigoClasificacionCurso = CodigoClasificacionCurso;
                clasificacionCursoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = clasificacionCursoBL.AgregarClasificacionCurso(clasificacionCursoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClasificacionCurso(int ClasificacionCursoId)
        {
            return Json(clasificacionCursoBL.BuscarClasificacionCursoID(ClasificacionCursoId));
        }

        public ActionResult ActualizarClasificacionCurso(int ClasificacionCursoId, string DescClasificacionCurso, string CodigoClasificacionCurso)
        {
            ClasificacionCursoDTO clasificacionCursoDTO = new();
            clasificacionCursoDTO.ClasificacionCursoId = ClasificacionCursoId;
            clasificacionCursoDTO.DescClasificacionCurso = DescClasificacionCurso;
            clasificacionCursoDTO.CodigoClasificacionCurso = CodigoClasificacionCurso;
            clasificacionCursoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = clasificacionCursoBL.ActualizarClasificacionCurso(clasificacionCursoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClasificacionCurso(int ClasificacionCursoId)
        {
            ClasificacionCursoDTO clasificacionCursoDTO = new();
            clasificacionCursoDTO.ClasificacionCursoId = ClasificacionCursoId;
            clasificacionCursoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = clasificacionCursoBL.EliminarClasificacionCurso(clasificacionCursoDTO);

            return Content(IND_OPERACION);
        }
    }
}
