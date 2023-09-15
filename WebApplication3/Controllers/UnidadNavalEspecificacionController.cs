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
    public class UnidadNavalEspecificacionController : Controller
    {
        readonly ILogger<UnidadNavalEspecificacionController> _logger;

        public UnidadNavalEspecificacionController(ILogger<UnidadNavalEspecificacionController> logger)
        {
            _logger = logger;
        }

        readonly UnidadNavalEspecificacion unidadNavalEspecificacionBL = new();
        Usuario usuarioBL = new();

        UnidadNavalTipo unidadNavalTipoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Unidades Navales Especificaciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<UnidadNavalTipoDTO> unidadNavalTipoDTO = unidadNavalTipoBL.ObtenerUnidadNavalTipos();

            return Json(new { data = unidadNavalTipoDTO });
        }

        public JsonResult CargarDatos()
        {
            List<UnidadNavalEspecificacionDTO> listaUnidadNavalEspecificaciones = unidadNavalEspecificacionBL.ObtenerUnidadNavalEspecificacions();
            return Json(new { data = listaUnidadNavalEspecificaciones });
        }

        public ActionResult InsertarUnidadNavalEspecificacion(string Descripcion, string Codigo, int UnidadNavalTipoId, string Caso)
        {
            var IND_OPERACION = "";
            try
            {
                UnidadNavalEspecificacionDTO unidadNavalEspecificacionDTO = new();
                unidadNavalEspecificacionDTO.DescUnidadNavalEspecificacion = Descripcion;
                unidadNavalEspecificacionDTO.CodigoUnidadNavalEspecificacion = Codigo;
                unidadNavalEspecificacionDTO.UnidadNavalTipoId = UnidadNavalTipoId;
                unidadNavalEspecificacionDTO.nCasoUnidadNavalEspecificacion = Caso;
                unidadNavalEspecificacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = unidadNavalEspecificacionBL.AgregarUnidadNavalEspecificacion(unidadNavalEspecificacionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarUnidadNavalEspecificacion(int UnidadNavalEspecificacionId)
        {
            return Json(unidadNavalEspecificacionBL.BuscarUnidadNavalEspecificacionID(UnidadNavalEspecificacionId));
        }

        public ActionResult ActualizarUnidadNavalEspecificacion(int UnidadNavalEspecificacionId, string Descripcion, string Codigo, int UnidadNavalTipoId, string Caso)
        {
            UnidadNavalEspecificacionDTO unidadNavalEspecificacionDTO = new();
            unidadNavalEspecificacionDTO.UnidadNavalEspecificacionId = UnidadNavalEspecificacionId;
            unidadNavalEspecificacionDTO.DescUnidadNavalEspecificacion = Descripcion;
            unidadNavalEspecificacionDTO.CodigoUnidadNavalEspecificacion = Codigo;
            unidadNavalEspecificacionDTO.UnidadNavalTipoId = UnidadNavalTipoId;
            unidadNavalEspecificacionDTO.nCasoUnidadNavalEspecificacion = Caso;
            unidadNavalEspecificacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadNavalEspecificacionBL.ActualizarUnidadNavalEspecificacion(unidadNavalEspecificacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarUnidadNavalEspecificacion(int UnidadNavalEspecificacionId)
        {
            UnidadNavalEspecificacionDTO unidadNavalEspecificacionDTO = new();
            unidadNavalEspecificacionDTO.UnidadNavalEspecificacionId = UnidadNavalEspecificacionId;
            unidadNavalEspecificacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadNavalEspecificacionBL.EliminarUnidadNavalEspecificacion(unidadNavalEspecificacionDTO);

            return Content(IND_OPERACION);
        }
    }
}
