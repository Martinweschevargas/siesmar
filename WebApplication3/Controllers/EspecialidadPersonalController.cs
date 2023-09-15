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
    public class EspecialidadPersonalController : Controller
    {
        readonly ILogger<EspecialidadPersonalController> _logger;

        public EspecialidadPersonalController(ILogger<EspecialidadPersonalController> logger)
        {
            _logger = logger;
        }

        readonly EspecialidadPersonalDAO especialidadPersonalBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Especialidades Personales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EspecialidadPersonalDTO> listaEspecialidadPersonals = especialidadPersonalBL.ObtenerEspecialidadPersonals();
            return Json(new { data = listaEspecialidadPersonals });
        }

        public ActionResult InsertarEspecialidadPersonal(string DescEspecialidadPersonal, string CodigoEspecialidadPersonal)
        {
            var IND_OPERACION = "";
            try
            {
                EspecialidadPersonalDTO especialidadPersonalDTO = new();
                especialidadPersonalDTO.DescEspecialidadPersonal = DescEspecialidadPersonal;
                especialidadPersonalDTO.CodigoEspecialidadPersonal = CodigoEspecialidadPersonal;
                especialidadPersonalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = especialidadPersonalBL.AgregarEspecialidadPersonal(especialidadPersonalDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEspecialidadPersonal(int EspecialidadPersonalId)
        {
            return Json(especialidadPersonalBL.BuscarEspecialidadPersonalID(EspecialidadPersonalId));
        }

        public ActionResult ActualizarEspecialidadPersonal(int EspecialidadPersonalId, string DescEspecialidadPersonal, string CodigoEspecialidadPersonal)
        {
            EspecialidadPersonalDTO especialidadPersonalDTO = new();
            especialidadPersonalDTO.EspecialidadPersonalId = EspecialidadPersonalId;
            especialidadPersonalDTO.DescEspecialidadPersonal = DescEspecialidadPersonal;
            especialidadPersonalDTO.CodigoEspecialidadPersonal = CodigoEspecialidadPersonal;
            especialidadPersonalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = especialidadPersonalBL.ActualizarEspecialidadPersonal(especialidadPersonalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEspecialidadPersonal(int EspecialidadPersonalId)
        {
            EspecialidadPersonalDTO especialidadPersonalDTO = new();
            especialidadPersonalDTO.EspecialidadPersonalId = EspecialidadPersonalId;
            especialidadPersonalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = especialidadPersonalBL.EliminarEspecialidadPersonal(especialidadPersonalDTO);

            return Content(IND_OPERACION);
        }
    }
}
