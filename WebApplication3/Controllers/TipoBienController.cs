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
    public class TipoBienController : Controller
    {
        readonly TipoBienDAO tipoBienBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Bienes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoBienDTO> listaTipoBiens = tipoBienBL.ObtenerTipoBiens();
            return Json(new { data = listaTipoBiens });
        }

        public ActionResult InsertarTipoBien(string DescTipoBien, string CodigoTipoBien)
        {
            TipoBienDTO tipoBienDTO = new();
            tipoBienDTO.DescTipoBien = DescTipoBien;
            tipoBienDTO.CodigoTipoBien = CodigoTipoBien;
            tipoBienDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoBienBL.AgregarTipoBien(tipoBienDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoBien(int TipoBienId)
        {
            return Json(tipoBienBL.BuscarTipoBienID(TipoBienId));
        }

        public ActionResult ActualizarTipoBien(int TipoBienId, string DescTipoBien, string CodigoTipoBien)
        {
            TipoBienDTO tipoBienDTO = new();
            tipoBienDTO.TipoBienId = TipoBienId;
            tipoBienDTO.DescTipoBien = DescTipoBien;
            tipoBienDTO.CodigoTipoBien = CodigoTipoBien;
            tipoBienDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoBienBL.ActualizarTipoBien(tipoBienDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoBien(int TipoBienId)
        {
            TipoBienDTO tipoBienDTO = new();
            tipoBienDTO.TipoBienId = TipoBienId;
            tipoBienDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoBienBL.EliminarTipoBien(tipoBienDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
