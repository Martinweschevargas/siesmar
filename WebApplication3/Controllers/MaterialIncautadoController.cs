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
    public class MaterialIncautadoController : Controller
    {
        readonly ILogger<MaterialIncautadoController> _logger;

        public MaterialIncautadoController(ILogger<MaterialIncautadoController> logger)
        {
            _logger = logger;
        }

        readonly MaterialIncautadoDAO MaterialIncautadoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Materiales Incautados", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MaterialIncautadoDTO> listaMaterialIncautados = MaterialIncautadoBL.ObtenerMaterialIncautados();
            return Json(new { data = listaMaterialIncautados });
        }

        public ActionResult InsertarMaterialIncautado(string Descripcion, string Codigo)
        {
            var IND_OPERACION="";
            try
            {
                MaterialIncautadoDTO MaterialIncautadoDTO = new();
                MaterialIncautadoDTO.DescMaterialIncautado = Descripcion;
                MaterialIncautadoDTO.CodigoMaterialIncautado = Codigo;
                MaterialIncautadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = MaterialIncautadoBL.AgregarMaterialIncautado(MaterialIncautadoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMaterialIncautado(int MaterialIncautadoId)
        {
            return Json(MaterialIncautadoBL.BuscarMaterialIncautadoID(MaterialIncautadoId));
        }

        public ActionResult ActualizarMaterialIncautado(int MaterialIncautadoId, string Descripcion, string Codigo)
        {
            MaterialIncautadoDTO MaterialIncautadoDTO = new();
            MaterialIncautadoDTO.MaterialIncautadoId = MaterialIncautadoId;
            MaterialIncautadoDTO.DescMaterialIncautado = Descripcion;
            MaterialIncautadoDTO.CodigoMaterialIncautado = Codigo;
            MaterialIncautadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = MaterialIncautadoBL.ActualizarMaterialIncautado(MaterialIncautadoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMaterialIncautado(int MaterialIncautadoId)
        {
            MaterialIncautadoDTO MaterialIncautadoDTO = new();
            MaterialIncautadoDTO.MaterialIncautadoId = MaterialIncautadoId;
            MaterialIncautadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = MaterialIncautadoBL.EliminarMaterialIncautado(MaterialIncautadoDTO);

            return Content(IND_OPERACION);
        }
    }
}
