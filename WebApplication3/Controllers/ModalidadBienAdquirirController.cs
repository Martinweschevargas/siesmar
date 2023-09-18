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
    public class ModalidadBienAdquirirController : Controller
    {
        readonly ModalidadBienAdquirirDAO modalidadBienAdquirirBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Modalidades Bienes Adquirir", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ModalidadBienAdquirirDTO> listaModalidadBienAdquirirs = modalidadBienAdquirirBL.ObtenerModalidadBienAdquirirs();
            return Json(new { data = listaModalidadBienAdquirirs });
        }

        public ActionResult InsertarModalidadBienAdquirir(string DescModalidadBienAdquirir, string CodigoModalidadBienAdquirir)
        {
            ModalidadBienAdquirirDTO modalidadBienAdquirirDTO = new();
            modalidadBienAdquirirDTO.DescModalidadBienAdquirir = DescModalidadBienAdquirir;
            modalidadBienAdquirirDTO.CodigoModalidadBienAdquirir = CodigoModalidadBienAdquirir;
            modalidadBienAdquirirDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = modalidadBienAdquirirBL.AgregarModalidadBienAdquirir(modalidadBienAdquirirDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarModalidadBienAdquirir(int ModalidadBienAdquirirId)
        {
            return Json(modalidadBienAdquirirBL.BuscarModalidadBienAdquirirID(ModalidadBienAdquirirId));
        }

        public ActionResult ActualizarModalidadBienAdquirir(int ModalidadBienAdquirirId, string DescModalidadBienAdquirir, string CodigoModalidadBienAdquirir)
        {
            ModalidadBienAdquirirDTO modalidadBienAdquirirDTO = new();
            modalidadBienAdquirirDTO.ModalidadBienAdquirirId = ModalidadBienAdquirirId;
            modalidadBienAdquirirDTO.DescModalidadBienAdquirir = DescModalidadBienAdquirir;
            modalidadBienAdquirirDTO.CodigoModalidadBienAdquirir = CodigoModalidadBienAdquirir;
            modalidadBienAdquirirDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = modalidadBienAdquirirBL.ActualizarModalidadBienAdquirir(modalidadBienAdquirirDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarModalidadBienAdquirir(int ModalidadBienAdquirirId)
        {
            string mensaje = "";

            if (modalidadBienAdquirirBL.EliminarModalidadBienAdquirir(ModalidadBienAdquirirId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
