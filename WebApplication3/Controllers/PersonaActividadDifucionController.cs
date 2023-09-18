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
    public class PersonaActividadDifucionController : Controller
    {
        readonly PersonaActividadDifucionDAO personaActividadDifucionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Personas Actividades Difucion", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<PersonaActividadDifucionDTO> listaPersonaActividadDifucions = personaActividadDifucionBL.ObtenerPersonaActividadDifucions();
            return Json(new { data = listaPersonaActividadDifucions });
        }

        public ActionResult InsertarPersonaActividadDifucion(string DescPersonaActividadDifucion, string CodigoPersonaActividadDifucion)
        {
            PersonaActividadDifucionDTO personaActividadDifucionDTO = new();
            personaActividadDifucionDTO.DescPersonaActividadDifucion = DescPersonaActividadDifucion;
            personaActividadDifucionDTO.CodigoPersonaActividadDifucion = CodigoPersonaActividadDifucion;
            personaActividadDifucionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = personaActividadDifucionBL.AgregarPersonaActividadDifucion(personaActividadDifucionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarPersonaActividadDifucion(int PersonaActividadDifucionId)
        {
            return Json(personaActividadDifucionBL.BuscarPersonaActividadDifucionID(PersonaActividadDifucionId));
        }

        public ActionResult ActualizarPersonaActividadDifucion(int PersonaActividadDifucionId, string DescPersonaActividadDifucion, string CodigoPersonaActividadDifucion)
        {
            PersonaActividadDifucionDTO personaActividadDifucionDTO = new();
            personaActividadDifucionDTO.PersonaActividadDifucionId = PersonaActividadDifucionId;
            personaActividadDifucionDTO.DescPersonaActividadDifucion = DescPersonaActividadDifucion;
            personaActividadDifucionDTO.CodigoPersonaActividadDifucion = CodigoPersonaActividadDifucion;
            personaActividadDifucionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = personaActividadDifucionBL.ActualizarPersonaActividadDifucion(personaActividadDifucionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPersonaActividadDifucion(int PersonaActividadDifucionId)
        {
            string mensaje = "";

            if (personaActividadDifucionBL.EliminarPersonaActividadDifucion(PersonaActividadDifucionId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
