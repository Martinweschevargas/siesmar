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
    public class TipoNovedadController : Controller
    {
        readonly ILogger<TipoNovedadController> _logger;

        public TipoNovedadController(ILogger<TipoNovedadController> logger)
        {
            _logger = logger;
        }

        readonly TipoNovedadDAO tipoNovedadBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Novedades", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoNovedadDTO> listaTipoNovedads = tipoNovedadBL.ObtenerTipoNovedads();
            return Json(new { data = listaTipoNovedads });
        }

        public ActionResult InsertarTipoNovedad(string DescTipoNovedad, string CodigoTipoNovedad)
        {
            var IND_OPERACION="";
            try
            {
                TipoNovedadDTO tipoNovedadDTO = new();
                tipoNovedadDTO.DescTipoNovedad = DescTipoNovedad;
                tipoNovedadDTO.CodigoTipoNovedad = CodigoTipoNovedad;
                tipoNovedadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoNovedadBL.AgregarTipoNovedad(tipoNovedadDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoNovedad(int TipoNovedadId)
        {
            return Json(tipoNovedadBL.BuscarTipoNovedadID(TipoNovedadId));
        }

        public ActionResult ActualizarTipoNovedad(int TipoNovedadId, string DescTipoNovedad, string CodigoTipoNovedad)
        {
            TipoNovedadDTO tipoNovedadDTO = new();
            tipoNovedadDTO.TipoNovedadId = TipoNovedadId;
            tipoNovedadDTO.DescTipoNovedad = DescTipoNovedad;
            tipoNovedadDTO.CodigoTipoNovedad = CodigoTipoNovedad;
            tipoNovedadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoNovedadBL.ActualizarTipoNovedad(tipoNovedadDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoNovedad(int TipoNovedadId)
        {
            TipoNovedadDTO tipoNovedadDTO = new();
            tipoNovedadDTO.TipoNovedadId = TipoNovedadId;
            tipoNovedadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoNovedadBL.EliminarTipoNovedad(tipoNovedadDTO);

            return Content(IND_OPERACION);
        }
    }
}
