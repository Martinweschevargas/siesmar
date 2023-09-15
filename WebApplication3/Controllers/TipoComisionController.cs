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
    public class TipoComisionController : Controller
    {
        readonly ILogger<TipoComisionController> _logger;

        public TipoComisionController(ILogger<TipoComisionController> logger)
        {
            _logger = logger;
        }

        readonly TipoComisionDAO tipoComisionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Comisiones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoComisionDTO> listaTipoComisions = tipoComisionBL.ObtenerTipoComisions();
            return Json(new { data = listaTipoComisions });
        }

        public ActionResult InsertarTipoComision(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoComisionDTO tipoComisionDTO = new();
                tipoComisionDTO.DescTipoComision = Descripcion;
                tipoComisionDTO.CodigoTipoComision = Codigo;
                tipoComisionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoComisionBL.AgregarTipoComision(tipoComisionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoComision(int TipoComisionId)
        {
            return Json(tipoComisionBL.BuscarTipoComisionID(TipoComisionId));
        }

        public ActionResult ActualizarTipoComision(int TipoComisionId, string Codigo, string Descripcion)
        {
            TipoComisionDTO tipoComisionDTO = new();
            tipoComisionDTO.TipoComisionId = TipoComisionId;
            tipoComisionDTO.DescTipoComision = Descripcion;
            tipoComisionDTO.CodigoTipoComision = Codigo;
            tipoComisionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoComisionBL.ActualizarTipoComision(tipoComisionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoComision(int TipoComisionId)
        {
            TipoComisionDTO tipoComisionDTO = new();
            tipoComisionDTO.TipoComisionId = TipoComisionId;
            tipoComisionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoComisionBL.EliminarTipoComision(tipoComisionDTO);

            return Content(IND_OPERACION);
        }
    }
}
