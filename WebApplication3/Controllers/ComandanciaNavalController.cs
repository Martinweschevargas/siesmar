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
    public class ComandanciaNavalController : Controller
    {
        readonly ILogger<ComandanciaNavalController> _logger;

        public ComandanciaNavalController(ILogger<ComandanciaNavalController> logger)
        {
            _logger = logger;
        }

        readonly ComandanciaNaval comandanciaNavalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Comandancias Navales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ComandanciaNavalDTO> listaComandanciaNavals = comandanciaNavalBL.ObtenerComandanciaNavals();
            return Json(new { data = listaComandanciaNavals });
        }

        public ActionResult InsertarComandanciaNaval(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ComandanciaNavalDTO comandanciaNavalDTO = new();
                comandanciaNavalDTO.DescComandanciaNaval = Descripcion;
                comandanciaNavalDTO.CodigoComandanciaNaval = Codigo;
                comandanciaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = comandanciaNavalBL.AgregarComandanciaNaval(comandanciaNavalDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarComandanciaNaval(int ComandanciaNavalId)
        {
            return Json(comandanciaNavalBL.BuscarComandanciaNavalID(ComandanciaNavalId));
        }

        public ActionResult ActualizarComandanciaNaval(int ComandanciaNavalId, string Codigo, string Descripcion)
        {
            ComandanciaNavalDTO comandanciaNavalDTO = new();
            comandanciaNavalDTO.ComandanciaNavalId = ComandanciaNavalId;
            comandanciaNavalDTO.DescComandanciaNaval = Descripcion;
            comandanciaNavalDTO.CodigoComandanciaNaval = Codigo;
            comandanciaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = comandanciaNavalBL.ActualizarComandanciaNaval(comandanciaNavalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarComandanciaNaval(int ComandanciaNavalId)
        {
            ComandanciaNavalDTO comandanciaNavalDTO = new();
            comandanciaNavalDTO.ComandanciaNavalId = ComandanciaNavalId;
            comandanciaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = comandanciaNavalBL.EliminarComandanciaNaval(comandanciaNavalDTO);

            return Content(IND_OPERACION);
        }
    }
}
