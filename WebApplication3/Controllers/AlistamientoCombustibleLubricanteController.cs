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
    public class AlistamientoCombustibleLubricanteController : Controller
    {
        readonly ILogger<AlistamientoCombustibleLubricanteController> _logger;

        public AlistamientoCombustibleLubricanteController(ILogger<AlistamientoCombustibleLubricanteController> logger)
        {
            _logger = logger;
        }

        readonly AlistamientoCombustibleLubricanteDAO AlistamientoCombustibleLubricanteBL = new();
        Usuario usuarioBL = new();

        SistemaCombustibleLubricanteDAO SistemaCombustibleLubricanteBL = new();
        SubsistemaCombustibleLubricanteDAO SubsistemaCombustibleLubricanteBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Alistamientos Combustibles Lubricantes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           return View();
        }


        [HttpGet]
        public IActionResult cargaCombsSistemas()
        {

            List<SistemaCombustibleLubricanteDTO> SistemaCombustibleLubricanteDTO = SistemaCombustibleLubricanteBL.ObtenerSistemaCombustibleLubricantes();
            List<SubsistemaCombustibleLubricanteDTO> SubsistemaCombustibleLubricanteDTO = SubsistemaCombustibleLubricanteBL.ObtenerSubsistemaCombustibleLubricantes();


            return Json(new
            {
                data1 = SistemaCombustibleLubricanteDTO,
                data2 = SubsistemaCombustibleLubricanteDTO
            });
        }

        public JsonResult CargarDatos()
        {
            List<AlistamientoCombustibleLubricanteDTO> listaAlistamientoCombustibleLubricantees = AlistamientoCombustibleLubricanteBL.ObtenerAlistamientoCombustibleLubricantes();
            return Json(new { data = listaAlistamientoCombustibleLubricantees });
        }

        public ActionResult InsertarAlistamientoCombustibleLubricante(string CodigoAlistamientoCombustibleLubricante, string CodigoSistemaCombustibleLubricante, string CodigoSubsistemaCombustibleLubricante, string Equipo, string Combustible, string Existente, string Necesaria, int Coeficiente)
        {
            var IND_OPERACION = "";
            try
            {
                AlistamientoCombustibleLubricanteDTO AlistamientoCombustibleLubricanteDTO = new();
                AlistamientoCombustibleLubricanteDTO.CodigoAlistamientoCombustibleLubricante = CodigoAlistamientoCombustibleLubricante;
                AlistamientoCombustibleLubricanteDTO.CodigoSistemaCombustibleLubricante = CodigoSistemaCombustibleLubricante;
                AlistamientoCombustibleLubricanteDTO.CodigoSubsistemaCombustibleLubricante = CodigoSubsistemaCombustibleLubricante;
                AlistamientoCombustibleLubricanteDTO.Equipo = Equipo;
                AlistamientoCombustibleLubricanteDTO.CombustibleLubricante = Combustible;
                AlistamientoCombustibleLubricanteDTO.Existente = Existente;
                AlistamientoCombustibleLubricanteDTO.NecesariasGLS = Necesaria;
                AlistamientoCombustibleLubricanteDTO.CoeficientePonderacion = Coeficiente;
                AlistamientoCombustibleLubricanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = AlistamientoCombustibleLubricanteBL.AgregarAlistamientoCombustibleLubricante(AlistamientoCombustibleLubricanteDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAlistamientoCombustibleLubricante(int AlistamientoCombustibleLubricanteId)
        {
            return Json(AlistamientoCombustibleLubricanteBL.BuscarAlistamientoCombustibleLubricanteID(AlistamientoCombustibleLubricanteId));
        }

        public ActionResult ActualizarAlistamientoCombustibleLubricante(int AlistamientoCombustibleLubricanteId, string CodigoAlistamientoCombustibleLubricante, string CodigoSistemaCombustibleLubricante, string CodigoSubsistemaCombustibleLubricante, string Equipo, string Combustible, string Existente, string Necesaria, int Coeficiente)
        {
            AlistamientoCombustibleLubricanteDTO AlistamientoCombustibleLubricanteDTO = new();
            AlistamientoCombustibleLubricanteDTO.AlistamientoCombustibleLubricanteId = AlistamientoCombustibleLubricanteId;
            AlistamientoCombustibleLubricanteDTO.CodigoAlistamientoCombustibleLubricante = CodigoAlistamientoCombustibleLubricante;
            AlistamientoCombustibleLubricanteDTO.CodigoSistemaCombustibleLubricante = CodigoSistemaCombustibleLubricante;
            AlistamientoCombustibleLubricanteDTO.CodigoSubsistemaCombustibleLubricante = CodigoSubsistemaCombustibleLubricante; ;
            AlistamientoCombustibleLubricanteDTO.Equipo = Equipo;
            AlistamientoCombustibleLubricanteDTO.CombustibleLubricante = Combustible;
            AlistamientoCombustibleLubricanteDTO.Existente = Existente;
            AlistamientoCombustibleLubricanteDTO.NecesariasGLS = Necesaria;
            AlistamientoCombustibleLubricanteDTO.CoeficientePonderacion = Coeficiente;
            AlistamientoCombustibleLubricanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AlistamientoCombustibleLubricanteBL.ActualizarAlistamientoCombustibleLubricante(AlistamientoCombustibleLubricanteDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAlistamientoCombustibleLubricante(int AlistamientoCombustibleLubricanteId)
        {
            AlistamientoCombustibleLubricanteDTO AlistamientoCombustibleLubricanteDTO = new();
            AlistamientoCombustibleLubricanteDTO.AlistamientoCombustibleLubricanteId = AlistamientoCombustibleLubricanteId;
            AlistamientoCombustibleLubricanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AlistamientoCombustibleLubricanteBL.EliminarAlistamientoCombustibleLubricante(AlistamientoCombustibleLubricanteDTO);

            return Content(IND_OPERACION);
        }
    }
}
