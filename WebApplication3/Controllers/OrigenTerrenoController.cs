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
    public class OrigenTerrenoController : Controller
    {
        readonly OrigenTerrenoDAO origenTerrenoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Orígenes Terrenos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<OrigenTerrenoDTO> listaOrigenTerrenos = origenTerrenoBL.ObtenerOrigenTerrenos();
            return Json(new { data = listaOrigenTerrenos });
        }

        public ActionResult InsertarOrigenTerreno(string DescOrigenTerreno, string CodigoOrigenTerreno)
        {
            OrigenTerrenoDTO origenTerrenoDTO = new();
            origenTerrenoDTO.DescOrigenTerreno = DescOrigenTerreno;
            origenTerrenoDTO.CodigoOrigenTerreno = CodigoOrigenTerreno;
            origenTerrenoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = origenTerrenoBL.AgregarOrigenTerreno(origenTerrenoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarOrigenTerreno(int OrigenTerrenoId)
        {
            return Json(origenTerrenoBL.BuscarOrigenTerrenoID(OrigenTerrenoId));
        }

        public ActionResult ActualizarOrigenTerreno(int OrigenTerrenoId, string DescOrigenTerreno, string CodigoOrigenTerreno)
        {
            OrigenTerrenoDTO origenTerrenoDTO = new();
            origenTerrenoDTO.OrigenTerrenoId = OrigenTerrenoId;
            origenTerrenoDTO.DescOrigenTerreno = DescOrigenTerreno;
            origenTerrenoDTO.CodigoOrigenTerreno = CodigoOrigenTerreno;
            origenTerrenoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = origenTerrenoBL.ActualizarOrigenTerreno(origenTerrenoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarOrigenTerreno(int OrigenTerrenoId)
        {
            string mensaje = "";

            if (origenTerrenoBL.EliminarOrigenTerreno(OrigenTerrenoId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
