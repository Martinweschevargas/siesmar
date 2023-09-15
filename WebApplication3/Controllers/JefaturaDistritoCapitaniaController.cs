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
    public class JefaturaDistritoCapitaniaController : Controller
    {
        readonly ILogger<JefaturaDistritoCapitaniaController> _logger;

        public JefaturaDistritoCapitaniaController(ILogger<JefaturaDistritoCapitaniaController> logger)
        {
            _logger = logger;
        }

        readonly JefaturaDistritoCapitaniaDAO jefaturaDistritoCapitaniaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Jefaturas Distritos Capitanias", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
          
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<JefaturaDistritoCapitaniaDTO> listaJefaturaDistritoCapitanias = jefaturaDistritoCapitaniaBL.ObtenerJefaturaDistritoCapitanias();
            return Json(new { data = listaJefaturaDistritoCapitanias });
        }

        public ActionResult InsertarJefaturaDistritoCapitania(string DescJefaturaDistritoCapitania)
        {
            var IND_OPERACION="";
            try
            {
                JefaturaDistritoCapitaniaDTO jefaturaDistritoCapitaniaDTO = new();
                jefaturaDistritoCapitaniaDTO.DescJefaturaDistritoCapitania = DescJefaturaDistritoCapitania;
                jefaturaDistritoCapitaniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = jefaturaDistritoCapitaniaBL.AgregarJefaturaDistritoCapitania(jefaturaDistritoCapitaniaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarJefaturaDistritoCapitania(int JefaturaDistritoCapitaniaId)
        {
            return Json(jefaturaDistritoCapitaniaBL.BuscarJefaturaDistritoCapitaniaID(JefaturaDistritoCapitaniaId));
        }

        public ActionResult ActualizarJefaturaDistritoCapitania(int JefaturaDistritoCapitaniaId, string DescJefaturaDistritoCapitania)
        {
            JefaturaDistritoCapitaniaDTO jefaturaDistritoCapitaniaDTO = new();
            jefaturaDistritoCapitaniaDTO.JefaturaDistritoCapitaniaId = JefaturaDistritoCapitaniaId;
            jefaturaDistritoCapitaniaDTO.DescJefaturaDistritoCapitania = DescJefaturaDistritoCapitania;
            jefaturaDistritoCapitaniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = jefaturaDistritoCapitaniaBL.ActualizarJefaturaDistritoCapitania(jefaturaDistritoCapitaniaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarJefaturaDistritoCapitania(int JefaturaDistritoCapitaniaId)
        {
            JefaturaDistritoCapitaniaDTO jefaturaDistritoCapitaniaDTO = new();
            jefaturaDistritoCapitaniaDTO.JefaturaDistritoCapitaniaId = JefaturaDistritoCapitaniaId;
            jefaturaDistritoCapitaniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = jefaturaDistritoCapitaniaBL.EliminarJefaturaDistritoCapitania(jefaturaDistritoCapitaniaDTO);

            return Content(IND_OPERACION);
        }
    }
}
