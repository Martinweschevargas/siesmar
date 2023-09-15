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
    public class EntidadFinancieraController : Controller
    {
        readonly ILogger<EntidadFinancieraController> _logger;

        public EntidadFinancieraController(ILogger<EntidadFinancieraController> logger)
        {
            _logger = logger;
        }

        readonly EntidadFinanciera puertoBL = new();
        EntidadFinancieraGrupo entidadFinancieraGrupoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Entidades Financieras", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<EntidadFinancieraGrupoDTO> entidadFinancieraGrupoDTO = entidadFinancieraGrupoBL.ObtenerEntidadFinancieraGrupos();
            return Json(new { data = entidadFinancieraGrupoDTO });
        }

        public JsonResult CargarDatos()
        {
            List<EntidadFinancieraDTO> listaEntidadFinancieraes = puertoBL.ObtenerEntidadFinancieras();
            return Json(new { data = listaEntidadFinancieraes });
        }

        public ActionResult InsertarEntidadFinanciera(string Descripcion, string Codigo, int EntidadFinancieraGrupoId)
        {
            var IND_OPERACION = "";
            try
            {
                EntidadFinancieraDTO puertoDTO = new();
                puertoDTO.DescEntidadFinanciera = Descripcion;
                puertoDTO.CodigoEntidadFinanciera = Codigo;
                puertoDTO.EntidadFinancieraGrupoId = EntidadFinancieraGrupoId;
                puertoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = puertoBL.AgregarEntidadFinanciera(puertoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEntidadFinanciera(int EntidadFinancieraId)
        {
            return Json(puertoBL.BuscarEntidadFinancieraID(EntidadFinancieraId));
        }

        public ActionResult ActualizarEntidadFinanciera(int EntidadFinancieraId, string Descripcion, string Codigo, int EntidadFinancieraGrupoId)
        {
            EntidadFinancieraDTO puertoDTO = new();
            puertoDTO.EntidadFinancieraId = EntidadFinancieraId;
            puertoDTO.DescEntidadFinanciera = Descripcion;
            puertoDTO.CodigoEntidadFinanciera = Codigo;
            puertoDTO.EntidadFinancieraGrupoId = EntidadFinancieraGrupoId;
            puertoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = puertoBL.ActualizarEntidadFinanciera(puertoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEntidadFinanciera(int EntidadFinancieraId)
        {
            EntidadFinancieraDTO puertoDTO = new();
            puertoDTO.EntidadFinancieraId = EntidadFinancieraId;
            puertoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = puertoBL.EliminarEntidadFinanciera(puertoDTO);

            return Content(IND_OPERACION);
        }
    }
}
