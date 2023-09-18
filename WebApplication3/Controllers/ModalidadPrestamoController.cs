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
    public class ModalidadPrestamoController : Controller
    {
        readonly ILogger<ModalidadPrestamoController> _logger;

        public ModalidadPrestamoController(ILogger<ModalidadPrestamoController> logger)
        {
            _logger = logger;
        }

        readonly ModalidadPrestamo modalidadPrestamoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Modalidades Préstamos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ModalidadPrestamoDTO> listaModalidadPrestamos = modalidadPrestamoBL.ObtenerModalidadPrestamos();
            return Json(new { data = listaModalidadPrestamos });
        }

        public ActionResult InsertarModalidadPrestamo(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ModalidadPrestamoDTO modalidadPrestamoDTO = new();
                modalidadPrestamoDTO.DescModalidadPrestamo = Descripcion;
                modalidadPrestamoDTO.CodigoModalidadPrestamo = Codigo;
                modalidadPrestamoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = modalidadPrestamoBL.AgregarModalidadPrestamo(modalidadPrestamoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarModalidadPrestamo(int ModalidadPrestamoId)
        {
            return Json(modalidadPrestamoBL.BuscarModalidadPrestamoID(ModalidadPrestamoId));
        }

        public ActionResult ActualizarModalidadPrestamo(int ModalidadPrestamoId, string Codigo, string Descripcion)
        {
            ModalidadPrestamoDTO modalidadPrestamoDTO = new();
            modalidadPrestamoDTO.ModalidadPrestamoId = ModalidadPrestamoId;
            modalidadPrestamoDTO.DescModalidadPrestamo = Descripcion;
            modalidadPrestamoDTO.CodigoModalidadPrestamo = Codigo;
            modalidadPrestamoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = modalidadPrestamoBL.ActualizarModalidadPrestamo(modalidadPrestamoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarModalidadPrestamo(int ModalidadPrestamoId)
        {
            ModalidadPrestamoDTO modalidadPrestamoDTO = new();
            modalidadPrestamoDTO.ModalidadPrestamoId = ModalidadPrestamoId;
            modalidadPrestamoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = modalidadPrestamoBL.EliminarModalidadPrestamo(modalidadPrestamoDTO);

            return Content(IND_OPERACION);
        }
    }
}
