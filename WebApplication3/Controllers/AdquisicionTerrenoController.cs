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
    public class AdquisicionTerrenoController : Controller
    {
        readonly ILogger<AdquisicionTerrenoController> _logger;

        public AdquisicionTerrenoController(ILogger<AdquisicionTerrenoController> logger)
        {
            _logger = logger;
        }

        readonly AdquisicionTerrenoDAO AdquisicionTerrenoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Adquisiciones Terrenos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<AdquisicionTerrenoDTO> listaAdquisicionTerrenos = AdquisicionTerrenoBL.ObtenerAdquisicionTerrenos();
            return Json(new { data = listaAdquisicionTerrenos });
        }

        public ActionResult InsertarAdquisicionTerreno(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                AdquisicionTerrenoDTO AdquisicionTerrenoDTO = new();
                AdquisicionTerrenoDTO.DescAdquisicionTerreno = Descripcion;
                AdquisicionTerrenoDTO.CodigoAdquisicionTerreno = Codigo;
                AdquisicionTerrenoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = AdquisicionTerrenoBL.AgregarAdquisicionTerreno(AdquisicionTerrenoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAdquisicionTerreno(int AdquisicionTerrenoId)
        {
            return Json(AdquisicionTerrenoBL.BuscarAdquisicionTerrenoID(AdquisicionTerrenoId));
        }

        public ActionResult ActualizarAdquisicionTerreno(int AdquisicionTerrenoId, string Codigo, string Descripcion)
        {
            AdquisicionTerrenoDTO AdquisicionTerrenoDTO = new();
            AdquisicionTerrenoDTO.AdquisicionTerrenoId = AdquisicionTerrenoId;
            AdquisicionTerrenoDTO.DescAdquisicionTerreno = Descripcion;
            AdquisicionTerrenoDTO.CodigoAdquisicionTerreno = Codigo;
            AdquisicionTerrenoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AdquisicionTerrenoBL.ActualizarAdquisicionTerreno(AdquisicionTerrenoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAdquisicionTerreno(int AdquisicionTerrenoId)
        {
            AdquisicionTerrenoDTO AdquisicionTerrenoDTO = new();
            AdquisicionTerrenoDTO.AdquisicionTerrenoId = AdquisicionTerrenoId;
            AdquisicionTerrenoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AdquisicionTerrenoBL.EliminarAdquisicionTerreno(AdquisicionTerrenoDTO);

            return Content(IND_OPERACION);
        }
    }
}
