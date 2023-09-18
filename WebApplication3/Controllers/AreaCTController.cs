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
    public class AreaCTController : Controller
    {
        readonly AreaCTDAO areaCTBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Areas CT", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<AreaCTDTO> listaAreaCTs = areaCTBL.ObtenerAreaCTs();
            return Json(new { data = listaAreaCTs });
        }

        public ActionResult InsertarAreaCT(string DescAreaCT, string CodigoAreaCT)
        {
            AreaCTDTO areaCTDTO = new();
            areaCTDTO.DescAreaCT = DescAreaCT;
            areaCTDTO.CodigoAreaCT = CodigoAreaCT;
            areaCTDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = areaCTBL.AgregarAreaCT(areaCTDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAreaCT(int AreaCTId)
        {
            return Json(areaCTBL.BuscarAreaCTID(AreaCTId));
        }

        public ActionResult ActualizarAreaCT(int AreaCTId, string DescAreaCT, string CodigoAreaCT)
        {
            AreaCTDTO areaCTDTO = new();
            areaCTDTO.AreaCTId = AreaCTId;
            areaCTDTO.DescAreaCT = DescAreaCT;
            areaCTDTO.CodigoAreaCT = CodigoAreaCT;
            areaCTDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = areaCTBL.ActualizarAreaCT(areaCTDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAreaCT(int AreaCTId)
        {
            AreaCTDTO areaCTDTO = new();
            areaCTDTO.AreaCTId = AreaCTId;
            areaCTDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (areaCTBL.EliminarAreaCT(areaCTDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
