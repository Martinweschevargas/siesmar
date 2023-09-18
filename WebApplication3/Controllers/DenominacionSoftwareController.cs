using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using MathNet.Numerics.Distributions;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DenominacionSoftwareController : Controller
    {
        readonly ILogger<DenominacionSoftwareController> _logger;

        public DenominacionSoftwareController(ILogger<DenominacionSoftwareController> logger)
        {
            _logger = logger;
        }

        readonly DenominacionSoftware denominacionSoftwareBL = new();
        Usuario usuarioBL = new();

        CategoriaSoftware categoriaSoftwareBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Denominaciones Software", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<CategoriaSoftwareDTO> categoriaSoftwareDTO = categoriaSoftwareBL.ObtenerCategoriaSoftwares();

            return Json(new { data = categoriaSoftwareDTO });
        }

        public JsonResult CargarDatos()
        {
            List<DenominacionSoftwareDTO> listaDenominacionSoftwarees = denominacionSoftwareBL.ObtenerDenominacionSoftwares();
            return Json(new { data = listaDenominacionSoftwarees });
        }

        public ActionResult InsertarDenominacionSoftware(string Descripcion, string Codigo, string Denominacion, int CategoriaSoftwareId)
        {
            var IND_OPERACION = "";
            try
            {
                DenominacionSoftwareDTO denominacionSoftwareDTO = new();
                denominacionSoftwareDTO.DescDenominacionSoftware = Descripcion;
                denominacionSoftwareDTO.CodigoDenominacionSoftware = Codigo;
                denominacionSoftwareDTO.DenominacionSoftware = Denominacion;
                denominacionSoftwareDTO.CategoriaSoftwareId = CategoriaSoftwareId;
                denominacionSoftwareDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = denominacionSoftwareBL.AgregarDenominacionSoftware(denominacionSoftwareDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDenominacionSoftware(int DenominacionSoftwareId)
        {
            return Json(denominacionSoftwareBL.BuscarDenominacionSoftwareID(DenominacionSoftwareId));
        }

        public ActionResult ActualizarDenominacionSoftware(int DenominacionSoftwareId, string Descripcion, string Codigo, string Denominacion, int CategoriaSoftwareId)
        {
            DenominacionSoftwareDTO denominacionSoftwareDTO = new();
            denominacionSoftwareDTO.DenominacionSoftwareId = DenominacionSoftwareId;
            denominacionSoftwareDTO.DescDenominacionSoftware = Descripcion;
            denominacionSoftwareDTO.CodigoDenominacionSoftware = Codigo;
            denominacionSoftwareDTO.DenominacionSoftware = Denominacion;
            denominacionSoftwareDTO.CategoriaSoftwareId = CategoriaSoftwareId;
            denominacionSoftwareDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = denominacionSoftwareBL.ActualizarDenominacionSoftware(denominacionSoftwareDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDenominacionSoftware(int DenominacionSoftwareId)
        {
            DenominacionSoftwareDTO denominacionSoftwareDTO = new();
            denominacionSoftwareDTO.DenominacionSoftwareId = DenominacionSoftwareId;
            denominacionSoftwareDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = denominacionSoftwareBL.EliminarDenominacionSoftware(denominacionSoftwareDTO);

            return Content(IND_OPERACION);
        }
    }
}
