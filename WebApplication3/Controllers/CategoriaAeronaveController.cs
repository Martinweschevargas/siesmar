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
    public class CategoriaAeronaveController : Controller
    {
        readonly ILogger<CategoriaAeronaveController> _logger;

        public CategoriaAeronaveController(ILogger<CategoriaAeronaveController> logger)
        {
            _logger = logger;
        }

        readonly CategoriaAeronaveDAO capitaniaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Categorías Aeronaves", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CategoriaAeronaveDTO> listaCategoriaAeronaves = capitaniaBL.ObtenerCategoriaAeronaves();
            return Json(new { data = listaCategoriaAeronaves });
        }

        public ActionResult InsertarCategoriaAeronave(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CategoriaAeronaveDTO capitaniaDTO = new();
                capitaniaDTO.DescCategoriaAeronave = Descripcion;
                capitaniaDTO.CodigoCategoriaAeronave = Codigo;
                capitaniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = capitaniaBL.AgregarCategoriaAeronave(capitaniaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCategoriaAeronave(int CategoriaAeronaveId)
        {
            return Json(capitaniaBL.BuscarCategoriaAeronaveID(CategoriaAeronaveId));
        }

        public ActionResult ActualizarCategoriaAeronave(int CategoriaAeronaveId, string Codigo, string Descripcion)
        {
            CategoriaAeronaveDTO capitaniaDTO = new();
            capitaniaDTO.CategoriaAeronaveId = CategoriaAeronaveId;
            capitaniaDTO.DescCategoriaAeronave = Descripcion;
            capitaniaDTO.CodigoCategoriaAeronave = Codigo;
            capitaniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capitaniaBL.ActualizarCategoriaAeronave(capitaniaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCategoriaAeronave(int CategoriaAeronaveId)
        {
            CategoriaAeronaveDTO capitaniaDTO = new();
            capitaniaDTO.CategoriaAeronaveId = CategoriaAeronaveId;
            capitaniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capitaniaBL.EliminarCategoriaAeronave(capitaniaDTO);

            return Content(IND_OPERACION);
        }
    }
}
