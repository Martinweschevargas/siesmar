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
    public class OcupacionPersonalCivilController : Controller
    {
        readonly OcupacionPersonalCivilDAO ocupacionPersonalCivilBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Ocupaciones Personales Civiles", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<OcupacionPersonalCivilDTO> listaOcupacionPersonalCivils = ocupacionPersonalCivilBL.ObtenerOcupacionPersonalCivils();
            return Json(new { data = listaOcupacionPersonalCivils });
        }

        public ActionResult InsertarOcupacionPersonalCivil(string DescOcupacionPersonalCivil, string CodigoOcupacionPersonalCivil)
        {
            OcupacionPersonalCivilDTO ocupacionPersonalCivilDTO = new();
            ocupacionPersonalCivilDTO.DescOcupacionPersonalCivil = DescOcupacionPersonalCivil;
            ocupacionPersonalCivilDTO.CodigoOcupacionPersonalCivil = CodigoOcupacionPersonalCivil;
            ocupacionPersonalCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ocupacionPersonalCivilBL.AgregarOcupacionPersonalCivil(ocupacionPersonalCivilDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarOcupacionPersonalCivil(int OcupacionPersonalCivilId)
        {
            return Json(ocupacionPersonalCivilBL.BuscarOcupacionPersonalCivilID(OcupacionPersonalCivilId));
        }

        public ActionResult ActualizarOcupacionPersonalCivil(int OcupacionPersonalCivilId, string DescOcupacionPersonalCivil, string CodigoOcupacionPersonalCivil)
        {
            OcupacionPersonalCivilDTO ocupacionPersonalCivilDTO = new();
            ocupacionPersonalCivilDTO.OcupacionPersonalCivilId = OcupacionPersonalCivilId;
            ocupacionPersonalCivilDTO.DescOcupacionPersonalCivil = DescOcupacionPersonalCivil;
            ocupacionPersonalCivilDTO.CodigoOcupacionPersonalCivil = CodigoOcupacionPersonalCivil;
            ocupacionPersonalCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ocupacionPersonalCivilBL.ActualizarOcupacionPersonalCivil(ocupacionPersonalCivilDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarOcupacionPersonalCivil(int OcupacionPersonalCivilId)
        {
            string mensaje = "";

            if (ocupacionPersonalCivilBL.EliminarOcupacionPersonalCivil(OcupacionPersonalCivilId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
