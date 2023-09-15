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
    public class MotivoInvestigacionController : Controller
    {
        readonly ILogger<MotivoInvestigacionController> _logger;

        public MotivoInvestigacionController(ILogger<MotivoInvestigacionController> logger)
        {
            _logger = logger;
        }

        readonly MotivoInvestigacionDAO motivoInvestigacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Motivos Investigaciones", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MotivoInvestigacionDTO> listaMotivoInvestigacions = motivoInvestigacionBL.ObtenerMotivoInvestigacions();
            return Json(new { data = listaMotivoInvestigacions });
        }

        public ActionResult InsertarMotivoInvestigacion(string DescMotivoInvestigacion, string CodigoMotivoInvestigacion)
        {
            var IND_OPERACION="";
            try
            {
                MotivoInvestigacionDTO motivoInvestigacionDTO = new();
                motivoInvestigacionDTO.DescMotivoInvestigacion = DescMotivoInvestigacion;
                motivoInvestigacionDTO.CodigoMotivoInvestigacion = CodigoMotivoInvestigacion;
                motivoInvestigacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = motivoInvestigacionBL.AgregarMotivoInvestigacion(motivoInvestigacionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMotivoInvestigacion(int MotivoInvestigacionId)
        {
            return Json(motivoInvestigacionBL.BuscarMotivoInvestigacionID(MotivoInvestigacionId));
        }

        public ActionResult ActualizarMotivoInvestigacion(int MotivoInvestigacionId, string DescMotivoInvestigacion, string CodigoMotivoInvestigacion)
        {
            MotivoInvestigacionDTO motivoInvestigacionDTO = new();
            motivoInvestigacionDTO.MotivoInvestigacionId = MotivoInvestigacionId;
            motivoInvestigacionDTO.DescMotivoInvestigacion = DescMotivoInvestigacion;
            motivoInvestigacionDTO.CodigoMotivoInvestigacion = CodigoMotivoInvestigacion;
            motivoInvestigacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = motivoInvestigacionBL.ActualizarMotivoInvestigacion(motivoInvestigacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMotivoInvestigacion(int MotivoInvestigacionId)
        {
            MotivoInvestigacionDTO motivoInvestigacionDTO = new();
            motivoInvestigacionDTO.MotivoInvestigacionId = MotivoInvestigacionId;
            motivoInvestigacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = motivoInvestigacionBL.EliminarMotivoInvestigacion(motivoInvestigacionDTO);

            return Content(IND_OPERACION);
        }
    }
}
