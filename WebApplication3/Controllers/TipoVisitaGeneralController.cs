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
    public class TipoVisitaGeneralController : Controller
    {
        readonly ILogger<TipoVisitaGeneralController> _logger;

        public TipoVisitaGeneralController(ILogger<TipoVisitaGeneralController> logger)
        {
            _logger = logger;
        }

        readonly TipoVisitaGeneralDAO tipoVisitaGeneralBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Visitas Generales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoVisitaGeneralDTO> listaTipoVisitaGenerals = tipoVisitaGeneralBL.ObtenerTipoVisitaGenerals();
            return Json(new { data = listaTipoVisitaGenerals });
        }

        public ActionResult InsertarTipoVisitaGeneral(string DescTipoVisitaGeneral, string CodigoTipoVisitaGeneral)
        {
            var IND_OPERACION = "";
            try
            {
                TipoVisitaGeneralDTO tipoVisitaGeneralDTO = new();
                tipoVisitaGeneralDTO.DescTipoVisitaGeneral = DescTipoVisitaGeneral;
                tipoVisitaGeneralDTO.CodigoTipoVisitaGeneral = CodigoTipoVisitaGeneral;
                tipoVisitaGeneralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoVisitaGeneralBL.AgregarTipoVisitaGeneral(tipoVisitaGeneralDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoVisitaGeneral(int TipoVisitaGeneralId)
        {
            return Json(tipoVisitaGeneralBL.BuscarTipoVisitaGeneralID(TipoVisitaGeneralId));
        }

        public ActionResult ActualizarTipoVisitaGeneral(int TipoVisitaGeneralId, string DescTipoVisitaGeneral, string CodigoTipoVisitaGeneral)
        {
            TipoVisitaGeneralDTO tipoVisitaGeneralDTO = new();
            tipoVisitaGeneralDTO.TipoVisitaGeneralId = TipoVisitaGeneralId;
            tipoVisitaGeneralDTO.DescTipoVisitaGeneral = DescTipoVisitaGeneral;
            tipoVisitaGeneralDTO.CodigoTipoVisitaGeneral = CodigoTipoVisitaGeneral;
            tipoVisitaGeneralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoVisitaGeneralBL.ActualizarTipoVisitaGeneral(tipoVisitaGeneralDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoVisitaGeneral(int TipoVisitaGeneralId)
        {
            TipoVisitaGeneralDTO tipoVisitaGeneralDTO = new();
            tipoVisitaGeneralDTO.TipoVisitaGeneralId = TipoVisitaGeneralId;
            tipoVisitaGeneralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoVisitaGeneralBL.EliminarTipoVisitaGeneral(tipoVisitaGeneralDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}

