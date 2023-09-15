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
    public class TipoAtencionController : Controller
    {
        readonly TipoAtencionDAO tipoAtencionBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Atenciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoAtencionDTO> listaTipoAtencions = tipoAtencionBL.ObtenerTipoAtencions();
            return Json(new { data = listaTipoAtencions });
        }

        public ActionResult InsertarTipoAtencion(string DescTipoAtencion, string CodigoTipoAtencion)
        {
            TipoAtencionDTO tipoAtencionDTO = new();
            tipoAtencionDTO.DescTipoAtencion = DescTipoAtencion;
            tipoAtencionDTO.CodigoTipoAtencion = CodigoTipoAtencion;
            tipoAtencionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoAtencionBL.AgregarTipoAtencion(tipoAtencionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoAtencion(int TipoAtencionId)
        {
            return Json(tipoAtencionBL.BuscarTipoAtencionID(TipoAtencionId));
        }

        public ActionResult ActualizarTipoAtencion(int TipoAtencionId, string DescTipoAtencion, string CodigoTipoAtencion)
        {
            TipoAtencionDTO tipoAtencionDTO = new();
            tipoAtencionDTO.TipoAtencionId = TipoAtencionId;
            tipoAtencionDTO.DescTipoAtencion = DescTipoAtencion;
            tipoAtencionDTO.CodigoTipoAtencion = CodigoTipoAtencion;
            tipoAtencionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoAtencionBL.ActualizarTipoAtencion(tipoAtencionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoAtencion(int TipoAtencionId)
        {
            TipoAtencionDTO tipoAtencionDTO = new();
            tipoAtencionDTO.TipoAtencionId = TipoAtencionId;
            tipoAtencionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoAtencionBL.EliminarTipoAtencion(tipoAtencionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
