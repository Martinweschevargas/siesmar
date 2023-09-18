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
    public class TipoNaveController : Controller
    {
        readonly ILogger<TipoNaveController> _logger;

        public TipoNaveController(ILogger<TipoNaveController> logger)
        {
            _logger = logger;
        }

        readonly TipoNaveDAO tipoNaveBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Naves", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoNaveDTO> listaTipoNaves = tipoNaveBL.ObtenerTipoNaves();
            return Json(new { data = listaTipoNaves });
        }

        public ActionResult InsertarTipoNave(string DescTipoNave)
        {
            var IND_OPERACION = "";
            try
            {
                TipoNaveDTO tipoNaveDTO = new();
                tipoNaveDTO.DescTipoNave = DescTipoNave;
                tipoNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoNaveBL.AgregarTipoNave(tipoNaveDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoNave(int TipoNaveId)
        {
            return Json(tipoNaveBL.BuscarTipoNaveID(TipoNaveId));
        }

        public ActionResult ActualizarTipoNave(int TipoNaveId, string DescTipoNave)
        {
            TipoNaveDTO tipoNaveDTO = new();
            tipoNaveDTO.TipoNaveId = TipoNaveId;
            tipoNaveDTO.DescTipoNave = DescTipoNave;
            tipoNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoNaveBL.ActualizarTipoNave(tipoNaveDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoNave(int TipoNaveId)
        {
            TipoNaveDTO tipoNaveDTO = new();
            tipoNaveDTO.TipoNaveId = TipoNaveId;
            tipoNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoNaveBL.EliminarTipoNave(tipoNaveDTO);

            return Content(IND_OPERACION);
        }
    }
}
