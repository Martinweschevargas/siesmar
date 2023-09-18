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
    public class MotivoBajaPersonalController : Controller
    {
        readonly ILogger<MotivoBajaPersonalController> _logger;

        public MotivoBajaPersonalController(ILogger<MotivoBajaPersonalController> logger)
        {
            _logger = logger;
        }

        readonly MotivoBajaPersonalDAO motivoBajaPersonalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Motivos Bajas Personales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MotivoBajaPersonalDTO> listaMotivoBajaPersonals = motivoBajaPersonalBL.ObtenerMotivoBajaPersonals();
            return Json(new { data = listaMotivoBajaPersonals });
        }

        public ActionResult InsertarMotivoBajaPersonal(string FlagMotivoBajaPersonal, string DescMotivoBajaPersonal, string CodigoMotivoBajaPersonal)
        {
            var IND_OPERACION = "";
            try
            {
                MotivoBajaPersonalDTO motivoBajaPersonalDTO = new();
                motivoBajaPersonalDTO.FlagMotivoBajaPersonal = FlagMotivoBajaPersonal;
                motivoBajaPersonalDTO.DescMotivoBajaPersonal = DescMotivoBajaPersonal;
                motivoBajaPersonalDTO.CodigoMotivoBajaPersonal = CodigoMotivoBajaPersonal;
                motivoBajaPersonalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = motivoBajaPersonalBL.AgregarMotivoBajaPersonal(motivoBajaPersonalDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMotivoBajaPersonal(int MotivoBajaPersonalId)
        {
            return Json(motivoBajaPersonalBL.BuscarMotivoBajaPersonalID(MotivoBajaPersonalId));
        }

        public ActionResult ActualizarMotivoBajaPersonal(int MotivoBajaPersonalId, string FlagMotivoBajaPersonal, string DescMotivoBajaPersonal, string CodigoMotivoBajaPersonal)
        {
            MotivoBajaPersonalDTO motivoBajaPersonalDTO = new();
            motivoBajaPersonalDTO.MotivoBajaPersonalId = MotivoBajaPersonalId;
            motivoBajaPersonalDTO.FlagMotivoBajaPersonal = FlagMotivoBajaPersonal;
            motivoBajaPersonalDTO.DescMotivoBajaPersonal = DescMotivoBajaPersonal;
            motivoBajaPersonalDTO.CodigoMotivoBajaPersonal = CodigoMotivoBajaPersonal;
            motivoBajaPersonalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = motivoBajaPersonalBL.ActualizarMotivoBajaPersonal(motivoBajaPersonalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMotivoBajaPersonal(int MotivoBajaPersonalId)
        {
            MotivoBajaPersonalDTO motivoBajaPersonalDTO = new();
            motivoBajaPersonalDTO.MotivoBajaPersonalId = MotivoBajaPersonalId;
            motivoBajaPersonalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = motivoBajaPersonalBL.EliminarMotivoBajaPersonal(motivoBajaPersonalDTO);

            return Content(IND_OPERACION);
        }
    }
}
