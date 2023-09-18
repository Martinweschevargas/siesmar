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
    public class TramiteArmaMenorController : Controller
    {
        readonly ILogger<TramiteArmaMenorController> _logger;

        public TramiteArmaMenorController(ILogger<TramiteArmaMenorController> logger)
        {
            _logger = logger;
        }

        readonly TramiteArmaMenorDAO tramiteArmaMenorBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tramites Armas Menores", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TramiteArmaMenorDTO> listaTramiteArmaMenors = tramiteArmaMenorBL.ObtenerTramiteArmaMenors();
            return Json(new { data = listaTramiteArmaMenors });
        }

        public ActionResult InsertarTramiteArmaMenor(string DescTramiteArmaMenor, string CodigoTramiteArmaMenor)
        {
            var IND_OPERACION = "";
            try
            {
                TramiteArmaMenorDTO tramiteArmaMenorDTO = new();
                tramiteArmaMenorDTO.DescTramiteArmaMenor = DescTramiteArmaMenor;
                tramiteArmaMenorDTO.CodigoTramiteArmaMenor = CodigoTramiteArmaMenor;
                tramiteArmaMenorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tramiteArmaMenorBL.AgregarTramiteArmaMenor(tramiteArmaMenorDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTramiteArmaMenor(int TramiteArmaMenorId)
        {
            return Json(tramiteArmaMenorBL.BuscarTramiteArmaMenorID(TramiteArmaMenorId));
        }

        public ActionResult ActualizarTramiteArmaMenor(int TramiteArmaMenorId, string DescTramiteArmaMenor, string CodigoTramiteArmaMenor)
        {
            TramiteArmaMenorDTO tramiteArmaMenorDTO = new();
            tramiteArmaMenorDTO.TramiteArmaMenorId = TramiteArmaMenorId;
            tramiteArmaMenorDTO.DescTramiteArmaMenor = DescTramiteArmaMenor;
            tramiteArmaMenorDTO.CodigoTramiteArmaMenor = CodigoTramiteArmaMenor;
            tramiteArmaMenorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tramiteArmaMenorBL.ActualizarTramiteArmaMenor(tramiteArmaMenorDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTramiteArmaMenor(int TramiteArmaMenorId)
        {
            TramiteArmaMenorDTO tramiteArmaMenorDTO = new();
            tramiteArmaMenorDTO.TramiteArmaMenorId = TramiteArmaMenorId;
            tramiteArmaMenorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tramiteArmaMenorBL.EliminarTramiteArmaMenor(tramiteArmaMenorDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}

