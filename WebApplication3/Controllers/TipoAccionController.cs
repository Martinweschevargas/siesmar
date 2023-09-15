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
    public class TipoAccionController : Controller
    {
        readonly TipoAccionDAO tipoAccionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Acciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoAccionDTO> listaTipoAccions = tipoAccionBL.ObtenerTipoAccions();
            return Json(new { data = listaTipoAccions });
        }

        public ActionResult InsertarTipoAccion(string DescTipoAccion, string CodigoTipoAccion)
        {
            TipoAccionDTO tipoAccionDTO = new();
            tipoAccionDTO.DescTipoAccion = DescTipoAccion;
            tipoAccionDTO.CodigoTipoAccion = CodigoTipoAccion;
            tipoAccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoAccionBL.AgregarTipoAccion(tipoAccionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoAccion(int TipoAccionId)
        {
            return Json(tipoAccionBL.BuscarTipoAccionID(TipoAccionId));
        }

        public ActionResult ActualizarTipoAccion(int TipoAccionId, string DescTipoAccion, string CodigoTipoAccion)
        {
            TipoAccionDTO tipoAccionDTO = new();
            tipoAccionDTO.TipoAccionId = TipoAccionId;
            tipoAccionDTO.DescTipoAccion = DescTipoAccion;
            tipoAccionDTO.CodigoTipoAccion = CodigoTipoAccion;
            tipoAccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoAccionBL.ActualizarTipoAccion(tipoAccionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoAccion(int TipoAccionId)
        {
            TipoAccionDTO tipoAccionDTO = new();
            tipoAccionDTO.TipoAccionId = TipoAccionId;
            tipoAccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoAccionBL.EliminarTipoAccion(tipoAccionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
