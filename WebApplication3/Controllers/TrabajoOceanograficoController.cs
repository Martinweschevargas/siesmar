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
    public class TrabajoOceanograficoController : Controller
    {
        readonly TrabajoOceanograficoDAO trabajoOceanograficoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Trabajos Oceanográficos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TrabajoOceanograficoDTO> listaTrabajoOceanograficos = trabajoOceanograficoBL.ObtenerTrabajoOceanograficos();
            return Json(new { data = listaTrabajoOceanograficos });
        }

        public ActionResult InsertarTrabajoOceanografico(string DescTrabajoOceanografico, string CodigoTrabajoOceanografico)
        {
            TrabajoOceanograficoDTO trabajoOceanograficoDTO = new();
            trabajoOceanograficoDTO.DescTrabajoOceanografico = DescTrabajoOceanografico;
            trabajoOceanograficoDTO.CodigoTrabajoOceanografico = CodigoTrabajoOceanografico;
            trabajoOceanograficoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = trabajoOceanograficoBL.AgregarTrabajoOceanografico(trabajoOceanograficoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTrabajoOceanografico(int TrabajoOceanograficoId)
        {
            return Json(trabajoOceanograficoBL.BuscarTrabajoOceanograficoID(TrabajoOceanograficoId));
        }

        public ActionResult ActualizarTrabajoOceanografico(int TrabajoOceanograficoId, string DescTrabajoOceanografico, string CodigoTrabajoOceanografico)
        {
            TrabajoOceanograficoDTO trabajoOceanograficoDTO = new();
            trabajoOceanograficoDTO.TrabajoOceanograficoId = TrabajoOceanograficoId;
            trabajoOceanograficoDTO.DescTrabajoOceanografico = DescTrabajoOceanografico;
            trabajoOceanograficoDTO.CodigoTrabajoOceanografico = CodigoTrabajoOceanografico;
            trabajoOceanograficoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = trabajoOceanograficoBL.ActualizarTrabajoOceanografico(trabajoOceanograficoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTrabajoOceanografico(int TrabajoOceanograficoId)
        {
            TrabajoOceanograficoDTO trabajoOceanograficoDTO = new();
            trabajoOceanograficoDTO.TrabajoOceanograficoId = TrabajoOceanograficoId;
            trabajoOceanograficoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (trabajoOceanograficoBL.EliminarTrabajoOceanografico(trabajoOceanograficoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
