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
    public class InstitucionEducativaController : Controller
    {
        readonly ILogger<InstitucionEducativaController> _logger;

        public InstitucionEducativaController(ILogger<InstitucionEducativaController> logger)
        {
            _logger = logger;
        }

        readonly InstitucionEducativaDAO institucionEducativaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Instituciones Educativas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<InstitucionEducativaDTO> listaInstitucionEducativas = institucionEducativaBL.ObtenerInstitucionEducativas();
            return Json(new { data = listaInstitucionEducativas });
        }

        public ActionResult InsertarInstitucionEducativa(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                InstitucionEducativaDTO institucionEducativaDTO = new();
                institucionEducativaDTO.DescInstitucionEducativa = Descripcion;
                institucionEducativaDTO.CodigoInstitucionEducativa = Codigo;
                institucionEducativaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = institucionEducativaBL.AgregarInstitucionEducativa(institucionEducativaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarInstitucionEducativa(int InstitucionEducativaId)
        {
            return Json(institucionEducativaBL.BuscarInstitucionEducativaID(InstitucionEducativaId));
        }

        public ActionResult ActualizarInstitucionEducativa(int InstitucionEducativaId, string Codigo, string Descripcion)
        {
            InstitucionEducativaDTO institucionEducativaDTO = new();
            institucionEducativaDTO.InstitucionEducativaId = InstitucionEducativaId;
            institucionEducativaDTO.DescInstitucionEducativa = Descripcion;
            institucionEducativaDTO.CodigoInstitucionEducativa = Codigo;
            institucionEducativaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = institucionEducativaBL.ActualizarInstitucionEducativa(institucionEducativaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarInstitucionEducativa(int InstitucionEducativaId)
        {
            InstitucionEducativaDTO institucionEducativaDTO = new();
            institucionEducativaDTO.InstitucionEducativaId = InstitucionEducativaId;
            institucionEducativaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = institucionEducativaBL.EliminarInstitucionEducativa(institucionEducativaDTO);

            return Content(IND_OPERACION);
        }
    }
}
