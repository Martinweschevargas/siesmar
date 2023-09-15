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
    public class GradoRemunerativoGrupoController : Controller
    {
        readonly ILogger<GradoRemunerativoGrupoController> _logger;

        public GradoRemunerativoGrupoController(ILogger<GradoRemunerativoGrupoController> logger)
        {
            _logger = logger;
        }

        readonly GradoRemunerativoGrupoDAO gradoRemunerativoGrupoBL = new();
        Usuario usuarioBL = new();

        GrupoRemunerativoDAO grupoRemunerativoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Grados Remunerativos Grupos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<GrupoRemunerativoDTO> grupoRemunerativoDTO = grupoRemunerativoBL.ObtenerGrupoRemunerativos();

            return Json(new { data = grupoRemunerativoDTO });
        }

        public JsonResult CargarDatos()
        {
            List<GradoRemunerativoGrupoDTO> listaGradoRemunerativoGrupos = gradoRemunerativoGrupoBL.ObtenerGradoRemunerativoGrupos();
            return Json(new { data = listaGradoRemunerativoGrupos });
        }

        public ActionResult InsertarGradoRemunerativoGrupo(string DescGradoRemunerativoGrupo, int GrupoRemunerativoId )
        {
            var IND_OPERACION = "";
            try
            {
                GradoRemunerativoGrupoDTO gradoRemunerativoGrupoDTO = new();
                gradoRemunerativoGrupoDTO.DescGradoRemunerativoGrupo = DescGradoRemunerativoGrupo;
                gradoRemunerativoGrupoDTO.GrupoRemunerativoId = GrupoRemunerativoId;
                gradoRemunerativoGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = gradoRemunerativoGrupoBL.AgregarGradoRemunerativoGrupo(gradoRemunerativoGrupoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarGradoRemunerativoGrupo(int GradoRemunerativoGrupoId)
        {
            return Json(gradoRemunerativoGrupoBL.BuscarGradoRemunerativoGrupoID(GradoRemunerativoGrupoId));
        }

        public ActionResult ActualizarGradoRemunerativoGrupo(int GradoRemunerativoGrupoId, string DescGradoRemunerativoGrupo, int GrupoRemunerativoId )
        {
            GradoRemunerativoGrupoDTO gradoRemunerativoGrupoDTO = new();
            gradoRemunerativoGrupoDTO.GradoRemunerativoGrupoId = GradoRemunerativoGrupoId;
            gradoRemunerativoGrupoDTO.DescGradoRemunerativoGrupo = DescGradoRemunerativoGrupo;
            gradoRemunerativoGrupoDTO.GrupoRemunerativoId = GrupoRemunerativoId;
            gradoRemunerativoGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = gradoRemunerativoGrupoBL.ActualizarGradoRemunerativoGrupo(gradoRemunerativoGrupoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarGradoRemunerativoGrupo(int GradoRemunerativoGrupoId)
        {
            GradoRemunerativoGrupoDTO gradoRemunerativoGrupoDTO = new();
            gradoRemunerativoGrupoDTO.GradoRemunerativoGrupoId = GradoRemunerativoGrupoId;
            gradoRemunerativoGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = gradoRemunerativoGrupoBL.EliminarGradoRemunerativoGrupo(gradoRemunerativoGrupoDTO);

            return Content(IND_OPERACION);
        }
    }
}

