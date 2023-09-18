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
    public class InstanciaJudicialController : Controller
    {
        readonly ILogger<InstanciaJudicialController> _logger;

        public InstanciaJudicialController(ILogger<InstanciaJudicialController> logger)
        {
            _logger = logger;
        }

        readonly InstanciaJudicialDAO instanciaJudicialBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Instancias Judiciales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<InstanciaJudicialDTO> listaInstanciaJudicials = instanciaJudicialBL.ObtenerInstanciaJudicials();
            return Json(new { data = listaInstanciaJudicials });
        }

        public ActionResult InsertarInstanciaJudicial(string DescInstanciaJudicial, string CodigoInstanciaJudicial)
        {
            var IND_OPERACION = "";
            try
            {
                InstanciaJudicialDTO instanciaJudicialDTO = new();
                instanciaJudicialDTO.DescInstanciaJudicial = DescInstanciaJudicial;
                instanciaJudicialDTO.CodigoInstanciaJudicial = CodigoInstanciaJudicial;
                instanciaJudicialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = instanciaJudicialBL.AgregarInstanciaJudicial(instanciaJudicialDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarInstanciaJudicial(int InstanciaJudicialId)
        {
            return Json(instanciaJudicialBL.BuscarInstanciaJudicialID(InstanciaJudicialId));
        }

        public ActionResult ActualizarInstanciaJudicial(int InstanciaJudicialId, string DescInstanciaJudicial, string CodigoInstanciaJudicial)
        {
            InstanciaJudicialDTO instanciaJudicialDTO = new();
            instanciaJudicialDTO.InstanciaJudicialId = InstanciaJudicialId;
            instanciaJudicialDTO.DescInstanciaJudicial = DescInstanciaJudicial;
            instanciaJudicialDTO.CodigoInstanciaJudicial = CodigoInstanciaJudicial;
            instanciaJudicialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = instanciaJudicialBL.ActualizarInstanciaJudicial(instanciaJudicialDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarInstanciaJudicial(int InstanciaJudicialId)
        {
            InstanciaJudicialDTO instanciaJudicialDTO = new();
            instanciaJudicialDTO.InstanciaJudicialId = InstanciaJudicialId;
            instanciaJudicialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = instanciaJudicialBL.EliminarInstanciaJudicial(instanciaJudicialDTO);

            return Content(IND_OPERACION);
        }
    }
}
