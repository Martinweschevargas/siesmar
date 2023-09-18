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
    public class TipoSeguridadController : Controller
    {
        readonly TipoSeguridadDAO tipoSeguridadBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Seguridad", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoSeguridadDTO> listaTipoSeguridads = tipoSeguridadBL.ObtenerTipoSeguridads();
            return Json(new { data = listaTipoSeguridads });
        }

        public ActionResult InsertarTipoSeguridad(string DescTipoSeguridad, string CodigoTipoSeguridad)
        {
            TipoSeguridadDTO tipoSeguridadDTO = new();
            tipoSeguridadDTO.DescTipoSeguridad = DescTipoSeguridad;
            tipoSeguridadDTO.CodigoTipoSeguridad = CodigoTipoSeguridad;
            tipoSeguridadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoSeguridadBL.AgregarTipoSeguridad(tipoSeguridadDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoSeguridad(int TipoSeguridadId)
        {
            return Json(tipoSeguridadBL.BuscarTipoSeguridadID(TipoSeguridadId));
        }

        public ActionResult ActualizarTipoSeguridad(int TipoSeguridadId, string DescTipoSeguridad, string CodigoTipoSeguridad)
        {
            TipoSeguridadDTO tipoSeguridadDTO = new();
            tipoSeguridadDTO.TipoSeguridadId = TipoSeguridadId;
            tipoSeguridadDTO.DescTipoSeguridad = DescTipoSeguridad;
            tipoSeguridadDTO.CodigoTipoSeguridad = CodigoTipoSeguridad;
            tipoSeguridadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoSeguridadBL.ActualizarTipoSeguridad(tipoSeguridadDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoSeguridad(int TipoSeguridadId)
        {
            TipoSeguridadDTO tipoSeguridadDTO = new();
            tipoSeguridadDTO.TipoSeguridadId = TipoSeguridadId;
            tipoSeguridadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoSeguridadBL.EliminarTipoSeguridad(tipoSeguridadDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
