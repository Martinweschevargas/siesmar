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
    public class ProductoController : Controller
    {
        readonly ILogger<ProductoController> _logger;

        public ProductoController(ILogger<ProductoController> logger)
        {
            _logger = logger;
        }

        readonly ProductoDAO productoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Productos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ProductoDTO> listaProductos = productoBL.ObtenerProductos();
            return Json(new { data = listaProductos });
        }

        public ActionResult InsertarProducto(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ProductoDTO productoDTO = new();
                productoDTO.DescProducto = Descripcion;
                productoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = productoBL.AgregarProducto(productoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarProducto(int ProductoId)
        {
            return Json(productoBL.BuscarProductoID(ProductoId));
        }

        public ActionResult ActualizarProducto(int ProductoId, string Descripcion)
        {
            ProductoDTO productoDTO = new();
            productoDTO.ProductoId = ProductoId;
            productoDTO.DescProducto = Descripcion;
            productoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = productoBL.ActualizarProducto(productoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarProducto(int ProductoId)
        {
            ProductoDTO productoDTO = new();
            productoDTO.ProductoId = ProductoId;
            productoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = productoBL.EliminarProducto(productoDTO);

            return Content(IND_OPERACION);
        }
    }
}
