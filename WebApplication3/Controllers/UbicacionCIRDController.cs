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
    public class UbicacionCIRDController : Controller
    {
        readonly ILogger<UbicacionCIRDController> _logger;

        public UbicacionCIRDController(ILogger<UbicacionCIRDController> logger)
        {
            _logger = logger;
        }

        readonly UbicacionCIRDDAO ubicacionCIRDBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Ubicaciones CIRD", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<UbicacionCIRDDTO> listaUbicacionCIRDs = ubicacionCIRDBL.ObtenerUbicacionCIRDs();
            return Json(new { data = listaUbicacionCIRDs });
        }

        public ActionResult InsertarUbicacionCIRD(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                UbicacionCIRDDTO ubicacionCIRDDTO = new();
                ubicacionCIRDDTO.DescUbicacionCIRD = Descripcion;
                ubicacionCIRDDTO.CodigoUbicacionCIRD = Codigo;
                ubicacionCIRDDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ubicacionCIRDBL.AgregarUbicacionCIRD(ubicacionCIRDDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarUbicacionCIRD(int UbicacionCIRDId)
        {
            return Json(ubicacionCIRDBL.BuscarUbicacionCIRDID(UbicacionCIRDId));
        }

        public ActionResult ActualizarUbicacionCIRD(int UbicacionCIRDId, string Codigo, string Descripcion)
        {
            UbicacionCIRDDTO ubicacionCIRDDTO = new();
            ubicacionCIRDDTO.UbicacionCIRDId = UbicacionCIRDId;
            ubicacionCIRDDTO.DescUbicacionCIRD = Descripcion;
            ubicacionCIRDDTO.CodigoUbicacionCIRD = Codigo;
            ubicacionCIRDDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ubicacionCIRDBL.ActualizarUbicacionCIRD(ubicacionCIRDDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarUbicacionCIRD(int UbicacionCIRDId)
        {
            UbicacionCIRDDTO ubicacionCIRDDTO = new();
            ubicacionCIRDDTO.UbicacionCIRDId = UbicacionCIRDId;
            ubicacionCIRDDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ubicacionCIRDBL.EliminarUbicacionCIRD(ubicacionCIRDDTO);

            return Content(IND_OPERACION);
        }
    }
}
