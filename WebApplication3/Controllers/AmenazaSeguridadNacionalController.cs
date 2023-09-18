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
    public class AmenazaSeguridadNacionalController : Controller
    {
        readonly ILogger<AmenazaSeguridadNacionalController> _logger;

        public AmenazaSeguridadNacionalController(ILogger<AmenazaSeguridadNacionalController> logger)
        {
            _logger = logger;
        }

        readonly AmenazaSeguridadNacionalDAO AmenazaSeguridadNacionalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Amenazas Seguridad Nacional", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<AmenazaSeguridadNacionalDTO> listaAmenazaSeguridadNacionals = AmenazaSeguridadNacionalBL.ObtenerAmenazaSeguridadNacionals();
            return Json(new { data = listaAmenazaSeguridadNacionals });
        }

        public ActionResult InsertarAmenazaSeguridadNacional(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                AmenazaSeguridadNacionalDTO AmenazaSeguridadNacionalDTO = new();
                AmenazaSeguridadNacionalDTO.DescAmenazaSeguridadNacional = Descripcion;
                AmenazaSeguridadNacionalDTO.CodigoAmenazaSeguridadNacional = Codigo;
                AmenazaSeguridadNacionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = AmenazaSeguridadNacionalBL.AgregarAmenazaSeguridadNacional(AmenazaSeguridadNacionalDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAmenazaSeguridadNacional(int AmenazaSeguridadNacionalId)
        {
            return Json(AmenazaSeguridadNacionalBL.BuscarAmenazaSeguridadNacionalID(AmenazaSeguridadNacionalId));
        }

        public ActionResult ActualizarAmenazaSeguridadNacional(int AmenazaSeguridadNacionalId, string Codigo, string Descripcion)
        {
            AmenazaSeguridadNacionalDTO AmenazaSeguridadNacionalDTO = new();
            AmenazaSeguridadNacionalDTO.AmenazaSeguridadNacionalId = AmenazaSeguridadNacionalId;
            AmenazaSeguridadNacionalDTO.DescAmenazaSeguridadNacional = Descripcion;
            AmenazaSeguridadNacionalDTO.CodigoAmenazaSeguridadNacional = Codigo;
            AmenazaSeguridadNacionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AmenazaSeguridadNacionalBL.ActualizarAmenazaSeguridadNacional(AmenazaSeguridadNacionalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAmenazaSeguridadNacional(int AmenazaSeguridadNacionalId)
        {
            AmenazaSeguridadNacionalDTO AmenazaSeguridadNacionalDTO = new();
            AmenazaSeguridadNacionalDTO.AmenazaSeguridadNacionalId = AmenazaSeguridadNacionalId;
            AmenazaSeguridadNacionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AmenazaSeguridadNacionalBL.EliminarAmenazaSeguridadNacional(AmenazaSeguridadNacionalDTO);

            return Content(IND_OPERACION);
        }
    }
}
