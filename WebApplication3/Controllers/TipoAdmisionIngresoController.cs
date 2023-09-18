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
    public class TipoAdmisionIngresoController : Controller
    {
        readonly ILogger<TipoAdmisionIngresoController> _logger;

        public TipoAdmisionIngresoController(ILogger<TipoAdmisionIngresoController> logger)
        {
            _logger = logger;
        }

        readonly TipoAdmisionIngresoDAO tipoAdmisionIngresoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Admisiones Ingresos", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoAdmisionIngresoDTO> listaTipoAdmisionIngresos = tipoAdmisionIngresoBL.ObtenerTipoAdmisionIngresos();
            return Json(new { data = listaTipoAdmisionIngresos });
        }

        public ActionResult InsertarTipoAdmisionIngreso(string DescTipoAdmisionIngreso, string CodigoTipoAdmisionIngreso)
        {
            var IND_OPERACION="";
            try
            {
                TipoAdmisionIngresoDTO tipoAdmisionIngresoDTO = new();
                tipoAdmisionIngresoDTO.DescTipoAdmisionIngreso = DescTipoAdmisionIngreso;
                tipoAdmisionIngresoDTO.CodigoTipoAdmisionIngreso = CodigoTipoAdmisionIngreso;
                tipoAdmisionIngresoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoAdmisionIngresoBL.AgregarTipoAdmisionIngreso(tipoAdmisionIngresoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoAdmisionIngreso(int TipoAdmisionIngresoId)
        {
            return Json(tipoAdmisionIngresoBL.BuscarTipoAdmisionIngresoID(TipoAdmisionIngresoId));
        }

        public ActionResult ActualizarTipoAdmisionIngreso(int TipoAdmisionIngresoId, string DescTipoAdmisionIngreso, string CodigoTipoAdmisionIngreso)
        {
            TipoAdmisionIngresoDTO tipoAdmisionIngresoDTO = new();
            tipoAdmisionIngresoDTO.TipoAdmisionIngresoId = TipoAdmisionIngresoId;
            tipoAdmisionIngresoDTO.DescTipoAdmisionIngreso = DescTipoAdmisionIngreso;
            tipoAdmisionIngresoDTO.CodigoTipoAdmisionIngreso = CodigoTipoAdmisionIngreso;
            tipoAdmisionIngresoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoAdmisionIngresoBL.ActualizarTipoAdmisionIngreso(tipoAdmisionIngresoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoAdmisionIngreso(int TipoAdmisionIngresoId)
        {
            TipoAdmisionIngresoDTO tipoAdmisionIngresoDTO = new();
            tipoAdmisionIngresoDTO.TipoAdmisionIngresoId = TipoAdmisionIngresoId;
            tipoAdmisionIngresoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoAdmisionIngresoBL.EliminarTipoAdmisionIngreso(tipoAdmisionIngresoDTO);

            return Content(IND_OPERACION);
        }
    }
}
