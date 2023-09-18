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
    public class ParentescoAfiliadoController : Controller
    {
        readonly ILogger<ParentescoAfiliadoController> _logger;

        public ParentescoAfiliadoController(ILogger<ParentescoAfiliadoController> logger)
        {
            _logger = logger;
        }

        readonly ParentescoAfiliado parentescoAfiliadoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Parentescos Afiliados", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ParentescoAfiliadoDTO> listaParentescoAfiliados = parentescoAfiliadoBL.ObtenerParentescoAfiliados();
            return Json(new { data = listaParentescoAfiliados });
        }

        public ActionResult InsertarParentescoAfiliado(string CodigoParentescoAfiliado, string DescParentescoAfiliado)
        {
            var IND_OPERACION = "";
            try
            {
                ParentescoAfiliadoDTO parentescoAfiliadoDTO = new();
                parentescoAfiliadoDTO.DescParentescoAfiliado = DescParentescoAfiliado;
                parentescoAfiliadoDTO.CodigoParentescoAfiliado = CodigoParentescoAfiliado;
                parentescoAfiliadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = parentescoAfiliadoBL.AgregarParentescoAfiliado(parentescoAfiliadoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarParentescoAfiliado(string CodigoParentescoAfiliado)
        {
            return Json(parentescoAfiliadoBL.BuscarParentescoAfiliadoID(CodigoParentescoAfiliado));
        }

        public ActionResult ActualizarParentescoAfiliado(string CodigoParentescoAfiliado, string DescParentescoAfiliado)
        {
            ParentescoAfiliadoDTO parentescoAfiliadoDTO = new();
            parentescoAfiliadoDTO.DescParentescoAfiliado = DescParentescoAfiliado;
            parentescoAfiliadoDTO.CodigoParentescoAfiliado = CodigoParentescoAfiliado;
            parentescoAfiliadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = parentescoAfiliadoBL.ActualizarParentescoAfiliado(parentescoAfiliadoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarParentescoAfiliado(string CodigoParentescoAfiliado)
        {
            ParentescoAfiliadoDTO parentescoAfiliadoDTO = new();
            parentescoAfiliadoDTO.CodigoParentescoAfiliado = CodigoParentescoAfiliado;
            parentescoAfiliadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = parentescoAfiliadoBL.EliminarParentescoAfiliado(parentescoAfiliadoDTO);

            return Content(IND_OPERACION);
        }
    }
}
