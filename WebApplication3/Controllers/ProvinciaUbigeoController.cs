using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class ProvinciaUbigeoController : Controller
    {
        readonly ILogger<ProvinciaUbigeoController> _logger;

        public ProvinciaUbigeoController(ILogger<ProvinciaUbigeoController> logger)
        {
            _logger = logger;
        }

        readonly ProvinciaUbigeo provinciaUbigeoBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Provincias Ubigeos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();

            return Json(new
            {
                data1 = departamentoUbigeoDTO
            });
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ProvinciaUbigeoDTO> listaProvinciaUbigeos = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            return Json(new { data = listaProvinciaUbigeos });
        }

        public ActionResult InsertarProvinciaUbigeo(string DescProvincia, string Ubigeo, int DepartamentoUbigeoId)
        {
            var IND_OPERACION = "";
            try
            {
                ProvinciaUbigeoDTO provinciaUbigeoDTO = new();
                provinciaUbigeoDTO.DescProvincia = DescProvincia;
                provinciaUbigeoDTO.Ubigeo = Ubigeo;
                provinciaUbigeoDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
                provinciaUbigeoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = provinciaUbigeoBL.AgregarProvinciaUbigeo(provinciaUbigeoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarProvinciaUbigeo(int ProvinciaUbigeoId)
        {
            return Json(provinciaUbigeoBL.BuscarProvinciaUbigeoID(ProvinciaUbigeoId));
        }

        public ActionResult ActualizarProvinciaUbigeo(int ProvinciaUbigeoId, string DescProvincia, string Ubigeo, int DepartamentoUbigeoId)
        {
            ProvinciaUbigeoDTO provinciaUbigeoDTO = new();
            provinciaUbigeoDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            provinciaUbigeoDTO.DescProvincia = DescProvincia;
            provinciaUbigeoDTO.Ubigeo = Ubigeo;
            provinciaUbigeoDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            provinciaUbigeoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = provinciaUbigeoBL.ActualizarProvinciaUbigeo(provinciaUbigeoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarProvinciaUbigeo(int ProvinciaUbigeoId)
        {
            ProvinciaUbigeoDTO provinciaUbigeoDTO = new();
            provinciaUbigeoDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            provinciaUbigeoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (provinciaUbigeoBL.EliminarProvinciaUbigeo(provinciaUbigeoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}

