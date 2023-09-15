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
    public class CategoriaPagoController : Controller
    {
        readonly ILogger<CategoriaPagoController> _logger;

        public CategoriaPagoController(ILogger<CategoriaPagoController> logger)
        {
            _logger = logger;
        }

        readonly CategoriaPagoDAO CategoriaPagoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Categorias Pagos", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CategoriaPagoDTO> listaCategoriaPagos = CategoriaPagoBL.ObtenerCategoriaPagos();
            return Json(new { data = listaCategoriaPagos });
        }

        public ActionResult InsertarCategoriaPago(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                CategoriaPagoDTO CategoriaPagoDTO = new();
                CategoriaPagoDTO.DescCategoriaPago = Descripcion;
                CategoriaPagoDTO.CodigoCategoriaPago = Codigo;
                CategoriaPagoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = CategoriaPagoBL.AgregarCategoriaPago(CategoriaPagoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCategoriaPago(int CategoriaPagoId)
        {
            return Json(CategoriaPagoBL.BuscarCategoriaPagoID(CategoriaPagoId));
        }

        public ActionResult ActualizarCategoriaPago(int CategoriaPagoId, string Codigo, string Descripcion)
        {
            CategoriaPagoDTO CategoriaPagoDTO = new();
            CategoriaPagoDTO.CategoriaPagoId = CategoriaPagoId;
            CategoriaPagoDTO.DescCategoriaPago = Descripcion;
            CategoriaPagoDTO.CodigoCategoriaPago = Codigo;
            CategoriaPagoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CategoriaPagoBL.ActualizarCategoriaPago(CategoriaPagoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCategoriaPago(int CategoriaPagoId)
        {
            CategoriaPagoDTO CategoriaPagoDTO = new();
            CategoriaPagoDTO.CategoriaPagoId = CategoriaPagoId;
            CategoriaPagoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CategoriaPagoBL.EliminarCategoriaPago(CategoriaPagoDTO);

            return Content(IND_OPERACION);
        }
    }
}
