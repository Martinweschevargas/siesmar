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
    public class ObservacionProcesoController : Controller
    {
        readonly ObservacionProcesoDAO observacionProcesoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Observaciones Procesos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ObservacionProcesoDTO> listaObservacionProcesos = observacionProcesoBL.ObtenerObservacionProcesos();
            return Json(new { data = listaObservacionProcesos });
        }

        public ActionResult InsertarObservacionProceso(string DescObservacionProceso, string CodigoObservacionProceso)
        {
            ObservacionProcesoDTO observacionProcesoDTO = new();
            observacionProcesoDTO.DescObservacionProceso = DescObservacionProceso;
            observacionProcesoDTO.CodigoObservacionProceso = CodigoObservacionProceso;
            observacionProcesoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = observacionProcesoBL.AgregarObservacionProceso(observacionProcesoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarObservacionProceso(int ObservacionProcesoId)
        {
            return Json(observacionProcesoBL.BuscarObservacionProcesoID(ObservacionProcesoId));
        }

        public ActionResult ActualizarObservacionProceso(int ObservacionProcesoId, string DescObservacionProceso, string CodigoObservacionProceso)
        {
            ObservacionProcesoDTO observacionProcesoDTO = new();
            observacionProcesoDTO.ObservacionProcesoId = ObservacionProcesoId;
            observacionProcesoDTO.DescObservacionProceso = DescObservacionProceso;
            observacionProcesoDTO.CodigoObservacionProceso = CodigoObservacionProceso;
            observacionProcesoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = observacionProcesoBL.ActualizarObservacionProceso(observacionProcesoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarObservacionProceso(int ObservacionProcesoId)
        {
            string mensaje = "";

            if (observacionProcesoBL.EliminarObservacionProceso(ObservacionProcesoId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
