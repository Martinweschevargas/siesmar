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
    public class MontoInversionController : Controller
    {
        readonly MontoInversionDAO montoInversionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Montos Inversiones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MontoInversionDTO> listaMontoInversions = montoInversionBL.ObtenerMontoInversions();
            return Json(new { data = listaMontoInversions });
        }

        public ActionResult InsertarMontoInversion(string DescMontoInversion, string CodigoMontoInversion)
        {
            MontoInversionDTO montoInversionDTO = new();
            montoInversionDTO.DescMontoInversion = DescMontoInversion;
            montoInversionDTO.CodigoMontoInversion = CodigoMontoInversion;
            montoInversionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = montoInversionBL.AgregarMontoInversion(montoInversionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMontoInversion(int MontoInversionId)
        {
            return Json(montoInversionBL.BuscarMontoInversionID(MontoInversionId));
        }

        public ActionResult ActualizarMontoInversion(int MontoInversionId, string DescMontoInversion, string CodigoMontoInversion)
        {
            MontoInversionDTO montoInversionDTO = new();
            montoInversionDTO.MontoInversionId = MontoInversionId;
            montoInversionDTO.DescMontoInversion = DescMontoInversion;
            montoInversionDTO.CodigoMontoInversion = CodigoMontoInversion;
            montoInversionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = montoInversionBL.ActualizarMontoInversion(montoInversionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMontoInversion(int MontoInversionId)
        {
            string mensaje = "";

            if (montoInversionBL.EliminarMontoInversion(MontoInversionId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
