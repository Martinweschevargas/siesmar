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
    public class CicloDesarrolloSoftwareController : Controller
    {
        readonly ILogger<CicloDesarrolloSoftwareController> _logger;

        public CicloDesarrolloSoftwareController(ILogger<CicloDesarrolloSoftwareController> logger)
        {
            _logger = logger;
        }

        readonly CicloDesarrolloSoftwareDAO cicloDesarrolloSoftwareBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Ciclos Desarrollos Softwares", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CicloDesarrolloSoftwareDTO> listaCicloDesarrolloSoftwares = cicloDesarrolloSoftwareBL.ObtenerCicloDesarrolloSoftwares();
            return Json(new { data = listaCicloDesarrolloSoftwares });
        }

        public ActionResult InsertarCicloDesarrolloSoftware(string DescCicloDesarrolloSoftware, string CodigoCicloDesarrolloSoftware)
        {
            var IND_OPERACION="";
            try
            {
                CicloDesarrolloSoftwareDTO cicloDesarrolloSoftwareDTO = new();
                cicloDesarrolloSoftwareDTO.DescCicloDesarrolloSoftware = DescCicloDesarrolloSoftware;
                cicloDesarrolloSoftwareDTO.CodigoCicloDesarrolloSoftware = CodigoCicloDesarrolloSoftware;
                cicloDesarrolloSoftwareDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = cicloDesarrolloSoftwareBL.AgregarCicloDesarrolloSoftware(cicloDesarrolloSoftwareDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCicloDesarrolloSoftware(int CicloDesarrolloSoftwareId)
        {
            return Json(cicloDesarrolloSoftwareBL.BuscarCicloDesarrolloSoftwareID(CicloDesarrolloSoftwareId));
        }

        public ActionResult ActualizarCicloDesarrolloSoftware(int CicloDesarrolloSoftwareId, string DescCicloDesarrolloSoftware, string CodigoCicloDesarrolloSoftware)
        {
            CicloDesarrolloSoftwareDTO cicloDesarrolloSoftwareDTO = new();
            cicloDesarrolloSoftwareDTO.CicloDesarrolloSoftwareId = CicloDesarrolloSoftwareId;
            cicloDesarrolloSoftwareDTO.DescCicloDesarrolloSoftware = DescCicloDesarrolloSoftware;
            cicloDesarrolloSoftwareDTO.CodigoCicloDesarrolloSoftware = CodigoCicloDesarrolloSoftware;
            cicloDesarrolloSoftwareDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = cicloDesarrolloSoftwareBL.ActualizarCicloDesarrolloSoftware(cicloDesarrolloSoftwareDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCicloDesarrolloSoftware(int CicloDesarrolloSoftwareId)
        {
            CicloDesarrolloSoftwareDTO cicloDesarrolloSoftwareDTO = new();
            cicloDesarrolloSoftwareDTO.CicloDesarrolloSoftwareId = CicloDesarrolloSoftwareId;
            cicloDesarrolloSoftwareDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = cicloDesarrolloSoftwareBL.EliminarCicloDesarrolloSoftware(cicloDesarrolloSoftwareDTO);

            return Content(IND_OPERACION);
        }
    }
}
