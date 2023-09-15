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
    public class ServicioLavanderiaController : Controller
    {
        readonly ServicioLavanderiaDAO servicioLavanderiaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "ServicioLavanderia", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
       
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ServicioLavanderiaDTO> listaServicioLavanderias = servicioLavanderiaBL.ObtenerServicioLavanderias();
            return Json(new { data = listaServicioLavanderias });
        }

        public ActionResult InsertarServicioLavanderia(string DescServicioLavanderia, string CodigoServicioLavanderia)
        {
            ServicioLavanderiaDTO servicioLavanderiaDTO = new();
            servicioLavanderiaDTO.DescServicioLavanderia = DescServicioLavanderia;
            servicioLavanderiaDTO.CodigoServicioLavanderia = CodigoServicioLavanderia;
            servicioLavanderiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioLavanderiaBL.AgregarServicioLavanderia(servicioLavanderiaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarServicioLavanderia(int ServicioLavanderiaId)
        {
            return Json(servicioLavanderiaBL.BuscarServicioLavanderiaID(ServicioLavanderiaId));
        }

        public ActionResult ActualizarServicioLavanderia(int ServicioLavanderiaId, string DescServicioLavanderia, string CodigoServicioLavanderia)
        {
            ServicioLavanderiaDTO servicioLavanderiaDTO = new();
            servicioLavanderiaDTO.ServicioLavanderiaId = ServicioLavanderiaId;
            servicioLavanderiaDTO.DescServicioLavanderia = DescServicioLavanderia;
            servicioLavanderiaDTO.CodigoServicioLavanderia = CodigoServicioLavanderia;
            servicioLavanderiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioLavanderiaBL.ActualizarServicioLavanderia(servicioLavanderiaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarServicioLavanderia(int ServicioLavanderiaId)
        {
            ServicioLavanderiaDTO servicioLavanderiaDTO = new();
            servicioLavanderiaDTO.ServicioLavanderiaId = ServicioLavanderiaId;
            servicioLavanderiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (servicioLavanderiaBL.EliminarServicioLavanderia(servicioLavanderiaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
