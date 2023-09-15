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
    public class VehiculoServicioGrupoController : Controller
    {
        readonly VehiculoServicioGrupoDAO vehiculoServicioGrupoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Vehiculos Servicios Grupos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<VehiculoServicioGrupoDTO> listaVehiculoServicioGrupos = vehiculoServicioGrupoBL.ObtenerVehiculoServicioGrupos();
            return Json(new { data = listaVehiculoServicioGrupos });
        }

        public ActionResult InsertarVehiculoServicioGrupo(string DescVehiculoServicioGrupo, string CodigoVehiculoServicioGrupo)
        {
            VehiculoServicioGrupoDTO vehiculoServicioGrupoDTO = new();
            vehiculoServicioGrupoDTO.DescVehiculoServicioGrupo = DescVehiculoServicioGrupo;
            vehiculoServicioGrupoDTO.CodigoVehiculoServicioGrupo = CodigoVehiculoServicioGrupo;
            vehiculoServicioGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = vehiculoServicioGrupoBL.AgregarVehiculoServicioGrupo(vehiculoServicioGrupoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarVehiculoServicioGrupo(int VehiculoServicioGrupoId)
        {
            return Json(vehiculoServicioGrupoBL.BuscarVehiculoServicioGrupoID(VehiculoServicioGrupoId));
        }

        public ActionResult ActualizarvehiculoServicioGrupo(int VehiculoServicioGrupoId, string DescVehiculoServicioGrupo, string CodigoVehiculoServicioGrupo)
        {
            VehiculoServicioGrupoDTO vehiculoServicioGrupoDTO = new();
            vehiculoServicioGrupoDTO.VehiculoServicioGrupoId = VehiculoServicioGrupoId;
            vehiculoServicioGrupoDTO.DescVehiculoServicioGrupo = DescVehiculoServicioGrupo;
            vehiculoServicioGrupoDTO.CodigoVehiculoServicioGrupo = CodigoVehiculoServicioGrupo;
            vehiculoServicioGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = vehiculoServicioGrupoBL.ActualizarVehiculoServicioGrupo(vehiculoServicioGrupoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarVehiculoServicioGrupo(int VehiculoServicioGrupoId)
        {
            VehiculoServicioGrupoDTO vehiculoServicioGrupoDTO = new();
            vehiculoServicioGrupoDTO.VehiculoServicioGrupoId = VehiculoServicioGrupoId;
            vehiculoServicioGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (vehiculoServicioGrupoBL.EliminarVehiculoServicioGrupo(vehiculoServicioGrupoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
