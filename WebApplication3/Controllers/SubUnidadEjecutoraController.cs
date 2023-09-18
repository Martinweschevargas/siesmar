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
    public class SubUnidadEjecutoraController : Controller
    {
        readonly SubUnidadEjecutoraDAO subUnidadEjecutoraBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "SubUnidadEjecutora", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SubUnidadEjecutoraDTO> listaSubUnidadEjecutoras = subUnidadEjecutoraBL.ObtenerSubUnidadEjecutoras();
            return Json(new { data = listaSubUnidadEjecutoras });
        }

        public ActionResult InsertarSubUnidadEjecutora(string DescSubUnidadEjecutora, string CodigoSubUnidadEjecutora)
        {
            SubUnidadEjecutoraDTO subUnidadEjecutoraDTO = new();
            subUnidadEjecutoraDTO.DescSubUnidadEjecutora = DescSubUnidadEjecutora;
            subUnidadEjecutoraDTO.CodigoSubUnidadEjecutora = CodigoSubUnidadEjecutora;
            subUnidadEjecutoraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = subUnidadEjecutoraBL.AgregarSubUnidadEjecutora(subUnidadEjecutoraDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSubUnidadEjecutora(int SubUnidadEjecutoraId)
        {
            return Json(subUnidadEjecutoraBL.BuscarSubUnidadEjecutoraID(SubUnidadEjecutoraId));
        }

        public ActionResult ActualizarSubUnidadEjecutora(int SubUnidadEjecutoraId, string DescSubUnidadEjecutora, string CodigoSubUnidadEjecutora)
        {
            SubUnidadEjecutoraDTO subUnidadEjecutoraDTO = new();
            subUnidadEjecutoraDTO.SubUnidadEjecutoraId = SubUnidadEjecutoraId;
            subUnidadEjecutoraDTO.DescSubUnidadEjecutora = DescSubUnidadEjecutora;
            subUnidadEjecutoraDTO.CodigoSubUnidadEjecutora = CodigoSubUnidadEjecutora;
            subUnidadEjecutoraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = subUnidadEjecutoraBL.ActualizarSubUnidadEjecutora(subUnidadEjecutoraDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSubUnidadEjecutora(int SubUnidadEjecutoraId)
        {
            SubUnidadEjecutoraDTO subUnidadEjecutoraDTO = new();
            subUnidadEjecutoraDTO.SubUnidadEjecutoraId = SubUnidadEjecutoraId;
            subUnidadEjecutoraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = subUnidadEjecutoraBL.EliminarSubUnidadEjecutora(subUnidadEjecutoraDTO);

            return Content(IND_OPERACION);
        }
    }
}
