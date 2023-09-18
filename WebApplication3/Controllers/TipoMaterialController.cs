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
    public class TipoMaterialController : Controller
    {
        readonly ILogger<TipoMaterialController> _logger;

        public TipoMaterialController(ILogger<TipoMaterialController> logger)
        {
            _logger = logger;
        }

        readonly TipoMaterialDAO tipoMaterialBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Materiales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoMaterialDTO> listaTipoMaterials = tipoMaterialBL.ObtenerTipoMaterials();
            return Json(new { data = listaTipoMaterials });
        }

        public ActionResult InsertarTipoMaterial(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoMaterialDTO tipoMaterialDTO = new();
                tipoMaterialDTO.DescTipoMaterial = Descripcion;
                tipoMaterialDTO.CodigoTipoMaterial = Codigo;
                tipoMaterialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoMaterialBL.AgregarTipoMaterial(tipoMaterialDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoMaterial(int TipoMaterialId)
        {
            return Json(tipoMaterialBL.BuscarTipoMaterialID(TipoMaterialId));
        }

        public ActionResult ActualizarTipoMaterial(int TipoMaterialId, string Codigo, string Descripcion)
        {
            TipoMaterialDTO tipoMaterialDTO = new();
            tipoMaterialDTO.TipoMaterialId = TipoMaterialId;
            tipoMaterialDTO.DescTipoMaterial = Descripcion;
            tipoMaterialDTO.CodigoTipoMaterial = Codigo;
            tipoMaterialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoMaterialBL.ActualizarTipoMaterial(tipoMaterialDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoMaterial(int TipoMaterialId)
        {
            TipoMaterialDTO tipoMaterialDTO = new();
            tipoMaterialDTO.TipoMaterialId = TipoMaterialId;
            tipoMaterialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoMaterialBL.EliminarTipoMaterial(tipoMaterialDTO);

            return Content(IND_OPERACION);
        }
    }
}
