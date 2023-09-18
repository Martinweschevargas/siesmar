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
    public class PersonalCivilLaboralController : Controller
    {
        readonly PersonalCivilLaboralDAO personalCivilLaboralBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Personal Civil Laboral", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<PersonalCivilLaboralDTO> listaPersonalCivilLaborals = personalCivilLaboralBL.ObtenerPersonalCivilLaborals();
            return Json(new { data = listaPersonalCivilLaborals });
        }

        public ActionResult InsertarPersonalCivilLaboral(string DescPersonalCivilLaboral, string CodigoPersonalCivilLaboral)
        {
            PersonalCivilLaboralDTO personalCivilLaboralDTO = new();
            personalCivilLaboralDTO.DescPersonalCivilLaboral = DescPersonalCivilLaboral;
            personalCivilLaboralDTO.CodigoPersonalCivilLaboral = CodigoPersonalCivilLaboral;
            personalCivilLaboralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = personalCivilLaboralBL.AgregarPersonalCivilLaboral(personalCivilLaboralDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarPersonalCivilLaboral(int PersonalCivilLaboralId)
        {
            return Json(personalCivilLaboralBL.BuscarPersonalCivilLaboralID(PersonalCivilLaboralId));
        }

        public ActionResult ActualizarPersonalCivilLaboral(int PersonalCivilLaboralId, string DescPersonalCivilLaboral, string CodigoPersonalCivilLaboral)
        {
            PersonalCivilLaboralDTO personalCivilLaboralDTO = new();
            personalCivilLaboralDTO.PersonalCivilLaboralId = PersonalCivilLaboralId;
            personalCivilLaboralDTO.DescPersonalCivilLaboral = DescPersonalCivilLaboral;
            personalCivilLaboralDTO.CodigoPersonalCivilLaboral = CodigoPersonalCivilLaboral;
            personalCivilLaboralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = personalCivilLaboralBL.ActualizarPersonalCivilLaboral(personalCivilLaboralDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPersonalCivilLaboral(int PersonalCivilLaboralId)
        {
            string mensaje = "";

            if (personalCivilLaboralBL.EliminarPersonalCivilLaboral(PersonalCivilLaboralId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
