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
    public class ProcedimientoMedicoSubseccionController : Controller
    {
        readonly ILogger<ProcedimientoMedicoSubseccionController> _logger;

        public ProcedimientoMedicoSubseccionController(ILogger<ProcedimientoMedicoSubseccionController> logger)
        {
            _logger = logger;
        }

        readonly ProcedimientoMedicoSubseccion procedimientoMedicoSubseccionBL = new();
        Usuario usuarioBL = new();

        ProcedimientoMedicoSeccion procedimientoMedicoSeccionBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Procedimientos Médicos Subsecciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<ProcedimientoMedicoSeccionDTO> procedimientoMedicoSeccionDTO = procedimientoMedicoSeccionBL.ObtenerProcedimientoMedicoSeccions();

            return Json(new { data = procedimientoMedicoSeccionDTO });
        }

        public JsonResult CargarDatos()
        {
            List<ProcedimientoMedicoSubseccionDTO> listaProcedimientoMedicoSubsecciones = procedimientoMedicoSubseccionBL.ObtenerProcedimientoMedicoSubseccions();
            return Json(new { data = listaProcedimientoMedicoSubsecciones });
        }

        public ActionResult InsertarProcedimientoMedicoSubseccion(string Descripcion, string Codigo, int ProcedimientoMedicoSeccionId)
        {
            var IND_OPERACION = "";
            try
            {
                ProcedimientoMedicoSubseccionDTO procedimientoMedicoSubseccionDTO = new();
                procedimientoMedicoSubseccionDTO.DescProcedimientoMedicoSubseccion = Descripcion;
                procedimientoMedicoSubseccionDTO.CodigoProcedimientoMedicoSubseccion = Codigo;
                procedimientoMedicoSubseccionDTO.ProcedimientoMedicoSeccionId = ProcedimientoMedicoSeccionId;
                procedimientoMedicoSubseccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = procedimientoMedicoSubseccionBL.AgregarProcedimientoMedicoSubseccion(procedimientoMedicoSubseccionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarProcedimientoMedicoSubseccion(int ProcedimientoMedicoSubseccionId)
        {
            return Json(procedimientoMedicoSubseccionBL.BuscarProcedimientoMedicoSubseccionID(ProcedimientoMedicoSubseccionId));
        }

        public ActionResult ActualizarProcedimientoMedicoSubseccion(int ProcedimientoMedicoSubseccionId, string Descripcion, string Codigo, int ProcedimientoMedicoSeccionId)
        {
            ProcedimientoMedicoSubseccionDTO procedimientoMedicoSubseccionDTO = new();
            procedimientoMedicoSubseccionDTO.ProcedimientoMedicoSubseccionId = ProcedimientoMedicoSubseccionId;
            procedimientoMedicoSubseccionDTO.DescProcedimientoMedicoSubseccion = Descripcion;
            procedimientoMedicoSubseccionDTO.CodigoProcedimientoMedicoSubseccion = Codigo;
            procedimientoMedicoSubseccionDTO.ProcedimientoMedicoSeccionId = ProcedimientoMedicoSeccionId;
            procedimientoMedicoSubseccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = procedimientoMedicoSubseccionBL.ActualizarProcedimientoMedicoSubseccion(procedimientoMedicoSubseccionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarProcedimientoMedicoSubseccion(int ProcedimientoMedicoSubseccionId)
        {
            ProcedimientoMedicoSubseccionDTO procedimientoMedicoSubseccionDTO = new();
            procedimientoMedicoSubseccionDTO.ProcedimientoMedicoSubseccionId = ProcedimientoMedicoSubseccionId;
            procedimientoMedicoSubseccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = procedimientoMedicoSubseccionBL.EliminarProcedimientoMedicoSubseccion(procedimientoMedicoSubseccionDTO);

            return Content(IND_OPERACION);
        }
    }
}
