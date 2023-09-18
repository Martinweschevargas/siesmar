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
    public class TipoActividadController : Controller
    {
        readonly ILogger<TipoActividadController> _logger;

        public TipoActividadController(ILogger<TipoActividadController> logger)
        {
            _logger = logger;
        }

        readonly TipoActividad tipoActividadBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Actividades", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoActividadDTO> listaTipoActividads = tipoActividadBL.ObtenerTipoActividads();
            return Json(new { data = listaTipoActividads });
        }

        public ActionResult InsertarTipoActividad(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoActividadDTO tipoActividadDTO = new();
                tipoActividadDTO.DescTipoActividad = Descripcion;
                tipoActividadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoActividadBL.AgregarTipoActividad(tipoActividadDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoActividad(int TipoActividadId)
        {
            return Json(tipoActividadBL.BuscarTipoActividadID(TipoActividadId));
        }

        public ActionResult ActualizarTipoActividad(int TipoActividadId, string Descripcion)
        {
            TipoActividadDTO tipoActividadDTO = new();
            tipoActividadDTO.TipoActividadId = TipoActividadId;
            tipoActividadDTO.DescTipoActividad = Descripcion;
            tipoActividadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoActividadBL.ActualizarTipoActividad(tipoActividadDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoActividad(int TipoActividadId)
        {
            TipoActividadDTO tipoActividadDTO = new();
            tipoActividadDTO.TipoActividadId = TipoActividadId;
            tipoActividadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoActividadBL.EliminarTipoActividad(tipoActividadDTO);

            return Content(IND_OPERACION);
        }
    }
}
