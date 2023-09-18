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
    public class DepartamentoUbigeoController : Controller
    {
        readonly ILogger<DepartamentoUbigeoController> _logger;

        public DepartamentoUbigeoController(ILogger<DepartamentoUbigeoController> logger)
        {
            _logger = logger;
        }

        readonly DepartamentoUbigeoDAO departamentoUbigeoBL = new();
        Usuario usuarioBL = new();

        PaisUbigeo paisUbigeoBL = new();
        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Departamentos Ubigeos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<PaisUbigeoDTO> paisUbigeoDTO = paisUbigeoBL.ObtenerPaisUbigeos();


            return Json(new{ data1 = paisUbigeoDTO });
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DepartamentoUbigeoDTO> listaDepartamentoUbigeos = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            return Json(new { data = listaDepartamentoUbigeos });
        }

        public ActionResult InsertarDepartamentoUbigeo(string DescDepartamento, string Ubigeo, int PaisUbigeoId)
        {
            var IND_OPERACION = "";
            try
            {
                DepartamentoUbigeoDTO departamentoUbigeoDTO = new();
                departamentoUbigeoDTO.DescDepartamento = DescDepartamento;
                departamentoUbigeoDTO.Ubigeo = Ubigeo;
                departamentoUbigeoDTO.PaisUbigeoId = PaisUbigeoId;
                departamentoUbigeoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = departamentoUbigeoBL.AgregarDepartamentoUbigeo(departamentoUbigeoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDepartamentoUbigeo(int DepartamentoUbigeoId)
        {
            return Json(departamentoUbigeoBL.BuscarDepartamentoUbigeoID(DepartamentoUbigeoId));
        }

        public ActionResult ActualizarDepartamentoUbigeo(int DepartamentoUbigeoId, string DescDepartamento, string Ubigeo, int PaisUbigeoId)
        {
            DepartamentoUbigeoDTO departamentoUbigeoDTO = new();
            departamentoUbigeoDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            departamentoUbigeoDTO.DescDepartamento = DescDepartamento;
            departamentoUbigeoDTO.Ubigeo = Ubigeo;
            departamentoUbigeoDTO.PaisUbigeoId = PaisUbigeoId;
            departamentoUbigeoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = departamentoUbigeoBL.ActualizarDepartamentoUbigeo(departamentoUbigeoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDepartamentoUbigeo(int DepartamentoUbigeoId)
        {
            DepartamentoUbigeoDTO departamentoUbigeoDTO = new();
            departamentoUbigeoDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            departamentoUbigeoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (departamentoUbigeoBL.EliminarDepartamentoUbigeo(departamentoUbigeoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
