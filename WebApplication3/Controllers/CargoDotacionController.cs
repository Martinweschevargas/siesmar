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
    public class CargoDotacionController : Controller
    {
        readonly ILogger<CargoDotacionController> _logger;

        public CargoDotacionController(ILogger<CargoDotacionController> logger)
        {
            _logger = logger;
        }

        readonly CargoDotacionDAO CargoDotacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Cargos Dotaciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CargoDotacionDTO> listaCargoDotacions = CargoDotacionBL.ObtenerCargoDotacions();
            return Json(new { data = listaCargoDotacions });
        }

        public ActionResult InsertarCargoDotacion(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CargoDotacionDTO CargoDotacionDTO = new();
                CargoDotacionDTO.DescCargoDotacion = Descripcion;
                CargoDotacionDTO.CodigoCargoDotacion = Codigo;
                CargoDotacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = CargoDotacionBL.AgregarCargoDotacion(CargoDotacionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCargoDotacion(int CargoDotacionId)
        {
            return Json(CargoDotacionBL.BuscarCargoDotacionID(CargoDotacionId));
        }

        public ActionResult ActualizarCargoDotacion(int CargoDotacionId, string Codigo, string Descripcion)
        {
            CargoDotacionDTO CargoDotacionDTO = new();
            CargoDotacionDTO.CargoDotacionId = CargoDotacionId;
            CargoDotacionDTO.DescCargoDotacion = Descripcion;
            CargoDotacionDTO.CodigoCargoDotacion = Codigo;
            CargoDotacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CargoDotacionBL.ActualizarCargoDotacion(CargoDotacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCargoDotacion(int CargoDotacionId)
        {
            CargoDotacionDTO CargoDotacionDTO = new();
            CargoDotacionDTO.CargoDotacionId = CargoDotacionId;
            CargoDotacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CargoDotacionBL.EliminarCargoDotacion(CargoDotacionDTO);

            return Content(IND_OPERACION);
        }
    }
}
