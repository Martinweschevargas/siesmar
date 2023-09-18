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
    public class GradoEstudioEspecifController : Controller
    {
        readonly ILogger<GradoEstudioEspecifController> _logger;

        public GradoEstudioEspecifController(ILogger<GradoEstudioEspecifController> logger)
        {
            _logger = logger;
        }

        readonly GradoEstudioEspecifDAO gradoEstudioEspecifBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Grados Estudios Especificos", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<GradoEstudioEspecifDTO> listaGradoEstudioEspecifs = gradoEstudioEspecifBL.ObtenerGradoEstudioEspecifs();
            return Json(new { data = listaGradoEstudioEspecifs });
        }

        public ActionResult InsertarGradoEstudioEspecif(string DescGradoEstudioEspecif, string CodigoGradoEstudioEspecif)
        {
            var IND_OPERACION="";
            try
            {
                GradoEstudioEspecifDTO gradoEstudioEspecifDTO = new();
                gradoEstudioEspecifDTO.DescGradoEstudioEspecif = DescGradoEstudioEspecif;
                gradoEstudioEspecifDTO.CodigoGradoEstudioEspecif = CodigoGradoEstudioEspecif;
                gradoEstudioEspecifDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = gradoEstudioEspecifBL.AgregarGradoEstudioEspecif(gradoEstudioEspecifDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarGradoEstudioEspecif(int GradoEstudioEspecifId)
        {
            return Json(gradoEstudioEspecifBL.BuscarGradoEstudioEspecifID(GradoEstudioEspecifId));
        }

        public ActionResult ActualizarGradoEstudioEspecif(int GradoEstudioEspecifId, string DescGradoEstudioEspecif, string CodigoGradoEstudioEspecif)
        {
            GradoEstudioEspecifDTO gradoEstudioEspecifDTO = new();
            gradoEstudioEspecifDTO.GradoEstudioEspecifId = GradoEstudioEspecifId;
            gradoEstudioEspecifDTO.DescGradoEstudioEspecif = DescGradoEstudioEspecif;
            gradoEstudioEspecifDTO.CodigoGradoEstudioEspecif = CodigoGradoEstudioEspecif;
            gradoEstudioEspecifDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = gradoEstudioEspecifBL.ActualizarGradoEstudioEspecif(gradoEstudioEspecifDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarGradoEstudioEspecif(int GradoEstudioEspecifId)
        {
            GradoEstudioEspecifDTO gradoEstudioEspecifDTO = new();
            gradoEstudioEspecifDTO.GradoEstudioEspecifId = GradoEstudioEspecifId;
            gradoEstudioEspecifDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = gradoEstudioEspecifBL.EliminarGradoEstudioEspecif(gradoEstudioEspecifDTO);

            return Content(IND_OPERACION);
        }
    }
}
