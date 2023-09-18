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
    public class ClubEsparcimientoController : Controller
    {
        readonly ILogger<ClubEsparcimientoController> _logger;

        public ClubEsparcimientoController(ILogger<ClubEsparcimientoController> logger)
        {
            _logger = logger;
        }

        readonly ClubEsparcimientoDAO ClubEsparcimientoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clubes Esparcimientos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClubEsparcimientoDTO> listaClubEsparcimientos = ClubEsparcimientoBL.ObtenerClubEsparcimientos();
            return Json(new { data = listaClubEsparcimientos });
        }

        public ActionResult InsertarClubEsparcimiento(string Descripcion, string Codigo)
        {
            var IND_OPERACION = "";
            try
            {
                ClubEsparcimientoDTO ClubEsparcimientoDTO = new();
                ClubEsparcimientoDTO.DescClubEsparcimiento = Descripcion;
                ClubEsparcimientoDTO.CodigoClubEsparcimiento = Codigo;
                ClubEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ClubEsparcimientoBL.AgregarClubEsparcimiento(ClubEsparcimientoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClubEsparcimiento(int ClubEsparcimientoId)
        {
            return Json(ClubEsparcimientoBL.BuscarClubEsparcimientoID(ClubEsparcimientoId));
        }

        public ActionResult ActualizarClubEsparcimiento(int ClubEsparcimientoId, string Descripcion, string Codigo)
        {
            ClubEsparcimientoDTO ClubEsparcimientoDTO = new();
            ClubEsparcimientoDTO.ClubEsparcimientoId = ClubEsparcimientoId;
            ClubEsparcimientoDTO.DescClubEsparcimiento = Descripcion;
            ClubEsparcimientoDTO.CodigoClubEsparcimiento = Codigo;
            ClubEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ClubEsparcimientoBL.ActualizarClubEsparcimiento(ClubEsparcimientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClubEsparcimiento(int ClubEsparcimientoId)
        {
            ClubEsparcimientoDTO ClubEsparcimientoDTO = new();
            ClubEsparcimientoDTO.ClubEsparcimientoId = ClubEsparcimientoId;
            ClubEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ClubEsparcimientoBL.EliminarClubEsparcimiento(ClubEsparcimientoDTO);

            return Content(IND_OPERACION);
        }
    }
}
