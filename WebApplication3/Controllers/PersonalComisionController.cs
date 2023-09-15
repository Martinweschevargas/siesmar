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
    public class PersonalComisionController : Controller
    {
        readonly ILogger<PersonalComisionController> _logger;

        public PersonalComisionController(ILogger<PersonalComisionController> logger)
        {
            _logger = logger;
        }

        readonly PersonalComisionDAO personalComisionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Personales Comisiones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<PersonalComisionDTO> listaPersonalComisions = personalComisionBL.ObtenerPersonalComisions();
            return Json(new { data = listaPersonalComisions });
        }

        public ActionResult InsertarPersonalComision(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                PersonalComisionDTO personalComisionDTO = new();
                personalComisionDTO.DescPersonalComision = Descripcion;
                personalComisionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = personalComisionBL.AgregarPersonalComision(personalComisionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarPersonalComision(int PersonalComisionId)
        {
            return Json(personalComisionBL.BuscarPersonalComisionID(PersonalComisionId));
        }

        public ActionResult ActualizarPersonalComision(int PersonalComisionId, string Descripcion)
        {
            PersonalComisionDTO personalComisionDTO = new();
            personalComisionDTO.PersonalComisionId = PersonalComisionId;
            personalComisionDTO.DescPersonalComision = Descripcion;
            personalComisionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = personalComisionBL.ActualizarPersonalComision(personalComisionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPersonalComision(int PersonalComisionId)
        {
            PersonalComisionDTO personalComisionDTO = new();
            personalComisionDTO.PersonalComisionId = PersonalComisionId;
            personalComisionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = personalComisionBL.EliminarPersonalComision(personalComisionDTO);

            return Content(IND_OPERACION);
        }
    }
}
