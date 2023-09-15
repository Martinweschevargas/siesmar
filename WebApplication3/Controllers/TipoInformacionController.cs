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
    public class TipoInformacionController : Controller
    {
        readonly TipoInformacionDAO tipoInformacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Informaciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoInformacionDTO> listaTipoInformacions = tipoInformacionBL.ObtenerTipoInformacions();
            return Json(new { data = listaTipoInformacions });
        }

        public ActionResult InsertarTipoInformacion(string DescTipoInformacion, string CodigoTipoInformacion)
        {
            TipoInformacionDTO tipoInformacionDTO = new();
            tipoInformacionDTO.DescTipoInformacion = DescTipoInformacion;
            tipoInformacionDTO.CodigoTipoInformacion = CodigoTipoInformacion;
            tipoInformacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoInformacionBL.AgregarTipoInformacion(tipoInformacionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoInformacion(int TipoInformacionId)
        {
            return Json(tipoInformacionBL.BuscarTipoInformacionID(TipoInformacionId));
        }

        public ActionResult ActualizarTipoInformacion(int TipoInformacionId, string DescTipoInformacion, string CodigoTipoInformacion)
        {
            TipoInformacionDTO tipoInformacionDTO = new();
            tipoInformacionDTO.TipoInformacionId = TipoInformacionId;
            tipoInformacionDTO.DescTipoInformacion = DescTipoInformacion;
            tipoInformacionDTO.CodigoTipoInformacion = CodigoTipoInformacion;
            tipoInformacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoInformacionBL.ActualizarTipoInformacion(tipoInformacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoInformacion(int TipoInformacionId)
        {
            TipoInformacionDTO tipoInformacionDTO = new();
            tipoInformacionDTO.TipoInformacionId = TipoInformacionId;
            tipoInformacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoInformacionBL.EliminarTipoInformacion(tipoInformacionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
