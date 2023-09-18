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
    public class TipoPlataformaNaveController : Controller
    {
        readonly ILogger<TipoPlataformaNaveController> _logger;

        public TipoPlataformaNaveController(ILogger<TipoPlataformaNaveController> logger)
        {
            _logger = logger;
        }

        readonly TipoPlataformaNaveDAO tipoPlataformaNaveBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Plataformas Naves", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoPlataformaNaveDTO> listaTipoPlataformaNaves = tipoPlataformaNaveBL.ObtenerTipoPlataformaNaves();
            return Json(new { data = listaTipoPlataformaNaves });
        }

        public ActionResult InsertarTipoPlataformaNave(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoPlataformaNaveDTO tipoPlataformaNaveDTO = new();
                tipoPlataformaNaveDTO.DescTipoPlataformaNave = Descripcion;
                tipoPlataformaNaveDTO.CodigoTipoPlataformaNave = Codigo;
                tipoPlataformaNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoPlataformaNaveBL.AgregarTipoPlataformaNave(tipoPlataformaNaveDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoPlataformaNave(int TipoPlataformaNaveId)
        {
            return Json(tipoPlataformaNaveBL.BuscarTipoPlataformaNaveID(TipoPlataformaNaveId));
        }

        public ActionResult ActualizarTipoPlataformaNave(int TipoPlataformaNaveId, string Codigo, string Descripcion)
        {
            TipoPlataformaNaveDTO tipoPlataformaNaveDTO = new();
            tipoPlataformaNaveDTO.TipoPlataformaNaveId = TipoPlataformaNaveId;
            tipoPlataformaNaveDTO.DescTipoPlataformaNave = Descripcion;
            tipoPlataformaNaveDTO.CodigoTipoPlataformaNave = Codigo;
            tipoPlataformaNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoPlataformaNaveBL.ActualizarTipoPlataformaNave(tipoPlataformaNaveDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoPlataformaNave(int TipoPlataformaNaveId)
        {
            TipoPlataformaNaveDTO tipoPlataformaNaveDTO = new();
            tipoPlataformaNaveDTO.TipoPlataformaNaveId = TipoPlataformaNaveId;
            tipoPlataformaNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoPlataformaNaveBL.EliminarTipoPlataformaNave(tipoPlataformaNaveDTO);

            return Content(IND_OPERACION);
        }
    }
}
