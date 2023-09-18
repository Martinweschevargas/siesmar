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
    public class GrupoPuertoPeruController : Controller
    {
        readonly ILogger<GrupoPuertoPeruController> _logger;

        public GrupoPuertoPeruController(ILogger<GrupoPuertoPeruController> logger)
        {
            _logger = logger;
        }

        readonly GrupoPuertoPeruDAO GrupoPuertoPeruBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Grupos Puertos Peruanos", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<GrupoPuertoPeruDTO> listaGrupoPuertoPerus = GrupoPuertoPeruBL.ObtenerGrupoPuertoPerus();
            return Json(new { data = listaGrupoPuertoPerus });
        }

        public ActionResult InsertarGrupoPuertoPeru(string Codigo, string Descripcion)
        {
            var IND_OPERACION="";
            try
            {
                GrupoPuertoPeruDTO GrupoPuertoPeruDTO = new();
                GrupoPuertoPeruDTO.DescGrupoPuertoPeru = Descripcion;
                GrupoPuertoPeruDTO.CodigoGrupoPuertoPeru = Codigo;
                GrupoPuertoPeruDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = GrupoPuertoPeruBL.AgregarGrupoPuertoPeru(GrupoPuertoPeruDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarGrupoPuertoPeru(int GrupoPuertoPeruId)
        {
            return Json(GrupoPuertoPeruBL.BuscarGrupoPuertoPeruID(GrupoPuertoPeruId));
        }

        public ActionResult ActualizarGrupoPuertoPeru(int GrupoPuertoPeruId, string Codigo, string Descripcion)
        {
            GrupoPuertoPeruDTO GrupoPuertoPeruDTO = new();
            GrupoPuertoPeruDTO.GrupoPuertoPeruId = GrupoPuertoPeruId;
            GrupoPuertoPeruDTO.DescGrupoPuertoPeru = Descripcion;
            GrupoPuertoPeruDTO.CodigoGrupoPuertoPeru = Codigo;
            GrupoPuertoPeruDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = GrupoPuertoPeruBL.ActualizarGrupoPuertoPeru(GrupoPuertoPeruDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarGrupoPuertoPeru(int GrupoPuertoPeruId)
        {
            GrupoPuertoPeruDTO GrupoPuertoPeruDTO = new();
            GrupoPuertoPeruDTO.GrupoPuertoPeruId = GrupoPuertoPeruId;
            GrupoPuertoPeruDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = GrupoPuertoPeruBL.EliminarGrupoPuertoPeru(GrupoPuertoPeruDTO);

            return Content(IND_OPERACION);
        }
    }
}
