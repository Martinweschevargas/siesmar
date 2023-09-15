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
    public class UsuarioAlquilerCentroEsparcimientoController : Controller
    {
        readonly ILogger<UsuarioAlquilerCentroEsparcimientoController> _logger;

        public UsuarioAlquilerCentroEsparcimientoController(ILogger<UsuarioAlquilerCentroEsparcimientoController> logger)
        {
            _logger = logger;
        }

        readonly UsuarioAlquilerCentroEsparcimientoDAO UsuarioAlquilerCentroEsparcimientoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Usuarios Alquileres Centros Esparcimientos", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<UsuarioAlquilerCentroEsparcimientoDTO> listaUsuarioAlquilerCentroEsparcimientos = UsuarioAlquilerCentroEsparcimientoBL.ObtenerUsuarioAlquilerCentroEsparcimientos();
            return Json(new { data = listaUsuarioAlquilerCentroEsparcimientos });
        }

        public ActionResult InsertarUsuarioAlquilerCentroEsparcimiento(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                UsuarioAlquilerCentroEsparcimientoDTO UsuarioAlquilerCentroEsparcimientoDTO = new();
                UsuarioAlquilerCentroEsparcimientoDTO.DescUsuarioAlquilerCentroEsparcimiento = Descripcion;
                UsuarioAlquilerCentroEsparcimientoDTO.CodigoUsuarioAlquilerCentroEsparcimiento = Codigo;
                UsuarioAlquilerCentroEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = UsuarioAlquilerCentroEsparcimientoBL.AgregarUsuarioAlquilerCentroEsparcimiento(UsuarioAlquilerCentroEsparcimientoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarUsuarioAlquilerCentroEsparcimiento(int UsuarioAlquilerCentroEsparcimientoId)
        {
            return Json(UsuarioAlquilerCentroEsparcimientoBL.BuscarUsuarioAlquilerCentroEsparcimientoID(UsuarioAlquilerCentroEsparcimientoId));
        }

        public ActionResult ActualizarUsuarioAlquilerCentroEsparcimiento(int UsuarioAlquilerCentroEsparcimientoId, string Codigo, string Descripcion)
        {
            UsuarioAlquilerCentroEsparcimientoDTO UsuarioAlquilerCentroEsparcimientoDTO = new();
            UsuarioAlquilerCentroEsparcimientoDTO.UsuarioAlquilerCentroEsparcimientoId = UsuarioAlquilerCentroEsparcimientoId;
            UsuarioAlquilerCentroEsparcimientoDTO.DescUsuarioAlquilerCentroEsparcimiento = Descripcion;
            UsuarioAlquilerCentroEsparcimientoDTO.CodigoUsuarioAlquilerCentroEsparcimiento = Codigo;
            UsuarioAlquilerCentroEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = UsuarioAlquilerCentroEsparcimientoBL.ActualizarUsuarioAlquilerCentroEsparcimiento(UsuarioAlquilerCentroEsparcimientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarUsuarioAlquilerCentroEsparcimiento(int UsuarioAlquilerCentroEsparcimientoId)
        {
            UsuarioAlquilerCentroEsparcimientoDTO UsuarioAlquilerCentroEsparcimientoDTO = new();
            UsuarioAlquilerCentroEsparcimientoDTO.UsuarioAlquilerCentroEsparcimientoId = UsuarioAlquilerCentroEsparcimientoId;
            UsuarioAlquilerCentroEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = UsuarioAlquilerCentroEsparcimientoBL.EliminarUsuarioAlquilerCentroEsparcimiento(UsuarioAlquilerCentroEsparcimientoDTO);

            return Content(IND_OPERACION);
        }
    }
}
