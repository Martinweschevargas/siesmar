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
    public class TipoUnidadNavalController : Controller
    {
        readonly ILogger<TipoUnidadNavalController> _logger;

        public TipoUnidadNavalController(ILogger<TipoUnidadNavalController> logger)
        {
            _logger = logger;
        }

        readonly TipoUnidadNavalDAO tipoUnidadNavalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Unidades Navales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoUnidadNavalDTO> listaTipoUnidadNavals = tipoUnidadNavalBL.ObtenerTipoUnidadNavals();
            return Json(new { data = listaTipoUnidadNavals });
        }

        public ActionResult InsertarTipoUnidadNaval(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoUnidadNavalDTO tipoUnidadNavalDTO = new();
                tipoUnidadNavalDTO.DescTipoUnidadNaval = Descripcion;
                tipoUnidadNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoUnidadNavalBL.AgregarTipoUnidadNaval(tipoUnidadNavalDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoUnidadNaval(int TipoUnidadNavalId)
        {
            return Json(tipoUnidadNavalBL.BuscarTipoUnidadNavalID(TipoUnidadNavalId));
        }

        public ActionResult ActualizarTipoUnidadNaval(int TipoUnidadNavalId, string Descripcion)
        {
            TipoUnidadNavalDTO tipoUnidadNavalDTO = new();
            tipoUnidadNavalDTO.TipoUnidadNavalId = TipoUnidadNavalId;
            tipoUnidadNavalDTO.DescTipoUnidadNaval = Descripcion;
            tipoUnidadNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoUnidadNavalBL.ActualizarTipoUnidadNaval(tipoUnidadNavalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoUnidadNaval(int TipoUnidadNavalId)
        {
            TipoUnidadNavalDTO tipoUnidadNavalDTO = new();
            tipoUnidadNavalDTO.TipoUnidadNavalId = TipoUnidadNavalId;
            tipoUnidadNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoUnidadNavalBL.EliminarTipoUnidadNaval(tipoUnidadNavalDTO);

            return Content(IND_OPERACION);
        }
    }
}
