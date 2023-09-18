using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class TipoActividadCulturalController : Controller
    {
        readonly ILogger<TipoActividadCulturalController> _logger;

        public TipoActividadCulturalController(ILogger<TipoActividadCulturalController> logger)
        {
            _logger = logger;
        }

        readonly TipoActividadCulturalDAO tipoActividadCulturalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Actividades Culturales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoActividadCulturalDTO> listaTipoActividadCulturals = tipoActividadCulturalBL.ObtenerTipoActividadCulturals();
            return Json(new { data = listaTipoActividadCulturals });
        }

        public ActionResult InsertarTipoActividadCultural(string DescTipoActividadCultural, string CodigoTipoActividadCultural)
        {
            var IND_OPERACION = "";
            try
            {
                TipoActividadCulturalDTO tipoActividadCulturalDTO = new();
                tipoActividadCulturalDTO.DescTipoActividadCultural = DescTipoActividadCultural;
                tipoActividadCulturalDTO.CodigoTipoActividadCultural = CodigoTipoActividadCultural;
                tipoActividadCulturalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoActividadCulturalBL.AgregarTipoActividadCultural(tipoActividadCulturalDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoActividadCultural(int TipoActividadCulturalId)
        {
            return Json(tipoActividadCulturalBL.BuscarTipoActividadCulturalID(TipoActividadCulturalId));
        }

        public ActionResult ActualizarTipoActividadCultural(int TipoActividadCulturalId, string DescTipoActividadCultural, string CodigoTipoActividadCultural)
        {
            TipoActividadCulturalDTO tipoActividadCulturalDTO = new();
            tipoActividadCulturalDTO.TipoActividadCulturalId = TipoActividadCulturalId;
            tipoActividadCulturalDTO.DescTipoActividadCultural = DescTipoActividadCultural;
            tipoActividadCulturalDTO.CodigoTipoActividadCultural = CodigoTipoActividadCultural;
            tipoActividadCulturalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoActividadCulturalBL.ActualizarTipoActividadCultural(tipoActividadCulturalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoActividadCultural(int TipoActividadCulturalId)
        {
            TipoActividadCulturalDTO tipoActividadCulturalDTO = new();
            tipoActividadCulturalDTO.TipoActividadCulturalId = TipoActividadCulturalId;
            tipoActividadCulturalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoActividadCulturalBL.EliminarTipoActividadCultural(tipoActividadCulturalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}

