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
    public class CapacidadOperativaRequeridaController : Controller
    {
        readonly ILogger<CapacidadOperativaRequeridaController> _logger;

        public CapacidadOperativaRequeridaController(ILogger<CapacidadOperativaRequeridaController> logger)
        {
            _logger = logger;
        }

        readonly CapacidadOperativaRequeridaDAO capacidadOperativaRequeridaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Capacidades Operativas Requeridas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CapacidadOperativaRequeridaDTO> listaCapacidadOperativaRequeridas = capacidadOperativaRequeridaBL.ObtenerCapacidadOperativaRequeridas();
            return Json(new { data = listaCapacidadOperativaRequeridas });
        }

        public ActionResult InsertarCapacidadOperativaRequerida(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CapacidadOperativaRequeridaDTO capacidadOperativaRequeridaDTO = new();
                capacidadOperativaRequeridaDTO.DescCapacidadOperativaRequerida = Descripcion;
                capacidadOperativaRequeridaDTO.CodigoCapacidadOperativaRequerida = Codigo;
                capacidadOperativaRequeridaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = capacidadOperativaRequeridaBL.AgregarCapacidadOperativaRequerida(capacidadOperativaRequeridaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCapacidadOperativaRequerida(int CapacidadOperativaRequeridaId)
        {
            return Json(capacidadOperativaRequeridaBL.BuscarCapacidadOperativaRequeridaID(CapacidadOperativaRequeridaId));
        }

        public ActionResult ActualizarCapacidadOperativaRequerida(int CapacidadOperativaRequeridaId, string Codigo, string Descripcion)
        {
            CapacidadOperativaRequeridaDTO capacidadOperativaRequeridaDTO = new();
            capacidadOperativaRequeridaDTO.CapacidadOperativaRequeridaId = CapacidadOperativaRequeridaId;
            capacidadOperativaRequeridaDTO.DescCapacidadOperativaRequerida = Descripcion;
            capacidadOperativaRequeridaDTO.CodigoCapacidadOperativaRequerida = Codigo;
            capacidadOperativaRequeridaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capacidadOperativaRequeridaBL.ActualizarCapacidadOperativaRequerida(capacidadOperativaRequeridaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCapacidadOperativaRequerida(int CapacidadOperativaRequeridaId)
        {
            CapacidadOperativaRequeridaDTO capacidadOperativaRequeridaDTO = new();
            capacidadOperativaRequeridaDTO.CapacidadOperativaRequeridaId = CapacidadOperativaRequeridaId;
            capacidadOperativaRequeridaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capacidadOperativaRequeridaBL.EliminarCapacidadOperativaRequerida(capacidadOperativaRequeridaDTO);

            return Content(IND_OPERACION);
        }
    }
}
