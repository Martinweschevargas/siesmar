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
    public class TipoPublicacionController : Controller
    {
        readonly ILogger<TipoPublicacionController> _logger;

        public TipoPublicacionController(ILogger<TipoPublicacionController> logger)
        {
            _logger = logger;
        }

        readonly TipoPublicacionDAO tipoPublicacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Publicaciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoPublicacionDTO> listaTipoPublicacions = tipoPublicacionBL.ObtenerTipoPublicacions();
            return Json(new { data = listaTipoPublicacions });
        }

        public ActionResult InsertarTipoPublicacion(string DescTipoPublicacion )
        {
            var IND_OPERACION = "";
            try
            {
                TipoPublicacionDTO tipoPublicacionDTO = new();
                tipoPublicacionDTO.DescTipoPublicacion = DescTipoPublicacion;
                tipoPublicacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoPublicacionBL.AgregarTipoPublicacion(tipoPublicacionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoPublicacion(int TipoPublicacionId)
        {
            return Json(tipoPublicacionBL.BuscarTipoPublicacionID(TipoPublicacionId));
        }

        public ActionResult ActualizarTipoPublicacion(int TipoPublicacionId, string DescTipoPublicacion)
        {
            TipoPublicacionDTO tipoPublicacionDTO = new();
            tipoPublicacionDTO.TipoPublicacionId = TipoPublicacionId;
            tipoPublicacionDTO.DescTipoPublicacion = DescTipoPublicacion;
            tipoPublicacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoPublicacionBL.ActualizarTipoPublicacion(tipoPublicacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoPublicacion(int TipoPublicacionId)
        {
            TipoPublicacionDTO tipoPublicacionDTO = new();
            tipoPublicacionDTO.TipoPublicacionId = TipoPublicacionId;
            tipoPublicacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoPublicacionBL.EliminarTipoPublicacion(tipoPublicacionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}

