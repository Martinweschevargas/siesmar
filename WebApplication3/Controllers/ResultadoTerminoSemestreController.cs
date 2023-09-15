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
    public class ResultadoTerminoSemestreController : Controller
    {
        readonly ILogger<ResultadoTerminoSemestreController> _logger;

        public ResultadoTerminoSemestreController(ILogger<ResultadoTerminoSemestreController> logger)
        {
            _logger = logger;
        }

        readonly ResultadoTerminoSemestreDAO resultadoTerminoSemestreBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Resultados Terminos Semestres", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ResultadoTerminoSemestreDTO> listaResultadoTerminoSemestres = resultadoTerminoSemestreBL.ObtenerResultadoTerminoSemestres();
            return Json(new { data = listaResultadoTerminoSemestres });
        }

        public ActionResult InsertarResultadoTerminoSemestre(string DescResultadoTerminoSemestre, string CodigoResultadoTerminoSemestre)
        {
            var IND_OPERACION="";
            try
            {
                ResultadoTerminoSemestreDTO resultadoTerminoSemestreDTO = new();
                resultadoTerminoSemestreDTO.DescResultadoTerminoSemestre = DescResultadoTerminoSemestre;
                resultadoTerminoSemestreDTO.CodigoResultadoTerminoSemestre = CodigoResultadoTerminoSemestre;
                resultadoTerminoSemestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = resultadoTerminoSemestreBL.AgregarResultadoTerminoSemestre(resultadoTerminoSemestreDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarResultadoTerminoSemestre(int ResultadoTerminoSemestreId)
        {
            return Json(resultadoTerminoSemestreBL.BuscarResultadoTerminoSemestreID(ResultadoTerminoSemestreId));
        }

        public ActionResult ActualizarResultadoTerminoSemestre(int ResultadoTerminoSemestreId, string DescResultadoTerminoSemestre, string CodigoResultadoTerminoSemestre)
        {
            ResultadoTerminoSemestreDTO resultadoTerminoSemestreDTO = new();
            resultadoTerminoSemestreDTO.ResultadoTerminoSemestreId = ResultadoTerminoSemestreId;
            resultadoTerminoSemestreDTO.DescResultadoTerminoSemestre = DescResultadoTerminoSemestre;
            resultadoTerminoSemestreDTO.CodigoResultadoTerminoSemestre = CodigoResultadoTerminoSemestre;
            resultadoTerminoSemestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = resultadoTerminoSemestreBL.ActualizarResultadoTerminoSemestre(resultadoTerminoSemestreDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarResultadoTerminoSemestre(int ResultadoTerminoSemestreId)
        {
            ResultadoTerminoSemestreDTO resultadoTerminoSemestreDTO = new();
            resultadoTerminoSemestreDTO.ResultadoTerminoSemestreId = ResultadoTerminoSemestreId;
            resultadoTerminoSemestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = resultadoTerminoSemestreBL.EliminarResultadoTerminoSemestre(resultadoTerminoSemestreDTO);

            return Content(IND_OPERACION);
        }
    }
}
