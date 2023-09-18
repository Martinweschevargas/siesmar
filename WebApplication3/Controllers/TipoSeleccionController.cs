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
    public class TipoSeleccionController : Controller
    {
        readonly TipoSeleccionDAO tipoSeleccionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Selecciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoSeleccionDTO> listaTipoSeleccions = tipoSeleccionBL.ObtenerTipoSeleccions();
            return Json(new { data = listaTipoSeleccions });
        }

        public ActionResult InsertarTipoSeleccion(string DescTipoSeleccion, string CodigoTipoSeleccion)
        {
            TipoSeleccionDTO tipoSeleccionDTO = new();
            tipoSeleccionDTO.DescTipoSeleccion = DescTipoSeleccion;
            tipoSeleccionDTO.CodigoTipoSeleccion = CodigoTipoSeleccion;
            tipoSeleccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoSeleccionBL.AgregarTipoSeleccion(tipoSeleccionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoSeleccion(int TipoSeleccionId)
        {
            return Json(tipoSeleccionBL.BuscarTipoSeleccionID(TipoSeleccionId));
        }

        public ActionResult ActualizarTipoSeleccion(int TipoSeleccionId, string DescTipoSeleccion, string CodigoTipoSeleccion)
        {
            TipoSeleccionDTO tipoSeleccionDTO = new();
            tipoSeleccionDTO.TipoSeleccionId = TipoSeleccionId;
            tipoSeleccionDTO.DescTipoSeleccion = DescTipoSeleccion;
            tipoSeleccionDTO.CodigoTipoSeleccion = CodigoTipoSeleccion;
            tipoSeleccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoSeleccionBL.ActualizarTipoSeleccion(tipoSeleccionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoSeleccion(int TipoSeleccionId)
        {
            TipoSeleccionDTO tipoSeleccionDTO = new();
            tipoSeleccionDTO.TipoSeleccionId = TipoSeleccionId;
            tipoSeleccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoSeleccionBL.EliminarTipoSeleccion(tipoSeleccionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
