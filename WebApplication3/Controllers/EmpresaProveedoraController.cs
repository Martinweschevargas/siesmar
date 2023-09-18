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
    public class EmpresaProveedoraController : Controller
    {
        readonly ILogger<EmpresaProveedoraController> _logger;

        public EmpresaProveedoraController(ILogger<EmpresaProveedoraController> logger)
        {
            _logger = logger;
        }

        readonly EmpresaProveedoraDAO empresaProveedoraBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Empresas Proveedoras", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EmpresaProveedoraDTO> listaEmpresaProveedoras = empresaProveedoraBL.ObtenerEmpresaProveedoras();
            return Json(new { data = listaEmpresaProveedoras });
        }

        public ActionResult InsertarEmpresaProveedora(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                EmpresaProveedoraDTO empresaProveedoraDTO = new();
                empresaProveedoraDTO.DescEmpresaProveedora = Descripcion;
                empresaProveedoraDTO.CodigoEmpresaProveedora = Codigo;
                empresaProveedoraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = empresaProveedoraBL.AgregarEmpresaProveedora(empresaProveedoraDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEmpresaProveedora(int EmpresaProveedoraId)
        {
            return Json(empresaProveedoraBL.BuscarEmpresaProveedoraID(EmpresaProveedoraId));
        }

        public ActionResult ActualizarEmpresaProveedora(int EmpresaProveedoraId, string Codigo, string Descripcion)
        {
            EmpresaProveedoraDTO empresaProveedoraDTO = new();
            empresaProveedoraDTO.EmpresaProveedoraId = EmpresaProveedoraId;
            empresaProveedoraDTO.DescEmpresaProveedora = Descripcion;
            empresaProveedoraDTO.CodigoEmpresaProveedora = Codigo;
            empresaProveedoraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = empresaProveedoraBL.ActualizarEmpresaProveedora(empresaProveedoraDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEmpresaProveedora(int EmpresaProveedoraId)
        {
            EmpresaProveedoraDTO empresaProveedoraDTO = new();
            empresaProveedoraDTO.EmpresaProveedoraId = EmpresaProveedoraId;
            empresaProveedoraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = empresaProveedoraBL.EliminarEmpresaProveedora(empresaProveedoraDTO);

            return Content(IND_OPERACION);
        }
    }
}
