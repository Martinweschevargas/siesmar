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
    public class PaisUbigeoController : Controller
    {
        readonly ILogger<PaisUbigeoController> _logger;

        public PaisUbigeoController(ILogger<PaisUbigeoController> logger)
        {
            _logger = logger;
        }

        readonly PaisUbigeoDAO paisUbigeoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Paises Ubigeos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<PaisUbigeoDTO> listaPaisUbigeos = paisUbigeoBL.ObtenerPaisUbigeos();
            return Json(new { data = listaPaisUbigeos });
        }

        public ActionResult InsertarPaisUbigeo(string CodIsoAlfa2, string NombrePais, string Numerico)
        {
            var IND_OPERACION = "";
            try
            {
                PaisUbigeoDTO paisUbigeoDTO = new();
                paisUbigeoDTO.CodIsoAlfa2 = CodIsoAlfa2;
                paisUbigeoDTO.NombrePais = NombrePais;
                paisUbigeoDTO.Numerico = Numerico;
                paisUbigeoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = paisUbigeoBL.AgregarPaisUbigeo(paisUbigeoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarPaisUbigeo(int PaisUbigeoId)
        {
            return Json(paisUbigeoBL.BuscarPaisUbigeoID(PaisUbigeoId));
        }

        public ActionResult ActualizarPaisUbigeo(int PaisUbigeoId, string CodIsoAlfa2, string NombrePais, string Numerico)
        {
            PaisUbigeoDTO paisUbigeoDTO = new();
            paisUbigeoDTO.PaisUbigeoId = PaisUbigeoId;
            paisUbigeoDTO.CodIsoAlfa2 = CodIsoAlfa2;
            paisUbigeoDTO.NombrePais = NombrePais;
            paisUbigeoDTO.Numerico = Numerico;
            paisUbigeoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = paisUbigeoBL.ActualizarPaisUbigeo(paisUbigeoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPaisUbigeo(int PaisUbigeoId)
        {
            PaisUbigeoDTO paisUbigeoDTO = new();
            paisUbigeoDTO.PaisUbigeoId = PaisUbigeoId;
            paisUbigeoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (paisUbigeoBL.EliminarPaisUbigeo(paisUbigeoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}

