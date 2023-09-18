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
    public class SubsistemaCombustibleLubricanteController : Controller
    {
        readonly ILogger<SubsistemaCombustibleLubricanteController> _logger;

        public SubsistemaCombustibleLubricanteController(ILogger<SubsistemaCombustibleLubricanteController> logger)
        {
            _logger = logger;
        }

        readonly SubsistemaCombustibleLubricanteDAO SubsistemaCombustibleLubricanteBL = new();
        Usuario usuarioBL = new();

        SistemaCombustibleLubricanteDAO SistemaCombustibleLubricanteBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Subsistemas Combustibles Lubricantes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult cargaCombs()
        {
            List<SistemaCombustibleLubricanteDTO> SistemaCombustibleLubricanteDTO = SistemaCombustibleLubricanteBL.ObtenerSistemaCombustibleLubricantes();
            return Json(new { data = SistemaCombustibleLubricanteDTO });
        }

        public JsonResult CargarDatos()
        {
            List<SubsistemaCombustibleLubricanteDTO> listaSubsistemaCombustibleLubricantees = SubsistemaCombustibleLubricanteBL.ObtenerSubsistemaCombustibleLubricantes();
            return Json(new { data = listaSubsistemaCombustibleLubricantees });
        }

        public ActionResult InsertarSubsistemaCombustibleLubricante(string Descripcion, string CodigoSistemaCombustibleLubricante, string CodigoSubsistemaCombustibleLubricante)
        {
            var IND_OPERACION = "";
            try
            {
                SubsistemaCombustibleLubricanteDTO SubsistemaCombustibleLubricanteDTO = new();
                SubsistemaCombustibleLubricanteDTO.DescSubsistemaCombustibleLubricante = Descripcion;
                SubsistemaCombustibleLubricanteDTO.CodigoSubsistemaCombustibleLubricante = CodigoSubsistemaCombustibleLubricante;
                SubsistemaCombustibleLubricanteDTO.CodigoSistemaCombustibleLubricante = CodigoSistemaCombustibleLubricante;
                SubsistemaCombustibleLubricanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = SubsistemaCombustibleLubricanteBL.AgregarSubsistemaCombustibleLubricante(SubsistemaCombustibleLubricanteDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSubsistemaCombustibleLubricante(int SubsistemaCombustibleLubricanteId)
        {
            return Json(SubsistemaCombustibleLubricanteBL.BuscarSubsistemaCombustibleLubricanteID(SubsistemaCombustibleLubricanteId));
        }

        public ActionResult ActualizarSubsistemaCombustibleLubricante(int SubsistemaCombustibleLubricanteId,string Descripcion, string CodigoSistemaCombustibleLubricante, string CodigoSubsistemaCombustibleLubricante)
        {
            SubsistemaCombustibleLubricanteDTO SubsistemaCombustibleLubricanteDTO = new();
            SubsistemaCombustibleLubricanteDTO.SubsistemaCombustibleLubricanteId = SubsistemaCombustibleLubricanteId;
            SubsistemaCombustibleLubricanteDTO.DescSubsistemaCombustibleLubricante = Descripcion;
            SubsistemaCombustibleLubricanteDTO.CodigoSubsistemaCombustibleLubricante = CodigoSubsistemaCombustibleLubricante;
            SubsistemaCombustibleLubricanteDTO.CodigoSistemaCombustibleLubricante = CodigoSistemaCombustibleLubricante;
            SubsistemaCombustibleLubricanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = SubsistemaCombustibleLubricanteBL.ActualizarSubsistemaCombustibleLubricante(SubsistemaCombustibleLubricanteDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSubsistemaCombustibleLubricante(int SubsistemaCombustibleLubricanteId)
        {
            SubsistemaCombustibleLubricanteDTO SubsistemaCombustibleLubricanteDTO = new();
            SubsistemaCombustibleLubricanteDTO.SubsistemaCombustibleLubricanteId = SubsistemaCombustibleLubricanteId;
            SubsistemaCombustibleLubricanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = SubsistemaCombustibleLubricanteBL.EliminarSubsistemaCombustibleLubricante(SubsistemaCombustibleLubricanteDTO);

            return Content(IND_OPERACION);
        }
    }
}
