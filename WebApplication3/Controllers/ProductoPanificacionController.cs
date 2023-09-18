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
    public class ProductoPanificacionController : Controller
    {
        readonly ILogger<ProductoPanificacionController> _logger;

        public ProductoPanificacionController(ILogger<ProductoPanificacionController> logger)
        {
            _logger = logger;
        }

        readonly ProductoPanificacionDAO productoPanificacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "ProductoPanificacion", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ProductoPanificacionDTO> listaProductoPanificacion = productoPanificacionBL.ObtenerProductos();
            return Json(new { data = listaProductoPanificacion });
        }

        public ActionResult InsertarProducto(string DescProductoPanificacion, string CodigoProductoPanificacion)
        {
            var IND_OPERACION = "";
            try
            {
                ProductoPanificacionDTO productoPanificacionDTO = new();
                productoPanificacionDTO.DescProductoPanificacion = DescProductoPanificacion;
                productoPanificacionDTO.CodigoProductoPanificacion = CodigoProductoPanificacion;
                productoPanificacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = productoPanificacionBL.AgregarProducto(productoPanificacionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarProducto(int ProductoPanificacionId)
        {
            return Json(productoPanificacionBL.BuscarProductoPanificacionId(ProductoPanificacionId));
        }

        public ActionResult ActualizarProducto(int ProductoPanificacionId, string DescProductoPanificacion, string CodigoProductoPanificacion)
        {
            ProductoPanificacionDTO productoPanificacionDTO = new();
            productoPanificacionDTO.ProductoPanificacionId = ProductoPanificacionId;
            productoPanificacionDTO.DescProductoPanificacion = DescProductoPanificacion;
            productoPanificacionDTO.CodigoProductoPanificacion = CodigoProductoPanificacion;
            productoPanificacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = productoPanificacionBL.ActualizarProducto(productoPanificacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarProducto(int ProductoPanificacionId)
        {
            ProductoPanificacionDTO productoPanificacionDTO = new();
            productoPanificacionDTO.ProductoPanificacionId = ProductoPanificacionId;
            productoPanificacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = productoPanificacionBL.EliminarProducto(productoPanificacionDTO);

            return Content(IND_OPERACION);
        }
    }
}
