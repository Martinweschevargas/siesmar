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
    public class CentroGastoController : Controller
    {
        readonly ILogger<CentroGastoController> _logger;

        public CentroGastoController(ILogger<CentroGastoController> logger)
        {
            _logger = logger;
        }

        readonly CentroGastoDAO CentroGastoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Centros Gastos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CentroGastoDTO> listaCentroGastos = CentroGastoBL.ObtenerCentroGastos();
            return Json(new { data = listaCentroGastos });
        }

        public ActionResult InsertarCentroGasto(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CentroGastoDTO CentroGastoDTO = new();
                CentroGastoDTO.DescCentroGasto = Descripcion;
                CentroGastoDTO.CodigoCentroGasto = Codigo;
                CentroGastoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = CentroGastoBL.AgregarCentroGasto(CentroGastoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCentroGasto(int CentroGastoId)
        {
            return Json(CentroGastoBL.BuscarCentroGastoID(CentroGastoId));
        }

        public ActionResult ActualizarCentroGasto(int CentroGastoId, string Codigo, string Descripcion)
        {
            CentroGastoDTO CentroGastoDTO = new();
            CentroGastoDTO.CentroGastoId = CentroGastoId;
            CentroGastoDTO.DescCentroGasto = Descripcion;
            CentroGastoDTO.CodigoCentroGasto = Codigo;
            CentroGastoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CentroGastoBL.ActualizarCentroGasto(CentroGastoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCentroGasto(int CentroGastoId)
        {
            CentroGastoDTO CentroGastoDTO = new();
            CentroGastoDTO.CentroGastoId = CentroGastoId;
            CentroGastoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CentroGastoBL.EliminarCentroGasto(CentroGastoDTO);

            return Content(IND_OPERACION);
        }
    }
}
