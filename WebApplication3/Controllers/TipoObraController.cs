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
    public class TipoObraController : Controller
    {
        readonly ILogger<TipoObraController> _logger;

        public TipoObraController(ILogger<TipoObraController> logger)
        {
            _logger = logger;
        }

        readonly TipoObraDAO tipoObraBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Obras", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoObraDTO> listaTipoObras = tipoObraBL.ObtenerTipoObras();
            return Json(new { data = listaTipoObras });
        }

        public ActionResult InsertarTipoObra(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoObraDTO tipoObraDTO = new();
                tipoObraDTO.DescTipoObra = Descripcion;
                tipoObraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoObraBL.AgregarTipoObra(tipoObraDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoObra(int TipoObraId)
        {
            return Json(tipoObraBL.BuscarTipoObraID(TipoObraId));
        }

        public ActionResult ActualizarTipoObra(int TipoObraId, string Descripcion)
        {
            TipoObraDTO tipoObraDTO = new();
            tipoObraDTO.TipoObraId = TipoObraId;
            tipoObraDTO.DescTipoObra = Descripcion;
            tipoObraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoObraBL.ActualizarTipoObra(tipoObraDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoObra(int TipoObraId)
        {
            TipoObraDTO tipoObraDTO = new();
            tipoObraDTO.TipoObraId = TipoObraId;
            tipoObraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoObraBL.EliminarTipoObra(tipoObraDTO);

            return Content(IND_OPERACION);
        }
    }
}
