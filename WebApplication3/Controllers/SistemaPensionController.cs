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
    public class SistemaPensionController : Controller
    {
        readonly ILogger<SistemaPensionController> _logger;

        public SistemaPensionController(ILogger<SistemaPensionController> logger)
        {
            _logger = logger;
        }

        readonly SistemaPensionDAO sistemaPensionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Sistemas Pensiones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SistemaPensionDTO> listaSistemaPensions = sistemaPensionBL.ObtenerSistemaPensions();
            return Json(new { data = listaSistemaPensions });
        }

        public ActionResult InsertarSistemaPension(string DescSistemaPension, string CodigoSistemaPension)
        {
            var IND_OPERACION = "";
            try
            {
                SistemaPensionDTO sistemaPensionDTO = new();
                sistemaPensionDTO.DescSistemaPension = DescSistemaPension;
                sistemaPensionDTO.CodigoSistemaPension = CodigoSistemaPension;
                sistemaPensionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = sistemaPensionBL.AgregarSistemaPension(sistemaPensionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSistemaPension(int SistemaPensionId)
        {
            return Json(sistemaPensionBL.BuscarSistemaPensionID(SistemaPensionId));
        }

        public ActionResult ActualizarSistemaPension(int SistemaPensionId, string DescSistemaPension, string CodigoSistemaPension)
        {
            SistemaPensionDTO sistemaPensionDTO = new();
            sistemaPensionDTO.SistemaPensionId = SistemaPensionId;
            sistemaPensionDTO.DescSistemaPension = DescSistemaPension;
            sistemaPensionDTO.CodigoSistemaPension = CodigoSistemaPension;
            sistemaPensionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = sistemaPensionBL.ActualizarSistemaPension(sistemaPensionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSistemaPension(int SistemaPensionId)
        {
            SistemaPensionDTO sistemaPensionDTO = new();
            sistemaPensionDTO.SistemaPensionId = SistemaPensionId;
            sistemaPensionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = sistemaPensionBL.EliminarSistemaPension(sistemaPensionDTO);

            return Content(IND_OPERACION);
        }
    }
}
