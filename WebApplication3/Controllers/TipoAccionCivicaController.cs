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
    public class TipoAccionCivicaController : Controller
    {
        readonly ILogger<TipoAccionCivicaController> _logger;

        public TipoAccionCivicaController(ILogger<TipoAccionCivicaController> logger)
        {
            _logger = logger;
        }

        readonly TipoAccionCivica tipoAccionCivicaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Acciones Cívicas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoAccionCivicaDTO> listaTipoAccionCivicas = tipoAccionCivicaBL.ObtenerTipoAccionCivicas();
            return Json(new { data = listaTipoAccionCivicas });
        }

        public ActionResult InsertarTipoAccionCivica(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoAccionCivicaDTO tipoAccionCivicaDTO = new();
                tipoAccionCivicaDTO.DescTipoAccionCivica = Descripcion;
                tipoAccionCivicaDTO.CodigoTipoAccionCivica = Codigo;
                tipoAccionCivicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoAccionCivicaBL.AgregarTipoAccionCivica(tipoAccionCivicaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoAccionCivica(int TipoAccionCivicaId)
        {
            return Json(tipoAccionCivicaBL.BuscarTipoAccionCivicaID(TipoAccionCivicaId));
        }

        public ActionResult ActualizarTipoAccionCivica(int TipoAccionCivicaId, string Codigo, string Descripcion)
        {
            TipoAccionCivicaDTO tipoAccionCivicaDTO = new();
            tipoAccionCivicaDTO.TipoAccionCivicaId = TipoAccionCivicaId;
            tipoAccionCivicaDTO.DescTipoAccionCivica = Descripcion;
            tipoAccionCivicaDTO.CodigoTipoAccionCivica = Codigo;
            tipoAccionCivicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoAccionCivicaBL.ActualizarTipoAccionCivica(tipoAccionCivicaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoAccionCivica(int TipoAccionCivicaId)
        {
            TipoAccionCivicaDTO tipoAccionCivicaDTO = new();
            tipoAccionCivicaDTO.TipoAccionCivicaId = TipoAccionCivicaId;
            tipoAccionCivicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoAccionCivicaBL.EliminarTipoAccionCivica(tipoAccionCivicaDTO);

            return Content(IND_OPERACION);
        }
    }
}
