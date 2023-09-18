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
    public class TipoProcesoDirnotematController : Controller
    {
        readonly ILogger<TipoProcesoDirnotematController> _logger;

        public TipoProcesoDirnotematController(ILogger<TipoProcesoDirnotematController> logger)
        {
            _logger = logger;
        }

        readonly TipoProcesoDirnotematDAO tipoProcesoDirnotematBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Procesos Dirnotemat", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoProcesoDirnotematDTO> listaTipoProcesoDirnotemats = tipoProcesoDirnotematBL.ObtenerTipoProcesoDirnotemats();
            return Json(new { data = listaTipoProcesoDirnotemats });
        }

        public ActionResult InsertarTipoProcesoDirnotemat(string DescTipoProcesoDirnotemat, string CodigoTipoProcesoDirnotemat)
        {
            var IND_OPERACION="";
            try
            {
                TipoProcesoDirnotematDTO tipoProcesoDirnotematDTO = new();
                tipoProcesoDirnotematDTO.DescTipoProcesoDirnotemat = DescTipoProcesoDirnotemat;
                tipoProcesoDirnotematDTO.CodigoTipoProcesoDirnotemat = CodigoTipoProcesoDirnotemat;
                tipoProcesoDirnotematDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoProcesoDirnotematBL.AgregarTipoProcesoDirnotemat(tipoProcesoDirnotematDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoProcesoDirnotemat(int TipoProcesoDirnotematId)
        {
            return Json(tipoProcesoDirnotematBL.BuscarTipoProcesoDirnotematID(TipoProcesoDirnotematId));
        }

        public ActionResult ActualizarTipoProcesoDirnotemat(int TipoProcesoDirnotematId, string DescTipoProcesoDirnotemat, string CodigoTipoProcesoDirnotemat)
        {
            TipoProcesoDirnotematDTO tipoProcesoDirnotematDTO = new();
            tipoProcesoDirnotematDTO.TipoProcesoDirnotematId = TipoProcesoDirnotematId;
            tipoProcesoDirnotematDTO.DescTipoProcesoDirnotemat = DescTipoProcesoDirnotemat;
            tipoProcesoDirnotematDTO.CodigoTipoProcesoDirnotemat = CodigoTipoProcesoDirnotemat;
            tipoProcesoDirnotematDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoProcesoDirnotematBL.ActualizarTipoProcesoDirnotemat(tipoProcesoDirnotematDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoProcesoDirnotemat(int TipoProcesoDirnotematId)
        {
            TipoProcesoDirnotematDTO tipoProcesoDirnotematDTO = new();
            tipoProcesoDirnotematDTO.TipoProcesoDirnotematId = TipoProcesoDirnotematId;
            tipoProcesoDirnotematDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoProcesoDirnotematBL.EliminarTipoProcesoDirnotemat(tipoProcesoDirnotematDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
