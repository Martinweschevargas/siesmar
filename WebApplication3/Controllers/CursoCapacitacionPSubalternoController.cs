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
    public class CursoCapacitacionPSubalternoController : Controller
    {
        readonly CursoCapacitacionPSubalternoDAO cursoCapacitacionPSubalternoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Cursos Capacitaciones Psubalternos", FromController = typeof(HomeController))]

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CursoCapacitacionPSubalternoDTO> listaCursoCapacitacionPSubalternos = cursoCapacitacionPSubalternoBL.ObtenerCursoCapacitacionPSubalternos();
            return Json(new { data = listaCursoCapacitacionPSubalternos });
        }

        public ActionResult InsertarCursoCapacitacionPSubalterno(string DescCursoCapacitacion, string CodigoCursoCapacitacion, string DuracionCursoCapacitacion, string InicioTerminoCursoCapacitacion)
        {
            CursoCapacitacionPSubalternoDTO cursoCapacitacionPSubalternoDTO = new();
            cursoCapacitacionPSubalternoDTO.DescCursoCapacitacion = DescCursoCapacitacion;
            cursoCapacitacionPSubalternoDTO.CodigoCursoCapacitacion = CodigoCursoCapacitacion;
            cursoCapacitacionPSubalternoDTO.DuracionCursoCapacitacion = DuracionCursoCapacitacion;
            cursoCapacitacionPSubalternoDTO.InicioTerminoCursoCapacitacion = InicioTerminoCursoCapacitacion;
            cursoCapacitacionPSubalternoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = cursoCapacitacionPSubalternoBL.AgregarCursoCapacitacionPSubalterno(cursoCapacitacionPSubalternoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarcursoCapacitacionPSubalterno(int cursoCapacitacionPSubalternoId)
        {
            return Json(cursoCapacitacionPSubalternoBL.BuscarCursoCapacitacionPSubalternoID(cursoCapacitacionPSubalternoId));
        }

        public ActionResult ActualizarcursoCapacitacionPSubalterno(int CursoCapacitacionPSubalternoId, string DescCursoCapacitacion, string CodigoCursoCapacitacion, string DuracionCursoCapacitacion, string InicioTerminoCursoCapacitacion)
        {
            CursoCapacitacionPSubalternoDTO cursoCapacitacionPSubalternoDTO = new();
            cursoCapacitacionPSubalternoDTO.CursoCapacitacionPSubalternoId = CursoCapacitacionPSubalternoId;
            cursoCapacitacionPSubalternoDTO.DescCursoCapacitacion = DescCursoCapacitacion;
            cursoCapacitacionPSubalternoDTO.CodigoCursoCapacitacion = CodigoCursoCapacitacion;
            cursoCapacitacionPSubalternoDTO.DuracionCursoCapacitacion = DuracionCursoCapacitacion;
            cursoCapacitacionPSubalternoDTO.InicioTerminoCursoCapacitacion = InicioTerminoCursoCapacitacion;
            cursoCapacitacionPSubalternoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = cursoCapacitacionPSubalternoBL.ActualizarCursoCapacitacionPSubalterno(cursoCapacitacionPSubalternoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCursoCapacitacionPSubalterno(int CursoCapacitacionPSubalternoId)
        {
            CursoCapacitacionPSubalternoDTO cursoCapacitacionPSubalternoDTO = new();
            cursoCapacitacionPSubalternoDTO.CursoCapacitacionPSubalternoId = CursoCapacitacionPSubalternoId;
            cursoCapacitacionPSubalternoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (cursoCapacitacionPSubalternoBL.EliminarCursoCapacitacionPSubalterno(cursoCapacitacionPSubalternoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
