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
    public class DocumentoController : Controller
    {
        readonly ILogger<DocumentoController> _logger;

        public DocumentoController(ILogger<DocumentoController> logger)
        {
            _logger = logger;
        }

        readonly DocumentoDAO documentoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Documentos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DocumentoDTO> listaDocumentos = documentoBL.ObtenerDocumentos();
            return Json(new { data = listaDocumentos });
        }

        public ActionResult InsertarDocumento(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                DocumentoDTO documentoDTO = new();
                documentoDTO.DescDocumento = Descripcion;
                documentoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = documentoBL.AgregarDocumento(documentoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDocumento(int DocumentoId)
        {
            return Json(documentoBL.BuscarDocumentoID(DocumentoId));
        }

        public ActionResult ActualizarDocumento(int DocumentoId, string Descripcion)
        {
            DocumentoDTO documentoDTO = new();
            documentoDTO.DocumentoId = DocumentoId;
            documentoDTO.DescDocumento = Descripcion;
            documentoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = documentoBL.ActualizarDocumento(documentoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDocumento(int DocumentoId)
        {
            DocumentoDTO documentoDTO = new();
            documentoDTO.DocumentoId = DocumentoId;
            documentoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = documentoBL.EliminarDocumento(documentoDTO);

            return Content(IND_OPERACION);
        }
    }
}
