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
    public class TipoDocumentoController : Controller
    {
        readonly ILogger<TipoDocumentoController> _logger;

        public TipoDocumentoController(ILogger<TipoDocumentoController> logger)
        {
            _logger = logger;
        }

        readonly TipoDocumentoDAO tipoDocumentoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Documentos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoDocumentoDTO> listaTipoDocumentos = tipoDocumentoBL.ObtenerTipoDocumentos();
            return Json(new { data = listaTipoDocumentos });
        }

        public ActionResult InsertarTipoDocumento(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoDocumentoDTO tipoDocumentoDTO = new();
                tipoDocumentoDTO.DescTipoDocumento = Descripcion;
                tipoDocumentoDTO.CodigoTipoDocumento = Codigo;
                tipoDocumentoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoDocumentoBL.AgregarTipoDocumento(tipoDocumentoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoDocumento(int TipoDocumentoId)
        {
            return Json(tipoDocumentoBL.BuscarTipoDocumentoID(TipoDocumentoId));
        }

        public ActionResult ActualizarTipoDocumento(int TipoDocumentoId, string Codigo, string Descripcion)
        {
            TipoDocumentoDTO tipoDocumentoDTO = new();
            tipoDocumentoDTO.TipoDocumentoId = TipoDocumentoId;
            tipoDocumentoDTO.DescTipoDocumento = Descripcion;
            tipoDocumentoDTO.CodigoTipoDocumento = Codigo;
            tipoDocumentoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoDocumentoBL.ActualizarTipoDocumento(tipoDocumentoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoDocumento(int TipoDocumentoId)
        {
            TipoDocumentoDTO tipoDocumentoDTO = new();
            tipoDocumentoDTO.TipoDocumentoId = TipoDocumentoId;
            tipoDocumentoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoDocumentoBL.EliminarTipoDocumento(tipoDocumentoDTO);

            return Content(IND_OPERACION);
        }
    }
}
