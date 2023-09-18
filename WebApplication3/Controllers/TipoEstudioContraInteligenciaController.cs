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
    public class TipoEstudioContraInteligenciaController : Controller
    {
        readonly ILogger<TipoEstudioContraInteligenciaController> _logger;

        public TipoEstudioContraInteligenciaController(ILogger<TipoEstudioContraInteligenciaController> logger)
        {
            _logger = logger;
        }

        readonly TipoEstudioContraInteligenciaDAO tipoEstudioContraInteligenciaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Estudios Contra Inteligencias", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoEstudioContraInteligenciaDTO> listaTipoEstudioContraInteligencias = tipoEstudioContraInteligenciaBL.ObtenerTipoEstudioContraInteligencias();
            return Json(new { data = listaTipoEstudioContraInteligencias });
        }

        public ActionResult InsertarTipoEstudioContraInteligencia(string DescTipoEstudioContrainteligencia, string CodigoTipoEstudioContrainteligencia)
        {
            var IND_OPERACION="";
            try
            {
                TipoEstudioContraInteligenciaDTO tipoEstudioContraInteligenciaDTO = new();
                tipoEstudioContraInteligenciaDTO.DescTipoEstudioContrainteligencia = DescTipoEstudioContrainteligencia;
                tipoEstudioContraInteligenciaDTO.CodigoTipoEstudioContrainteligencia = CodigoTipoEstudioContrainteligencia;
                tipoEstudioContraInteligenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoEstudioContraInteligenciaBL.AgregarTipoEstudioContraInteligencia(tipoEstudioContraInteligenciaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoEstudioContraInteligencia(int TipoEstudioContraInteligenciaId)
        {
            return Json(tipoEstudioContraInteligenciaBL.BuscarTipoEstudioContraInteligenciaID(TipoEstudioContraInteligenciaId));
        }

        public ActionResult ActualizarTipoEstudioContraInteligencia(int TipoEstudioContrainteligenciaId, string DescTipoEstudioContrainteligencia, string CodigoTipoEstudioContrainteligencia)
        {
            TipoEstudioContraInteligenciaDTO tipoEstudioContraInteligenciaDTO = new();
            tipoEstudioContraInteligenciaDTO.TipoEstudioContrainteligenciaId = TipoEstudioContrainteligenciaId;
            tipoEstudioContraInteligenciaDTO.DescTipoEstudioContrainteligencia = DescTipoEstudioContrainteligencia;
            tipoEstudioContraInteligenciaDTO.CodigoTipoEstudioContrainteligencia = CodigoTipoEstudioContrainteligencia;
            tipoEstudioContraInteligenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoEstudioContraInteligenciaBL.ActualizarTipoEstudioContraInteligencia(tipoEstudioContraInteligenciaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoEstudioContraInteligencia(int TipoEstudioContrainteligenciaId)
        {
            TipoEstudioContraInteligenciaDTO tipoEstudioContraInteligenciaDTO = new();
            tipoEstudioContraInteligenciaDTO.TipoEstudioContrainteligenciaId = TipoEstudioContrainteligenciaId;
            tipoEstudioContraInteligenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoEstudioContraInteligenciaBL.EliminarTipoEstudioContraInteligencia(tipoEstudioContraInteligenciaDTO);

            return Content(IND_OPERACION);
        }
    }
}
