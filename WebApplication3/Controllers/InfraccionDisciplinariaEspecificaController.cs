using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class InfraccionDisciplinariaEspecificaController : Controller
    {
        readonly ILogger<InfraccionDisciplinariaEspecificaController> _logger;

        public InfraccionDisciplinariaEspecificaController(ILogger<InfraccionDisciplinariaEspecificaController> logger)
        {
            _logger = logger;
        }

        readonly InfraccionDisciplinariaEspecifica infraccionDisciplinariaEspecificaBL = new();
        Usuario usuarioBL = new();

        InfraccionDisciplinariaGenerica infraccionDisciplinariaGenericaBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Infracciones Disciplinarias Específicas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<InfraccionDisciplinariaGenericaDTO> infraccionDisciplinariaGenericaDTO = infraccionDisciplinariaGenericaBL.ObtenerInfraccionDisciplinariaGenericas();

            return Json(new { data = infraccionDisciplinariaGenericaDTO });
        }

        public JsonResult CargarDatos()
        {
            List<InfraccionDisciplinariaEspecificaDTO> listaInfraccionDisciplinariaEspecificaes = infraccionDisciplinariaEspecificaBL.ObtenerInfraccionDisciplinariaEspecificas();
            return Json(new { data = listaInfraccionDisciplinariaEspecificaes });
        }

        public ActionResult InsertarInfraccionDisciplinariaEspecifica(string Descripcion, string Codigo, int InfraccionDisciplinariaGenericaId)
        {
            var IND_OPERACION = "";
            try
            {
                InfraccionDisciplinariaEspecificaDTO infraccionDisciplinariaEspecificaDTO = new();
                infraccionDisciplinariaEspecificaDTO.DescInfraccionDisciplinariaEspecifica = Descripcion;
                infraccionDisciplinariaEspecificaDTO.CodigoInfraccionDisciplinariaEspecifica = Codigo;
                infraccionDisciplinariaEspecificaDTO.InfraccionDisciplinariaGenericaId = InfraccionDisciplinariaGenericaId;
                infraccionDisciplinariaEspecificaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = infraccionDisciplinariaEspecificaBL.AgregarInfraccionDisciplinariaEspecifica(infraccionDisciplinariaEspecificaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarInfraccionDisciplinariaEspecifica(int InfraccionDisciplinariaEspecificaId)
        {
            return Json(infraccionDisciplinariaEspecificaBL.BuscarInfraccionDisciplinariaEspecificaID(InfraccionDisciplinariaEspecificaId));
        }

        public ActionResult ActualizarInfraccionDisciplinariaEspecifica(int InfraccionDisciplinariaEspecificaId, string Descripcion, string Codigo, int InfraccionDisciplinariaGenericaId)
        {
            InfraccionDisciplinariaEspecificaDTO infraccionDisciplinariaEspecificaDTO = new();
            infraccionDisciplinariaEspecificaDTO.InfraccionDisciplinariaEspecificaId = InfraccionDisciplinariaEspecificaId;
            infraccionDisciplinariaEspecificaDTO.DescInfraccionDisciplinariaEspecifica = Descripcion;
            infraccionDisciplinariaEspecificaDTO.CodigoInfraccionDisciplinariaEspecifica = Codigo;
            infraccionDisciplinariaEspecificaDTO.InfraccionDisciplinariaGenericaId = InfraccionDisciplinariaGenericaId;
            infraccionDisciplinariaEspecificaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = infraccionDisciplinariaEspecificaBL.ActualizarInfraccionDisciplinariaEspecifica(infraccionDisciplinariaEspecificaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarInfraccionDisciplinariaEspecifica(int InfraccionDisciplinariaEspecificaId)
        {
            InfraccionDisciplinariaEspecificaDTO infraccionDisciplinariaEspecificaDTO = new();
            infraccionDisciplinariaEspecificaDTO.InfraccionDisciplinariaEspecificaId = InfraccionDisciplinariaEspecificaId;
            infraccionDisciplinariaEspecificaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = infraccionDisciplinariaEspecificaBL.EliminarInfraccionDisciplinariaEspecifica(infraccionDisciplinariaEspecificaDTO);

            return Content(IND_OPERACION);
        }
    }
}
