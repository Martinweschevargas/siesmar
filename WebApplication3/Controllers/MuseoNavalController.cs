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
    public class MuseoNavalController : Controller
    {
        readonly ILogger<MuseoNavalController> _logger;

        public MuseoNavalController(ILogger<MuseoNavalController> logger)
        {
            _logger = logger;
        }

        readonly MuseoNavalDAO museoNavalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Museos Navales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MuseoNavalDTO> listaMuseoNavals = museoNavalBL.ObtenerMuseoNavals();
            return Json(new { data = listaMuseoNavals });
        }

        public ActionResult InsertarMuseoNaval(string DescMuseoNaval, string CodigoMuseoNaval)
        {
            var IND_OPERACION = "";
            try
            {
                MuseoNavalDTO museoNavalDTO = new();
                museoNavalDTO.DescMuseoNaval = DescMuseoNaval;
                museoNavalDTO.CodigoMuseoNaval = CodigoMuseoNaval;
                museoNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = museoNavalBL.AgregarMuseoNaval(museoNavalDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMuseoNaval(int MuseoNavalId)
        {
            return Json(museoNavalBL.BuscarMuseoNavalID(MuseoNavalId));
        }

        public ActionResult ActualizarMuseoNaval(int MuseoNavalId, string DescMuseoNaval, string CodigoMuseoNaval)
        {
            MuseoNavalDTO museoNavalDTO = new();
            museoNavalDTO.MuseoNavalId = MuseoNavalId;
            museoNavalDTO.DescMuseoNaval = DescMuseoNaval;
            museoNavalDTO.CodigoMuseoNaval = CodigoMuseoNaval;
            museoNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = museoNavalBL.ActualizarMuseoNaval(museoNavalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMuseoNaval(int MuseoNavalId)
        {
            MuseoNavalDTO museoNavalDTO = new();
            museoNavalDTO.MuseoNavalId = MuseoNavalId;
            museoNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (museoNavalBL.EliminarMuseoNaval(museoNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}

