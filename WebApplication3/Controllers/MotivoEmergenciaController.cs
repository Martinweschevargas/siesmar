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
    public class MotivoEmergenciaController : Controller
    {
        readonly ILogger<MotivoEmergenciaController> _logger;

        public MotivoEmergenciaController(ILogger<MotivoEmergenciaController> logger)
        {
            _logger = logger;
        }

        readonly MotivoEmergencia motivoEmergenciaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Motivos Emergencias", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MotivoEmergenciaDTO> listaMotivoEmergencias = motivoEmergenciaBL.ObtenerMotivoEmergencias();
            return Json(new { data = listaMotivoEmergencias });
        }

        public ActionResult InsertarMotivoEmergencia(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                MotivoEmergenciaDTO motivoEmergenciaDTO = new();
                motivoEmergenciaDTO.DescMotivoEmergencia = Descripcion;
                motivoEmergenciaDTO.CodigoMotivoEmergencia = Codigo;
                motivoEmergenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = motivoEmergenciaBL.AgregarMotivoEmergencia(motivoEmergenciaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMotivoEmergencia(int MotivoEmergenciaId)
        {
            return Json(motivoEmergenciaBL.BuscarMotivoEmergenciaID(MotivoEmergenciaId));
        }

        public ActionResult ActualizarMotivoEmergencia(int MotivoEmergenciaId, string Codigo, string Descripcion)
        {
            MotivoEmergenciaDTO motivoEmergenciaDTO = new();
            motivoEmergenciaDTO.MotivoEmergenciaId = MotivoEmergenciaId;
            motivoEmergenciaDTO.DescMotivoEmergencia = Descripcion;
            motivoEmergenciaDTO.CodigoMotivoEmergencia = Codigo;
            motivoEmergenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = motivoEmergenciaBL.ActualizarMotivoEmergencia(motivoEmergenciaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMotivoEmergencia(int MotivoEmergenciaId)
        {
            MotivoEmergenciaDTO motivoEmergenciaDTO = new();
            motivoEmergenciaDTO.MotivoEmergenciaId = MotivoEmergenciaId;
            motivoEmergenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = motivoEmergenciaBL.EliminarMotivoEmergencia(motivoEmergenciaDTO);

            return Content(IND_OPERACION);
        }
    }
}
