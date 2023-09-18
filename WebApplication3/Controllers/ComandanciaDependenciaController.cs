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
    public class ComandanciaDependenciaController : Controller
    {
        readonly ILogger<ComandanciaDependenciaController> _logger;

        public ComandanciaDependenciaController(ILogger<ComandanciaDependenciaController> logger)
        {
            _logger = logger;
        }

        readonly ComandanciaDependenciaDAO comandanciaDependenciaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Comandancia Dependencias", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ComandanciaDependenciaDTO> listaComandanciaDependencias = comandanciaDependenciaBL.ObtenerComandanciaDependencias();
            return Json(new { data = listaComandanciaDependencias });
        }

        public ActionResult InsertarComandanciaDependencia(string DescComandanciaDependencia, string CodigoComandanciaDependencia)
        {
            var IND_OPERACION="";
            try
            {
                ComandanciaDependenciaDTO comandanciaDependenciaDTO = new();
                comandanciaDependenciaDTO.DescComandanciaDependencia = DescComandanciaDependencia;
                comandanciaDependenciaDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
                comandanciaDependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = comandanciaDependenciaBL.AgregarComandanciaDependencia(comandanciaDependenciaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarComandanciaDependencia(int ComandanciaDependenciaId)
        {
            return Json(comandanciaDependenciaBL.BuscarComandanciaDependenciaID(ComandanciaDependenciaId));
        }

        public ActionResult ActualizarComandanciaDependencia(int ComandanciaDependenciaId, string DescComandanciaDependencia, string CodigoComandanciaDependencia)
        {
            ComandanciaDependenciaDTO comandanciaDependenciaDTO = new();
            comandanciaDependenciaDTO.ComandanciaDependenciaId = ComandanciaDependenciaId;
            comandanciaDependenciaDTO.DescComandanciaDependencia = DescComandanciaDependencia;
            comandanciaDependenciaDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            comandanciaDependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = comandanciaDependenciaBL.ActualizarComandanciaDependencia(comandanciaDependenciaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarComandanciaDependencia(int ComandanciaDependenciaId)
        {
            ComandanciaDependenciaDTO comandanciaDependenciaDTO = new();
            comandanciaDependenciaDTO.ComandanciaDependenciaId = ComandanciaDependenciaId;
            comandanciaDependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = comandanciaDependenciaBL.EliminarComandanciaDependencia(comandanciaDependenciaDTO);

            return Content(IND_OPERACION);
        }
    }
}
