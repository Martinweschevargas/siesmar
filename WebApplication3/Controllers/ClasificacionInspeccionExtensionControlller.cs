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
    public class ClasificacionInspeccionExtensionController : Controller
    {
        readonly ClasificacionInspeccionExtension clasificacionInspeccionExtensionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clasificaciones Inspecciones Extensiones", FromController = typeof(HomeController))]

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClasificacionInspeccionExtensionDTO> listaClasificacionInspeccionExtensions = clasificacionInspeccionExtensionBL.ObtenerClasificacionInspeccionExtensions();
            return Json(new { data = listaClasificacionInspeccionExtensions });
        }

        public ActionResult InsertarClasificacionInspeccionExtension(string DescClasificacionInspeccionExtension, string CodigoClasificacionInspeccionExtension)
        {
            ClasificacionInspeccionExtensionDTO clasificacionInspeccionExtensionDTO = new();
            clasificacionInspeccionExtensionDTO.DescClasificacionInspeccionExtension = DescClasificacionInspeccionExtension;
            clasificacionInspeccionExtensionDTO.CodigoClasificacionInspeccionExtension = CodigoClasificacionInspeccionExtension;
            clasificacionInspeccionExtensionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = clasificacionInspeccionExtensionBL.AgregarClasificacionInspeccionExtension(clasificacionInspeccionExtensionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClasificacionInspeccionExtension(int ClasificacionInspeccionExtensionId)
        {
            return Json(clasificacionInspeccionExtensionBL.BuscarClasificacionInspeccionExtensionID(ClasificacionInspeccionExtensionId));
        }

        public ActionResult ActualizarClasificacionInspeccionExtension(int ClasificacionInspeccionExtensionId, string DescClasificacionInspeccionExtension, string CodigoClasificacionInspeccionExtension)
        {
            ClasificacionInspeccionExtensionDTO clasificacionInspeccionExtensionDTO = new();
            clasificacionInspeccionExtensionDTO.ClasificacionInspeccionExtensionId = ClasificacionInspeccionExtensionId;
            clasificacionInspeccionExtensionDTO.DescClasificacionInspeccionExtension = DescClasificacionInspeccionExtension;
            clasificacionInspeccionExtensionDTO.CodigoClasificacionInspeccionExtension = CodigoClasificacionInspeccionExtension;
            clasificacionInspeccionExtensionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = clasificacionInspeccionExtensionBL.ActualizarClasificacionInspeccionExtension(clasificacionInspeccionExtensionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClasificacionInspeccionExtension(int ClasificacionInspeccionExtensionId)
        {
            ClasificacionInspeccionExtensionDTO clasificacionInspeccionExtensionDTO = new();
            clasificacionInspeccionExtensionDTO.ClasificacionInspeccionExtensionId = ClasificacionInspeccionExtensionId;
            clasificacionInspeccionExtensionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (clasificacionInspeccionExtensionBL.EliminarClasificacionInspeccionExtension(clasificacionInspeccionExtensionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
