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
    public class UnidadTipoAeronaveController : Controller
    {
        readonly ILogger<UnidadTipoAeronaveController> _logger;

        public UnidadTipoAeronaveController(ILogger<UnidadTipoAeronaveController> logger)
        {
            _logger = logger;
        }

        readonly UnidadTipoAeronave unidadTipoAeronaveBL = new();
        Usuario usuarioBL = new();

        TipoAeronave tipoAeronaveBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Unidades Tipos Aeronaves", FromController = typeof(HomeController))]
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
            List<UnidadTipoAeronaveDTO> listaUnidadTipoAeronavees = unidadTipoAeronaveBL.ObtenerUnidadTipoAeronaves();
            return Json(new { data = listaUnidadTipoAeronavees });
        }

        public ActionResult InsertarUnidadTipoAeronave(string Descripcion, string Codigo, int TipoAeronaveId)
        {
            var IND_OPERACION = "";
            try
            {
                UnidadTipoAeronaveDTO unidadTipoAeronaveDTO = new();
                unidadTipoAeronaveDTO.DescUnidadTipoAeronave = Descripcion;
                unidadTipoAeronaveDTO.CodigoUnidadTipoAeronave = Codigo;
                unidadTipoAeronaveDTO.TipoAeronaveId = TipoAeronaveId;
                unidadTipoAeronaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = unidadTipoAeronaveBL.AgregarUnidadTipoAeronave(unidadTipoAeronaveDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarUnidadTipoAeronave(int UnidadTipoAeronaveId)
        {
            return Json(unidadTipoAeronaveBL.BuscarUnidadTipoAeronaveID(UnidadTipoAeronaveId));
        }

        public ActionResult ActualizarUnidadTipoAeronave(int UnidadTipoAeronaveId, string Descripcion, string Codigo, int TipoAeronaveId)
        {
            UnidadTipoAeronaveDTO unidadTipoAeronaveDTO = new();
            unidadTipoAeronaveDTO.UnidadTipoAeronaveId = UnidadTipoAeronaveId;
            unidadTipoAeronaveDTO.DescUnidadTipoAeronave = Descripcion;
            unidadTipoAeronaveDTO.CodigoUnidadTipoAeronave = Codigo;
            unidadTipoAeronaveDTO.TipoAeronaveId = TipoAeronaveId;
            unidadTipoAeronaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadTipoAeronaveBL.ActualizarUnidadTipoAeronave(unidadTipoAeronaveDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarUnidadTipoAeronave(int UnidadTipoAeronaveId)
        {
            UnidadTipoAeronaveDTO unidadTipoAeronaveDTO = new();
            unidadTipoAeronaveDTO.UnidadTipoAeronaveId = UnidadTipoAeronaveId;
            unidadTipoAeronaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadTipoAeronaveBL.EliminarUnidadTipoAeronave(unidadTipoAeronaveDTO);

            return Content(IND_OPERACION);
        }
    }
}
