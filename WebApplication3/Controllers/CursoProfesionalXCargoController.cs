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
    public class CursoProfesionalXCargoController : Controller
    {
        readonly ILogger<CursoProfesionalXCargoController> _logger;

        public CursoProfesionalXCargoController(ILogger<CursoProfesionalXCargoController> logger)
        {
            _logger = logger;
        }

        readonly CursoProfesionalXCargoDAO CursoProfesionalXCargoBL = new();
        Usuario usuarioBL = new();

        TipoPersonalMilitar tipoPersonalMilitar = new();
        Cargo cargo = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Cursos Profesionales X Cargos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombsTipo()
        {

            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitar.ObtenerTipoPersonalMilitars();

            return Json(new { data = tipoPersonalMilitarDTO });
        }

        [HttpGet]
        public IActionResult cargaCombsCargo()
        {

            List<CargoDTO> cargoDTO = cargo.ObtenerCargos();

            return Json(new { data = cargoDTO });
        }

        public JsonResult CargarDatos()
        {
            List<CursoProfesionalXCargoDTO> listaCursoProfesionalXCargoes = CursoProfesionalXCargoBL.ObtenerCursoProfesionalXCargos();
            return Json(new { data = listaCursoProfesionalXCargoes });
        }

        public ActionResult InsertarCursoProfesionalXCargo(string Descripcion, int TipoPersonalMilitarId, int Cargo)
        {
            var IND_OPERACION = "";
            try
            {
                CursoProfesionalXCargoDTO CursoProfesionalXCargoDTO = new();
                CursoProfesionalXCargoDTO.DescCursoCapacitacion = Descripcion;
                CursoProfesionalXCargoDTO.TipoPersonalMilitarId = TipoPersonalMilitarId;
                CursoProfesionalXCargoDTO.CargoId = Cargo;
                CursoProfesionalXCargoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = CursoProfesionalXCargoBL.AgregarCursoProfesionalXCargo(CursoProfesionalXCargoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCursoProfesionalXCargo(int CursoProfesionalXCargoId)
        {
            return Json(CursoProfesionalXCargoBL.BuscarCursoProfesionalXCargoID(CursoProfesionalXCargoId));
        }

        public ActionResult ActualizarCursoProfesionalXCargo(int CursoProfesionalXCargoId, string Descripcion, int TipoPersonalMilitarId, int Cargo)
        {
            CursoProfesionalXCargoDTO CursoProfesionalXCargoDTO = new();
            CursoProfesionalXCargoDTO.CursoProfesionalXCargoId = CursoProfesionalXCargoId;
            CursoProfesionalXCargoDTO.DescCursoCapacitacion = Descripcion;
            CursoProfesionalXCargoDTO.TipoPersonalMilitarId = TipoPersonalMilitarId;
            CursoProfesionalXCargoDTO.CargoId = Cargo;
            CursoProfesionalXCargoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CursoProfesionalXCargoBL.ActualizarCursoProfesionalXCargo(CursoProfesionalXCargoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCursoProfesionalXCargo(int CursoProfesionalXCargoId)
        {
            CursoProfesionalXCargoDTO CursoProfesionalXCargoDTO = new();
            CursoProfesionalXCargoDTO.CursoProfesionalXCargoId = CursoProfesionalXCargoId;
            CursoProfesionalXCargoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CursoProfesionalXCargoBL.EliminarCursoProfesionalXCargo(CursoProfesionalXCargoDTO);

            return Content(IND_OPERACION);
        }
    }
}
