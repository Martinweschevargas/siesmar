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
    public class TipoEvaluacionSocialController : Controller
    {
        readonly TipoEvaluacionSocialDAO tipoEvaluacionSocialBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Evaluaciones Sociales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoEvaluacionSocialDTO> listaTipoEvaluacionSocials = tipoEvaluacionSocialBL.ObtenerTipoEvaluacionSocials();
            return Json(new { data = listaTipoEvaluacionSocials });
        }

        public ActionResult InsertarTipoEvaluacionSocial(string DescTipoEvaluacionSocial, string CodigoTipoEvaluacionSocial)
        {
            TipoEvaluacionSocialDTO tipoEvaluacionSocialDTO = new();
            tipoEvaluacionSocialDTO.DescTipoEvaluacionSocial = DescTipoEvaluacionSocial;
            tipoEvaluacionSocialDTO.CodigoTipoEvaluacionSocial = CodigoTipoEvaluacionSocial;
            tipoEvaluacionSocialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoEvaluacionSocialBL.AgregarTipoEvaluacionSocial(tipoEvaluacionSocialDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoEvaluacionSocial(int TipoEvaluacionSocialId)
        {
            return Json(tipoEvaluacionSocialBL.BuscarTipoEvaluacionSocialID(TipoEvaluacionSocialId));
        }

        public ActionResult ActualizarTipoEvaluacionSocial(int TipoEvaluacionSocialId, string DescTipoEvaluacionSocial, string CodigoTipoEvaluacionSocial)
        {
            TipoEvaluacionSocialDTO tipoEvaluacionSocialDTO = new();
            tipoEvaluacionSocialDTO.TipoEvaluacionSocialId = TipoEvaluacionSocialId;
            tipoEvaluacionSocialDTO.DescTipoEvaluacionSocial = DescTipoEvaluacionSocial;
            tipoEvaluacionSocialDTO.CodigoTipoEvaluacionSocial = CodigoTipoEvaluacionSocial;
            tipoEvaluacionSocialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoEvaluacionSocialBL.ActualizarTipoEvaluacionSocial(tipoEvaluacionSocialDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoEvaluacionSocial(int TipoEvaluacionSocialId)
        {
            TipoEvaluacionSocialDTO tipoEvaluacionSocialDTO = new();
            tipoEvaluacionSocialDTO.TipoEvaluacionSocialId = TipoEvaluacionSocialId;
            tipoEvaluacionSocialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoEvaluacionSocialBL.EliminarTipoEvaluacionSocial(tipoEvaluacionSocialDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
