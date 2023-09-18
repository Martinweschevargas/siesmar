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
    public class PublicoObjetivoController : Controller
    {
        readonly PublicoObjetivoDAO publicoObjetivoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Personales Militares", FromController = typeof(HomeController))]

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<PublicoObjetivoDTO> listaPublicoObjetivos = publicoObjetivoBL.ObtenerPublicoObjetivos();
            return Json(new { data = listaPublicoObjetivos });
        }

        public ActionResult InsertarPublicoObjetivo(string DescPublicoObjetivo, string CodigoPublicoObjetivo)
        {
            PublicoObjetivoDTO publicoObjetivoDTO = new();
            publicoObjetivoDTO.DescPublicoObjetivo = DescPublicoObjetivo;
            publicoObjetivoDTO.CodigoPublicoObjetivo = CodigoPublicoObjetivo;
            publicoObjetivoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = publicoObjetivoBL.AgregarPublicoObjetivo(publicoObjetivoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarPublicoObjetivo(int PublicoObjetivoId)
        {
            return Json(publicoObjetivoBL.BuscarPublicoObjetivoID(PublicoObjetivoId));
        }

        public ActionResult ActualizarPublicoObjetivo(int PublicoObjetivoId, string DescPublicoObjetivo, string CodigoPublicoObjetivo)
        {
            PublicoObjetivoDTO publicoObjetivoDTO = new();
            publicoObjetivoDTO.PublicoObjetivoId = PublicoObjetivoId;
            publicoObjetivoDTO.DescPublicoObjetivo = DescPublicoObjetivo;
            publicoObjetivoDTO.CodigoPublicoObjetivo = CodigoPublicoObjetivo;
            publicoObjetivoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = publicoObjetivoBL.ActualizarPublicoObjetivo(publicoObjetivoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPublicoObjetivo(int PublicoObjetivoId)
        {
            PublicoObjetivoDTO publicoObjetivoDTO = new();
            publicoObjetivoDTO.PublicoObjetivoId = PublicoObjetivoId;
            publicoObjetivoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (publicoObjetivoBL.EliminarPublicoObjetivo(publicoObjetivoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
