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
    public class TipoMantenimientoController : Controller
    {
        readonly TipoMantenimientoDAO tipoMantenimientoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Mantenimientos", FromController = typeof(HomeController))]

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoMantenimientoDTO> listaTipoMantenimientos = tipoMantenimientoBL.ObtenerTipoMantenimientos();
            return Json(new { data = listaTipoMantenimientos });
        }

        public ActionResult InsertarTipoMantenimiento(string DescTipoMantenimiento, string CodigoTipoMantenimiento)
        {
            TipoMantenimientoDTO tipoMantenimientoDTO = new();
            tipoMantenimientoDTO.DescTipoMantenimiento = DescTipoMantenimiento;
            tipoMantenimientoDTO.CodigoTipoMantenimiento = CodigoTipoMantenimiento;
            tipoMantenimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoMantenimientoBL.AgregarTipoMantenimiento(tipoMantenimientoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoMantenimiento(int TipoMantenimientoId)
        {
            return Json(tipoMantenimientoBL.BuscarTipoMantenimientoID(TipoMantenimientoId));
        }

        public ActionResult ActualizarTipoMantenimiento(int TipoMantenimientoId, string DescTipoMantenimiento, string CodigoTipoMantenimiento)
        {
            TipoMantenimientoDTO tipoMantenimientoDTO = new();
            tipoMantenimientoDTO.TipoMantenimientoId = TipoMantenimientoId;
            tipoMantenimientoDTO.DescTipoMantenimiento = DescTipoMantenimiento;
            tipoMantenimientoDTO.CodigoTipoMantenimiento = CodigoTipoMantenimiento;
            tipoMantenimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoMantenimientoBL.ActualizarTipoMantenimiento(tipoMantenimientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoMantenimiento(int TipoMantenimientoId)
        {
            TipoMantenimientoDTO tipoMantenimientoDTO = new();
            tipoMantenimientoDTO.TipoMantenimientoId = TipoMantenimientoId;
            tipoMantenimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoMantenimientoBL.EliminarTipoMantenimiento(tipoMantenimientoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
