using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using MathNet.Numerics.Distributions;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class AreaClubEsparcimientoController : Controller
    {
        readonly ILogger<AreaClubEsparcimientoController> _logger;

        public AreaClubEsparcimientoController(ILogger<AreaClubEsparcimientoController> logger)
        {
            _logger = logger;
        }

        readonly AreaClubEsparcimiento areaClubEsparcimientoBL = new();
        Usuario usuarioBL = new();

        ClubEsparcimiento clubEsparcimientoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Areas Clubes Esparcimientos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<ClubEsparcimientoDTO> clubEsparcimientoDTO = clubEsparcimientoBL.ObtenerClubEsparcimientos();

            return Json(new { data = clubEsparcimientoDTO });
        }

        public JsonResult CargarDatos()
        {
            List<AreaClubEsparcimientoDTO> listaAreaClubEsparcimientoes = areaClubEsparcimientoBL.ObtenerAreaClubEsparcimientos();
            return Json(new { data = listaAreaClubEsparcimientoes });
        }

        public ActionResult InsertarAreaClubEsparcimiento(string Descripcion, int ClubEsparcimientoId)
        {
            var IND_OPERACION = "";
            try
            {
                AreaClubEsparcimientoDTO areaClubEsparcimientoDTO = new();
                areaClubEsparcimientoDTO.DescAreaClubEsparcimiento = Descripcion;
                areaClubEsparcimientoDTO.ClubEsparcimientoId = ClubEsparcimientoId;
                areaClubEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = areaClubEsparcimientoBL.AgregarAreaClubEsparcimiento(areaClubEsparcimientoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAreaClubEsparcimiento(int AreaClubEsparcimientoId)
        {
            return Json(areaClubEsparcimientoBL.BuscarAreaClubEsparcimientoID(AreaClubEsparcimientoId));
        }

        public ActionResult ActualizarAreaClubEsparcimiento(int AreaClubEsparcimientoId, string Descripcion, int ClubEsparcimientoId)
        {
            AreaClubEsparcimientoDTO areaClubEsparcimientoDTO = new();
            areaClubEsparcimientoDTO.AreaClubEsparcimientoId = AreaClubEsparcimientoId;
            areaClubEsparcimientoDTO.DescAreaClubEsparcimiento = Descripcion;
            areaClubEsparcimientoDTO.ClubEsparcimientoId = ClubEsparcimientoId;
            areaClubEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = areaClubEsparcimientoBL.ActualizarAreaClubEsparcimiento(areaClubEsparcimientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAreaClubEsparcimiento(int AreaClubEsparcimientoId)
        {
            AreaClubEsparcimientoDTO areaClubEsparcimientoDTO = new();
            areaClubEsparcimientoDTO.AreaClubEsparcimientoId = AreaClubEsparcimientoId;
            areaClubEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = areaClubEsparcimientoBL.EliminarAreaClubEsparcimiento(areaClubEsparcimientoDTO);

            return Content(IND_OPERACION);
        }
    }
}
