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
    public class TipoApoyoSocialController : Controller
    {
        readonly TipoApoyoSocialDAO tipoApoyoSocialBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Apoyos Sociales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoApoyoSocialDTO> listaTipoApoyoSocials = tipoApoyoSocialBL.ObtenerTipoApoyoSocials();
            return Json(new { data = listaTipoApoyoSocials });
        }

        public ActionResult InsertarTipoApoyoSocial(string DescTipoApoyoSocial, string CodigoTipoApoyoSocial)
        {
            TipoApoyoSocialDTO tipoApoyoSocialDTO = new();
            tipoApoyoSocialDTO.DescTipoApoyoSocial = DescTipoApoyoSocial;
            tipoApoyoSocialDTO.CodigoTipoApoyoSocial = CodigoTipoApoyoSocial;
            tipoApoyoSocialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoApoyoSocialBL.AgregarTipoApoyoSocial(tipoApoyoSocialDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoApoyoSocial(int TipoApoyoSocialId)
        {
            return Json(tipoApoyoSocialBL.BuscarTipoApoyoSocialID(TipoApoyoSocialId));
        }

        public ActionResult ActualizarTipoApoyoSocial(int TipoApoyoSocialId, string DescTipoApoyoSocial, string CodigoTipoApoyoSocial)
        {
            TipoApoyoSocialDTO tipoApoyoSocialDTO = new();
            tipoApoyoSocialDTO.TipoApoyoSocialId = TipoApoyoSocialId;
            tipoApoyoSocialDTO.DescTipoApoyoSocial = DescTipoApoyoSocial;
            tipoApoyoSocialDTO.CodigoTipoApoyoSocial = CodigoTipoApoyoSocial;
            tipoApoyoSocialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoApoyoSocialBL.ActualizarTipoApoyoSocial(tipoApoyoSocialDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoApoyoSocial(int TipoApoyoSocialId)
        {
            TipoApoyoSocialDTO tipoApoyoSocialDTO = new();
            tipoApoyoSocialDTO.TipoApoyoSocialId = TipoApoyoSocialId;
            tipoApoyoSocialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoApoyoSocialBL.EliminarTipoApoyoSocial(tipoApoyoSocialDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
