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
    public class TipoFinanciamientoController : Controller
    {
        readonly TipoFinanciamientoDAO tipoFinanciamientoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Financiamientos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoFinanciamientoDTO> listaTipoFinanciamientos = tipoFinanciamientoBL.ObtenerTipoFinanciamientos();
            return Json(new { data = listaTipoFinanciamientos });
        }

        public ActionResult InsertarTipoFinanciamiento(string DescTipoFinanciamiento, string CodigoTipoFinanciamiento)
        {
            TipoFinanciamientoDTO tipoFinanciamientoDTO = new();
            tipoFinanciamientoDTO.DescTipoFinanciamiento = DescTipoFinanciamiento;
            tipoFinanciamientoDTO.CodigoTipoFinanciamiento = CodigoTipoFinanciamiento;
            tipoFinanciamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoFinanciamientoBL.AgregarTipoFinanciamiento(tipoFinanciamientoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoFinanciamiento(int TipoFinanciamientoId)
        {
            return Json(tipoFinanciamientoBL.BuscarTipoFinanciamientoID(TipoFinanciamientoId));
        }

        public ActionResult ActualizarTipoFinanciamiento(int TipoFinanciamientoId, string DescTipoFinanciamiento, string CodigoTipoFinanciamiento)
        {
            TipoFinanciamientoDTO tipoFinanciamientoDTO = new();
            tipoFinanciamientoDTO.TipoFinanciamientoId = TipoFinanciamientoId;
            tipoFinanciamientoDTO.DescTipoFinanciamiento = DescTipoFinanciamiento;
            tipoFinanciamientoDTO.CodigoTipoFinanciamiento = CodigoTipoFinanciamiento;
            tipoFinanciamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoFinanciamientoBL.ActualizarTipoFinanciamiento(tipoFinanciamientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoFinanciamiento(int TipoFinanciamientoId)
        {
            TipoFinanciamientoDTO tipoFinanciamientoDTO = new();
            tipoFinanciamientoDTO.TipoFinanciamientoId = TipoFinanciamientoId;
            tipoFinanciamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoFinanciamientoBL.EliminarTipoFinanciamiento(tipoFinanciamientoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
