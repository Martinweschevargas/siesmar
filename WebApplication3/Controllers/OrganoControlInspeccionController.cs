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
    public class OrganoControlInspeccionController : Controller
    {
        readonly ILogger<OrganoControlInspeccionController> _logger;

        public OrganoControlInspeccionController(ILogger<OrganoControlInspeccionController> logger)
        {
            _logger = logger;
        }

        readonly OrganoControlInspeccion organoControlInspeccionBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Órganos Controles Inspecciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<OrganoControlInspeccionDTO> listaOrganoControlInspeccions = organoControlInspeccionBL.ObtenerOrganoControlInspeccions();
            return Json(new { data = listaOrganoControlInspeccions });
        }

        public ActionResult InsertarOrganoControlInspeccion(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                OrganoControlInspeccionDTO organoControlInspeccionDTO = new();
                organoControlInspeccionDTO.DescOrganoControlInspeccion = Descripcion;
                organoControlInspeccionDTO.CodigoOrganoControlInspeccion = Codigo;
                organoControlInspeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = organoControlInspeccionBL.AgregarOrganoControlInspeccion(organoControlInspeccionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarOrganoControlInspeccion(int OrganoControlInspeccionId)
        {
            return Json(organoControlInspeccionBL.BuscarOrganoControlInspeccionID(OrganoControlInspeccionId));
        }

        public ActionResult ActualizarOrganoControlInspeccion(int OrganoControlInspeccionId, string Codigo, string Descripcion)
        {
            OrganoControlInspeccionDTO organoControlInspeccionDTO = new();
            organoControlInspeccionDTO.OrganoControlInspeccionId = OrganoControlInspeccionId;
            organoControlInspeccionDTO.DescOrganoControlInspeccion = Descripcion;
            organoControlInspeccionDTO.CodigoOrganoControlInspeccion = Codigo;
            organoControlInspeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = organoControlInspeccionBL.ActualizarOrganoControlInspeccion(organoControlInspeccionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarOrganoControlInspeccion(int OrganoControlInspeccionId)
        {
            OrganoControlInspeccionDTO organoControlInspeccionDTO = new();
            organoControlInspeccionDTO.OrganoControlInspeccionId = OrganoControlInspeccionId;
            organoControlInspeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = organoControlInspeccionBL.EliminarOrganoControlInspeccion(organoControlInspeccionDTO);

            return Content(IND_OPERACION);
        }
    }
}
