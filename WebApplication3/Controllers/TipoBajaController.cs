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
    public class TipoBajaController : Controller
    {
        readonly ILogger<TipoBajaController> _logger;

        public TipoBajaController(ILogger<TipoBajaController> logger)
        {
            _logger = logger;
        }

        readonly TipoBaja tipoBajaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Bajas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoBajaDTO> listaTipoBajas = tipoBajaBL.ObtenerTipoBajas();
            return Json(new { data = listaTipoBajas });
        }

        public ActionResult InsertarTipoBaja(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoBajaDTO tipoBajaDTO = new();
                tipoBajaDTO.DescTipoBaja = Descripcion;
                tipoBajaDTO.CodigoTipoBaja = Codigo;
                tipoBajaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoBajaBL.AgregarTipoBaja(tipoBajaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoBaja(int TipoBajaId)
        {
            return Json(tipoBajaBL.BuscarTipoBajaID(TipoBajaId));
        }

        public ActionResult ActualizarTipoBaja(int TipoBajaId, string Codigo, string Descripcion)
        {
            TipoBajaDTO tipoBajaDTO = new();
            tipoBajaDTO.TipoBajaId = TipoBajaId;
            tipoBajaDTO.DescTipoBaja = Descripcion;
            tipoBajaDTO.CodigoTipoBaja = Codigo;
            tipoBajaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoBajaBL.ActualizarTipoBaja(tipoBajaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoBaja(int TipoBajaId)
        {
            TipoBajaDTO tipoBajaDTO = new();
            tipoBajaDTO.TipoBajaId = TipoBajaId;
            tipoBajaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoBajaBL.EliminarTipoBaja(tipoBajaDTO);

            return Content(IND_OPERACION);
        }
    }
}
