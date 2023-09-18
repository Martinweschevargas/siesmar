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
    public class PersonalCivilController : Controller
    {
        readonly ILogger<PersonalCivilController> _logger;

        public PersonalCivilController(ILogger<PersonalCivilController> logger)
        {
            _logger = logger;
        }

        readonly PersonalCivilMDAO PersonalCivilBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Personales Civiles", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<PersonalCivilMDTO> listaPersonalCivils = PersonalCivilBL.ObtenerPersonalCivils();
            return Json(new { data = listaPersonalCivils });
        }

        public ActionResult InsertarPersonalCivil(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                PersonalCivilMDTO PersonalCivilDTO = new();
                PersonalCivilDTO.DescPersonalCivil = Descripcion;
                PersonalCivilDTO.CodigoPersonalCivil = Codigo;
                PersonalCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = PersonalCivilBL.AgregarPersonalCivil(PersonalCivilDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarPersonalCivil(int PersonalCivilId)
        {
            return Json(PersonalCivilBL.BuscarPersonalCivilID(PersonalCivilId));
        }

        public ActionResult ActualizarPersonalCivil(int PersonalCivilId, string Codigo, string Descripcion)
        {
            PersonalCivilMDTO PersonalCivilDTO = new();
            PersonalCivilDTO.PersonalCivilId = PersonalCivilId;
            PersonalCivilDTO.DescPersonalCivil = Descripcion;
            PersonalCivilDTO.CodigoPersonalCivil = Codigo;
            PersonalCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = PersonalCivilBL.ActualizarPersonalCivil(PersonalCivilDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPersonalCivil(int PersonalCivilId)
        {
            PersonalCivilMDTO PersonalCivilDTO = new();
            PersonalCivilDTO.PersonalCivilId = PersonalCivilId;
            PersonalCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = PersonalCivilBL.EliminarPersonalCivil(PersonalCivilDTO);

            return Content(IND_OPERACION);
        }
    }
}
