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
    public class FrecuenciaDifusionController : Controller
    {
        readonly ILogger<FrecuenciaDifusionController> _logger;

        public FrecuenciaDifusionController(ILogger<FrecuenciaDifusionController> logger)
        {
            _logger = logger;
        }

        readonly FrecuenciaDifusionDAO frecuenciaDifusionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Frecuencias Difusiones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<FrecuenciaDifusionDTO> listaFrecuenciaDifusions = frecuenciaDifusionBL.ObtenerFrecuenciaDifusions();
            return Json(new { data = listaFrecuenciaDifusions });
        }

        public ActionResult InsertarFrecuenciaDifusion(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                FrecuenciaDifusionDTO frecuenciaDifusionDTO = new();
                frecuenciaDifusionDTO.DescFrecuenciaDifusion = Descripcion;
                frecuenciaDifusionDTO.CodigoFrecuenciaDifusion = Codigo;
                frecuenciaDifusionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = frecuenciaDifusionBL.AgregarFrecuenciaDifusion(frecuenciaDifusionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarFrecuenciaDifusion(int FrecuenciaDifusionId)
        {
            return Json(frecuenciaDifusionBL.BuscarFrecuenciaDifusionID(FrecuenciaDifusionId));
        }

        public ActionResult ActualizarFrecuenciaDifusion(int FrecuenciaDifusionId, string Codigo, string Descripcion)
        {
            FrecuenciaDifusionDTO frecuenciaDifusionDTO = new();
            frecuenciaDifusionDTO.FrecuenciaDifusionId = FrecuenciaDifusionId;
            frecuenciaDifusionDTO.DescFrecuenciaDifusion = Descripcion;
            frecuenciaDifusionDTO.CodigoFrecuenciaDifusion = Codigo;
            frecuenciaDifusionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = frecuenciaDifusionBL.ActualizarFrecuenciaDifusion(frecuenciaDifusionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarFrecuenciaDifusion(int FrecuenciaDifusionId)
        {
            FrecuenciaDifusionDTO frecuenciaDifusionDTO = new();
            frecuenciaDifusionDTO.FrecuenciaDifusionId = FrecuenciaDifusionId;
            frecuenciaDifusionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = frecuenciaDifusionBL.EliminarFrecuenciaDifusion(frecuenciaDifusionDTO);

            return Content(IND_OPERACION);
        }
    }
}
