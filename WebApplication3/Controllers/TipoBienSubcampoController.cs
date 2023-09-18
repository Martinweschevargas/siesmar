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
    public class TipoBienSubcampoController : Controller
    {
        readonly TipoBienSubcampoDAO tipoBienSubcampoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Bienes Subcampo", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoBienSubcampoDTO> listaTipoBienSubcampos = tipoBienSubcampoBL.ObtenerTipoBienSubcampos();
            return Json(new { data = listaTipoBienSubcampos });
        }

        public ActionResult InsertarTipoBienSubcampo(string DescTipoBienSubcampo, string CodigoTipoBienSubcampo)
        {
            TipoBienSubcampoDTO tipoBienSubcampoDTO = new();
            tipoBienSubcampoDTO.DescTipoBienSubcampo = DescTipoBienSubcampo;
            tipoBienSubcampoDTO.CodigoTipoBienSubcampo = CodigoTipoBienSubcampo;
            tipoBienSubcampoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoBienSubcampoBL.AgregarTipoBienSubcampo(tipoBienSubcampoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoBienSubcampo(int TipoBienSubcampoId)
        {
            return Json(tipoBienSubcampoBL.BuscarTipoBienSubcampoID(TipoBienSubcampoId));
        }

        public ActionResult ActualizarTipoBienSubcampo(int TipoBienSubcampoId, string DescTipoBienSubcampo, string CodigoTipoBienSubcampo)
        {
            TipoBienSubcampoDTO tipoBienSubcampoDTO = new();
            tipoBienSubcampoDTO.TipoBienSubcampoId = TipoBienSubcampoId;
            tipoBienSubcampoDTO.DescTipoBienSubcampo = DescTipoBienSubcampo;
            tipoBienSubcampoDTO.CodigoTipoBienSubcampo = CodigoTipoBienSubcampo;
            tipoBienSubcampoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoBienSubcampoBL.ActualizarTipoBienSubcampo(tipoBienSubcampoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoBienSubcampo(int TipoBienSubcampoId)
        {
            TipoBienSubcampoDTO tipoBienSubcampoDTO = new();
            tipoBienSubcampoDTO.TipoBienSubcampoId = TipoBienSubcampoId;
            tipoBienSubcampoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoBienSubcampoBL.EliminarTipoBienSubcampo(tipoBienSubcampoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
