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
    public class CondicionAlistamientoLogisticoController : Controller
    {
        readonly ILogger<CondicionAlistamientoLogisticoController> _logger;

        public CondicionAlistamientoLogisticoController(ILogger<CondicionAlistamientoLogisticoController> logger)
        {
            _logger = logger;
        }

        readonly CondicionAlistamientoLogistico condicionAlistamientoLogisticoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Condiciones Alistamientos Logísticos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CondicionAlistamientoLogisticoDTO> listaCondicionAlistamientoLogisticos = condicionAlistamientoLogisticoBL.ObtenerCondicionAlistamientoLogisticos();
            return Json(new { data = listaCondicionAlistamientoLogisticos });
        }

        public ActionResult InsertarCondicionAlistamientoLogistico(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CondicionAlistamientoLogisticoDTO condicionAlistamientoLogisticoDTO = new();
                condicionAlistamientoLogisticoDTO.DescCondicionAlistamientoLogistico = Descripcion;
                condicionAlistamientoLogisticoDTO.CodigoCondicionAlistamientoLogistico = Codigo;
                condicionAlistamientoLogisticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = condicionAlistamientoLogisticoBL.AgregarCondicionAlistamientoLogistico(condicionAlistamientoLogisticoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCondicionAlistamientoLogistico(int CondicionAlistamientoLogisticoId)
        {
            return Json(condicionAlistamientoLogisticoBL.BuscarCondicionAlistamientoLogisticoID(CondicionAlistamientoLogisticoId));
        }

        public ActionResult ActualizarCondicionAlistamientoLogistico(int CondicionAlistamientoLogisticoId, string Codigo, string Descripcion)
        {
            CondicionAlistamientoLogisticoDTO condicionAlistamientoLogisticoDTO = new();
            condicionAlistamientoLogisticoDTO.CondicionAlistamientoLogisticoId = CondicionAlistamientoLogisticoId;
            condicionAlistamientoLogisticoDTO.DescCondicionAlistamientoLogistico = Descripcion;
            condicionAlistamientoLogisticoDTO.CodigoCondicionAlistamientoLogistico = Codigo;
            condicionAlistamientoLogisticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = condicionAlistamientoLogisticoBL.ActualizarCondicionAlistamientoLogistico(condicionAlistamientoLogisticoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCondicionAlistamientoLogistico(int CondicionAlistamientoLogisticoId)
        {
            CondicionAlistamientoLogisticoDTO condicionAlistamientoLogisticoDTO = new();
            condicionAlistamientoLogisticoDTO.CondicionAlistamientoLogisticoId = CondicionAlistamientoLogisticoId;
            condicionAlistamientoLogisticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = condicionAlistamientoLogisticoBL.EliminarCondicionAlistamientoLogistico(condicionAlistamientoLogisticoDTO);

            return Content(IND_OPERACION);
        }
    }
}
