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
    public class TipoMaterialBienHistoricoController : Controller
    {
        readonly ILogger<TipoMaterialBienHistoricoController> _logger;

        public TipoMaterialBienHistoricoController(ILogger<TipoMaterialBienHistoricoController> logger)
        {
            _logger = logger;
        }

        readonly TipoMaterialBienHistoricoDAO tipoMaterialBienHistoricoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Materiales Bien Historicos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoMaterialBienHistoricoDTO> listaTipoMaterialBienHistoricos = tipoMaterialBienHistoricoBL.ObtenerTipoMaterialBienHistoricos();
            return Json(new { data = listaTipoMaterialBienHistoricos });
        }

        public ActionResult InsertarTipoMaterialBienHistorico(string DescTipoMaterialBienHistorico, string CodigoTipoMaterialBienHistorico)
        {
            var IND_OPERACION = "";
            try
            {
                TipoMaterialBienHistoricoDTO tipoMaterialBienHistoricoDTO = new();
                tipoMaterialBienHistoricoDTO.DescTipoMaterialBienHistorico = DescTipoMaterialBienHistorico;
                tipoMaterialBienHistoricoDTO.CodigoTipoMaterialBienHistorico = CodigoTipoMaterialBienHistorico;
                tipoMaterialBienHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoMaterialBienHistoricoBL.AgregarTipoMaterialBienHistorico(tipoMaterialBienHistoricoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoMaterialBienHistorico(int TipoMaterialBienHistoricoId)
        {
            return Json(tipoMaterialBienHistoricoBL.BuscarTipoMaterialBienHistoricoID(TipoMaterialBienHistoricoId));
        }

        public ActionResult ActualizarTipoMaterialBienHistorico(int TipoMaterialBienHistoricoId, string DescTipoMaterialBienHistorico, string CodigoTipoMaterialBienHistorico)
        {
            TipoMaterialBienHistoricoDTO tipoMaterialBienHistoricoDTO = new();
            tipoMaterialBienHistoricoDTO.TipoMaterialBienHistoricoId = TipoMaterialBienHistoricoId;
            tipoMaterialBienHistoricoDTO.DescTipoMaterialBienHistorico = DescTipoMaterialBienHistorico;
            tipoMaterialBienHistoricoDTO.CodigoTipoMaterialBienHistorico = CodigoTipoMaterialBienHistorico;
            tipoMaterialBienHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoMaterialBienHistoricoBL.ActualizarTipoMaterialBienHistorico(tipoMaterialBienHistoricoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoMaterialBienHistorico(int TipoMaterialBienHistoricoId)
        {
            TipoMaterialBienHistoricoDTO tipoMaterialBienHistoricoDTO = new();
            tipoMaterialBienHistoricoDTO.TipoMaterialBienHistoricoId = TipoMaterialBienHistoricoId;
            tipoMaterialBienHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoMaterialBienHistoricoBL.EliminarTipoMaterialBienHistorico(tipoMaterialBienHistoricoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}

