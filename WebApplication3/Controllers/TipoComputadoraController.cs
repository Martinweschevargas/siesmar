using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class TipoComputadoraController : Controller
    {
        readonly ILogger<TipoComputadoraController> _logger;

        public TipoComputadoraController(ILogger<TipoComputadoraController> logger)
        {
            _logger = logger;
        }

        readonly TipoComputadoraDAO tipoComputadoraBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Computadoras", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoComputadoraDTO> listaTipoComputadoras = tipoComputadoraBL.ObtenerTipoComputadoras();
            return Json(new { data = listaTipoComputadoras });
        }

        public ActionResult InsertarTipoComputadora(string DescTipoComputadora, string CodigoTipoComputadora)
        {
            var IND_OPERACION="";
            try
            {
                TipoComputadoraDTO tipoComputadoraDTO = new();
                tipoComputadoraDTO.DescTipoComputadora = DescTipoComputadora;
                tipoComputadoraDTO.CodigoTipoComputadora = CodigoTipoComputadora;
                tipoComputadoraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoComputadoraBL.AgregarTipoComputadora(tipoComputadoraDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoComputadora(int TipoComputadoraId)
        {
            return Json(tipoComputadoraBL.BuscarTipoComputadoraID(TipoComputadoraId));
        }

        public ActionResult ActualizarTipoComputadora(int TipoComputadoraId, string DescTipoComputadora, string CodigoTipoComputadora)
        {
            TipoComputadoraDTO tipoComputadoraDTO = new();
            tipoComputadoraDTO.TipoComputadoraId = TipoComputadoraId;
            tipoComputadoraDTO.DescTipoComputadora = DescTipoComputadora;
            tipoComputadoraDTO.CodigoTipoComputadora = CodigoTipoComputadora;
            tipoComputadoraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoComputadoraBL.ActualizarTipoComputadora(tipoComputadoraDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoComputadora(int TipoComputadoraId)
        {
            TipoComputadoraDTO tipoComputadoraDTO = new();
            tipoComputadoraDTO.TipoComputadoraId = TipoComputadoraId;
            tipoComputadoraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoComputadoraBL.EliminarTipoComputadora(tipoComputadoraDTO);

            return Content(IND_OPERACION);
        }
    }
}
