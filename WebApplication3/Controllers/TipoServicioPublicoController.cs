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
    public class TipoServicioPublicoController : Controller
    {
        readonly TipoServicioPublicoDAO tipoServicioPublicoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Personales Militares", FromController = typeof(HomeController))]

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoServicioPublicoDTO> listaTipoServicioPublicos = tipoServicioPublicoBL.ObtenerTipoServicioPublicos();
            return Json(new { data = listaTipoServicioPublicos });
        }

        public ActionResult InsertarTipoServicioPublico(string DescTipoServicioPublico, string CodigoTipoServicioPublico)
        {
            TipoServicioPublicoDTO tipoServicioPublicoDTO = new();
            tipoServicioPublicoDTO.DescTipoServicioPublico = DescTipoServicioPublico;
            tipoServicioPublicoDTO.CodigoTipoServicioPublico = CodigoTipoServicioPublico;
            tipoServicioPublicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoServicioPublicoBL.AgregarTipoServicioPublico(tipoServicioPublicoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoServicioPublico(int TipoServicioPublicoId)
        {
            return Json(tipoServicioPublicoBL.BuscarTipoServicioPublicoID(TipoServicioPublicoId));
        }

        public ActionResult ActualizarTipoServicioPublico(int TipoServicioPublicoId, string DescTipoServicioPublico, string CodigoTipoServicioPublico)
        {
            TipoServicioPublicoDTO tipoServicioPublicoDTO = new();
            tipoServicioPublicoDTO.TipoServicioPublicoId = TipoServicioPublicoId;
            tipoServicioPublicoDTO.DescTipoServicioPublico = DescTipoServicioPublico;
            tipoServicioPublicoDTO.CodigoTipoServicioPublico = CodigoTipoServicioPublico;
            tipoServicioPublicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoServicioPublicoBL.ActualizarTipoServicioPublico(tipoServicioPublicoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoServicioPublico(int TipoServicioPublicoId)
        {
            TipoServicioPublicoDTO tipoServicioPublicoDTO = new();
            tipoServicioPublicoDTO.TipoServicioPublicoId = TipoServicioPublicoId;
            tipoServicioPublicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoServicioPublicoBL.EliminarTipoServicioPublico(tipoServicioPublicoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
