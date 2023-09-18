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
    public class ClaseVisitaController : Controller
    {
        readonly ILogger<ClaseVisitaController> _logger;

        public ClaseVisitaController(ILogger<ClaseVisitaController> logger)
        {
            _logger = logger;
        }

        readonly ClaseVisitaDAO ClaseVisitaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clases Visitas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClaseVisitaDTO> listaClaseVisitas = ClaseVisitaBL.ObtenerClaseVisitas();
            return Json(new { data = listaClaseVisitas });
        }

        public ActionResult InsertarClaseVisita(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ClaseVisitaDTO ClaseVisitaDTO = new();
                ClaseVisitaDTO.DescClaseVisita = Descripcion;
                ClaseVisitaDTO.CodigoClaseVisita = Codigo;
                ClaseVisitaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ClaseVisitaBL.AgregarClaseVisita(ClaseVisitaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClaseVisita(int ClaseVisitaId)
        {
            return Json(ClaseVisitaBL.BuscarClaseVisitaID(ClaseVisitaId));
        }

        public ActionResult ActualizarClaseVisita(int ClaseVisitaId, string Codigo, string Descripcion)
        {
            ClaseVisitaDTO ClaseVisitaDTO = new();
            ClaseVisitaDTO.ClaseVisitaId = ClaseVisitaId;
            ClaseVisitaDTO.DescClaseVisita = Descripcion;
            ClaseVisitaDTO.CodigoClaseVisita = Codigo;
            ClaseVisitaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ClaseVisitaBL.ActualizarClaseVisita(ClaseVisitaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClaseVisita(int ClaseVisitaId)
        {
            ClaseVisitaDTO ClaseVisitaDTO = new();
            ClaseVisitaDTO.ClaseVisitaId = ClaseVisitaId;
            ClaseVisitaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ClaseVisitaBL.EliminarClaseVisita(ClaseVisitaDTO);

            return Content(IND_OPERACION);
        }
    }
}
