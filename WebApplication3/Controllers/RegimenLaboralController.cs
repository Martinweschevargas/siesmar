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
    public class RegimenLaboralController : Controller
    {
        readonly ILogger<RegimenLaboralController> _logger;

        public RegimenLaboralController(ILogger<RegimenLaboralController> logger)
        {
            _logger = logger;
        }

        readonly RegimenLaboralDAO regimenLaboralBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Regimen Laborales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<RegimenLaboralDTO> listaRegimenLaborals = regimenLaboralBL.ObtenerRegimenLaborals();
            return Json(new { data = listaRegimenLaborals });
        }

        public ActionResult InsertarRegimenLaboral(string DescRegimenLaboral, string CodigoRegimenLaboral)
        {
            var IND_OPERACION = "";
            try
            {
                RegimenLaboralDTO regimenLaboralDTO = new();
                regimenLaboralDTO.DescRegimenLaboral = DescRegimenLaboral;
                regimenLaboralDTO.CodigoRegimenLaboral = CodigoRegimenLaboral;
                regimenLaboralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = regimenLaboralBL.AgregarRegimenLaboral(regimenLaboralDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarRegimenLaboral(int RegimenLaboralId)
        {
            return Json(regimenLaboralBL.BuscarRegimenLaboralID(RegimenLaboralId));
        }

        public ActionResult ActualizarRegimenLaboral(int RegimenLaboralId, string DescRegimenLaboral, string CodigoRegimenLaboral)
        {
            RegimenLaboralDTO regimenLaboralDTO = new();
            regimenLaboralDTO.RegimenLaboralId = RegimenLaboralId;
            regimenLaboralDTO.DescRegimenLaboral = DescRegimenLaboral;
            regimenLaboralDTO.CodigoRegimenLaboral = CodigoRegimenLaboral;
            regimenLaboralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = regimenLaboralBL.ActualizarRegimenLaboral(regimenLaboralDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarRegimenLaboral(int RegimenLaboralId)
        {
            RegimenLaboralDTO regimenLaboralDTO = new();
            regimenLaboralDTO.RegimenLaboralId = RegimenLaboralId;
            regimenLaboralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = regimenLaboralBL.EliminarRegimenLaboral(regimenLaboralDTO);

            return Content(IND_OPERACION);
        }
    }
}
