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
    public class AreaTecnicaController : Controller
    {
        readonly ILogger<AreaTecnicaController> _logger;

        public AreaTecnicaController(ILogger<AreaTecnicaController> logger)
        {
            _logger = logger;
        }

        readonly AreaTecnica areaTecnicaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Areas Tecnicas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<AreaTecnicaDTO> listaAreaTecnicas = areaTecnicaBL.ObtenerAreaTecnicas();
            return Json(new { data = listaAreaTecnicas });
        }

        public ActionResult InsertarAreaTecnica(string DescAreaTecnica, string CodigoAreaTecnica)
        {
            var IND_OPERACION = "";
            try
            {
                AreaTecnicaDTO areaTecnicaDTO = new();
                areaTecnicaDTO.DescAreaTecnica = DescAreaTecnica;
                areaTecnicaDTO.CodigoAreaTecnica = CodigoAreaTecnica;
                areaTecnicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = areaTecnicaBL.AgregarAreaTecnica(areaTecnicaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAreaTecnica(int AreaTecnicaId)
        {
            return Json(areaTecnicaBL.BuscarAreaTecnicaID(AreaTecnicaId));
        }

        public ActionResult ActualizarAreaTecnica(int AreaTecnicaId, string DescAreaTecnica, string CodigoAreaTecnica)
        {
            AreaTecnicaDTO areaTecnicaDTO = new();
            areaTecnicaDTO.AreaTecnicaId = AreaTecnicaId;
            areaTecnicaDTO.DescAreaTecnica = DescAreaTecnica;
            areaTecnicaDTO.CodigoAreaTecnica = CodigoAreaTecnica;
            areaTecnicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = areaTecnicaBL.ActualizarAreaTecnica(areaTecnicaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAreaTecnica(int AreaTecnicaId)
        {
            AreaTecnicaDTO areaTecnicaDTO = new();
            areaTecnicaDTO.AreaTecnicaId = AreaTecnicaId;
            areaTecnicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (areaTecnicaBL.EliminarAreaTecnica(areaTecnicaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}

