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
    public class CasoExcepcionalController : Controller
    {
        readonly ILogger<CasoExcepcionalController> _logger;

        public CasoExcepcionalController(ILogger<CasoExcepcionalController> logger)
        {
            _logger = logger;
        }

        readonly CasoExcepcional CasoExcepcionalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Casos Excepcionales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CasoExcepcionalDTO> listaCasoExcepcionals = CasoExcepcionalBL.ObtenerCasoExcepcionals();
            return Json(new { data = listaCasoExcepcionals });
        }

        public ActionResult InsertarCasoExcepcional(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CasoExcepcionalDTO CasoExcepcionalDTO = new();
                CasoExcepcionalDTO.DescCasoExcepcional = Descripcion;
                CasoExcepcionalDTO.CodigoCasoExcepcional = Codigo;
                CasoExcepcionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = CasoExcepcionalBL.AgregarCasoExcepcional(CasoExcepcionalDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCasoExcepcional(int CasoExcepcionalId)
        {
            return Json(CasoExcepcionalBL.BuscarCasoExcepcionalID(CasoExcepcionalId));
        }

        public ActionResult ActualizarCasoExcepcional(int CasoExcepcionalId, string Codigo, string Descripcion)
        {
            CasoExcepcionalDTO CasoExcepcionalDTO = new();
            CasoExcepcionalDTO.CasoExcepcionalId = CasoExcepcionalId;
            CasoExcepcionalDTO.DescCasoExcepcional = Descripcion;
            CasoExcepcionalDTO.CodigoCasoExcepcional = Codigo;
            CasoExcepcionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CasoExcepcionalBL.ActualizarCasoExcepcional(CasoExcepcionalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCasoExcepcional(int CasoExcepcionalId)
        {
            CasoExcepcionalDTO CasoExcepcionalDTO = new();
            CasoExcepcionalDTO.CasoExcepcionalId = CasoExcepcionalId;
            CasoExcepcionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CasoExcepcionalBL.EliminarCasoExcepcional(CasoExcepcionalDTO);

            return Content(IND_OPERACION);
        }
    }
}
