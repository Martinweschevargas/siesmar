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
    public class TrabajoHidrograficoController : Controller
    {
        readonly ILogger<TrabajoHidrograficoController> _logger;

        public TrabajoHidrograficoController(ILogger<TrabajoHidrograficoController> logger)
        {
            _logger = logger;
        }

        readonly TrabajoHidrograficoDAO trabajoHidrograficoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Trabajos Hidrográficos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TrabajoHidrograficoDTO> listaTrabajoHidrograficos = trabajoHidrograficoBL.ObtenerTrabajoHidrograficos();
            return Json(new { data = listaTrabajoHidrograficos });
        }

        public ActionResult InsertarTrabajoHidrografico(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TrabajoHidrograficoDTO trabajoHidrograficoDTO = new();
                trabajoHidrograficoDTO.DescTrabajoHidrografico = Descripcion;
                trabajoHidrograficoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = trabajoHidrograficoBL.AgregarTrabajoHidrografico(trabajoHidrograficoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTrabajoHidrografico(int TrabajoHidrograficoId)
        {
            return Json(trabajoHidrograficoBL.BuscarTrabajoHidrograficoID(TrabajoHidrograficoId));
        }

        public ActionResult ActualizarTrabajoHidrografico(int TrabajoHidrograficoId, string Descripcion)
        {
            TrabajoHidrograficoDTO trabajoHidrograficoDTO = new();
            trabajoHidrograficoDTO.TrabajoHidrograficoId = TrabajoHidrograficoId;
            trabajoHidrograficoDTO.DescTrabajoHidrografico = Descripcion;
            trabajoHidrograficoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = trabajoHidrograficoBL.ActualizarTrabajoHidrografico(trabajoHidrograficoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTrabajoHidrografico(int TrabajoHidrograficoId)
        {
            TrabajoHidrograficoDTO trabajoHidrograficoDTO = new();
            trabajoHidrograficoDTO.TrabajoHidrograficoId = TrabajoHidrograficoId;
            trabajoHidrograficoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = trabajoHidrograficoBL.EliminarTrabajoHidrografico(trabajoHidrograficoDTO);

            return Content(IND_OPERACION);
        }
    }
}
