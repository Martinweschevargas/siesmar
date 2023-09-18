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
    public class CondicionLaboralController : Controller
    {
        readonly ILogger<CondicionLaboralController> _logger;

        public CondicionLaboralController(ILogger<CondicionLaboralController> logger)
        {
            _logger = logger;
        }

        readonly CondicionLaboral condicionLaboralBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Condiciones Laborales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CondicionLaboralDTO> listaCondicionLaborals = condicionLaboralBL.ObtenerCondicionLaborals();
            return Json(new { data = listaCondicionLaborals });
        }

        public ActionResult InsertarCondicionLaboral(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CondicionLaboralDTO condicionLaboralDTO = new();
                condicionLaboralDTO.DescCondicionLaboral = Descripcion;
                condicionLaboralDTO.CodigoCondicionLaboral = Codigo;
                condicionLaboralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = condicionLaboralBL.AgregarCondicionLaboral(condicionLaboralDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCondicionLaboral(int CondicionLaboralId)
        {
            return Json(condicionLaboralBL.BuscarCondicionLaboralID(CondicionLaboralId));
        }

        public ActionResult ActualizarCondicionLaboral(int CondicionLaboralId, string Codigo, string Descripcion)
        {
            CondicionLaboralDTO condicionLaboralDTO = new();
            condicionLaboralDTO.CondicionLaboralId = CondicionLaboralId;
            condicionLaboralDTO.DescCondicionLaboral = Descripcion;
            condicionLaboralDTO.CodigoCondicionLaboral = Codigo;
            condicionLaboralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = condicionLaboralBL.ActualizarCondicionLaboral(condicionLaboralDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCondicionLaboral(int CondicionLaboralId)
        {
            CondicionLaboralDTO condicionLaboralDTO = new();
            condicionLaboralDTO.CondicionLaboralId = CondicionLaboralId;
            condicionLaboralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = condicionLaboralBL.EliminarCondicionLaboral(condicionLaboralDTO);

            return Content(IND_OPERACION);
        }
    }
}
