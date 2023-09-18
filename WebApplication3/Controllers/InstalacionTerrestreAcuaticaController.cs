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
    public class InstalacionTerrestreAcuaticaController : Controller
    {
        readonly ILogger<InstalacionTerrestreAcuaticaController> _logger;

        public InstalacionTerrestreAcuaticaController(ILogger<InstalacionTerrestreAcuaticaController> logger)
        {
            _logger = logger;
        }

        readonly InstalacionTerrestreAcuatica instalacionTerrestreAcuaticaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Instalaciones Terrestres Acuáticas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<InstalacionTerrestreAcuaticaDTO> listaInstalacionTerrestreAcuaticas = instalacionTerrestreAcuaticaBL.ObtenerInstalacionTerrestreAcuaticas();
            return Json(new { data = listaInstalacionTerrestreAcuaticas });
        }

        public ActionResult InsertarInstalacionTerrestreAcuatica(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                InstalacionTerrestreAcuaticaDTO instalacionTerrestreAcuaticaDTO = new();
                instalacionTerrestreAcuaticaDTO.DescInstalacionTerrestreAcuatica = Descripcion;
                instalacionTerrestreAcuaticaDTO.CodigoInstalacionTerrestreAcuatica = Codigo;
                instalacionTerrestreAcuaticaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = instalacionTerrestreAcuaticaBL.AgregarInstalacionTerrestreAcuatica(instalacionTerrestreAcuaticaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarInstalacionTerrestreAcuatica(int InstalacionTerrestreAcuaticaId)
        {
            return Json(instalacionTerrestreAcuaticaBL.BuscarInstalacionTerrestreAcuaticaID(InstalacionTerrestreAcuaticaId));
        }

        public ActionResult ActualizarInstalacionTerrestreAcuatica(int InstalacionTerrestreAcuaticaId, string Codigo, string Descripcion)
        {
            InstalacionTerrestreAcuaticaDTO instalacionTerrestreAcuaticaDTO = new();
            instalacionTerrestreAcuaticaDTO.InstalacionTerrestreAcuaticaId = InstalacionTerrestreAcuaticaId;
            instalacionTerrestreAcuaticaDTO.DescInstalacionTerrestreAcuatica = Descripcion;
            instalacionTerrestreAcuaticaDTO.CodigoInstalacionTerrestreAcuatica = Codigo;
            instalacionTerrestreAcuaticaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = instalacionTerrestreAcuaticaBL.ActualizarInstalacionTerrestreAcuatica(instalacionTerrestreAcuaticaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarInstalacionTerrestreAcuatica(int InstalacionTerrestreAcuaticaId)
        {
            InstalacionTerrestreAcuaticaDTO instalacionTerrestreAcuaticaDTO = new();
            instalacionTerrestreAcuaticaDTO.InstalacionTerrestreAcuaticaId = InstalacionTerrestreAcuaticaId;
            instalacionTerrestreAcuaticaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = instalacionTerrestreAcuaticaBL.EliminarInstalacionTerrestreAcuatica(instalacionTerrestreAcuaticaDTO);

            return Content(IND_OPERACION);
        }
    }
}
