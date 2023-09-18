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
    public class ResultadoEjercicioEducativoController : Controller
    {
        readonly ILogger<ResultadoEjercicioEducativoController> _logger;

        public ResultadoEjercicioEducativoController(ILogger<ResultadoEjercicioEducativoController> logger)
        {
            _logger = logger;
        }

        readonly ResultadoEjercicioEducativoDAO ResultadoEjercicioEducativoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Resultados Ejercicios Educativos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ResultadoEjercicioEducativoDTO> listaResultadoEjercicioEducativos = ResultadoEjercicioEducativoBL.ObtenerResultadoEjercicioEducativos();
            return Json(new { data = listaResultadoEjercicioEducativos });
        }

        public ActionResult InsertarResultadoEjercicioEducativo(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ResultadoEjercicioEducativoDTO ResultadoEjercicioEducativoDTO = new();
                ResultadoEjercicioEducativoDTO.DescResultadoEjercicioEducativo = Descripcion;
                ResultadoEjercicioEducativoDTO.CodigoResultadoEjercicioEducativo = Codigo;
                ResultadoEjercicioEducativoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = ResultadoEjercicioEducativoBL.AgregarResultadoEjercicioEducativo(ResultadoEjercicioEducativoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarResultadoEjercicioEducativo(int ResultadoEjercicioEducativoId)
        {
            return Json(ResultadoEjercicioEducativoBL.BuscarResultadoEjercicioEducativoID(ResultadoEjercicioEducativoId));
        }

        public ActionResult ActualizarResultadoEjercicioEducativo(int ResultadoEjercicioEducativoId, string Codigo, string Descripcion)
        {
            ResultadoEjercicioEducativoDTO ResultadoEjercicioEducativoDTO = new();
            ResultadoEjercicioEducativoDTO.ResultadoEjercicioEducativoId = ResultadoEjercicioEducativoId;
            ResultadoEjercicioEducativoDTO.DescResultadoEjercicioEducativo = Descripcion;
            ResultadoEjercicioEducativoDTO.CodigoResultadoEjercicioEducativo = Codigo;
            ResultadoEjercicioEducativoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ResultadoEjercicioEducativoBL.ActualizarResultadoEjercicioEducativo(ResultadoEjercicioEducativoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarResultadoEjercicioEducativo(int ResultadoEjercicioEducativoId)
        {
            ResultadoEjercicioEducativoDTO ResultadoEjercicioEducativoDTO = new();
            ResultadoEjercicioEducativoDTO.ResultadoEjercicioEducativoId = ResultadoEjercicioEducativoId;
            ResultadoEjercicioEducativoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ResultadoEjercicioEducativoBL.EliminarResultadoEjercicioEducativo(ResultadoEjercicioEducativoDTO);

            return Content(IND_OPERACION);
        }
    }
}
