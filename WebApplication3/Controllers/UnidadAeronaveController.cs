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
    public class UnidadAeronaveController : Controller
    {
        readonly ILogger<UnidadAeronaveController> _logger;

        public UnidadAeronaveController(ILogger<UnidadAeronaveController> logger)
        {
            _logger = logger;
        }

        readonly UnidadAeronave unidadAeronaveBL = new();
        Usuario usuarioBL = new();

        TipoAeronave tipoAeronaveBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Unidades Aeronaves", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<TipoAeronaveDTO> tipoAeronaveDTO = tipoAeronaveBL.ObtenerTipoAeronaves();

            return Json(new { data = tipoAeronaveDTO });
        }

        public JsonResult CargarDatos()
        {
            List<UnidadAeronaveDTO> listaUnidadAeronavees = unidadAeronaveBL.ObtenerUnidadAeronaves();
            return Json(new { data = listaUnidadAeronavees });
        }

        public ActionResult InsertarUnidadAeronave(string Descripcion, string Codigo, int TipoAeronaveId)
        {
            var IND_OPERACION = "";
            try
            {
                UnidadAeronaveDTO unidadAeronaveDTO = new();
                unidadAeronaveDTO.DescUnidadAeronave = Descripcion;
                unidadAeronaveDTO.CodigoUnidadAeronave = Codigo;
                unidadAeronaveDTO.TipoAeronaveId = TipoAeronaveId;
                unidadAeronaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = unidadAeronaveBL.AgregarUnidadAeronave(unidadAeronaveDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarUnidadAeronave(int UnidadAeronaveId)
        {
            return Json(unidadAeronaveBL.BuscarUnidadAeronaveID(UnidadAeronaveId));
        }

        public ActionResult ActualizarUnidadAeronave(int UnidadAeronaveId, string Descripcion, string Codigo, int TipoAeronaveId)
        {
            UnidadAeronaveDTO unidadAeronaveDTO = new();
            unidadAeronaveDTO.UnidadAeronaveId = UnidadAeronaveId;
            unidadAeronaveDTO.DescUnidadAeronave = Descripcion;
            unidadAeronaveDTO.CodigoUnidadAeronave = Codigo;
            unidadAeronaveDTO.TipoAeronaveId = TipoAeronaveId;
            unidadAeronaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadAeronaveBL.ActualizarUnidadAeronave(unidadAeronaveDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarUnidadAeronave(int UnidadAeronaveId)
        {
            UnidadAeronaveDTO unidadAeronaveDTO = new();
            unidadAeronaveDTO.UnidadAeronaveId = UnidadAeronaveId;
            unidadAeronaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadAeronaveBL.EliminarUnidadAeronave(unidadAeronaveDTO);

            return Content(IND_OPERACION);
        }
    }
}
