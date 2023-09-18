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
    public class DirigidoAController : Controller
    {
        readonly ILogger<DirigidoAController> _logger;

        public DirigidoAController(ILogger<DirigidoAController> logger)
        {
            _logger = logger;
        }

        readonly DirigidoADAO DirigidoABL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Dirigidos A", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DirigidoADTO> listaDirigidoAs = DirigidoABL.ObtenerDirigidoAs();
            return Json(new { data = listaDirigidoAs });
        }

        public ActionResult InsertarDirigidoA(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                DirigidoADTO DirigidoADTO = new();
                DirigidoADTO.DescDirigidoA = Descripcion;
                DirigidoADTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = DirigidoABL.AgregarDirigidoA(DirigidoADTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDirigidoA(int DirigidoAId)
        {
            return Json(DirigidoABL.BuscarDirigidoAID(DirigidoAId));
        }

        public ActionResult ActualizarDirigidoA(int DirigidoAId, string Descripcion)
        {
            DirigidoADTO DirigidoADTO = new();
            DirigidoADTO.DirigidoAId = DirigidoAId;
            DirigidoADTO.DescDirigidoA = Descripcion;
            DirigidoADTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = DirigidoABL.ActualizarDirigidoA(DirigidoADTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDirigidoA(int DirigidoAId)
        {
            DirigidoADTO DirigidoADTO = new();
            DirigidoADTO.DirigidoAId = DirigidoAId;
            DirigidoADTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = DirigidoABL.EliminarDirigidoA(DirigidoADTO);

            return Content(IND_OPERACION);
        }
    }
}