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
    public class TipoComunicacionDirtelController : Controller
    {
        readonly ILogger<TipoComunicacionDirtelController> _logger;

        public TipoComunicacionDirtelController(ILogger<TipoComunicacionDirtelController> logger)
        {
            _logger = logger;
        }

        readonly TipoComunicacionDirtelDAO tipoComunicacionDirtelBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tiposs Comunicaciones Dirtel", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoComunicacionDirtelDTO> listaTipoComunicacionDirtels = tipoComunicacionDirtelBL.ObtenerTipoComunicacionDirtels();
            return Json(new { data = listaTipoComunicacionDirtels });
        }

        public ActionResult InsertarTipoComunicacionDirtel(string DescTipoComunicacionDirtel, string CodigoTipoComunicacionDirtel)
        {
            var IND_OPERACION="";
            try
            {
                TipoComunicacionDirtelDTO tipoComunicacionDirtelDTO = new();
                tipoComunicacionDirtelDTO.DescTipoComunicacionDirtel = DescTipoComunicacionDirtel;
                tipoComunicacionDirtelDTO.CodigoTipoComunicacionDirtel = CodigoTipoComunicacionDirtel;
                tipoComunicacionDirtelDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoComunicacionDirtelBL.AgregarTipoComunicacionDirtel(tipoComunicacionDirtelDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoComunicacionDirtel(int TipoComunicacionDirtelId)
        {
            return Json(tipoComunicacionDirtelBL.BuscarTipoComunicacionDirtelID(TipoComunicacionDirtelId));
        }

        public ActionResult ActualizarTipoComunicacionDirtel(int TipoComunicacionDirtelId, string DescTipoComunicacionDirtel, string CodigoTipoComunicacionDirtel)
        {
            TipoComunicacionDirtelDTO tipoComunicacionDirtelDTO = new();
            tipoComunicacionDirtelDTO.TipoComunicacionDirtelId = TipoComunicacionDirtelId;
            tipoComunicacionDirtelDTO.DescTipoComunicacionDirtel = DescTipoComunicacionDirtel;
            tipoComunicacionDirtelDTO.CodigoTipoComunicacionDirtel = CodigoTipoComunicacionDirtel;
            tipoComunicacionDirtelDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoComunicacionDirtelBL.ActualizarTipoComunicacionDirtel(tipoComunicacionDirtelDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoComunicacionDirtel(int TipoComunicacionDirtelId)
        {
            TipoComunicacionDirtelDTO tipoComunicacionDirtelDTO = new();
            tipoComunicacionDirtelDTO.TipoComunicacionDirtelId = TipoComunicacionDirtelId;
            tipoComunicacionDirtelDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoComunicacionDirtelBL.EliminarTipoComunicacionDirtel(tipoComunicacionDirtelDTO);

            return Content(IND_OPERACION);
        }
    }
}
