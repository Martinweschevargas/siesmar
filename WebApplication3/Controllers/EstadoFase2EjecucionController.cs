using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class EstadoFase2EjecucionController : Controller
    {
        readonly EstadoFase2EjecucionDAO estadoFase2EjecucionBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Estados Fase 2 Ejecuciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EstadoFase2EjecucionDTO> listaEstadoFase2Ejecucions = estadoFase2EjecucionBL.ObtenerEstadoFase2Ejecucions();
            return Json(new { data = listaEstadoFase2Ejecucions });
        }

        public ActionResult InsertarEstadoFase2Ejecucion(string DescEstadoFase2Ejecucion, string CodigoEstadoFase2Ejecucion)
        {
            EstadoFase2EjecucionDTO estadoFase2EjecucionDTO = new();
            estadoFase2EjecucionDTO.DescEstadoFase2Ejecucion = DescEstadoFase2Ejecucion;
            estadoFase2EjecucionDTO.CodigoEstadoFase2Ejecucion = CodigoEstadoFase2Ejecucion;
            estadoFase2EjecucionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = estadoFase2EjecucionBL.AgregarEstadoFase2Ejecucion(estadoFase2EjecucionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEstadoFase2Ejecucion(int EstadoFase2EjecucionId)
        {
            return Json(estadoFase2EjecucionBL.BuscarEstadoFase2EjecucionID(EstadoFase2EjecucionId));
        }

        public ActionResult ActualizarEstadoFase2Ejecucion(int EstadoFase2EjecucionId, string DescEstadoFase2Ejecucion, string CodigoEstadoFase2Ejecucion)
        {
            EstadoFase2EjecucionDTO estadoFase2EjecucionDTO = new();
            estadoFase2EjecucionDTO.EstadoFase2EjecucionId = EstadoFase2EjecucionId;
            estadoFase2EjecucionDTO.DescEstadoFase2Ejecucion = DescEstadoFase2Ejecucion;
            estadoFase2EjecucionDTO.CodigoEstadoFase2Ejecucion = CodigoEstadoFase2Ejecucion;
            estadoFase2EjecucionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = estadoFase2EjecucionBL.ActualizarEstadoFase2Ejecucion(estadoFase2EjecucionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEstadoFase2Ejecucion(int EstadoFase2EjecucionId)
        {
            EstadoFase2EjecucionDTO estadoFase2EjecucionDTO = new();
            estadoFase2EjecucionDTO.EstadoFase2EjecucionId = EstadoFase2EjecucionId;
            estadoFase2EjecucionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (estadoFase2EjecucionBL.EliminarEstadoFase2Ejecucion(estadoFase2EjecucionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
