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
    public class TipoContraInteligenciaController : Controller
    {
        readonly ILogger<TipoContraInteligenciaController> _logger;

        public TipoContraInteligenciaController(ILogger<TipoContraInteligenciaController> logger)
        {
            _logger = logger;
        }

        readonly TipoContraInteligenciaDAO tipoContraInteligenciaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Contra Inteligencias", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoContraInteligenciaDTO> listaTipoContraInteligencias = tipoContraInteligenciaBL.ObtenerTipoContraInteligencias();
            return Json(new { data = listaTipoContraInteligencias });
        }

        public ActionResult InsertarTipoContraInteligencia(string DescTipoContrainteligencia, string CodigoTipoContrainteligencia)
        {
            var IND_OPERACION="";
            try
            {
                TipoContraInteligenciaDTO tipoContraInteligenciaDTO = new();
                tipoContraInteligenciaDTO.DescTipoContrainteligencia = DescTipoContrainteligencia;
                tipoContraInteligenciaDTO.CodigoTipoContrainteligencia = CodigoTipoContrainteligencia;
                tipoContraInteligenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoContraInteligenciaBL.AgregarTipoContraInteligencia(tipoContraInteligenciaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoContraInteligencia(int TipoContraInteligenciaId)
        {
            return Json(tipoContraInteligenciaBL.BuscarTipoContraInteligenciaID(TipoContraInteligenciaId));
        }

        public ActionResult ActualizarTipoContraInteligencia(int TipoContrainteligenciaId, string DescTipoContrainteligencia, string CodigoTipoContrainteligencia)
        {
            TipoContraInteligenciaDTO tipoContraInteligenciaDTO = new();
            tipoContraInteligenciaDTO.TipoContrainteligenciaId = TipoContrainteligenciaId;
            tipoContraInteligenciaDTO.DescTipoContrainteligencia = DescTipoContrainteligencia;
            tipoContraInteligenciaDTO.CodigoTipoContrainteligencia = CodigoTipoContrainteligencia;
            tipoContraInteligenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoContraInteligenciaBL.ActualizarTipoContraInteligencia(tipoContraInteligenciaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoContraInteligencia(int TipoContrainteligenciaId)
        {
            TipoContraInteligenciaDTO tipoContraInteligenciaDTO = new();
            tipoContraInteligenciaDTO.TipoContrainteligenciaId = TipoContrainteligenciaId;
            tipoContraInteligenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoContraInteligenciaBL.EliminarTipoContraInteligencia(tipoContraInteligenciaDTO);

            return Content(IND_OPERACION);
        }
    }
}
