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
    public class SistemaPropulsionController : Controller
    {
        readonly ILogger<SistemaPropulsionController> _logger;

        public SistemaPropulsionController(ILogger<SistemaPropulsionController> logger)
        {
            _logger = logger;
        }

        readonly SistemaPropulsionDAO sistemaPropulsionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Sistemas Propulsión", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SistemaPropulsionDTO> listaSistemaPropulsions = sistemaPropulsionBL.ObtenerSistemaPropulsions();
            return Json(new { data = listaSistemaPropulsions });
        }

        public ActionResult InsertarSistemaPropulsion(string CodigoSistemaPropulsion, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                SistemaPropulsionDTO sistemaPropulsionDTO = new();
                sistemaPropulsionDTO.CodigoSistemaPropulsion = CodigoSistemaPropulsion;
                sistemaPropulsionDTO.DescSistemaPropulsion = Descripcion;
                sistemaPropulsionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = sistemaPropulsionBL.AgregarSistemaPropulsion(sistemaPropulsionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSistemaPropulsion(int SistemaPropulsionId)
        {
            return Json(sistemaPropulsionBL.BuscarSistemaPropulsionID(SistemaPropulsionId));
        }

        public ActionResult ActualizarSistemaPropulsion(int SistemaPropulsionId, string CodigoSistemaPropulsion, string Descripcion)
        {
            SistemaPropulsionDTO sistemaPropulsionDTO = new();
            sistemaPropulsionDTO.SistemaPropulsionId = SistemaPropulsionId;
            sistemaPropulsionDTO.CodigoSistemaPropulsion = CodigoSistemaPropulsion;
            sistemaPropulsionDTO.DescSistemaPropulsion = Descripcion;
            sistemaPropulsionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = sistemaPropulsionBL.ActualizarSistemaPropulsion(sistemaPropulsionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSistemaPropulsion(int SistemaPropulsionId)
        {
            SistemaPropulsionDTO sistemaPropulsionDTO = new();
            sistemaPropulsionDTO.SistemaPropulsionId = SistemaPropulsionId;
            sistemaPropulsionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = sistemaPropulsionBL.EliminarSistemaPropulsion(sistemaPropulsionDTO);

            return Content(IND_OPERACION);
        }
    }
}
