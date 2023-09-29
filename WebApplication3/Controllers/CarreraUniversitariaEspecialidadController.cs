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
    public class CarreraUniversitariaEspecialidadController : Controller
    {
        readonly ILogger<CarreraUniversitariaEspecialidadController> _logger;

        public CarreraUniversitariaEspecialidadController(ILogger<CarreraUniversitariaEspecialidadController> logger)
        {
            _logger = logger;
        }


        readonly CarreraUniversitariaEspecialidadDAO carreraUniversitariaEspecialidadBL = new();
        Usuario usuarioBL = new();
        CarreraUniversitariaDAO carreraUniversitariaBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Carreras Universitarias Especialidades", FromController = typeof(HomeController))]

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<CarreraUniversitariaDTO> carreraUniversitariaDTO = carreraUniversitariaBL.ObtenerCarreraUniversitarias();

            return Json(new { data = carreraUniversitariaDTO });
        }

        public JsonResult CargarDatos()
        {
            List<CarreraUniversitariaEspecialidadDTO> listaCarreraUniversitariaEspecialidads = carreraUniversitariaEspecialidadBL.ObtenerCarreraUniversitariaEspecialidads();
            return Json(new { data = listaCarreraUniversitariaEspecialidads });
        }

        public ActionResult InsertarCarreraUniversitariaEspecialidad(string DescCarreraUniversitariaEspecialidad, string CodigoCarreraUniversitariaEspecialidad, string CodigoCarreraUniversitaria)
        {
            CarreraUniversitariaEspecialidadDTO carreraUniversitariaEspecialidadDTO = new();
            carreraUniversitariaEspecialidadDTO.DescCarreraUniversitariaEspecialidad = DescCarreraUniversitariaEspecialidad;
            carreraUniversitariaEspecialidadDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            carreraUniversitariaEspecialidadDTO.CodigoCarreraUniversitaria = CodigoCarreraUniversitaria;
            carreraUniversitariaEspecialidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = carreraUniversitariaEspecialidadBL.AgregarCarreraUniversitariaEspecialidad(carreraUniversitariaEspecialidadDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCarreraUniversitariaEspecialidad(int CarreraUniversitariaEspecialidadId)
        {
            return Json(carreraUniversitariaEspecialidadBL.BuscarCarreraUniversitariaEspecialidadID(CarreraUniversitariaEspecialidadId));
        }

        public ActionResult ActualizarCarreraUniversitariaEspecialidad(int CarreraUniversitariaEspecialidadId, string DescCarreraUniversitariaEspecialidad, string CodigoCarreraUniversitariaEspecialidad, string CodigoCarreraUniversitaria)
        {
            CarreraUniversitariaEspecialidadDTO carreraUniversitariaEspecialidadDTO = new();
            carreraUniversitariaEspecialidadDTO.CarreraUniversitariaEspecialidadId = CarreraUniversitariaEspecialidadId;
            carreraUniversitariaEspecialidadDTO.DescCarreraUniversitariaEspecialidad = DescCarreraUniversitariaEspecialidad;
            carreraUniversitariaEspecialidadDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            carreraUniversitariaEspecialidadDTO.CodigoCarreraUniversitaria = CodigoCarreraUniversitaria;
            carreraUniversitariaEspecialidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = carreraUniversitariaEspecialidadBL.ActualizarCarreraUniversitariaEspecialidad(carreraUniversitariaEspecialidadDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCarreraUniversitariaEspecialidad(int CarreraUniversitariaEspecialidadId)
        {
            CarreraUniversitariaEspecialidadDTO carreraUniversitariaEspecialidadDTO = new();
            carreraUniversitariaEspecialidadDTO.CarreraUniversitariaEspecialidadId = CarreraUniversitariaEspecialidadId;
            carreraUniversitariaEspecialidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = carreraUniversitariaEspecialidadBL.EliminarCarreraUniversitariaEspecialidad(carreraUniversitariaEspecialidadDTO);

            return Content(IND_OPERACION);
        }
    }

  }

