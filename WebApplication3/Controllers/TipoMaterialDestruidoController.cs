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
    public class TipoMaterialDestruidoController : Controller
    {
        readonly ILogger<TipoMaterialDestruidoController> _logger;

        public TipoMaterialDestruidoController(ILogger<TipoMaterialDestruidoController> logger)
        {
            _logger = logger;
        }

        readonly TipoMaterialDestruidoDAO TipoMaterialDestruidoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Materiales Destruidos", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoMaterialDestruidoDTO> listaTipoMaterialDestruidos = TipoMaterialDestruidoBL.ObtenerTipoMaterialDestruidos();
            return Json(new { data = listaTipoMaterialDestruidos });
        }

        public ActionResult InsertarTipoMaterialDestruido(string Descripcion, string Codigo)
        {
            var IND_OPERACION="";
            try
            {
                TipoMaterialDestruidoDTO TipoMaterialDestruidoDTO = new();
                TipoMaterialDestruidoDTO.DescTipoMaterialDestruido = Descripcion;
                TipoMaterialDestruidoDTO.CodigoTipoMaterialDestruido = Codigo;

                TipoMaterialDestruidoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = TipoMaterialDestruidoBL.AgregarTipoMaterialDestruido(TipoMaterialDestruidoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoMaterialDestruido(int TipoMaterialDestruidoId)
        {
            return Json(TipoMaterialDestruidoBL.BuscarTipoMaterialDestruidoID(TipoMaterialDestruidoId));
        }

        public ActionResult ActualizarTipoMaterialDestruido(int TipoMaterialDestruidoId, string Descripcion, string Codigo)
        {
            TipoMaterialDestruidoDTO TipoMaterialDestruidoDTO = new();
            TipoMaterialDestruidoDTO.TipoMaterialDestruidoId = TipoMaterialDestruidoId;
            TipoMaterialDestruidoDTO.DescTipoMaterialDestruido = Descripcion;
            TipoMaterialDestruidoDTO.CodigoTipoMaterialDestruido = Codigo;
            TipoMaterialDestruidoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoMaterialDestruidoBL.ActualizarTipoMaterialDestruido(TipoMaterialDestruidoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoMaterialDestruido(int TipoMaterialDestruidoId)
        {
            TipoMaterialDestruidoDTO TipoMaterialDestruidoDTO = new();
            TipoMaterialDestruidoDTO.TipoMaterialDestruidoId = TipoMaterialDestruidoId;
            TipoMaterialDestruidoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoMaterialDestruidoBL.EliminarTipoMaterialDestruido(TipoMaterialDestruidoDTO);

            return Content(IND_OPERACION);
        }
    }
}
