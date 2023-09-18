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
    public class TipoCiberataqueController : Controller
    {
        readonly ILogger<TipoCiberataqueController> _logger;

        public TipoCiberataqueController(ILogger<TipoCiberataqueController> logger)
        {
            _logger = logger;
        }

        readonly TipoCiberataque tipoCiberataqueBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Ciberataques", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoCiberataqueDTO> listaTipoCiberataques = tipoCiberataqueBL.ObtenerTipoCiberataques();
            return Json(new { data = listaTipoCiberataques });
        }

        public ActionResult InsertarTipoCiberataque(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoCiberataqueDTO tipoCiberataqueDTO = new();
                tipoCiberataqueDTO.DescTipoCiberataque = Descripcion;
                tipoCiberataqueDTO.CodigoTipoCiberataque = Codigo;
                tipoCiberataqueDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoCiberataqueBL.AgregarTipoCiberataque(tipoCiberataqueDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoCiberataque(int TipoCiberataqueId)
        {
            return Json(tipoCiberataqueBL.BuscarTipoCiberataqueID(TipoCiberataqueId));
        }

        public ActionResult ActualizarTipoCiberataque(int TipoCiberataqueId, string Codigo, string Descripcion)
        {
            TipoCiberataqueDTO tipoCiberataqueDTO = new();
            tipoCiberataqueDTO.TipoCiberataqueId = TipoCiberataqueId;
            tipoCiberataqueDTO.DescTipoCiberataque = Descripcion;
            tipoCiberataqueDTO.CodigoTipoCiberataque = Codigo;
            tipoCiberataqueDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoCiberataqueBL.ActualizarTipoCiberataque(tipoCiberataqueDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoCiberataque(int TipoCiberataqueId)
        {
            TipoCiberataqueDTO tipoCiberataqueDTO = new();
            tipoCiberataqueDTO.TipoCiberataqueId = TipoCiberataqueId;
            tipoCiberataqueDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoCiberataqueBL.EliminarTipoCiberataque(tipoCiberataqueDTO);

            return Content(IND_OPERACION);
        }
    }
}
