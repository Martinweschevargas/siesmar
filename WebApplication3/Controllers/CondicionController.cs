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
    public class CondicionController : Controller
    {
        readonly ILogger<CondicionController> _logger;

        public CondicionController(ILogger<CondicionController> logger)
        {
            _logger = logger;
        }

        readonly CondicionDAO CondicionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Condiciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CondicionDTO> listaCondicions = CondicionBL.ObtenerCondicions();
            return Json(new { data = listaCondicions });
        }

        public ActionResult InsertarCondicion(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CondicionDTO CondicionDTO = new();
                CondicionDTO.DescCondicion = Descripcion;
                CondicionDTO.CodigoCondicion = Codigo;
                CondicionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = CondicionBL.AgregarCondicion(CondicionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCondicion(int CondicionId)
        {
            return Json(CondicionBL.BuscarCondicionID(CondicionId));
        }

        public ActionResult ActualizarCondicion(int CondicionId, string Codigo, string Descripcion)
        {
            CondicionDTO CondicionDTO = new();
            CondicionDTO.CondicionId = CondicionId;
            CondicionDTO.DescCondicion = Descripcion;
            CondicionDTO.CodigoCondicion = Codigo;
            CondicionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CondicionBL.ActualizarCondicion(CondicionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCondicion(int CondicionId)
        {
            CondicionDTO CondicionDTO = new();
            CondicionDTO.CondicionId = CondicionId;
            CondicionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CondicionBL.EliminarCondicion(CondicionDTO);

            return Content(IND_OPERACION);
        }
    }
}
