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
    public class TipoCartaController : Controller
    {
        readonly ILogger<TipoCartaController> _logger;

        public TipoCartaController(ILogger<TipoCartaController> logger)
        {
            _logger = logger;
        }

        readonly TipoCartaDAO TipoCartaBL = new();

        [Breadcrumb(FromAction = "Index", Title = "Tipos Cartas", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoCartaDTO> listaTipoCartas = TipoCartaBL.ObtenerTipoCartas();
            return Json(new { data = listaTipoCartas });
        }

        public ActionResult InsertarTipoCarta(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                TipoCartaDTO TipoCartaDTO = new();
                TipoCartaDTO.DescTipoCarta = Descripcion;
                TipoCartaDTO.CodigoTipoCarta = Codigo;
                TipoCartaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = TipoCartaBL.AgregarTipoCarta(TipoCartaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoCarta(int TipoCartaId)
        {
            return Json(TipoCartaBL.BuscarTipoCartaID(TipoCartaId));
        }

        public ActionResult ActualizarTipoCarta(int TipoCartaId, string Codigo, string Descripcion)
        {
            TipoCartaDTO TipoCartaDTO = new();
            TipoCartaDTO.TipoCartaId = TipoCartaId;
            TipoCartaDTO.DescTipoCarta = Descripcion;
            TipoCartaDTO.CodigoTipoCarta = Codigo;
            TipoCartaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoCartaBL.ActualizarTipoCarta(TipoCartaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoCarta(int TipoCartaId)
        {
            TipoCartaDTO TipoCartaDTO = new();
            TipoCartaDTO.TipoCartaId = TipoCartaId;
            TipoCartaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoCartaBL.EliminarTipoCarta(TipoCartaDTO);

            return Content(IND_OPERACION);
        }
    }
}
