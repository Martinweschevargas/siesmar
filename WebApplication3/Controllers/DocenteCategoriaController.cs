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
    public class DocenteCategoriaController : Controller
    {
        readonly ILogger<DocenteCategoriaController> _logger;

        public DocenteCategoriaController(ILogger<DocenteCategoriaController> logger)
        {
            _logger = logger;
        }

        readonly DocenteCategoriaDAO DocenteCategoriaBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Docentes Categorias", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DocenteCategoriaDTO> listaDocenteCategorias = DocenteCategoriaBL.ObtenerDocenteCategorias();
            return Json(new { data = listaDocenteCategorias });
        }

        public ActionResult InsertarDocenteCategoria(string Descripcion, string Codigo)
        {
            var IND_OPERACION = "";
            try
            {
                DocenteCategoriaDTO DocenteCategoriaDTO = new();
                DocenteCategoriaDTO.DescDocenteCategoria = Descripcion;
                DocenteCategoriaDTO.CodigoDocenteCategoria = Codigo;
                DocenteCategoriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = DocenteCategoriaBL.AgregarDocenteCategoria(DocenteCategoriaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDocenteCategoria(int DocenteCategoriaId)
        {
            return Json(DocenteCategoriaBL.BuscarDocenteCategoriaID(DocenteCategoriaId));
        }

        public ActionResult ActualizarDocenteCategoria(int DocenteCategoriaId, string Descripcion, string Codigo)
        {
            DocenteCategoriaDTO DocenteCategoriaDTO = new();
            DocenteCategoriaDTO.DocenteCategoriaId = DocenteCategoriaId;
            DocenteCategoriaDTO.DescDocenteCategoria = Descripcion;
            DocenteCategoriaDTO.CodigoDocenteCategoria = Codigo;
            DocenteCategoriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = DocenteCategoriaBL.ActualizarDocenteCategoria(DocenteCategoriaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDocenteCategoria(int DocenteCategoriaId)
        {
            DocenteCategoriaDTO DocenteCategoriaDTO = new();
            DocenteCategoriaDTO.DocenteCategoriaId = DocenteCategoriaId;
            DocenteCategoriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = DocenteCategoriaBL.EliminarDocenteCategoria(DocenteCategoriaDTO);

            return Content(IND_OPERACION);
        }
    }
}
