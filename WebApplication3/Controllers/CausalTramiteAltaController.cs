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
    public class CausalTramiteAltaController : Controller
    {
        readonly ILogger<CausalTramiteAltaController> _logger;

        public CausalTramiteAltaController(ILogger<CausalTramiteAltaController> logger)
        {
            _logger = logger;
        }

        readonly CausalTramiteAltaDAO CausalTramiteAltaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Causales Tramites Altas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CausalTramiteAltaDTO> listaCausalTramiteAltas = CausalTramiteAltaBL.ObtenerCausalTramiteAltas();
            return Json(new { data = listaCausalTramiteAltas });
        }

        public ActionResult InsertarCausalTramiteAlta(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CausalTramiteAltaDTO CausalTramiteAltaDTO = new();
                CausalTramiteAltaDTO.DescCausalTramiteAlta = Descripcion;
                CausalTramiteAltaDTO.CodigoCausalTramiteAlta = Codigo;
                CausalTramiteAltaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = CausalTramiteAltaBL.AgregarCausalTramiteAlta(CausalTramiteAltaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCausalTramiteAlta(int CausalTramiteAltaId)
        {
            return Json(CausalTramiteAltaBL.BuscarCausalTramiteAltaID(CausalTramiteAltaId));
        }

        public ActionResult ActualizarCausalTramiteAlta(int CausalTramiteAltaId, string Codigo, string Descripcion)
        {
            CausalTramiteAltaDTO CausalTramiteAltaDTO = new();
            CausalTramiteAltaDTO.CausalTramiteAltaId = CausalTramiteAltaId;
            CausalTramiteAltaDTO.DescCausalTramiteAlta = Descripcion;
            CausalTramiteAltaDTO.CodigoCausalTramiteAlta = Codigo;
            CausalTramiteAltaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CausalTramiteAltaBL.ActualizarCausalTramiteAlta(CausalTramiteAltaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCausalTramiteAlta(int CausalTramiteAltaId)
        {
            CausalTramiteAltaDTO CausalTramiteAltaDTO = new();
            CausalTramiteAltaDTO.CausalTramiteAltaId = CausalTramiteAltaId;
            CausalTramiteAltaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CausalTramiteAltaBL.EliminarCausalTramiteAlta(CausalTramiteAltaDTO);

            return Content(IND_OPERACION);
        }
    }
}
