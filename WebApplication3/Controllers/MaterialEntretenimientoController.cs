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
    public class MaterialEntretenimientoController : Controller
    {
        readonly ILogger<MaterialEntretenimientoController> _logger;

        public MaterialEntretenimientoController(ILogger<MaterialEntretenimientoController> logger)
        {
            _logger = logger;
        }

        readonly MaterialEntretenimientoDAO MaterialEntretenimientoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Materiales Entretenimientos", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MaterialEntretenimientoDTO> listaMaterialEntretenimientos = MaterialEntretenimientoBL.ObtenerMaterialEntretenimientos();
            return Json(new { data = listaMaterialEntretenimientos });
        }

        public ActionResult InsertarMaterialEntretenimiento(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                MaterialEntretenimientoDTO MaterialEntretenimientoDTO = new();
                MaterialEntretenimientoDTO.DescMaterialEntretenimiento = Descripcion;
                MaterialEntretenimientoDTO.CodigoMaterialEntretenimiento = Codigo;
                MaterialEntretenimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = MaterialEntretenimientoBL.AgregarMaterialEntretenimiento(MaterialEntretenimientoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMaterialEntretenimiento(int MaterialEntretenimientoId)
        {
            return Json(MaterialEntretenimientoBL.BuscarMaterialEntretenimientoID(MaterialEntretenimientoId));
        }

        public ActionResult ActualizarMaterialEntretenimiento(int MaterialEntretenimientoId, string Codigo, string Descripcion)
        {
            MaterialEntretenimientoDTO MaterialEntretenimientoDTO = new();
            MaterialEntretenimientoDTO.MaterialEntretenimientoId = MaterialEntretenimientoId;
            MaterialEntretenimientoDTO.CodigoMaterialEntretenimiento = Codigo;
            MaterialEntretenimientoDTO.DescMaterialEntretenimiento = Descripcion;
            MaterialEntretenimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = MaterialEntretenimientoBL.ActualizarMaterialEntretenimiento(MaterialEntretenimientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMaterialEntretenimiento(int MaterialEntretenimientoId)
        {
            MaterialEntretenimientoDTO MaterialEntretenimientoDTO = new();
            MaterialEntretenimientoDTO.MaterialEntretenimientoId = MaterialEntretenimientoId;
            MaterialEntretenimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = MaterialEntretenimientoBL.EliminarMaterialEntretenimiento(MaterialEntretenimientoDTO);

            return Content(IND_OPERACION);
        }
    }
}
