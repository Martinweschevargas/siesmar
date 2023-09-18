using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class ProductoDimarController : Controller
    {
        readonly ILogger<ProductoDimarController> _logger;

        public ProductoDimarController(ILogger<ProductoDimarController> logger)
        {
            _logger = logger;
        }

        readonly ProductoDimarDAO ProductoDimarBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Productos Dimar", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ProductoDimarDTO> listaProductoDimars = ProductoDimarBL.ObtenerProductoDimars();
            return Json(new { data = listaProductoDimars });
        }

        public ActionResult InsertarProductoDimar(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ProductoDimarDTO ProductoDimarDTO = new();
                ProductoDimarDTO.DescProductoDimar = Descripcion;
                ProductoDimarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ProductoDimarBL.AgregarProductoDimar(ProductoDimarDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarProductoDimar(int ProductoDimarId)
        {
            return Json(ProductoDimarBL.BuscarProductoDimarID(ProductoDimarId));
        }

        public ActionResult ActualizarProductoDimar(int ProductoDimarId, string Descripcion)
        {
            ProductoDimarDTO ProductoDimarDTO = new();
            ProductoDimarDTO.ProductoDimarId = ProductoDimarId;
            ProductoDimarDTO.DescProductoDimar = Descripcion;
            ProductoDimarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ProductoDimarBL.ActualizarProductoDimar(ProductoDimarDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarProductoDimar(int ProductoDimarId)
        {
            ProductoDimarDTO ProductoDimarDTO = new();
            ProductoDimarDTO.ProductoDimarId = ProductoDimarId;
            ProductoDimarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ProductoDimarBL.EliminarProductoDimar(ProductoDimarDTO);

            return Content(IND_OPERACION);
        }
    }
}
