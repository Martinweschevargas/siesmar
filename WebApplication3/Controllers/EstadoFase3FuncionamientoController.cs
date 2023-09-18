using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class EstadoFase3FuncionamientoController : Controller
    {
        readonly ILogger<EstadoFase3FuncionamientoController> _logger;

        public EstadoFase3FuncionamientoController(ILogger<EstadoFase3FuncionamientoController> logger)
        {
            _logger = logger;
        }

        readonly EstadoFase3Funcionamiento estadoFase3FuncionamientoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Estados Fase 3 Funcionamientos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EstadoFase3FuncionamientoDTO> listaEstadoFase3Funcionamientos = estadoFase3FuncionamientoBL.ObtenerEstadoFase3Funcionamientos();
            return Json(new { data = listaEstadoFase3Funcionamientos });
        }

        public ActionResult InsertarEstadoFase3Funcionamiento(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                EstadoFase3FuncionamientoDTO estadoFase3FuncionamientoDTO = new();
                estadoFase3FuncionamientoDTO.DescEstadoFase3Funcionamiento = Descripcion;
                estadoFase3FuncionamientoDTO.CodigoEstadoFase3Funcionamiento = Codigo;
                estadoFase3FuncionamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = estadoFase3FuncionamientoBL.AgregarEstadoFase3Funcionamiento(estadoFase3FuncionamientoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEstadoFase3Funcionamiento(int EstadoFase3FuncionamientoId)
        {
            return Json(estadoFase3FuncionamientoBL.BuscarEstadoFase3FuncionamientoID(EstadoFase3FuncionamientoId));
        }

        public ActionResult ActualizarEstadoFase3Funcionamiento(int EstadoFase3FuncionamientoId, string Codigo, string Descripcion)
        {
            EstadoFase3FuncionamientoDTO estadoFase3FuncionamientoDTO = new();
            estadoFase3FuncionamientoDTO.EstadoFase3FuncionamientoId = EstadoFase3FuncionamientoId;
            estadoFase3FuncionamientoDTO.DescEstadoFase3Funcionamiento = Descripcion;
            estadoFase3FuncionamientoDTO.CodigoEstadoFase3Funcionamiento = Codigo;
            estadoFase3FuncionamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = estadoFase3FuncionamientoBL.ActualizarEstadoFase3Funcionamiento(estadoFase3FuncionamientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEstadoFase3Funcionamiento(int EstadoFase3FuncionamientoId)
        {
            EstadoFase3FuncionamientoDTO estadoFase3FuncionamientoDTO = new();
            estadoFase3FuncionamientoDTO.EstadoFase3FuncionamientoId = EstadoFase3FuncionamientoId;
            estadoFase3FuncionamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = estadoFase3FuncionamientoBL.EliminarEstadoFase3Funcionamiento(estadoFase3FuncionamientoDTO);

            return Content(IND_OPERACION);
        }
    }
}
