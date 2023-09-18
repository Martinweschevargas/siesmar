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
    public class AutoridadEmiteZarpeController : Controller
    {
        readonly ILogger<AutoridadEmiteZarpeController> _logger;

        public AutoridadEmiteZarpeController(ILogger<AutoridadEmiteZarpeController> logger)
        {
            _logger = logger;
        }

        readonly AutoridadEmiteZarpeDAO AutoridadEmiteZarpeBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Autoridades Emiten Zarpes", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<AutoridadEmiteZarpeDTO> listaAutoridadEmiteZarpes = AutoridadEmiteZarpeBL.ObtenerAutoridadEmiteZarpes();
            return Json(new { data = listaAutoridadEmiteZarpes });
        }

        public ActionResult InsertarAutoridadEmiteZarpe(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                AutoridadEmiteZarpeDTO AutoridadEmiteZarpeDTO = new();
                AutoridadEmiteZarpeDTO.DescAutoridadEmiteZarpe = Descripcion;
                AutoridadEmiteZarpeDTO.CodigoAutoridadEmiteZarpe = Codigo;
                AutoridadEmiteZarpeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = AutoridadEmiteZarpeBL.AgregarAutoridadEmiteZarpe(AutoridadEmiteZarpeDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAutoridadEmiteZarpe(int AutoridadEmiteZarpeId)
        {
            return Json(AutoridadEmiteZarpeBL.BuscarAutoridadEmiteZarpeID(AutoridadEmiteZarpeId));
        }

        public ActionResult ActualizarAutoridadEmiteZarpe(int AutoridadEmiteZarpeId, string Codigo, string Descripcion)
        {
            AutoridadEmiteZarpeDTO AutoridadEmiteZarpeDTO = new();
            AutoridadEmiteZarpeDTO.AutoridadEmiteZarpeId = AutoridadEmiteZarpeId;
            AutoridadEmiteZarpeDTO.DescAutoridadEmiteZarpe = Descripcion;
            AutoridadEmiteZarpeDTO.CodigoAutoridadEmiteZarpe = Codigo;
            AutoridadEmiteZarpeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AutoridadEmiteZarpeBL.ActualizarAutoridadEmiteZarpe(AutoridadEmiteZarpeDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAutoridadEmiteZarpe(int AutoridadEmiteZarpeId)
        {
            AutoridadEmiteZarpeDTO AutoridadEmiteZarpeDTO = new();
            AutoridadEmiteZarpeDTO.AutoridadEmiteZarpeId = AutoridadEmiteZarpeId;
            AutoridadEmiteZarpeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AutoridadEmiteZarpeBL.EliminarAutoridadEmiteZarpe(AutoridadEmiteZarpeDTO);

            return Content(IND_OPERACION);
        }
    }
}
