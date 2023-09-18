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
    public class InfraccionDisciplinariaCivilController : Controller
    {
        readonly InfraccionDisciplinariaCivilDAO infraccionDisciplinariaCivilBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Infracción Disciplinaria Civil", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<InfraccionDisciplinariaCivilDTO> listaInfraccionDisciplinariaCivils = infraccionDisciplinariaCivilBL.ObtenerInfraccionDisciplinariaCivils();
            return Json(new { data = listaInfraccionDisciplinariaCivils });
        }
        public ActionResult InsertarInfraccionDisciplinariaCivil(string DescInfraccionDisciplinariaCivil, string CodigoInfraccionDisciplinariaCivil)
        {
            InfraccionDisciplinariaCivilDTO infraccionDisciplinariaCivilDTO = new();
            infraccionDisciplinariaCivilDTO.DescInfraccionDisciplinariaCivil = DescInfraccionDisciplinariaCivil;
            infraccionDisciplinariaCivilDTO.CodigoInfraccionDisciplinariaCivil = CodigoInfraccionDisciplinariaCivil;
            infraccionDisciplinariaCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = infraccionDisciplinariaCivilBL.AgregarInfraccionDisciplinariaCivil(infraccionDisciplinariaCivilDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarInfraccionDisciplinariaCivil(int InfraccionDisciplinariaCivilId)
        {
            return Json(infraccionDisciplinariaCivilBL.BuscarInfraccionDisciplinariaCivilID(InfraccionDisciplinariaCivilId));
        }

        public ActionResult ActualizarInfraccionDisciplinariaCivil(int InfraccionDisciplinariaCivilId, string DescInfraccionDisciplinariaCivil, string CodigoInfraccionDisciplinariaCivil)
        {
            InfraccionDisciplinariaCivilDTO infraccionDisciplinariaCivilDTO = new();
            infraccionDisciplinariaCivilDTO.InfraccionDisciplinariaCivilId = InfraccionDisciplinariaCivilId;
            infraccionDisciplinariaCivilDTO.DescInfraccionDisciplinariaCivil = DescInfraccionDisciplinariaCivil;
            infraccionDisciplinariaCivilDTO.CodigoInfraccionDisciplinariaCivil = CodigoInfraccionDisciplinariaCivil;
            infraccionDisciplinariaCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = infraccionDisciplinariaCivilBL.ActualizarInfraccionDisciplinariaCivil(infraccionDisciplinariaCivilDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarInfraccionDisciplinariaCivil(int InfraccionDisciplinariaCivilId)
        {
            InfraccionDisciplinariaCivilDTO infraccionDisciplinariaCivilDTO = new();
            infraccionDisciplinariaCivilDTO.InfraccionDisciplinariaCivilId = InfraccionDisciplinariaCivilId;
            infraccionDisciplinariaCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (infraccionDisciplinariaCivilBL.EliminarInfraccionDisciplinariaCivil(infraccionDisciplinariaCivilDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
