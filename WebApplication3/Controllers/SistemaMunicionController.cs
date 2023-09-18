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
    public class SistemaMunicionController : Controller
    {
        readonly ILogger<SistemaMunicionController> _logger;

        public SistemaMunicionController(ILogger<SistemaMunicionController> logger)
        {
            _logger = logger;
        }

        readonly SistemaMunicionDAO sistemaMunicionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Sistemas Municiones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SistemaMunicionDTO> listaSistemaMunicions = sistemaMunicionBL.ObtenerSistemaMunicions();
            return Json(new { data = listaSistemaMunicions });
        }

        public ActionResult InsertarSistemaMunicion(string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                SistemaMunicionDTO sistemaMunicionDTO = new();
                sistemaMunicionDTO.DescSistemaMunicion = Descripcion;
                sistemaMunicionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = sistemaMunicionBL.AgregarSistemaMunicion(sistemaMunicionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSistemaMunicion(int SistemaMunicionId)
        {
            return Json(sistemaMunicionBL.BuscarSistemaMunicionID(SistemaMunicionId));
        }

        public ActionResult ActualizarSistemaMunicion(int SistemaMunicionId, string Descripcion)
        {
            SistemaMunicionDTO sistemaMunicionDTO = new();
            sistemaMunicionDTO.SistemaMunicionId = SistemaMunicionId;
            sistemaMunicionDTO.DescSistemaMunicion = Descripcion;
            sistemaMunicionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = sistemaMunicionBL.ActualizarSistemaMunicion(sistemaMunicionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSistemaMunicion(int SistemaMunicionId)
        {
            SistemaMunicionDTO sistemaMunicionDTO = new();
            sistemaMunicionDTO.SistemaMunicionId = SistemaMunicionId;
            sistemaMunicionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = sistemaMunicionBL.EliminarSistemaMunicion(sistemaMunicionDTO);

            return Content(IND_OPERACION);
        }
    }
}
