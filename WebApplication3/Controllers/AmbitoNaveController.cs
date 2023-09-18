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
    public class AmbitoNaveController : Controller
    {
        readonly ILogger<AmbitoNaveController> _logger;

        public AmbitoNaveController(ILogger<AmbitoNaveController> logger)
        {
            _logger = logger;
        }

        readonly AmbitoNaveDAO AmbitoNaveBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Ambitos Naves", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
           return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<AmbitoNaveDTO> listaAmbitoNaves = AmbitoNaveBL.ObtenerAmbitoNaves();
            return Json(new { data = listaAmbitoNaves });
        }

        public ActionResult InsertarAmbitoNave(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                AmbitoNaveDTO AmbitoNaveDTO = new();
                AmbitoNaveDTO.CodigoAmbitoNave = Codigo;
                AmbitoNaveDTO.DescAmbitoNave = Descripcion;
                AmbitoNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = AmbitoNaveBL.AgregarAmbitoNave(AmbitoNaveDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAmbitoNave(int AmbitoNaveId)
        {
            return Json(AmbitoNaveBL.BuscarAmbitoNaveID(AmbitoNaveId));
        }

        public ActionResult ActualizarAmbitoNave(int AmbitoNaveId, string Codigo, string Descripcion)
        {
            AmbitoNaveDTO AmbitoNaveDTO = new();
            AmbitoNaveDTO.AmbitoNaveId = AmbitoNaveId;
            AmbitoNaveDTO.CodigoAmbitoNave = Codigo;
            AmbitoNaveDTO.DescAmbitoNave = Descripcion;
            AmbitoNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AmbitoNaveBL.ActualizarAmbitoNave(AmbitoNaveDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAmbitoNave(int AmbitoNaveId)
        {
            AmbitoNaveDTO AmbitoNaveDTO = new();
            AmbitoNaveDTO.AmbitoNaveId = AmbitoNaveId;
            AmbitoNaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AmbitoNaveBL.EliminarAmbitoNave(AmbitoNaveDTO);

            return Content(IND_OPERACION);
        }
    }
}
