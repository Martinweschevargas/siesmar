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
    public class TipoEventoController : Controller
    {
        readonly TipoEventoDAO tipoEventoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Eventos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoEventoDTO> listaTipoEventos = tipoEventoBL.ObtenerTipoEventos();
            return Json(new { data = listaTipoEventos });
        }

        public ActionResult InsertarTipoEvento(string DescTipoEvento, string CodigoTipoEvento)
        {
            TipoEventoDTO tipoEventoDTO = new();
            tipoEventoDTO.DescTipoEvento = DescTipoEvento;
            tipoEventoDTO.CodigoTipoEvento = CodigoTipoEvento;
            tipoEventoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoEventoBL.AgregarTipoEvento(tipoEventoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoEvento(int TipoEventoId)
        {
            return Json(tipoEventoBL.BuscarTipoEventoID(TipoEventoId));
        }

        public ActionResult ActualizarTipoEvento(int TipoEventoId, string DescTipoEvento, string CodigoTipoEvento)
        {
            TipoEventoDTO tipoEventoDTO = new();
            tipoEventoDTO.TipoEventoId = TipoEventoId;
            tipoEventoDTO.DescTipoEvento = DescTipoEvento;
            tipoEventoDTO.CodigoTipoEvento = CodigoTipoEvento;
            tipoEventoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoEventoBL.ActualizarTipoEvento(tipoEventoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoEvento(int TipoEventoId)
        {
            TipoEventoDTO tipoEventoDTO = new();
            tipoEventoDTO.TipoEventoId = TipoEventoId;
            tipoEventoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoEventoBL.EliminarTipoEvento(tipoEventoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
