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
    public class TipoIncidenteSGSIController : Controller
    {
        readonly ILogger<TipoIncidenteSGSIController> _logger;

        public TipoIncidenteSGSIController(ILogger<TipoIncidenteSGSIController> logger)
        {
            _logger = logger;
        }

        readonly TipoIncidenteSGSIDAO tipoIncidenteSGSIBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Incidentes SGSIs", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoIncidenteSGSIDTO> listaTipoIncidenteSGSIs = tipoIncidenteSGSIBL.ObtenerTipoIncidenteSGSIs();
            return Json(new { data = listaTipoIncidenteSGSIs });
        }

        public ActionResult InsertarTipoIncidenteSGSI(string DescTipoIncidenteSGSI, string CodigoTipoIncidenteSGSI)
        {
            var IND_OPERACION="";
            try
            {
                TipoIncidenteSGSIDTO tipoIncidenteSGSIDTO = new();
                tipoIncidenteSGSIDTO.DescTipoIncidenteSGSI = DescTipoIncidenteSGSI;
                tipoIncidenteSGSIDTO.CodigoTipoIncidenteSGSI = CodigoTipoIncidenteSGSI;
                tipoIncidenteSGSIDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoIncidenteSGSIBL.AgregarTipoIncidenteSGSI(tipoIncidenteSGSIDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoIncidenteSGSI(int TipoIncidenteSGSIId)
        {
            return Json(tipoIncidenteSGSIBL.BuscarTipoIncidenteSGSIID(TipoIncidenteSGSIId));
        }

        public ActionResult ActualizarTipoIncidenteSGSI(int TipoIncidenteSGSIId, string DescTipoIncidenteSGSI, string CodigoTipoIncidenteSGSI)
        {
            TipoIncidenteSGSIDTO tipoIncidenteSGSIDTO = new();
            tipoIncidenteSGSIDTO.TipoIncidenteSGSIId = TipoIncidenteSGSIId;
            tipoIncidenteSGSIDTO.DescTipoIncidenteSGSI = DescTipoIncidenteSGSI;
            tipoIncidenteSGSIDTO.CodigoTipoIncidenteSGSI = CodigoTipoIncidenteSGSI;
            tipoIncidenteSGSIDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoIncidenteSGSIBL.ActualizarTipoIncidenteSGSI(tipoIncidenteSGSIDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoIncidenteSGSI(int TipoIncidenteSGSIId)
        {
            TipoIncidenteSGSIDTO tipoIncidenteSGSIDTO = new();
            tipoIncidenteSGSIDTO.TipoIncidenteSGSIId = TipoIncidenteSGSIId;
            tipoIncidenteSGSIDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoIncidenteSGSIBL.EliminarTipoIncidenteSGSI(tipoIncidenteSGSIDTO);

            return Content(IND_OPERACION);
        }
    }
}
