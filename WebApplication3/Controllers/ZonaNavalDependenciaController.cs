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
    public class ZonaNavalDependenciaController : Controller
    {
        readonly ZonaNavalDependenciaDAO zonaNavalDependenciaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Zonas Navales Dependencias", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
          
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ZonaNavalDependenciaDTO> listaZonaNavalDependencias = zonaNavalDependenciaBL.ObtenerZonaNavalDependencias();
            return Json(new { data = listaZonaNavalDependencias });
        }

        public ActionResult InsertarZonaNavalDependencia(string DescZonaNavalDependencia, string CodigoZonaNavalDependencia)
        {
            ZonaNavalDependenciaDTO zonaNavalDependenciaDTO = new();
            zonaNavalDependenciaDTO.DescZonaNavalDependencia = DescZonaNavalDependencia;
            zonaNavalDependenciaDTO.CodigoZonaNavalDependencia = CodigoZonaNavalDependencia;
            zonaNavalDependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = zonaNavalDependenciaBL.AgregarZonaNavalDependencia(zonaNavalDependenciaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarZonaNavalDependencia(int ZonaNavalDependenciaId)
        {
            return Json(zonaNavalDependenciaBL.BuscarZonaNavalDependenciaID(ZonaNavalDependenciaId));
        }

        public ActionResult ActualizarZonaNavalDependencia(int ZonaNavalDependenciaId, string DescZonaNavalDependencia, string CodigoZonaNavalDependencia)
        {
            ZonaNavalDependenciaDTO zonaNavalDependenciaDTO = new();
            zonaNavalDependenciaDTO.ZonaNavalDependenciaId = ZonaNavalDependenciaId;
            zonaNavalDependenciaDTO.DescZonaNavalDependencia = DescZonaNavalDependencia;
            zonaNavalDependenciaDTO.CodigoZonaNavalDependencia = CodigoZonaNavalDependencia;
            zonaNavalDependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = zonaNavalDependenciaBL.ActualizarZonaNavalDependencia(zonaNavalDependenciaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarZonaNavalDependencia(int ZonaNavalDependenciaId)
        {
            ZonaNavalDependenciaDTO zonaNavalDependenciaDTO = new();
            zonaNavalDependenciaDTO.ZonaNavalDependenciaId = ZonaNavalDependenciaId;
            zonaNavalDependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (zonaNavalDependenciaBL.EliminarZonaNavalDependencia(zonaNavalDependenciaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
