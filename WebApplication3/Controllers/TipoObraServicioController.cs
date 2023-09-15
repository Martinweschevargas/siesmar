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
    public class TipoObraServicioController : Controller
    {
        readonly TipoObraServicioDAO tipoObraServicioBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Obras Servicios", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoObraServicioDTO> listaTipoObraServicios = tipoObraServicioBL.ObtenerTipoObraServicios();
            return Json(new { data = listaTipoObraServicios });
        }

        public ActionResult InsertarTipoObraServicio(string DescTipoObraServicio, string CodigoTipoObraServicio)
        {
            TipoObraServicioDTO tipoObraServicioDTO = new();
            tipoObraServicioDTO.DescTipoObraServicio = DescTipoObraServicio;
            tipoObraServicioDTO.CodigoTipoObraServicio = CodigoTipoObraServicio;
            tipoObraServicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoObraServicioBL.AgregarTipoObraServicio(tipoObraServicioDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoObraServicio(int TipoObraServicioId)
        {
            return Json(tipoObraServicioBL.BuscarTipoObraServicioID(TipoObraServicioId));
        }

        public ActionResult ActualizarTipoObraServicio(int TipoObraServicioId, string DescTipoObraServicio, string CodigoTipoObraServicio)
        {
            TipoObraServicioDTO tipoObraServicioDTO = new();
            tipoObraServicioDTO.TipoObraServicioId = TipoObraServicioId;
            tipoObraServicioDTO.DescTipoObraServicio = DescTipoObraServicio;
            tipoObraServicioDTO.CodigoTipoObraServicio = CodigoTipoObraServicio;
            tipoObraServicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoObraServicioBL.ActualizarTipoObraServicio(tipoObraServicioDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoObraServicio(int TipoObraServicioId)
        {
            TipoObraServicioDTO tipoObraServicioDTO = new();
            tipoObraServicioDTO.TipoObraServicioId = TipoObraServicioId;
            tipoObraServicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoObraServicioBL.EliminarTipoObraServicio(tipoObraServicioDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
