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
    public class ModalidadVentaController : Controller
    {
        readonly ILogger<ModalidadVentaController> _logger;

        public ModalidadVentaController(ILogger<ModalidadVentaController> logger)
        {
            _logger = logger;
        }

        readonly ModalidadVentaDAO ModalidadVentaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Modalidades Ventas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ModalidadVentaDTO> listaModalidadVentas = ModalidadVentaBL.ObtenerModalidadVentas();
            return Json(new { data = listaModalidadVentas });
        }

        public ActionResult InsertarModalidadVenta(string CodigoModalidadVenta, string DescModalidadVenta)
        {
            var IND_OPERACION = "";
            try
            {
                ModalidadVentaDTO ModalidadVentaDTO = new();
                ModalidadVentaDTO.DescModalidadVenta = DescModalidadVenta;
                ModalidadVentaDTO.CodigoModalidadVenta = CodigoModalidadVenta;
                ModalidadVentaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ModalidadVentaBL.AgregarModalidadVenta(ModalidadVentaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarModalidadVenta(int ModalidadVentaId)
        {
            return Json(ModalidadVentaBL.BuscarModalidadVentaID(ModalidadVentaId));
        }

        public ActionResult ActualizarModalidadVenta(int ModalidadVentaId, string CodigoModalidadVenta, string DescModalidadVenta)
        {
            ModalidadVentaDTO ModalidadVentaDTO = new();
            ModalidadVentaDTO.ModalidadVentaId = ModalidadVentaId;
            ModalidadVentaDTO.DescModalidadVenta = DescModalidadVenta;
            ModalidadVentaDTO.CodigoModalidadVenta = CodigoModalidadVenta;
            ModalidadVentaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ModalidadVentaBL.ActualizarModalidadVenta(ModalidadVentaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarModalidadVenta(int ModalidadVentaId)
        {
            ModalidadVentaDTO ModalidadVentaDTO = new();
            ModalidadVentaDTO.ModalidadVentaId = ModalidadVentaId;
            ModalidadVentaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ModalidadVentaBL.EliminarModalidadVenta(ModalidadVentaDTO);

            return Content(IND_OPERACION);
        }
    }
}
