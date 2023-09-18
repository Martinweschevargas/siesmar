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
    public class MontoAdjudicadoController : Controller
    {
        readonly MontoAdjudicadoDAO montoAdjudicadoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Montos Adjudicados", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MontoAdjudicadoDTO> listaMontoAdjudicados = montoAdjudicadoBL.ObtenerMontoAdjudicados();
            return Json(new { data = listaMontoAdjudicados });
        }

        public ActionResult InsertarMontoAdjudicado(string DescMontoAdjudicado, string CodigoMontoAdjudicado)
        {
            MontoAdjudicadoDTO montoAdjudicadoDTO = new();
            montoAdjudicadoDTO.DescMontoAdjudicado = DescMontoAdjudicado;
            montoAdjudicadoDTO.CodigoMontoAdjudicado = CodigoMontoAdjudicado;
            montoAdjudicadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = montoAdjudicadoBL.AgregarMontoAdjudicado(montoAdjudicadoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMontoAdjudicado(int MontoAdjudicadoId)
        {
            return Json(montoAdjudicadoBL.BuscarMontoAdjudicadoID(MontoAdjudicadoId));
        }

        public ActionResult ActualizarMontoAdjudicado(int MontoAdjudicadoId, string DescMontoAdjudicado, string CodigoMontoAdjudicado)
        {
            MontoAdjudicadoDTO montoAdjudicadoDTO = new();
            montoAdjudicadoDTO.MontoAdjudicadoId = MontoAdjudicadoId;
            montoAdjudicadoDTO.DescMontoAdjudicado = DescMontoAdjudicado;
            montoAdjudicadoDTO.CodigoMontoAdjudicado = CodigoMontoAdjudicado;
            montoAdjudicadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = montoAdjudicadoBL.ActualizarMontoAdjudicado(montoAdjudicadoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMontoAdjudicado(int MontoAdjudicadoId)
        {
            string mensaje = "";

            if (montoAdjudicadoBL.EliminarMontoAdjudicado(MontoAdjudicadoId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
