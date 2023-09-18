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
    public class GrupoRemunerativoController : Controller
    {
        readonly ILogger<GrupoRemunerativoController> _logger;

        public GrupoRemunerativoController(ILogger<GrupoRemunerativoController> logger)
        {
            _logger = logger;
        }

        readonly GrupoRemunerativoDAO grupoRemunerativoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Grupos Remunerativos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<GrupoRemunerativoDTO> listaGrupoRemunerativos = grupoRemunerativoBL.ObtenerGrupoRemunerativos();
            return Json(new { data = listaGrupoRemunerativos });
        }

        public ActionResult InsertarGrupoRemunerativo(string DescGrupoRemunerativo, string CodigoGrupoRemunerativo)
        {
            var IND_OPERACION = "";
            try
            {
                GrupoRemunerativoDTO grupoRemunerativoDTO = new();
                grupoRemunerativoDTO.DescGrupoRemunerativo = DescGrupoRemunerativo;
                grupoRemunerativoDTO.CodigoGrupoRemunerativo = CodigoGrupoRemunerativo;
                grupoRemunerativoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = grupoRemunerativoBL.AgregarGrupoRemunerativo(grupoRemunerativoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarGrupoRemunerativo(int GrupoRemunerativoId)
        {
            return Json(grupoRemunerativoBL.BuscarGrupoRemunerativoID(GrupoRemunerativoId));
        }

        public ActionResult ActualizarGrupoRemunerativo(int GrupoRemunerativoId, string DescGrupoRemunerativo, string CodigoGrupoRemunerativo)
        {
            GrupoRemunerativoDTO grupoRemunerativoDTO = new();
            grupoRemunerativoDTO.GrupoRemunerativoId = GrupoRemunerativoId;
            grupoRemunerativoDTO.DescGrupoRemunerativo = DescGrupoRemunerativo;
            grupoRemunerativoDTO.CodigoGrupoRemunerativo = CodigoGrupoRemunerativo;
            grupoRemunerativoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = grupoRemunerativoBL.ActualizarGrupoRemunerativo(grupoRemunerativoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarGrupoRemunerativo(int GrupoRemunerativoId)
        {
            GrupoRemunerativoDTO grupoRemunerativoDTO = new();
            grupoRemunerativoDTO.GrupoRemunerativoId = GrupoRemunerativoId;
            grupoRemunerativoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = grupoRemunerativoBL.EliminarGrupoRemunerativo(grupoRemunerativoDTO);

            return Content(IND_OPERACION);
        }
    }
}
