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
    public class MaterialRecreativoController : Controller
    {
        readonly ILogger<MaterialRecreativoController> _logger;

        public MaterialRecreativoController(ILogger<MaterialRecreativoController> logger)
        {
            _logger = logger;
        }

        readonly MaterialRecreativoDAO MaterialRecreativoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Materiales Recreativos", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MaterialRecreativoDTO> listaMaterialRecreativos = MaterialRecreativoBL.ObtenerMaterialRecreativos();
            return Json(new { data = listaMaterialRecreativos });
        }

        public ActionResult InsertarMaterialRecreativo(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                MaterialRecreativoDTO MaterialRecreativoDTO = new();
                MaterialRecreativoDTO.DescMaterialRecreativo = Descripcion;
                MaterialRecreativoDTO.CodigoMaterialRecreativo = Codigo;
                MaterialRecreativoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = MaterialRecreativoBL.AgregarMaterialRecreativo(MaterialRecreativoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMaterialRecreativo(int MaterialRecreativoId)
        {
            return Json(MaterialRecreativoBL.BuscarMaterialRecreativoID(MaterialRecreativoId));
        }

        public ActionResult ActualizarMaterialRecreativo(int MaterialRecreativoId, string Codigo, string Descripcion)
        {
            MaterialRecreativoDTO MaterialRecreativoDTO = new();
            MaterialRecreativoDTO.MaterialRecreativoId = MaterialRecreativoId;
            MaterialRecreativoDTO.DescMaterialRecreativo = Descripcion;
            MaterialRecreativoDTO.CodigoMaterialRecreativo = Codigo;
            MaterialRecreativoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = MaterialRecreativoBL.ActualizarMaterialRecreativo(MaterialRecreativoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMaterialRecreativo(int MaterialRecreativoId)
        {
            MaterialRecreativoDTO MaterialRecreativoDTO = new();
            MaterialRecreativoDTO.MaterialRecreativoId = MaterialRecreativoId;
            MaterialRecreativoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = MaterialRecreativoBL.EliminarMaterialRecreativo(MaterialRecreativoDTO);

            return Content(IND_OPERACION);
        }
    }
}
