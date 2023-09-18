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
    public class MedioInvestigacionController : Controller
    {
        readonly ILogger<MedioInvestigacionController> _logger;

        public MedioInvestigacionController(ILogger<MedioInvestigacionController> logger)
        {
            _logger = logger;
        }

        readonly MedioInvestigacionDAO medioInvestigacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Medios Investigaciones", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MedioInvestigacionDTO> listaMedioInvestigacions = medioInvestigacionBL.ObtenerMedioInvestigacions();
            return Json(new { data = listaMedioInvestigacions });
        }

        public ActionResult InsertarMedioInvestigacion(string DescMedioInvestigacion, string CodigoMedioInvestigacion)
        {
            var IND_OPERACION="";
            try
            {
                MedioInvestigacionDTO medioInvestigacionDTO = new();
                medioInvestigacionDTO.DescMedioInvestigacion = DescMedioInvestigacion;
                medioInvestigacionDTO.CodigoMedioInvestigacion = CodigoMedioInvestigacion;
                medioInvestigacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = medioInvestigacionBL.AgregarMedioInvestigacion(medioInvestigacionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMedioInvestigacion(int MedioInvestigacionId)
        {
            return Json(medioInvestigacionBL.BuscarMedioInvestigacionID(MedioInvestigacionId));
        }

        public ActionResult ActualizarMedioInvestigacion(int MedioInvestigacionId, string DescMedioInvestigacion, string CodigoMedioInvestigacion)
        {
            MedioInvestigacionDTO medioInvestigacionDTO = new();
            medioInvestigacionDTO.MedioInvestigacionId = MedioInvestigacionId;
            medioInvestigacionDTO.DescMedioInvestigacion = DescMedioInvestigacion;
            medioInvestigacionDTO.CodigoMedioInvestigacion = CodigoMedioInvestigacion;
            medioInvestigacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = medioInvestigacionBL.ActualizarMedioInvestigacion(medioInvestigacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMedioInvestigacion(int MedioInvestigacionId)
        {
            MedioInvestigacionDTO medioInvestigacionDTO = new();
            medioInvestigacionDTO.MedioInvestigacionId = MedioInvestigacionId;
            medioInvestigacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = medioInvestigacionBL.EliminarMedioInvestigacion(medioInvestigacionDTO);

            return Content(IND_OPERACION);
        }
    }
}
