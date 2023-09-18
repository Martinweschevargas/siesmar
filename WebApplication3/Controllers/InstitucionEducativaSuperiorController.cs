using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class InstitucionEducativaSuperiorController : Controller
    {
        readonly ILogger<InstitucionEducativaSuperiorController> _logger;

        public InstitucionEducativaSuperiorController(ILogger<InstitucionEducativaSuperiorController> logger)
        {
            _logger = logger;
        }

        readonly InstitucionEducativaSuperior institucionEducativaSuperiorBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Instituciones Educativas Superiores", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<InstitucionEducativaSuperiorDTO> listaInstitucionEducativaSuperiors = institucionEducativaSuperiorBL.ObtenerInstitucionEducativaSuperiors();
            return Json(new { data = listaInstitucionEducativaSuperiors });
        }

        public ActionResult InsertarInstitucionEducativaSuperior(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                InstitucionEducativaSuperiorDTO institucionEducativaSuperiorDTO = new();
                institucionEducativaSuperiorDTO.DescInstitucionEducativaSuperior = Descripcion;
                institucionEducativaSuperiorDTO.CodigoInstitucionEducativaSuperior = Codigo;
                institucionEducativaSuperiorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = institucionEducativaSuperiorBL.AgregarInstitucionEducativaSuperior(institucionEducativaSuperiorDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarInstitucionEducativaSuperior(int InstitucionEducativaSuperiorId)
        {
            return Json(institucionEducativaSuperiorBL.BuscarInstitucionEducativaSuperiorID(InstitucionEducativaSuperiorId));
        }

        public ActionResult ActualizarInstitucionEducativaSuperior(int InstitucionEducativaSuperiorId, string Codigo, string Descripcion)
        {
            InstitucionEducativaSuperiorDTO institucionEducativaSuperiorDTO = new();
            institucionEducativaSuperiorDTO.InstitucionEducativaSuperiorId = InstitucionEducativaSuperiorId;
            institucionEducativaSuperiorDTO.DescInstitucionEducativaSuperior = Descripcion;
            institucionEducativaSuperiorDTO.CodigoInstitucionEducativaSuperior = Codigo;
            institucionEducativaSuperiorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = institucionEducativaSuperiorBL.ActualizarInstitucionEducativaSuperior(institucionEducativaSuperiorDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarInstitucionEducativaSuperior(int InstitucionEducativaSuperiorId)
        {
            InstitucionEducativaSuperiorDTO institucionEducativaSuperiorDTO = new();
            institucionEducativaSuperiorDTO.InstitucionEducativaSuperiorId = InstitucionEducativaSuperiorId;
            institucionEducativaSuperiorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = institucionEducativaSuperiorBL.EliminarInstitucionEducativaSuperior(institucionEducativaSuperiorDTO);

            return Content(IND_OPERACION);
        }
    }
}
