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
    public class PuntoDistribucionPanificacionController : Controller
    {
        readonly PuntoDistribucionPanificacionDAO puntoDistribucionPanificacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Puntos Distribucion Panificacion", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<PuntoDistribucionPanificacionDTO> listaPuntoDistribucionPanificacions = puntoDistribucionPanificacionBL.ObtenerPuntoDistribucionPanificacions();
            return Json(new { data = listaPuntoDistribucionPanificacions });
        }

        public ActionResult InsertarPuntoDistribucionPanificacion(string DescPuntoDistribucionPanificacion, string CodigoPuntoDistribucionPanificacion)
        {
            PuntoDistribucionPanificacionDTO puntoDistribucionPanificacionDTO = new();
            puntoDistribucionPanificacionDTO.DescPuntoDistribucionPanificacion = DescPuntoDistribucionPanificacion;
            puntoDistribucionPanificacionDTO.CodigoPuntoDistribucionPanificacion = CodigoPuntoDistribucionPanificacion;
            puntoDistribucionPanificacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = puntoDistribucionPanificacionBL.AgregarPuntoDistribucionPanificacion(puntoDistribucionPanificacionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarPuntoDistribucionPanificacion(int PuntoDistribucionPanificacionId)
        {
            return Json(puntoDistribucionPanificacionBL.BuscarPuntoDistribucionPanificacionID(PuntoDistribucionPanificacionId));
        }

        public ActionResult ActualizarPuntoDistribucionPanificacion(int PuntoDistribucionPanificacionId, string DescPuntoDistribucionPanificacion, string CodigoPuntoDistribucionPanificacion)
        {
            PuntoDistribucionPanificacionDTO puntoDistribucionPanificacionDTO = new();
            puntoDistribucionPanificacionDTO.PuntoDistribucionPanificacionId = PuntoDistribucionPanificacionId;
            puntoDistribucionPanificacionDTO.DescPuntoDistribucionPanificacion = DescPuntoDistribucionPanificacion;
            puntoDistribucionPanificacionDTO.CodigoPuntoDistribucionPanificacion = CodigoPuntoDistribucionPanificacion;
            puntoDistribucionPanificacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = puntoDistribucionPanificacionBL.ActualizarPuntoDistribucionPanificacion(puntoDistribucionPanificacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPuntoDistribucionPanificacion(int PuntoDistribucionPanificacionId)
        {
            PuntoDistribucionPanificacionDTO puntoDistribucionPanificacionDTO = new();
            puntoDistribucionPanificacionDTO.PuntoDistribucionPanificacionId = PuntoDistribucionPanificacionId;
            puntoDistribucionPanificacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (puntoDistribucionPanificacionBL.EliminarPuntoDistribucionPanificacion(puntoDistribucionPanificacionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
