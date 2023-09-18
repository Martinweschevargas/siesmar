using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class TipoVehiculoTransporteController : Controller
    {
        readonly TipoVehiculoTransporteDAO tipoVehiculoTransporteBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoVehiculoTransporteDTO> listaTipoVehiculoTransportes = tipoVehiculoTransporteBL.ObtenerTipoVehiculoTransportes();
            return Json(new { data = listaTipoVehiculoTransportes });
        }

        public ActionResult InsertarTipoVehiculoTransporte(string DescTipoVehiculoTransporte, string CodigoTipoVehiculoTransporte)
        {
            TipoVehiculoTransporteDTO tipoVehiculoTransporteDTO = new();
            tipoVehiculoTransporteDTO.DescTipoVehiculoTransporte = DescTipoVehiculoTransporte;
            tipoVehiculoTransporteDTO.CodigoTipoVehiculoTransporte = CodigoTipoVehiculoTransporte;
            tipoVehiculoTransporteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoVehiculoTransporteBL.AgregarTipoVehiculoTransporte(tipoVehiculoTransporteDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoVehiculoTransporte(int TipoVehiculoTransporteId)
        {
            return Json(tipoVehiculoTransporteBL.BuscarTipoVehiculoTransporteID(TipoVehiculoTransporteId));
        }

        public ActionResult ActualizarTipoVehiculoTransporte(int TipoVehiculoTransporteId, string DescTipoVehiculoTransporte, string CodigoTipoVehiculoTransporte)
        {
            TipoVehiculoTransporteDTO tipoVehiculoTransporteDTO = new();
            tipoVehiculoTransporteDTO.TipoVehiculoTransporteId = TipoVehiculoTransporteId;
            tipoVehiculoTransporteDTO.DescTipoVehiculoTransporte = DescTipoVehiculoTransporte;
            tipoVehiculoTransporteDTO.CodigoTipoVehiculoTransporte = CodigoTipoVehiculoTransporte;
            tipoVehiculoTransporteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoVehiculoTransporteBL.ActualizarTipoVehiculoTransporte(tipoVehiculoTransporteDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoVehiculoTransporte(int TipoVehiculoTransporteId)
        {
            TipoVehiculoTransporteDTO tipoVehiculoTransporteDTO = new();
            tipoVehiculoTransporteDTO.TipoVehiculoTransporteId = TipoVehiculoTransporteId;
            tipoVehiculoTransporteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoVehiculoTransporteBL.EliminarTipoVehiculoTransporte(tipoVehiculoTransporteDTO);

            return Content(IND_OPERACION);
        }
    }
}
