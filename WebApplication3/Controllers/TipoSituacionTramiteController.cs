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
    public class TipoSituacionTramiteController : Controller
    {
        readonly TipoSituacionTramiteDAO tipoSituacionTramiteBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Situaciones Tramites", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoSituacionTramiteDTO> listaTipoSituacionTramites = tipoSituacionTramiteBL.ObtenerTipoSituacionTramites();
            return Json(new { data = listaTipoSituacionTramites });
        }

        public ActionResult InsertarTipoSituacionTramite(string DescTipoSituacionTramite, string CodigoTipoSituacionTramite)
        {
            TipoSituacionTramiteDTO tipoSituacionTramiteDTO = new();
            tipoSituacionTramiteDTO.DescTipoSituacionTramite = DescTipoSituacionTramite;
            tipoSituacionTramiteDTO.CodigoTipoSituacionTramite = CodigoTipoSituacionTramite;
            tipoSituacionTramiteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoSituacionTramiteBL.AgregarTipoSituacionTramite(tipoSituacionTramiteDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoSituacionTramite(int TipoSituacionTramiteId)
        {
            return Json(tipoSituacionTramiteBL.BuscarTipoSituacionTramiteID(TipoSituacionTramiteId));
        }

        public ActionResult ActualizarTipoSituacionTramite(int TipoSituacionTramiteId, string DescTipoSituacionTramite, string CodigoTipoSituacionTramite)
        {
            TipoSituacionTramiteDTO tipoSituacionTramiteDTO = new();
            tipoSituacionTramiteDTO.TipoSituacionTramiteId = TipoSituacionTramiteId;
            tipoSituacionTramiteDTO.DescTipoSituacionTramite = DescTipoSituacionTramite;
            tipoSituacionTramiteDTO.CodigoTipoSituacionTramite = CodigoTipoSituacionTramite;
            tipoSituacionTramiteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoSituacionTramiteBL.ActualizarTipoSituacionTramite(tipoSituacionTramiteDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoSituacionTramite(int TipoSituacionTramiteId)
        {
            TipoSituacionTramiteDTO tipoSituacionTramiteDTO = new();
            tipoSituacionTramiteDTO.TipoSituacionTramiteId = TipoSituacionTramiteId;
            tipoSituacionTramiteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoSituacionTramiteBL.EliminarTipoSituacionTramite(tipoSituacionTramiteDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
