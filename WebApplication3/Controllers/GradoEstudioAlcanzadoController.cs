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
    public class GradoEstudioAlcanzadoController : Controller
    {
        readonly ILogger<GradoEstudioAlcanzadoController> _logger;

        public GradoEstudioAlcanzadoController(ILogger<GradoEstudioAlcanzadoController> logger)
        {
            _logger = logger;
        }

        readonly GradoEstudioAlcanzadoDAO gradoEstudioAlcanzadoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Grados Estudios Alcanzados", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<GradoEstudioAlcanzadoDTO> listaGradoEstudioAlcanzados = gradoEstudioAlcanzadoBL.ObtenerGradoEstudioAlcanzados();
            return Json(new { data = listaGradoEstudioAlcanzados });
        }

        public ActionResult InsertarGradoEstudioAlcanzado(string DescGradoEstudioAlcanzado, string CodigoGradoEstudioAlcanzado)
        {
            var IND_OPERACION = "";
            try
            {
                GradoEstudioAlcanzadoDTO gradoEstudioAlcanzadoDTO = new();
                gradoEstudioAlcanzadoDTO.DescGradoEstudioAlcanzado = DescGradoEstudioAlcanzado;
                gradoEstudioAlcanzadoDTO.CodigoGradoEstudioAlcanzado = CodigoGradoEstudioAlcanzado;
                gradoEstudioAlcanzadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = gradoEstudioAlcanzadoBL.AgregarGradoEstudioAlcanzado(gradoEstudioAlcanzadoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarGradoEstudioAlcanzado(int GradoEstudioAlcanzadoId)
        {
            return Json(gradoEstudioAlcanzadoBL.BuscarGradoEstudioAlcanzadoID(GradoEstudioAlcanzadoId));
        }

        public ActionResult ActualizarGradoEstudioAlcanzado(int GradoEstudioAlcanzadoId, string DescGradoEstudioAlcanzado, string CodigoGradoEstudioAlcanzado)
        {
            GradoEstudioAlcanzadoDTO gradoEstudioAlcanzadoDTO = new();
            gradoEstudioAlcanzadoDTO.GradoEstudioAlcanzadoId = GradoEstudioAlcanzadoId;
            gradoEstudioAlcanzadoDTO.DescGradoEstudioAlcanzado = DescGradoEstudioAlcanzado;
            gradoEstudioAlcanzadoDTO.CodigoGradoEstudioAlcanzado = CodigoGradoEstudioAlcanzado;
            gradoEstudioAlcanzadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = gradoEstudioAlcanzadoBL.ActualizarGradoEstudioAlcanzado(gradoEstudioAlcanzadoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarGradoEstudioAlcanzado(int GradoEstudioAlcanzadoId)
        {
            GradoEstudioAlcanzadoDTO gradoEstudioAlcanzadoDTO = new();
            gradoEstudioAlcanzadoDTO.GradoEstudioAlcanzadoId = GradoEstudioAlcanzadoId;
            gradoEstudioAlcanzadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = gradoEstudioAlcanzadoBL.EliminarGradoEstudioAlcanzado(gradoEstudioAlcanzadoDTO);

            return Content(IND_OPERACION);
        }
    }
}
