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
    public class TipoPuertoPeruController : Controller
    {
        readonly ILogger<TipoPuertoPeruController> _logger;

        public TipoPuertoPeruController(ILogger<TipoPuertoPeruController> logger)
        {
            _logger = logger;
        }

        readonly TipoPuertoPeruDAO TipoPuertoPeruBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Puertos Perú", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoPuertoPeruDTO> listaTipoPuertoPerus = TipoPuertoPeruBL.ObtenerTipoPuertoPerus();
            return Json(new { data = listaTipoPuertoPerus });
        }

        public ActionResult InsertarTipoPuertoPeru(string Descripcion, string Codigo)
        {
            var IND_OPERACION="";
            try
            {
                TipoPuertoPeruDTO TipoPuertoPeruDTO = new();
                TipoPuertoPeruDTO.DescTipoPuertoPeru = Descripcion;
                TipoPuertoPeruDTO.CodigoTipoPuertoPeru = Codigo;
                TipoPuertoPeruDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = TipoPuertoPeruBL.AgregarTipoPuertoPeru(TipoPuertoPeruDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoPuertoPeru(int TipoPuertoPeruId)
        {
            return Json(TipoPuertoPeruBL.BuscarTipoPuertoPeruID(TipoPuertoPeruId));
        }

        public ActionResult ActualizarTipoPuertoPeru(int TipoPuertoPeruId, string Codigo, string Descripcion)
        {
            TipoPuertoPeruDTO TipoPuertoPeruDTO = new();
            TipoPuertoPeruDTO.TipoPuertoPeruId = TipoPuertoPeruId;
            TipoPuertoPeruDTO.DescTipoPuertoPeru = Descripcion;
            TipoPuertoPeruDTO.CodigoTipoPuertoPeru = Codigo;
            TipoPuertoPeruDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoPuertoPeruBL.ActualizarTipoPuertoPeru(TipoPuertoPeruDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoPuertoPeru(int TipoPuertoPeruId)
        {
            TipoPuertoPeruDTO TipoPuertoPeruDTO = new();
            TipoPuertoPeruDTO.TipoPuertoPeruId = TipoPuertoPeruId;
            TipoPuertoPeruDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoPuertoPeruBL.EliminarTipoPuertoPeru(TipoPuertoPeruDTO);

            return Content(IND_OPERACION);
        }
    }
}
