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
    public class ResultadoInvestigacionController : Controller
    {
        readonly ILogger<ResultadoInvestigacionController> _logger;

        public ResultadoInvestigacionController(ILogger<ResultadoInvestigacionController> logger)
        {
            _logger = logger;
        }

        readonly ResultadoInvestigacionDAO resultadoInvestigacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Resultados Investigaciones", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ResultadoInvestigacionDTO> listaResultadoInvestigacions = resultadoInvestigacionBL.ObtenerResultadoInvestigacions();
            return Json(new { data = listaResultadoInvestigacions });
        }

        public ActionResult InsertarResultadoInvestigacion(string DescResultadoInvestigacion, string CodigoResultadoInvestigacion)
        {
            var IND_OPERACION="";
            try
            {
                ResultadoInvestigacionDTO resultadoInvestigacionDTO = new();
                resultadoInvestigacionDTO.DescResultadoInvestigacion = DescResultadoInvestigacion;
                resultadoInvestigacionDTO.CodigoResultadoInvestigacion = CodigoResultadoInvestigacion;
                resultadoInvestigacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = resultadoInvestigacionBL.AgregarResultadoInvestigacion(resultadoInvestigacionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarResultadoInvestigacion(int ResultadoInvestigacionId)
        {
            return Json(resultadoInvestigacionBL.BuscarResultadoInvestigacionID(ResultadoInvestigacionId));
        }

        public ActionResult ActualizarResultadoInvestigacion(int ResultadoInvestigacionId, string DescResultadoInvestigacion, string CodigoResultadoInvestigacion)
        {
            ResultadoInvestigacionDTO resultadoInvestigacionDTO = new();
            resultadoInvestigacionDTO.ResultadoInvestigacionId = ResultadoInvestigacionId;
            resultadoInvestigacionDTO.DescResultadoInvestigacion = DescResultadoInvestigacion;
            resultadoInvestigacionDTO.CodigoResultadoInvestigacion = CodigoResultadoInvestigacion;
            resultadoInvestigacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = resultadoInvestigacionBL.ActualizarResultadoInvestigacion(resultadoInvestigacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarResultadoInvestigacion(int ResultadoInvestigacionId)
        {
            ResultadoInvestigacionDTO resultadoInvestigacionDTO = new();
            resultadoInvestigacionDTO.ResultadoInvestigacionId = ResultadoInvestigacionId;
            resultadoInvestigacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = resultadoInvestigacionBL.EliminarResultadoInvestigacion(resultadoInvestigacionDTO);

            return Content(IND_OPERACION);
        }
    }
}
