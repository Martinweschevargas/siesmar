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
    public class MaterialDeportivoController : Controller
    {
        readonly ILogger<MaterialDeportivoController> _logger;

        public MaterialDeportivoController(ILogger<MaterialDeportivoController> logger)
        {
            _logger = logger;
        }

        readonly MaterialDeportivoDAO MaterialDeportivoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Materiales Deportivos", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MaterialDeportivoDTO> listaMaterialDeportivos = MaterialDeportivoBL.ObtenerMaterialDeportivos();
            return Json(new { data = listaMaterialDeportivos });
        }

        public ActionResult InsertarMaterialDeportivo(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                MaterialDeportivoDTO MaterialDeportivoDTO = new();
                MaterialDeportivoDTO.DescMaterialDeportivo = Descripcion;
                MaterialDeportivoDTO.CodigoMaterialDeportivo = Codigo;
                MaterialDeportivoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = MaterialDeportivoBL.AgregarMaterialDeportivo(MaterialDeportivoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMaterialDeportivo(int MaterialDeportivoId)
        {
            return Json(MaterialDeportivoBL.BuscarMaterialDeportivoID(MaterialDeportivoId));
        }

        public ActionResult ActualizarMaterialDeportivo(int MaterialDeportivoId, string Codigo, string Descripcion)
        {
            MaterialDeportivoDTO MaterialDeportivoDTO = new();
            MaterialDeportivoDTO.MaterialDeportivoId = MaterialDeportivoId;
            MaterialDeportivoDTO.DescMaterialDeportivo = Descripcion;
            MaterialDeportivoDTO.CodigoMaterialDeportivo = Codigo;
            MaterialDeportivoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = MaterialDeportivoBL.ActualizarMaterialDeportivo(MaterialDeportivoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMaterialDeportivo(int MaterialDeportivoId)
        {
            MaterialDeportivoDTO MaterialDeportivoDTO = new();
            MaterialDeportivoDTO.MaterialDeportivoId = MaterialDeportivoId;
            MaterialDeportivoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = MaterialDeportivoBL.EliminarMaterialDeportivo(MaterialDeportivoDTO);

            return Content(IND_OPERACION);
        }
    }
}
