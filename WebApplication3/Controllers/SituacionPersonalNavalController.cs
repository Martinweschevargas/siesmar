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
    public class SituacionPersonalNavalController : Controller
    {
        readonly SituacionPersonalNaval situacionPersonalNavalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Situacion Personal Naval", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SituacionPersonalNavalDTO> listaSituacionPersonalNavals = situacionPersonalNavalBL.ObtenerSituacionPersonalNavals();
            return Json(new { data = listaSituacionPersonalNavals });
        }

        public ActionResult InsertarSituacionPersonalNaval( string CodigoSituacionPersonalNaval,string DescSituacionPersonalNaval)
        {
            SituacionPersonalNavalDTO situacionPersonalNavalDTO = new();

            situacionPersonalNavalDTO.CodigoSituacionPersonalNaval = CodigoSituacionPersonalNaval;
            situacionPersonalNavalDTO.DescSituacionPersonalNaval = DescSituacionPersonalNaval;

            situacionPersonalNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionPersonalNavalBL.AgregarSituacionPersonalNaval(situacionPersonalNavalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSituacionPersonalNaval(int SituacionPersonalNavalId)
        {
            return Json(situacionPersonalNavalBL.BuscarSituacionPersonalNavalID(SituacionPersonalNavalId));
        }

        public ActionResult ActualizarSituacionPersonalNaval(int SituacionPersonalNavalId, string DescSituacionPersonalNaval, string CodigoSituacionPersonalNaval)
        {
            SituacionPersonalNavalDTO situacionPersonalNavalDTO = new();
            situacionPersonalNavalDTO.SituacionPersonalNavalId = SituacionPersonalNavalId;
            situacionPersonalNavalDTO.DescSituacionPersonalNaval = DescSituacionPersonalNaval;
            situacionPersonalNavalDTO.CodigoSituacionPersonalNaval = CodigoSituacionPersonalNaval;
            situacionPersonalNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionPersonalNavalBL.ActualizarSituacionPersonalNaval(situacionPersonalNavalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSituacionPersonalNaval(int SituacionPersonalNavalId)
        {
            SituacionPersonalNavalDTO situacionPersonalNavalDTO = new();
            situacionPersonalNavalDTO.SituacionPersonalNavalId = SituacionPersonalNavalId;
            situacionPersonalNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (situacionPersonalNavalBL.EliminarSituacionPersonalNaval(situacionPersonalNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
