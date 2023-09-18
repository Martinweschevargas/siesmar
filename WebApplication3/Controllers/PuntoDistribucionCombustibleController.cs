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
    public class PuntoDistribucionCombustibleController : Controller
    {
        readonly PuntoDistribucionCombustibleDAO puntoDistribucionCombustibleBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Puntos Distribucion Combustible", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<PuntoDistribucionCombustibleDTO> listaPuntoDistribucionCombustibles = puntoDistribucionCombustibleBL.ObtenerPuntoDistribucionCombustibles();
            return Json(new { data = listaPuntoDistribucionCombustibles });
        }

        public ActionResult InsertarPuntoDistribucionCombustible(string DescPuntoDistribucionCombustible, string CodigoPuntoDistribucionCombustible)
        {
            PuntoDistribucionCombustibleDTO puntoDistribucionCombustibleDTO = new();
            puntoDistribucionCombustibleDTO.DescPuntoDistribucionCombustible = DescPuntoDistribucionCombustible;
            puntoDistribucionCombustibleDTO.CodigoPuntoDistribucionCombustible = CodigoPuntoDistribucionCombustible;
            puntoDistribucionCombustibleDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = puntoDistribucionCombustibleBL.AgregarPuntoDistribucionCombustible(puntoDistribucionCombustibleDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarPuntoDistribucionCombustible(int puntoDistribucionCombustibleId)
        {
            return Json(puntoDistribucionCombustibleBL.BuscarPuntoDistribucionCombustibleID(puntoDistribucionCombustibleId));
        }

        public ActionResult ActualizarPuntoDistribucionCombustible(int PuntoDistribucionCombustibleId, string DescPuntoDistribucionCombustible, string CodigoPuntoDistribucionCombustible)
        {
            PuntoDistribucionCombustibleDTO puntoDistribucionCombustibleDTO = new();
            puntoDistribucionCombustibleDTO.PuntoDistribucionCombustibleId = PuntoDistribucionCombustibleId;
            puntoDistribucionCombustibleDTO.DescPuntoDistribucionCombustible = DescPuntoDistribucionCombustible;
            puntoDistribucionCombustibleDTO.CodigoPuntoDistribucionCombustible = CodigoPuntoDistribucionCombustible;
            puntoDistribucionCombustibleDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = puntoDistribucionCombustibleBL.ActualizarPuntoDistribucionCombustible(puntoDistribucionCombustibleDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPuntoDistribucionCombustible(int PuntoDistribucionCombustibleId)
        {
            PuntoDistribucionCombustibleDTO puntoDistribucionCombustibleDTO = new();
            puntoDistribucionCombustibleDTO.PuntoDistribucionCombustibleId = PuntoDistribucionCombustibleId;
            puntoDistribucionCombustibleDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (puntoDistribucionCombustibleBL.EliminarPuntoDistribucionCombustible(puntoDistribucionCombustibleDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
