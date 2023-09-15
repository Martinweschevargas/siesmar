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
    public class ModalidadProgramaController : Controller
    {
        readonly ILogger<ModalidadProgramaController> _logger;

        public ModalidadProgramaController(ILogger<ModalidadProgramaController> logger)
        {
            _logger = logger;
        }

        readonly ModalidadPrograma modalidadProgramaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Modalidades Programas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ModalidadProgramaDTO> listaModalidadProgramas = modalidadProgramaBL.ObtenerModalidadProgramas();
            return Json(new { data = listaModalidadProgramas });
        }

        public ActionResult InsertarModalidadPrograma(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ModalidadProgramaDTO modalidadProgramaDTO = new();
                modalidadProgramaDTO.DescModalidadPrograma = Descripcion;
                modalidadProgramaDTO.CodigoModalidadPrograma = Codigo;
                modalidadProgramaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = modalidadProgramaBL.AgregarModalidadPrograma(modalidadProgramaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarModalidadPrograma(int ModalidadProgramaId)
        {
            return Json(modalidadProgramaBL.BuscarModalidadProgramaID(ModalidadProgramaId));
        }

        public ActionResult ActualizarModalidadPrograma(int ModalidadProgramaId, string Codigo, string Descripcion)
        {
            ModalidadProgramaDTO modalidadProgramaDTO = new();
            modalidadProgramaDTO.ModalidadProgramaId = ModalidadProgramaId;
            modalidadProgramaDTO.DescModalidadPrograma = Descripcion;
            modalidadProgramaDTO.CodigoModalidadPrograma = Codigo;
            modalidadProgramaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = modalidadProgramaBL.ActualizarModalidadPrograma(modalidadProgramaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarModalidadPrograma(int ModalidadProgramaId)
        {
            ModalidadProgramaDTO modalidadProgramaDTO = new();
            modalidadProgramaDTO.ModalidadProgramaId = ModalidadProgramaId;
            modalidadProgramaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = modalidadProgramaBL.EliminarModalidadPrograma(modalidadProgramaDTO);

            return Content(IND_OPERACION);
        }
    }
}
