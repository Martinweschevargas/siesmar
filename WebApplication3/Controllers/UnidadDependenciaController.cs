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
    public class UnidadDependenciaController : Controller
    {
        readonly ILogger<UnidadDependenciaController> _logger;

        public UnidadDependenciaController(ILogger<UnidadDependenciaController> logger)
        {
            _logger = logger;
        }

        readonly UnidadDependenciaDAO unidadDependenciaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Unidades Dependencias", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<UnidadDependenciaDTO> listaUnidadDependencias = unidadDependenciaBL.ObtenerUnidadDependencias();
            return Json(new { data = listaUnidadDependencias });
        }

        public ActionResult InsertarUnidadDependencia(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                UnidadDependenciaDTO unidadDependenciaDTO = new();
                unidadDependenciaDTO.DescUnidadDependencia = Descripcion;
                unidadDependenciaDTO.CodigoUnidadDependencia = Codigo;
                unidadDependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = unidadDependenciaBL.AgregarUnidadDependencia(unidadDependenciaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarUnidadDependencia(int UnidadDependenciaId)
        {
            return Json(unidadDependenciaBL.BuscarUnidadDependenciaID(UnidadDependenciaId));
        }

        public ActionResult ActualizarUnidadDependencia(int UnidadDependenciaId, string Codigo, string Descripcion)
        {
            UnidadDependenciaDTO unidadDependenciaDTO = new();
            unidadDependenciaDTO.UnidadDependenciaId = UnidadDependenciaId;
            unidadDependenciaDTO.DescUnidadDependencia = Descripcion;
            unidadDependenciaDTO.CodigoUnidadDependencia = Codigo;
            unidadDependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadDependenciaBL.ActualizarUnidadDependencia(unidadDependenciaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarUnidadDependencia(int UnidadDependenciaId)
        {
            UnidadDependenciaDTO unidadDependenciaDTO = new();
            unidadDependenciaDTO.UnidadDependenciaId = UnidadDependenciaId;
            unidadDependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadDependenciaBL.EliminarUnidadDependencia(unidadDependenciaDTO);

            return Content(IND_OPERACION);
        }
    }
}
