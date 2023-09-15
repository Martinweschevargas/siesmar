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
    public class PlataformaMedioComunicacionController : Controller
    {
        readonly PlataformaMedioComunicacionDAO plataformaMedioComunicacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Plataformas Medios Comunicaciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<PlataformaMedioComunicacionDTO> listaPlataformaMedioComunicacions = plataformaMedioComunicacionBL.ObtenerPlataformaMedioComunicacions();
            return Json(new { data = listaPlataformaMedioComunicacions });
        }

        public ActionResult InsertarPlataformaMedioComunicacion(string DescPlataformaMedioComunicacion, string CodigoPlataformaMedioComunicacion)
        {
            PlataformaMedioComunicacionDTO plataformaMedioComunicacionDTO = new();
            plataformaMedioComunicacionDTO.DescPlataformaMedioComunicacion = DescPlataformaMedioComunicacion;
            plataformaMedioComunicacionDTO.CodigoPlataformaMedioComunicacion = CodigoPlataformaMedioComunicacion;
            plataformaMedioComunicacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = plataformaMedioComunicacionBL.AgregarPlataformaMedioComunicacion(plataformaMedioComunicacionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarPlataformaMedioComunicacion(int PlataformaMedioComunicacionId)
        {
            return Json(plataformaMedioComunicacionBL.BuscarPlataformaMedioComunicacionID(PlataformaMedioComunicacionId));
        }

        public ActionResult ActualizarPlataformaMedioComunicacion(int PlataformaMedioComunicacionId, string DescPlataformaMedioComunicacion, string CodigoPlataformaMedioComunicacion)
        {
            PlataformaMedioComunicacionDTO plataformaMedioComunicacionDTO = new();
            plataformaMedioComunicacionDTO.PlataformaMedioComunicacionId = PlataformaMedioComunicacionId;
            plataformaMedioComunicacionDTO.DescPlataformaMedioComunicacion = DescPlataformaMedioComunicacion;
            plataformaMedioComunicacionDTO.CodigoPlataformaMedioComunicacion = CodigoPlataformaMedioComunicacion;
            plataformaMedioComunicacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = plataformaMedioComunicacionBL.ActualizarPlataformaMedioComunicacion(plataformaMedioComunicacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPlataformaMedioComunicacion(int PlataformaMedioComunicacionId)
        {
            PlataformaMedioComunicacionDTO plataformaMedioComunicacionDTO = new();
            plataformaMedioComunicacionDTO.PlataformaMedioComunicacionId = PlataformaMedioComunicacionId;
            plataformaMedioComunicacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (plataformaMedioComunicacionBL.EliminarPlataformaMedioComunicacion(plataformaMedioComunicacionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
