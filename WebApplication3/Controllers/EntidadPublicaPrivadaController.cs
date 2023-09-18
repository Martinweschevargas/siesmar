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
    public class EntidadPublicaPrivadaController : Controller
    {
        readonly EntidadPublicaPrivadaDAO entidadPublicaPrivadaBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Entidades Publicas Privadas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EntidadPublicaPrivadaDTO> listaEntidadPublicaPrivadas = entidadPublicaPrivadaBL.ObtenerEntidadPublicaPrivadas();
            return Json(new { data = listaEntidadPublicaPrivadas });
        }

        public ActionResult InsertarEntidadPublicaPrivada(string DescEntidadPublicaPrivada, string CodigoEntidadPublicaPrivada)
        {
            EntidadPublicaPrivadaDTO entidadPublicaPrivadaDTO = new();
            entidadPublicaPrivadaDTO.DescEntidadPublicaPrivada = DescEntidadPublicaPrivada;
            entidadPublicaPrivadaDTO.CodigoEntidadPublicaPrivada = CodigoEntidadPublicaPrivada;
            entidadPublicaPrivadaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = entidadPublicaPrivadaBL.AgregarEntidadPublicaPrivada(entidadPublicaPrivadaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEntidadPublicaPrivada(int EntidadPublicaPrivadaId)
        {
            return Json(entidadPublicaPrivadaBL.BuscarEntidadPublicaPrivadaID(EntidadPublicaPrivadaId));
        }

        public ActionResult ActualizarEntidadPublicaPrivada(int EntidadPublicaPrivadaId, string DescEntidadPublicaPrivada, string CodigoEntidadPublicaPrivada)
        {
            EntidadPublicaPrivadaDTO entidadPublicaPrivadaDTO = new();
            entidadPublicaPrivadaDTO.EntidadPublicaPrivadaId = EntidadPublicaPrivadaId;
            entidadPublicaPrivadaDTO.DescEntidadPublicaPrivada = DescEntidadPublicaPrivada;
            entidadPublicaPrivadaDTO.CodigoEntidadPublicaPrivada = CodigoEntidadPublicaPrivada;
            entidadPublicaPrivadaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = entidadPublicaPrivadaBL.ActualizarEntidadPublicaPrivada(entidadPublicaPrivadaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEntidadPublicaPrivada(int EntidadPublicaPrivadaId)
        {
            EntidadPublicaPrivadaDTO entidadPublicaPrivadaDTO = new();
            entidadPublicaPrivadaDTO.EntidadPublicaPrivadaId = EntidadPublicaPrivadaId;
            entidadPublicaPrivadaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (entidadPublicaPrivadaBL.EliminarEntidadPublicaPrivada(entidadPublicaPrivadaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
