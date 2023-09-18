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
    public class FinalidadPrestamoController : Controller
    {
        readonly ILogger<FinalidadPrestamoController> _logger;

        public FinalidadPrestamoController(ILogger<FinalidadPrestamoController> logger)
        {
            _logger = logger;
        }

        readonly FinalidadPrestamoDAO finalidadPrestamoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Finalidades Prestamos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<FinalidadPrestamoDTO> listaFinalidadPrestamos = finalidadPrestamoBL.ObtenerFinalidadPrestamos();
            return Json(new { data = listaFinalidadPrestamos });
        }

        public ActionResult InsertarFinalidadPrestamo(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                FinalidadPrestamoDTO finalidadPrestamoDTO = new();
                finalidadPrestamoDTO.DescFinalidadPrestamo = Descripcion;
                finalidadPrestamoDTO.CodigoFinalidadPrestamo = Codigo;
                finalidadPrestamoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = finalidadPrestamoBL.AgregarFinalidadPrestamo(finalidadPrestamoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarFinalidadPrestamo(int FinalidadPrestamoId)
        {
            return Json(finalidadPrestamoBL.BuscarFinalidadPrestamoID(FinalidadPrestamoId));
        }

        public ActionResult ActualizarFinalidadPrestamo(int FinalidadPrestamoId, string Codigo, string Descripcion)
        {
            FinalidadPrestamoDTO finalidadPrestamoDTO = new();
            finalidadPrestamoDTO.FinalidadPrestamoId = FinalidadPrestamoId;
            finalidadPrestamoDTO.DescFinalidadPrestamo = Descripcion;
            finalidadPrestamoDTO.CodigoFinalidadPrestamo = Codigo;
            finalidadPrestamoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = finalidadPrestamoBL.ActualizarFinalidadPrestamo(finalidadPrestamoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarFinalidadPrestamo(int FinalidadPrestamoId)
        {
            FinalidadPrestamoDTO finalidadPrestamoDTO = new();
            finalidadPrestamoDTO.FinalidadPrestamoId = FinalidadPrestamoId;
            finalidadPrestamoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = finalidadPrestamoBL.EliminarFinalidadPrestamo(finalidadPrestamoDTO);

            return Content(IND_OPERACION);
        }
    }
}
