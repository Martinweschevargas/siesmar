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
    public class ServicioBrindadoController : Controller
    {
        readonly ILogger<ServicioBrindadoController> _logger;

        public ServicioBrindadoController(ILogger<ServicioBrindadoController> logger)
        {
            _logger = logger;
        }

        readonly ServicioBrindadoDAO ServicioBrindadoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Servicio Brindado", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ServicioBrindadoDTO> listaServicioBrindado = ServicioBrindadoBL.ObtenerServicioBrindados();
            return Json(new { data = listaServicioBrindado });
        }

        public ActionResult InsertarServicioBrindado(string DescServicioBrindado, string CodigoServicioBrindado)
        {
            var IND_OPERACION = "";
            try
            {
                ServicioBrindadoDTO servicioBrindadoDTO = new();
                servicioBrindadoDTO.DescServicioBrindado = DescServicioBrindado;
                servicioBrindadoDTO.CodigoServicioBrindado = CodigoServicioBrindado;
                servicioBrindadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ServicioBrindadoBL.AgregarServicioBrindado(servicioBrindadoDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarServicioBrindado(int ServicioBrindadoId)
        {
            return Json(ServicioBrindadoBL.BuscarServicioBrindadoID(ServicioBrindadoId));
        }

        public ActionResult ActualizarServicioBrindado(int ServicioBrindadoId, string DescServicioBrindado, string CodigoServicioBrindado)
        {
            ServicioBrindadoDTO ServicioBrindadoDTO = new();
            ServicioBrindadoDTO.ServicioBrindadoId = ServicioBrindadoId;
            ServicioBrindadoDTO.DescServicioBrindado = DescServicioBrindado;
            ServicioBrindadoDTO.CodigoServicioBrindado = CodigoServicioBrindado;
            ServicioBrindadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ServicioBrindadoBL.ActualizarServicioBrindado(ServicioBrindadoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarServicioBrindado(int ServicioBrindadoId)
        {
            ServicioBrindadoDTO ServicioBrindadoDTO = new();
            ServicioBrindadoDTO.ServicioBrindadoId = ServicioBrindadoId;
            ServicioBrindadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ServicioBrindadoBL.EliminarServicioBrindado(ServicioBrindadoDTO);

            return Content(IND_OPERACION);
        }
    }
}
