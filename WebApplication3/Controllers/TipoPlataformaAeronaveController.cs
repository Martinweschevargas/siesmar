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
    public class TipoPlataformaAeronaveController : Controller
    {
        readonly ILogger<TipoPlataformaAeronaveController> _logger;

        public TipoPlataformaAeronaveController(ILogger<TipoPlataformaAeronaveController> logger)
        {
            _logger = logger;
        }

        readonly TipoPlataformaAeronaveDAO tipoPlataformaAeronaveBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Plataformas Aeronaves", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoPlataformaAeronaveDTO> listaTipoPlataformaAeronaves = tipoPlataformaAeronaveBL.ObtenerTipoPlataformaAeronaves();
            return Json(new { data = listaTipoPlataformaAeronaves });
        }

        public ActionResult InsertarTipoPlataformaAeronave(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoPlataformaAeronaveDTO tipoPlataformaAeronaveDTO = new();
                tipoPlataformaAeronaveDTO.DescTipoPlataformaAeronave = Descripcion;
                tipoPlataformaAeronaveDTO.CodigoTipoPlataformaAeronave = Codigo;
                tipoPlataformaAeronaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoPlataformaAeronaveBL.AgregarTipoPlataformaAeronave(tipoPlataformaAeronaveDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoPlataformaAeronave(int TipoPlataformaAeronaveId)
        {
            return Json(tipoPlataformaAeronaveBL.BuscarTipoPlataformaAeronaveID(TipoPlataformaAeronaveId));
        }

        public ActionResult ActualizarTipoPlataformaAeronave(int TipoPlataformaAeronaveId, string Codigo, string Descripcion)
        {
            TipoPlataformaAeronaveDTO tipoPlataformaAeronaveDTO = new();
            tipoPlataformaAeronaveDTO.TipoPlataformaAeronaveId = TipoPlataformaAeronaveId;
            tipoPlataformaAeronaveDTO.DescTipoPlataformaAeronave = Descripcion;
            tipoPlataformaAeronaveDTO.CodigoTipoPlataformaAeronave = Codigo;
            tipoPlataformaAeronaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoPlataformaAeronaveBL.ActualizarTipoPlataformaAeronave(tipoPlataformaAeronaveDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoPlataformaAeronave(int TipoPlataformaAeronaveId)
        {
            TipoPlataformaAeronaveDTO tipoPlataformaAeronaveDTO = new();
            tipoPlataformaAeronaveDTO.TipoPlataformaAeronaveId = TipoPlataformaAeronaveId;
            tipoPlataformaAeronaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoPlataformaAeronaveBL.EliminarTipoPlataformaAeronave(tipoPlataformaAeronaveDTO);

            return Content(IND_OPERACION);
        }
    }
}
