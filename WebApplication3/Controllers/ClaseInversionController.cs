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
    public class ClaseInversionController : Controller
    {
        readonly ILogger<ClaseInversionController> _logger;

        public ClaseInversionController(ILogger<ClaseInversionController> logger)
        {
            _logger = logger;
        }

        readonly ClaseInversion ClaseInversionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clases Inversiones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClaseInversionDTO> listaClaseInversions = ClaseInversionBL.ObtenerClaseInversions();
            return Json(new { data = listaClaseInversions });
        }

        public ActionResult InsertarClaseInversion(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ClaseInversionDTO ClaseInversionDTO = new();
                ClaseInversionDTO.DescClaseInversion = Descripcion;
                ClaseInversionDTO.CodigoClaseInversion = Codigo;
                ClaseInversionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ClaseInversionBL.AgregarClaseInversion(ClaseInversionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClaseInversion(int ClaseInversionId)
        {
            return Json(ClaseInversionBL.BuscarClaseInversionID(ClaseInversionId));
        }

        public ActionResult ActualizarClaseInversion(int ClaseInversionId, string Codigo, string Descripcion)
        {
            ClaseInversionDTO ClaseInversionDTO = new();
            ClaseInversionDTO.ClaseInversionId = ClaseInversionId;
            ClaseInversionDTO.DescClaseInversion = Descripcion;
            ClaseInversionDTO.CodigoClaseInversion = Codigo;
            ClaseInversionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ClaseInversionBL.ActualizarClaseInversion(ClaseInversionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClaseInversion(int ClaseInversionId)
        {
            ClaseInversionDTO ClaseInversionDTO = new();
            ClaseInversionDTO.ClaseInversionId = ClaseInversionId;
            ClaseInversionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ClaseInversionBL.EliminarClaseInversion(ClaseInversionDTO);

            return Content(IND_OPERACION);
        }
    }
}
