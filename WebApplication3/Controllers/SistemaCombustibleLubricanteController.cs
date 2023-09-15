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
    public class SistemaCombustibleLubricanteController : Controller
    {
        readonly ILogger<SistemaCombustibleLubricanteController> _logger;

        public SistemaCombustibleLubricanteController(ILogger<SistemaCombustibleLubricanteController> logger)
        {
            _logger = logger;
        }

        readonly SistemaCombustibleLubricanteDAO sistemaCombustibleLubricanteBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Sistemas Combustibles Lubricantes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SistemaCombustibleLubricanteDTO> listaSistemaCombustibleLubricantes = sistemaCombustibleLubricanteBL.ObtenerSistemaCombustibleLubricantes();
            return Json(new { data = listaSistemaCombustibleLubricantes });
        }

        public ActionResult InsertarSistemaCombustibleLubricante(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                SistemaCombustibleLubricanteDTO sistemaCombustibleLubricanteDTO = new();
                sistemaCombustibleLubricanteDTO.DescSistemaCombustibleLubricante = Descripcion;
                sistemaCombustibleLubricanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = sistemaCombustibleLubricanteBL.AgregarSistemaCombustibleLubricante(sistemaCombustibleLubricanteDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSistemaCombustibleLubricante(int SistemaCombustibleLubricanteId)
        {
            return Json(sistemaCombustibleLubricanteBL.BuscarSistemaCombustibleLubricanteID(SistemaCombustibleLubricanteId));
        }

        public ActionResult ActualizarSistemaCombustibleLubricante(int SistemaCombustibleLubricanteId, string Descripcion)
        {
            SistemaCombustibleLubricanteDTO sistemaCombustibleLubricanteDTO = new();
            sistemaCombustibleLubricanteDTO.SistemaCombustibleLubricanteId = SistemaCombustibleLubricanteId;
            sistemaCombustibleLubricanteDTO.DescSistemaCombustibleLubricante = Descripcion;
            sistemaCombustibleLubricanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = sistemaCombustibleLubricanteBL.ActualizarSistemaCombustibleLubricante(sistemaCombustibleLubricanteDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSistemaCombustibleLubricante(int SistemaCombustibleLubricanteId)
        {
            SistemaCombustibleLubricanteDTO sistemaCombustibleLubricanteDTO = new();
            sistemaCombustibleLubricanteDTO.SistemaCombustibleLubricanteId = SistemaCombustibleLubricanteId;
            sistemaCombustibleLubricanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = sistemaCombustibleLubricanteBL.EliminarSistemaCombustibleLubricante(sistemaCombustibleLubricanteDTO);

            return Content(IND_OPERACION);
        }
    }
}
