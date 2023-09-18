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
    public class DptoProteccionMedioAmbienteController : Controller
    {
        readonly ILogger<DptoProteccionMedioAmbienteController> _logger;

        public DptoProteccionMedioAmbienteController(ILogger<DptoProteccionMedioAmbienteController> logger)
        {
            _logger = logger;
        }

        readonly DptoProteccionMedioAmbienteDAO DptoProteccionMedioAmbienteBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Dptos Proteccion Medio Ambiente", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DptoProteccionMedioAmbienteDTO> listaDptoProteccionMedioAmbientes = DptoProteccionMedioAmbienteBL.ObtenerDptoProteccionMedioAmbientes();
            return Json(new { data = listaDptoProteccionMedioAmbientes });
        }

        public ActionResult InsertarDptoProteccionMedioAmbiente(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                DptoProteccionMedioAmbienteDTO DptoProteccionMedioAmbienteDTO = new();
                DptoProteccionMedioAmbienteDTO.DescDptoProteccionMedioAmbiente = Descripcion;
                DptoProteccionMedioAmbienteDTO.CodigoDptoProteccionMedioAmbiente = Codigo;
                DptoProteccionMedioAmbienteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = DptoProteccionMedioAmbienteBL.AgregarDptoProteccionMedioAmbiente(DptoProteccionMedioAmbienteDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDptoProteccionMedioAmbiente(int DptoProteccionMedioAmbienteId)
        {
            return Json(DptoProteccionMedioAmbienteBL.BuscarDptoProteccionMedioAmbienteID(DptoProteccionMedioAmbienteId));
        }

        public ActionResult ActualizarDptoProteccionMedioAmbiente(int DptoProteccionMedioAmbienteId, string Codigo, string Descripcion)
        {
            DptoProteccionMedioAmbienteDTO DptoProteccionMedioAmbienteDTO = new();
            DptoProteccionMedioAmbienteDTO.DptoProteccionMedioAmbienteId = DptoProteccionMedioAmbienteId;
            DptoProteccionMedioAmbienteDTO.DescDptoProteccionMedioAmbiente = Descripcion;
            DptoProteccionMedioAmbienteDTO.CodigoDptoProteccionMedioAmbiente = Codigo;
            DptoProteccionMedioAmbienteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = DptoProteccionMedioAmbienteBL.ActualizarDptoProteccionMedioAmbiente(DptoProteccionMedioAmbienteDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDptoProteccionMedioAmbiente(int DptoProteccionMedioAmbienteId)
        {
            DptoProteccionMedioAmbienteDTO DptoProteccionMedioAmbienteDTO = new();
            DptoProteccionMedioAmbienteDTO.DptoProteccionMedioAmbienteId = DptoProteccionMedioAmbienteId;
            DptoProteccionMedioAmbienteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = DptoProteccionMedioAmbienteBL.EliminarDptoProteccionMedioAmbiente(DptoProteccionMedioAmbienteDTO);

            return Content(IND_OPERACION);
        }
    }
}
