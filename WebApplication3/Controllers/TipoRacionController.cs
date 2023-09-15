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
    public class TipoRacionController : Controller
    {
        readonly TipoRacionDAO tipoRacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Raciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoRacionDTO> listaTipoRacions = tipoRacionBL.ObtenerTipoRacions();
            return Json(new { data = listaTipoRacions });
        }

        public ActionResult InsertarTipoRacion(string DescTipoRacion, string CodigoTipoRacion)
        {
            TipoRacionDTO tipoRacionDTO = new();
            tipoRacionDTO.DescTipoRacion = DescTipoRacion;
            tipoRacionDTO.CodigoTipoRacion = CodigoTipoRacion;
            tipoRacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoRacionBL.AgregarTipoRacion(tipoRacionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoRacion(int TipoRacionId)
        {
            return Json(tipoRacionBL.BuscarTipoRacionID(TipoRacionId));
        }

        public ActionResult ActualizarTipoRacion(int TipoRacionId, string DescTipoRacion, string CodigoTipoRacion)
        {
            TipoRacionDTO tipoRacionDTO = new();
            tipoRacionDTO.TipoRacionId = TipoRacionId;
            tipoRacionDTO.DescTipoRacion = DescTipoRacion;
            tipoRacionDTO.CodigoTipoRacion = CodigoTipoRacion;
            tipoRacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoRacionBL.ActualizarTipoRacion(tipoRacionDTO);

            return Content(IND_OPERACION);
        }


        public ActionResult EliminarTipoRacion(int TipoRacionId)
        {
            TipoRacionDTO TipoRacionDTO = new();
            TipoRacionDTO.TipoRacionId = TipoRacionId;
            TipoRacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoRacionBL.EliminarTipoRacion(TipoRacionDTO);

            return Content(IND_OPERACION);
        }
    }
}
