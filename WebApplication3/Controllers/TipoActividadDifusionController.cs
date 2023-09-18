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
    public class TipoActividadDifusionController : Controller
    {
        readonly ILogger<TipoActividadDifusionController> _logger;

        public TipoActividadDifusionController(ILogger<TipoActividadDifusionController> logger)
        {
            _logger = logger;
        }

        readonly TipoActividadDifusionDAO tipoActividadDifusionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Actividades Difusión", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoActividadDifusionDTO> listaTipoActividadDifusions = tipoActividadDifusionBL.ObtenerTipoActividadDifusions();
            return Json(new { data = listaTipoActividadDifusions });
        }

        public ActionResult InsertarTipoActividadDifusion(string DescTipoActividadDifusion, string CodigoTipoActividadDifusion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoActividadDifusionDTO tipoActividadDifusionDTO = new();
                tipoActividadDifusionDTO.DescTipoActividadDifusion = DescTipoActividadDifusion;
                tipoActividadDifusionDTO.CodigoTipoActividadDifusion = CodigoTipoActividadDifusion;
                tipoActividadDifusionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoActividadDifusionBL.AgregarTipoActividadDifusion(tipoActividadDifusionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoActividadDifusion(int TipoActividadDifusionId)
        {
            return Json(tipoActividadDifusionBL.BuscarTipoActividadDifusionID(TipoActividadDifusionId));
        }

        public ActionResult ActualizarTipoActividadDifusion(int TipoActividadDifusionId, string DescTipoActividadDifusion, string CodigoTipoActividadDifusion)
        {
            TipoActividadDifusionDTO tipoActividadDifusionDTO = new();
            tipoActividadDifusionDTO.TipoActividadDifusionId = TipoActividadDifusionId;
            tipoActividadDifusionDTO.DescTipoActividadDifusion = DescTipoActividadDifusion;
            tipoActividadDifusionDTO.CodigoTipoActividadDifusion = CodigoTipoActividadDifusion;
            tipoActividadDifusionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoActividadDifusionBL.ActualizarTipoActividadDifusion(tipoActividadDifusionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoActividadDifusion(int TipoActividadDifusionId)
        {
            TipoActividadDifusionDTO tipoActividadDifusionDTO = new();
            tipoActividadDifusionDTO.TipoActividadDifusionId = TipoActividadDifusionId;
            tipoActividadDifusionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoActividadDifusionBL.EliminarTipoActividadDifusion(tipoActividadDifusionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}

