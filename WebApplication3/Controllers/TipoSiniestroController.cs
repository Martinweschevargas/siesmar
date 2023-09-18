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
    public class TipoSiniestroController : Controller
    {
        readonly ILogger<TipoSiniestroController> _logger;

        public TipoSiniestroController(ILogger<TipoSiniestroController> logger)
        {
            _logger = logger;
        }

        readonly TipoSiniestroDAO TipoSiniestroBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Siniestros", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoSiniestroDTO> listaTipoSiniestros = TipoSiniestroBL.ObtenerTipoSiniestros();
            return Json(new { data = listaTipoSiniestros });
        }

        public ActionResult InsertarTipoSiniestro(string DescTipoSiniestro, string CodTipoSiniestro)
        {
            var IND_OPERACION = "";
            try
            {
                TipoSiniestroDTO TipoSiniestroDTO = new();
                TipoSiniestroDTO.DescTipoSiniestro = DescTipoSiniestro;
                TipoSiniestroDTO.CodTipoSiniestro = CodTipoSiniestro;
                TipoSiniestroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = TipoSiniestroBL.AgregarTipoSiniestro(TipoSiniestroDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoSiniestro(int TipoSiniestroId)
        {
            return Json(TipoSiniestroBL.BuscarTipoSiniestroID(TipoSiniestroId));
        }

        public ActionResult ActualizarTipoSiniestro(int TipoSiniestroId, string DescTipoSiniestro, string CodTipoSiniestro)
        {
            TipoSiniestroDTO TipoSiniestroDTO = new();
            TipoSiniestroDTO.TipoSiniestroId = TipoSiniestroId;
            TipoSiniestroDTO.DescTipoSiniestro = DescTipoSiniestro;
            TipoSiniestroDTO.CodTipoSiniestro = CodTipoSiniestro;
            TipoSiniestroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoSiniestroBL.ActualizarTipoSiniestro(TipoSiniestroDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoSiniestro(int TipoSiniestroId)
        {
            TipoSiniestroDTO TipoSiniestroDTO = new();
            TipoSiniestroDTO.TipoSiniestroId = TipoSiniestroId;
            TipoSiniestroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoSiniestroBL.EliminarTipoSiniestro(TipoSiniestroDTO);

            return Content(IND_OPERACION);
        }
    }
}
