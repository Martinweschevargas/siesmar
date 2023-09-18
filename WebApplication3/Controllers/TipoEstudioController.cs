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
    public class TipoEstudioController : Controller
    {
        readonly ILogger<TipoEstudioController> _logger;

        public TipoEstudioController(ILogger<TipoEstudioController> logger)
        {
            _logger = logger;
        }

        readonly TipoEstudioDAO tipoEstudioBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Estudios", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoEstudioDTO> listaTipoEstudios = tipoEstudioBL.ObtenerTipoEstudios();
            return Json(new { data = listaTipoEstudios });
        }

        public ActionResult InsertarTipoEstudio(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoEstudioDTO tipoEstudioDTO = new();
                tipoEstudioDTO.DescTipoEstudio = Descripcion;
                tipoEstudioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoEstudioBL.AgregarTipoEstudio(tipoEstudioDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoEstudio(int TipoEstudioId)
        {
            return Json(tipoEstudioBL.BuscarTipoEstudioID(TipoEstudioId));
        }

        public ActionResult ActualizarTipoEstudio(int TipoEstudioId, string Descripcion)
        {
            TipoEstudioDTO tipoEstudioDTO = new();
            tipoEstudioDTO.TipoEstudioId = TipoEstudioId;
            tipoEstudioDTO.DescTipoEstudio = Descripcion;
            tipoEstudioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoEstudioBL.ActualizarTipoEstudio(tipoEstudioDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoEstudio(int TipoEstudioId)
        {
            TipoEstudioDTO tipoEstudioDTO = new();
            tipoEstudioDTO.TipoEstudioId = TipoEstudioId;
            tipoEstudioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoEstudioBL.EliminarTipoEstudio(tipoEstudioDTO);

            return Content(IND_OPERACION);
        }
    }
}
