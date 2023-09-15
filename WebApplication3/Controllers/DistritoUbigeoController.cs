using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DistritoUbigeoController : Controller
    {
        readonly ILogger<DistritoUbigeoController> _logger;

        public DistritoUbigeoController(ILogger<DistritoUbigeoController> logger)
        {
            _logger = logger;
        }

        readonly DistritoUbigeo distritoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Distritos Ubigeos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();

            return Json(new
            {
                data1 = provinciaUbigeoDTO
            });
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DistritoUbigeoDTO> listaDistritoUbigeos = distritoUbigeoBL.ObtenerDistritoUbigeos();
            return Json(new { data = listaDistritoUbigeos });
        }

        public ActionResult InsertarDistritoUbigeo(string DescDistrito, string DistritoUbigeo, int ProvinciaUbigeoId)
        {
            var IND_OPERACION = "";
            try
            {
                DistritoUbigeoDTO distritoUbigeoDTO = new();
                distritoUbigeoDTO.DescDistrito = DescDistrito;
                distritoUbigeoDTO.DistritoUbigeo = DistritoUbigeo;
                distritoUbigeoDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
                distritoUbigeoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = distritoUbigeoBL.AgregarDistritoUbigeo(distritoUbigeoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDistritoUbigeo(int DistritoUbigeoId)
        {
            return Json(distritoUbigeoBL.BuscarDistritoUbigeoID(DistritoUbigeoId));
        }

        public ActionResult ActualizarDistritoUbigeo(int DistritoUbigeoId, string DescDistrito, string DistritoUbigeo, int ProvinciaUbigeoId)
        {
            DistritoUbigeoDTO distritoUbigeoDTO = new();
            distritoUbigeoDTO.DistritoUbigeoId = DistritoUbigeoId;
            distritoUbigeoDTO.DescDistrito = DescDistrito;
            distritoUbigeoDTO.DistritoUbigeo = DistritoUbigeo;
            distritoUbigeoDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            distritoUbigeoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = distritoUbigeoBL.ActualizarDistritoUbigeo(distritoUbigeoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDistritoUbigeo(int DistritoUbigeoId)
        {
            DistritoUbigeoDTO distritoUbigeoDTO = new();
            distritoUbigeoDTO.DistritoUbigeoId = DistritoUbigeoId;
            distritoUbigeoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (distritoUbigeoBL.EliminarDistritoUbigeo(distritoUbigeoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}

