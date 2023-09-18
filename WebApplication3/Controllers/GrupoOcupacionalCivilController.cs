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
    public class GrupoOcupacionalCivilController : Controller
    {
        readonly ILogger<GrupoOcupacionalCivilController> _logger;

        public GrupoOcupacionalCivilController(ILogger<GrupoOcupacionalCivilController> logger)
        {
            _logger = logger;
        }

        readonly GrupoOcupacionalCivilDAO grupoOcupacionalCivilBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Grupo Ocupacional Civil", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<GrupoOcupacionalCivilDTO> listaGrupoOcupacionalCivils = grupoOcupacionalCivilBL.ObtenerGrupoOcupacionalCivils();
            return Json(new { data = listaGrupoOcupacionalCivils });
        }

        public ActionResult InsertarGrupoOcupacionalCivil(string DescGrupoOcupacionalCivil, string CodigoGrupoOcupacionalCivil)
        {
            GrupoOcupacionalCivilDTO grupoOcupacionalCivilDTO = new();
            grupoOcupacionalCivilDTO.DescGrupoOcupacionalCivil = DescGrupoOcupacionalCivil;
            grupoOcupacionalCivilDTO.CodigoGrupoOcupacionalCivil = CodigoGrupoOcupacionalCivil;
            grupoOcupacionalCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = grupoOcupacionalCivilBL.AgregarGrupoOcupacionalCivil(grupoOcupacionalCivilDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarGrupoOcupacionalCivil(int GrupoOcupacionalCivilId)
        {
            return Json(grupoOcupacionalCivilBL.BuscarGrupoOcupacionalCivilID(GrupoOcupacionalCivilId));
        }

        public ActionResult ActualizarGrupoOcupacionalCivil(int GrupoOcupacionalCivilId, string DescGrupoOcupacionalCivil, string CodigoGrupoOcupacionalCivil)
        {
            GrupoOcupacionalCivilDTO grupoOcupacionalCivilDTO = new();
            grupoOcupacionalCivilDTO.GrupoOcupacionalCivilId = GrupoOcupacionalCivilId;
            grupoOcupacionalCivilDTO.DescGrupoOcupacionalCivil = DescGrupoOcupacionalCivil;
            grupoOcupacionalCivilDTO.CodigoGrupoOcupacionalCivil = CodigoGrupoOcupacionalCivil;
            grupoOcupacionalCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = grupoOcupacionalCivilBL.ActualizarGrupoOcupacionalCivil(grupoOcupacionalCivilDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarGrupoOcupacionalCivil(int grupoOcupacionalCivilId)
        {
            GrupoOcupacionalCivilDTO grupoOcupacionalCivilDTO = new();
            grupoOcupacionalCivilDTO.GrupoOcupacionalCivilId = grupoOcupacionalCivilId;
            grupoOcupacionalCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = grupoOcupacionalCivilBL.EliminarGrupoOcupacionalCivil(grupoOcupacionalCivilDTO);

            return Content(IND_OPERACION);
        }
       
    }
}
