using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Algorithm;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class EspecialidadPostulacionController : Controller
    {
        readonly ILogger<EspecialidadPostulacionController> _logger;

        public EspecialidadPostulacionController(ILogger<EspecialidadPostulacionController> logger)
        {
            _logger = logger;
        }

        readonly EspecialidadPostulacion especialidadPostulacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Especialidades Postulaciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EspecialidadPostulacionDTO> listaEspecialidadPostulacions = especialidadPostulacionBL.ObtenerEspecialidadPostulacions();
            return Json(new { data = listaEspecialidadPostulacions });
        }

        public ActionResult InsertarEspecialidadPostulacion(string Codigo,string Abrev, string Descripcion, string Especialidad)
        {
            var IND_OPERACION = "";
            try
            {
                EspecialidadPostulacionDTO especialidadPostulacionDTO = new();
                especialidadPostulacionDTO.DescEspecialidadPostulacion = Descripcion;
                especialidadPostulacionDTO.CodigoEspecialidadPostulacion = Codigo;
                especialidadPostulacionDTO.AbrevEspecialidadPostulacion = Abrev;
                especialidadPostulacionDTO.ProfesionalEspecialidadPostulacion = Especialidad;
                especialidadPostulacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = especialidadPostulacionBL.AgregarEspecialidadPostulacion(especialidadPostulacionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEspecialidadPostulacion(int EspecialidadPostulacionId)
        {
            return Json(especialidadPostulacionBL.BuscarEspecialidadPostulacionID(EspecialidadPostulacionId));
        }

        public ActionResult ActualizarEspecialidadPostulacion(int EspecialidadPostulacionId, string Abrev, string Descripcion, string Codigo, string Especialidad)
        {
            EspecialidadPostulacionDTO especialidadPostulacionDTO = new();
            especialidadPostulacionDTO.EspecialidadPostulacionId = EspecialidadPostulacionId;
            especialidadPostulacionDTO.DescEspecialidadPostulacion = Descripcion;
            especialidadPostulacionDTO.CodigoEspecialidadPostulacion = Codigo;
            especialidadPostulacionDTO.AbrevEspecialidadPostulacion = Abrev;
            especialidadPostulacionDTO.ProfesionalEspecialidadPostulacion = Especialidad;
            especialidadPostulacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = especialidadPostulacionBL.ActualizarEspecialidadPostulacion(especialidadPostulacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEspecialidadPostulacion(int EspecialidadPostulacionId)
        {
            EspecialidadPostulacionDTO especialidadPostulacionDTO = new();
            especialidadPostulacionDTO.EspecialidadPostulacionId = EspecialidadPostulacionId;
            especialidadPostulacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = especialidadPostulacionBL.EliminarEspecialidadPostulacion(especialidadPostulacionDTO);

            return Content(IND_OPERACION);
        }
    }
}
