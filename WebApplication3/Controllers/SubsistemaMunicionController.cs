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
    public class SubsistemaMunicionController : Controller
    {
        readonly ILogger<SubsistemaMunicionController> _logger;

        public SubsistemaMunicionController(ILogger<SubsistemaMunicionController> logger)
        {
            _logger = logger;
        }

        readonly SubsistemaMunicionDAO SubsistemaMunicionBL = new();
        Usuario usuarioBL = new();

        SistemaMunicionDAO SistemaMunicionBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Subsistemas Municiones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<SistemaMunicionDTO> SistemaMunicionDTO = SistemaMunicionBL.ObtenerSistemaMunicions();

            return Json(new { data = SistemaMunicionDTO });
        }

        public JsonResult CargarDatos()
        {
            List<SubsistemaMunicionDTO> listaSubsistemaMuniciones = SubsistemaMunicionBL.ObtenerSubsistemaMunicions();
            return Json(new { data = listaSubsistemaMuniciones });
        }

        public ActionResult InsertarSubsistemaMunicion(string Descripcion, int SistemaMunicionId)
        {
            var IND_OPERACION = "";
            try
            {
                SubsistemaMunicionDTO SubsistemaMunicionDTO = new();
                SubsistemaMunicionDTO.DescSubsistemaMunicion = Descripcion;
                SubsistemaMunicionDTO.SistemaMunicionId = SistemaMunicionId;
                SubsistemaMunicionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = SubsistemaMunicionBL.AgregarSubsistemaMunicion(SubsistemaMunicionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSubsistemaMunicion(int SubsistemaMunicionId)
        {
            return Json(SubsistemaMunicionBL.BuscarSubsistemaMunicionID(SubsistemaMunicionId));
        }

        public ActionResult ActualizarSubsistemaMunicion(int SubsistemaMunicionId, string Descripcion, int SistemaMunicionId)
        {
            SubsistemaMunicionDTO SubsistemaMunicionDTO = new();
            SubsistemaMunicionDTO.SubsistemaMunicionId = SubsistemaMunicionId;
            SubsistemaMunicionDTO.DescSubsistemaMunicion = Descripcion;
            SubsistemaMunicionDTO.SistemaMunicionId = SistemaMunicionId;
            SubsistemaMunicionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = SubsistemaMunicionBL.ActualizarSubsistemaMunicion(SubsistemaMunicionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSubsistemaMunicion(int SubsistemaMunicionId)
        {
            SubsistemaMunicionDTO SubsistemaMunicionDTO = new();
            SubsistemaMunicionDTO.SubsistemaMunicionId = SubsistemaMunicionId;
            SubsistemaMunicionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = SubsistemaMunicionBL.EliminarSubsistemaMunicion(SubsistemaMunicionDTO);

            return Content(IND_OPERACION);
        }
    }
}
