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
    public class EventoController : Controller
    {
        readonly EventoDAO eventoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Eventos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EventoDTO> listaEventos = eventoBL.ObtenerEventos();
            return Json(new { data = listaEventos });
        }

        public ActionResult InsertarEvento(string DescEvento, string CodigoEvento)
        {
            EventoDTO eventoDTO = new();
            eventoDTO.DescEvento = DescEvento;
            eventoDTO.CodigoEvento = CodigoEvento;
            eventoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = eventoBL.AgregarEvento(eventoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEvento(int EventoId)
        {
            return Json(eventoBL.BuscarEventoID(EventoId));
        }

        public ActionResult ActualizarEvento(int EventoId, string DescEvento, string CodigoEvento)
        {
            EventoDTO eventoDTO = new();
            eventoDTO.EventoId = EventoId;
            eventoDTO.DescEvento = DescEvento;
            eventoDTO.CodigoEvento = CodigoEvento;
            eventoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = eventoBL.ActualizarEvento(eventoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEvento(int EventoId)
        {
            EventoDTO eventoDTO = new();
            eventoDTO.EventoId = EventoId;
            eventoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (eventoBL.EliminarEvento(eventoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
