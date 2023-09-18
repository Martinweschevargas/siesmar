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
    public class SituacionPersonalSolicitanteController : Controller
    {
        readonly ILogger<SituacionPersonalSolicitanteController> _logger;

        public SituacionPersonalSolicitanteController(ILogger<SituacionPersonalSolicitanteController> logger)
        {
            _logger = logger;
        }

        readonly SituacionPersonalSolicitanteDAO situacionPersonalSolicitanteBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Situaciones Personales Solicitantes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SituacionPersonalSolicitanteDTO> listaSituacionPersonalSolicitantes = situacionPersonalSolicitanteBL.ObtenerSituacionPersonalSolicitantes();
            return Json(new { data = listaSituacionPersonalSolicitantes });
        }

        public ActionResult InsertarSituacionPersonalSolicitante(string DescSituacionPersonalSol, string CodigoSituacionPersonalSol)
        {
            var IND_OPERACION = "";
            try
            {
                SituacionPersonalSolicitanteDTO situacionPersonalSolicitanteDTO = new();
                situacionPersonalSolicitanteDTO.DescSituacionPersonalSol = DescSituacionPersonalSol;
                situacionPersonalSolicitanteDTO.CodigoSituacionPersonalSol = CodigoSituacionPersonalSol;
                situacionPersonalSolicitanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = situacionPersonalSolicitanteBL.AgregarSituacionPersonalSolicitante(situacionPersonalSolicitanteDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSituacionPersonalSolicitante(int SituacionPersonalSolId)
        {
            return Json(situacionPersonalSolicitanteBL.BuscarSituacionPersonalSolicitanteID(SituacionPersonalSolId));
        }

        public ActionResult ActualizarSituacionPersonalSolicitante(int SituacionPersonalSolId, string DescSituacionPersonalSol, string CodigoSituacionPersonalSol)
        {
            SituacionPersonalSolicitanteDTO situacionPersonalSolicitanteDTO = new();
            situacionPersonalSolicitanteDTO.SituacionPersonalSolId = SituacionPersonalSolId;
            situacionPersonalSolicitanteDTO.DescSituacionPersonalSol = DescSituacionPersonalSol;
            situacionPersonalSolicitanteDTO.CodigoSituacionPersonalSol = CodigoSituacionPersonalSol;
            situacionPersonalSolicitanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionPersonalSolicitanteBL.ActualizarSituacionPersonalSolicitante(situacionPersonalSolicitanteDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSituacionPersonalSolicitante(int SituacionPersonalSolId)
        {
            SituacionPersonalSolicitanteDTO situacionPersonalSolicitanteDTO = new();
            situacionPersonalSolicitanteDTO.SituacionPersonalSolId = SituacionPersonalSolId;
            situacionPersonalSolicitanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (situacionPersonalSolicitanteBL.EliminarSituacionPersonalSolicitante(situacionPersonalSolicitanteDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}

