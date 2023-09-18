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
    public class NivelAlistamientoController : Controller
    {
        readonly NivelAlistamientoDAO  nivelAlistamientoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Niveles Alistamientos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<NivelAlistamientoDTO> listaNivelAlistamientos = nivelAlistamientoBL.ObtenerNivelAlistamientos();
            return Json(new { data = listaNivelAlistamientos });
        }

        public ActionResult InsertarNivelAlistamiento(string DescNivelAlistamiento, string Calificativo)
        {
            NivelAlistamientoDTO nivelAlistamientoDTO = new();
            nivelAlistamientoDTO.DescNivelAlistamiento = DescNivelAlistamiento;
            nivelAlistamientoDTO.Calificativo = Calificativo;
            nivelAlistamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = nivelAlistamientoBL.AgregarNivelAlistamiento(nivelAlistamientoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarNivelAlistamiento(int NivelAlistamientoId)
        {
            return Json(nivelAlistamientoBL.BuscarNivelAlistamientoID(NivelAlistamientoId));
        }

        public ActionResult ActualizarNivelAlistamiento(int NivelAlistamientoId, string DescNivelAlistamiento, string Calificativo)
        {
            NivelAlistamientoDTO nivelAlistamientoDTO = new();
            nivelAlistamientoDTO.NivelAlistamientoId = NivelAlistamientoId;
            nivelAlistamientoDTO.DescNivelAlistamiento = DescNivelAlistamiento;
            nivelAlistamientoDTO.Calificativo = Calificativo;
            nivelAlistamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = nivelAlistamientoBL.ActualizarNivelAlistamiento(nivelAlistamientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarNivelAlistamiento(int NivelAlistamientoId)
        {
            string mensaje = "";

            if (nivelAlistamientoBL.EliminarNivelAlistamiento(NivelAlistamientoId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
