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
    public class DetalleInfraccionController : Controller
    {
        readonly ILogger<DetalleInfraccionController> _logger;

        public DetalleInfraccionController(ILogger<DetalleInfraccionController> logger)
        {
            _logger = logger;
        }

        readonly DetalleInfraccionDAO detalleInfraccionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Detalles Infracciones", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DetalleInfraccionDTO> listaDetalleInfraccions = detalleInfraccionBL.ObtenerDetalleInfraccions();
            return Json(new { data = listaDetalleInfraccions });
        }

        public ActionResult InsertarDetalleInfraccion(string DescDetalleInfraccion, string CodigoDetalleInfraccion)
        {
            var IND_OPERACION="";
            try
            {
                DetalleInfraccionDTO detalleInfraccionDTO = new();
                detalleInfraccionDTO.DescDetalleInfraccion = DescDetalleInfraccion;
                detalleInfraccionDTO.CodigoDetalleInfraccion = CodigoDetalleInfraccion;
                detalleInfraccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = detalleInfraccionBL.AgregarDetalleInfraccion(detalleInfraccionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDetalleInfraccion(int DetalleInfraccionId)
        {
            return Json(detalleInfraccionBL.BuscarDetalleInfraccionID(DetalleInfraccionId));
        }

        public ActionResult ActualizarDetalleInfraccion(int DetalleInfraccionId, string DescDetalleInfraccion, string CodigoDetalleInfraccion)
        {
            DetalleInfraccionDTO detalleInfraccionDTO = new();
            detalleInfraccionDTO.DetalleInfraccionId = DetalleInfraccionId;
            detalleInfraccionDTO.DescDetalleInfraccion = DescDetalleInfraccion;
            detalleInfraccionDTO.CodigoDetalleInfraccion = CodigoDetalleInfraccion;
            detalleInfraccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = detalleInfraccionBL.ActualizarDetalleInfraccion(detalleInfraccionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDetalleInfraccion(int DetalleInfraccionId)
        {
            DetalleInfraccionDTO detalleInfraccionDTO = new();
            detalleInfraccionDTO.DetalleInfraccionId = DetalleInfraccionId;
            detalleInfraccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = detalleInfraccionBL.EliminarDetalleInfraccion(detalleInfraccionDTO);

            return Content(IND_OPERACION);
        }
    }
}
