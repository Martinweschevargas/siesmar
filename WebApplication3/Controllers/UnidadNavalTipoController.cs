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
    public class UnidadNavalTipoController : Controller
    {
        readonly UnidadNavalTipoDAO unidadNavalTipoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Unidades Navales Tipos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<UnidadNavalTipoDTO> listaUnidadNavalTipos = unidadNavalTipoBL.ObtenerUnidadNavalTipos();
            return Json(new { data = listaUnidadNavalTipos });
        }

        public ActionResult InsertarUnidadNavalTipo(string DescUnidadNavalTipo, string CodigoUnidadNavalTipo)
        {
            UnidadNavalTipoDTO unidadNavalTipoDTO = new();
            unidadNavalTipoDTO.DescUnidadNavalTipo = DescUnidadNavalTipo;
            unidadNavalTipoDTO.CodigoUnidadNavalTipo = CodigoUnidadNavalTipo;
            unidadNavalTipoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadNavalTipoBL.AgregarUnidadNavalTipo(unidadNavalTipoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarUnidadNavalTipo(int UnidadNavalTipoId)
        {
            return Json(unidadNavalTipoBL.BuscarUnidadNavalTipoID(UnidadNavalTipoId));
        }

        public ActionResult ActualizarUnidadNavalTipo(int UnidadNavalTipoId, string DescUnidadNavalTipo, string CodigoUnidadNavalTipo)
        {
            UnidadNavalTipoDTO unidadNavalTipoDTO = new();
            unidadNavalTipoDTO.UnidadNavalTipoId = UnidadNavalTipoId;
            unidadNavalTipoDTO.DescUnidadNavalTipo = DescUnidadNavalTipo;
            unidadNavalTipoDTO.CodigoUnidadNavalTipo = CodigoUnidadNavalTipo;
            unidadNavalTipoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = unidadNavalTipoBL.ActualizarUnidadNavalTipo(unidadNavalTipoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarUnidadNavalTipo(int UnidadNavalTipoId)
        {
            UnidadNavalTipoDTO unidadNavalTipoDTO = new();
            unidadNavalTipoDTO.UnidadNavalTipoId = UnidadNavalTipoId;
            unidadNavalTipoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (unidadNavalTipoBL.EliminarUnidadNavalTipo(unidadNavalTipoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
