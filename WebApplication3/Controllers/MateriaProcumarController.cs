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
    public class MateriaProcumarController : Controller
    {
        readonly ILogger<MateriaProcumarController> _logger;

        public MateriaProcumarController(ILogger<MateriaProcumarController> logger)
        {
            _logger = logger;
        }

        readonly MateriaProcumarDAO materiaProcumarBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Materias Procumar", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MateriaProcumarDTO> listaMateriaProcumars = materiaProcumarBL.ObtenerMateriaProcumars();
            return Json(new { data = listaMateriaProcumars });
        }

        public ActionResult InsertarMateriaProcumar(string DescMateriaProcumar, string CodigoMateriaProcumar)
        {
            var IND_OPERACION = "";
            try
            {
                MateriaProcumarDTO materiaProcumarDTO = new();
                materiaProcumarDTO.DescMateriaProcumar = DescMateriaProcumar;
                materiaProcumarDTO.CodigoMateriaProcumar = CodigoMateriaProcumar;
                materiaProcumarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = materiaProcumarBL.AgregarMateriaProcumar(materiaProcumarDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMateriaProcumar(int MateriaProcumarId)
        {
            return Json(materiaProcumarBL.BuscarMateriaProcumarID(MateriaProcumarId));
        }

        public ActionResult ActualizarMateriaProcumar(int MateriaProcumarId, string DescMateriaProcumar, string CodigoMateriaProcumar)
        {
            MateriaProcumarDTO materiaProcumarDTO = new();
            materiaProcumarDTO.MateriaProcumarId = MateriaProcumarId;
            materiaProcumarDTO.DescMateriaProcumar = DescMateriaProcumar;
            materiaProcumarDTO.CodigoMateriaProcumar = CodigoMateriaProcumar;
            materiaProcumarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = materiaProcumarBL.ActualizarMateriaProcumar(materiaProcumarDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMateriaProcumar(int MateriaProcumarId)
        {
            MateriaProcumarDTO materiaProcumarDTO = new();
            materiaProcumarDTO.MateriaProcumarId = MateriaProcumarId;
            materiaProcumarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = materiaProcumarBL.EliminarMateriaProcumar(materiaProcumarDTO);

            return Content(IND_OPERACION);
        }
    }
}
