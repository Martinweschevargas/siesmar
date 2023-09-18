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
    public class DescripcionMaterialController : Controller
    {
        readonly ILogger<DescripcionMaterialController> _logger;

        public DescripcionMaterialController(ILogger<DescripcionMaterialController> logger)
        {
            _logger = logger;
        }

        readonly DescripcionMaterialDAO DescripcionMaterialBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Descripciones Materiales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DescripcionMaterialDTO> listaDescripcionMaterials = DescripcionMaterialBL.ObtenerDescripcionMaterials();
            return Json(new { data = listaDescripcionMaterials });
        }

        public ActionResult InsertarDescripcionMaterial(string Clasificacion, string CodigoDescripcionMaterial)
        {
            var IND_OPERACION = "";
            try
            {
                DescripcionMaterialDTO DescripcionMaterialDTO = new();
                DescripcionMaterialDTO.Clasificacion = Clasificacion;
                DescripcionMaterialDTO.CodigoDescripcionMaterial = CodigoDescripcionMaterial;
                DescripcionMaterialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = DescripcionMaterialBL.AgregarDescripcionMaterial(DescripcionMaterialDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDescripcionMaterial(int DescripcionMaterialId)
        {
            return Json(DescripcionMaterialBL.BuscarDescripcionMaterialID(DescripcionMaterialId));
        }

        public ActionResult ActualizarDescripcionMaterial(int DescripcionMaterialId, string Clasificacion, string CodigoDescripcionMaterial)
        {
            DescripcionMaterialDTO DescripcionMaterialDTO = new();
            DescripcionMaterialDTO.DescripcionMaterialId = DescripcionMaterialId;
            DescripcionMaterialDTO.Clasificacion = Clasificacion;
            DescripcionMaterialDTO.CodigoDescripcionMaterial = CodigoDescripcionMaterial;
            DescripcionMaterialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = DescripcionMaterialBL.ActualizarDescripcionMaterial(DescripcionMaterialDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDescripcionMaterial(int DescripcionMaterialId)
        {
            DescripcionMaterialDTO DescripcionMaterialDTO = new();
            DescripcionMaterialDTO.DescripcionMaterialId = DescripcionMaterialId;
            DescripcionMaterialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = DescripcionMaterialBL.EliminarDescripcionMaterial(DescripcionMaterialDTO);

            return Content(IND_OPERACION);
        }
    }
}
