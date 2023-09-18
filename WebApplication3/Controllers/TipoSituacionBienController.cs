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
    public class TipoSituacionBienController : Controller
    {
        readonly TipoSituacionBienDAO tipoSituacionBienBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Situaciones Bien", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoSituacionBienDTO> listaTipoSituacionBiens = tipoSituacionBienBL.ObtenerTipoSituacionBiens();
            return Json(new { data = listaTipoSituacionBiens });
        }

        public ActionResult InsertarTipoSituacionBien(string DescTipoSituacionBien, string CodigoTipoSituacionBien)
        {
            TipoSituacionBienDTO tipoSituacionBienDTO = new();
            tipoSituacionBienDTO.DescTipoSituacionBien = DescTipoSituacionBien;
            tipoSituacionBienDTO.CodigoTipoSituacionBien = CodigoTipoSituacionBien;
            tipoSituacionBienDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoSituacionBienBL.AgregarTipoSituacionBien(tipoSituacionBienDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoSituacionBien(int TipoSituacionBienId)
        {
            return Json(tipoSituacionBienBL.BuscarTipoSituacionBienID(TipoSituacionBienId));
        }

        public ActionResult ActualizarTipoSituacionBien(int TipoSituacionBienId, string DescTipoSituacionBien, string CodigoTipoSituacionBien)
        {
            TipoSituacionBienDTO tipoSituacionBienDTO = new();
            tipoSituacionBienDTO.TipoSituacionBienId = TipoSituacionBienId;
            tipoSituacionBienDTO.DescTipoSituacionBien = DescTipoSituacionBien;
            tipoSituacionBienDTO.CodigoTipoSituacionBien = CodigoTipoSituacionBien;
            tipoSituacionBienDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoSituacionBienBL.ActualizarTipoSituacionBien(tipoSituacionBienDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoSituacionBien(int TipoSituacionBienId)
        {
            TipoSituacionBienDTO tipoSituacionBienDTO = new();
            tipoSituacionBienDTO.TipoSituacionBienId = TipoSituacionBienId;
            tipoSituacionBienDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoSituacionBienBL.EliminarTipoSituacionBien(tipoSituacionBienDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
