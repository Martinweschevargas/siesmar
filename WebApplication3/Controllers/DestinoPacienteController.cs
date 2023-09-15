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
    public class DestinoPacienteController : Controller
    {
        readonly ILogger<DestinoPacienteController> _logger;

        public DestinoPacienteController(ILogger<DestinoPacienteController> logger)
        {
            _logger = logger;
        }

        readonly DestinoPaciente destinoPacienteBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Destinos Pacientes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DestinoPacienteDTO> listaDestinoPacientes = destinoPacienteBL.ObtenerDestinoPacientes();
            return Json(new { data = listaDestinoPacientes });
        }

        public ActionResult InsertarDestinoPaciente(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                DestinoPacienteDTO destinoPacienteDTO = new();
                destinoPacienteDTO.DescDestinoPaciente = Descripcion;
                destinoPacienteDTO.CodigoDestinoPaciente = Codigo;
                destinoPacienteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = destinoPacienteBL.AgregarDestinoPaciente(destinoPacienteDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDestinoPaciente(int DestinoPacienteId)
        {
            return Json(destinoPacienteBL.BuscarDestinoPacienteID(DestinoPacienteId));
        }

        public ActionResult ActualizarDestinoPaciente(int DestinoPacienteId, string Codigo, string Descripcion)
        {
            DestinoPacienteDTO destinoPacienteDTO = new();
            destinoPacienteDTO.DestinoPacienteId = DestinoPacienteId;
            destinoPacienteDTO.DescDestinoPaciente = Descripcion;
            destinoPacienteDTO.CodigoDestinoPaciente = Codigo;
            destinoPacienteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = destinoPacienteBL.ActualizarDestinoPaciente(destinoPacienteDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDestinoPaciente(int DestinoPacienteId)
        {
            DestinoPacienteDTO destinoPacienteDTO = new();
            destinoPacienteDTO.DestinoPacienteId = DestinoPacienteId;
            destinoPacienteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = destinoPacienteBL.EliminarDestinoPaciente(destinoPacienteDTO);

            return Content(IND_OPERACION);
        }
    }
}
