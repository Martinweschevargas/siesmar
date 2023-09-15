using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class FaseProyectoController : Controller
    {
        readonly FaseProyectoDAO faseProyectoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Fases Proyectos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<FaseProyectoDTO> listaFaseProyectos = faseProyectoBL.ObtenerFaseProyectos();
            return Json(new { data = listaFaseProyectos });
        }

        public ActionResult InsertarFaseProyecto(string DescFaseProyecto, string CodigoFaseProyecto)
        {
            FaseProyectoDTO faseProyectoDTO = new();
            faseProyectoDTO.DescFaseProyecto = DescFaseProyecto;
            faseProyectoDTO.CodigoFaseProyecto = CodigoFaseProyecto;
            faseProyectoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = faseProyectoBL.AgregarFaseProyecto(faseProyectoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarFaseProyecto(int FaseProyectoId)
        {
            return Json(faseProyectoBL.BuscarFaseProyectoID(FaseProyectoId));
        }

        public ActionResult ActualizarFaseProyecto(int FaseProyectoId, string DescFaseProyecto, string CodigoFaseProyecto)
        {
            FaseProyectoDTO faseProyectoDTO = new();
            faseProyectoDTO.FaseProyectoId = FaseProyectoId;
            faseProyectoDTO.DescFaseProyecto = DescFaseProyecto;
            faseProyectoDTO.CodigoFaseProyecto = CodigoFaseProyecto;
            faseProyectoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = faseProyectoBL.ActualizarFaseProyecto(faseProyectoDTO);
              
            return Content(IND_OPERACION);
        }

        public ActionResult EliminarFaseProyecto(int FaseProyectoId)
        {
            FaseProyectoDTO faseProyectoDTO = new();
            faseProyectoDTO.FaseProyectoId = FaseProyectoId;
            faseProyectoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (faseProyectoBL.EliminarFaseProyecto(faseProyectoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
