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
    public class CalificativoAsignadoEjercicioController : Controller
    {
        readonly ILogger<CalificativoAsignadoEjercicioController> _logger;

        public CalificativoAsignadoEjercicioController(ILogger<CalificativoAsignadoEjercicioController> logger)
        {
            _logger = logger;
        }

        readonly CalificativoAsignadoEjercicio calificativoAsignadoEjercicioBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Calificativos Asignados Ejercicios", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CalificativoAsignadoEjercicioDTO> listaCalificativoAsignadoEjercicios = calificativoAsignadoEjercicioBL.ObtenerCalificativoAsignadoEjercicios();
            return Json(new { data = listaCalificativoAsignadoEjercicios });
        }

        public ActionResult InsertarCalificativoAsignadoEjercicio(string CodigoCalificativoAsignadoEjercicio, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CalificativoAsignadoEjercicioDTO calificativoAsignadoEjercicioDTO = new();
                calificativoAsignadoEjercicioDTO.Descripcion = Descripcion;
                calificativoAsignadoEjercicioDTO.CodigoCalificativoAsignadoEjercicio = CodigoCalificativoAsignadoEjercicio;
                calificativoAsignadoEjercicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = calificativoAsignadoEjercicioBL.AgregarCalificativoAsignadoEjercicio(calificativoAsignadoEjercicioDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCalificativoAsignadoEjercicio(int CalificativoAsignadoEjercicioId)
        {
            return Json(calificativoAsignadoEjercicioBL.BuscarCalificativoAsignadoEjercicioID(CalificativoAsignadoEjercicioId));
        }

        public ActionResult ActualizarCalificativoAsignadoEjercicio(int CalificativoAsignadoEjercicioId, string CodigoCalificativoAsignadoEjercicio, string Descripcion)
        {
            CalificativoAsignadoEjercicioDTO calificativoAsignadoEjercicioDTO = new();
            calificativoAsignadoEjercicioDTO.CalificativoAsignadoEjercicioId = CalificativoAsignadoEjercicioId;
            calificativoAsignadoEjercicioDTO.Descripcion = Descripcion;
            calificativoAsignadoEjercicioDTO.CodigoCalificativoAsignadoEjercicio = CodigoCalificativoAsignadoEjercicio;
            calificativoAsignadoEjercicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = calificativoAsignadoEjercicioBL.ActualizarCalificativoAsignadoEjercicio(calificativoAsignadoEjercicioDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCalificativoAsignadoEjercicio(int CalificativoAsignadoEjercicioId)
        {
            CalificativoAsignadoEjercicioDTO calificativoAsignadoEjercicioDTO = new();
            calificativoAsignadoEjercicioDTO.CalificativoAsignadoEjercicioId = CalificativoAsignadoEjercicioId;
            calificativoAsignadoEjercicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = calificativoAsignadoEjercicioBL.EliminarCalificativoAsignadoEjercicio(calificativoAsignadoEjercicioDTO);

            return Content(IND_OPERACION);
        }
    }
}
