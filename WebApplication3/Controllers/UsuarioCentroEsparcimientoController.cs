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
    public class UsuarioCentroEsparcimientoController : Controller
    {
        readonly ILogger<UsuarioCentroEsparcimientoController> _logger;

        public UsuarioCentroEsparcimientoController(ILogger<UsuarioCentroEsparcimientoController> logger)
        {
            _logger = logger;
        }

        readonly UsuarioCentroEsparcimientoDAO UsuarioCentroEsparcimientoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Usuarios Centros Esparcimientos", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<UsuarioCentroEsparcimientoDTO> listaUsuarioCentroEsparcimientos = UsuarioCentroEsparcimientoBL.ObtenerUsuarioCentroEsparcimientos();
            return Json(new { data = listaUsuarioCentroEsparcimientos });
        }

        public ActionResult InsertarUsuarioCentroEsparcimiento(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                UsuarioCentroEsparcimientoDTO UsuarioCentroEsparcimientoDTO = new();
                UsuarioCentroEsparcimientoDTO.DescUsuarioCentroEsparcimiento = Descripcion;
                UsuarioCentroEsparcimientoDTO.CodigoUsuarioCentroEsparcimiento = Codigo;
                UsuarioCentroEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = UsuarioCentroEsparcimientoBL.AgregarUsuarioCentroEsparcimiento(UsuarioCentroEsparcimientoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarUsuarioCentroEsparcimiento(int UsuarioCentroEsparcimientoId)
        {
            return Json(UsuarioCentroEsparcimientoBL.BuscarUsuarioCentroEsparcimientoID(UsuarioCentroEsparcimientoId));
        }

        public ActionResult ActualizarUsuarioCentroEsparcimiento(int UsuarioCentroEsparcimientoId, string Codigo, string Descripcion)
        {
            UsuarioCentroEsparcimientoDTO UsuarioCentroEsparcimientoDTO = new();
            UsuarioCentroEsparcimientoDTO.UsuarioCentroEsparcimientoId = UsuarioCentroEsparcimientoId;
            UsuarioCentroEsparcimientoDTO.DescUsuarioCentroEsparcimiento = Descripcion;
            UsuarioCentroEsparcimientoDTO.CodigoUsuarioCentroEsparcimiento = Codigo;
            UsuarioCentroEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = UsuarioCentroEsparcimientoBL.ActualizarUsuarioCentroEsparcimiento(UsuarioCentroEsparcimientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarUsuarioCentroEsparcimiento(int UsuarioCentroEsparcimientoId)
        {
            UsuarioCentroEsparcimientoDTO UsuarioCentroEsparcimientoDTO = new();
            UsuarioCentroEsparcimientoDTO.UsuarioCentroEsparcimientoId = UsuarioCentroEsparcimientoId;
            UsuarioCentroEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = UsuarioCentroEsparcimientoBL.EliminarUsuarioCentroEsparcimiento(UsuarioCentroEsparcimientoDTO);

            return Content(IND_OPERACION);
        }
    }
}
