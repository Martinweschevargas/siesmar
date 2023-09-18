using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class ClasificacionInspeccionConocimientoController : Controller
    {
        readonly ClasificacionInspeccionConocimiento clasificacionInspeccionConocimientoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clasificaciones Inspecciones Conocimientos", FromController = typeof(HomeController))]

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClasificacionInspeccionConocimientoDTO> listaClasificacionInspeccionConocimientos = clasificacionInspeccionConocimientoBL.ObtenerClasificacionInspeccionConocimientos();
            return Json(new { data = listaClasificacionInspeccionConocimientos });
        }

        public ActionResult InsertarClasificacionInspeccionConocimiento(string DescClasificacionInspeccionConocimiento, string CodigoClasificacionInspeccionConocimiento)
        {
            ClasificacionInspeccionConocimientoDTO clasificacionInspeccionConocimientoDTO = new();
            clasificacionInspeccionConocimientoDTO.DescClasificacionInspeccionConocimiento = DescClasificacionInspeccionConocimiento;
            clasificacionInspeccionConocimientoDTO.CodigoClasificacionInspeccionConocimiento = CodigoClasificacionInspeccionConocimiento;
            clasificacionInspeccionConocimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = clasificacionInspeccionConocimientoBL.AgregarClasificacionInspeccionConocimiento(clasificacionInspeccionConocimientoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClasificacionInspeccionConocimiento(int ClasificacionInspeccionConocimientoId)
        {
            return Json(clasificacionInspeccionConocimientoBL.BuscarClasificacionInspeccionConocimientoID(ClasificacionInspeccionConocimientoId));
        }

        public ActionResult ActualizarClasificacionInspeccionConocimiento(int ClasificacionInspeccionConocimientoId, string DescClasificacionInspeccionConocimiento, string CodigoClasificacionInspeccionConocimiento)
        {
            ClasificacionInspeccionConocimientoDTO clasificacionInspeccionConocimientoDTO = new();
            clasificacionInspeccionConocimientoDTO.ClasificacionInspeccionConocimientoId = ClasificacionInspeccionConocimientoId;
            clasificacionInspeccionConocimientoDTO.DescClasificacionInspeccionConocimiento = DescClasificacionInspeccionConocimiento;
            clasificacionInspeccionConocimientoDTO.CodigoClasificacionInspeccionConocimiento = CodigoClasificacionInspeccionConocimiento;
            clasificacionInspeccionConocimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = clasificacionInspeccionConocimientoBL.ActualizarClasificacionInspeccionConocimiento(clasificacionInspeccionConocimientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClasificacionInspeccionConocimiento(int ClasificacionInspeccionConocimientoId)
        {
            ClasificacionInspeccionConocimientoDTO clasificacionInspeccionConocimientoDTO = new();
            clasificacionInspeccionConocimientoDTO.ClasificacionInspeccionConocimientoId = ClasificacionInspeccionConocimientoId;
            clasificacionInspeccionConocimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (clasificacionInspeccionConocimientoBL.EliminarClasificacionInspeccionConocimiento(clasificacionInspeccionConocimientoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
