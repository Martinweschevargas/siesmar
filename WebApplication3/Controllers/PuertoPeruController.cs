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
    public class PuertoPeruController : Controller
    {
        readonly ILogger<PuertoPeruController> _logger;

        public PuertoPeruController(ILogger<PuertoPeruController> logger)
        {
            _logger = logger;
        }

        readonly PuertoPeruDAO PuertoPeruBL = new();
        Usuario usuarioBL = new();

        TipoPuertoPeruDAO tipoPuertoPerulBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Puertos Peru", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<TipoPuertoPeruDTO> tipoPuertoPerulDTO = tipoPuertoPerulBL.ObtenerTipoPuertoPerus();

            return Json(new { data = tipoPuertoPerulDTO });
        }

        public JsonResult CargarDatos()
        {
            List<PuertoPeruDTO> listaPuertoPerues = PuertoPeruBL.ObtenerPuertoPerus();
            return Json(new { data = listaPuertoPerues });
        }

        public ActionResult InsertarPuertoPeru(string Descripcion, string Codigo, int TipoPuertoPeruId)
        {
            var IND_OPERACION = "";
            try
            {
                PuertoPeruDTO PuertoPeruDTO = new();
                PuertoPeruDTO.DescPuertoPeru = Descripcion;
                PuertoPeruDTO.CodigoPuertoPeru = Codigo;
                PuertoPeruDTO.TipoPuertoPeruId = TipoPuertoPeruId;
                PuertoPeruDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = PuertoPeruBL.AgregarPuertoPeru(PuertoPeruDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarPuertoPeru(int PuertoPeruId)
        {
            return Json(PuertoPeruBL.BuscarPuertoPeruID(PuertoPeruId));
        }

        public ActionResult ActualizarPuertoPeru(int PuertoPeruId, string Descripcion, string Codigo, int TipoPuertoPeruId)
        {
            PuertoPeruDTO PuertoPeruDTO = new();
            PuertoPeruDTO.PuertoPeruId = PuertoPeruId;
            PuertoPeruDTO.DescPuertoPeru = Descripcion;
            PuertoPeruDTO.CodigoPuertoPeru = Codigo;
            PuertoPeruDTO.TipoPuertoPeruId = TipoPuertoPeruId;
            PuertoPeruDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = PuertoPeruBL.ActualizarPuertoPeru(PuertoPeruDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPuertoPeru(int PuertoPeruId)
        {
            PuertoPeruDTO PuertoPeruDTO = new();
            PuertoPeruDTO.PuertoPeruId = PuertoPeruId;
            PuertoPeruDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = PuertoPeruBL.EliminarPuertoPeru(PuertoPeruDTO);

            return Content(IND_OPERACION);
        }
    }
}
