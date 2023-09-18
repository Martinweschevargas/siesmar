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
    public class EstablecimientoSaludMGPController : Controller
    {
        readonly ILogger<EstablecimientoSaludMGPController> _logger;

        public EstablecimientoSaludMGPController(ILogger<EstablecimientoSaludMGPController> logger)
        {
            _logger = logger;
        }

        readonly EstablecimientoSaludMGP establecimientoSaludMGPBL = new();
        EntidadMilitar entidadMilitarBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Establecimientos Salud MGP", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult cargaCombs()
        {
            List<EntidadMilitarDTO> entidadMilitarDTO = entidadMilitarBL.ObtenerEntidadMilitars();
            return Json(new { data = entidadMilitarDTO });
        }

        public JsonResult CargarDatos()
        {
            List<EstablecimientoSaludMGPDTO> listaEstablecimientoSaludMGPes = establecimientoSaludMGPBL.ObtenerEstablecimientoSaludMGPs();
            return Json(new { data = listaEstablecimientoSaludMGPes });
        }

        public ActionResult InsertarEstablecimientoSaludMGP(string Descripcion, string CodigoEstablecimiento, string CodigoRenaes, int EntidadMilitarId)
        {
            var IND_OPERACION = "";
            try
            {
                EstablecimientoSaludMGPDTO establecimientoSaludMGPDTO = new();
                establecimientoSaludMGPDTO.CodigoEstablecimientoRENAES = CodigoEstablecimiento;
                establecimientoSaludMGPDTO.CodigoRenaesMindef = CodigoRenaes;
                establecimientoSaludMGPDTO.EntidadMilitarId = EntidadMilitarId;
                establecimientoSaludMGPDTO.DescEstablecimientoSalud = Descripcion;
                establecimientoSaludMGPDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = establecimientoSaludMGPBL.AgregarEstablecimientoSaludMGP(establecimientoSaludMGPDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEstablecimientoSaludMGP(int EstablecimientoSaludMGPId)
        {
            return Json(establecimientoSaludMGPBL.BuscarEstablecimientoSaludMGPID(EstablecimientoSaludMGPId));
        }

        public ActionResult ActualizarEstablecimientoSaludMGP(int EstablecimientoSaludMGPId, string Descripcion, string CodigoEstablecimiento, string CodigoRenaes, int EntidadMilitarId)
        {
            EstablecimientoSaludMGPDTO establecimientoSaludMGPDTO = new();
            establecimientoSaludMGPDTO.EstablecimientoSaludMGPId = EstablecimientoSaludMGPId;
            establecimientoSaludMGPDTO.CodigoEstablecimientoRENAES = CodigoEstablecimiento;
            establecimientoSaludMGPDTO.CodigoRenaesMindef = CodigoRenaes;
            establecimientoSaludMGPDTO.EntidadMilitarId = EntidadMilitarId;
            establecimientoSaludMGPDTO.DescEstablecimientoSalud = Descripcion;
            establecimientoSaludMGPDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = establecimientoSaludMGPBL.ActualizarEstablecimientoSaludMGP(establecimientoSaludMGPDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEstablecimientoSaludMGP(int EstablecimientoSaludMGPId)
        {
            EstablecimientoSaludMGPDTO establecimientoSaludMGPDTO = new();
            establecimientoSaludMGPDTO.EstablecimientoSaludMGPId = EstablecimientoSaludMGPId;
            establecimientoSaludMGPDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = establecimientoSaludMGPBL.EliminarEstablecimientoSaludMGP(establecimientoSaludMGPDTO);

            return Content(IND_OPERACION);
        }
    }
}
