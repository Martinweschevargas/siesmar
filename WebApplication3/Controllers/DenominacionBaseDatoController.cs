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
    public class DenominacionBaseDatosController : Controller
    {
        readonly ILogger<DenominacionBaseDatosController> _logger;

        public DenominacionBaseDatosController(ILogger<DenominacionBaseDatosController> logger)
        {
            _logger = logger;
        }

        readonly DenominacionBaseDatoDAO denominacionBaseDatoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Denominaciones Bases de Datos", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DenominacionBaseDatoDTO> listaDenominacionBaseDatos = denominacionBaseDatoBL.ObtenerDenominacionBaseDatos();
            return Json(new { data = listaDenominacionBaseDatos });
        }

        public ActionResult InsertarDenominacionBaseDato(string DescDenominacionBaseDato, string CodigoDenominacionBaseDato)
        {
            var IND_OPERACION="";
            try
            {
                DenominacionBaseDatoDTO denominacionBaseDatoDTO = new();
                denominacionBaseDatoDTO.DescDenominacionBaseDato = DescDenominacionBaseDato;
                denominacionBaseDatoDTO.CodigoDenominacionBaseDato = CodigoDenominacionBaseDato;
                denominacionBaseDatoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = denominacionBaseDatoBL.AgregarDenominacionBaseDato(denominacionBaseDatoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDenominacionBaseDato(int DenominacionBaseDatoId)
        {
            return Json(denominacionBaseDatoBL.BuscarDenominacionBaseDatoID(DenominacionBaseDatoId));
        }

        public ActionResult ActualizarDenominacionBaseDato(int DenominacionBaseDatoId, string DescDenominacionBaseDato, string CodigoDenominacionBaseDato)
        {
            DenominacionBaseDatoDTO denominacionBaseDatoDTO = new();
            denominacionBaseDatoDTO.DenominacionBaseDatoId = DenominacionBaseDatoId;
            denominacionBaseDatoDTO.DescDenominacionBaseDato = DescDenominacionBaseDato;
            denominacionBaseDatoDTO.CodigoDenominacionBaseDato = CodigoDenominacionBaseDato;
            denominacionBaseDatoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = denominacionBaseDatoBL.ActualizarDenominacionBaseDato(denominacionBaseDatoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDenominacionBaseDato(int DenominacionBaseDatoId)
        {
            DenominacionBaseDatoDTO denominacionBaseDatoDTO = new();
            denominacionBaseDatoDTO.DenominacionBaseDatoId = DenominacionBaseDatoId;
            denominacionBaseDatoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = denominacionBaseDatoBL.EliminarDenominacionBaseDato(denominacionBaseDatoDTO);

            return Content(IND_OPERACION);
        }
    }
}
