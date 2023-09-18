using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class ProcedenciaController : Controller
    {
        readonly ILogger<ProcedenciaController> _logger;

        public ProcedenciaController(ILogger<ProcedenciaController> logger)
        {
            _logger = logger;
        }

        readonly ProcedenciaDAO procedenciaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Procedencias", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ProcedenciaDTO> listaProcedencias = procedenciaBL.ObtenerProcedencias();
            return Json(new { data = listaProcedencias });
        }

        public ActionResult InsertarProcedencia(string CodigoProcedencia, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                ProcedenciaDTO procedenciaDTO = new();
                procedenciaDTO.CodigoProcedencia = CodigoProcedencia;
                procedenciaDTO.DescProcedencia = Descripcion;
                procedenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = procedenciaBL.AgregarProcedencia(procedenciaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarProcedencia(int ProcedenciaId)
        {
            return Json(procedenciaBL.BuscarProcedenciaID(ProcedenciaId));
        }

        public ActionResult ActualizarProcedencia(int ProcedenciaId,string CodigoProcedencia,  string Descripcion)
        {
            ProcedenciaDTO procedenciaDTO = new();
            procedenciaDTO.ProcedenciaId = ProcedenciaId;
            procedenciaDTO.CodigoProcedencia = CodigoProcedencia;
            procedenciaDTO.DescProcedencia = Descripcion;
            procedenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = procedenciaBL.ActualizarProcedencia(procedenciaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarProcedencia(int ProcedenciaId)
        {
            ProcedenciaDTO procedenciaDTO = new();
            procedenciaDTO.ProcedenciaId = ProcedenciaId;
            procedenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = procedenciaBL.EliminarProcedencia(procedenciaDTO);

            return Content(IND_OPERACION);
        }
    }
}
