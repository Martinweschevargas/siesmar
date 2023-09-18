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
    public class SancionDisciplinariaNavalController : Controller
    {
        readonly SancionDisciplinariaNavalDAO sancionDisciplinariaNavalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "SancionDisciplinariaNaval", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SancionDisciplinariaNavalDTO> listaSancionDisciplinariaNavals = sancionDisciplinariaNavalBL.ObtenerSancionDisciplinariaNavals();
            return Json(new { data = listaSancionDisciplinariaNavals });
        }

        public ActionResult InsertarSancionDisciplinariaNaval(string DescSancionDisciplinariaNaval, string CodigoSancionDisciplinariaNaval)
        {
            SancionDisciplinariaNavalDTO sancionDisciplinariaNavalDTO = new();
            sancionDisciplinariaNavalDTO.DescSancionDisciplinariaNaval = DescSancionDisciplinariaNaval;
            sancionDisciplinariaNavalDTO.CodigoSancionDisciplinariaNaval = CodigoSancionDisciplinariaNaval;
            sancionDisciplinariaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = sancionDisciplinariaNavalBL.AgregarSancionDisciplinariaNaval(sancionDisciplinariaNavalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSancionDisciplinariaNaval(int SancionDisciplinariaNavalId)
        {
            return Json(sancionDisciplinariaNavalBL.BuscarSancionDisciplinariaNavalID(SancionDisciplinariaNavalId));
        }

        public ActionResult ActualizarSancionDisciplinariaNaval(int SancionDisciplinariaNavalId, string DescSancionDisciplinariaNaval, string CodigoSancionDisciplinariaNaval)
        {
            SancionDisciplinariaNavalDTO sancionDisciplinariaNavalDTO = new();
            sancionDisciplinariaNavalDTO.SancionDisciplinariaNavalId = SancionDisciplinariaNavalId;
            sancionDisciplinariaNavalDTO.DescSancionDisciplinariaNaval = DescSancionDisciplinariaNaval;
            sancionDisciplinariaNavalDTO.CodigoSancionDisciplinariaNaval = CodigoSancionDisciplinariaNaval;
            sancionDisciplinariaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = sancionDisciplinariaNavalBL.ActualizarSancionDisciplinariaNaval(sancionDisciplinariaNavalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSancionDisciplinariaNaval(int SancionDisciplinariaNavalId)
        {
            SancionDisciplinariaNavalDTO sancionDisciplinariaNavalDTO = new();
            sancionDisciplinariaNavalDTO.SancionDisciplinariaNavalId = SancionDisciplinariaNavalId;
            sancionDisciplinariaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (sancionDisciplinariaNavalBL.EliminarSancionDisciplinariaNaval(sancionDisciplinariaNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
