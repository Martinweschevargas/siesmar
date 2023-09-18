using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using MathNet.Numerics.Distributions;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class EquipoSistemaPropulsionController : Controller
    {
        readonly ILogger<EquipoSistemaPropulsionController> _logger;

        public EquipoSistemaPropulsionController(ILogger<EquipoSistemaPropulsionController> logger)
        {
            _logger = logger;
        }

        readonly EquipoSistemaPropulsion equipoSistemaPropulsionBL = new();
        Usuario usuarioBL = new();

        SubSistemaPropulsion subSistemaPropulsionBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Equipos Sistemas Propulsiones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<SubSistemaPropulsionDTO> subSistemaPropulsionDTO = subSistemaPropulsionBL.ObtenerSubSistemaPropulsions();

            return Json(new { data = subSistemaPropulsionDTO });
        }

        public JsonResult CargarDatos()
        {
            List<EquipoSistemaPropulsionDTO> listaEquipoSistemaPropulsiones = equipoSistemaPropulsionBL.ObtenerEquipoSistemaPropulsions();
            return Json(new { data = listaEquipoSistemaPropulsiones });
        }

        public ActionResult InsertarEquipoSistemaPropulsion(string CodigoEquipoSistemaPropulsion, string DescEquipoSistemaPropulsion, string CodigoSubSistemaPropulsion)
        {
            var IND_OPERACION = "";
            try
            {
                EquipoSistemaPropulsionDTO equipoSistemaPropulsionDTO = new();
                equipoSistemaPropulsionDTO.CodigoEquipoSistemaPropulsion = CodigoEquipoSistemaPropulsion;
                equipoSistemaPropulsionDTO.DescEquipoSistemaPropulsion = DescEquipoSistemaPropulsion;
                equipoSistemaPropulsionDTO.CodigoSubSistemaPropulsion = CodigoSubSistemaPropulsion;
                equipoSistemaPropulsionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = equipoSistemaPropulsionBL.AgregarEquipoSistemaPropulsion(equipoSistemaPropulsionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEquipoSistemaPropulsion(int EquipoSistemaPropulsionId)
        {
            return Json(equipoSistemaPropulsionBL.BuscarEquipoSistemaPropulsionID(EquipoSistemaPropulsionId));
        }

        public ActionResult ActualizarEquipoSistemaPropulsion(int EquipoSistemaPropulsionId, string CodigoEquipoSistemaPropulsion, string DescEquipoSistemaPropulsion, string CodigoSubSistemaPropulsion)
        {
            EquipoSistemaPropulsionDTO equipoSistemaPropulsionDTO = new();
            equipoSistemaPropulsionDTO.EquipoSistemaPropulsionId = EquipoSistemaPropulsionId;
            equipoSistemaPropulsionDTO.CodigoEquipoSistemaPropulsion = CodigoEquipoSistemaPropulsion;
            equipoSistemaPropulsionDTO.DescEquipoSistemaPropulsion = DescEquipoSistemaPropulsion;
            equipoSistemaPropulsionDTO.CodigoSubSistemaPropulsion = CodigoSubSistemaPropulsion;
            equipoSistemaPropulsionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = equipoSistemaPropulsionBL.ActualizarEquipoSistemaPropulsion(equipoSistemaPropulsionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEquipoSistemaPropulsion(int EquipoSistemaPropulsionId)
        {
            EquipoSistemaPropulsionDTO equipoSistemaPropulsionDTO = new();
            equipoSistemaPropulsionDTO.EquipoSistemaPropulsionId = EquipoSistemaPropulsionId;
            equipoSistemaPropulsionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = equipoSistemaPropulsionBL.EliminarEquipoSistemaPropulsion(equipoSistemaPropulsionDTO);

            return Content(IND_OPERACION);
        }
    }
}
