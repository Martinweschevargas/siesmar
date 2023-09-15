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
    public class TomaConocimientoController : Controller
    {
        readonly TomaConocimientoDAO tomaConocimientoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Toma Conocimientos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TomaConocimientoDTO> listaTomaConocimientos = tomaConocimientoBL.ObtenerTomaConocimientos();
            return Json(new { data = listaTomaConocimientos });
        }

        public ActionResult InsertarTomaConocimiento(string Descripcion, string Codigo)
        {
            TomaConocimientoDTO tomaConocimientoDTO = new();
            tomaConocimientoDTO.DescTomaConocimiento = Descripcion;
            tomaConocimientoDTO.CodigoTomaConocimiento = Codigo;
            tomaConocimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tomaConocimientoBL.AgregarTomaConocimiento(tomaConocimientoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTomaConocimiento(int TomaConocimientoId)
        {
            return Json(tomaConocimientoBL.BuscarTomaConocimientoID(TomaConocimientoId));
        }

        public ActionResult ActualizarTomaConocimiento(int TomaConocimientoId, string Descripcion, string Codigo)
        {
            TomaConocimientoDTO tomaConocimientoDTO = new();
            tomaConocimientoDTO.TomaConocimientoId = TomaConocimientoId;
            tomaConocimientoDTO.DescTomaConocimiento = Descripcion;
            tomaConocimientoDTO.CodigoTomaConocimiento = Codigo;
            tomaConocimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tomaConocimientoBL.ActualizarTomaConocimiento(tomaConocimientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTomaConocimiento(int TomaConocimientoId)
        {
            TomaConocimientoDTO tomaConocimientoDTO = new();
            tomaConocimientoDTO.TomaConocimientoId = TomaConocimientoId;
            tomaConocimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tomaConocimientoBL.EliminarTomaConocimiento(tomaConocimientoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
