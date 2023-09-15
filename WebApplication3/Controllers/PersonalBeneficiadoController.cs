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
    public class PersonalBeneficiadoController : Controller
    {
        readonly ILogger<PersonalBeneficiadoController> _logger;

        public PersonalBeneficiadoController(ILogger<PersonalBeneficiadoController> logger)
        {
            _logger = logger;
        }

        readonly PersonalBeneficiadoDAO PersonalBeneficiadoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Personales Beneficiados", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<PersonalBeneficiadoDTO> listaPersonalBeneficiados = PersonalBeneficiadoBL.ObtenerPersonalBeneficiados();
            return Json(new { data = listaPersonalBeneficiados });
        }

        public ActionResult InsertarPersonalBeneficiado(string CodigoPersonalBeneficiado, string DescPersonalBeneficiado)
        {
            var IND_OPERACION = "";
            try
            {
                PersonalBeneficiadoDTO PersonalBeneficiadoDTO = new();
                PersonalBeneficiadoDTO.DescPersonalBeneficiado = DescPersonalBeneficiado;
                PersonalBeneficiadoDTO.CodigoPersonalBeneficiado = CodigoPersonalBeneficiado;
                PersonalBeneficiadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = PersonalBeneficiadoBL.AgregarPersonalBeneficiado(PersonalBeneficiadoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarPersonalBeneficiado(int PersonalBeneficiadoId)
        {
            return Json(PersonalBeneficiadoBL.BuscarPersonalBeneficiadoID(PersonalBeneficiadoId));
        }

        public ActionResult ActualizarPersonalBeneficiado(int PersonalBeneficiadoId, string CodigoPersonalBeneficiado, string DescPersonalBeneficiado)
        {
            PersonalBeneficiadoDTO PersonalBeneficiadoDTO = new();
            PersonalBeneficiadoDTO.PersonalBeneficiadoId = PersonalBeneficiadoId;
            PersonalBeneficiadoDTO.DescPersonalBeneficiado = DescPersonalBeneficiado;
            PersonalBeneficiadoDTO.CodigoPersonalBeneficiado = CodigoPersonalBeneficiado;
            PersonalBeneficiadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = PersonalBeneficiadoBL.ActualizarPersonalBeneficiado(PersonalBeneficiadoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPersonalBeneficiado(int PersonalBeneficiadoId)
        {
            PersonalBeneficiadoDTO PersonalBeneficiadoDTO = new();
            PersonalBeneficiadoDTO.PersonalBeneficiadoId = PersonalBeneficiadoId;
            PersonalBeneficiadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = PersonalBeneficiadoBL.EliminarPersonalBeneficiado(PersonalBeneficiadoDTO);

            return Content(IND_OPERACION);
        }
    }
}
