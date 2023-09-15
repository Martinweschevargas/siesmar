using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using MathNet.Numerics.Distributions;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class TipoActividadDenominacionController : Controller
    {
        readonly ILogger<TipoActividadDenominacionController> _logger;

        public TipoActividadDenominacionController(ILogger<TipoActividadDenominacionController> logger)
        {
            _logger = logger;
        }

        readonly TipoActividadDenominacion tipoActividadDenominacionBL = new();
        Usuario usuarioBL = new();

        TipoActividad tipoActividadBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Actividades Denominaciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<TipoActividadDTO> tipoActividadDTO = tipoActividadBL.ObtenerTipoActividads();

            return Json(new { data = tipoActividadDTO });
        }

        public JsonResult CargarDatos()
        {
            List<TipoActividadDenominacionDTO> listaTipoActividadDenominaciones = tipoActividadDenominacionBL.ObtenerTipoActividadDenominacions();
            return Json(new { data = listaTipoActividadDenominaciones });
        }

        public ActionResult InsertarTipoActividadDenominacion(string Descripcion, string Codigo, int TipoActividadId)
        {
            var IND_OPERACION = "";
            try
            {
                TipoActividadDenominacionDTO tipoActividadDenominacionDTO = new();
                tipoActividadDenominacionDTO.DescTipoActividadDenominacion = Descripcion;
                tipoActividadDenominacionDTO.CodigoTipoActividadDenominacion = Codigo;
                tipoActividadDenominacionDTO.TipoActividadId = TipoActividadId;
                tipoActividadDenominacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoActividadDenominacionBL.AgregarTipoActividadDenominacion(tipoActividadDenominacionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoActividadDenominacion(int TipoActividadDenominacionId)
        {
            return Json(tipoActividadDenominacionBL.BuscarTipoActividadDenominacionID(TipoActividadDenominacionId));
        }

        public ActionResult ActualizarTipoActividadDenominacion(int TipoActividadDenominacionId, string Descripcion, string Codigo, int TipoActividadId)
        {
            TipoActividadDenominacionDTO tipoActividadDenominacionDTO = new();
            tipoActividadDenominacionDTO.TipoActividadDenominacionId = TipoActividadDenominacionId;
            tipoActividadDenominacionDTO.DescTipoActividadDenominacion = Descripcion;
            tipoActividadDenominacionDTO.CodigoTipoActividadDenominacion = Codigo;
            tipoActividadDenominacionDTO.TipoActividadId = TipoActividadId;
            tipoActividadDenominacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoActividadDenominacionBL.ActualizarTipoActividadDenominacion(tipoActividadDenominacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoActividadDenominacion(int TipoActividadDenominacionId)
        {
            TipoActividadDenominacionDTO tipoActividadDenominacionDTO = new();
            tipoActividadDenominacionDTO.TipoActividadDenominacionId = TipoActividadDenominacionId;
            tipoActividadDenominacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoActividadDenominacionBL.EliminarTipoActividadDenominacion(tipoActividadDenominacionDTO);

            return Content(IND_OPERACION);
        }
    }
}
