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
    public class TipoPresupuestoController : Controller
    {
        readonly TipoPresupuestoDAO tipoPresupuestoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Presupuestos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoPresupuestoDTO> listaTipoPresupuestos = tipoPresupuestoBL.ObtenerTipoPresupuestos();
            return Json(new { data = listaTipoPresupuestos });
        }

        public ActionResult InsertarTipoPresupuesto(string DescTipoPresupuesto, string CodigoTipoPresupuesto)
        {
            TipoPresupuestoDTO tipoPresupuestoDTO = new();
            tipoPresupuestoDTO.DescTipoPresupuesto = DescTipoPresupuesto;
            tipoPresupuestoDTO.CodigoTipoPresupuesto = CodigoTipoPresupuesto;
            tipoPresupuestoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoPresupuestoBL.AgregarTipoPresupuesto(tipoPresupuestoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoPresupuesto(int TipoPresupuestoId)
        {
            return Json(tipoPresupuestoBL.BuscarTipoPresupuestoID(TipoPresupuestoId));
        }

        public ActionResult ActualizarTipoPresupuesto(int TipoPresupuestoId, string DescTipoPresupuesto, string CodigoTipoPresupuesto)
        {
            TipoPresupuestoDTO tipoPresupuestoDTO = new();
            tipoPresupuestoDTO.TipoPresupuestoId = TipoPresupuestoId;
            tipoPresupuestoDTO.DescTipoPresupuesto = DescTipoPresupuesto;
            tipoPresupuestoDTO.CodigoTipoPresupuesto = CodigoTipoPresupuesto;
            tipoPresupuestoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoPresupuestoBL.ActualizarTipoPresupuesto(tipoPresupuestoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoPresupuesto(int TipoPresupuestoId)
        {
            TipoPresupuestoDTO tipoPresupuestoDTO = new();
            tipoPresupuestoDTO.TipoPresupuestoId = TipoPresupuestoId;
            tipoPresupuestoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoPresupuestoBL.EliminarTipoPresupuesto(tipoPresupuestoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
