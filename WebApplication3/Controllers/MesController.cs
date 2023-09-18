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
    public class MesController : Controller
    {
        readonly ILogger<MesController> _logger;

        public MesController(ILogger<MesController> logger)
        {
            _logger = logger;
        }

        readonly MesDAO mesBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Meses", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MesDTO> listaMess = mesBL.ObtenerMess();
            return Json(new { data = listaMess });
        }

        public ActionResult InsertarMes( string DescMes, string NumeroMes)
        {
            var IND_OPERACION = "";
            try
            {
                MesDTO mesDTO = new();
                mesDTO.DescMes = DescMes;
                mesDTO.NumeroMes = NumeroMes;
                mesDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = mesBL.AgregarMes(mesDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMes(int MesId)
        {
            return Json(mesBL.BuscarMesID(MesId));
        }

        public ActionResult ActualizarMes(int MesId, string DescMes, string NumeroMes)
        {
            MesDTO mesDTO = new();
            mesDTO.MesId = MesId;
            mesDTO.DescMes = DescMes;
            mesDTO.NumeroMes = NumeroMes;
            mesDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = mesBL.ActualizarMes(mesDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMes(int MesId)
        {
            MesDTO mesDTO = new();
            mesDTO.MesId = MesId;
            mesDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = mesBL.EliminarMes(mesDTO);

            return Content(IND_OPERACION);
        }
    }
}

