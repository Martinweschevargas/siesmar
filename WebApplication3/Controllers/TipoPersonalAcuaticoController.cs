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
    public class TipoPersonalAcuaticoController : Controller
    {
        readonly ILogger<TipoPersonalAcuaticoController> _logger;

        public TipoPersonalAcuaticoController(ILogger<TipoPersonalAcuaticoController> logger)
        {
            _logger = logger;
        }

        readonly TipoPersonalAcuaticoDAO tipoPersonalAcuaticoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Personales Acuáticos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoPersonalAcuaticoDTO> listaTipoPersonalAcuaticos = tipoPersonalAcuaticoBL.ObtenerTipoPersonalAcuaticos();
            return Json(new { data = listaTipoPersonalAcuaticos });
        }

        public ActionResult InsertarTipoPersonalAcuatico(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoPersonalAcuaticoDTO tipoPersonalAcuaticoDTO = new();
                tipoPersonalAcuaticoDTO.DescTipoPersonalAcuatico = Descripcion;
                tipoPersonalAcuaticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoPersonalAcuaticoBL.AgregarTipoPersonalAcuatico(tipoPersonalAcuaticoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoPersonalAcuatico(int TipoPersonalAcuaticoId)
        {
            return Json(tipoPersonalAcuaticoBL.BuscarTipoPersonalAcuaticoID(TipoPersonalAcuaticoId));
        }

        public ActionResult ActualizarTipoPersonalAcuatico(int TipoPersonalAcuaticoId, string Descripcion)
        {
            TipoPersonalAcuaticoDTO tipoPersonalAcuaticoDTO = new();
            tipoPersonalAcuaticoDTO.TipoPersonalAcuaticoId = TipoPersonalAcuaticoId;
            tipoPersonalAcuaticoDTO.DescTipoPersonalAcuatico = Descripcion;
            tipoPersonalAcuaticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoPersonalAcuaticoBL.ActualizarTipoPersonalAcuatico(tipoPersonalAcuaticoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoPersonalAcuatico(int TipoPersonalAcuaticoId)
        {
            TipoPersonalAcuaticoDTO tipoPersonalAcuaticoDTO = new();
            tipoPersonalAcuaticoDTO.TipoPersonalAcuaticoId = TipoPersonalAcuaticoId;
            tipoPersonalAcuaticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoPersonalAcuaticoBL.EliminarTipoPersonalAcuatico(tipoPersonalAcuaticoDTO);

            return Content(IND_OPERACION);
        }
    }
}
