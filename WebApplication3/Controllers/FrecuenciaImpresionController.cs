using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class FrecuenciaImpresionController : Controller
    {
        readonly ILogger<FrecuenciaImpresionController> _logger;

        public FrecuenciaImpresionController(ILogger<FrecuenciaImpresionController> logger)
        {
            _logger = logger;
        }

        readonly FrecuenciaImpresionDAO capitaniaBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Frecuencias Impresiones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<FrecuenciaImpresionDTO> listaFrecuenciaImpresions = capitaniaBL.ObtenerFrecuenciaImpresions();
            return Json(new { data = listaFrecuenciaImpresions });
        }

        public ActionResult InsertarFrecuenciaImpresion(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                FrecuenciaImpresionDTO capitaniaDTO = new();
                capitaniaDTO.DescFrecuenciaImpresion = Descripcion;
                capitaniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = capitaniaBL.AgregarFrecuenciaImpresion(capitaniaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarFrecuenciaImpresion(int FrecuenciaImpresionId)
        {
            return Json(capitaniaBL.BuscarFrecuenciaImpresionID(FrecuenciaImpresionId));
        }

        public ActionResult ActualizarFrecuenciaImpresion(int FrecuenciaImpresionId, string Descripcion)
        {
            FrecuenciaImpresionDTO capitaniaDTO = new();
            capitaniaDTO.FrecuenciaImpresionId = FrecuenciaImpresionId;
            capitaniaDTO.DescFrecuenciaImpresion = Descripcion;
            capitaniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capitaniaBL.ActualizarFrecuenciaImpresion(capitaniaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarFrecuenciaImpresion(int FrecuenciaImpresionId)
        {
            FrecuenciaImpresionDTO capitaniaDTO = new();
            capitaniaDTO.FrecuenciaImpresionId = FrecuenciaImpresionId;
            capitaniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capitaniaBL.EliminarFrecuenciaImpresion(capitaniaDTO);

            return Content(IND_OPERACION);
        }
    }
}
