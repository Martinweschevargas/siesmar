using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class MedioComunicacionController : Controller
    {
        readonly MedioComunicacionDAO medioComunicacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Medios Comunicación", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MedioComunicacionDTO> listaMedioComunicacions = medioComunicacionBL.ObtenerMedioComunicacions();
            return Json(new { data = listaMedioComunicacions });
        }

        public ActionResult InsertarMedioComunicacion(string CodigoMedioComunicacion, string DescMedioComunicacion)
        {
            MedioComunicacionDTO medioComunicacionDTO = new();
            medioComunicacionDTO.DescMedioComunicacion = DescMedioComunicacion;
            medioComunicacionDTO.CodigoMedioComunicacion = CodigoMedioComunicacion;
            medioComunicacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = medioComunicacionBL.AgregarMedioComunicacion(medioComunicacionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMedioComunicacion(int MedioComunicacionId)
        {
            return Json(medioComunicacionBL.BuscarMedioComunicacionID(MedioComunicacionId));
        }

        public ActionResult ActualizarMedioComunicacion(int MedioComunicacionId, string DescMedioComunicacion, string CodigoMedioComunicacion)
        {
            MedioComunicacionDTO medioComunicacionDTO = new();
            medioComunicacionDTO.MedioComunicacionId = MedioComunicacionId;
            medioComunicacionDTO.DescMedioComunicacion = DescMedioComunicacion;
            medioComunicacionDTO.CodigoMedioComunicacion = CodigoMedioComunicacion;
            medioComunicacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = medioComunicacionBL.ActualizarMedioComunicacion(medioComunicacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMedioComunicacion(int MedioComunicacionId)
        {
            MedioComunicacionDTO medioComunicacionDTO = new();
            medioComunicacionDTO.MedioComunicacionId = MedioComunicacionId;
            medioComunicacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = medioComunicacionBL.EliminarMedioComunicacion(medioComunicacionDTO);

            return Content(IND_OPERACION);
        }
    }
}
