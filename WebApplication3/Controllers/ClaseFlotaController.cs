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
    public class ClaseFlotaController : Controller
    {
        readonly ILogger<ClaseFlotaController> _logger;

        public ClaseFlotaController(ILogger<ClaseFlotaController> logger)
        {
            _logger = logger;
        }

        readonly ClaseFlotaDAO claseFlotaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clases Flotas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
          
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClaseFlotaDTO> listaClaseFlotas = claseFlotaBL.ObtenerClaseFlotas();
            return Json(new { data = listaClaseFlotas });
        }

        public ActionResult InsertarClaseFlota(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ClaseFlotaDTO claseFlotaDTO = new();
                claseFlotaDTO.DescClaseFlota = Descripcion;
                claseFlotaDTO.CodigoClaseFlota = Codigo;
                claseFlotaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = claseFlotaBL.AgregarClaseFlota(claseFlotaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClaseFlota(int ClaseFlotaId)
        {
            return Json(claseFlotaBL.BuscarClaseFlotaID(ClaseFlotaId));
        }

        public ActionResult ActualizarClaseFlota(int ClaseFlotaId, string Codigo, string Descripcion)
        {
            ClaseFlotaDTO claseFlotaDTO = new();
            claseFlotaDTO.ClaseFlotaId = ClaseFlotaId;
            claseFlotaDTO.DescClaseFlota = Descripcion;
            claseFlotaDTO.CodigoClaseFlota = Codigo;
            claseFlotaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = claseFlotaBL.ActualizarClaseFlota(claseFlotaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClaseFlota(int ClaseFlotaId)
        {
            ClaseFlotaDTO claseFlotaDTO = new();
            claseFlotaDTO.ClaseFlotaId = ClaseFlotaId;
            claseFlotaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = claseFlotaBL.EliminarClaseFlota(claseFlotaDTO);

            return Content(IND_OPERACION);
        }
    }
}
