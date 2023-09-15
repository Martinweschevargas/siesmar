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
    public class ServicioReligiosoController : Controller
    {
        readonly ServicioReligiosoDAO servicioReligiosoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "ServicioReligioso", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ServicioReligiosoDTO> listaServicioReligiosos = servicioReligiosoBL.ObtenerServicioReligiosos();
            return Json(new { data = listaServicioReligiosos });
        }

        public ActionResult InsertarServicioReligioso(string DescServicioReligioso, string CodigoServicioReligioso)
        {
            ServicioReligiosoDTO servicioReligiosoDTO = new();
            servicioReligiosoDTO.DescServicioReligioso = DescServicioReligioso;
            servicioReligiosoDTO.CodigoServicioReligioso = CodigoServicioReligioso;
            servicioReligiosoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioReligiosoBL.AgregarServicioReligioso(servicioReligiosoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarServicioReligioso(int ServicioReligiosoId)
        {
            return Json(servicioReligiosoBL.BuscarServicioReligiosoID(ServicioReligiosoId));
        }

        public ActionResult ActualizarServicioReligioso(int ServicioReligiosoId, string DescServicioReligioso, string CodigoServicioReligioso)
        {
            ServicioReligiosoDTO servicioReligiosoDTO = new();
            servicioReligiosoDTO.ServicioReligiosoId = ServicioReligiosoId;
            servicioReligiosoDTO.DescServicioReligioso = DescServicioReligioso;
            servicioReligiosoDTO.CodigoServicioReligioso = CodigoServicioReligioso;
            servicioReligiosoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioReligiosoBL.ActualizarServicioReligioso(servicioReligiosoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarServicioReligioso(int ServicioReligiosoId)
        {
            ServicioReligiosoDTO servicioReligiosoDTO = new();
            servicioReligiosoDTO.ServicioReligiosoId = ServicioReligiosoId;
            servicioReligiosoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (servicioReligiosoBL.EliminarServicioReligioso(servicioReligiosoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
