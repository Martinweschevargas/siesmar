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
    public class EspecialidadGenericaController : Controller
    {
        readonly ILogger<EspecialidadGenericaController> _logger;

        public EspecialidadGenericaController(ILogger<EspecialidadGenericaController> logger)
        {
            _logger = logger;
        }

        readonly EspecialidadGenericaDAO EspecialidadGenericaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Especialidades Genericas", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EspecialidadGenericaDTO> listaEspecialidadGenericas = EspecialidadGenericaBL.ObtenerEspecialidadGenericas();
            return Json(new { data = listaEspecialidadGenericas });
        }

        public ActionResult InsertarEspecialidadGenerica(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                EspecialidadGenericaDTO EspecialidadGenericaDTO = new();
                EspecialidadGenericaDTO.DescEspecialidadGenerica = Descripcion;
                EspecialidadGenericaDTO.CodigoEspecialidadGenerica = Codigo;
                EspecialidadGenericaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = EspecialidadGenericaBL.AgregarEspecialidadGenerica(EspecialidadGenericaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEspecialidadGenerica(int EspecialidadGenericaId)
        {
            return Json(EspecialidadGenericaBL.BuscarEspecialidadGenericaID(EspecialidadGenericaId));
        }

        public ActionResult ActualizarEspecialidadGenerica(int EspecialidadGenericaId, string Codigo, string Descripcion)
        {
            EspecialidadGenericaDTO EspecialidadGenericaDTO = new();
            EspecialidadGenericaDTO.EspecialidadGenericaId = EspecialidadGenericaId;
            EspecialidadGenericaDTO.DescEspecialidadGenerica = Descripcion;
            EspecialidadGenericaDTO.CodigoEspecialidadGenerica = Codigo;
            EspecialidadGenericaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = EspecialidadGenericaBL.ActualizarEspecialidadGenerica(EspecialidadGenericaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEspecialidadGenerica(int EspecialidadGenericaId)
        {
            EspecialidadGenericaDTO EspecialidadGenericaDTO = new();
            EspecialidadGenericaDTO.EspecialidadGenericaId = EspecialidadGenericaId;
            EspecialidadGenericaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = EspecialidadGenericaBL.EliminarEspecialidadGenerica(EspecialidadGenericaDTO);

            return Content(IND_OPERACION);
        }
    }
}
