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
    public class NivelDependenciaController : Controller
    {
        readonly ILogger<NivelDependenciaController> _logger;

        public NivelDependenciaController(ILogger<NivelDependenciaController> logger)
        {
            _logger = logger;
        }

        readonly NivelDependenciaDAO nivelDependenciaBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Niveles Dependencias", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<NivelDependenciaDTO> listaNivelDependencias = nivelDependenciaBL.ObtenerNivelDependencias();
            return Json(new { data = listaNivelDependencias });
        }

        public ActionResult InsertarNivelDependencia(string DescNivelDependencia, string CodigoNivelDependencia)
        {
            var IND_OPERACION="";
            try
            {
                NivelDependenciaDTO nivelDependenciaDTO = new();
                nivelDependenciaDTO.DescNivelDependencia = DescNivelDependencia;
                nivelDependenciaDTO.CodigoNivelDependencia = CodigoNivelDependencia;
                nivelDependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = nivelDependenciaBL.AgregarNivelDependencia(nivelDependenciaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarNivelDependencia(int NivelDependenciaId)
        {
            return Json(nivelDependenciaBL.BuscarNivelDependenciaID(NivelDependenciaId));
        }

        public ActionResult ActualizarNivelDependencia(int NivelDependenciaId, string DescNivelDependencia, string CodigoNivelDependencia)
        {
            NivelDependenciaDTO nivelDependenciaDTO = new();
            nivelDependenciaDTO.NivelDependenciaId = NivelDependenciaId;
            nivelDependenciaDTO.DescNivelDependencia = DescNivelDependencia;
            nivelDependenciaDTO.CodigoNivelDependencia = CodigoNivelDependencia;
            nivelDependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = nivelDependenciaBL.ActualizarNivelDependencia(nivelDependenciaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarNivelDependencia(int NivelDependenciaId)
        {
            NivelDependenciaDTO nivelDependenciaDTO = new();
            nivelDependenciaDTO.NivelDependenciaId = NivelDependenciaId;
            nivelDependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = nivelDependenciaBL.EliminarNivelDependencia(nivelDependenciaDTO);

            return Content(IND_OPERACION);
        }
    }
}
