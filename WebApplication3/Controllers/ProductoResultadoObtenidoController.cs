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
    public class ProductoResultadoObtenidoController : Controller
    {
        readonly ILogger<ProductoResultadoObtenidoController> _logger;

        public ProductoResultadoObtenidoController(ILogger<ProductoResultadoObtenidoController> logger)
        {
            _logger = logger;
        }

        readonly ProductoResultadoObtenidoDAO ProductoResultadoObtenidoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Productos Resultados Obtenidos", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ProductoResultadoObtenidoDTO> listaProductoResultadoObtenidos = ProductoResultadoObtenidoBL.ObtenerProductoResultadoObtenidos();
            return Json(new { data = listaProductoResultadoObtenidos });
        }

        public ActionResult InsertarProductoResultadoObtenido(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                ProductoResultadoObtenidoDTO ProductoResultadoObtenidoDTO = new();
                ProductoResultadoObtenidoDTO.DescProductoResultadoObtenido = Descripcion;
                ProductoResultadoObtenidoDTO.CodigoProductoResultadoObtenido = Codigo;
                ProductoResultadoObtenidoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ProductoResultadoObtenidoBL.AgregarProductoResultadoObtenido(ProductoResultadoObtenidoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarProductoResultadoObtenido(int ProductoResultadoObtenidoId)
        {
            return Json(ProductoResultadoObtenidoBL.BuscarProductoResultadoObtenidoID(ProductoResultadoObtenidoId));
        }

        public ActionResult ActualizarProductoResultadoObtenido(int ProductoResultadoObtenidoId, string Codigo, string Descripcion)
        {
            ProductoResultadoObtenidoDTO ProductoResultadoObtenidoDTO = new();
            ProductoResultadoObtenidoDTO.ProductoResultadoObtenidoId = ProductoResultadoObtenidoId;
            ProductoResultadoObtenidoDTO.DescProductoResultadoObtenido = Descripcion;
            ProductoResultadoObtenidoDTO.CodigoProductoResultadoObtenido = Codigo;
            ProductoResultadoObtenidoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ProductoResultadoObtenidoBL.ActualizarProductoResultadoObtenido(ProductoResultadoObtenidoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarProductoResultadoObtenido(int ProductoResultadoObtenidoId)
        {
            ProductoResultadoObtenidoDTO ProductoResultadoObtenidoDTO = new();
            ProductoResultadoObtenidoDTO.ProductoResultadoObtenidoId = ProductoResultadoObtenidoId;
            ProductoResultadoObtenidoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ProductoResultadoObtenidoBL.EliminarProductoResultadoObtenido(ProductoResultadoObtenidoDTO);

            return Content(IND_OPERACION);
        }
    }
}
