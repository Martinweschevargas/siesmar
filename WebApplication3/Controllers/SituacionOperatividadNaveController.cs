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
    public class SituacionOperatividadNaveController : Controller
    {
        readonly SituacionOperatividadNave situacionOperatividadNaveBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Situacion Operatividad Nave", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SituacionOperatividadNaveDTO> listaSituacionOperatividadNaves = situacionOperatividadNaveBL.ObtenerSituacionOperatividadNaves();
            return Json(new { data = listaSituacionOperatividadNaves });
        }

        public ActionResult InsertarSituacionOperatividadNave(string Nave, string NumeroCasco, string TipoPlataforma, string CodigoDependencia)
        {
            SituacionOperatividadNaveDTO situacionOperatividadNaveDTO = new();
            situacionOperatividadNaveDTO.Nave = Nave;
            situacionOperatividadNaveDTO.NumeroCasco = NumeroCasco;
            situacionOperatividadNaveDTO.TipoPlataforma = TipoPlataforma;
            situacionOperatividadNaveDTO.CodigoDependencia = CodigoDependencia;
            situacionOperatividadNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperatividadNaveBL.AgregarSituacionOperatividadNave(situacionOperatividadNaveDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSituacionOperatividadNave(int SituacionOperatividadNaveId)
        {
            return Json(situacionOperatividadNaveBL.BuscarSituacionOperatividadNaveID(SituacionOperatividadNaveId));
        }

        public ActionResult ActualizarSituacionOperatividadNave(int SituacionOperatividadNaveId, string Nave, string NumeroCasco, string TipoPlataforma, string CodigoDependencia)
        {
            SituacionOperatividadNaveDTO situacionOperatividadNaveDTO = new();
            situacionOperatividadNaveDTO.SituacionOperatividadNaveId = SituacionOperatividadNaveId;
            situacionOperatividadNaveDTO.Nave = Nave;
            situacionOperatividadNaveDTO.NumeroCasco = NumeroCasco;
            situacionOperatividadNaveDTO.TipoPlataforma = TipoPlataforma;
            situacionOperatividadNaveDTO.CodigoDependencia = CodigoDependencia;
            situacionOperatividadNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperatividadNaveBL.ActualizarSituacionOperatividadNave(situacionOperatividadNaveDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSituacionOperatividadNave(int SituacionOperatividadNaveId)
        {
            SituacionOperatividadNaveDTO situacionOperatividadNaveDTO = new();
            situacionOperatividadNaveDTO.SituacionOperatividadNaveId = SituacionOperatividadNaveId;
            situacionOperatividadNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperatividadNaveBL.EliminarSituacionOperatividadNave(situacionOperatividadNaveDTO);

            return Content(IND_OPERACION);
        }
    }
}
