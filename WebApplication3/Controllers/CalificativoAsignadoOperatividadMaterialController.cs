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
    public class CalificativoAsignadoOperatividadMaterialController : Controller
    {
        readonly ILogger<CalificativoAsignadoOperatividadMaterialController> _logger;

        public CalificativoAsignadoOperatividadMaterialController(ILogger<CalificativoAsignadoOperatividadMaterialController> logger)
        {
            _logger = logger;
        }

        readonly CalificativoAsignadoOperatividadMaterial calificativoAsignadoOperatividadMaterialBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Calificativos Asignados Operatividad Materiales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CalificativoAsignadoOperatividadMaterialDTO> listaCalificativoAsignadoOperatividadMaterials = calificativoAsignadoOperatividadMaterialBL.ObtenerCalificativoAsignadoOperatividadMaterials();
            return Json(new { data = listaCalificativoAsignadoOperatividadMaterials });
        }

        public ActionResult InsertarCalificativoAsignadoOperatividadMaterial(string Calificativo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                CalificativoAsignadoOperatividadMaterialDTO calificativoAsignadoOperatividadMaterialDTO = new();
                calificativoAsignadoOperatividadMaterialDTO.Descripcion = Descripcion;
                calificativoAsignadoOperatividadMaterialDTO.Calificativo = Calificativo;
                calificativoAsignadoOperatividadMaterialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = calificativoAsignadoOperatividadMaterialBL.AgregarCalificativoAsignadoOperatividadMaterial(calificativoAsignadoOperatividadMaterialDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCalificativoAsignadoOperatividadMaterial(int CalificativoAsignadoOperatividadMaterialId)
        {
            return Json(calificativoAsignadoOperatividadMaterialBL.BuscarCalificativoAsignadoOperatividadMaterialID(CalificativoAsignadoOperatividadMaterialId));
        }

        public ActionResult ActualizarCalificativoAsignadoOperatividadMaterial(int CalificativoAsignadoOperatividadMaterialId, string Calificativo, string Descripcion)
        {
            CalificativoAsignadoOperatividadMaterialDTO calificativoAsignadoOperatividadMaterialDTO = new();
            calificativoAsignadoOperatividadMaterialDTO.CalificativoAsignadoOperatividadMaterialId = CalificativoAsignadoOperatividadMaterialId;
            calificativoAsignadoOperatividadMaterialDTO.Descripcion = Descripcion;
            calificativoAsignadoOperatividadMaterialDTO.Calificativo = Calificativo;
            calificativoAsignadoOperatividadMaterialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = calificativoAsignadoOperatividadMaterialBL.ActualizarCalificativoAsignadoOperatividadMaterial(calificativoAsignadoOperatividadMaterialDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCalificativoAsignadoOperatividadMaterial(int CalificativoAsignadoOperatividadMaterialId)
        {
            CalificativoAsignadoOperatividadMaterialDTO calificativoAsignadoOperatividadMaterialDTO = new();
            calificativoAsignadoOperatividadMaterialDTO.CalificativoAsignadoOperatividadMaterialId = CalificativoAsignadoOperatividadMaterialId;
            calificativoAsignadoOperatividadMaterialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = calificativoAsignadoOperatividadMaterialBL.EliminarCalificativoAsignadoOperatividadMaterial(calificativoAsignadoOperatividadMaterialDTO);

            return Content(IND_OPERACION);
        }
    }
}
