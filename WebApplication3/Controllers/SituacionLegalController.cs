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
    public class SituacionLegalController : Controller
    {
        readonly SituacionLegal situacionLegalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Situacion Legal", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SituacionLegalDTO> listaSituacionLegals = situacionLegalBL.ObtenerSituacionLegals();
            return Json(new { data = listaSituacionLegals });
        }

        public ActionResult InsertarSituacionLegal(string DescSituacionLegal, string CodigoSituacionLegal)
        {
            SituacionLegalDTO situacionLegalDTO = new();
            situacionLegalDTO.DescSituacionLegal = DescSituacionLegal;
            situacionLegalDTO.CodigoSituacionLegal = CodigoSituacionLegal;
            situacionLegalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionLegalBL.AgregarSituacionLegal(situacionLegalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSituacionLegal(int SituacionLegalId)
        {
            return Json(situacionLegalBL.BuscarSituacionLegalID(SituacionLegalId));
        }

        public ActionResult ActualizarSituacionLegal(int SituacionLegalId, string DescSituacionLegal, string CodigoSituacionLegal)
        {
            SituacionLegalDTO situacionLegalDTO = new();
            situacionLegalDTO.SituacionLegalId = SituacionLegalId;
            situacionLegalDTO.DescSituacionLegal = DescSituacionLegal;
            situacionLegalDTO.CodigoSituacionLegal = CodigoSituacionLegal;
            situacionLegalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionLegalBL.ActualizarSituacionLegal(situacionLegalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSituacionLegal(int SituacionLegalId)
        {
            SituacionLegalDTO situacionLegalDTO = new();
            situacionLegalDTO.SituacionLegalId = SituacionLegalId;
            situacionLegalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (situacionLegalBL.EliminarSituacionLegal(situacionLegalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
