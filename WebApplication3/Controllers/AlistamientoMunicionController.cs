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
    public class AlistamientoMunicionController : Controller
    {
        readonly ILogger<AlistamientoMunicionController> _logger;

        public AlistamientoMunicionController(ILogger<AlistamientoMunicionController> logger)
        {
            _logger = logger;
        }

        readonly AlistamientoMunicionDAO AlistamientoMunicionBL = new();

        SistemaMunicionDAO SistemaMunicionBL = new();
        SubsistemaMunicionDAO SubsistemaMunicionBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Alistamientos Municions Críticos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           return View();
        }


        [HttpGet]
        public IActionResult cargaCombsSistemas()
        {

            List<SistemaMunicionDTO> SistemaMunicionDTO = SistemaMunicionBL.ObtenerSistemaMunicions();

            return Json(new { data = SistemaMunicionDTO });
        }

        [HttpGet]
        public IActionResult cargaCombsSubsistemas()
        {

            List<SubsistemaMunicionDTO> SubsistemaMunicionDTO = SubsistemaMunicionBL.ObtenerSubsistemaMunicions();

            return Json(new { data = SubsistemaMunicionDTO });
        }

        public JsonResult CargarDatos()
        {
            List<AlistamientoMunicionDTO> listaAlistamientoMuniciones = AlistamientoMunicionBL.ObtenerAlistamientoMunicions();
            return Json(new { data = listaAlistamientoMuniciones });
        }

        public ActionResult InsertarAlistamientoMunicion(string CodigoAlistamientoMunicion, string CodigoSistemaMunicion, string CodigoSubsistemaMunicion, string Equipo, string Municion, string Existente, int Necesaria, int Coeficiente)
        {
            var IND_OPERACION = "";
            try
            {
                AlistamientoMunicionDTO AlistamientoMunicionDTO = new();
                AlistamientoMunicionDTO.CodigoAlistamientoMunicion = CodigoAlistamientoMunicion;
                AlistamientoMunicionDTO.CodigoSistemaMunicion = CodigoSistemaMunicion;
                AlistamientoMunicionDTO.CodigoSubsistemaMunicion = CodigoSubsistemaMunicion;
                AlistamientoMunicionDTO.Equipo = Equipo;
                AlistamientoMunicionDTO.Municion = Municion;
                AlistamientoMunicionDTO.Existente = Existente;
                AlistamientoMunicionDTO.Necesaria = Necesaria;
                AlistamientoMunicionDTO.CoeficientePonderacion = Coeficiente;
                AlistamientoMunicionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = AlistamientoMunicionBL.AgregarAlistamientoMunicion(AlistamientoMunicionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAlistamientoMunicion(int AlistamientoMunicionId)
        {
            return Json(AlistamientoMunicionBL.BuscarAlistamientoMunicionID(AlistamientoMunicionId));
        }

        public ActionResult ActualizarAlistamientoMunicion(int AlistamientoMunicionId, string CodigoAlistamientoMunicion, string CodigoSistemaMunicion, string CodigoSubsistemaMunicion, string Equipo, string Municion, string Existente, int Necesaria, int Coeficiente)
        {
            AlistamientoMunicionDTO AlistamientoMunicionDTO = new();
            AlistamientoMunicionDTO.AlistamientoMunicionId = AlistamientoMunicionId;
            AlistamientoMunicionDTO.CodigoAlistamientoMunicion = CodigoAlistamientoMunicion;
            AlistamientoMunicionDTO.CodigoSistemaMunicion = CodigoSistemaMunicion;
            AlistamientoMunicionDTO.CodigoSubsistemaMunicion = CodigoSubsistemaMunicion;
            AlistamientoMunicionDTO.Equipo = Equipo;
            AlistamientoMunicionDTO.Municion = Municion;
            AlistamientoMunicionDTO.Existente = Existente;
            AlistamientoMunicionDTO.Necesaria = Necesaria;
            AlistamientoMunicionDTO.CoeficientePonderacion = Coeficiente;
            AlistamientoMunicionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AlistamientoMunicionBL.ActualizarAlistamientoMunicion(AlistamientoMunicionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAlistamientoMunicion(int AlistamientoMunicionId)
        {
            AlistamientoMunicionDTO AlistamientoMunicionDTO = new();
            AlistamientoMunicionDTO.AlistamientoMunicionId = AlistamientoMunicionId;
            AlistamientoMunicionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AlistamientoMunicionBL.EliminarAlistamientoMunicion(AlistamientoMunicionDTO);

            return Content(IND_OPERACION);
        }
    }
}
