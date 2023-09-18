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
    public class CausalLiquidacionController : Controller
    {
        readonly ILogger<CausalLiquidacionController> _logger;

        public CausalLiquidacionController(ILogger<CausalLiquidacionController> logger)
        {
            _logger = logger;
        }

        readonly CausalLiquidacionDAO causalLiquidacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Causales Liquidaciones", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CausalLiquidacionDTO> listaCausalLiquidacions = causalLiquidacionBL.ObtenerCausalLiquidacions();
            return Json(new { data = listaCausalLiquidacions });
        }

        public ActionResult InsertarCausalLiquidacion(string DescCausalLiquidacion, string CodigoCausalLiquidacion)
        {
            var IND_OPERACION="";
            try
            {
                CausalLiquidacionDTO causalLiquidacionDTO = new();
                causalLiquidacionDTO.DescCausalLiquidacion = DescCausalLiquidacion;
                causalLiquidacionDTO.CodigoCausalLiquidacion = CodigoCausalLiquidacion;
                causalLiquidacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = causalLiquidacionBL.AgregarCausalLiquidacion(causalLiquidacionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCausalLiquidacion(int CausalLiquidacionId)
        {
            return Json(causalLiquidacionBL.BuscarCausalLiquidacionID(CausalLiquidacionId));
        }

        public ActionResult ActualizarCausalLiquidacion(int CausalLiquidacionId, string DescCausalLiquidacion, string CodigoCausalLiquidacion)
        {
            CausalLiquidacionDTO causalLiquidacionDTO = new();
            causalLiquidacionDTO.CausalLiquidacionId = CausalLiquidacionId;
            causalLiquidacionDTO.DescCausalLiquidacion = DescCausalLiquidacion;
            causalLiquidacionDTO.CodigoCausalLiquidacion = CodigoCausalLiquidacion;
            causalLiquidacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = causalLiquidacionBL.ActualizarCausalLiquidacion(causalLiquidacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCausalLiquidacion(int CausalLiquidacionId)
        {
            CausalLiquidacionDTO causalLiquidacionDTO = new();
            causalLiquidacionDTO.CausalLiquidacionId = CausalLiquidacionId;
            causalLiquidacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = causalLiquidacionBL.EliminarCausalLiquidacion(causalLiquidacionDTO);

            return Content(IND_OPERACION);
        }
    }
}
