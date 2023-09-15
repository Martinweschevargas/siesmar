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
    public class MotivoViajeController : Controller
    {
        readonly MotivoViajeDAO motivoViajeBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Motivos Viajes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MotivoViajeDTO> listaMotivoViajes = motivoViajeBL.ObtenerMotivoViajes();
            return Json(new { data = listaMotivoViajes });
        }

        public ActionResult InsertarMotivoViaje(string DescMotivoViaje, string CodigoMotivoViaje)
        {
            MotivoViajeDTO motivoViajeDTO = new();
            motivoViajeDTO.DescMotivoViaje = DescMotivoViaje;
            motivoViajeDTO.CodigoMotivoViaje = CodigoMotivoViaje;
            motivoViajeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = motivoViajeBL.AgregarMotivoViaje(motivoViajeDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMotivoViaje(int MotivoViajeId)
        {
            return Json(motivoViajeBL.BuscarMotivoViajeID(MotivoViajeId));
        }

        public ActionResult ActualizarMotivoViaje(int MotivoViajeId, string DescMotivoViaje, string CodigoMotivoViaje)
        {
            MotivoViajeDTO motivoViajeDTO = new();
            motivoViajeDTO.MotivoViajeId = MotivoViajeId;
            motivoViajeDTO.DescMotivoViaje = DescMotivoViaje;
            motivoViajeDTO.CodigoMotivoViaje = CodigoMotivoViaje;
            motivoViajeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = motivoViajeBL.ActualizarMotivoViaje(motivoViajeDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMotivoViaje(int MotivoViajeId)
        {
            string mensaje = "";

            if (motivoViajeBL.EliminarMotivoViaje(MotivoViajeId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
