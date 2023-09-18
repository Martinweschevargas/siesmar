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
    public class TipoVinculoController : Controller
    {
        readonly ILogger<TipoVinculoController> _logger;

        public TipoVinculoController(ILogger<TipoVinculoController> logger)
        {
            _logger = logger;
        }

        readonly TipoVinculoDAO tipoVinculoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Vinculos", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoVinculoDTO> listaTipoVinculos = tipoVinculoBL.ObtenerTipoVinculos();
            return Json(new { data = listaTipoVinculos });
        }

        public ActionResult InsertarTipoVinculo(string DescTipoVinculo, string CodigoTipoVinculo)
        {
            var IND_OPERACION="";
            try
            {
                TipoVinculoDTO tipoVinculoDTO = new();
                tipoVinculoDTO.DescTipoVinculo = DescTipoVinculo;
                tipoVinculoDTO.CodigoTipoVinculo = CodigoTipoVinculo;
                tipoVinculoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoVinculoBL.AgregarTipoVinculo(tipoVinculoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoVinculo(int TipoVinculoId)
        {
            return Json(tipoVinculoBL.BuscarTipoVinculoID(TipoVinculoId));
        }

        public ActionResult ActualizarTipoVinculo(int TipoVinculoId, string DescTipoVinculo, string CodigoTipoVinculo)
        {
            TipoVinculoDTO tipoVinculoDTO = new();
            tipoVinculoDTO.TipoVinculoId = TipoVinculoId;
            tipoVinculoDTO.DescTipoVinculo = DescTipoVinculo;
            tipoVinculoDTO.CodigoTipoVinculo = CodigoTipoVinculo;
            tipoVinculoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoVinculoBL.ActualizarTipoVinculo(tipoVinculoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoVinculo(int TipoVinculoId)
        {
            TipoVinculoDTO tipoVinculoDTO = new();
            tipoVinculoDTO.TipoVinculoId = TipoVinculoId;
            tipoVinculoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoVinculoBL.EliminarTipoVinculo(tipoVinculoDTO);

            return Content(IND_OPERACION);
        }
    }
}
