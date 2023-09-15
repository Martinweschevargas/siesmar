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
    public class TipoPresenteProtocolarController : Controller
    {
        readonly ILogger<TipoPresenteProtocolarController> _logger;

        public TipoPresenteProtocolarController(ILogger<TipoPresenteProtocolarController> logger)
        {
            _logger = logger;
        }

        readonly TipoPresenteProtocolarDAO tipoPresenteProtocolarBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Presentes Protocolares", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoPresenteProtocolarDTO> listaTipoPresenteProtocolars = tipoPresenteProtocolarBL.ObtenerTipoPresenteProtocolars();
            return Json(new { data = listaTipoPresenteProtocolars });
        }

        public ActionResult InsertarTipoPresenteProtocolar(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoPresenteProtocolarDTO tipoPresenteProtocolarDTO = new();
                tipoPresenteProtocolarDTO.DescTipoPresenteProtocolar = Descripcion;
                tipoPresenteProtocolarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoPresenteProtocolarBL.AgregarTipoPresenteProtocolar(tipoPresenteProtocolarDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoPresenteProtocolar(int TipoPresenteProtocolarId)
        {
            return Json(tipoPresenteProtocolarBL.BuscarTipoPresenteProtocolarID(TipoPresenteProtocolarId));
        }

        public ActionResult ActualizarTipoPresenteProtocolar(int TipoPresenteProtocolarId, string Descripcion)
        {
            TipoPresenteProtocolarDTO tipoPresenteProtocolarDTO = new();
            tipoPresenteProtocolarDTO.TipoPresenteProtocolarId = TipoPresenteProtocolarId;
            tipoPresenteProtocolarDTO.DescTipoPresenteProtocolar = Descripcion;
            tipoPresenteProtocolarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoPresenteProtocolarBL.ActualizarTipoPresenteProtocolar(tipoPresenteProtocolarDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoPresenteProtocolar(int TipoPresenteProtocolarId)
        {
            TipoPresenteProtocolarDTO tipoPresenteProtocolarDTO = new();
            tipoPresenteProtocolarDTO.TipoPresenteProtocolarId = TipoPresenteProtocolarId;
            tipoPresenteProtocolarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoPresenteProtocolarBL.EliminarTipoPresenteProtocolar(tipoPresenteProtocolarDTO);

            return Content(IND_OPERACION);
        }
    }
}
