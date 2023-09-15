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
    public class TipoRepresentacionBienHistoricoController : Controller
    {
        readonly ILogger<TipoRepresentacionBienHistoricoController> _logger;

        public TipoRepresentacionBienHistoricoController(ILogger<TipoRepresentacionBienHistoricoController> logger)
        {
            _logger = logger;
        }

        readonly TipoRepresentacionBienHistoricoDAO tipoRepresentacionBienHistoricoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Representaciones Bien Historicos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoRepresentacionBienHistoricoDTO> listaTipoRepresentacionBienHistoricos = tipoRepresentacionBienHistoricoBL.ObtenerTipoRepresentacionBienHistoricos();
            return Json(new { data = listaTipoRepresentacionBienHistoricos });
        }

        public ActionResult InsertarTipoRepresentacionBienHistorico(string DescTipoRepresentacionBienHistorico, string CodigoTipoRepresentacionBienHistorico)
        {
            var IND_OPERACION = "";
            try
            {
                TipoRepresentacionBienHistoricoDTO tipoRepresentacionBienHistoricoDTO = new();
                tipoRepresentacionBienHistoricoDTO.DescTipoRepresentacionBienHistorico = DescTipoRepresentacionBienHistorico;
                tipoRepresentacionBienHistoricoDTO.CodigoTipoRepresentacionBienHistorico = CodigoTipoRepresentacionBienHistorico;
                tipoRepresentacionBienHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoRepresentacionBienHistoricoBL.AgregarTipoRepresentacionBienHistorico(tipoRepresentacionBienHistoricoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoRepresentacionBienHistorico(int TipoRepresentacionBienHistoricoId)
        {
            return Json(tipoRepresentacionBienHistoricoBL.BuscarTipoRepresentacionBienHistoricoID(TipoRepresentacionBienHistoricoId));
        }

        public ActionResult ActualizarTipoRepresentacionBienHistorico(int TipoRepresentacionBienHistoricoId, string DescTipoRepresentacionBienHistorico, string CodigoTipoRepresentacionBienHistorico)
        {
            TipoRepresentacionBienHistoricoDTO tipoRepresentacionBienHistoricoDTO = new();
            tipoRepresentacionBienHistoricoDTO.TipoRepresentacionBienHistoricoId = TipoRepresentacionBienHistoricoId;
            tipoRepresentacionBienHistoricoDTO.DescTipoRepresentacionBienHistorico = DescTipoRepresentacionBienHistorico;
            tipoRepresentacionBienHistoricoDTO.CodigoTipoRepresentacionBienHistorico = CodigoTipoRepresentacionBienHistorico;
            tipoRepresentacionBienHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoRepresentacionBienHistoricoBL.ActualizarTipoRepresentacionBienHistorico(tipoRepresentacionBienHistoricoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoRepresentacionBienHistorico(int TipoRepresentacionBienHistoricoId)
        {
            TipoRepresentacionBienHistoricoDTO tipoRepresentacionBienHistoricoDTO = new();
            tipoRepresentacionBienHistoricoDTO.TipoRepresentacionBienHistoricoId = TipoRepresentacionBienHistoricoId;
            tipoRepresentacionBienHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoRepresentacionBienHistoricoBL.EliminarTipoRepresentacionBienHistorico(tipoRepresentacionBienHistoricoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}

