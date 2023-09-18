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
    public class CondicionEgresoHospitalizacionController : Controller
    {
        readonly ILogger<CondicionEgresoHospitalizacionController> _logger;

        public CondicionEgresoHospitalizacionController(ILogger<CondicionEgresoHospitalizacionController> logger)
        {
            _logger = logger;
        }

        readonly CondicionEgresoHospitalizacion condicionEgresoHospitalizacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Condiciones Egresos Hospitalizaciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CondicionEgresoHospitalizacionDTO> listaCondicionEgresoHospitalizacions = condicionEgresoHospitalizacionBL.ObtenerCondicionEgresoHospitalizacions();
            return Json(new { data = listaCondicionEgresoHospitalizacions });
        }

        public ActionResult InsertarCondicionEgresoHospitalizacion(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CondicionEgresoHospitalizacionDTO condicionEgresoHospitalizacionDTO = new();
                condicionEgresoHospitalizacionDTO.DescCondicionEgresoHospitalizacion = Descripcion;
                condicionEgresoHospitalizacionDTO.CodigoCondicionEgresoHospitalizacion = Codigo;
                condicionEgresoHospitalizacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = condicionEgresoHospitalizacionBL.AgregarCondicionEgresoHospitalizacion(condicionEgresoHospitalizacionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCondicionEgresoHospitalizacion(int CondicionEgresoHospitalizacionId)
        {
            return Json(condicionEgresoHospitalizacionBL.BuscarCondicionEgresoHospitalizacionID(CondicionEgresoHospitalizacionId));
        }

        public ActionResult ActualizarCondicionEgresoHospitalizacion(int CondicionEgresoHospitalizacionId, string Codigo, string Descripcion)
        {
            CondicionEgresoHospitalizacionDTO condicionEgresoHospitalizacionDTO = new();
            condicionEgresoHospitalizacionDTO.CondicionEgresoHospitalizacionId = CondicionEgresoHospitalizacionId;
            condicionEgresoHospitalizacionDTO.DescCondicionEgresoHospitalizacion = Descripcion;
            condicionEgresoHospitalizacionDTO.CodigoCondicionEgresoHospitalizacion = Codigo;
            condicionEgresoHospitalizacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = condicionEgresoHospitalizacionBL.ActualizarCondicionEgresoHospitalizacion(condicionEgresoHospitalizacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCondicionEgresoHospitalizacion(int CondicionEgresoHospitalizacionId)
        {
            CondicionEgresoHospitalizacionDTO condicionEgresoHospitalizacionDTO = new();
            condicionEgresoHospitalizacionDTO.CondicionEgresoHospitalizacionId = CondicionEgresoHospitalizacionId;
            condicionEgresoHospitalizacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = condicionEgresoHospitalizacionBL.EliminarCondicionEgresoHospitalizacion(condicionEgresoHospitalizacionDTO);

            return Content(IND_OPERACION);
        }
    }
}
