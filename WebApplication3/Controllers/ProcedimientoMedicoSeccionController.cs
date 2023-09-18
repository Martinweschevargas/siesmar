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
    public class ProcedimientoMedicoSeccionController : Controller
    {
        readonly ILogger<ProcedimientoMedicoSeccionController> _logger;

        public ProcedimientoMedicoSeccionController(ILogger<ProcedimientoMedicoSeccionController> logger)
        {
            _logger = logger;
        }

        readonly ProcedimientoMedicoSeccion procedimientoMedicoSeccionBL = new();
        Usuario usuarioBL = new();

        ProcedimientoMedicoGrupo procedimientoMedicoGrupoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Procedimientos Médicos Secciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<ProcedimientoMedicoGrupoDTO> procedimientoMedicoGrupoDTO = procedimientoMedicoGrupoBL.ObtenerProcedimientoMedicoGrupos();

            return Json(new { data = procedimientoMedicoGrupoDTO });
        }

        public JsonResult CargarDatos()
        {
            List<ProcedimientoMedicoSeccionDTO> listaProcedimientoMedicoSecciones = procedimientoMedicoSeccionBL.ObtenerProcedimientoMedicoSeccions();
            return Json(new { data = listaProcedimientoMedicoSecciones });
        }

        public ActionResult InsertarProcedimientoMedicoSeccion(string Descripcion, string Codigo, int ProcedimientoMedicoGrupoId)
        {
            var IND_OPERACION = "";
            try
            {
                ProcedimientoMedicoSeccionDTO procedimientoMedicoSeccionDTO = new();
                procedimientoMedicoSeccionDTO.DescProcedimientoMedicoSeccion = Descripcion;
                procedimientoMedicoSeccionDTO.CodigoProcedimientoMedicoSeccion = Codigo;
                procedimientoMedicoSeccionDTO.ProcedimientoMedicoGrupoId = ProcedimientoMedicoGrupoId;
                procedimientoMedicoSeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = procedimientoMedicoSeccionBL.AgregarProcedimientoMedicoSeccion(procedimientoMedicoSeccionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarProcedimientoMedicoSeccion(int ProcedimientoMedicoSeccionId)
        {
            return Json(procedimientoMedicoSeccionBL.BuscarProcedimientoMedicoSeccionID(ProcedimientoMedicoSeccionId));
        }

        public ActionResult ActualizarProcedimientoMedicoSeccion(int ProcedimientoMedicoSeccionId, string Descripcion, string Codigo, int ProcedimientoMedicoGrupoId)
        {
            ProcedimientoMedicoSeccionDTO procedimientoMedicoSeccionDTO = new();
            procedimientoMedicoSeccionDTO.ProcedimientoMedicoSeccionId = ProcedimientoMedicoSeccionId;
            procedimientoMedicoSeccionDTO.DescProcedimientoMedicoSeccion = Descripcion;
            procedimientoMedicoSeccionDTO.CodigoProcedimientoMedicoSeccion = Codigo;
            procedimientoMedicoSeccionDTO.ProcedimientoMedicoGrupoId = ProcedimientoMedicoGrupoId;
            procedimientoMedicoSeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = procedimientoMedicoSeccionBL.ActualizarProcedimientoMedicoSeccion(procedimientoMedicoSeccionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarProcedimientoMedicoSeccion(int ProcedimientoMedicoSeccionId)
        {
            ProcedimientoMedicoSeccionDTO procedimientoMedicoSeccionDTO = new();
            procedimientoMedicoSeccionDTO.ProcedimientoMedicoSeccionId = ProcedimientoMedicoSeccionId;
            procedimientoMedicoSeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = procedimientoMedicoSeccionBL.EliminarProcedimientoMedicoSeccion(procedimientoMedicoSeccionDTO);

            return Content(IND_OPERACION);
        }
    }
}
