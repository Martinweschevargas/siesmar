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
    public class TipoPrestamoConvenioController : Controller
    {
        readonly ILogger<TipoPrestamoConvenioController> _logger;

        public TipoPrestamoConvenioController(ILogger<TipoPrestamoConvenioController> logger)
        {
            _logger = logger;
        }

        readonly TipoPrestamoConvenioDAO TipoPrestamoConvenioBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Prestamos Convenios", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoPrestamoConvenioDTO> listaTipoPrestamoConvenios = TipoPrestamoConvenioBL.ObtenerTipoPrestamoConvenios();
            return Json(new { data = listaTipoPrestamoConvenios });
        }

        public ActionResult InsertarTipoPrestamoConvenio(string CodigoTipoPrestamoConvenio, string DescTipoPrestamoConvenio)
        {
            var IND_OPERACION="";
            try
            {
                TipoPrestamoConvenioDTO TipoPrestamoConvenioDTO = new();
                TipoPrestamoConvenioDTO.DescTipoPrestamoConvenio = DescTipoPrestamoConvenio;
                TipoPrestamoConvenioDTO.CodigoTipoPrestamoConvenio = CodigoTipoPrestamoConvenio;
                TipoPrestamoConvenioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = TipoPrestamoConvenioBL.AgregarTipoPrestamoConvenio(TipoPrestamoConvenioDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoPrestamoConvenio(int TipoPrestamoConvenioId)
        {
            return Json(TipoPrestamoConvenioBL.BuscarTipoPrestamoConvenioID(TipoPrestamoConvenioId));
        }

        public ActionResult ActualizarTipoPrestamoConvenio(int TipoPrestamoConvenioId, string CodigoTipoPrestamoConvenio, string DescTipoPrestamoConvenio)
        {
            TipoPrestamoConvenioDTO TipoPrestamoConvenioDTO = new();
            TipoPrestamoConvenioDTO.TipoPrestamoConvenioId = TipoPrestamoConvenioId;
            TipoPrestamoConvenioDTO.DescTipoPrestamoConvenio = DescTipoPrestamoConvenio;
            TipoPrestamoConvenioDTO.CodigoTipoPrestamoConvenio = CodigoTipoPrestamoConvenio;
            TipoPrestamoConvenioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoPrestamoConvenioBL.ActualizarTipoPrestamoConvenio(TipoPrestamoConvenioDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoPrestamoConvenio(int TipoPrestamoConvenioId)
        {
            TipoPrestamoConvenioDTO TipoPrestamoConvenioDTO = new();
            TipoPrestamoConvenioDTO.TipoPrestamoConvenioId = TipoPrestamoConvenioId;
            TipoPrestamoConvenioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoPrestamoConvenioBL.EliminarTipoPrestamoConvenio(TipoPrestamoConvenioDTO);

            return Content(IND_OPERACION);
        }
    }
}
