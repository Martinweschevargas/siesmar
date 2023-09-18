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
    public class ClasificacionGenericaGastoController : Controller
    {
        readonly ILogger<ClasificacionGenericaGastoController> _logger;

        public ClasificacionGenericaGastoController(ILogger<ClasificacionGenericaGastoController> logger)
        {
            _logger = logger;
        }

        readonly ClasificacionGenericaGasto clasificacionGenericaGastoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clasificaciones Genéricas Gastos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
          
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClasificacionGenericaGastoDTO> listaClasificacionGenericaGastos = clasificacionGenericaGastoBL.ObtenerClasificacionGenericaGastos();
            return Json(new { data = listaClasificacionGenericaGastos });
        }

        public ActionResult InsertarClasificacionGenericaGasto(string Clasificacion, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ClasificacionGenericaGastoDTO clasificacionGenericaGastoDTO = new();
                clasificacionGenericaGastoDTO.DescClasificacionGenericaGasto = Descripcion;
                clasificacionGenericaGastoDTO.ClasificacionGenericaGasto = Clasificacion;
                clasificacionGenericaGastoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = clasificacionGenericaGastoBL.AgregarClasificacionGenericaGasto(clasificacionGenericaGastoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClasificacionGenericaGasto(int ClasificacionGenericaGastoId)
        {
            return Json(clasificacionGenericaGastoBL.BuscarClasificacionGenericaGastoID(ClasificacionGenericaGastoId));
        }

        public ActionResult ActualizarClasificacionGenericaGasto(int ClasificacionGenericaGastoId, string Clasificacion, string Descripcion)
        {
            ClasificacionGenericaGastoDTO clasificacionGenericaGastoDTO = new();
            clasificacionGenericaGastoDTO.ClasificacionGenericaGastoId = ClasificacionGenericaGastoId;
            clasificacionGenericaGastoDTO.DescClasificacionGenericaGasto = Descripcion;
            clasificacionGenericaGastoDTO.ClasificacionGenericaGasto = Clasificacion;
            clasificacionGenericaGastoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = clasificacionGenericaGastoBL.ActualizarClasificacionGenericaGasto(clasificacionGenericaGastoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClasificacionGenericaGasto(int ClasificacionGenericaGastoId)
        {
            ClasificacionGenericaGastoDTO clasificacionGenericaGastoDTO = new();
            clasificacionGenericaGastoDTO.ClasificacionGenericaGastoId = ClasificacionGenericaGastoId;
            clasificacionGenericaGastoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = clasificacionGenericaGastoBL.EliminarClasificacionGenericaGasto(clasificacionGenericaGastoDTO);

            return Content(IND_OPERACION);
        }
    }
}
