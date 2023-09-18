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
    public class CausalBajaController : Controller
    {
        readonly ILogger<CausalBajaController> _logger;

        public CausalBajaController(ILogger<CausalBajaController> logger)
        {
            _logger = logger;
        }

        readonly CausalBaja causalBajaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Causales Bajas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CausalBajaDTO> listaCausalBajas = causalBajaBL.ObtenerCausalBajas();
            return Json(new { data = listaCausalBajas });
        }

        public ActionResult InsertarCausalBaja(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CausalBajaDTO causalBajaDTO = new();
                causalBajaDTO.DescCausalBaja = Descripcion;
                causalBajaDTO.CodigoCausalBaja = Codigo;
                causalBajaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = causalBajaBL.AgregarCausalBaja(causalBajaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCausalBaja(int CausalBajaId)
        {
            return Json(causalBajaBL.BuscarCausalBajaID(CausalBajaId));
        }

        public ActionResult ActualizarCausalBaja(int CausalBajaId, string Codigo, string Descripcion)
        {
            CausalBajaDTO causalBajaDTO = new();
            causalBajaDTO.CausalBajaId = CausalBajaId;
            causalBajaDTO.DescCausalBaja = Descripcion;
            causalBajaDTO.CodigoCausalBaja = Codigo;
            causalBajaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = causalBajaBL.ActualizarCausalBaja(causalBajaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCausalBaja(int CausalBajaId)
        {
            CausalBajaDTO causalBajaDTO = new();
            causalBajaDTO.CausalBajaId = CausalBajaId;
            causalBajaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = causalBajaBL.EliminarCausalBaja(causalBajaDTO);

            return Content(IND_OPERACION);
        }
    }
}
