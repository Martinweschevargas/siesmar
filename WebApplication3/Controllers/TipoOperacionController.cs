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
    public class TipoOperacionController : Controller
    {
        readonly ILogger<TipoOperacionController> _logger;

        public TipoOperacionController(ILogger<TipoOperacionController> logger)
        {
            _logger = logger;
        }

        readonly TipoOperacionDAO tipoOperacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Operaciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoOperacionDTO> listaTipoOperacions = tipoOperacionBL.ObtenerTipoOperacions();
            return Json(new { data = listaTipoOperacions });
        }

        public ActionResult InsertarTipoOperacion(string DescTipoOperacion, string Operacion, string CodigoTipoOperacion)
        {
            TipoOperacionDTO tipoOperacionDTO = new();
            tipoOperacionDTO.DescTipoOperacion = DescTipoOperacion;
            tipoOperacionDTO.Operacion = Operacion;
            tipoOperacionDTO.CodigoTipoOperacion = CodigoTipoOperacion;
            tipoOperacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoOperacionBL.AgregarTipoOperacion(tipoOperacionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoOperacion(int TipoOperacionId)
        {
            return Json(tipoOperacionBL.BuscarTipoOperacionID(TipoOperacionId));
        }

        public ActionResult ActualizarTipoOperacion(int TipoOperacionId, string DescTipoOperacion, string Operacion, string CodigoTipoOperacion)
        {
            TipoOperacionDTO tipoOperacionDTO = new();
            tipoOperacionDTO.TipoOperacionId = TipoOperacionId;
            tipoOperacionDTO.DescTipoOperacion = DescTipoOperacion;
            tipoOperacionDTO.Operacion = Operacion;
            tipoOperacionDTO.CodigoTipoOperacion = CodigoTipoOperacion;
            tipoOperacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoOperacionBL.ActualizarTipoOperacion(tipoOperacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoOperacion(int TipoOperacionId)
        {
            TipoOperacionDTO tipoOperacionDTO = new();
            tipoOperacionDTO.TipoOperacionId = TipoOperacionId;
            tipoOperacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoOperacionBL.EliminarTipoOperacion(tipoOperacionDTO);

            return Content(IND_OPERACION);
        }
    }
}
