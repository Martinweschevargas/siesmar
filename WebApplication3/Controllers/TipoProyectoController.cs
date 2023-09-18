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
    public class TipoProyectoController : Controller
    {
        readonly TipoProyectoDAO tipoProyectoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Proyectos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoProyectoDTO> listaTipoProyectos = tipoProyectoBL.ObtenerTipoProyectos();
            return Json(new { data = listaTipoProyectos });
        }

        public ActionResult InsertarTipoProyecto(string DescTipoProyecto, string CodigoTipoProyecto)
        {
            TipoProyectoDTO tipoProyectoDTO = new();
            tipoProyectoDTO.DescTipoProyecto = DescTipoProyecto;
            tipoProyectoDTO.CodigoTipoProyecto = CodigoTipoProyecto;
            tipoProyectoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoProyectoBL.AgregarTipoProyecto(tipoProyectoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoProyecto(int TipoProyectoId)
        {
            return Json(tipoProyectoBL.BuscarTipoProyectoID(TipoProyectoId));
        }

        public ActionResult ActualizarTipoProyecto(int TipoProyectoId, string DescTipoProyecto, string CodigoTipoProyecto)
        {
            TipoProyectoDTO tipoProyectoDTO = new();
            tipoProyectoDTO.TipoProyectoId = TipoProyectoId;
            tipoProyectoDTO.DescTipoProyecto = DescTipoProyecto;
            tipoProyectoDTO.CodigoTipoProyecto = CodigoTipoProyecto;
            tipoProyectoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoProyectoBL.ActualizarTipoProyecto(tipoProyectoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoProyecto(int TipoProyectoId)
        {
            TipoProyectoDTO tipoProyectoDTO = new();
            tipoProyectoDTO.TipoProyectoId = TipoProyectoId;
            tipoProyectoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoProyectoBL.EliminarTipoProyecto(tipoProyectoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
