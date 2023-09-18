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
    public class TipoProcesoController : Controller
    {
        readonly TipoProcesoDAO tipoProcesoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Procesos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoProcesoDTO> listaTipoProcesos = tipoProcesoBL.ObtenerTipoProcesos();
            return Json(new { data = listaTipoProcesos });
        }

        public ActionResult InsertarTipoProceso(string DescTipoProceso, string CodigoTipoProceso)
        {
            TipoProcesoDTO tipoProcesoDTO = new();
            tipoProcesoDTO.DescTipoProceso = DescTipoProceso;
            tipoProcesoDTO.CodigoTipoProceso = CodigoTipoProceso;
            tipoProcesoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoProcesoBL.AgregarTipoProceso(tipoProcesoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoProceso(int TipoProcesoId)
        {
            return Json(tipoProcesoBL.BuscarTipoProcesoID(TipoProcesoId));
        }

        public ActionResult ActualizarTipoProceso(int TipoProcesoId, string DescTipoProceso, string CodigoTipoProceso)
        {
            TipoProcesoDTO tipoProcesoDTO = new();
            tipoProcesoDTO.TipoProcesoId = TipoProcesoId;
            tipoProcesoDTO.DescTipoProceso = DescTipoProceso;
            tipoProcesoDTO.CodigoTipoProceso = CodigoTipoProceso;
            tipoProcesoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoProcesoBL.ActualizarTipoProceso(tipoProcesoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoProceso(int TipoProcesoId)
        {
            TipoProcesoDTO tipoProcesoDTO = new();
            tipoProcesoDTO.TipoProcesoId = TipoProcesoId;
            tipoProcesoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoProcesoBL.EliminarTipoProceso(tipoProcesoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
