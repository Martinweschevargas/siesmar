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
    public class TipoEjercicioController : Controller
    {
        readonly ILogger<TipoEjercicioController> _logger;

        public TipoEjercicioController(ILogger<TipoEjercicioController> logger)
        {
            _logger = logger;
        }

        readonly TipoEjercicioDAO tipoEjercicioBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Ejercicios", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoEjercicioDTO> listaTipoEjercicios = tipoEjercicioBL.ObtenerTipoEjercicios();
            return Json(new { data = listaTipoEjercicios });
        }

        public ActionResult InsertarTipoEjercicio(string DescTipoEjercicio, string CodigoTipoEjercicio)
        {
            TipoEjercicioDTO tipoEjercicioDTO = new();
            tipoEjercicioDTO.DescTipoEjercicio = DescTipoEjercicio;
            tipoEjercicioDTO.CodigoTipoEjercicio = CodigoTipoEjercicio;
            tipoEjercicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoEjercicioBL.AgregarTipoEjercicio(tipoEjercicioDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoEjercicio(int TipoEjercicioId)
        {
            return Json(tipoEjercicioBL.BuscarTipoEjercicioID(TipoEjercicioId));
        }

        public ActionResult ActualizarTipoEjercicio(int TipoEjercicioId, string DescTipoEjercicio, string CodigoTipoEjercicio)
        {
            TipoEjercicioDTO tipoEjercicioDTO = new();
            tipoEjercicioDTO.TipoEjercicioId = TipoEjercicioId;
            tipoEjercicioDTO.DescTipoEjercicio = DescTipoEjercicio;
            tipoEjercicioDTO.CodigoTipoEjercicio = CodigoTipoEjercicio;
            tipoEjercicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoEjercicioBL.ActualizarTipoEjercicio(tipoEjercicioDTO);

            return Content(IND_OPERACION);
        }



        public ActionResult EliminarTipoEjercicio(int TipoEjercicioId)
        {
            TipoEjercicioDTO tipoEjercicioDTO = new();
            tipoEjercicioDTO.TipoEjercicioId = TipoEjercicioId;
            tipoEjercicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoEjercicioBL.EliminarTipoEjercicio(tipoEjercicioDTO);

            return Content(IND_OPERACION);
        }
    }
}
