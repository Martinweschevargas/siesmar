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
    public class TipoAsignacionCasaServicioController : Controller
    {
        readonly ILogger<TipoAsignacionCasaServicioController> _logger;

        public TipoAsignacionCasaServicioController(ILogger<TipoAsignacionCasaServicioController> logger)
        {
            _logger = logger;
        }

        readonly TipoAsignacionCasaServicioDAO TipoAsignacionCasaServicioBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Asignaciones Casas Servicios", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoAsignacionCasaServicioDTO> listaTipoAsignacionCasaServicios = TipoAsignacionCasaServicioBL.ObtenerTipoAsignacionCasaServicios();
            return Json(new { data = listaTipoAsignacionCasaServicios });
        }

        public ActionResult InsertarTipoAsignacionCasaServicio(string CodigoTipoAsignacionCasaServicio, string DescTipoAsignacionCasaServicio)
        {
            var IND_OPERACION="";
            try
            {
                TipoAsignacionCasaServicioDTO TipoAsignacionCasaServicioDTO = new();
                TipoAsignacionCasaServicioDTO.DescTipoAsignacionCasaServicio = DescTipoAsignacionCasaServicio;
                TipoAsignacionCasaServicioDTO.CodigoTipoAsignacionCasaServicio = CodigoTipoAsignacionCasaServicio;
                TipoAsignacionCasaServicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = TipoAsignacionCasaServicioBL.AgregarTipoAsignacionCasaServicio(TipoAsignacionCasaServicioDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoAsignacionCasaServicio(int TipoAsignacionCasaServicioId)
        {
            return Json(TipoAsignacionCasaServicioBL.BuscarTipoAsignacionCasaServicioID(TipoAsignacionCasaServicioId));
        }

        public ActionResult ActualizarTipoAsignacionCasaServicio(int TipoAsignacionCasaServicioId, string CodigoTipoAsignacionCasaServicio, string DescTipoAsignacionCasaServicio)
        {
            TipoAsignacionCasaServicioDTO TipoAsignacionCasaServicioDTO = new();
            TipoAsignacionCasaServicioDTO.TipoAsignacionCasaServicioId = TipoAsignacionCasaServicioId;
            TipoAsignacionCasaServicioDTO.DescTipoAsignacionCasaServicio = DescTipoAsignacionCasaServicio;
            TipoAsignacionCasaServicioDTO.CodigoTipoAsignacionCasaServicio = CodigoTipoAsignacionCasaServicio;
            TipoAsignacionCasaServicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoAsignacionCasaServicioBL.ActualizarTipoAsignacionCasaServicio(TipoAsignacionCasaServicioDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoAsignacionCasaServicio(int TipoAsignacionCasaServicioId)
        {
            TipoAsignacionCasaServicioDTO TipoAsignacionCasaServicioDTO = new();
            TipoAsignacionCasaServicioDTO.TipoAsignacionCasaServicioId = TipoAsignacionCasaServicioId;
            TipoAsignacionCasaServicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoAsignacionCasaServicioBL.EliminarTipoAsignacionCasaServicio(TipoAsignacionCasaServicioDTO);

            return Content(IND_OPERACION);
        }
    }
}
