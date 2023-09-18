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
    public class TipoDesplazamientoController : Controller
    {
        readonly ILogger<TipoDesplazamientoController> _logger;

        public TipoDesplazamientoController(ILogger<TipoDesplazamientoController> logger)
        {
            _logger = logger;
        }

        readonly TipoDesplazamientoDAO tipoDesplazamientoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Desplazamientos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoDesplazamientoDTO> listaTipoDesplazamientos = tipoDesplazamientoBL.ObtenerTipoDesplazamientos();
            return Json(new { data = listaTipoDesplazamientos });
        }

        public ActionResult InsertarTipoDesplazamiento(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoDesplazamientoDTO tipoDesplazamientoDTO = new();
                tipoDesplazamientoDTO.DescTipoDesplazamiento = Descripcion;
                tipoDesplazamientoDTO.CodigoTipoDesplazamiento = Codigo;
                tipoDesplazamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoDesplazamientoBL.AgregarTipoDesplazamiento(tipoDesplazamientoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoDesplazamiento(int TipoDesplazamientoId)
        {
            return Json(tipoDesplazamientoBL.BuscarTipoDesplazamientoID(TipoDesplazamientoId));
        }

        public ActionResult ActualizarTipoDesplazamiento(int TipoDesplazamientoId, string Codigo, string Descripcion)
        {
            TipoDesplazamientoDTO tipoDesplazamientoDTO = new();
            tipoDesplazamientoDTO.TipoDesplazamientoId = TipoDesplazamientoId;
            tipoDesplazamientoDTO.DescTipoDesplazamiento = Descripcion;
            tipoDesplazamientoDTO.CodigoTipoDesplazamiento = Codigo;
            tipoDesplazamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoDesplazamientoBL.ActualizarTipoDesplazamiento(tipoDesplazamientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoDesplazamiento(int TipoDesplazamientoId)
        {
            TipoDesplazamientoDTO tipoDesplazamientoDTO = new();
            tipoDesplazamientoDTO.TipoDesplazamientoId = TipoDesplazamientoId;
            tipoDesplazamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoDesplazamientoBL.EliminarTipoDesplazamiento(tipoDesplazamientoDTO);

            return Content(IND_OPERACION);
        }
    }
}
