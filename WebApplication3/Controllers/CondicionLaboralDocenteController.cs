using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class CondicionLaboralDocenteController : Controller
    {
        readonly ILogger<CondicionLaboralDocenteController> _logger;

        public CondicionLaboralDocenteController(ILogger<CondicionLaboralDocenteController> logger)
        {
            _logger = logger;
        }

        readonly CondicionLaboralDocenteDAO condicionLaboralDocenteBL = new();

        [Breadcrumb(FromAction = "Index", Title = "Condiciones Laborales Docentes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CondicionLaboralDocenteDTO> listaCondicionLaboralDocentes = condicionLaboralDocenteBL.ObtenerCondicionLaboralDocentes();
            return Json(new { data = listaCondicionLaboralDocentes });
        }

        public ActionResult InsertarCondicionLaboralDocente(string DescCondicionLaboralDocente, string CodigoCondicionLaboralDocente)

        {
            var IND_OPERACION = "";
            try
            {
                CondicionLaboralDocenteDTO condicionLaboralDocenteDTO = new();
                condicionLaboralDocenteDTO.DescCondicionLaboralDocente = DescCondicionLaboralDocente;
                condicionLaboralDocenteDTO.CodigoCondicionLaboralDocente = CodigoCondicionLaboralDocente;
                condicionLaboralDocenteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
                IND_OPERACION = condicionLaboralDocenteBL.AgregarCondicionLaboralDocente(condicionLaboralDocenteDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCondicionLaboralDocente(int CondicionLaboralDocenteId)
        {
            return Json(condicionLaboralDocenteBL.BuscarCondicionLaboralDocenteID(CondicionLaboralDocenteId));
        }

        public ActionResult ActualizarCondicionLaboralDocente(int CondicionLaboralDocenteId, string DescCondicionLaboralDocente, string CodigoCondicionLaboralDocente)
        {
            CondicionLaboralDocenteDTO condicionLaboralDocenteDTO = new();
            condicionLaboralDocenteDTO.CondicionLaboralDocenteId = CondicionLaboralDocenteId;
            condicionLaboralDocenteDTO.DescCondicionLaboralDocente = DescCondicionLaboralDocente;
            condicionLaboralDocenteDTO.CodigoCondicionLaboralDocente = CodigoCondicionLaboralDocente;
            condicionLaboralDocenteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = condicionLaboralDocenteBL.ActualizarCondicionLaboralDocente(condicionLaboralDocenteDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCondicionLaboralDocente(int CondicionLaboralDocenteId)
        {
            CondicionLaboralDocenteDTO condicionLaboralDocenteDTO = new();
            condicionLaboralDocenteDTO.CondicionLaboralDocenteId = CondicionLaboralDocenteId;
            condicionLaboralDocenteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = condicionLaboralDocenteBL.EliminarCondicionLaboralDocente(condicionLaboralDocenteDTO);

            return Content(IND_OPERACION);
        }
    }
}
