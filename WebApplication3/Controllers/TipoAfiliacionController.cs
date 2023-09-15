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
    public class TipoAfiliacionController : Controller
    {
        readonly ILogger<TipoAfiliacionController> _logger;

        public TipoAfiliacionController(ILogger<TipoAfiliacionController> logger)
        {
            _logger = logger;
        }

        readonly TipoAfiliacionDAO tipoAfiliacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Afiliaciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoAfiliacionDTO> listaTipoAfiliacions = tipoAfiliacionBL.ObtenerTipoAfiliacions();
            return Json(new { data = listaTipoAfiliacions });
        }

        public ActionResult InsertarTipoAfiliacion(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoAfiliacionDTO tipoAfiliacionDTO = new();
                tipoAfiliacionDTO.DescTipoAfiliacion = Descripcion;
                tipoAfiliacionDTO.CodigoTipoAfiliacion = Codigo;
                tipoAfiliacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoAfiliacionBL.AgregarTipoAfiliacion(tipoAfiliacionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoAfiliacion(int TipoAfiliacionId)
        {
            return Json(tipoAfiliacionBL.BuscarTipoAfiliacionID(TipoAfiliacionId));
        }

        public ActionResult ActualizarTipoAfiliacion(int TipoAfiliacionId, string Codigo, string Descripcion)
        {
            TipoAfiliacionDTO tipoAfiliacionDTO = new();
            tipoAfiliacionDTO.TipoAfiliacionId = TipoAfiliacionId;
            tipoAfiliacionDTO.DescTipoAfiliacion = Descripcion;
            tipoAfiliacionDTO.CodigoTipoAfiliacion = Codigo;
            tipoAfiliacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoAfiliacionBL.ActualizarTipoAfiliacion(tipoAfiliacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoAfiliacion(int TipoAfiliacionId)
        {
            TipoAfiliacionDTO tipoAfiliacionDTO = new();
            tipoAfiliacionDTO.TipoAfiliacionId = TipoAfiliacionId;
            tipoAfiliacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoAfiliacionBL.EliminarTipoAfiliacion(tipoAfiliacionDTO);

            return Content(IND_OPERACION);
        }
    }
}
