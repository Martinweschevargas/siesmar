using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class FormacionAcademicaController : Controller
    {
        readonly FormacionAcademicaDAO formacionAcademicaBL = new();
 
        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Formaciones Académicas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<FormacionAcademicaDTO> listaFormacionAcademicas = formacionAcademicaBL.ObtenerFormacionAcademicas();
            return Json(new { data = listaFormacionAcademicas });
        }

        public ActionResult InsertarFormacionAcademica(string DescFormacionAcademica, string CodigoFormacionAcademica)
        {
            FormacionAcademicaDTO formacionAcademicaDTO = new();
            formacionAcademicaDTO.DescFormacionAcademica = DescFormacionAcademica;
            formacionAcademicaDTO.CodigoFormacionAcademica = CodigoFormacionAcademica;
            formacionAcademicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = formacionAcademicaBL.AgregarFormacionAcademica(formacionAcademicaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarFormacionAcademica(int FormacionAcademicaId)
        {
            return Json(formacionAcademicaBL.BuscarFormacionAcademicaID(FormacionAcademicaId));
        }

        public ActionResult ActualizarFormacionAcademica(int FormacionAcademicaId, string DescFormacionAcademica, string CodigoFormacionAcademica)
        {
            FormacionAcademicaDTO formacionAcademicaDTO = new();
            formacionAcademicaDTO.FormacionAcademicaId = FormacionAcademicaId;
            formacionAcademicaDTO.DescFormacionAcademica = DescFormacionAcademica;
            formacionAcademicaDTO.CodigoFormacionAcademica = CodigoFormacionAcademica;
            formacionAcademicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = formacionAcademicaBL.ActualizarFormacionAcademica(formacionAcademicaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarFormacionAcademica(int FormacionAcademicaId)
        {
            FormacionAcademicaDTO formacionAcademicaDTO = new();
            formacionAcademicaDTO.FormacionAcademicaId = FormacionAcademicaId;
            formacionAcademicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (formacionAcademicaBL.EliminarFormacionAcademica(formacionAcademicaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
