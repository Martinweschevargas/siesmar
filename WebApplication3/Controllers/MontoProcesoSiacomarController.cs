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
    public class MontoProcesoSiacomarController : Controller
    {
        readonly MontoProcesoSiacomarDAO montoProcesoSiacomarBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Montos Procesos Siacomar", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MontoProcesoSiacomarDTO> listaMontoProcesoSiacomars = montoProcesoSiacomarBL.ObtenerMontoProcesoSiacomars();
            return Json(new { data = listaMontoProcesoSiacomars });
        }

        public ActionResult InsertarMontoProcesoSiacomar(string DescMontoProcesoSiacomar, string CodigoMontoProcesoSiacomar)
        {
            MontoProcesoSiacomarDTO montoProcesoSiacomarDTO = new();
            montoProcesoSiacomarDTO.DescMontoProcesoSiacomar = DescMontoProcesoSiacomar;
            montoProcesoSiacomarDTO.CodigoMontoProcesoSiacomar = CodigoMontoProcesoSiacomar;
            montoProcesoSiacomarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = montoProcesoSiacomarBL.AgregarMontoProcesoSiacomar(montoProcesoSiacomarDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMontoProcesoSiacomar(int MontoProcesoSiacomarId)
        {
            return Json(montoProcesoSiacomarBL.BuscarMontoProcesoSiacomarID(MontoProcesoSiacomarId));
        }

        public ActionResult ActualizarMontoProcesoSiacomar(int MontoProcesoSiacomarId, string DescMontoProcesoSiacomar, string CodigoMontoProcesoSiacomar)
        {
            MontoProcesoSiacomarDTO montoProcesoSiacomarDTO = new();
            montoProcesoSiacomarDTO.MontoProcesoSiacomarId = MontoProcesoSiacomarId;
            montoProcesoSiacomarDTO.DescMontoProcesoSiacomar = DescMontoProcesoSiacomar;
            montoProcesoSiacomarDTO.CodigoMontoProcesoSiacomar = CodigoMontoProcesoSiacomar;
            montoProcesoSiacomarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = montoProcesoSiacomarBL.ActualizarMontoProcesoSiacomar(montoProcesoSiacomarDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMontoProcesoSiacomar(int MontoProcesoSiacomarId)
        {
            string mensaje = "";

            if (montoProcesoSiacomarBL.EliminarMontoProcesoSiacomar(MontoProcesoSiacomarId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
