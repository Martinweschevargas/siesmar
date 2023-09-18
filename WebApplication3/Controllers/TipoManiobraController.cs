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
    public class TipoManiobraController : Controller
    {
        readonly ILogger<TipoManiobraController> _logger;

        public TipoManiobraController(ILogger<TipoManiobraController> logger)
        {
            _logger = logger;
        }

        readonly TipoManiobraDAO tipoManiobraBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Maniobras", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoManiobraDTO> listaTipoManiobras = tipoManiobraBL.ObtenerTipoManiobras();
            return Json(new { data = listaTipoManiobras });
        }

        public ActionResult InsertarTipoManiobra(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoManiobraDTO tipoManiobraDTO = new();
                tipoManiobraDTO.DescTipoManiobra = Descripcion;
                tipoManiobraDTO.CodigoTipoManiobra = Codigo;
                tipoManiobraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoManiobraBL.AgregarTipoManiobra(tipoManiobraDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoManiobra(int TipoManiobraId)
        {
            return Json(tipoManiobraBL.BuscarTipoManiobraID(TipoManiobraId));
        }

        public ActionResult ActualizarTipoManiobra(int TipoManiobraId, string Codigo, string Descripcion)
        {
            TipoManiobraDTO tipoManiobraDTO = new();
            tipoManiobraDTO.TipoManiobraId = TipoManiobraId;
            tipoManiobraDTO.DescTipoManiobra = Descripcion;
            tipoManiobraDTO.CodigoTipoManiobra = Codigo;
            tipoManiobraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoManiobraBL.ActualizarTipoManiobra(tipoManiobraDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoManiobra(int TipoManiobraId)
        {
            TipoManiobraDTO tipoManiobraDTO = new();
            tipoManiobraDTO.TipoManiobraId = TipoManiobraId;
            tipoManiobraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoManiobraBL.EliminarTipoManiobra(tipoManiobraDTO);

            return Content(IND_OPERACION);
        }
    }
}
