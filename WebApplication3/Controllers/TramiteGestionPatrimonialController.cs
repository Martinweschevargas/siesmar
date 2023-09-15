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
    public class TramiteGestionPatrimonialController : Controller
    {
        readonly TramiteGestionPatrimonialDAO tramiteGestionPatrimonialBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tramites Gestiones Patrimoniales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TramiteGestionPatrimonialDTO> listaTramiteGestionPatrimonials = tramiteGestionPatrimonialBL.ObtenerTramiteGestionPatrimonials();
            return Json(new { data = listaTramiteGestionPatrimonials });
        }

        public ActionResult InsertarTramiteGestionPatrimonial(string DescTramiteGestionPatrimonial, string CodigoTramiteGestionPatrimonial)
        {
            TramiteGestionPatrimonialDTO tramiteGestionPatrimonialDTO = new();
            tramiteGestionPatrimonialDTO.DescTramiteGestionPatrimonial = DescTramiteGestionPatrimonial;
            tramiteGestionPatrimonialDTO.CodigoTramiteGestionPatrimonial = CodigoTramiteGestionPatrimonial;
            tramiteGestionPatrimonialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tramiteGestionPatrimonialBL.AgregarTramiteGestionPatrimonial(tramiteGestionPatrimonialDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTramiteGestionPatrimonial(int TramiteGestionPatrimonialId)
        {
            return Json(tramiteGestionPatrimonialBL.BuscarTramiteGestionPatrimonialID(TramiteGestionPatrimonialId));
        }

        public ActionResult ActualizarTramiteGestionPatrimonial(int TramiteGestionPatrimonialId, string DescTramiteGestionPatrimonial, string CodigoTramiteGestionPatrimonial)
        {
            TramiteGestionPatrimonialDTO tramiteGestionPatrimonialDTO = new();
            tramiteGestionPatrimonialDTO.TramiteGestionPatrimonialId = TramiteGestionPatrimonialId;
            tramiteGestionPatrimonialDTO.DescTramiteGestionPatrimonial = DescTramiteGestionPatrimonial;
            tramiteGestionPatrimonialDTO.CodigoTramiteGestionPatrimonial = CodigoTramiteGestionPatrimonial;
            tramiteGestionPatrimonialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tramiteGestionPatrimonialBL.ActualizarTramiteGestionPatrimonial(tramiteGestionPatrimonialDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTramiteGestionPatrimonial(int TramiteGestionPatrimonialId)
        {
            TramiteGestionPatrimonialDTO tramiteGestionPatrimonialDTO = new();
            tramiteGestionPatrimonialDTO.TramiteGestionPatrimonialId = TramiteGestionPatrimonialId;
            tramiteGestionPatrimonialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tramiteGestionPatrimonialBL.EliminarTramiteGestionPatrimonial(tramiteGestionPatrimonialDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
