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
    public class SeveridadCiberataqueController : Controller
    {
        readonly ILogger<SeveridadCiberataqueController> _logger;

        public SeveridadCiberataqueController(ILogger<SeveridadCiberataqueController> logger)
        {
            _logger = logger;
        }

        readonly SeveridadCiberataque severidadCiberataqueBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Severidad Ciberataques", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SeveridadCiberataqueDTO> listaSeveridadCiberataques = severidadCiberataqueBL.ObtenerSeveridadCiberataques();
            return Json(new { data = listaSeveridadCiberataques });
        }

        public ActionResult InsertarSeveridadCiberataque(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                SeveridadCiberataqueDTO severidadCiberataqueDTO = new();
                severidadCiberataqueDTO.DescSeveridadCiberataque = Descripcion;
                severidadCiberataqueDTO.CodigoSeveridadCiberataque = Codigo;
                severidadCiberataqueDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = severidadCiberataqueBL.AgregarSeveridadCiberataque(severidadCiberataqueDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSeveridadCiberataque(int SeveridadCiberataqueId)
        {
            return Json(severidadCiberataqueBL.BuscarSeveridadCiberataqueID(SeveridadCiberataqueId));
        }

        public ActionResult ActualizarSeveridadCiberataque(int SeveridadCiberataqueId, string Codigo, string Descripcion)
        {
            SeveridadCiberataqueDTO severidadCiberataqueDTO = new();
            severidadCiberataqueDTO.SeveridadCiberataqueId = SeveridadCiberataqueId;
            severidadCiberataqueDTO.DescSeveridadCiberataque = Descripcion;
            severidadCiberataqueDTO.CodigoSeveridadCiberataque = Codigo;
            severidadCiberataqueDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = severidadCiberataqueBL.ActualizarSeveridadCiberataque(severidadCiberataqueDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSeveridadCiberataque(int SeveridadCiberataqueId)
        {
            SeveridadCiberataqueDTO severidadCiberataqueDTO = new();
            severidadCiberataqueDTO.SeveridadCiberataqueId = SeveridadCiberataqueId;
            severidadCiberataqueDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = severidadCiberataqueBL.EliminarSeveridadCiberataque(severidadCiberataqueDTO);

            return Content(IND_OPERACION);
        }
    }
}
