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
    public class TipoPersonalMilitarController : Controller
    {
        readonly ILogger<TipoPersonalMilitarController> _logger;

        public TipoPersonalMilitarController(ILogger<TipoPersonalMilitarController> logger)
        {
            _logger = logger;
        }

        readonly TipoPersonalMilitarDAO tipoPersonalMilitarBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Personales Militares", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoPersonalMilitarDTO> listaTipoPersonalMilitars = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            return Json(new { data = listaTipoPersonalMilitars });
        }

        public ActionResult InsertarTipoPersonalMilitar(string DescTipoPersonalMilitar, string CodigoTipoPersonalMilitar)
        {
            var IND_OPERACION="";
            try
            {
                TipoPersonalMilitarDTO tipoPersonalMilitarDTO = new();
                tipoPersonalMilitarDTO.DescTipoPersonalMilitar = DescTipoPersonalMilitar;
                tipoPersonalMilitarDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
                tipoPersonalMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoPersonalMilitarBL.AgregarTipoPersonalMilitar(tipoPersonalMilitarDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoPersonalMilitar(int TipoPersonalMilitarId)
        {
            return Json(tipoPersonalMilitarBL.BuscarTipoPersonalMilitarID(TipoPersonalMilitarId));
        }

        public ActionResult ActualizarTipoPersonalMilitar(int TipoPersonalMilitarId, string DescTipoPersonalMilitar, string CodigoTipoPersonalMilitar)
        {
            TipoPersonalMilitarDTO tipoPersonalMilitarDTO = new();
            tipoPersonalMilitarDTO.TipoPersonalMilitarId = TipoPersonalMilitarId;
            tipoPersonalMilitarDTO.DescTipoPersonalMilitar = DescTipoPersonalMilitar;
            tipoPersonalMilitarDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            tipoPersonalMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoPersonalMilitarBL.ActualizarTipoPersonalMilitar(tipoPersonalMilitarDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoPersonalMilitar(int TipoPersonalMilitarId)
        {
            TipoPersonalMilitarDTO tipoPersonalMilitarDTO = new();
            tipoPersonalMilitarDTO.TipoPersonalMilitarId = TipoPersonalMilitarId;
            tipoPersonalMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoPersonalMilitarBL.EliminarTipoPersonalMilitar(tipoPersonalMilitarDTO);

            return Content(IND_OPERACION);
        }
    }
}
