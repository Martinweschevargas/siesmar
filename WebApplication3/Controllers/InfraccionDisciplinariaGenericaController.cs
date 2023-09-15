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
    public class InfraccionDisciplinariaGenericaController : Controller
    {
        readonly ILogger<InfraccionDisciplinariaGenericaController> _logger;

        public InfraccionDisciplinariaGenericaController(ILogger<InfraccionDisciplinariaGenericaController> logger)
        {
            _logger = logger;
        }

        readonly InfraccionDisciplinariaGenericaDAO infraccionDisciplinariaGenericaBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Infracciones Disciplinarias Genéricas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<InfraccionDisciplinariaGenericaDTO> listaInfraccionDisciplinariaGenericas = infraccionDisciplinariaGenericaBL.ObtenerInfraccionDisciplinariaGenericas();
            return Json(new { data = listaInfraccionDisciplinariaGenericas });
        }

        public ActionResult InsertarInfraccionDisciplinariaGenerica(string Descripcion, string CodigoInfraccionDisciplinariaGenerica)
        {
            var IND_OPERACION = "";
            try
            {
                InfraccionDisciplinariaGenericaDTO infraccionDisciplinariaGenericaDTO = new();
                infraccionDisciplinariaGenericaDTO.DescInfraccionDisciplinariaGenerica = CodigoInfraccionDisciplinariaGenerica;
                infraccionDisciplinariaGenericaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = infraccionDisciplinariaGenericaBL.AgregarInfraccionDisciplinariaGenerica(infraccionDisciplinariaGenericaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarInfraccionDisciplinariaGenerica(int InfraccionDisciplinariaGenericaId)
        {
            return Json(infraccionDisciplinariaGenericaBL.BuscarInfraccionDisciplinariaGenericaID(InfraccionDisciplinariaGenericaId));
        }

        public ActionResult ActualizarInfraccionDisciplinariaGenerica(int InfraccionDisciplinariaGenericaId, string Descripcion, string CodigoInfraccionDisciplinariaGenerica)
        {
            InfraccionDisciplinariaGenericaDTO infraccionDisciplinariaGenericaDTO = new();
            infraccionDisciplinariaGenericaDTO.InfraccionDisciplinariaGenericaId = InfraccionDisciplinariaGenericaId;
            infraccionDisciplinariaGenericaDTO.DescInfraccionDisciplinariaGenerica = Descripcion;
            infraccionDisciplinariaGenericaDTO.DescInfraccionDisciplinariaGenerica = CodigoInfraccionDisciplinariaGenerica;
            infraccionDisciplinariaGenericaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = infraccionDisciplinariaGenericaBL.ActualizarInfraccionDisciplinariaGenerica(infraccionDisciplinariaGenericaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarInfraccionDisciplinariaGenerica(int InfraccionDisciplinariaGenericaId)
        {
            InfraccionDisciplinariaGenericaDTO infraccionDisciplinariaGenericaDTO = new();
            infraccionDisciplinariaGenericaDTO.InfraccionDisciplinariaGenericaId = InfraccionDisciplinariaGenericaId;
            infraccionDisciplinariaGenericaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = infraccionDisciplinariaGenericaBL.EliminarInfraccionDisciplinariaGenerica(infraccionDisciplinariaGenericaDTO);

            return Content(IND_OPERACION);
        }
    }
}
