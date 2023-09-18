using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using MathNet.Numerics.Distributions;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class CombustibleEspecificacionController : Controller
    {
        readonly ILogger<CombustibleEspecificacionController> _logger;

        public CombustibleEspecificacionController(ILogger<CombustibleEspecificacionController> logger)
        {
            _logger = logger;
        }

        readonly CombustibleEspecificacion puertoBL = new();
        Usuario usuarioBL = new();

        ClaseCombustible claseCombustibleBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Combustibles Especificaciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<ClaseCombustibleDTO> claseCombustibleDTO = claseCombustibleBL.ObtenerClaseCombustibles();

            return Json(new { data = claseCombustibleDTO });
        }

        public JsonResult CargarDatos()
        {
            List<CombustibleEspecificacionDTO> listaCombustibleEspecificaciones = puertoBL.ObtenerCombustibleEspecificacions();
            return Json(new { data = listaCombustibleEspecificaciones });
        }

        public ActionResult InsertarCombustibleEspecificacion(string Descripcion, string Codigo, int ClaseCombustibleId)
        {
            var IND_OPERACION = "";
            try
            {
                CombustibleEspecificacionDTO puertoDTO = new();
                puertoDTO.DescCombustibleEspecificacion = Descripcion;
                puertoDTO.CodigoCombustibleEspecificacion = Codigo;
                puertoDTO.ClaseCombustibleId = ClaseCombustibleId;
                puertoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = puertoBL.AgregarCombustibleEspecificacion(puertoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCombustibleEspecificacion(int CombustibleEspecificacionId)
        {
            return Json(puertoBL.BuscarCombustibleEspecificacionID(CombustibleEspecificacionId));
        }

        public ActionResult ActualizarCombustibleEspecificacion(int CombustibleEspecificacionId, string Descripcion, string Codigo, int ClaseCombustibleId)
        {
            CombustibleEspecificacionDTO puertoDTO = new();
            puertoDTO.CombustibleEspecificacionId = CombustibleEspecificacionId;
            puertoDTO.DescCombustibleEspecificacion = Descripcion;
            puertoDTO.CodigoCombustibleEspecificacion = Codigo;
            puertoDTO.ClaseCombustibleId = ClaseCombustibleId;
            puertoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = puertoBL.ActualizarCombustibleEspecificacion(puertoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCombustibleEspecificacion(int CombustibleEspecificacionId)
        {
            CombustibleEspecificacionDTO puertoDTO = new();
            puertoDTO.CombustibleEspecificacionId = CombustibleEspecificacionId;
            puertoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = puertoBL.EliminarCombustibleEspecificacion(puertoDTO);

            return Content(IND_OPERACION);
        }
    }
}
