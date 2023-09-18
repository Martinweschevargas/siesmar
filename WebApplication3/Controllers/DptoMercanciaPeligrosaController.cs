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
    public class DptoMercanciaPeligrosaController : Controller
    {
        readonly ILogger<DptoMercanciaPeligrosaController> _logger;

        public DptoMercanciaPeligrosaController(ILogger<DptoMercanciaPeligrosaController> logger)
        {
            _logger = logger;
        }

        readonly DptoMercanciaPeligrosaDAO DptoMercanciaPeligrosaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Dptos Mercancias Peligrosas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DptoMercanciaPeligrosaDTO> listaDptoMercanciaPeligrosas = DptoMercanciaPeligrosaBL.ObtenerDptoMercanciaPeligrosas();
            return Json(new { data = listaDptoMercanciaPeligrosas });
        }

        public ActionResult InsertarDptoMercanciaPeligrosa(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                DptoMercanciaPeligrosaDTO DptoMercanciaPeligrosaDTO = new();
                DptoMercanciaPeligrosaDTO.DescDptoMercanciaPeligrosa = Descripcion;
                DptoMercanciaPeligrosaDTO.CodigoDptoMercanciaPeligrosa = Codigo;
                DptoMercanciaPeligrosaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = DptoMercanciaPeligrosaBL.AgregarDptoMercanciaPeligrosa(DptoMercanciaPeligrosaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDptoMercanciaPeligrosa(int DptoMercanciaPeligrosaId)
        {
            return Json(DptoMercanciaPeligrosaBL.BuscarDptoMercanciaPeligrosaID(DptoMercanciaPeligrosaId));
        }

        public ActionResult ActualizarDptoMercanciaPeligrosa(int DptoMercanciaPeligrosaId, string Codigo, string Descripcion)
        {
            DptoMercanciaPeligrosaDTO DptoMercanciaPeligrosaDTO = new();
            DptoMercanciaPeligrosaDTO.DptoMercanciaPeligrosaId = DptoMercanciaPeligrosaId;
            DptoMercanciaPeligrosaDTO.DescDptoMercanciaPeligrosa = Descripcion;
            DptoMercanciaPeligrosaDTO.CodigoDptoMercanciaPeligrosa = Codigo;
            DptoMercanciaPeligrosaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = DptoMercanciaPeligrosaBL.ActualizarDptoMercanciaPeligrosa(DptoMercanciaPeligrosaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDptoMercanciaPeligrosa(int DptoMercanciaPeligrosaId)
        {
            DptoMercanciaPeligrosaDTO DptoMercanciaPeligrosaDTO = new();
            DptoMercanciaPeligrosaDTO.DptoMercanciaPeligrosaId = DptoMercanciaPeligrosaId;
            DptoMercanciaPeligrosaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = DptoMercanciaPeligrosaBL.EliminarDptoMercanciaPeligrosa(DptoMercanciaPeligrosaDTO);

            return Content(IND_OPERACION);
        }
    }
}
