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
    public class VillaNavalController : Controller
    {
        readonly ILogger<VillaNavalController> _logger;

        public VillaNavalController(ILogger<VillaNavalController> logger)
        {
            _logger = logger;
        }

        readonly VillaNavalDAO villaNavalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Villas Navales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<VillaNavalDTO> listaVillaNavals = villaNavalBL.ObtenerVillaNavals();
            return Json(new { data = listaVillaNavals });
        }

        public ActionResult InsertarVillaNaval(string CodigoVillaNaval, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                VillaNavalDTO villaNavalDTO = new();
                villaNavalDTO.CodigoVillaNaval = CodigoVillaNaval;
                villaNavalDTO.DescVillaNaval = Descripcion;
                villaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = villaNavalBL.AgregarVillaNaval(villaNavalDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarVillaNaval(int VillaNavalId)
        {
            return Json(villaNavalBL.BuscarVillaNavalID(VillaNavalId));
        }

        public ActionResult ActualizarVillaNaval(int VillaNavalId, string CodigoVillaNaval, string Descripcion)
        {
            VillaNavalDTO villaNavalDTO = new();
            villaNavalDTO.VillaNavalId = VillaNavalId;
            villaNavalDTO.CodigoVillaNaval = CodigoVillaNaval;
            villaNavalDTO.DescVillaNaval = Descripcion;
            villaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = villaNavalBL.ActualizarVillaNaval(villaNavalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarVillaNaval(int VillaNavalId)
        {
            VillaNavalDTO villaNavalDTO = new();
            villaNavalDTO.VillaNavalId = VillaNavalId;
            villaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = villaNavalBL.EliminarVillaNaval(villaNavalDTO);

            return Content(IND_OPERACION);
        }
    }
}
