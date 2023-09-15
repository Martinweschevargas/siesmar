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
    public class ClasificacionSancionDisciplinariaController : Controller
    {
        readonly ILogger<ClasificacionSancionDisciplinariaController> _logger;

        public ClasificacionSancionDisciplinariaController(ILogger<ClasificacionSancionDisciplinariaController> logger)
        {
            _logger = logger;
        }

        readonly ClasificacionSancionDisciplinaria ClasificacionSancionDisciplinariaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clasificaciones Sanciones Disciplinarias", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
          
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClasificacionSancionDisciplinariaDTO> listaClasificacionSancionDisciplinarias = ClasificacionSancionDisciplinariaBL.ObtenerClasificacionSancionDisciplinarias();
            return Json(new { data = listaClasificacionSancionDisciplinarias });
        }

        public ActionResult InsertarClasificacionSancionDisciplinaria(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ClasificacionSancionDisciplinariaDTO ClasificacionSancionDisciplinariaDTO = new();
                ClasificacionSancionDisciplinariaDTO.DescClasificacionSancionDisciplinaria = Descripcion;
                ClasificacionSancionDisciplinariaDTO.CodigoClasificacionSancionDisciplinaria = Codigo;
                ClasificacionSancionDisciplinariaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ClasificacionSancionDisciplinariaBL.AgregarClasificacionSancionDisciplinaria(ClasificacionSancionDisciplinariaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClasificacionSancionDisciplinaria(int ClasificacionSancionDisciplinariaId)
        {
            return Json(ClasificacionSancionDisciplinariaBL.BuscarClasificacionSancionDisciplinariaID(ClasificacionSancionDisciplinariaId));
        }

        public ActionResult ActualizarClasificacionSancionDisciplinaria(int ClasificacionSancionDisciplinariaId, string Codigo, string Descripcion)
        {
            ClasificacionSancionDisciplinariaDTO ClasificacionSancionDisciplinariaDTO = new();
            ClasificacionSancionDisciplinariaDTO.ClasificacionSancionDisciplinariaId = ClasificacionSancionDisciplinariaId;
            ClasificacionSancionDisciplinariaDTO.DescClasificacionSancionDisciplinaria = Descripcion;
            ClasificacionSancionDisciplinariaDTO.CodigoClasificacionSancionDisciplinaria = Codigo;
            ClasificacionSancionDisciplinariaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ClasificacionSancionDisciplinariaBL.ActualizarClasificacionSancionDisciplinaria(ClasificacionSancionDisciplinariaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClasificacionSancionDisciplinaria(int ClasificacionSancionDisciplinariaId)
        {
            ClasificacionSancionDisciplinariaDTO ClasificacionSancionDisciplinariaDTO = new();
            ClasificacionSancionDisciplinariaDTO.ClasificacionSancionDisciplinariaId = ClasificacionSancionDisciplinariaId;
            ClasificacionSancionDisciplinariaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ClasificacionSancionDisciplinariaBL.EliminarClasificacionSancionDisciplinaria(ClasificacionSancionDisciplinariaDTO);

            return Content(IND_OPERACION);
        }
    }
}
