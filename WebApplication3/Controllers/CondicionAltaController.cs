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
    public class CondicionAltaController : Controller
    {
        readonly ILogger<CondicionAltaController> _logger;

        public CondicionAltaController(ILogger<CondicionAltaController> logger)
        {
            _logger = logger;
        }

        readonly CondicionAlta condicionAltaBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Condiciones Altas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CondicionAltaDTO> listaCondicionAltas = condicionAltaBL.ObtenerCondicionAltas();
            return Json(new { data = listaCondicionAltas });
        }

        public ActionResult InsertarCondicionAlta(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CondicionAltaDTO condicionAltaDTO = new();
                condicionAltaDTO.DescCondicionAlta = Descripcion;
                condicionAltaDTO.CodigoCondicionAlta = Codigo;
                condicionAltaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = condicionAltaBL.AgregarCondicionAlta(condicionAltaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCondicionAlta(int CondicionAltaId)
        {
            return Json(condicionAltaBL.BuscarCondicionAltaID(CondicionAltaId));
        }

        public ActionResult ActualizarCondicionAlta(int CondicionAltaId, string Codigo, string Descripcion)
        {
            CondicionAltaDTO condicionAltaDTO = new();
            condicionAltaDTO.CondicionAltaId = CondicionAltaId;
            condicionAltaDTO.DescCondicionAlta = Descripcion;
            condicionAltaDTO.CodigoCondicionAlta = Codigo;
            condicionAltaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = condicionAltaBL.ActualizarCondicionAlta(condicionAltaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCondicionAlta(int CondicionAltaId)
        {
            CondicionAltaDTO condicionAltaDTO = new();
            condicionAltaDTO.CondicionAltaId = CondicionAltaId;
            condicionAltaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = condicionAltaBL.EliminarCondicionAlta(condicionAltaDTO);

            return Content(IND_OPERACION);
        }
    }
}
