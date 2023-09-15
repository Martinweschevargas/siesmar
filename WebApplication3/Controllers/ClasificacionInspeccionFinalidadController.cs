using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using SmartBreadcrumbs.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication3.Controllers;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class ClasificacionInspeccionFinalidadController : Controller
    {
        readonly ClasificacionInspeccionFinalidad clasificacionInspeccionFinalidadBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clasificaciones Inspecciones Finalidades", FromController = typeof(HomeController))]

        public IActionResult Index()
        {
           
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClasificacionInspeccionFinalidadDTO> listaClasificacionInspeccionFinalidads = clasificacionInspeccionFinalidadBL.ObtenerClasificacionInspeccionFinalidads();
            return Json(new { data = listaClasificacionInspeccionFinalidads });
        }

        public ActionResult InsertarClasificacionInspeccionFinalidad(string DescClasificacionInspeccionFinalidad, string CodigoClasificacionInspeccionFinalidad)
        {
            ClasificacionInspeccionFinalidadDTO clasificacionInspeccionFinalidadDTO = new();
            clasificacionInspeccionFinalidadDTO.DescClasificacionInspeccionFinalidad = DescClasificacionInspeccionFinalidad;
            clasificacionInspeccionFinalidadDTO.CodigoClasificacionInspeccionFinalidad = CodigoClasificacionInspeccionFinalidad;
            clasificacionInspeccionFinalidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = clasificacionInspeccionFinalidadBL.AgregarClasificacionInspeccionFinalidad(clasificacionInspeccionFinalidadDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClasificacionInspeccionFinalidad(int ClasificacionInspeccionFinalidadId)
        {
            return Json(clasificacionInspeccionFinalidadBL.BuscarClasificacionInspeccionFinalidadID(ClasificacionInspeccionFinalidadId));
        }

        public ActionResult ActualizarClasificacionInspeccionFinalidad(int ClasificacionInspeccionFinalidadId, string DescClasificacionInspeccionFinalidad, string CodigoClasificacionInspeccionFinalidad)
        {
            ClasificacionInspeccionFinalidadDTO clasificacionInspeccionFinalidadDTO = new();
            clasificacionInspeccionFinalidadDTO.ClasificacionInspeccionFinalidadId = ClasificacionInspeccionFinalidadId;
            clasificacionInspeccionFinalidadDTO.DescClasificacionInspeccionFinalidad = DescClasificacionInspeccionFinalidad;
            clasificacionInspeccionFinalidadDTO.CodigoClasificacionInspeccionFinalidad = CodigoClasificacionInspeccionFinalidad;
            clasificacionInspeccionFinalidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = clasificacionInspeccionFinalidadBL.ActualizarClasificacionInspeccionFinalidad(clasificacionInspeccionFinalidadDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClasificacionInspeccionFinalidad(int ClasificacionInspeccionFinalidadId)
        {
            ClasificacionInspeccionFinalidadDTO clasificacionInspeccionFinalidadDTO = new();
            clasificacionInspeccionFinalidadDTO.ClasificacionInspeccionFinalidadId = ClasificacionInspeccionFinalidadId;
            clasificacionInspeccionFinalidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (clasificacionInspeccionFinalidadBL.EliminarClasificacionInspeccionFinalidad(clasificacionInspeccionFinalidadDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
