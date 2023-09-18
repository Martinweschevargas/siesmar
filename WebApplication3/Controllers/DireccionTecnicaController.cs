using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DireccionTecnicaController : Controller
    {
        readonly DireccionTecnicaDAO direccionTecnicaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Direcciones Técnicas", FromController = typeof(HomeController))]

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DireccionTecnicaDTO> listaDireccionTecnicas = direccionTecnicaBL.ObtenerDireccionTecnicas();
            return Json(new { data = listaDireccionTecnicas });
        }

        public ActionResult InsertarDireccionTecnica(string DescDireccionTecnica, string CodigoDireccionTecnica)
        {
            DireccionTecnicaDTO direccionTecnicaDTO = new();
            direccionTecnicaDTO.DescDireccionTecnica = DescDireccionTecnica;
            direccionTecnicaDTO.CodigoDireccionTecnica = CodigoDireccionTecnica;
            direccionTecnicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = direccionTecnicaBL.AgregarDireccionTecnica(direccionTecnicaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDireccionTecnica(int DireccionTecnicaId)
        {
            return Json(direccionTecnicaBL.BuscarDireccionTecnicaID(DireccionTecnicaId));
        }

        public ActionResult ActualizarDireccionTecnica(int DireccionTecnicaId, string DescDireccionTecnica, string CodigoDireccionTecnica)
        {
            DireccionTecnicaDTO direccionTecnicaDTO = new();
            direccionTecnicaDTO.DireccionTecnicaId = DireccionTecnicaId;
            direccionTecnicaDTO.DescDireccionTecnica = DescDireccionTecnica;
            direccionTecnicaDTO.CodigoDireccionTecnica = CodigoDireccionTecnica;
            direccionTecnicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = direccionTecnicaBL.ActualizarDireccionTecnica(direccionTecnicaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDireccionTecnica(int DireccionTecnicaId)
        {
            DireccionTecnicaDTO direccionTecnicaDTO = new();
            direccionTecnicaDTO.DireccionTecnicaId = DireccionTecnicaId;
            direccionTecnicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (direccionTecnicaBL.EliminarDireccionTecnica(direccionTecnicaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
