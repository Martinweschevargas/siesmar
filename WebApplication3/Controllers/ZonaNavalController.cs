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
    public class ZonaNavalController : Controller
    {
        readonly ZonaNavalDAO zonaNavalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Zonas Navales", FromController = typeof(HomeController))]

        public IActionResult Index()
        {
         
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ZonaNavalDTO> listaZonaNavals = zonaNavalBL.ObtenerZonaNavals();
            return Json(new { data = listaZonaNavals });
        }

        public ActionResult InsertarZonaNaval(string DescZonaNaval, string CodigoZonaNaval)
        {
            ZonaNavalDTO zonaNavalDTO = new();
            zonaNavalDTO.DescZonaNaval = DescZonaNaval;
            zonaNavalDTO.CodigoZonaNaval = CodigoZonaNaval;
            zonaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = zonaNavalBL.AgregarZonaNaval(zonaNavalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarZonaNaval(int ZonaNavalId)
        {
            return Json(zonaNavalBL.BuscarZonaNavalID(ZonaNavalId));
        }

        public ActionResult ActualizarZonaNaval(int ZonaNavalId, string DescZonaNaval, string CodigoZonaNaval)
        {
            ZonaNavalDTO zonaNavalDTO = new();
            zonaNavalDTO.ZonaNavalId = ZonaNavalId;
            zonaNavalDTO.DescZonaNaval = DescZonaNaval;
            zonaNavalDTO.CodigoZonaNaval = CodigoZonaNaval;
            zonaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = zonaNavalBL.ActualizarZonaNaval(zonaNavalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarZonaNaval(int ZonaNavalId)
        {
            ZonaNavalDTO zonaNavalDTO = new();
            zonaNavalDTO.ZonaNavalId = ZonaNavalId;
            zonaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (zonaNavalBL.EliminarZonaNaval(zonaNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
