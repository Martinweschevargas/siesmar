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
    public class EntidadSolicitanteController : Controller
    {
        readonly ILogger<EntidadSolicitanteController> _logger;

        public EntidadSolicitanteController(ILogger<EntidadSolicitanteController> logger)
        {
            _logger = logger;
        }

        readonly EntidadSolicitanteDAO entidadSolicitanteBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Entidades Solicitantes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EntidadSolicitanteDTO> listaEntidadSolicitantes = entidadSolicitanteBL.ObtenerEntidadSolicitantes();
            return Json(new { data = listaEntidadSolicitantes });
        }

        public ActionResult InsertarEntidadSolicitante(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                EntidadSolicitanteDTO entidadSolicitanteDTO = new();
                entidadSolicitanteDTO.DescEntidadSolicitante = Descripcion;
                entidadSolicitanteDTO.CodigoEntidadSolicitante = Codigo;
                entidadSolicitanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = entidadSolicitanteBL.AgregarEntidadSolicitante(entidadSolicitanteDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEntidadSolicitante(int EntidadSolicitanteId)
        {
            return Json(entidadSolicitanteBL.BuscarEntidadSolicitanteID(EntidadSolicitanteId));
        }

        public ActionResult ActualizarEntidadSolicitante(int EntidadSolicitanteId, string Codigo, string Descripcion)
        {
            EntidadSolicitanteDTO entidadSolicitanteDTO = new();
            entidadSolicitanteDTO.EntidadSolicitanteId = EntidadSolicitanteId;
            entidadSolicitanteDTO.DescEntidadSolicitante = Descripcion;
            entidadSolicitanteDTO.CodigoEntidadSolicitante = Codigo;
            entidadSolicitanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = entidadSolicitanteBL.ActualizarEntidadSolicitante(entidadSolicitanteDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEntidadSolicitante(int EntidadSolicitanteId)
        {
            EntidadSolicitanteDTO entidadSolicitanteDTO = new();
            entidadSolicitanteDTO.EntidadSolicitanteId = EntidadSolicitanteId;
            entidadSolicitanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = entidadSolicitanteBL.EliminarEntidadSolicitante(entidadSolicitanteDTO);

            return Content(IND_OPERACION);
        }
    }
}
