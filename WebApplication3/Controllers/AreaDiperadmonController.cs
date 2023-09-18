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
    public class AreaDiperadmonController : Controller
    {
        readonly ILogger<AreaDiperadmonController> _logger;

        public AreaDiperadmonController(ILogger<AreaDiperadmonController> logger)
        {
            _logger = logger;
        }

        readonly AreaDiperadmonDAO AreaDiperadmonBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Areas Diperadmon", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<AreaDiperadmonDTO> listaAreaDiperadmons = AreaDiperadmonBL.ObtenerAreaDiperadmons();
            return Json(new { data = listaAreaDiperadmons });
        }

        public ActionResult InsertarAreaDiperadmon(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                AreaDiperadmonDTO AreaDiperadmonDTO = new();
                AreaDiperadmonDTO.DescAreaDiperadmon = Descripcion;
                AreaDiperadmonDTO.CodigoAreaDiperadmon = Codigo;
                AreaDiperadmonDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = AreaDiperadmonBL.AgregarAreaDiperadmon(AreaDiperadmonDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAreaDiperadmon(int AreaDiperadmonId)
        {
            return Json(AreaDiperadmonBL.BuscarAreaDiperadmonID(AreaDiperadmonId));
        }

        public ActionResult ActualizarAreaDiperadmon(int AreaDiperadmonId, string Codigo, string Descripcion)
        {
            AreaDiperadmonDTO AreaDiperadmonDTO = new();
            AreaDiperadmonDTO.AreaDiperadmonId = AreaDiperadmonId;
            AreaDiperadmonDTO.DescAreaDiperadmon = Descripcion;
            AreaDiperadmonDTO.CodigoAreaDiperadmon = Codigo;
            AreaDiperadmonDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AreaDiperadmonBL.ActualizarAreaDiperadmon(AreaDiperadmonDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAreaDiperadmon(int AreaDiperadmonId)
        {
            AreaDiperadmonDTO AreaDiperadmonDTO = new();
            AreaDiperadmonDTO.AreaDiperadmonId = AreaDiperadmonId;
            AreaDiperadmonDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AreaDiperadmonBL.EliminarAreaDiperadmon(AreaDiperadmonDTO);

            return Content(IND_OPERACION);
        }
    }
}
