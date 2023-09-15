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
    public class ClasificacionFlotaController : Controller
    {
        readonly ILogger<ClasificacionFlotaController> _logger;

        public ClasificacionFlotaController(ILogger<ClasificacionFlotaController> logger)
        {
            _logger = logger;
        }

        readonly ClasificacionFlota clasificacionFlotaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clasificaciones Flotas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClasificacionFlotaDTO> listaClasificacionFlotas = clasificacionFlotaBL.ObtenerClasificacionFlotas();
            return Json(new { data = listaClasificacionFlotas });
        }

        public ActionResult InsertarClasificacionFlota(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ClasificacionFlotaDTO clasificacionFlotaDTO = new();
                clasificacionFlotaDTO.DescClasificacionFlota = Descripcion;
                clasificacionFlotaDTO.CodigoClasificacionFlota = Codigo;
                clasificacionFlotaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = clasificacionFlotaBL.AgregarClasificacionFlota(clasificacionFlotaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClasificacionFlota(int ClasificacionFlotaId)
        {
            return Json(clasificacionFlotaBL.BuscarClasificacionFlotaID(ClasificacionFlotaId));
        }

        public ActionResult ActualizarClasificacionFlota(int ClasificacionFlotaId, string Codigo, string Descripcion)
        {
            ClasificacionFlotaDTO clasificacionFlotaDTO = new();
            clasificacionFlotaDTO.ClasificacionFlotaId = ClasificacionFlotaId;
            clasificacionFlotaDTO.DescClasificacionFlota = Descripcion;
            clasificacionFlotaDTO.CodigoClasificacionFlota = Codigo;
            clasificacionFlotaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = clasificacionFlotaBL.ActualizarClasificacionFlota(clasificacionFlotaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClasificacionFlota(int ClasificacionFlotaId)
        {
            ClasificacionFlotaDTO clasificacionFlotaDTO = new();
            clasificacionFlotaDTO.ClasificacionFlotaId = ClasificacionFlotaId;
            clasificacionFlotaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = clasificacionFlotaBL.EliminarClasificacionFlota(clasificacionFlotaDTO);

            return Content(IND_OPERACION);
        }
    }
}
