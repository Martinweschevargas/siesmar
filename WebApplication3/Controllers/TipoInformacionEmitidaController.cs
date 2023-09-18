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
    public class TipoInformacionEmitidaController : Controller
    {
        readonly ILogger<TipoInformacionEmitidaController> _logger;

        public TipoInformacionEmitidaController(ILogger<TipoInformacionEmitidaController> logger)
        {
            _logger = logger;
        }

        readonly TipoInformacionEmitidaDAO tipoInformacionEmitidaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Informaciones Emitidas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoInformacionEmitidaDTO> listaTipoInformacionEmitidas = tipoInformacionEmitidaBL.ObtenerTipoInformacionEmitidas();
            return Json(new { data = listaTipoInformacionEmitidas });
        }

        public ActionResult InsertarTipoInformacionEmitida(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoInformacionEmitidaDTO tipoInformacionEmitidaDTO = new();
                tipoInformacionEmitidaDTO.DescTipoInformacionEmitida = Descripcion;
                tipoInformacionEmitidaDTO.CodigoTipoInformacionEmitida = Codigo;
                tipoInformacionEmitidaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoInformacionEmitidaBL.AgregarTipoInformacionEmitida(tipoInformacionEmitidaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoInformacionEmitida(int TipoInformacionEmitidaId)
        {
            return Json(tipoInformacionEmitidaBL.BuscarTipoInformacionEmitidaID(TipoInformacionEmitidaId));
        }

        public ActionResult ActualizarTipoInformacionEmitida(int TipoInformacionEmitidaId, string Codigo, string Descripcion)
        {
            TipoInformacionEmitidaDTO tipoInformacionEmitidaDTO = new();
            tipoInformacionEmitidaDTO.TipoInformacionEmitidaId = TipoInformacionEmitidaId;
            tipoInformacionEmitidaDTO.DescTipoInformacionEmitida = Descripcion;
            tipoInformacionEmitidaDTO.CodigoTipoInformacionEmitida = Codigo;
            tipoInformacionEmitidaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoInformacionEmitidaBL.ActualizarTipoInformacionEmitida(tipoInformacionEmitidaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoInformacionEmitida(int TipoInformacionEmitidaId)
        {
            TipoInformacionEmitidaDTO tipoInformacionEmitidaDTO = new();
            tipoInformacionEmitidaDTO.TipoInformacionEmitidaId = TipoInformacionEmitidaId;
            tipoInformacionEmitidaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoInformacionEmitidaBL.EliminarTipoInformacionEmitida(tipoInformacionEmitidaDTO);

            return Content(IND_OPERACION);
        }
    }
}
