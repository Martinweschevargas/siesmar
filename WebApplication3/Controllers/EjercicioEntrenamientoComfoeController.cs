using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class EjercicioEntrenamientoComfoeController : Controller
    {
        readonly ILogger<EjercicioEntrenamientoComfoeController> _logger;

        public EjercicioEntrenamientoComfoeController(ILogger<EjercicioEntrenamientoComfoeController> logger)
        {
            _logger = logger;
        }

        readonly EjercicioEntrenamientoComfoeDAO EjercicioEntrenamientoComfoeBL = new();
        Usuario usuarioBL = new();

        TipoCompetenciaTecnicaDAO tipoCompetenciaTecnicaBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Ejercicios Entrenamientos Comfoe", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<TipoCompetenciaTecnicaDTO> TipoCompetenciaTecnicaDTO = tipoCompetenciaTecnicaBL.ObtenerTipoCompetenciaTecnicas();

            return Json(new { data = TipoCompetenciaTecnicaDTO });
        }

        public JsonResult CargarDatos()
        {
            List<EjercicioEntrenamientoComfoeDTO> listaEjercicioEntrenamientoComfoees = EjercicioEntrenamientoComfoeBL.ObtenerEjercicioEntrenamientoComfoes();
            return Json(new { data = listaEjercicioEntrenamientoComfoees });
        }

        public ActionResult InsertarEjercicioEntrenamientoComfoe(string Descripcion, string Codigo, string CodigoTipoCompetenciaTecnica, string Nivel, int VigenciaDia)
        {
            var IND_OPERACION = "";
            try
            {
                EjercicioEntrenamientoComfoeDTO EjercicioEntrenamientoComfoeDTO = new();
                EjercicioEntrenamientoComfoeDTO.CodigoTipoCompetenciaTecnica = CodigoTipoCompetenciaTecnica;
                EjercicioEntrenamientoComfoeDTO.DescripcionEjercicioEntrenamiento = Descripcion;
                EjercicioEntrenamientoComfoeDTO.CodigoEjercicioEntrenamientoComfoe = Codigo;
                EjercicioEntrenamientoComfoeDTO.Nivel = Nivel;
                EjercicioEntrenamientoComfoeDTO.VigenciaDia = VigenciaDia;
                EjercicioEntrenamientoComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = EjercicioEntrenamientoComfoeBL.AgregarEjercicioEntrenamientoComfoe(EjercicioEntrenamientoComfoeDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEjercicioEntrenamientoComfoe(int EjercicioEntrenamientoComfoeId)
        {
            return Json(EjercicioEntrenamientoComfoeBL.BuscarEjercicioEntrenamientoComfoeID(EjercicioEntrenamientoComfoeId));
        }

        public ActionResult ActualizarEjercicioEntrenamientoComfoe(int EjercicioEntrenamientoComfoeId, string Descripcion, string Codigo, string CodigoTipoCompetenciaTecnica, string Nivel, int VigenciaDia)
        {
            EjercicioEntrenamientoComfoeDTO EjercicioEntrenamientoComfoeDTO = new();
            EjercicioEntrenamientoComfoeDTO.EjercicioEntrenamientoComfoeId = EjercicioEntrenamientoComfoeId;
            EjercicioEntrenamientoComfoeDTO.CodigoTipoCompetenciaTecnica = CodigoTipoCompetenciaTecnica;
            EjercicioEntrenamientoComfoeDTO.DescripcionEjercicioEntrenamiento = Descripcion;
            EjercicioEntrenamientoComfoeDTO.CodigoEjercicioEntrenamientoComfoe = Codigo;
            EjercicioEntrenamientoComfoeDTO.Nivel = Nivel;
            EjercicioEntrenamientoComfoeDTO.VigenciaDia = VigenciaDia;
            EjercicioEntrenamientoComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = EjercicioEntrenamientoComfoeBL.ActualizarEjercicioEntrenamientoComfoe(EjercicioEntrenamientoComfoeDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEjercicioEntrenamientoComfoe(int EjercicioEntrenamientoComfoeId)
        {
            EjercicioEntrenamientoComfoeDTO EjercicioEntrenamientoComfoeDTO = new();
            EjercicioEntrenamientoComfoeDTO.EjercicioEntrenamientoComfoeId = EjercicioEntrenamientoComfoeId;
            EjercicioEntrenamientoComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = EjercicioEntrenamientoComfoeBL.EliminarEjercicioEntrenamientoComfoe(EjercicioEntrenamientoComfoeDTO);

            return Content(IND_OPERACION);
        }
    }
}
