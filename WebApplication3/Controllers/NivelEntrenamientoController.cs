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
    public class NivelEntrenamientoController : Controller
    {
        readonly ILogger<NivelEntrenamientoController> _logger;

        public NivelEntrenamientoController(ILogger<NivelEntrenamientoController> logger)
        {
            _logger = logger;
        }

        readonly NivelEntrenamientoDAO nivelEntrenamientoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Niveles Entrenamientos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<NivelEntrenamientoDTO> listaNivelEntrenamientos = nivelEntrenamientoBL.ObtenerNivelEntrenamientos();
            return Json(new { data = listaNivelEntrenamientos });
        }

        public ActionResult InsertarNivelEntrenamiento(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                NivelEntrenamientoDTO nivelEntrenamientoDTO = new();
                nivelEntrenamientoDTO.DescNivelEntrenamiento = Descripcion;
                nivelEntrenamientoDTO.CodigoNivelEntrenamiento = Codigo;
                nivelEntrenamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = nivelEntrenamientoBL.AgregarNivelEntrenamiento(nivelEntrenamientoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarNivelEntrenamiento(int NivelEntrenamientoId)
        {
            return Json(nivelEntrenamientoBL.BuscarNivelEntrenamientoID(NivelEntrenamientoId));
        }

        public ActionResult ActualizarNivelEntrenamiento(int NivelEntrenamientoId, string Codigo, string Descripcion)
        {
            NivelEntrenamientoDTO nivelEntrenamientoDTO = new();
            nivelEntrenamientoDTO.NivelEntrenamientoId = NivelEntrenamientoId;
            nivelEntrenamientoDTO.DescNivelEntrenamiento = Descripcion;
            nivelEntrenamientoDTO.CodigoNivelEntrenamiento = Codigo;
            nivelEntrenamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = nivelEntrenamientoBL.ActualizarNivelEntrenamiento(nivelEntrenamientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarNivelEntrenamiento(int NivelEntrenamientoId)
        {
            NivelEntrenamientoDTO nivelEntrenamientoDTO = new();
            nivelEntrenamientoDTO.NivelEntrenamientoId = NivelEntrenamientoId;
            nivelEntrenamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = nivelEntrenamientoBL.EliminarNivelEntrenamiento(nivelEntrenamientoDTO);

            return Content(IND_OPERACION);
        }
    }
}
