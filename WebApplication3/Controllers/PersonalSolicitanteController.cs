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
    public class PersonalSolicitanteController : Controller
    {
        readonly ILogger<PersonalSolicitanteController> _logger;

        public PersonalSolicitanteController(ILogger<PersonalSolicitanteController> logger)
        {
            _logger = logger;
        }

        readonly PersonalSolicitanteDAO PersonalSolicitanteBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Personales Solicitantes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {

            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<PersonalSolicitanteDTO> listaPersonalSolicitantes = PersonalSolicitanteBL.ObtenerPersonalSolicitantes();
            return Json(new { data = listaPersonalSolicitantes });
        }

        public ActionResult InsertarPersonalSolicitante(string CodigoPersonalSolicitante, string DescPersonalSolicitante)
        {
            var IND_OPERACION = "";
            try
            {
                PersonalSolicitanteDTO PersonalSolicitanteDTO = new();
                PersonalSolicitanteDTO.DescPersonalSolicitante = DescPersonalSolicitante;
                PersonalSolicitanteDTO.CodigoPersonalSolicitante = CodigoPersonalSolicitante;
                PersonalSolicitanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = PersonalSolicitanteBL.AgregarPersonalSolicitante(PersonalSolicitanteDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarPersonalSolicitante(int PersonalSolicitanteId)
        {
            return Json(PersonalSolicitanteBL.BuscarPersonalSolicitanteID(PersonalSolicitanteId));
        }

        public ActionResult ActualizarPersonalSolicitante(int PersonalSolicitanteId, string CodigoPersonalSolicitante, string DescPersonalSolicitante)
        {
            PersonalSolicitanteDTO PersonalSolicitanteDTO = new();
            PersonalSolicitanteDTO.PersonalSolicitanteId = PersonalSolicitanteId;
            PersonalSolicitanteDTO.DescPersonalSolicitante = DescPersonalSolicitante;
            PersonalSolicitanteDTO.CodigoPersonalSolicitante = CodigoPersonalSolicitante;
            PersonalSolicitanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = PersonalSolicitanteBL.ActualizarPersonalSolicitante(PersonalSolicitanteDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPersonalSolicitante(int PersonalSolicitanteId)
        {
            PersonalSolicitanteDTO PersonalSolicitanteDTO = new();
            PersonalSolicitanteDTO.PersonalSolicitanteId = PersonalSolicitanteId;
            PersonalSolicitanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = PersonalSolicitanteBL.EliminarPersonalSolicitante(PersonalSolicitanteDTO);

            return Content(IND_OPERACION);
        }
    }
}
