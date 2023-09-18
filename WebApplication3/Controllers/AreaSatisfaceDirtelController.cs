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
    public class AreaSatisfaceDirtelController : Controller
    {
        readonly ILogger<AreaSatisfaceDirtelController> _logger;

        public AreaSatisfaceDirtelController(ILogger<AreaSatisfaceDirtelController> logger)
        {
            _logger = logger;
        }

        readonly AreaSatisfaceDirtelDAO areaSatisfaceDirtelBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "AreaSatisfaceDirtels", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<AreaSatisfaceDirtelDTO> listaAreaSatisfaceDirtels = areaSatisfaceDirtelBL.ObtenerAreaSatisfaceDirtels();
            return Json(new { data = listaAreaSatisfaceDirtels });
        }

        public ActionResult InsertarAreaSatisfaceDirtel(string DescAreaSatisfaceDirtel, string CodigoAreaSatisfaceDirtel)
        {
            var IND_OPERACION="";
            try
            {
                AreaSatisfaceDirtelDTO areaSatisfaceDirtelDTO = new();
                areaSatisfaceDirtelDTO.DescAreaSatisfaceDirtel = DescAreaSatisfaceDirtel;
                areaSatisfaceDirtelDTO.CodigoAreaSatisfaceDirtel = CodigoAreaSatisfaceDirtel;
                areaSatisfaceDirtelDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = areaSatisfaceDirtelBL.AgregarAreaSatisfaceDirtel(areaSatisfaceDirtelDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAreaSatisfaceDirtel(int AreaSatisfaceDirtelId)
        {
            return Json(areaSatisfaceDirtelBL.BuscarAreaSatisfaceDirtelID(AreaSatisfaceDirtelId));
        }

        public ActionResult ActualizarAreaSatisfaceDirtel(int AreaSatisfaceDirtelId, string DescAreaSatisfaceDirtel, string CodigoAreaSatisfaceDirtel)
        {
            AreaSatisfaceDirtelDTO areaSatisfaceDirtelDTO = new();
            areaSatisfaceDirtelDTO.AreaSatisfaceDirtelId = AreaSatisfaceDirtelId;
            areaSatisfaceDirtelDTO.DescAreaSatisfaceDirtel = DescAreaSatisfaceDirtel;
            areaSatisfaceDirtelDTO.CodigoAreaSatisfaceDirtel = CodigoAreaSatisfaceDirtel;
            areaSatisfaceDirtelDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = areaSatisfaceDirtelBL.ActualizarAreaSatisfaceDirtel(areaSatisfaceDirtelDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAreaSatisfaceDirtel(int AreaSatisfaceDirtelId)
        {
            AreaSatisfaceDirtelDTO areaSatisfaceDirtelDTO = new();
            areaSatisfaceDirtelDTO.AreaSatisfaceDirtelId = AreaSatisfaceDirtelId;
            areaSatisfaceDirtelDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = areaSatisfaceDirtelBL.EliminarAreaSatisfaceDirtel(areaSatisfaceDirtelDTO);

            return Content(IND_OPERACION);
        }
    }
}
