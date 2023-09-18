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
    public class InspeccionConocimientoController : Controller
    {
        readonly ILogger<InspeccionConocimientoController> _logger;

        public InspeccionConocimientoController(ILogger<InspeccionConocimientoController> logger)
        {
            _logger = logger;
        }

        readonly InspeccionConocimientoDAO inspeccionConocimientoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Inspecciones Conocimientos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<InspeccionConocimientoDTO> listaInspeccionConocimientos = inspeccionConocimientoBL.ObtenerInspeccionConocimientos();
            return Json(new { data = listaInspeccionConocimientos });
        }

        public ActionResult InsertarInspeccionConocimiento(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                InspeccionConocimientoDTO inspeccionConocimientoDTO = new();
                inspeccionConocimientoDTO.DescInspeccionConocimiento = Descripcion;
                inspeccionConocimientoDTO.CodigoInspeccionConocimiento = Codigo;
                inspeccionConocimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = inspeccionConocimientoBL.AgregarInspeccionConocimiento(inspeccionConocimientoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarInspeccionConocimiento(int InspeccionConocimientoId)
        {
            return Json(inspeccionConocimientoBL.BuscarInspeccionConocimientoID(InspeccionConocimientoId));
        }

        public ActionResult ActualizarInspeccionConocimiento(int InspeccionConocimientoId, string Codigo, string Descripcion)
        {
            InspeccionConocimientoDTO inspeccionConocimientoDTO = new();
            inspeccionConocimientoDTO.InspeccionConocimientoId = InspeccionConocimientoId;
            inspeccionConocimientoDTO.DescInspeccionConocimiento = Descripcion;
            inspeccionConocimientoDTO.CodigoInspeccionConocimiento = Codigo;
            inspeccionConocimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = inspeccionConocimientoBL.ActualizarInspeccionConocimiento(inspeccionConocimientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarInspeccionConocimiento(int InspeccionConocimientoId)
        {
            InspeccionConocimientoDTO inspeccionConocimientoDTO = new();
            inspeccionConocimientoDTO.InspeccionConocimientoId = InspeccionConocimientoId;
            inspeccionConocimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = inspeccionConocimientoBL.EliminarInspeccionConocimiento(inspeccionConocimientoDTO);

            return Content(IND_OPERACION);
        }
    }
}
