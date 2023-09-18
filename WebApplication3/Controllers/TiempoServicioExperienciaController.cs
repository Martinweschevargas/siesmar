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
    public class TiempoServicioExperienciaController : Controller
    {
        readonly ILogger<TiempoServicioExperienciaController> _logger;

        public TiempoServicioExperienciaController(ILogger<TiempoServicioExperienciaController> logger)
        {
            _logger = logger;
        }

        readonly TiempoServicioExperiencia tiempoServicioExperienciaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tiempos Servicios Experiencias", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TiempoServicioExperienciaDTO> listaTiempoServicioExperiencias = tiempoServicioExperienciaBL.ObtenerTiempoServicioExperiencias();
            return Json(new { data = listaTiempoServicioExperiencias });
        }

        public ActionResult InsertarTiempoServicioExperiencia(char BAPAmazonas, char BAPLoreto, char BAPMaranon, char BAPUcayali, char BAPClavero,
                                                              char BAPCastillo, char BAPMorona, char BAPCorrientes, char BAPPastaza, char Personal)
        {
            var IND_OPERACION = "";
            try
            {
                TiempoServicioExperienciaDTO tiempoServicioExperienciaDTO = new();
                tiempoServicioExperienciaDTO.BAPAmazonas = BAPAmazonas;
                tiempoServicioExperienciaDTO.BAPLoreto = BAPLoreto;
                tiempoServicioExperienciaDTO.BAPMaranon = BAPMaranon;
                tiempoServicioExperienciaDTO.BAPUcayali = BAPUcayali;
                tiempoServicioExperienciaDTO.BAPClavero = BAPClavero;
                tiempoServicioExperienciaDTO.BAPCastillo = BAPCastillo;
                tiempoServicioExperienciaDTO.BAPMorona = BAPMorona;
                tiempoServicioExperienciaDTO.BAPCorrientes = BAPCorrientes;
                tiempoServicioExperienciaDTO.BAPPastaza = BAPPastaza;
                tiempoServicioExperienciaDTO.Personal = Personal;
                tiempoServicioExperienciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tiempoServicioExperienciaBL.AgregarTiempoServicioExperiencia(tiempoServicioExperienciaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTiempoServicioExperiencia(int TiempoServicioExperienciaId)
        {
            return Json(tiempoServicioExperienciaBL.BuscarTiempoServicioExperienciaID(TiempoServicioExperienciaId));
        }

        public ActionResult ActualizarTiempoServicioExperiencia(int TiempoServicioExperienciaId, char BAPAmazonas, char BAPLoreto, char BAPMaranon, char BAPUcayali, char BAPClavero,
                                                              char BAPCastillo, char BAPMorona, char BAPCorrientes, char BAPPastaza, char Personal)
        {
            TiempoServicioExperienciaDTO tiempoServicioExperienciaDTO = new();
            tiempoServicioExperienciaDTO.TiempoServicioExperienciaId = TiempoServicioExperienciaId;
            tiempoServicioExperienciaDTO.BAPAmazonas = BAPAmazonas;
            tiempoServicioExperienciaDTO.BAPLoreto = BAPLoreto;
            tiempoServicioExperienciaDTO.BAPMaranon = BAPMaranon;
            tiempoServicioExperienciaDTO.BAPUcayali = BAPUcayali;
            tiempoServicioExperienciaDTO.BAPClavero = BAPClavero;
            tiempoServicioExperienciaDTO.BAPCastillo = BAPCastillo;
            tiempoServicioExperienciaDTO.BAPMorona = BAPMorona;
            tiempoServicioExperienciaDTO.BAPCorrientes = BAPCorrientes;
            tiempoServicioExperienciaDTO.BAPPastaza = BAPPastaza;
            tiempoServicioExperienciaDTO.Personal = Personal;
            tiempoServicioExperienciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tiempoServicioExperienciaBL.ActualizarTiempoServicioExperiencia(tiempoServicioExperienciaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTiempoServicioExperiencia(int TiempoServicioExperienciaId)
        {
            TiempoServicioExperienciaDTO tiempoServicioExperienciaDTO = new();
            tiempoServicioExperienciaDTO.TiempoServicioExperienciaId = TiempoServicioExperienciaId;
            tiempoServicioExperienciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tiempoServicioExperienciaBL.EliminarTiempoServicioExperiencia(tiempoServicioExperienciaDTO);

            return Content(IND_OPERACION);
        }
    }
}
