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
    public class TipoCombustibleComoperguardController : Controller
    {
        readonly ILogger<TipoCombustibleComoperguardController> _logger;

        public TipoCombustibleComoperguardController(ILogger<TipoCombustibleComoperguardController> logger)
        {
            _logger = logger;
        }

        readonly TipoCombustibleComoperguardDAO TipoCombustibleComoperguardBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Combustibles Comoperguards", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoCombustibleComoperguardDTO> listaTipoCombustibleComoperguards = TipoCombustibleComoperguardBL.ObtenerTipoCombustibleComoperguards();
            return Json(new { data = listaTipoCombustibleComoperguards });
        }

        public ActionResult InsertarTipoCombustibleComoperguard(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                TipoCombustibleComoperguardDTO TipoCombustibleComoperguardDTO = new();
                TipoCombustibleComoperguardDTO.DescTipoCombustibleComoperguard = Descripcion;
                TipoCombustibleComoperguardDTO.CodigoTipoCombustibleComoperguard = Codigo;
                TipoCombustibleComoperguardDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = TipoCombustibleComoperguardBL.AgregarTipoCombustibleComoperguard(TipoCombustibleComoperguardDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoCombustibleComoperguard(int TipoCombustibleComoperguardId)
        {
            return Json(TipoCombustibleComoperguardBL.BuscarTipoCombustibleComoperguardID(TipoCombustibleComoperguardId));
        }

        public ActionResult ActualizarTipoCombustibleComoperguard(int TipoCombustibleComoperguardId, string Codigo, string Descripcion)
        {
            TipoCombustibleComoperguardDTO TipoCombustibleComoperguardDTO = new();
            TipoCombustibleComoperguardDTO.TipoCombustibleComoperguardId = TipoCombustibleComoperguardId;
            TipoCombustibleComoperguardDTO.DescTipoCombustibleComoperguard = Descripcion;
            TipoCombustibleComoperguardDTO.CodigoTipoCombustibleComoperguard = Codigo;
            TipoCombustibleComoperguardDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoCombustibleComoperguardBL.ActualizarTipoCombustibleComoperguard(TipoCombustibleComoperguardDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoCombustibleComoperguard(int TipoCombustibleComoperguardId)
        {
            TipoCombustibleComoperguardDTO TipoCombustibleComoperguardDTO = new();
            TipoCombustibleComoperguardDTO.TipoCombustibleComoperguardId = TipoCombustibleComoperguardId;
            TipoCombustibleComoperguardDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoCombustibleComoperguardBL.EliminarTipoCombustibleComoperguard(TipoCombustibleComoperguardDTO);

            return Content(IND_OPERACION);
        }
    }
}
