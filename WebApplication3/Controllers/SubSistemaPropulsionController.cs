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
    public class SubSistemaPropulsionController : Controller
    {
        readonly ILogger<SubSistemaPropulsionController> _logger;

        public SubSistemaPropulsionController(ILogger<SubSistemaPropulsionController> logger)
        {
            _logger = logger;
        }

        readonly SubSistemaPropulsion subSistemaPropulsionBL = new();
        Usuario usuarioBL = new();

        SistemaPropulsion sistemaPropulsionBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "SubSistemas Propulsiones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<SistemaPropulsionDTO> sistemaPropulsionDTO = sistemaPropulsionBL.ObtenerSistemaPropulsions();

            return Json(new { data = sistemaPropulsionDTO });
        }

        public JsonResult CargarDatos()
        {
            List<SubSistemaPropulsionDTO> listaSubSistemaPropulsiones = subSistemaPropulsionBL.ObtenerSubSistemaPropulsions();
            return Json(new { data = listaSubSistemaPropulsiones });
        }

        public ActionResult InsertarSubSistemaPropulsion(string Descripcion, string CodigoSubSistemaPropulsion, string CodigoSistemaPropulsion)
        {
            var IND_OPERACION = "";
            try
            {
                SubSistemaPropulsionDTO subSistemaPropulsionDTO = new();
                subSistemaPropulsionDTO.CodigoSubSistemaPropulsion = CodigoSubSistemaPropulsion;
                subSistemaPropulsionDTO.DescSubSistemaPropulsion = Descripcion;
                subSistemaPropulsionDTO.CodigoSistemaPropulsion = CodigoSistemaPropulsion;
                subSistemaPropulsionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = subSistemaPropulsionBL.AgregarSubSistemaPropulsion(subSistemaPropulsionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSubSistemaPropulsion(int SubSistemaPropulsionId)
        {
            return Json(subSistemaPropulsionBL.BuscarSubSistemaPropulsionID(SubSistemaPropulsionId));
        }

        public ActionResult ActualizarSubSistemaPropulsion(int SubSistemaPropulsionId, string Descripcion, string CodigoSubSistemaPropulsion, string CodigoSistemaPropulsion)
        {
            SubSistemaPropulsionDTO subSistemaPropulsionDTO = new();
            subSistemaPropulsionDTO.SubSistemaPropulsionId = SubSistemaPropulsionId;
            subSistemaPropulsionDTO.CodigoSubSistemaPropulsion = CodigoSubSistemaPropulsion;
            subSistemaPropulsionDTO.DescSubSistemaPropulsion = Descripcion;
            subSistemaPropulsionDTO.CodigoSistemaPropulsion = CodigoSistemaPropulsion;
            subSistemaPropulsionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = subSistemaPropulsionBL.ActualizarSubSistemaPropulsion(subSistemaPropulsionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSubSistemaPropulsion(int SubSistemaPropulsionId)
        {
            SubSistemaPropulsionDTO subSistemaPropulsionDTO = new();
            subSistemaPropulsionDTO.SubSistemaPropulsionId = SubSistemaPropulsionId;
            subSistemaPropulsionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = subSistemaPropulsionBL.EliminarSubSistemaPropulsion(subSistemaPropulsionDTO);

            return Content(IND_OPERACION);
        }
    }
}
