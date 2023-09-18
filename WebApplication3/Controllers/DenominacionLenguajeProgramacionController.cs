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
    public class DenominacionLenguajeProgramacionController : Controller
    {
        readonly ILogger<DenominacionLenguajeProgramacionController> _logger;

        public DenominacionLenguajeProgramacionController(ILogger<DenominacionLenguajeProgramacionController> logger)
        {
            _logger = logger;
        }

        readonly DenominacionLenguajeProgramacionDAO denominacionLenguajeProgramacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "DenominacionLenguajeProgramacions", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DenominacionLenguajeProgramacionDTO> listaDenominacionLenguajeProgramacions = denominacionLenguajeProgramacionBL.ObtenerDenominacionLenguajeProgramacions();
            return Json(new { data = listaDenominacionLenguajeProgramacions });
        }

        public ActionResult InsertarDenominacionLenguajeProgramacion(string DescDenominacionLenguajeProgramacion, string CodigoDenominacionLenguajeProgramacion)
        {
            var IND_OPERACION="";
            try
            {
                DenominacionLenguajeProgramacionDTO denominacionLenguajeProgramacionDTO = new();
                denominacionLenguajeProgramacionDTO.DescDenominacionLenguajeProgramacion = DescDenominacionLenguajeProgramacion;
                denominacionLenguajeProgramacionDTO.CodigoDenominacionLenguajeProgramacion = CodigoDenominacionLenguajeProgramacion;
                denominacionLenguajeProgramacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = denominacionLenguajeProgramacionBL.AgregarDenominacionLenguajeProgramacion(denominacionLenguajeProgramacionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDenominacionLenguajeProgramacion(int DenominacionLenguajeProgramacionId)
        {
            return Json(denominacionLenguajeProgramacionBL.BuscarDenominacionLenguajeProgramacionID(DenominacionLenguajeProgramacionId));
        }

        public ActionResult ActualizarDenominacionLenguajeProgramacion(int DenominacionLenguajeProgramacionId, string DescDenominacionLenguajeProgramacion, string CodigoDenominacionLenguajeProgramacion)
        {
            DenominacionLenguajeProgramacionDTO denominacionLenguajeProgramacionDTO = new();
            denominacionLenguajeProgramacionDTO.DenominacionLenguajeProgramacionId = DenominacionLenguajeProgramacionId;
            denominacionLenguajeProgramacionDTO.DescDenominacionLenguajeProgramacion = DescDenominacionLenguajeProgramacion;
            denominacionLenguajeProgramacionDTO.CodigoDenominacionLenguajeProgramacion = CodigoDenominacionLenguajeProgramacion;
            denominacionLenguajeProgramacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = denominacionLenguajeProgramacionBL.ActualizarDenominacionLenguajeProgramacion(denominacionLenguajeProgramacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDenominacionLenguajeProgramacion(int DenominacionLenguajeProgramacionId)
        {
            DenominacionLenguajeProgramacionDTO denominacionLenguajeProgramacionDTO = new();
            denominacionLenguajeProgramacionDTO.DenominacionLenguajeProgramacionId = DenominacionLenguajeProgramacionId;
            denominacionLenguajeProgramacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = denominacionLenguajeProgramacionBL.EliminarDenominacionLenguajeProgramacion(denominacionLenguajeProgramacionDTO);

            return Content(IND_OPERACION);
        }
    }
}
