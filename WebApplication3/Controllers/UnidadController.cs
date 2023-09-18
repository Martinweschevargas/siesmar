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
    public class UnidadController : Controller
    {
        readonly ILogger<UnidadController> _logger;

        public UnidadController(ILogger<UnidadController> logger)
        {
            _logger = logger;
        }

        readonly UnidadDAO unidadBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Unidades", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<UnidadDTO> listaUnidads = unidadBL.ObtenerUnidads();
            return Json(new { data = listaUnidads });
        }

        public ActionResult InsertarUnidad(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                UnidadDTO unidadDTO = new();
                unidadDTO.DescUnidad = Descripcion;
                unidadDTO.CodigoUnidad = Codigo;
                unidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = unidadBL.AgregarUnidad(unidadDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarUnidad(int UnidadId)
        {
            return Json(unidadBL.BuscarUnidadID(UnidadId));
        }

        public ActionResult ActualizarUnidad(int UnidadId, string Codigo, string Descripcion)
        {
            UnidadDTO unidadDTO = new();
            unidadDTO.UnidadId = UnidadId;
            unidadDTO.DescUnidad = Descripcion;
            unidadDTO.CodigoUnidad = Codigo;
            unidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadBL.ActualizarUnidad(unidadDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarUnidad(int UnidadId)
        {
            UnidadDTO unidadDTO = new();
            unidadDTO.UnidadId = UnidadId;
            unidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadBL.EliminarUnidad(unidadDTO);

            return Content(IND_OPERACION);
        }
    }
}
