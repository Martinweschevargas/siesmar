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
    public class TrabajoRealizadoBienHistoricoController : Controller
    {
        readonly ILogger<TrabajoRealizadoBienHistoricoController> _logger;

        public TrabajoRealizadoBienHistoricoController(ILogger<TrabajoRealizadoBienHistoricoController> logger)
        {
            _logger = logger;
        }

        readonly TrabajoRealizadoBienHistoricoDAO trabajoRealizadoBienHistoricoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "TrabajoRealizadoBienHistorico", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TrabajoRealizadoBienHistoricoDTO> listaTrabajoRealizadoBienHistoricos = trabajoRealizadoBienHistoricoBL.ObtenerTrabajoRealizadoBienHistoricos();
            return Json(new { data = listaTrabajoRealizadoBienHistoricos });
        }

        public ActionResult InsertarTrabajoRealizadoBienHistorico(string DescTrabajoRealizadoBienHistorico, string CodigoTrabajoRealizadoBienHistorico)
        {
            var IND_OPERACION = "";
            try
            {
                TrabajoRealizadoBienHistoricoDTO trabajoRealizadoBienHistoricoDTO = new();
                trabajoRealizadoBienHistoricoDTO.DescTrabajoRealizadoBienHistorico = DescTrabajoRealizadoBienHistorico;
                trabajoRealizadoBienHistoricoDTO.CodigoTrabajoRealizadoBienHistorico = CodigoTrabajoRealizadoBienHistorico;
                trabajoRealizadoBienHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = trabajoRealizadoBienHistoricoBL.AgregarTrabajoRealizadoBienHistorico(trabajoRealizadoBienHistoricoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTrabajoRealizadoBienHistorico(int TrabajoRealizadoBienHistoricoId)
        {
            return Json(trabajoRealizadoBienHistoricoBL.BuscarTrabajoRealizadoBienHistoricoID(TrabajoRealizadoBienHistoricoId));
        }

        public ActionResult ActualizarTrabajoRealizadoBienHistorico(int TrabajoRealizadoBienHistoricoId, string DescTrabajoRealizadoBienHistorico, string CodigoTrabajoRealizadoBienHistorico)
        {
            TrabajoRealizadoBienHistoricoDTO trabajoRealizadoBienHistoricoDTO = new();
            trabajoRealizadoBienHistoricoDTO.TrabajoRealizadoBienHistoricoId = TrabajoRealizadoBienHistoricoId;
            trabajoRealizadoBienHistoricoDTO.DescTrabajoRealizadoBienHistorico = DescTrabajoRealizadoBienHistorico;
            trabajoRealizadoBienHistoricoDTO.CodigoTrabajoRealizadoBienHistorico = CodigoTrabajoRealizadoBienHistorico;
            trabajoRealizadoBienHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = trabajoRealizadoBienHistoricoBL.ActualizarTrabajoRealizadoBienHistorico(trabajoRealizadoBienHistoricoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTrabajoRealizadoBienHistorico(int TrabajoRealizadoBienHistoricoId)
        {
            TrabajoRealizadoBienHistoricoDTO trabajoRealizadoBienHistoricoDTO = new();
            trabajoRealizadoBienHistoricoDTO.TrabajoRealizadoBienHistoricoId = TrabajoRealizadoBienHistoricoId;
            trabajoRealizadoBienHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (trabajoRealizadoBienHistoricoBL.EliminarTrabajoRealizadoBienHistorico(trabajoRealizadoBienHistoricoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}

