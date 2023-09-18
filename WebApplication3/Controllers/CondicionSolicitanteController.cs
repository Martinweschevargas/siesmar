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
    public class CondicionSolicitanteController : Controller
    {
        readonly ILogger<CondicionSolicitanteController> _logger;

        public CondicionSolicitanteController(ILogger<CondicionSolicitanteController> logger)
        {
            _logger = logger;
        }

        readonly CondicionSolicitanteDAO CondicionSolicitanteBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Condiciones Solicitantes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CondicionSolicitanteDTO> listaCondicionSolicitantes = CondicionSolicitanteBL.ObtenerCondicionSolicitantes();
            return Json(new { data = listaCondicionSolicitantes });
        }

        public ActionResult InsertarCondicionSolicitante(string CodigoCondicionSolicitante, string DescCondicionSolicitante)
        {
            var IND_OPERACION = "";
            try
            {
                CondicionSolicitanteDTO CondicionSolicitanteDTO = new();
                CondicionSolicitanteDTO.DescCondicionSolicitante = DescCondicionSolicitante;
                CondicionSolicitanteDTO.CodigoCondicionSolicitante = CodigoCondicionSolicitante;
                CondicionSolicitanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = CondicionSolicitanteBL.AgregarCondicionSolicitante(CondicionSolicitanteDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCondicionSolicitante(int CondicionSolicitanteId, string CodigoCondicionSolicitante, string DescCondicionSolicitante)
        {
            return Json(CondicionSolicitanteBL.BuscarCondicionSolicitanteID(CondicionSolicitanteId));
        }

        public ActionResult ActualizarCondicionSolicitante(int CondicionSolicitanteId, string CodigoCondicionSolicitante, string DescCondicionSolicitante)
        {
            CondicionSolicitanteDTO CondicionSolicitanteDTO = new();
            CondicionSolicitanteDTO.CondicionSolicitanteId = CondicionSolicitanteId;
            CondicionSolicitanteDTO.DescCondicionSolicitante = DescCondicionSolicitante;
            CondicionSolicitanteDTO.CodigoCondicionSolicitante = CodigoCondicionSolicitante;
            CondicionSolicitanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CondicionSolicitanteBL.ActualizarCondicionSolicitante(CondicionSolicitanteDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCondicionSolicitante(int CondicionSolicitanteId)
        {
            CondicionSolicitanteDTO CondicionSolicitanteDTO = new();
            CondicionSolicitanteDTO.CondicionSolicitanteId = CondicionSolicitanteId;
            CondicionSolicitanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CondicionSolicitanteBL.EliminarCondicionSolicitante(CondicionSolicitanteDTO);

            return Content(IND_OPERACION);
        }
    }
}
