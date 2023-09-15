using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class SancionDisciplinariaCivilController : Controller
    {
        readonly SancionDisciplinariaCivilDAO sancionDisciplinariaCivilBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "SancionDisciplinariaCivil", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
           return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SancionDisciplinariaCivilDTO> listaSancionDisciplinariaCivils = sancionDisciplinariaCivilBL.ObtenerSancionDisciplinariaCivils();
            return Json(new { data = listaSancionDisciplinariaCivils });
        }

        public ActionResult InsertarSancionDisciplinariaCivil(string DescSancionDisciplinariaCivil, string CodigoSancionDisciplinariaCivil)
        {
            SancionDisciplinariaCivilDTO sancionDisciplinariaCivilDTO = new();
            sancionDisciplinariaCivilDTO.DescSancionDisciplinariaCivil = DescSancionDisciplinariaCivil;
            sancionDisciplinariaCivilDTO.CodigoSancionDisciplinariaCivil = CodigoSancionDisciplinariaCivil;
            sancionDisciplinariaCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = sancionDisciplinariaCivilBL.AgregarSancionDisciplinariaCivil(sancionDisciplinariaCivilDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSancionDisciplinariaCivil(int SancionDisciplinariaCivilId)
        {
            return Json(sancionDisciplinariaCivilBL.BuscarSancionDisciplinariaCivilID(SancionDisciplinariaCivilId));
        }

        public ActionResult ActualizarSancionDisciplinariaCivil(int SancionDisciplinariaCivilId, string DescSancionDisciplinariaCivil, string CodigoSancionDisciplinariaCivil)
        {
            SancionDisciplinariaCivilDTO sancionDisciplinariaCivilDTO = new();
            sancionDisciplinariaCivilDTO.SancionDisciplinariaCivilId = SancionDisciplinariaCivilId;
            sancionDisciplinariaCivilDTO.DescSancionDisciplinariaCivil = DescSancionDisciplinariaCivil;
            sancionDisciplinariaCivilDTO.CodigoSancionDisciplinariaCivil = CodigoSancionDisciplinariaCivil;
            sancionDisciplinariaCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = sancionDisciplinariaCivilBL.ActualizarSancionDisciplinariaCivil(sancionDisciplinariaCivilDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSancionDisciplinariaCivil(int SancionDisciplinariaCivilId)
        {
            SancionDisciplinariaCivilDTO sancionDisciplinariaCivilDTO = new();
            sancionDisciplinariaCivilDTO.SancionDisciplinariaCivilId = SancionDisciplinariaCivilId;
            sancionDisciplinariaCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (sancionDisciplinariaCivilBL.EliminarSancionDisciplinariaCivil(sancionDisciplinariaCivilDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
