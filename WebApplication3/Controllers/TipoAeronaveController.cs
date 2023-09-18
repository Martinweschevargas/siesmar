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
    public class TipoAeronaveController : Controller
    {
        readonly TipoAeronaveDAO tipoAeronaveBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Aeronaves", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoAeronaveDTO> listaTipoAeronaves = tipoAeronaveBL.ObtenerTipoAeronaves();
            return Json(new { data = listaTipoAeronaves });
        }

        public ActionResult InsertarTipoAeronave(string DescTipoAeronave, string CodigoTipoAeronave)
        {
            TipoAeronaveDTO tipoAeronaveDTO = new();
            tipoAeronaveDTO.DescTipoAeronave = DescTipoAeronave;
            tipoAeronaveDTO.CodigoTipoAeronave = CodigoTipoAeronave;
            tipoAeronaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoAeronaveBL.AgregarTipoAeronave(tipoAeronaveDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoAeronave(int TipoAeronaveId)
        {
            return Json(tipoAeronaveBL.BuscarTipoAeronaveID(TipoAeronaveId));
        }

        public ActionResult ActualizarTipoAeronave(int TipoAeronaveId, string DescTipoAeronave, string CodigoTipoAeronave)
        {
            TipoAeronaveDTO tipoAeronaveDTO = new();
            tipoAeronaveDTO.TipoAeronaveId = TipoAeronaveId;
            tipoAeronaveDTO.DescTipoAeronave = DescTipoAeronave;
            tipoAeronaveDTO.CodigoTipoAeronave = CodigoTipoAeronave;
            tipoAeronaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoAeronaveBL.ActualizarTipoAeronave(tipoAeronaveDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoAeronave(int TipoAeronaveId)
        {
            TipoAeronaveDTO tipoAeronaveDTO = new();
            tipoAeronaveDTO.TipoAeronaveId = TipoAeronaveId;
            tipoAeronaveDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoAeronaveBL.EliminarTipoAeronave(tipoAeronaveDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
