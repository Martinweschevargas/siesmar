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
    public class ClasificacionEspecialidadController : Controller
    {
        readonly ClasificacionEspecialidad clasificacionEspecialidadBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Clasificaciones Especialidades", FromController = typeof(HomeController))]

        public IActionResult Index()
        {
           
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ClasificacionEspecialidadDTO> listaClasificacionEspecialidads = clasificacionEspecialidadBL.ObtenerClasificacionEspecialidads();
            return Json(new { data = listaClasificacionEspecialidads });
        }

        public ActionResult InsertarClasificacionEspecialidad(string DescClasificacionEspecialidad, string AbrevClasificacionEspecialidad, string CodigoClasificacionEspecialidad)
        {
            ClasificacionEspecialidadDTO clasificacionEspecialidadDTO = new();
            clasificacionEspecialidadDTO.DescClasificacionEspecialidad = DescClasificacionEspecialidad;
            clasificacionEspecialidadDTO.AbrevClasificacionEspecialidad = AbrevClasificacionEspecialidad;
            clasificacionEspecialidadDTO.CodigoClasificacionEspecialidad = CodigoClasificacionEspecialidad;
            clasificacionEspecialidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = clasificacionEspecialidadBL.AgregarClasificacionEspecialidad(clasificacionEspecialidadDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarClasificacionEspecialidad(int ClasificacionEspecialidadId)
        {
            return Json(clasificacionEspecialidadBL.BuscarClasificacionEspecialidadID(ClasificacionEspecialidadId));
        }

        public ActionResult ActualizarClasificacionEspecialidad(int ClasificacionEspecialidadId, string DescClasificacionEspecialidad, string AbrevClasificacionEspecialidad, string CodigoClasificacionEspecialidad)
        {
            ClasificacionEspecialidadDTO clasificacionEspecialidadDTO = new();
            clasificacionEspecialidadDTO.ClasificacionEspecialidadId = ClasificacionEspecialidadId;
            clasificacionEspecialidadDTO.DescClasificacionEspecialidad = DescClasificacionEspecialidad;
            clasificacionEspecialidadDTO.AbrevClasificacionEspecialidad = AbrevClasificacionEspecialidad;
            clasificacionEspecialidadDTO.CodigoClasificacionEspecialidad = CodigoClasificacionEspecialidad;
            clasificacionEspecialidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = clasificacionEspecialidadBL.ActualizarClasificacionEspecialidad(clasificacionEspecialidadDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarClasificacionEspecialidad(int ClasificacionEspecialidadId)
        {
            ClasificacionEspecialidadDTO clasificacionEspecialidadDTO = new();
            clasificacionEspecialidadDTO.ClasificacionEspecialidadId = ClasificacionEspecialidadId;
            clasificacionEspecialidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (clasificacionEspecialidadBL.EliminarClasificacionEspecialidad(clasificacionEspecialidadDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
