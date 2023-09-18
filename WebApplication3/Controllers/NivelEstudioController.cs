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
    public class NivelEstudioController : Controller
    {
        readonly ILogger<NivelEstudioController> _logger;

        public NivelEstudioController(ILogger<NivelEstudioController> logger)
        {
            _logger = logger;
        }

        readonly NivelEstudioDAO nivelEstudioBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Niveles Estudios", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<NivelEstudioDTO> listaNivelEstudios = nivelEstudioBL.ObtenerNivelEstudios();
            return Json(new { data = listaNivelEstudios });
        }

        public ActionResult InsertarNivelEstudio(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                NivelEstudioDTO nivelEstudioDTO = new();
                nivelEstudioDTO.DescNivelEstudio = Descripcion;
                nivelEstudioDTO.CodigoNivelEstudio = Codigo;
                nivelEstudioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = nivelEstudioBL.AgregarNivelEstudio(nivelEstudioDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarNivelEstudio(int NivelEstudioId)
        {
            return Json(nivelEstudioBL.BuscarNivelEstudioID(NivelEstudioId));
        }

        public ActionResult ActualizarNivelEstudio(int NivelEstudioId, string Codigo, string Descripcion)
        {
            NivelEstudioDTO nivelEstudioDTO = new();
            nivelEstudioDTO.NivelEstudioId = NivelEstudioId;
            nivelEstudioDTO.DescNivelEstudio = Descripcion;
            nivelEstudioDTO.CodigoNivelEstudio = Codigo;
            nivelEstudioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = nivelEstudioBL.ActualizarNivelEstudio(nivelEstudioDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarNivelEstudio(int NivelEstudioId)
        {
            NivelEstudioDTO nivelEstudioDTO = new();
            nivelEstudioDTO.NivelEstudioId = NivelEstudioId;
            nivelEstudioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = nivelEstudioBL.EliminarNivelEstudio(nivelEstudioDTO);

            return Content(IND_OPERACION);
        }
    }
}
