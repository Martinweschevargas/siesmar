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
    public class InspeccionFinalidadController : Controller
    {
        readonly ILogger<InspeccionFinalidadController> _logger;

        public InspeccionFinalidadController(ILogger<InspeccionFinalidadController> logger)
        {
            _logger = logger;
        }

        readonly InspeccionFinalidadDAO inspeccionFinalidadBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Inspecciones Finalidades", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<InspeccionFinalidadDTO> listaInspeccionFinalidads = inspeccionFinalidadBL.ObtenerInspeccionFinalidads();
            return Json(new { data = listaInspeccionFinalidads });
        }

        public ActionResult InsertarInspeccionFinalidad(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                InspeccionFinalidadDTO inspeccionFinalidadDTO = new();
                inspeccionFinalidadDTO.DescInspeccionFinalidad = Descripcion;
                inspeccionFinalidadDTO.CodigoInspeccionFinalidad = Codigo;
                inspeccionFinalidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = inspeccionFinalidadBL.AgregarInspeccionFinalidad(inspeccionFinalidadDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarInspeccionFinalidad(int InspeccionFinalidadId)
        {
            return Json(inspeccionFinalidadBL.BuscarInspeccionFinalidadID(InspeccionFinalidadId));
        }

        public ActionResult ActualizarInspeccionFinalidad(int InspeccionFinalidadId, string Codigo, string Descripcion)
        {
            InspeccionFinalidadDTO inspeccionFinalidadDTO = new();
            inspeccionFinalidadDTO.InspeccionFinalidadId = InspeccionFinalidadId;
            inspeccionFinalidadDTO.DescInspeccionFinalidad = Descripcion;
            inspeccionFinalidadDTO.CodigoInspeccionFinalidad = Codigo;
            inspeccionFinalidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = inspeccionFinalidadBL.ActualizarInspeccionFinalidad(inspeccionFinalidadDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarInspeccionFinalidad(int InspeccionFinalidadId)
        {
            InspeccionFinalidadDTO inspeccionFinalidadDTO = new();
            inspeccionFinalidadDTO.InspeccionFinalidadId = InspeccionFinalidadId;
            inspeccionFinalidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = inspeccionFinalidadBL.EliminarInspeccionFinalidad(inspeccionFinalidadDTO);

            return Content(IND_OPERACION);
        }
    }
}
