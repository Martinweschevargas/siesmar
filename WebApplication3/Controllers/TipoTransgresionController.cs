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
    public class TipoTransgresionController : Controller
    {
        readonly ILogger<TipoTransgresionController> _logger;

        public TipoTransgresionController(ILogger<TipoTransgresionController> logger)
        {
            _logger = logger;
        }

        readonly TipoTransgresionDAO tipoTransgresionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Transgresiones", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoTransgresionDTO> listaTipoTransgresions = tipoTransgresionBL.ObtenerTipoTransgresions();
            return Json(new { data = listaTipoTransgresions });
        }

        public ActionResult InsertarTipoTransgresion(string DescTipoTransgresion, string CodigoTipoTransgresion)
        {
            var IND_OPERACION="";
            try
            {
                TipoTransgresionDTO tipoTransgresionDTO = new();
                tipoTransgresionDTO.DescTipoTransgresion = DescTipoTransgresion;
                tipoTransgresionDTO.CodigoTipoTransgresion = CodigoTipoTransgresion;
                tipoTransgresionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoTransgresionBL.AgregarTipoTransgresion(tipoTransgresionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoTransgresion(int TipoTransgresionId)
        {
            return Json(tipoTransgresionBL.BuscarTipoTransgresionID(TipoTransgresionId));
        }

        public ActionResult ActualizarTipoTransgresion(int TipoTransgresionId, string DescTipoTransgresion, string CodigoTipoTransgresion)
        {
            TipoTransgresionDTO tipoTransgresionDTO = new();
            tipoTransgresionDTO.TipoTransgresionId = TipoTransgresionId;
            tipoTransgresionDTO.DescTipoTransgresion = DescTipoTransgresion;
            tipoTransgresionDTO.CodigoTipoTransgresion = CodigoTipoTransgresion;
            tipoTransgresionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoTransgresionBL.ActualizarTipoTransgresion(tipoTransgresionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoTransgresion(int TipoTransgresionId)
        {
            TipoTransgresionDTO tipoTransgresionDTO = new();
            tipoTransgresionDTO.TipoTransgresionId = TipoTransgresionId;
            tipoTransgresionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoTransgresionBL.EliminarTipoTransgresion(tipoTransgresionDTO);

            return Content(IND_OPERACION);
        }
    }
}
