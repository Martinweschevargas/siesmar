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
    public class MaterialArmamentoController : Controller
    {
        readonly ILogger<MaterialArmamentoController> _logger;

        public MaterialArmamentoController(ILogger<MaterialArmamentoController> logger)
        {
            _logger = logger;
        }

        readonly MaterialArmamentoDAO materialArmamentoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Materiales Armamentos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MaterialArmamentoDTO> listaMaterialArmamentos = materialArmamentoBL.ObtenerMaterialArmamentos();
            return Json(new { data = listaMaterialArmamentos });
        }

        public ActionResult InsertarMaterialArmamento(string Codigo, string Descripcion, string Calibre)
        {
            var IND_OPERACION = "";
            try
            {
                MaterialArmamentoDTO materialArmamentoDTO = new();
                materialArmamentoDTO.DescMaterialArmamento = Descripcion;
                materialArmamentoDTO.CalibreMaterialArmamento = Calibre;
                materialArmamentoDTO.CodigoMaterialArmamento = Codigo;
                materialArmamentoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = materialArmamentoBL.AgregarMaterialArmamento(materialArmamentoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMaterialArmamento(int MaterialArmamentoId)
        {
            return Json(materialArmamentoBL.BuscarMaterialArmamentoID(MaterialArmamentoId));
        }

        public ActionResult ActualizarMaterialArmamento(int MaterialArmamentoId, string Codigo, string Calibre, string Descripcion)
        {
            MaterialArmamentoDTO materialArmamentoDTO = new();
            materialArmamentoDTO.MaterialArmamentoId = MaterialArmamentoId;
            materialArmamentoDTO.DescMaterialArmamento = Descripcion;
            materialArmamentoDTO.CalibreMaterialArmamento = Calibre;
            materialArmamentoDTO.CodigoMaterialArmamento = Codigo;
            materialArmamentoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = materialArmamentoBL.ActualizarMaterialArmamento(materialArmamentoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMaterialArmamento(int MaterialArmamentoId)
        {
            MaterialArmamentoDTO materialArmamentoDTO = new();
            materialArmamentoDTO.MaterialArmamentoId = MaterialArmamentoId;
            materialArmamentoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = materialArmamentoBL.EliminarMaterialArmamento(materialArmamentoDTO);

            return Content(IND_OPERACION);
        }
    }
}
