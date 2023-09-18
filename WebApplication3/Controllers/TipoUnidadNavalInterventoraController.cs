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
    public class TipoUnidadNavalInterventoraController : Controller
    {
        readonly ILogger<TipoUnidadNavalInterventoraController> _logger;

        public TipoUnidadNavalInterventoraController(ILogger<TipoUnidadNavalInterventoraController> logger)
        {
            _logger = logger;
        }

        readonly TipoUnidadNavalInterventoraDAO TipoUnidadNavalInterventoraBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Unidades Navales Interventoras", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoUnidadNavalInterventoraDTO> listaTipoUnidadNavalInterventoras = TipoUnidadNavalInterventoraBL.ObtenerTipoUnidadNavalInterventoras();
            return Json(new { data = listaTipoUnidadNavalInterventoras });
        }

        public ActionResult InsertarTipoUnidadNavalInterventora(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                TipoUnidadNavalInterventoraDTO TipoUnidadNavalInterventoraDTO = new();
                TipoUnidadNavalInterventoraDTO.DescTipoUnidadNavalInterventora = Descripcion;
                TipoUnidadNavalInterventoraDTO.CodigoTipoUnidadNavalInterventora = Codigo;
                TipoUnidadNavalInterventoraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = TipoUnidadNavalInterventoraBL.AgregarTipoUnidadNavalInterventora(TipoUnidadNavalInterventoraDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoUnidadNavalInterventora(int TipoUnidadNavalInterventoraId)
        {
            return Json(TipoUnidadNavalInterventoraBL.BuscarTipoUnidadNavalInterventoraID(TipoUnidadNavalInterventoraId));
        }

        public ActionResult ActualizarTipoUnidadNavalInterventora(int TipoUnidadNavalInterventoraId, string Codigo, string Descripcion)
        {
            TipoUnidadNavalInterventoraDTO TipoUnidadNavalInterventoraDTO = new();
            TipoUnidadNavalInterventoraDTO.TipoUnidadNavalInterventoraId = TipoUnidadNavalInterventoraId;
            TipoUnidadNavalInterventoraDTO.DescTipoUnidadNavalInterventora = Descripcion;
            TipoUnidadNavalInterventoraDTO.CodigoTipoUnidadNavalInterventora = Codigo;
            TipoUnidadNavalInterventoraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoUnidadNavalInterventoraBL.ActualizarTipoUnidadNavalInterventora(TipoUnidadNavalInterventoraDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoUnidadNavalInterventora(int TipoUnidadNavalInterventoraId)
        {
            TipoUnidadNavalInterventoraDTO TipoUnidadNavalInterventoraDTO = new();
            TipoUnidadNavalInterventoraDTO.TipoUnidadNavalInterventoraId = TipoUnidadNavalInterventoraId;
            TipoUnidadNavalInterventoraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoUnidadNavalInterventoraBL.EliminarTipoUnidadNavalInterventora(TipoUnidadNavalInterventoraDTO);

            return Content(IND_OPERACION);
        }
    }
}
