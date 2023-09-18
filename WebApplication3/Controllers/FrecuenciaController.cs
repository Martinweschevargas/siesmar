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
    public class FrecuenciaController : Controller
    {
        readonly ILogger<FrecuenciaController> _logger;

        public FrecuenciaController(ILogger<FrecuenciaController> logger)
        {
            _logger = logger;
        }

        readonly FrecuenciaDAO frecuenciaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Frecuencias", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<FrecuenciaDTO> listaFrecuencias = frecuenciaBL.ObtenerFrecuencias();
            return Json(new { data = listaFrecuencias });
        }

        public ActionResult InsertarFrecuencia(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                FrecuenciaDTO frecuenciaDTO = new();
                frecuenciaDTO.DescFrecuencia = Descripcion;
                frecuenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = frecuenciaBL.AgregarFrecuencia(frecuenciaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarFrecuencia(int FrecuenciaId)
        {
            return Json(frecuenciaBL.BuscarFrecuenciaID(FrecuenciaId));
        }

        public ActionResult ActualizarFrecuencia(int FrecuenciaId, string Descripcion)
        {
            FrecuenciaDTO frecuenciaDTO = new();
            frecuenciaDTO.FrecuenciaId = FrecuenciaId;
            frecuenciaDTO.DescFrecuencia = Descripcion;
            frecuenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = frecuenciaBL.ActualizarFrecuencia(frecuenciaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarFrecuencia(int FrecuenciaId)
        {
            FrecuenciaDTO frecuenciaDTO = new();
            frecuenciaDTO.FrecuenciaId = FrecuenciaId;
            frecuenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = frecuenciaBL.EliminarFrecuencia(frecuenciaDTO);

            return Content(IND_OPERACION);
        }
    }
}
