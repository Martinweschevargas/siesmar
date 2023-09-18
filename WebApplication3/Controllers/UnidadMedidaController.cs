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
    public class UnidadMedidaController : Controller
    {
        readonly ILogger<UnidadMedidaController> _logger;

        public UnidadMedidaController(ILogger<UnidadMedidaController> logger)
        {
            _logger = logger;
        }

        readonly UnidadMedidaDAO unidadMedidaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Unidades Medidas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<UnidadMedidaDTO> listaUnidadMedidas = unidadMedidaBL.ObtenerUnidadMedidas();
            return Json(new { data = listaUnidadMedidas });
        }

        public ActionResult InsertarUnidadMedida(string Codigo, string Abrev, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                UnidadMedidaDTO unidadMedidaDTO = new();
                unidadMedidaDTO.DescUnidadMedida = Descripcion;
                unidadMedidaDTO.CodigoUnidadMedida = Codigo;
                unidadMedidaDTO.AbrevUnidadMedida = Abrev;
                unidadMedidaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = unidadMedidaBL.AgregarUnidadMedida(unidadMedidaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarUnidadMedida(int UnidadMedidaId)
        {
            return Json(unidadMedidaBL.BuscarUnidadMedidaID(UnidadMedidaId));
        }

        public ActionResult ActualizarUnidadMedida(int UnidadMedidaId, string Codigo, string Abrev, string Descripcion)
        {
            UnidadMedidaDTO unidadMedidaDTO = new();
            unidadMedidaDTO.UnidadMedidaId = UnidadMedidaId;
            unidadMedidaDTO.CodigoUnidadMedida = Codigo;
            unidadMedidaDTO.DescUnidadMedida = Descripcion;
            unidadMedidaDTO.AbrevUnidadMedida = Abrev;
            unidadMedidaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadMedidaBL.ActualizarUnidadMedida(unidadMedidaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarUnidadMedida(int UnidadMedidaId)
        {
            UnidadMedidaDTO unidadMedidaDTO = new();
            unidadMedidaDTO.UnidadMedidaId = UnidadMedidaId;
            unidadMedidaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadMedidaBL.EliminarUnidadMedida(unidadMedidaDTO);

            return Content(IND_OPERACION);
        }
    }
}
