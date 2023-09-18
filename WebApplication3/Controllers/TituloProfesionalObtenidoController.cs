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
    public class TituloProfesionalObtenidoController : Controller
    {
        readonly TituloProfesionalObtenidoDAO tituloProfesionalObtenidoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Títulos Profesionales Obtenidos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TituloProfesionalObtenidoDTO> listaTituloProfesionalObtenidos = tituloProfesionalObtenidoBL.ObtenerTituloProfesionalObtenidos();
            return Json(new { data = listaTituloProfesionalObtenidos });
        }

        public ActionResult InsertarTituloProfesionalObtenido(string DescTituloProfesionalObtenido, string CodigoTituloProfesionalObtenido)
        {
            TituloProfesionalObtenidoDTO tituloProfesionalObtenidoDTO = new();
            tituloProfesionalObtenidoDTO.DescTituloProfesionalObtenido = DescTituloProfesionalObtenido;
            tituloProfesionalObtenidoDTO.CodigoTituloProfesionalObtenido = CodigoTituloProfesionalObtenido;
            tituloProfesionalObtenidoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tituloProfesionalObtenidoBL.AgregarTituloProfesionalObtenido(tituloProfesionalObtenidoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTituloProfesionalObtenido(int TituloProfesionalObtenidoId)
        {
            return Json(tituloProfesionalObtenidoBL.BuscarTituloProfesionalObtenidoID(TituloProfesionalObtenidoId));
        }

        public ActionResult ActualizarTituloProfesionalObtenido(int TituloProfesionalObtenidoId, string DescTituloProfesionalObtenido, string CodigoTituloProfesionalObtenido)
        {
            TituloProfesionalObtenidoDTO tituloProfesionalObtenidoDTO = new();
            tituloProfesionalObtenidoDTO.TituloProfesionalObtenidoId = TituloProfesionalObtenidoId;
            tituloProfesionalObtenidoDTO.DescTituloProfesionalObtenido = DescTituloProfesionalObtenido;
            tituloProfesionalObtenidoDTO.CodigoTituloProfesionalObtenido = CodigoTituloProfesionalObtenido;
            tituloProfesionalObtenidoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tituloProfesionalObtenidoBL.ActualizarTituloProfesionalObtenido(tituloProfesionalObtenidoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTituloProfesionalObtenido(int TituloProfesionalObtenidoId)
        {
            TituloProfesionalObtenidoDTO tituloProfesionalObtenidoDTO = new();
            tituloProfesionalObtenidoDTO.TituloProfesionalObtenidoId = TituloProfesionalObtenidoId;
            tituloProfesionalObtenidoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tituloProfesionalObtenidoBL.EliminarTituloProfesionalObtenido(tituloProfesionalObtenidoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
