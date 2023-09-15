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
    public class CertificacionCETPROController : Controller
    {
        readonly ILogger<CertificacionCETPROController> _logger;

        public CertificacionCETPROController(ILogger<CertificacionCETPROController> logger)
        {
            _logger = logger;
        }

        readonly CertificacionCETPRO CertificacionCETPROBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Certificaciones CETPRO", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CertificacionCETPRODTO> listaCertificacionCETPROs = CertificacionCETPROBL.ObtenerCertificacionCETPROs();
            return Json(new { data = listaCertificacionCETPROs });
        }

        public ActionResult InsertarCertificacionCETPRO(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CertificacionCETPRODTO CertificacionCETPRODTO = new();
                CertificacionCETPRODTO.DescCertificacionCETPRO = Descripcion;
                CertificacionCETPRODTO.CodigoCertificacionCETPRO = Codigo;
                CertificacionCETPRODTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = CertificacionCETPROBL.AgregarCertificacionCETPRO(CertificacionCETPRODTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCertificacionCETPRO(int CertificacionCETPROId)
        {
            return Json(CertificacionCETPROBL.BuscarCertificacionCETPROID(CertificacionCETPROId));
        }

        public ActionResult ActualizarCertificacionCETPRO(int CertificacionCETPROId, string Codigo, string Descripcion)
        {
            CertificacionCETPRODTO CertificacionCETPRODTO = new();
            CertificacionCETPRODTO.CertificacionCETPROId = CertificacionCETPROId;
            CertificacionCETPRODTO.DescCertificacionCETPRO = Descripcion;
            CertificacionCETPRODTO.CodigoCertificacionCETPRO = Codigo;
            CertificacionCETPRODTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CertificacionCETPROBL.ActualizarCertificacionCETPRO(CertificacionCETPRODTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCertificacionCETPRO(int CertificacionCETPROId)
        {
            CertificacionCETPRODTO CertificacionCETPRODTO = new();
            CertificacionCETPRODTO.CertificacionCETPROId = CertificacionCETPROId;
            CertificacionCETPRODTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CertificacionCETPROBL.EliminarCertificacionCETPRO(CertificacionCETPRODTO);

            return Content(IND_OPERACION);
        }
    }
}
