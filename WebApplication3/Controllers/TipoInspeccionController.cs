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
    public class TipoInspeccionController : Controller
    {
        readonly TipoInspeccionDAO tipoInspeccionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Inspecciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoInspeccionDTO> listaTipoInspeccions = tipoInspeccionBL.ObtenerTipoInspeccions();
            return Json(new { data = listaTipoInspeccions });
        }

        public ActionResult InsertarTipoInspeccion(string DescTipoInspeccion, string CodigoTipoInspeccion)
        {
            TipoInspeccionDTO tipoInspeccionDTO = new();
            tipoInspeccionDTO.DescTipoInspeccion = DescTipoInspeccion;
            tipoInspeccionDTO.CodigoTipoInspeccion = CodigoTipoInspeccion;
            tipoInspeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoInspeccionBL.AgregarTipoInspeccion(tipoInspeccionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoInspeccion(int TipoInspeccionId)
        {
            return Json(tipoInspeccionBL.BuscarTipoInspeccionID(TipoInspeccionId));
        }

        public ActionResult ActualizarTipoInspeccion(int TipoInspeccionId, string DescTipoInspeccion, string CodigoTipoInspeccion)
        {
            TipoInspeccionDTO tipoInspeccionDTO = new();
            tipoInspeccionDTO.TipoInspeccionId = TipoInspeccionId;
            tipoInspeccionDTO.DescTipoInspeccion = DescTipoInspeccion;
            tipoInspeccionDTO.CodigoTipoInspeccion = CodigoTipoInspeccion;
            tipoInspeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoInspeccionBL.ActualizarTipoInspeccion(tipoInspeccionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoInspeccion(int TipoInspeccionId)
        {
            TipoInspeccionDTO tipoInspeccionDTO = new();
            tipoInspeccionDTO.TipoInspeccionId = TipoInspeccionId;
            tipoInspeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoInspeccionBL.EliminarTipoInspeccion(tipoInspeccionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
