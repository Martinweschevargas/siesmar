using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class PublicidadEsnaController : Controller
    {
        readonly ILogger<PublicidadEsnaController> _logger;

        public PublicidadEsnaController(ILogger<PublicidadEsnaController> logger)
        {
            _logger = logger;
        }

        readonly PublicidadEsnaDAO publicidadEsnaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Publicidades Esnas", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<PublicidadEsnaDTO> listaPublicidadEsnas = publicidadEsnaBL.ObtenerPublicidadEsnas();
            return Json(new { data = listaPublicidadEsnas });
        }

        public ActionResult InsertarPublicidadEsna(string DescPublicidadEsna, string CodigoPublicidadEsna)
        {
            var IND_OPERACION="";
            try
            {
                PublicidadEsnaDTO publicidadEsnaDTO = new();
                publicidadEsnaDTO.DescPublicidadEsna = DescPublicidadEsna;
                publicidadEsnaDTO.CodigoPublicidadEsna = CodigoPublicidadEsna;
                publicidadEsnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = publicidadEsnaBL.AgregarPublicidadEsna(publicidadEsnaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarPublicidadEsna(int PublicidadEsnaId)
        {
            return Json(publicidadEsnaBL.BuscarPublicidadEsnaID(PublicidadEsnaId));
        }

        public ActionResult ActualizarPublicidadEsna(int PublicidadEsnaId, string DescPublicidadEsna, string CodigoPublicidadEsna)
        {
            PublicidadEsnaDTO publicidadEsnaDTO = new();
            publicidadEsnaDTO.PublicidadEsnaId = PublicidadEsnaId;
            publicidadEsnaDTO.DescPublicidadEsna = DescPublicidadEsna;
            publicidadEsnaDTO.CodigoPublicidadEsna = CodigoPublicidadEsna;
            publicidadEsnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = publicidadEsnaBL.ActualizarPublicidadEsna(publicidadEsnaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPublicidadEsna(int PublicidadEsnaId)
        {
            PublicidadEsnaDTO publicidadEsnaDTO = new();
            publicidadEsnaDTO.PublicidadEsnaId = PublicidadEsnaId;
            publicidadEsnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = publicidadEsnaBL.EliminarPublicidadEsna(publicidadEsnaDTO);

            return Content(IND_OPERACION);
        }
    }
}
