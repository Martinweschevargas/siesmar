using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class EstadoProcesoController : Controller
    {
        readonly ILogger<EstadoProcesoController> _logger;

        public EstadoProcesoController(ILogger<EstadoProcesoController> logger)
        {
            _logger = logger;
        }

        readonly EstadoProcesoDAO EstadoProcesoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "EstadoProcesos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EstadoProcesoDTO> listaEstadoProcesos = EstadoProcesoBL.ObtenerEstadoProcesos();
            return Json(new { data = listaEstadoProcesos });
        }

        public ActionResult InsertarEstadoProceso(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                EstadoProcesoDTO EstadoProcesoDTO = new();
                EstadoProcesoDTO.DescEstadoProceso = Descripcion;
                EstadoProcesoDTO.CodigoEstadoProceso = Codigo;
                EstadoProcesoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = EstadoProcesoBL.AgregarEstadoProceso(EstadoProcesoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEstadoProceso(int EstadoProcesoId)
        {
            return Json(EstadoProcesoBL.BuscarEstadoProcesoID(EstadoProcesoId));
        }

        public ActionResult ActualizarEstadoProceso(int EstadoProcesoId, string Codigo, string Descripcion)
        {
            EstadoProcesoDTO EstadoProcesoDTO = new();
            EstadoProcesoDTO.EstadoProcesoId = EstadoProcesoId;
            EstadoProcesoDTO.DescEstadoProceso = Descripcion;
            EstadoProcesoDTO.CodigoEstadoProceso = Codigo;
            EstadoProcesoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = EstadoProcesoBL.ActualizarEstadoProceso(EstadoProcesoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEstadoProceso(int EstadoProcesoId)
        {
            EstadoProcesoDTO EstadoProcesoDTO = new();
            EstadoProcesoDTO.EstadoProcesoId = EstadoProcesoId;
            EstadoProcesoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = EstadoProcesoBL.EliminarEstadoProceso(EstadoProcesoDTO);

            return Content(IND_OPERACION);
        }
    }
}
