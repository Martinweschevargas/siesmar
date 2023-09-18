using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class TipoAcuerdoController : Controller
    {
        readonly ILogger<TipoAcuerdoController> _logger;

        public TipoAcuerdoController(ILogger<TipoAcuerdoController> logger)
        {
            _logger = logger;
        }

        readonly TipoAcuerdo tipoAcuerdoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Acuerdos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoAcuerdoDTO> listaTipoAcuerdos = tipoAcuerdoBL.ObtenerTipoAcuerdos();
            return Json(new { data = listaTipoAcuerdos });
        }

        public ActionResult InsertarTipoAcuerdo(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoAcuerdoDTO tipoAcuerdoDTO = new();
                tipoAcuerdoDTO.DescTipoAcuerdo = Descripcion;
                tipoAcuerdoDTO.CodigoTipoAcuerdo = Codigo;
                tipoAcuerdoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoAcuerdoBL.AgregarTipoAcuerdo(tipoAcuerdoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoAcuerdo(int TipoAcuerdoId)
        {
            return Json(tipoAcuerdoBL.BuscarTipoAcuerdoID(TipoAcuerdoId));
        }

        public ActionResult ActualizarTipoAcuerdo(int TipoAcuerdoId, string Codigo, string Descripcion)
        {
            TipoAcuerdoDTO tipoAcuerdoDTO = new();
            tipoAcuerdoDTO.TipoAcuerdoId = TipoAcuerdoId;
            tipoAcuerdoDTO.DescTipoAcuerdo = Descripcion;
            tipoAcuerdoDTO.CodigoTipoAcuerdo = Codigo;
            tipoAcuerdoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoAcuerdoBL.ActualizarTipoAcuerdo(tipoAcuerdoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoAcuerdo(int TipoAcuerdoId)
        {
            TipoAcuerdoDTO tipoAcuerdoDTO = new();
            tipoAcuerdoDTO.TipoAcuerdoId = TipoAcuerdoId;
            tipoAcuerdoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoAcuerdoBL.EliminarTipoAcuerdo(tipoAcuerdoDTO);

            return Content(IND_OPERACION);
        }
    }
}
