using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class EnfermedadProblemaRelacionadoController : Controller
    {
        readonly ILogger<EnfermedadProblemaRelacionadoController> _logger;

        public EnfermedadProblemaRelacionadoController(ILogger<EnfermedadProblemaRelacionadoController> logger)
        {
            _logger = logger;
        }

        readonly EnfermedadProblemaRelacionado enfermedadProblemaRelacionadoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Enfermedades Problemas Relacionados", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EnfermedadProblemaRelacionadoDTO> listaEnfermedadProblemaRelacionados = enfermedadProblemaRelacionadoBL.ObtenerEnfermedadProblemaRelacionados();
            return Json(new { data = listaEnfermedadProblemaRelacionados });
        }

        public ActionResult InsertarEnfermedadProblemaRelacionado(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                EnfermedadProblemaRelacionadoDTO enfermedadProblemaRelacionadoDTO = new();
                enfermedadProblemaRelacionadoDTO.DescEnfermedadProblemaRelacionado = Descripcion;
                enfermedadProblemaRelacionadoDTO.CodigoEnfermedadProblemaRelacionado = Codigo;
                enfermedadProblemaRelacionadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = enfermedadProblemaRelacionadoBL.AgregarEnfermedadProblemaRelacionado(enfermedadProblemaRelacionadoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEnfermedadProblemaRelacionado(int EnfermedadProblemaRelacionadoId)
        {
            return Json(enfermedadProblemaRelacionadoBL.BuscarEnfermedadProblemaRelacionadoID(EnfermedadProblemaRelacionadoId));
        }

        public ActionResult ActualizarEnfermedadProblemaRelacionado(int EnfermedadProblemaRelacionadoId, string Codigo, string Descripcion)
        {
            EnfermedadProblemaRelacionadoDTO enfermedadProblemaRelacionadoDTO = new();
            enfermedadProblemaRelacionadoDTO.EnfermedadProblemaRelacionadoId = EnfermedadProblemaRelacionadoId;
            enfermedadProblemaRelacionadoDTO.DescEnfermedadProblemaRelacionado = Descripcion;
            enfermedadProblemaRelacionadoDTO.CodigoEnfermedadProblemaRelacionado = Codigo;
            enfermedadProblemaRelacionadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = enfermedadProblemaRelacionadoBL.ActualizarEnfermedadProblemaRelacionado(enfermedadProblemaRelacionadoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEnfermedadProblemaRelacionado(int EnfermedadProblemaRelacionadoId)
        {
            EnfermedadProblemaRelacionadoDTO enfermedadProblemaRelacionadoDTO = new();
            enfermedadProblemaRelacionadoDTO.EnfermedadProblemaRelacionadoId = EnfermedadProblemaRelacionadoId;
            enfermedadProblemaRelacionadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = enfermedadProblemaRelacionadoBL.EliminarEnfermedadProblemaRelacionado(enfermedadProblemaRelacionadoDTO);

            return Content(IND_OPERACION);
        }
    }
}
