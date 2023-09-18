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
    public class EstadoOperativoController : Controller
    {
        readonly ILogger<EstadoOperativoController> _logger;

        public EstadoOperativoController(ILogger<EstadoOperativoController> logger)
        {
            _logger = logger;
        }

        readonly EstadoOperativo estadoOperativoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Estados Operativos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EstadoOperativoDTO> listaEstadoOperativos = estadoOperativoBL.ObtenerEstadoOperativos();
            return Json(new { data = listaEstadoOperativos });
        }

        public ActionResult InsertarEstadoOperativo(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                EstadoOperativoDTO estadoOperativoDTO = new();
                estadoOperativoDTO.DescEstadoOperativo = Descripcion;
                estadoOperativoDTO.CodigoEstadoOperativo = Codigo;
                estadoOperativoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = estadoOperativoBL.AgregarEstadoOperativo(estadoOperativoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEstadoOperativo(int EstadoOperativoId)
        {
            return Json(estadoOperativoBL.BuscarEstadoOperativoID(EstadoOperativoId));
        }

        public ActionResult ActualizarEstadoOperativo(int EstadoOperativoId, string Codigo, string Descripcion)
        {
            EstadoOperativoDTO estadoOperativoDTO = new();
            estadoOperativoDTO.EstadoOperativoId = EstadoOperativoId;
            estadoOperativoDTO.DescEstadoOperativo = Descripcion;
            estadoOperativoDTO.CodigoEstadoOperativo = Codigo;
            estadoOperativoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = estadoOperativoBL.ActualizarEstadoOperativo(estadoOperativoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEstadoOperativo(int EstadoOperativoId)
        {
            EstadoOperativoDTO estadoOperativoDTO = new();
            estadoOperativoDTO.EstadoOperativoId = EstadoOperativoId;
            estadoOperativoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = estadoOperativoBL.EliminarEstadoOperativo(estadoOperativoDTO);

            return Content(IND_OPERACION);
        }
    }
}
