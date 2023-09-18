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
    public class OrigenPacienteIntervenidoController : Controller
    {
        readonly ILogger<OrigenPacienteIntervenidoController> _logger;

        public OrigenPacienteIntervenidoController(ILogger<OrigenPacienteIntervenidoController> logger)
        {
            _logger = logger;
        }

        readonly OrigenPacienteIntervenido origenPacienteIntervenidoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Orígenes Pacientes Intervenidos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<OrigenPacienteIntervenidoDTO> listaOrigenPacienteIntervenidos = origenPacienteIntervenidoBL.ObtenerOrigenPacienteIntervenidos();
            return Json(new { data = listaOrigenPacienteIntervenidos });
        }

        public ActionResult InsertarOrigenPacienteIntervenido(string Codigo, string Descripcion, string Abrev)
        {
            var IND_OPERACION = "";
            try
            {
                OrigenPacienteIntervenidoDTO origenPacienteIntervenidoDTO = new();
                origenPacienteIntervenidoDTO.DescOrigenPacienteIntervenido = Descripcion;
                origenPacienteIntervenidoDTO.CodigoOrigenPacienteIntervenido = Codigo;
                origenPacienteIntervenidoDTO.AbrevOrigenPacienteIntervenido = Abrev;
                origenPacienteIntervenidoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = origenPacienteIntervenidoBL.AgregarOrigenPacienteIntervenido(origenPacienteIntervenidoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarOrigenPacienteIntervenido(int OrigenPacienteIntervenidoId)
        {
            return Json(origenPacienteIntervenidoBL.BuscarOrigenPacienteIntervenidoID(OrigenPacienteIntervenidoId));
        }

        public ActionResult ActualizarOrigenPacienteIntervenido(int OrigenPacienteIntervenidoId, string Codigo, string Descripcion, string Abrev)
        {
            OrigenPacienteIntervenidoDTO origenPacienteIntervenidoDTO = new();
            origenPacienteIntervenidoDTO.OrigenPacienteIntervenidoId = OrigenPacienteIntervenidoId;
            origenPacienteIntervenidoDTO.DescOrigenPacienteIntervenido = Descripcion;
            origenPacienteIntervenidoDTO.CodigoOrigenPacienteIntervenido = Codigo;
            origenPacienteIntervenidoDTO.AbrevOrigenPacienteIntervenido = Abrev;
            origenPacienteIntervenidoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = origenPacienteIntervenidoBL.ActualizarOrigenPacienteIntervenido(origenPacienteIntervenidoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarOrigenPacienteIntervenido(int OrigenPacienteIntervenidoId)
        {
            OrigenPacienteIntervenidoDTO origenPacienteIntervenidoDTO = new();
            origenPacienteIntervenidoDTO.OrigenPacienteIntervenidoId = OrigenPacienteIntervenidoId;
            origenPacienteIntervenidoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = origenPacienteIntervenidoBL.EliminarOrigenPacienteIntervenido(origenPacienteIntervenidoDTO);

            return Content(IND_OPERACION);
        }
    }
}
