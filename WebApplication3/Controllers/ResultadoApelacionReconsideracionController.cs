using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class ResultadoApelacionReconsideracionController : Controller
    {
        readonly ILogger<ResultadoApelacionReconsideracionController> _logger;

        public ResultadoApelacionReconsideracionController(ILogger<ResultadoApelacionReconsideracionController> logger)
        {
            _logger = logger;
        }

        readonly ResultadoApelacionReconsideracionDAO resultadoApelacionReconsideracionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Resultados Apelaciones Reconsideraciones", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ResultadoApelacionReconsideracionDTO> listaResultadoApelacionReconsideracions = resultadoApelacionReconsideracionBL.ObtenerResultadoApelacionReconsideracions();
            return Json(new { data = listaResultadoApelacionReconsideracions });
        }

        public ActionResult InsertarResultadoApelacionReconsideracion(string DescResultadoApelacionReconsideracion, string CodigoResultadoApelacionReconsideracion)
        {
            var IND_OPERACION="";
            try
            {
                ResultadoApelacionReconsideracionDTO resultadoApelacionReconsideracionDTO = new();
                resultadoApelacionReconsideracionDTO.DescResultadoApelacionReconsideracion = DescResultadoApelacionReconsideracion;
                resultadoApelacionReconsideracionDTO.CodigoResultadoApelacionReconsideracion = CodigoResultadoApelacionReconsideracion;
                resultadoApelacionReconsideracionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = resultadoApelacionReconsideracionBL.AgregarResultadoApelacionReconsideracion(resultadoApelacionReconsideracionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarResultadoApelacionReconsideracion(int ResultadoApelacionReconsideracionId)
        {
            return Json(resultadoApelacionReconsideracionBL.BuscarResultadoApelacionReconsideracionID(ResultadoApelacionReconsideracionId));
        }

        public ActionResult ActualizarResultadoApelacionReconsideracion(int ResultadoApelacionReconsideracionId, string DescResultadoApelacionReconsideracion, string CodigoResultadoApelacionReconsideracion)
        {
            ResultadoApelacionReconsideracionDTO resultadoApelacionReconsideracionDTO = new();
            resultadoApelacionReconsideracionDTO.ResultadoApelacionReconsideracionId = ResultadoApelacionReconsideracionId;
            resultadoApelacionReconsideracionDTO.DescResultadoApelacionReconsideracion = DescResultadoApelacionReconsideracion;
            resultadoApelacionReconsideracionDTO.CodigoResultadoApelacionReconsideracion = CodigoResultadoApelacionReconsideracion;
            resultadoApelacionReconsideracionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = resultadoApelacionReconsideracionBL.ActualizarResultadoApelacionReconsideracion(resultadoApelacionReconsideracionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarResultadoApelacionReconsideracion(int ResultadoApelacionReconsideracionId)
        {
            ResultadoApelacionReconsideracionDTO resultadoApelacionReconsideracionDTO = new();
            resultadoApelacionReconsideracionDTO.ResultadoApelacionReconsideracionId = ResultadoApelacionReconsideracionId;
            resultadoApelacionReconsideracionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = resultadoApelacionReconsideracionBL.EliminarResultadoApelacionReconsideracion(resultadoApelacionReconsideracionDTO);

            return Content(IND_OPERACION);
        }
    }
}
