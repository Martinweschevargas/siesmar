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
    public class CodigoController : Controller
    {
        readonly ILogger<CodigoController> _logger;

        public CodigoController(ILogger<CodigoController> logger)
        {
            _logger = logger;
        }

        readonly CodigoDAO codigoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Códigos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CodigoDTO> listaCodigos = codigoBL.ObtenerCodigos();
            return Json(new { data = listaCodigos });
        }

        public ActionResult InsertarCodigo(string Publico)
        {
            var IND_OPERACION = "";
            try
            {
                CodigoDTO codigoDTO = new();
                codigoDTO.PublicoObjetivo = Publico;
                codigoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = codigoBL.AgregarCodigo(codigoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCodigo(int CodigoId)
        {
            return Json(codigoBL.BuscarCodigoID(CodigoId));
        }

        public ActionResult ActualizarCodigo(int CodigoId, string Publico)
        {
            CodigoDTO codigoDTO = new();
            codigoDTO.CodigoId = CodigoId;
            codigoDTO.PublicoObjetivo = Publico;
            codigoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = codigoBL.ActualizarCodigo(codigoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCodigo(int CodigoId)
        {
            CodigoDTO codigoDTO = new();
            codigoDTO.CodigoId = CodigoId;
            codigoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = codigoBL.EliminarCodigo(codigoDTO);

            return Content(IND_OPERACION);
        }
    }
}
