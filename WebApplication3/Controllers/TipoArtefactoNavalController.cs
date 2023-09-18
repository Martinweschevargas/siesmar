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
    public class TipoArtefactoNavalController : Controller
    {
        readonly ILogger<TipoArtefactoNavalController> _logger;

        public TipoArtefactoNavalController(ILogger<TipoArtefactoNavalController> logger)
        {
            _logger = logger;
        }

        readonly TipoArtefactoNavalDAO tipoArtefactoNavalBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Artefactos Navales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoArtefactoNavalDTO> listaTipoArtefactoNavals = tipoArtefactoNavalBL.ObtenerTipoArtefactoNavals();
            return Json(new { data = listaTipoArtefactoNavals });
        }

        public ActionResult InsertarTipoArtefactoNaval(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoArtefactoNavalDTO tipoArtefactoNavalDTO = new();
                tipoArtefactoNavalDTO.DescTipoArtefactoNaval = Descripcion;
                tipoArtefactoNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoArtefactoNavalBL.AgregarTipoArtefactoNaval(tipoArtefactoNavalDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoArtefactoNaval(int TipoArtefactoNavalId)
        {
            return Json(tipoArtefactoNavalBL.BuscarTipoArtefactoNavalID(TipoArtefactoNavalId));
        }

        public ActionResult ActualizarTipoArtefactoNaval(int TipoArtefactoNavalId, string Descripcion)
        {
            TipoArtefactoNavalDTO tipoArtefactoNavalDTO = new();
            tipoArtefactoNavalDTO.TipoArtefactoNavalId = TipoArtefactoNavalId;
            tipoArtefactoNavalDTO.DescTipoArtefactoNaval = Descripcion;
            tipoArtefactoNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoArtefactoNavalBL.ActualizarTipoArtefactoNaval(tipoArtefactoNavalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoArtefactoNaval(int TipoArtefactoNavalId)
        {
            TipoArtefactoNavalDTO tipoArtefactoNavalDTO = new();
            tipoArtefactoNavalDTO.TipoArtefactoNavalId = TipoArtefactoNavalId;
            tipoArtefactoNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoArtefactoNavalBL.EliminarTipoArtefactoNaval(tipoArtefactoNavalDTO);

            return Content(IND_OPERACION);
        }
    }
}
