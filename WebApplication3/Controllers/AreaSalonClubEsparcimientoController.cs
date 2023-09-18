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
    public class AreaSalonClubEsparcimientoController : Controller
    {
        readonly ILogger<AreaSalonClubEsparcimientoController> _logger;

        public AreaSalonClubEsparcimientoController(ILogger<AreaSalonClubEsparcimientoController> logger)
        {
            _logger = logger;
        }

        readonly AreaSalonClubEsparcimientoDAO AreaSalonClubEsparcimientoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Areas Salones Clubes Esparcimientos", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<AreaSalonClubEsparcimientoDTO> listaAreaSalonClubEsparcimientos = AreaSalonClubEsparcimientoBL.ObtenerAreaSalonClubEsparcimientos();
            return Json(new { data = listaAreaSalonClubEsparcimientos });
        }

        public ActionResult InsertarAreaSalonClubEsparcimiento(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                AreaSalonClubEsparcimientoDTO AreaSalonClubEsparcimientoDTO = new();
                AreaSalonClubEsparcimientoDTO.DescAreaSalonClubEsparcimiento = Descripcion;
                AreaSalonClubEsparcimientoDTO.CodigoAreaSalonClubEsparcimiento = Codigo;
                AreaSalonClubEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = AreaSalonClubEsparcimientoBL.AgregarAreaSalonClubEsparcimiento(AreaSalonClubEsparcimientoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAreaSalonClubEsparcimiento(int AreaSalonClubEsparcimientoId)
        {
            return Json(AreaSalonClubEsparcimientoBL.BuscarAreaSalonClubEsparcimientoID(AreaSalonClubEsparcimientoId));
        }

        public ActionResult ActualizarAreaSalonClubEsparcimiento(int AreaSalonClubEsparcimientoId, string Codigo, string Descripcion)
        {
            AreaSalonClubEsparcimientoDTO AreaSalonClubEsparcimientoDTO = new();
            AreaSalonClubEsparcimientoDTO.AreaSalonClubEsparcimientoId = AreaSalonClubEsparcimientoId;
            AreaSalonClubEsparcimientoDTO.DescAreaSalonClubEsparcimiento = Descripcion;
            AreaSalonClubEsparcimientoDTO.CodigoAreaSalonClubEsparcimiento = Codigo;
            AreaSalonClubEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AreaSalonClubEsparcimientoBL.ActualizarAreaSalonClubEsparcimiento(AreaSalonClubEsparcimientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAreaSalonClubEsparcimiento(int AreaSalonClubEsparcimientoId)
        {
            AreaSalonClubEsparcimientoDTO AreaSalonClubEsparcimientoDTO = new();
            AreaSalonClubEsparcimientoDTO.AreaSalonClubEsparcimientoId = AreaSalonClubEsparcimientoId;
            AreaSalonClubEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AreaSalonClubEsparcimientoBL.EliminarAreaSalonClubEsparcimiento(AreaSalonClubEsparcimientoDTO);

            return Content(IND_OPERACION);
        }
    }
}
