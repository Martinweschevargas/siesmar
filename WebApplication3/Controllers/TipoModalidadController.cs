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
    public class TipoModalidadController : Controller
    {
        readonly TipoModalidadDAO tipoModalidadBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Modalidades", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoModalidadDTO> listaTipoModalidads = tipoModalidadBL.ObtenerTipoModalidads();
            return Json(new { data = listaTipoModalidads });
        }

        public ActionResult InsertarTipoModalidad(string DescTipoModalidad, string CodigoTipoModalidad)
        {
            TipoModalidadDTO tipoModalidadDTO = new();
            tipoModalidadDTO.DescTipoModalidad = DescTipoModalidad;
            tipoModalidadDTO.CodigoTipoModalidad = CodigoTipoModalidad;
            tipoModalidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoModalidadBL.AgregarTipoModalidad(tipoModalidadDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoModalidad(int TipoModalidadId)
        {
            return Json(tipoModalidadBL.BuscarTipoModalidadID(TipoModalidadId));
        }

        public ActionResult ActualizarTipoModalidad(int TipoModalidadId, string DescTipoModalidad, string CodigoTipoModalidad)
        {
            TipoModalidadDTO tipoModalidadDTO = new();
            tipoModalidadDTO.TipoModalidadId = TipoModalidadId;
            tipoModalidadDTO.DescTipoModalidad = DescTipoModalidad;
            tipoModalidadDTO.CodigoTipoModalidad = CodigoTipoModalidad;
            tipoModalidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoModalidadBL.ActualizarTipoModalidad(tipoModalidadDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoModalidad(int TipoModalidadId)
        {
            TipoModalidadDTO tipoModalidadDTO = new();
            tipoModalidadDTO.TipoModalidadId = TipoModalidadId;
            tipoModalidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoModalidadBL.EliminarTipoModalidad(tipoModalidadDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
