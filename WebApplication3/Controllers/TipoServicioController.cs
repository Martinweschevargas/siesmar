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
    public class TipoServicioController : Controller
    {
        readonly TipoServicioDAO tipoServicioBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Servicios", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoServicioDTO> listaTipoServicios = tipoServicioBL.ObtenerTipoServicios();
            return Json(new { data = listaTipoServicios });
        }

        public ActionResult InsertarTipoServicio(string DescTipoServicio, string CodigoTipoServicio)
        {
            TipoServicioDTO tipoServicioDTO = new();
            tipoServicioDTO.DescTipoServicio = DescTipoServicio;
            tipoServicioDTO.CodigoTipoServicio = CodigoTipoServicio;
            tipoServicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoServicioBL.AgregarTipoServicio(tipoServicioDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoServicio(int TipoServicioId)
        {
            return Json(tipoServicioBL.BuscarTipoServicioID(TipoServicioId));
        }

        public ActionResult ActualizarTipoServicio(int TipoServicioId, string DescTipoServicio, string CodigoTipoServicio)
        {
            TipoServicioDTO tipoServicioDTO = new();
            tipoServicioDTO.TipoServicioId = TipoServicioId;
            tipoServicioDTO.DescTipoServicio = DescTipoServicio;
            tipoServicioDTO.CodigoTipoServicio = CodigoTipoServicio;
            tipoServicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoServicioBL.ActualizarTipoServicio(tipoServicioDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoServicio(int TipoServicioId)
        {
            TipoServicioDTO tipoServicioDTO = new();
            tipoServicioDTO.TipoServicioId = TipoServicioId;
            tipoServicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoServicioBL.EliminarTipoServicio(tipoServicioDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
