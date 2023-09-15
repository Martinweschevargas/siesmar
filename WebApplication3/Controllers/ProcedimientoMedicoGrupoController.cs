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
    public class ProcedimientoMedicoGrupoController : Controller
    {
        readonly ILogger<ProcedimientoMedicoGrupoController> _logger;

        public ProcedimientoMedicoGrupoController(ILogger<ProcedimientoMedicoGrupoController> logger)
        {
            _logger = logger;
        }

        readonly ProcedimientoMedicoGrupo procedimientoMedicoGrupoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Procedimientos Médicos Grupos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ProcedimientoMedicoGrupoDTO> listaProcedimientoMedicoGrupos = procedimientoMedicoGrupoBL.ObtenerProcedimientoMedicoGrupos();
            return Json(new { data = listaProcedimientoMedicoGrupos });
        }

        public ActionResult InsertarProcedimientoMedicoGrupo(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ProcedimientoMedicoGrupoDTO procedimientoMedicoGrupoDTO = new();
                procedimientoMedicoGrupoDTO.DescProcedimientoMedicoGrupo = Descripcion;
                procedimientoMedicoGrupoDTO.CodigoProcedimientoMedicoGrupo = Codigo;
                procedimientoMedicoGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = procedimientoMedicoGrupoBL.AgregarProcedimientoMedicoGrupo(procedimientoMedicoGrupoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarProcedimientoMedicoGrupo(int ProcedimientoMedicoGrupoId)
        {
            return Json(procedimientoMedicoGrupoBL.BuscarProcedimientoMedicoGrupoID(ProcedimientoMedicoGrupoId));
        }

        public ActionResult ActualizarProcedimientoMedicoGrupo(int ProcedimientoMedicoGrupoId, string Codigo, string Descripcion)
        {
            ProcedimientoMedicoGrupoDTO procedimientoMedicoGrupoDTO = new();
            procedimientoMedicoGrupoDTO.ProcedimientoMedicoGrupoId = ProcedimientoMedicoGrupoId;
            procedimientoMedicoGrupoDTO.DescProcedimientoMedicoGrupo = Descripcion;
            procedimientoMedicoGrupoDTO.CodigoProcedimientoMedicoGrupo = Codigo;
            procedimientoMedicoGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = procedimientoMedicoGrupoBL.ActualizarProcedimientoMedicoGrupo(procedimientoMedicoGrupoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarProcedimientoMedicoGrupo(int ProcedimientoMedicoGrupoId)
        {
            ProcedimientoMedicoGrupoDTO procedimientoMedicoGrupoDTO = new();
            procedimientoMedicoGrupoDTO.ProcedimientoMedicoGrupoId = ProcedimientoMedicoGrupoId;
            procedimientoMedicoGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = procedimientoMedicoGrupoBL.EliminarProcedimientoMedicoGrupo(procedimientoMedicoGrupoDTO);

            return Content(IND_OPERACION);
        }
    }
}
