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
    public class ProyectoFovimarController : Controller
    {
        readonly ILogger<ProyectoFovimarController> _logger;

        public ProyectoFovimarController(ILogger<ProyectoFovimarController> logger)
        {
            _logger = logger;
        }

        readonly ProyectoFovimar proyectoFovimarBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Proyectos Fovimar", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ProyectoFovimarDTO> listaProyectoFovimars = proyectoFovimarBL.ObtenerProyectoFovimars();
            return Json(new { data = listaProyectoFovimars });
        }

        public ActionResult InsertarProyectoFovimar(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                ProyectoFovimarDTO proyectoFovimarDTO = new();
                proyectoFovimarDTO.DescProyectoFovimar = Descripcion;
                proyectoFovimarDTO.CodigoProyectoFovimar = Codigo;
                proyectoFovimarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = proyectoFovimarBL.AgregarProyectoFovimar(proyectoFovimarDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarProyectoFovimar(int ProyectoFovimarId)
        {
            return Json(proyectoFovimarBL.BuscarProyectoFovimarID(ProyectoFovimarId));
        }

        public ActionResult ActualizarProyectoFovimar(int ProyectoFovimarId, string Codigo, string Descripcion)
        {
            ProyectoFovimarDTO proyectoFovimarDTO = new();
            proyectoFovimarDTO.ProyectoFovimarId = ProyectoFovimarId;
            proyectoFovimarDTO.DescProyectoFovimar = Descripcion;
            proyectoFovimarDTO.CodigoProyectoFovimar = Codigo;
            proyectoFovimarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = proyectoFovimarBL.ActualizarProyectoFovimar(proyectoFovimarDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarProyectoFovimar(int ProyectoFovimarId)
        {
            ProyectoFovimarDTO proyectoFovimarDTO = new();
            proyectoFovimarDTO.ProyectoFovimarId = ProyectoFovimarId;
            proyectoFovimarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = proyectoFovimarBL.EliminarProyectoFovimar(proyectoFovimarDTO);

            return Content(IND_OPERACION);
        }
    }
}
