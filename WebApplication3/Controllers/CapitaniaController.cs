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
    public class CapitaniaController : Controller
    {
        readonly ILogger<CapitaniaController> _logger;

        public CapitaniaController(ILogger<CapitaniaController> logger)
        {
            _logger = logger;
        }

        readonly CapitaniaDAO capitaniaBL = new();
        readonly JefaturaDistritoCapitania jefaturaDistritoCapitania = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Capitanias", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CapitaniaDTO> listaCapitanias = capitaniaBL.ObtenerCapitanias();
            return Json(new { data = listaCapitanias });
        }

        public JsonResult cargarCombo()
        {
            List<JefaturaDistritoCapitaniaDTO> listaJefaturaDistritoCapitania = jefaturaDistritoCapitania.ObtenerJefaturaDistritoCapitanias();
            return Json(listaJefaturaDistritoCapitania);
        }

        public ActionResult InsertarCapitania(string NombreCapitania, string DescCapitania, string CodigoCapitania, int JefaturaDistritoCapitaniaId)
        {
            var IND_OPERACION="";
            try
            {
                CapitaniaDTO capitaniaDTO = new();
                capitaniaDTO.NombreCapitania = NombreCapitania;
                capitaniaDTO.DescCapitania = DescCapitania;
                capitaniaDTO.CodigoCapitania = CodigoCapitania;
                capitaniaDTO.JefaturaDistritoCapitaniaId = JefaturaDistritoCapitaniaId;
                capitaniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = capitaniaBL.AgregarCapitania(capitaniaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCapitania(int CapitaniaId)
        {
            return Json(capitaniaBL.BuscarCapitaniaID(CapitaniaId));
        }

        public ActionResult ActualizarCapitania(int CapitaniaId, string NombreCapitania, string DescCapitania, string CodigoCapitania, int JefaturaDistritoCapitaniaId)
        {
            CapitaniaDTO capitaniaDTO = new();
            capitaniaDTO.CapitaniaId = CapitaniaId;
            capitaniaDTO.NombreCapitania = NombreCapitania;
            capitaniaDTO.DescCapitania = DescCapitania;
            capitaniaDTO.CodigoCapitania = CodigoCapitania;
            capitaniaDTO.JefaturaDistritoCapitaniaId = JefaturaDistritoCapitaniaId;
            capitaniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capitaniaBL.ActualizarCapitania(capitaniaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCapitania(int CapitaniaId)
        {
            CapitaniaDTO capitaniaDTO = new();
            capitaniaDTO.CapitaniaId = CapitaniaId;
            capitaniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capitaniaBL.EliminarCapitania(capitaniaDTO);

            return Content(IND_OPERACION);
        }
    }
}
