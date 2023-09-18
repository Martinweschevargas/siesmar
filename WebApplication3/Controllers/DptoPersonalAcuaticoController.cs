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
    public class DptoPersonalAcuaticoController : Controller
    {
        readonly DptoPersonalAcuaticoDAO dptoPersonalAcuaticoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Dptos Personales Acuaticos", FromController = typeof(HomeController))]

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DptoPersonalAcuaticoDTO> listaDptoPersonalAcuaticos = dptoPersonalAcuaticoBL.ObtenerDptoPersonalAcuaticos();
            return Json(new { data = listaDptoPersonalAcuaticos });
        }

        public ActionResult InsertarDptoPersonalAcuatico(string Codigo, string Descripcion)
        {
            DptoPersonalAcuaticoDTO dptoPersonalAcuaticoDTO = new();
            dptoPersonalAcuaticoDTO.Codigo = Codigo;
            dptoPersonalAcuaticoDTO.Descripcion = Descripcion;
            dptoPersonalAcuaticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = dptoPersonalAcuaticoBL.AgregarDptoPersonalAcuatico(dptoPersonalAcuaticoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDptoPersonalAcuatico(int DptoPersonalAcuaticoId)
        {
            return Json(dptoPersonalAcuaticoBL.BuscarDptoPersonalAcuaticoID(DptoPersonalAcuaticoId));
        }

        public ActionResult ActualizarDptoPersonalAcuatico(int DptoPersonalAcuaticoId, string Codigo, string Descripcion)
        {
            DptoPersonalAcuaticoDTO dptoPersonalAcuaticoDTO = new();
            dptoPersonalAcuaticoDTO.DptoPersonalAcuaticoId = DptoPersonalAcuaticoId;
            dptoPersonalAcuaticoDTO.Codigo = Codigo;
            dptoPersonalAcuaticoDTO.Descripcion = Descripcion;
            dptoPersonalAcuaticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = dptoPersonalAcuaticoBL.ActualizarDptoPersonalAcuatico(dptoPersonalAcuaticoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDptoPersonalAcuatico(int DptoPersonalAcuaticoId)
        {
            DptoPersonalAcuaticoDTO dptoPersonalAcuaticoDTO = new();
            dptoPersonalAcuaticoDTO.DptoPersonalAcuaticoId = DptoPersonalAcuaticoId;
            dptoPersonalAcuaticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (dptoPersonalAcuaticoBL.EliminarDptoPersonalAcuatico(dptoPersonalAcuaticoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
