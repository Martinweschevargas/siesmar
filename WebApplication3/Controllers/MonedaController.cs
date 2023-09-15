using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class MonedaController : Controller
    {
        readonly ILogger<MonedaController> _logger;

        public MonedaController(ILogger<MonedaController> logger)
        {
            _logger = logger;
        }

        readonly MonedaDAO monedaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Monedas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MonedaDTO> listaMonedas = monedaBL.ObtenerMonedas();
            return Json(new { data = listaMonedas });
        }

        public ActionResult InsertarMoneda(string DescMoneda, string CodigoMoneda)
        {
            var IND_OPERACION = "";
            try
            {
                MonedaDTO monedaDTO = new();
                monedaDTO.DescMoneda = DescMoneda;
                monedaDTO.CodigoMoneda = CodigoMoneda;
                monedaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = monedaBL.AgregarMoneda(monedaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMoneda(int MonedaId)
        {
            return Json(monedaBL.BuscarMonedaID(MonedaId));
        }

        public ActionResult ActualizarMoneda(int MonedaId, string DescMoneda, string CodigoMoneda)
        {
            MonedaDTO monedaDTO = new();
            monedaDTO.MonedaId = MonedaId;
            monedaDTO.DescMoneda = DescMoneda;
            monedaDTO.CodigoMoneda = CodigoMoneda;
            monedaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = monedaBL.ActualizarMoneda(monedaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMoneda(int MonedaId)
        {
            MonedaDTO monedaDTO = new();
            monedaDTO.MonedaId = MonedaId;
            monedaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = monedaBL.EliminarMoneda(monedaDTO);

            return Content(IND_OPERACION);
        }
    }
}
