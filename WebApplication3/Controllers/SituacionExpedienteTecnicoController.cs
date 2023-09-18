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
    public class SituacionExpedienteTecnicoController : Controller
    {
        readonly SituacionExpedienteTecnicoDAO situacionExpedienteTecnicoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Situacion Expediente Tecnico", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SituacionExpedienteTecnicoDTO> listaSituacionExpedienteTecnicos = situacionExpedienteTecnicoBL.ObtenerSituacionExpedienteTecnicos();
            return Json(new { data = listaSituacionExpedienteTecnicos });
        }

        public ActionResult InsertarSituacionExpedienteTecnico(string DescSituacionExpedienteTecnico, string CodigoSituacionExpedienteTecnico)
        {
            SituacionExpedienteTecnicoDTO situacionExpedienteTecnicoDTO = new();
            situacionExpedienteTecnicoDTO.DescSituacionExpedienteTecnico = DescSituacionExpedienteTecnico;
            situacionExpedienteTecnicoDTO.CodigoSituacionExpedienteTecnico = CodigoSituacionExpedienteTecnico;
            situacionExpedienteTecnicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionExpedienteTecnicoBL.AgregarSituacionExpedienteTecnico(situacionExpedienteTecnicoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSituacionExpedienteTecnico(int SituacionExpedienteTecnicoId)
        {
            return Json(situacionExpedienteTecnicoBL.BuscarSituacionExpedienteTecnicoID(SituacionExpedienteTecnicoId));
        }

        public ActionResult ActualizarSituacionExpedienteTecnico(int SituacionExpedienteTecnicoId, string DescSituacionExpedienteTecnico, string CodigoSituacionExpedienteTecnico)
        {
            SituacionExpedienteTecnicoDTO situacionExpedienteTecnicoDTO = new();
            situacionExpedienteTecnicoDTO.SituacionExpedienteTecnicoId = SituacionExpedienteTecnicoId;
            situacionExpedienteTecnicoDTO.DescSituacionExpedienteTecnico = DescSituacionExpedienteTecnico;
            situacionExpedienteTecnicoDTO.CodigoSituacionExpedienteTecnico = CodigoSituacionExpedienteTecnico;
            situacionExpedienteTecnicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionExpedienteTecnicoBL.ActualizarSituacionExpedienteTecnico(situacionExpedienteTecnicoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSituacionExpedienteTecnico(int SituacionExpedienteTecnicoId)
        {
            SituacionExpedienteTecnicoDTO situacionExpedienteTecnicoDTO = new();
            situacionExpedienteTecnicoDTO.SituacionExpedienteTecnicoId = SituacionExpedienteTecnicoId;
            situacionExpedienteTecnicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (situacionExpedienteTecnicoBL.EliminarSituacionExpedienteTecnico(situacionExpedienteTecnicoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
