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
    public class ComisionController : Controller
    {
        readonly ILogger<ComisionController> _logger;

        public ComisionController(ILogger<ComisionController> logger)
        {
            _logger = logger;
        }

        readonly ComisionDAO ComisionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Comisiones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ComisionDTO> listaComisions = ComisionBL.ObtenerComisions();
            return Json(new { data = listaComisions });
        }

        public ActionResult InsertarComision(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ComisionDTO ComisionDTO = new();
                ComisionDTO.DescComision = Descripcion;
                ComisionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ComisionBL.AgregarComision(ComisionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarComision(int ComisionId)
        {
            return Json(ComisionBL.BuscarComisionID(ComisionId));
        }

        public ActionResult ActualizarComision(int ComisionId, string Descripcion)
        {
            ComisionDTO ComisionDTO = new();
            ComisionDTO.ComisionId = ComisionId;
            ComisionDTO.DescComision = Descripcion;
            ComisionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ComisionBL.ActualizarComision(ComisionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarComision(int ComisionId)
        {
            ComisionDTO ComisionDTO = new();
            ComisionDTO.ComisionId = ComisionId;
            ComisionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ComisionBL.EliminarComision(ComisionDTO);

            return Content(IND_OPERACION);
        }
    }
}
