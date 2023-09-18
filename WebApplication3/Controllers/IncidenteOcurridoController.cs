using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class IncidenteOcurridoController : Controller
    {
        readonly IncidenteOcurridoDAO incidenteOcurridoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<IncidenteOcurridoDTO> listaIncidenteOcurridos = incidenteOcurridoBL.ObtenerIncidenteOcurridos();
            return Json(new { data = listaIncidenteOcurridos });
        }

        public ActionResult InsertarIncidenteOcurrido(string DescIncidenteOcurrido, string AspectoEvaluarIncidenteOcurrido)
        {
            IncidenteOcurridoDTO incidenteOcurridoDTO = new();
            incidenteOcurridoDTO.DescIncidenteOcurrido = DescIncidenteOcurrido;
            incidenteOcurridoDTO.AspectoEvaluarIncidenteOcurrido = AspectoEvaluarIncidenteOcurrido;
            incidenteOcurridoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = incidenteOcurridoBL.AgregarIncidenteOcurrido(incidenteOcurridoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarIncidenteOcurrido(int IncidenteOcurridoId)
        {
            return Json(incidenteOcurridoBL.BuscarIncidenteOcurridoID(IncidenteOcurridoId));
        }

        public ActionResult ActualizarIncidenteOcurrido(int IncidenteOcurridoId, string DescIncidenteOcurrido, string AspectoEvaluarIncidenteOcurrido)
        {
            IncidenteOcurridoDTO incidenteOcurridoDTO = new();
            incidenteOcurridoDTO.IncidenteOcurridoId = IncidenteOcurridoId;
            incidenteOcurridoDTO.DescIncidenteOcurrido = DescIncidenteOcurrido;
            incidenteOcurridoDTO.AspectoEvaluarIncidenteOcurrido = AspectoEvaluarIncidenteOcurrido;
            incidenteOcurridoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = incidenteOcurridoBL.ActualizarIncidenteOcurrido(incidenteOcurridoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarIncidenteOcurrido(int IncidenteOcurridoId)
        {
            IncidenteOcurridoDTO IncidenteOcurridoDTO = new();
            IncidenteOcurridoDTO.IncidenteOcurridoId = IncidenteOcurridoId;
            IncidenteOcurridoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = incidenteOcurridoBL.EliminarIncidenteOcurrido(IncidenteOcurridoDTO);

            return Content(IND_OPERACION);
        }
    }
}
