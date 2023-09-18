using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class AccionAnteCiberataqueController : Controller
    {
        readonly ILogger<AccionAnteCiberataqueController> _logger;

        public AccionAnteCiberataqueController(ILogger<AccionAnteCiberataqueController> logger)
        {
            _logger = logger;
        }

        readonly AccionAnteCiberataque accionAnteCiberataqueBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Acciones Ante Ciberataques", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<AccionAnteCiberataqueDTO> listaAccionAnteCiberataques = accionAnteCiberataqueBL.ObtenerAccionAnteCiberataques();
            return Json(new { data = listaAccionAnteCiberataques });
        }

        public ActionResult InsertarAccionAnteCiberataque(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                AccionAnteCiberataqueDTO accionAnteCiberataqueDTO = new();
                accionAnteCiberataqueDTO.DescAccionAnteCiberataque = Descripcion;
                accionAnteCiberataqueDTO.CodigoAccionAnteCiberataque = Codigo;
                accionAnteCiberataqueDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = accionAnteCiberataqueBL.AgregarAccionAnteCiberataque(accionAnteCiberataqueDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAccionAnteCiberataque(int AccionAnteCiberataqueId)
        {
            return Json(accionAnteCiberataqueBL.BuscarAccionAnteCiberataqueID(AccionAnteCiberataqueId));
        }

        public ActionResult ActualizarAccionAnteCiberataque(int AccionAnteCiberataqueId, string Codigo, string Descripcion)
        {
            AccionAnteCiberataqueDTO accionAnteCiberataqueDTO = new();
            accionAnteCiberataqueDTO.AccionAnteCiberataqueId = AccionAnteCiberataqueId;
            accionAnteCiberataqueDTO.DescAccionAnteCiberataque = Descripcion;
            accionAnteCiberataqueDTO.CodigoAccionAnteCiberataque = Codigo;
            accionAnteCiberataqueDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = accionAnteCiberataqueBL.ActualizarAccionAnteCiberataque(accionAnteCiberataqueDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAccionAnteCiberataque(int AccionAnteCiberataqueId)
        {
            AccionAnteCiberataqueDTO accionAnteCiberataqueDTO = new();
            accionAnteCiberataqueDTO.AccionAnteCiberataqueId = AccionAnteCiberataqueId;
            accionAnteCiberataqueDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = accionAnteCiberataqueBL.EliminarAccionAnteCiberataque(accionAnteCiberataqueDTO);

            return Content(IND_OPERACION);
        }
    }
}
