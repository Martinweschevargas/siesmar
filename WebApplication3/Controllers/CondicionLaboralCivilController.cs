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
    public class CondicionLaboralCivilController : Controller
    {
        readonly ILogger<CondicionLaboralCivilController> _logger;

        public CondicionLaboralCivilController(ILogger<CondicionLaboralCivilController> logger)
        {
            _logger = logger;
        }

        readonly CondicionLaboralCivilDAO CondicionLaboralCivilBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Condiciones Laborales Civiles", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CondicionLaboralCivilDTO> listaCondicionLaboralCivils = CondicionLaboralCivilBL.ObtenerCondicionLaboralCivils();
            return Json(new { data = listaCondicionLaboralCivils });
        }

        public ActionResult InsertarCondicionLaboralCivil(string Descripcion, string CodigoCondicionLaboralCivil)
        {
            var IND_OPERACION = "";
            try
            {
                CondicionLaboralCivilDTO CondicionLaboralCivilDTO = new();
                CondicionLaboralCivilDTO.DescCondicionLaboralCivil = Descripcion;
                CondicionLaboralCivilDTO.CodigoCondicionLaboralCivil = CodigoCondicionLaboralCivil;
                CondicionLaboralCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = CondicionLaboralCivilBL.AgregarCondicionLaboralCivil(CondicionLaboralCivilDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCondicionLaboralCivil(int CondicionLaboralCivilId)
        {
            return Json(CondicionLaboralCivilBL.BuscarCondicionLaboralCivilID(CondicionLaboralCivilId));
        }

        public ActionResult ActualizarCondicionLaboralCivil(int CondicionLaboralCivilId, string Descripcion, string CodigoCondicionLaboralCivil)
        {
            CondicionLaboralCivilDTO CondicionLaboralCivilDTO = new();
            CondicionLaboralCivilDTO.CondicionLaboralCivilId = CondicionLaboralCivilId;
            CondicionLaboralCivilDTO.DescCondicionLaboralCivil = Descripcion;
            CondicionLaboralCivilDTO.CodigoCondicionLaboralCivil = CodigoCondicionLaboralCivil;
            CondicionLaboralCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CondicionLaboralCivilBL.ActualizarCondicionLaboralCivil(CondicionLaboralCivilDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCondicionLaboralCivil(int CondicionLaboralCivilId)
        {
            CondicionLaboralCivilDTO CondicionLaboralCivilDTO = new();
            CondicionLaboralCivilDTO.CondicionLaboralCivilId = CondicionLaboralCivilId;
            CondicionLaboralCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = CondicionLaboralCivilBL.EliminarCondicionLaboralCivil(CondicionLaboralCivilDTO);

            return Content(IND_OPERACION);
        }
    }
}
