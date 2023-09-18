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
    public class EspecialidadMedicaNoMedicaController : Controller
    {
        readonly ILogger<EspecialidadMedicaNoMedicaController> _logger;

        public EspecialidadMedicaNoMedicaController(ILogger<EspecialidadMedicaNoMedicaController> logger)
        {
            _logger = logger;
        }

        readonly EspecialidadMedicaNoMedica especialidadMedicaNoMedicaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Especialidades Médicas No Médicas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EspecialidadMedicaNoMedicaDTO> listaEspecialidadMedicaNoMedicas = especialidadMedicaNoMedicaBL.ObtenerEspecialidadMedicaNoMedicas();
            return Json(new { data = listaEspecialidadMedicaNoMedicas });
        }

        public ActionResult InsertarEspecialidadMedicaNoMedica(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                EspecialidadMedicaNoMedicaDTO especialidadMedicaNoMedicaDTO = new();
                especialidadMedicaNoMedicaDTO.DescEspecialidadMedicaNoMedica = Descripcion;
                especialidadMedicaNoMedicaDTO.CodigoUPS = Codigo;
                especialidadMedicaNoMedicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = especialidadMedicaNoMedicaBL.AgregarEspecialidadMedicaNoMedica(especialidadMedicaNoMedicaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEspecialidadMedicaNoMedica(int EspecialidadMedicaNoMedicaId)
        {
            return Json(especialidadMedicaNoMedicaBL.BuscarEspecialidadMedicaNoMedicaID(EspecialidadMedicaNoMedicaId));
        }

        public ActionResult ActualizarEspecialidadMedicaNoMedica(int EspecialidadMedicaNoMedicaId, string Codigo, string Descripcion)
        {
            EspecialidadMedicaNoMedicaDTO especialidadMedicaNoMedicaDTO = new();
            especialidadMedicaNoMedicaDTO.EspecialidadMedicaNoMedicaId = EspecialidadMedicaNoMedicaId;
            especialidadMedicaNoMedicaDTO.DescEspecialidadMedicaNoMedica = Descripcion;
            especialidadMedicaNoMedicaDTO.CodigoUPS = Codigo;
            especialidadMedicaNoMedicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = especialidadMedicaNoMedicaBL.ActualizarEspecialidadMedicaNoMedica(especialidadMedicaNoMedicaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEspecialidadMedicaNoMedica(int EspecialidadMedicaNoMedicaId)
        {
            EspecialidadMedicaNoMedicaDTO especialidadMedicaNoMedicaDTO = new();
            especialidadMedicaNoMedicaDTO.EspecialidadMedicaNoMedicaId = EspecialidadMedicaNoMedicaId;
            especialidadMedicaNoMedicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = especialidadMedicaNoMedicaBL.EliminarEspecialidadMedicaNoMedica(especialidadMedicaNoMedicaDTO);

            return Content(IND_OPERACION);
        }
    }
}
