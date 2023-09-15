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
    public class GradoRemunerativoController : Controller
    {
        readonly ILogger<GradoRemunerativoController> _logger;

        public GradoRemunerativoController(ILogger<GradoRemunerativoController> logger)
        {
            _logger = logger;
        }

        readonly GradoRemunerativoDAO gradoRemunerativoBL = new();
        Usuario usuarioBL = new();
        GradoRemunerativoGrupoDAO gradoRemunerativoGrupoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Grados Remunerativos", FromController = typeof(HomeController))]

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<GradoRemunerativoGrupoDTO> gradoRemunerativoGrupoDTO = gradoRemunerativoGrupoBL.ObtenerGradoRemunerativoGrupos();

            return Json(new { data = gradoRemunerativoGrupoDTO });
        }

        public JsonResult CargarDatos()
        {
            List<GradoRemunerativoDTO> listaGradoRemunerativos = gradoRemunerativoBL.ObtenerGradoRemunerativos();
            return Json(new { data = listaGradoRemunerativos });
        }

        public ActionResult InsertarGradoRemunerativo(string DescGradoRemunerativo, int GradoRemunerativoGrupoId, string CodigoGradoRemunerativo )
        {
            GradoRemunerativoDTO gradoRemunerativoDTO = new();
            gradoRemunerativoDTO.CodigoGradoRemunerativo = CodigoGradoRemunerativo;
            gradoRemunerativoDTO.DescGradoRemunerativo = DescGradoRemunerativo;
            gradoRemunerativoDTO.GradoRemunerativoGrupoId = GradoRemunerativoGrupoId;
            gradoRemunerativoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = gradoRemunerativoBL.AgregarGradoRemunerativo(gradoRemunerativoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarGradoRemunerativo(int GradoRemunerativoId)
        {
            return Json(gradoRemunerativoBL.BuscarGradoRemunerativoID(GradoRemunerativoId));
        }

        public ActionResult ActualizarGradoRemunerativo(int GradoRemunerativoId, string DescGradoRemunerativo, 
            int GradoRemunerativoGrupoId, string CodigoGradoRemunerativo)
        {
            GradoRemunerativoDTO gradoRemunerativoDTO = new();
            gradoRemunerativoDTO.GradoRemunerativoId = GradoRemunerativoId;
            gradoRemunerativoDTO.CodigoGradoRemunerativo = CodigoGradoRemunerativo;
            gradoRemunerativoDTO.DescGradoRemunerativo = DescGradoRemunerativo;
            gradoRemunerativoDTO.GradoRemunerativoGrupoId = GradoRemunerativoGrupoId;
            gradoRemunerativoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = gradoRemunerativoBL.ActualizarGradoRemunerativo(gradoRemunerativoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarGradoRemunerativo(int GradoRemunerativoId)
        {
            GradoRemunerativoDTO gradoRemunerativoDTO = new();
            gradoRemunerativoDTO.GradoRemunerativoId = GradoRemunerativoId;
            gradoRemunerativoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = gradoRemunerativoBL.EliminarGradoRemunerativo(gradoRemunerativoDTO);

            return Content(IND_OPERACION);
        }
    }
}
