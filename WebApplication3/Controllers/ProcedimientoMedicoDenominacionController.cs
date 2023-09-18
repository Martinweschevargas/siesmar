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
    public class ProcedimientoMedicoDenominacionController : Controller
    {
        readonly ILogger<ProcedimientoMedicoDenominacionController> _logger;

        public ProcedimientoMedicoDenominacionController(ILogger<ProcedimientoMedicoDenominacionController> logger)
        {
            _logger = logger;
        }

        readonly ProcedimientoMedicoDenominacion procedimientoMedicoDenominacionBL = new();
        Usuario usuarioBL = new();

        ProcedimientoMedicoSubseccion procedimientoMedicoSubseccionBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Procedimientos Médicos Denominaciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {

            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<ProcedimientoMedicoSubseccionDTO> procedimientoMedicoSubseccionDTO = procedimientoMedicoSubseccionBL.ObtenerProcedimientoMedicoSubseccions();

            return Json(new { data = procedimientoMedicoSubseccionDTO });
        }

        public JsonResult CargarDatos()
        {
            List<ProcedimientoMedicoDenominacionDTO> listaProcedimientoMedicoDenominaciones = procedimientoMedicoDenominacionBL.ObtenerProcedimientoMedicoDenominacions();
            return Json(new { data = listaProcedimientoMedicoDenominaciones });
        }

        public ActionResult InsertarProcedimientoMedicoDenominacion(string Descripcion, string Codigo, int ProcedimientoMedicoSubseccionId)
        {
            var IND_OPERACION = "";
            try
            {
                ProcedimientoMedicoDenominacionDTO procedimientoMedicoDenominacionDTO = new();
                procedimientoMedicoDenominacionDTO.DescProcedimientoMedicoDenominacion = Descripcion;
                procedimientoMedicoDenominacionDTO.CodigoProcedimientoMedicoDenominacion = Codigo;
                procedimientoMedicoDenominacionDTO.ProcedimientoMedicoSubseccionId = ProcedimientoMedicoSubseccionId;
                procedimientoMedicoDenominacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = procedimientoMedicoDenominacionBL.AgregarProcedimientoMedicoDenominacion(procedimientoMedicoDenominacionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarProcedimientoMedicoDenominacion(int ProcedimientoMedicoDenominacionId)
        {
            return Json(procedimientoMedicoDenominacionBL.BuscarProcedimientoMedicoDenominacionID(ProcedimientoMedicoDenominacionId));
        }

        public ActionResult ActualizarProcedimientoMedicoDenominacion(int ProcedimientoMedicoDenominacionId, string Descripcion, string Codigo, int ProcedimientoMedicoSubseccionId)
        {
            ProcedimientoMedicoDenominacionDTO procedimientoMedicoDenominacionDTO = new();
            procedimientoMedicoDenominacionDTO.ProcedimientoMedicoDenominacionId = ProcedimientoMedicoDenominacionId;
            procedimientoMedicoDenominacionDTO.DescProcedimientoMedicoDenominacion = Descripcion;
            procedimientoMedicoDenominacionDTO.CodigoProcedimientoMedicoDenominacion = Codigo;
            procedimientoMedicoDenominacionDTO.ProcedimientoMedicoSubseccionId = ProcedimientoMedicoSubseccionId;
            procedimientoMedicoDenominacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = procedimientoMedicoDenominacionBL.ActualizarProcedimientoMedicoDenominacion(procedimientoMedicoDenominacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarProcedimientoMedicoDenominacion(int ProcedimientoMedicoDenominacionId)
        {
            ProcedimientoMedicoDenominacionDTO procedimientoMedicoDenominacionDTO = new();
            procedimientoMedicoDenominacionDTO.ProcedimientoMedicoDenominacionId = ProcedimientoMedicoDenominacionId;
            procedimientoMedicoDenominacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = procedimientoMedicoDenominacionBL.EliminarProcedimientoMedicoDenominacion(procedimientoMedicoDenominacionDTO);

            return Content(IND_OPERACION);
        }
    }
}
