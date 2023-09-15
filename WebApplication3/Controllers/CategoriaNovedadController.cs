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
    public class CategoriaNovedadController : Controller
    {
        readonly ILogger<CategoriaNovedadController> _logger;

        public CategoriaNovedadController(ILogger<CategoriaNovedadController> logger)
        {
            _logger = logger;
        }

        readonly CategoriaNovedadDAO CategoriaNovedadBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Categorias Novedades", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CategoriaNovedadDTO> listaCategoriaNovedads = CategoriaNovedadBL.ObtenerCategoriaNovedads();
            return Json(new { data = listaCategoriaNovedads });
        }

        public ActionResult InsertarCategoriaNovedad(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CategoriaNovedadDTO CategoriaNovedadDTO = new();
                CategoriaNovedadDTO.DescCategoriaNovedad = Descripcion;
                CategoriaNovedadDTO.CodigoCategoriaNovedad = Codigo;
                CategoriaNovedadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = CategoriaNovedadBL.AgregarCategoriaNovedad(CategoriaNovedadDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCategoriaNovedad(int CategoriaNovedadId)
        {
            return Json(CategoriaNovedadBL.BuscarCategoriaNovedadID(CategoriaNovedadId));
        }

        public ActionResult ActualizarCategoriaNovedad(int CategoriaNovedadId, string Codigo, string Descripcion)
        {
            CategoriaNovedadDTO CategoriaNovedadDTO = new();
            CategoriaNovedadDTO.CategoriaNovedadId = CategoriaNovedadId;
            CategoriaNovedadDTO.DescCategoriaNovedad = Descripcion;
            CategoriaNovedadDTO.CodigoCategoriaNovedad = Codigo;
            CategoriaNovedadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CategoriaNovedadBL.ActualizarCategoriaNovedad(CategoriaNovedadDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCategoriaNovedad(int CategoriaNovedadId)
        {
            CategoriaNovedadDTO CategoriaNovedadDTO = new();
            CategoriaNovedadDTO.CategoriaNovedadId = CategoriaNovedadId;
            CategoriaNovedadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CategoriaNovedadBL.EliminarCategoriaNovedad(CategoriaNovedadDTO);

            return Content(IND_OPERACION);
        }
    }
}
