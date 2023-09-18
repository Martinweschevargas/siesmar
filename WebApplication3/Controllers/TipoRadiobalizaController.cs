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
    public class TipoRadiobalizaController : Controller
    {
        readonly ILogger<TipoRadiobalizaController> _logger;

        public TipoRadiobalizaController(ILogger<TipoRadiobalizaController> logger)
        {
            _logger = logger;
        }

        readonly TipoRadiobalizaDAO TipoRadiobalizaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Radiobalizas", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoRadiobalizaDTO> listaTipoRadiobalizas = TipoRadiobalizaBL.ObtenerTipoRadiobalizas();
            return Json(new { data = listaTipoRadiobalizas });
        }

        public ActionResult InsertarTipoRadiobaliza(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                TipoRadiobalizaDTO TipoRadiobalizaDTO = new();
                TipoRadiobalizaDTO.DescTipoRadiobaliza = Descripcion;
                TipoRadiobalizaDTO.CodigoTipoRadiobaliza = Codigo;
                TipoRadiobalizaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = TipoRadiobalizaBL.AgregarTipoRadiobaliza(TipoRadiobalizaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoRadiobaliza(int TipoRadiobalizaId)
        {
            return Json(TipoRadiobalizaBL.BuscarTipoRadiobalizaID(TipoRadiobalizaId));
        }

        public ActionResult ActualizarTipoRadiobaliza(int TipoRadiobalizaId, string Codigo, string Descripcion)
        {
            TipoRadiobalizaDTO TipoRadiobalizaDTO = new();
            TipoRadiobalizaDTO.TipoRadiobalizaId = TipoRadiobalizaId;
            TipoRadiobalizaDTO.DescTipoRadiobaliza = Descripcion;
            TipoRadiobalizaDTO.CodigoTipoRadiobaliza = Codigo;
            TipoRadiobalizaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoRadiobalizaBL.ActualizarTipoRadiobaliza(TipoRadiobalizaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoRadiobaliza(int TipoRadiobalizaId)
        {
            TipoRadiobalizaDTO TipoRadiobalizaDTO = new();
            TipoRadiobalizaDTO.TipoRadiobalizaId = TipoRadiobalizaId;
            TipoRadiobalizaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoRadiobalizaBL.EliminarTipoRadiobaliza(TipoRadiobalizaDTO);

            return Content(IND_OPERACION);
        }
    }
}
