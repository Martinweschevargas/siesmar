using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class CarreraUniversitariaController : Controller
    {
        readonly ILogger<CarreraUniversitariaController> _logger;

        public CarreraUniversitariaController(ILogger<CarreraUniversitariaController> logger)
        {
            _logger = logger;
        }

        readonly CarreraUniversitariaDAO carreraUniversitariaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CarreraUniversitariaDTO> listaCarreraUniversitarias = carreraUniversitariaBL.ObtenerCarreraUniversitarias();
            return Json(new { data = listaCarreraUniversitarias });
        }

        public ActionResult InsertarCarreraUniversitaria(string DescCarreraUniversitaria, string CodigoCarreraUniversitaria)
        {
            CarreraUniversitariaDTO carreraUniversitariaDTO = new();
            carreraUniversitariaDTO.DescCarreraUniversitaria = DescCarreraUniversitaria;
            carreraUniversitariaDTO.CodigoCarreraUniversitaria = CodigoCarreraUniversitaria;
            carreraUniversitariaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = carreraUniversitariaBL.AgregarCarreraUniversitaria(carreraUniversitariaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCarreraUniversitaria(int CarreraUniversitariaId)
        {
            return Json(carreraUniversitariaBL.BuscarCarreraUniversitariaID(CarreraUniversitariaId));
        }

        public ActionResult ActualizarCarreraUniversitaria(int CarreraUniversitariaId, string DescCarreraUniversitaria, string CodigoCarreraUniversitaria)
        {
            CarreraUniversitariaDTO carreraUniversitariaDTO = new();
            carreraUniversitariaDTO.CarreraUniversitariaId = CarreraUniversitariaId;
            carreraUniversitariaDTO.DescCarreraUniversitaria = DescCarreraUniversitaria;
            carreraUniversitariaDTO.CodigoCarreraUniversitaria = CodigoCarreraUniversitaria;
            carreraUniversitariaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = carreraUniversitariaBL.ActualizarCarreraUniversitaria(carreraUniversitariaDTO);

            return Content(IND_OPERACION);
        }
        public ActionResult EliminarCarreraUniversitaria(int CarreraUniversitariaId)
        {
            CarreraUniversitariaDTO carreraUniversitariaDTO = new();
            carreraUniversitariaDTO.CarreraUniversitariaId = CarreraUniversitariaId;
            carreraUniversitariaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = carreraUniversitariaBL.EliminarCarreraUniversitaria(carreraUniversitariaDTO);

            return Content(IND_OPERACION);
        }


    }
}
