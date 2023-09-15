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
    public class TipoVehiculoMovilController : Controller
    {
        readonly ILogger<TipoVehiculoMovilController> _logger;

        public TipoVehiculoMovilController(ILogger<TipoVehiculoMovilController> logger)
        {
            _logger = logger;
        }

        readonly TipoVehiculoMovilDAO TipoVehiculoMovilBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Vehiculos Moviles", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoVehiculoMovilDTO> listaTipoVehiculoMovils = TipoVehiculoMovilBL.ObtenerTipoVehiculoMovils();
            return Json(new { data = listaTipoVehiculoMovils });
        }

        public ActionResult InsertarTipoVehiculoMovil(string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                TipoVehiculoMovilDTO TipoVehiculoMovilDTO = new();
                TipoVehiculoMovilDTO.DescTipoVehiculoMovil = Descripcion;
                TipoVehiculoMovilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = TipoVehiculoMovilBL.AgregarTipoVehiculoMovil(TipoVehiculoMovilDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoVehiculoMovil(int TipoVehiculoMovilId)
        {
            return Json(TipoVehiculoMovilBL.BuscarTipoVehiculoMovilID(TipoVehiculoMovilId));
        }

        public ActionResult ActualizarTipoVehiculoMovil(int TipoVehiculoMovilId, string Descripcion)
        {
            TipoVehiculoMovilDTO TipoVehiculoMovilDTO = new();
            TipoVehiculoMovilDTO.TipoVehiculoMovilId = TipoVehiculoMovilId;
            TipoVehiculoMovilDTO.DescTipoVehiculoMovil = Descripcion;
            TipoVehiculoMovilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoVehiculoMovilBL.ActualizarTipoVehiculoMovil(TipoVehiculoMovilDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoVehiculoMovil(int TipoVehiculoMovilId)
        {
            TipoVehiculoMovilDTO TipoVehiculoMovilDTO = new();
            TipoVehiculoMovilDTO.TipoVehiculoMovilId = TipoVehiculoMovilId;
            TipoVehiculoMovilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoVehiculoMovilBL.EliminarTipoVehiculoMovil(TipoVehiculoMovilDTO);

            return Content(IND_OPERACION);
        }
    }
}
