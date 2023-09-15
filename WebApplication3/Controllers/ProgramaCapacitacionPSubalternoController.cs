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
    public class ProgramaCapacitacionPSubalternoController : Controller
    {
        readonly ProgramaCapacitacionPSubalternoDAO programaCapacitacionPSubalternoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Programas Capacitaciones PSubalternos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ProgramaCapacitacionPSubalternoDTO> listaProgramaCapacitacionPSubalternos = programaCapacitacionPSubalternoBL.ObtenerProgramaCapacitacionPSubalternos();
            return Json(new { data = listaProgramaCapacitacionPSubalternos });
        }

        public ActionResult InsertarProgramaCapacitacionPSubalterno(string DescProgramaCapacitacionPSubalterno, string CodigoProgramaCapacitacionPSubalterno)
        {
            ProgramaCapacitacionPSubalternoDTO programaCapacitacionPSubalternoDTO = new();
            programaCapacitacionPSubalternoDTO.DescProgramaCapacitacionPSubalterno = DescProgramaCapacitacionPSubalterno;
            programaCapacitacionPSubalternoDTO.CodigoProgramaCapacitacionPSubalterno = CodigoProgramaCapacitacionPSubalterno;
            programaCapacitacionPSubalternoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = programaCapacitacionPSubalternoBL.AgregarProgramaCapacitacionPSubalterno(programaCapacitacionPSubalternoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarProgramaCapacitacionPSubalterno(int ProgramaCapacitacionPSubalternoId)
        {
            return Json(programaCapacitacionPSubalternoBL.BuscarProgramaCapacitacionPSubalternoID(ProgramaCapacitacionPSubalternoId));
        }

        public ActionResult ActualizarProgramaCapacitacionPSubalterno(int ProgramaCapacitacionPSubalternoId, string DescProgramaCapacitacionPSubalterno, string CodigoProgramaCapacitacionPSubalterno)
        {
            ProgramaCapacitacionPSubalternoDTO programaCapacitacionPSubalternoDTO = new();
            programaCapacitacionPSubalternoDTO.ProgramaCapacitacionPSubalternoId = ProgramaCapacitacionPSubalternoId;
            programaCapacitacionPSubalternoDTO.DescProgramaCapacitacionPSubalterno = DescProgramaCapacitacionPSubalterno;
            programaCapacitacionPSubalternoDTO.CodigoProgramaCapacitacionPSubalterno = CodigoProgramaCapacitacionPSubalterno;
            programaCapacitacionPSubalternoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = programaCapacitacionPSubalternoBL.ActualizarProgramaCapacitacionPSubalterno(programaCapacitacionPSubalternoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarProgramaCapacitacionPSubalterno(int ProgramaCapacitacionPSubalternoId)
        {
            ProgramaCapacitacionPSubalternoDTO programaCapacitacionPSubalternoDTO = new();
            programaCapacitacionPSubalternoDTO.ProgramaCapacitacionPSubalternoId = ProgramaCapacitacionPSubalternoId;
            programaCapacitacionPSubalternoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (programaCapacitacionPSubalternoBL.EliminarProgramaCapacitacionPSubalterno(programaCapacitacionPSubalternoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
