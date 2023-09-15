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
    public class TipoEntidadAcademicaController : Controller
    {
        readonly ILogger<TipoEntidadAcademicaController> _logger;

        public TipoEntidadAcademicaController(ILogger<TipoEntidadAcademicaController> logger)
        {
            _logger = logger;
        }

        readonly TipoEntidadAcademicaDAO tipoEntidadAcademicaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Entidades Académicas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoEntidadAcademicaDTO> listaTipoEntidadAcademicas = tipoEntidadAcademicaBL.ObtenerTipoEntidadAcademicas();
            return Json(new { data = listaTipoEntidadAcademicas });
        }

        public ActionResult InsertarTipoEntidadAcademica(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoEntidadAcademicaDTO tipoEntidadAcademicaDTO = new();
                tipoEntidadAcademicaDTO.DescTipoEntidadAcademica = Descripcion;
                tipoEntidadAcademicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoEntidadAcademicaBL.AgregarTipoEntidadAcademica(tipoEntidadAcademicaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoEntidadAcademica(int TipoEntidadAcademicaId)
        {
            return Json(tipoEntidadAcademicaBL.BuscarTipoEntidadAcademicaID(TipoEntidadAcademicaId));
        }

        public ActionResult ActualizarTipoEntidadAcademica(int TipoEntidadAcademicaId, string Descripcion)
        {
            TipoEntidadAcademicaDTO tipoEntidadAcademicaDTO = new();
            tipoEntidadAcademicaDTO.TipoEntidadAcademicaId = TipoEntidadAcademicaId;
            tipoEntidadAcademicaDTO.DescTipoEntidadAcademica = Descripcion;
            tipoEntidadAcademicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoEntidadAcademicaBL.ActualizarTipoEntidadAcademica(tipoEntidadAcademicaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoEntidadAcademica(int TipoEntidadAcademicaId)
        {
            TipoEntidadAcademicaDTO tipoEntidadAcademicaDTO = new();
            tipoEntidadAcademicaDTO.TipoEntidadAcademicaId = TipoEntidadAcademicaId;
            tipoEntidadAcademicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoEntidadAcademicaBL.EliminarTipoEntidadAcademica(tipoEntidadAcademicaDTO);

            return Content(IND_OPERACION);
        }
    }
}
