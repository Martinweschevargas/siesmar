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
    public class TipoActividadEmpresaController : Controller
    {
        readonly ILogger<TipoActividadEmpresaController> _logger;

        public TipoActividadEmpresaController(ILogger<TipoActividadEmpresaController> logger)
        {
            _logger = logger;
        }

        readonly TipoActividadEmpresaDAO tipoActividadEmpresaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Actividades Empresas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoActividadEmpresaDTO> listaTipoActividadEmpresas = tipoActividadEmpresaBL.ObtenerTipoActividadEmpresas();
            return Json(new { data = listaTipoActividadEmpresas });
        }

        public ActionResult InsertarTipoActividadEmpresa(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoActividadEmpresaDTO tipoActividadEmpresaDTO = new();
                tipoActividadEmpresaDTO.DescTipoActividadEmpresa = Descripcion;
                tipoActividadEmpresaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoActividadEmpresaBL.AgregarTipoActividadEmpresa(tipoActividadEmpresaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoActividadEmpresa(int TipoActividadEmpresaId)
        {
            return Json(tipoActividadEmpresaBL.BuscarTipoActividadEmpresaID(TipoActividadEmpresaId));
        }

        public ActionResult ActualizarTipoActividadEmpresa(int TipoActividadEmpresaId, string Descripcion)
        {
            TipoActividadEmpresaDTO tipoActividadEmpresaDTO = new();
            tipoActividadEmpresaDTO.TipoActividadEmpresaId = TipoActividadEmpresaId;
            tipoActividadEmpresaDTO.DescTipoActividadEmpresa = Descripcion;
            tipoActividadEmpresaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoActividadEmpresaBL.ActualizarTipoActividadEmpresa(tipoActividadEmpresaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoActividadEmpresa(int TipoActividadEmpresaId)
        {
            TipoActividadEmpresaDTO tipoActividadEmpresaDTO = new();
            tipoActividadEmpresaDTO.TipoActividadEmpresaId = TipoActividadEmpresaId;
            tipoActividadEmpresaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoActividadEmpresaBL.EliminarTipoActividadEmpresa(tipoActividadEmpresaDTO);

            return Content(IND_OPERACION);
        }
    }
}
