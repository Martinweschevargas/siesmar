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
    public class TipoEstudioInvestigacionController : Controller
    {
        readonly ILogger<TipoEstudioInvestigacionController> _logger;

        public TipoEstudioInvestigacionController(ILogger<TipoEstudioInvestigacionController> logger)
        {
            _logger = logger;
        }

        readonly TipoEstudioInvestigacionDAO tipoEstudioInvestigacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Estudios Investigaciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoEstudioInvestigacionDTO> listaTipoEstudioInvestigacions = tipoEstudioInvestigacionBL.ObtenerTipoEstudioInvestigacions();
            return Json(new { data = listaTipoEstudioInvestigacions });
        }

        public ActionResult InsertarTipoEstudioInvestigacion(string DescTipoEstudioInvestigacion, string CodigoTipoEstudioInvestigacion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoEstudioInvestigacionDTO tipoEstudioInvestigacionDTO = new();
                tipoEstudioInvestigacionDTO.DescTipoEstudioInvestigacion = DescTipoEstudioInvestigacion;
                tipoEstudioInvestigacionDTO.CodigoTipoEstudioInvestigacion = CodigoTipoEstudioInvestigacion;
                tipoEstudioInvestigacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoEstudioInvestigacionBL.AgregarTipoEstudioInvestigacion(tipoEstudioInvestigacionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoEstudioInvestigacion(int TipoEstudioInvestigacionId)
        {
            return Json(tipoEstudioInvestigacionBL.BuscarTipoEstudioInvestigacionID(TipoEstudioInvestigacionId));
        }

        public ActionResult ActualizarTipoEstudioInvestigacion(int TipoEstudioInvestigacionId, string DescTipoEstudioInvestigacion, string CodigoTipoEstudioInvestigacion)
        {
            TipoEstudioInvestigacionDTO tipoEstudioInvestigacionDTO = new();
            tipoEstudioInvestigacionDTO.TipoEstudioInvestigacionId = TipoEstudioInvestigacionId;
            tipoEstudioInvestigacionDTO.DescTipoEstudioInvestigacion = DescTipoEstudioInvestigacion;
            tipoEstudioInvestigacionDTO.CodigoTipoEstudioInvestigacion = CodigoTipoEstudioInvestigacion;
            tipoEstudioInvestigacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoEstudioInvestigacionBL.ActualizarTipoEstudioInvestigacion(tipoEstudioInvestigacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoEstudioInvestigacion(int TipoEstudioInvestigacionId)
        {
            TipoEstudioInvestigacionDTO tipoEstudioInvestigacionDTO = new();
            tipoEstudioInvestigacionDTO.TipoEstudioInvestigacionId = TipoEstudioInvestigacionId;
            tipoEstudioInvestigacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoEstudioInvestigacionBL.EliminarTipoEstudioInvestigacion(tipoEstudioInvestigacionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}

