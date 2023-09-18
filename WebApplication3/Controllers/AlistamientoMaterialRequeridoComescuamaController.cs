using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class AlistamientoMaterialRequeridoComescuamaController : Controller
    {
        readonly ILogger<AlistamientoMaterialRequeridoComescuamaController> _logger;

        public AlistamientoMaterialRequeridoComescuamaController(ILogger<AlistamientoMaterialRequeridoComescuamaController> logger)
        {
            _logger = logger;
        }

        readonly AlistamientoMaterialRequeridoComescuama alistamientoMaterialRequeridoComescuamaBL = new();

        AlistamientoMaterialRequerido3N alistamientoMaterialRequerido3NBL = new();

        [Breadcrumb(FromAction = "Index", Title = "Alistamientos Materiales Requeridos Comescuama", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<AlistamientoMaterialRequerido3NDTO> alistamientoMaterialRequerido3NDTO = alistamientoMaterialRequerido3NBL.ObtenerAlistamientoMaterialRequerido3Ns();

            return Json(new { data = alistamientoMaterialRequerido3NDTO });
        }

        public JsonResult CargarDatos()
        {
            List<AlistamientoMaterialRequeridoComescuamaDTO> listaAlistamientoMaterialRequeridoComescuamaes = alistamientoMaterialRequeridoComescuamaBL.ObtenerAlistamientoMaterialRequeridoComescuamas();
            return Json(new { data = listaAlistamientoMaterialRequeridoComescuamaes });
        }

        public ActionResult InsertarAlistamientoMaterialRequeridoComescuama(string CodigoAlistamientoMaterialRequeridoComescuama, int AlistamientoMaterialRequerido3NId, 
            string Requerido, string Operativo, string PorcentajeOperatividad)
        {
            var IND_OPERACION = "";
            try
            {
                AlistamientoMaterialRequeridoComescuamaDTO alistamientoMaterialRequeridoComescuamaDTO = new();
                alistamientoMaterialRequeridoComescuamaDTO.CodigoAlistamientoMaterialRequeridoComescuama = CodigoAlistamientoMaterialRequeridoComescuama;
                alistamientoMaterialRequeridoComescuamaDTO.AlistamientoMaterialRequerido3NId = AlistamientoMaterialRequerido3NId;
                alistamientoMaterialRequeridoComescuamaDTO.Requerido = Requerido;
                alistamientoMaterialRequeridoComescuamaDTO.Operativo = Operativo;
                alistamientoMaterialRequeridoComescuamaDTO.PorcentajeOperatividad = PorcentajeOperatividad;
                alistamientoMaterialRequeridoComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = alistamientoMaterialRequeridoComescuamaBL.AgregarAlistamientoMaterialRequeridoComescuama(alistamientoMaterialRequeridoComescuamaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAlistamientoMaterialRequeridoComescuama(int AlistamientoMaterialRequeridoComescuamaId)
        {
            return Json(alistamientoMaterialRequeridoComescuamaBL.BuscarAlistamientoMaterialRequeridoComescuamaID(AlistamientoMaterialRequeridoComescuamaId));
        }

        public ActionResult ActualizarAlistamientoMaterialRequeridoComescuama(int AlistamientoMaterialRequeridoComescuamaId, string CodigoAlistamientoMaterialRequeridoComescuama, 
            int AlistamientoMaterialRequerido3NId, string Requerido, string Operativo, string PorcentajeOperatividad)
        {
            AlistamientoMaterialRequeridoComescuamaDTO alistamientoMaterialRequeridoComescuamaDTO = new();
            alistamientoMaterialRequeridoComescuamaDTO.AlistamientoMaterialRequeridoComescuamaId = AlistamientoMaterialRequeridoComescuamaId;
            alistamientoMaterialRequeridoComescuamaDTO.CodigoAlistamientoMaterialRequeridoComescuama = CodigoAlistamientoMaterialRequeridoComescuama;
            alistamientoMaterialRequeridoComescuamaDTO.AlistamientoMaterialRequerido3NId = AlistamientoMaterialRequerido3NId;
            alistamientoMaterialRequeridoComescuamaDTO.Requerido = Requerido;
            alistamientoMaterialRequeridoComescuamaDTO.Operativo = Operativo;
            alistamientoMaterialRequeridoComescuamaDTO.PorcentajeOperatividad = PorcentajeOperatividad;
            alistamientoMaterialRequeridoComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialRequeridoComescuamaBL.ActualizarAlistamientoMaterialRequeridoComescuama(alistamientoMaterialRequeridoComescuamaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAlistamientoMaterialRequeridoComescuama(int AlistamientoMaterialRequeridoComescuamaId)
        {
            AlistamientoMaterialRequeridoComescuamaDTO alistamientoMaterialRequeridoComescuamaDTO = new();
            alistamientoMaterialRequeridoComescuamaDTO.AlistamientoMaterialRequeridoComescuamaId = AlistamientoMaterialRequeridoComescuamaId;
            alistamientoMaterialRequeridoComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialRequeridoComescuamaBL.EliminarAlistamientoMaterialRequeridoComescuama(alistamientoMaterialRequeridoComescuamaDTO);

            return Content(IND_OPERACION);
        }
    }
}
