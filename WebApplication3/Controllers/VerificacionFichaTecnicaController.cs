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
    public class VerificacionFichaTecnicaController : Controller
    {
        readonly VerificacionFichaTecnicaDAO verificacionFichaTecnicaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Verificaciones Fichas Técnicas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
        
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<VerificacionFichaTecnicaDTO> listaVerificacionFichaTecnicas = verificacionFichaTecnicaBL.ObtenerVerificacionFichaTecnicas();
            return Json(new { data = listaVerificacionFichaTecnicas });
        }

        public ActionResult InsertarVerificacionFichaTecnica(string DescVerificacionFichaTecnica, string CodigoVerificacionFichaTecnica)
        {
            VerificacionFichaTecnicaDTO verificacionFichaTecnicaDTO = new();
            verificacionFichaTecnicaDTO.DescVerificacionFichaTecnica = DescVerificacionFichaTecnica;
            verificacionFichaTecnicaDTO.CodigoVerificacionFichaTecnica = CodigoVerificacionFichaTecnica;
            verificacionFichaTecnicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = verificacionFichaTecnicaBL.AgregarVerificacionFichaTecnica(verificacionFichaTecnicaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarVerificacionFichaTecnica(int VerificacionFichaTecnicaId)
        {
            return Json(verificacionFichaTecnicaBL.BuscarVerificacionFichaTecnicaID(VerificacionFichaTecnicaId));
        }

        public ActionResult ActualizarVerificacionFichaTecnica(int VerificacionFichaTecnicaId, string DescVerificacionFichaTecnica, string CodigoVerificacionFichaTecnica)
        {
            VerificacionFichaTecnicaDTO verificacionFichaTecnicaDTO = new();
            verificacionFichaTecnicaDTO.VerificacionFichaTecnicaId = VerificacionFichaTecnicaId;
            verificacionFichaTecnicaDTO.DescVerificacionFichaTecnica = DescVerificacionFichaTecnica;
            verificacionFichaTecnicaDTO.CodigoVerificacionFichaTecnica = CodigoVerificacionFichaTecnica;
            verificacionFichaTecnicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = verificacionFichaTecnicaBL.ActualizarVerificacionFichaTecnica(verificacionFichaTecnicaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarVerificacionFichaTecnica(int VerificacionFichaTecnicaId)
        {
            VerificacionFichaTecnicaDTO verificacionFichaTecnicaDTO = new();
            verificacionFichaTecnicaDTO.VerificacionFichaTecnicaId = VerificacionFichaTecnicaId;
            verificacionFichaTecnicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (verificacionFichaTecnicaBL.EliminarVerificacionFichaTecnica(verificacionFichaTecnicaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
