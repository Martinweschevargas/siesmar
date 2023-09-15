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
    public class LugarFormacionServicioMilitarController : Controller
    {
        readonly LugarFormacionServicioMilitarDAO lugarFormacionServicioMilitarBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Lugares Formacion Servicios Militares", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<LugarFormacionServicioMilitarDTO> listaLugarFormacionServicioMilitars = lugarFormacionServicioMilitarBL.ObtenerLugarFormacionServicioMilitars();
            return Json(new { data = listaLugarFormacionServicioMilitars });
        }

        public ActionResult InsertarLugarFormacionServicioMilitar(string DescLugarFormacionServicioMilitar, string CodigoLugarFormacionServicioMilitar)
        {
            LugarFormacionServicioMilitarDTO lugarFormacionServicioMilitarDTO = new();
            lugarFormacionServicioMilitarDTO.DescLugarFormacionServicioMilitar = DescLugarFormacionServicioMilitar;
            lugarFormacionServicioMilitarDTO.CodigoLugarFormacionServicioMilitar = CodigoLugarFormacionServicioMilitar;
            lugarFormacionServicioMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = lugarFormacionServicioMilitarBL.AgregarLugarFormacionServicioMilitar(lugarFormacionServicioMilitarDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarLugarFormacionServicioMilitar(int LugarFormacionServicioMilitarId)
        {
            return Json(lugarFormacionServicioMilitarBL.BuscarLugarFormacionServicioMilitarID(LugarFormacionServicioMilitarId));
        }

        public ActionResult ActualizarLugarFormacionServicioMilitar(int LugarFormacionServicioMilitarId, string DescLugarFormacionServicioMilitar, string CodigoLugarFormacionServicioMilitar)
        {
            LugarFormacionServicioMilitarDTO lugarFormacionServicioMilitarDTO = new();
            lugarFormacionServicioMilitarDTO.LugarFormacionServicioMilitarId = LugarFormacionServicioMilitarId;
            lugarFormacionServicioMilitarDTO.DescLugarFormacionServicioMilitar = DescLugarFormacionServicioMilitar;
            lugarFormacionServicioMilitarDTO.CodigoLugarFormacionServicioMilitar = CodigoLugarFormacionServicioMilitar;
            lugarFormacionServicioMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = lugarFormacionServicioMilitarBL.ActualizarLugarFormacionServicioMilitar(lugarFormacionServicioMilitarDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarLugarFormacionServicioMilitar(int LugarFormacionServicioMilitarId)
        {
            string mensaje = "";

            if (lugarFormacionServicioMilitarBL.EliminarLugarFormacionServicioMilitar(LugarFormacionServicioMilitarId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
