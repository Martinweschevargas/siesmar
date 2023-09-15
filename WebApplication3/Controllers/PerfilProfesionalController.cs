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
    public class PerfilProfesionalController : Controller
    {
        readonly PerfilProfesionalDAO perfilProfesionalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Perfiles Profesionales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<PerfilProfesionalDTO> listaPerfilProfesionals = perfilProfesionalBL.ObtenerPerfilProfesionals();
            return Json(new { data = listaPerfilProfesionals });
        }

        public ActionResult InsertarPerfilProfesional(string DescPerfilProfesional, string CodigoPerfilProfesional)
        {
            PerfilProfesionalDTO perfilProfesionalDTO = new();
            perfilProfesionalDTO.DescPerfilProfesional = DescPerfilProfesional;
            perfilProfesionalDTO.CodigoPerfilProfesional = CodigoPerfilProfesional;
            perfilProfesionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = perfilProfesionalBL.AgregarPerfilProfesional(perfilProfesionalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarPerfilProfesional(int PerfilProfesionalId)
        {
            return Json(perfilProfesionalBL.BuscarPerfilProfesionalID(PerfilProfesionalId));
        }

        public ActionResult ActualizarPerfilProfesional(int PerfilProfesionalId, string DescPerfilProfesional, string CodigoPerfilProfesional)
        {
            PerfilProfesionalDTO perfilProfesionalDTO = new();
            perfilProfesionalDTO.PerfilProfesionalId = PerfilProfesionalId;
            perfilProfesionalDTO.DescPerfilProfesional = DescPerfilProfesional;
            perfilProfesionalDTO.CodigoPerfilProfesional = CodigoPerfilProfesional;
            perfilProfesionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = perfilProfesionalBL.ActualizarPerfilProfesional(perfilProfesionalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPerfilProfesional(int PerfilProfesionalId)
        {
            string mensaje = "";

            if (perfilProfesionalBL.EliminarPerfilProfesional(PerfilProfesionalId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
