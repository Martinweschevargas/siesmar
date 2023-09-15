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
    public class VehiculoServicioTipoController : Controller
    {
        readonly ILogger<VehiculoServicioTipoController> _logger;

        public VehiculoServicioTipoController(ILogger<VehiculoServicioTipoController> logger)
        {
            _logger = logger;
        }

        readonly VehiculoServicioTipo vehiculoServicioTipoBL = new();
        Usuario usuarioBL = new();

        VehiculoServicioGrupo vehiculoServicioGrupoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Vehículos Servicios Tipos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<VehiculoServicioGrupoDTO> vehiculoServicioGrupoDTO = vehiculoServicioGrupoBL.ObtenerVehiculoServicioGrupos();

            return Json(new { data = vehiculoServicioGrupoDTO });
        }

        public JsonResult CargarDatos()
        {
            List<VehiculoServicioTipoDTO> listaVehiculoServicioTipoes = vehiculoServicioTipoBL.ObtenerVehiculoServicioTipos();
            return Json(new { data = listaVehiculoServicioTipoes });
        }

        public ActionResult InsertarVehiculoServicioTipo(string Descripcion, string Codigo, int VehiculoServicioGrupoId)
        {
            var IND_OPERACION = "";
            try
            {
                VehiculoServicioTipoDTO vehiculoServicioTipoDTO = new();
                vehiculoServicioTipoDTO.DescVehiculoServicioTipo = Descripcion;
                vehiculoServicioTipoDTO.CodigoVehiculoServicioTipo = Codigo;
                vehiculoServicioTipoDTO.VehiculoServicioGrupoId = VehiculoServicioGrupoId;
                vehiculoServicioTipoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = vehiculoServicioTipoBL.AgregarVehiculoServicioTipo(vehiculoServicioTipoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarVehiculoServicioTipo(int VehiculoServicioTipoId)
        {
            return Json(vehiculoServicioTipoBL.BuscarVehiculoServicioTipoID(VehiculoServicioTipoId));
        }

        public ActionResult ActualizarVehiculoServicioTipo(int VehiculoServicioTipoId, string Descripcion, string Codigo, int VehiculoServicioGrupoId)
        {
            VehiculoServicioTipoDTO vehiculoServicioTipoDTO = new();
            vehiculoServicioTipoDTO.VehiculoServicioTipoId = VehiculoServicioTipoId;
            vehiculoServicioTipoDTO.DescVehiculoServicioTipo = Descripcion;
            vehiculoServicioTipoDTO.CodigoVehiculoServicioTipo = Codigo;
            vehiculoServicioTipoDTO.VehiculoServicioGrupoId = VehiculoServicioGrupoId;
            vehiculoServicioTipoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = vehiculoServicioTipoBL.ActualizarVehiculoServicioTipo(vehiculoServicioTipoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarVehiculoServicioTipo(int VehiculoServicioTipoId)
        {
            VehiculoServicioTipoDTO vehiculoServicioTipoDTO = new();
            vehiculoServicioTipoDTO.VehiculoServicioTipoId = VehiculoServicioTipoId;
            vehiculoServicioTipoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = vehiculoServicioTipoBL.EliminarVehiculoServicioTipo(vehiculoServicioTipoDTO);

            return Content(IND_OPERACION);
        }
    }
}
