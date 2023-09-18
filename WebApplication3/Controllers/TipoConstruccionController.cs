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
    public class TipoConstruccionController : Controller
    {
        readonly ILogger<TipoConstruccionController> _logger;

        public TipoConstruccionController(ILogger<TipoConstruccionController> logger)
        {
            _logger = logger;
        }

        readonly TipoConstruccionDAO tipoConstruccionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Construcciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoConstruccionDTO> listaTipoConstruccions = tipoConstruccionBL.ObtenerTipoConstruccions();
            return Json(new { data = listaTipoConstruccions });
        }

        public ActionResult InsertarTipoConstruccion(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoConstruccionDTO tipoConstruccionDTO = new();
                tipoConstruccionDTO.DescTipoConstruccion = Descripcion;
                tipoConstruccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoConstruccionBL.AgregarTipoConstruccion(tipoConstruccionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoConstruccion(int TipoConstruccionId)
        {
            return Json(tipoConstruccionBL.BuscarTipoConstruccionID(TipoConstruccionId));
        }

        public ActionResult ActualizarTipoConstruccion(int TipoConstruccionId, string Descripcion)
        {
            TipoConstruccionDTO tipoConstruccionDTO = new();
            tipoConstruccionDTO.TipoConstruccionId = TipoConstruccionId;
            tipoConstruccionDTO.DescTipoConstruccion = Descripcion;
            tipoConstruccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoConstruccionBL.ActualizarTipoConstruccion(tipoConstruccionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoConstruccion(int TipoConstruccionId)
        {
            TipoConstruccionDTO tipoConstruccionDTO = new();
            tipoConstruccionDTO.TipoConstruccionId = TipoConstruccionId;
            tipoConstruccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoConstruccionBL.EliminarTipoConstruccion(tipoConstruccionDTO);

            return Content(IND_OPERACION);
        }
    }
}
