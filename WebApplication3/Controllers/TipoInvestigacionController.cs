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
    public class TipoInvestigacionController : Controller
    {
        readonly TipoInvestigacionDAO tipoInvestigacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Investigaciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoInvestigacionDTO> listaTipoInvestigacions = tipoInvestigacionBL.ObtenerTipoInvestigacions();
            return Json(new { data = listaTipoInvestigacions });
        }

        public ActionResult InsertarTipoInvestigacion(string DescTipoInvestigacion, string CodigoTipoInvestigacion)
        {
            TipoInvestigacionDTO tipoInvestigacionDTO = new();
            tipoInvestigacionDTO.DescTipoInvestigacion = DescTipoInvestigacion;
            tipoInvestigacionDTO.CodigoTipoInvestigacion = CodigoTipoInvestigacion;
            tipoInvestigacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoInvestigacionBL.AgregarTipoInvestigacion(tipoInvestigacionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoInvestigacion(int TipoInvestigacionId)
        {
            return Json(tipoInvestigacionBL.BuscarTipoInvestigacionID(TipoInvestigacionId));
        }

        public ActionResult ActualizarTipoInvestigacion(int TipoInvestigacionId, string DescTipoInvestigacion, string CodigoTipoInvestigacion)
        {
            TipoInvestigacionDTO tipoInvestigacionDTO = new();
            tipoInvestigacionDTO.TipoInvestigacionId = TipoInvestigacionId;
            tipoInvestigacionDTO.DescTipoInvestigacion = DescTipoInvestigacion;
            tipoInvestigacionDTO.CodigoTipoInvestigacion = CodigoTipoInvestigacion;
            tipoInvestigacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoInvestigacionBL.ActualizarTipoInvestigacion(tipoInvestigacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoInvestigacion(int TipoInvestigacionId)
        {
            TipoInvestigacionDTO tipoInvestigacionDTO = new();
            tipoInvestigacionDTO.TipoInvestigacionId = TipoInvestigacionId;
            tipoInvestigacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoInvestigacionBL.EliminarTipoInvestigacion(tipoInvestigacionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
