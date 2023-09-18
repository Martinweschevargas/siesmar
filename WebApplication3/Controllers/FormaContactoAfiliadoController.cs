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
    public class FormaContactoAfiliadoController : Controller
    {
        readonly ILogger<FormaContactoAfiliadoController> _logger;

        public FormaContactoAfiliadoController(ILogger<FormaContactoAfiliadoController> logger)
        {
            _logger = logger;
        }

        readonly FormaContactoAfiliadoDAO formaContactoAfiliadoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Formas Contactos Afiliados", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<FormaContactoAfiliadoDTO> listaFormaContactoAfiliados = formaContactoAfiliadoBL.ObtenerFormaContactoAfiliados();
            return Json(new { data = listaFormaContactoAfiliados });
        }

        public ActionResult InsertarFormaContactoAfiliado(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                FormaContactoAfiliadoDTO formaContactoAfiliadoDTO = new();
                formaContactoAfiliadoDTO.DescFormaContactoAfiliado = Descripcion;
                formaContactoAfiliadoDTO.CodigoFormaContactoAfiliado = Codigo;
                formaContactoAfiliadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = formaContactoAfiliadoBL.AgregarFormaContactoAfiliado(formaContactoAfiliadoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarFormaContactoAfiliado(int FormaContactoAfiliadoId)
        {
            return Json(formaContactoAfiliadoBL.BuscarFormaContactoAfiliadoID(FormaContactoAfiliadoId));
        }

        public ActionResult ActualizarFormaContactoAfiliado(int FormaContactoAfiliadoId, string Codigo, string Descripcion)
        {
            FormaContactoAfiliadoDTO formaContactoAfiliadoDTO = new();
            formaContactoAfiliadoDTO.FormaContactoAfiliadoId = FormaContactoAfiliadoId;
            formaContactoAfiliadoDTO.DescFormaContactoAfiliado = Descripcion;
            formaContactoAfiliadoDTO.CodigoFormaContactoAfiliado = Codigo;
            formaContactoAfiliadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = formaContactoAfiliadoBL.ActualizarFormaContactoAfiliado(formaContactoAfiliadoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarFormaContactoAfiliado(int FormaContactoAfiliadoId)
        {
            FormaContactoAfiliadoDTO formaContactoAfiliadoDTO = new();
            formaContactoAfiliadoDTO.FormaContactoAfiliadoId = FormaContactoAfiliadoId;
            formaContactoAfiliadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = formaContactoAfiliadoBL.EliminarFormaContactoAfiliado(formaContactoAfiliadoDTO);

            return Content(IND_OPERACION);
        }
    }
}
