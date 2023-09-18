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
    public class MotivoServicioController : Controller
    {
        readonly MotivoServicioDAO motivoServicioBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Motivos Servicios", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MotivoServicioDTO> listaMotivoServicios = motivoServicioBL.ObtenerMotivoServicios();
            return Json(new { data = listaMotivoServicios });
        }

        public ActionResult InsertarMotivoServicio(string DescMotivoServicio, string CodigoMotivoServicio)
        {
            MotivoServicioDTO motivoServicioDTO = new();
            motivoServicioDTO.DescMotivoServicio = DescMotivoServicio;
            motivoServicioDTO.CodigoMotivoServicio = CodigoMotivoServicio;
            motivoServicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = motivoServicioBL.AgregarMotivoServicio(motivoServicioDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMotivoServicio(int MotivoServicioId)
        {
            return Json(motivoServicioBL.BuscarMotivoServicioID(MotivoServicioId));
        }

        public ActionResult ActualizarMotivoServicio(int MotivoServicioId, string DescMotivoServicio, string CodigoMotivoServicio)
        {
            MotivoServicioDTO motivoServicioDTO = new();
            motivoServicioDTO.MotivoServicioId = MotivoServicioId;
            motivoServicioDTO.DescMotivoServicio = DescMotivoServicio;
            motivoServicioDTO.CodigoMotivoServicio = CodigoMotivoServicio;
            motivoServicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = motivoServicioBL.ActualizarMotivoServicio(motivoServicioDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMotivoServicio(int MotivoServicioId)
        {
            string mensaje = "";

            if (motivoServicioBL.EliminarMotivoServicio(MotivoServicioId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
