using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using SmartBreadcrumbs.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class ContactoController : Controller
    {
        readonly ContactoDAO contactoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Contactos", FromController = typeof(HomeController))]

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ContactoDTO> listaContactos = contactoBL.ObtenerContactos();
            return Json(new { data = listaContactos });
        }

        public ActionResult InsertarContacto(string DescContacto, string Apellido, string Telefono, string Correo)
        {
            ContactoDTO contactoDTO = new();
            contactoDTO.DescContacto = DescContacto;
            contactoDTO.Apellido = Apellido;
            contactoDTO.Telefono = Telefono;
            contactoDTO.Correo = Correo;
            contactoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = contactoBL.AgregarContacto(contactoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarContacto(int ContactoId)
        {
            return Json(contactoBL.BuscarContactoID(ContactoId));
        }

        public ActionResult ActualizarContacto(int ContactoId, string DescContacto, string Apellido, string Telefono, string Correo)
        {
            ContactoDTO contactoDTO = new();
            contactoDTO.ContactoId = ContactoId;
            contactoDTO.DescContacto = DescContacto;
            contactoDTO.Apellido = Apellido;
            contactoDTO.Telefono = Telefono;
            contactoDTO.Correo = Correo;
            contactoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = contactoBL.ActualizarContacto(contactoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarContacto(int ContactoId)
        {
            ContactoDTO contactoDTO = new();
            contactoDTO.ContactoId = ContactoId;
            contactoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (contactoBL.EliminarContacto(contactoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
