using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class FuenteFinanciamientoController : Controller
    {
        readonly FuenteFinanciamientoDAO fuenteFinanciamientoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "FuenteFinanciamiento", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<FuenteFinanciamientoDTO> listaFuenteFinanciamientos = fuenteFinanciamientoBL.ObtenerFuenteFinanciamientos();
            return Json(new { data = listaFuenteFinanciamientos });
        }

        public ActionResult InsertarFuenteFinanciamiento(string DescFuenteFinanciamiento, string CodigoFuenteFinanciamiento)
        {
            FuenteFinanciamientoDTO fuenteFinanciamientoDTO = new();
            fuenteFinanciamientoDTO.DescFuenteFinanciamiento = DescFuenteFinanciamiento;
            fuenteFinanciamientoDTO.CodigoFuenteFinanciamiento = CodigoFuenteFinanciamiento;
            fuenteFinanciamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = fuenteFinanciamientoBL.AgregarFuenteFinanciamiento(fuenteFinanciamientoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarFuenteFinanciamiento(int FuenteFinanciamientoId)
        {
            return Json(fuenteFinanciamientoBL.BuscarFuenteFinanciamientoID(FuenteFinanciamientoId));
        }

        public ActionResult ActualizarFuenteFinanciamiento(int FuenteFinanciamientoId, string DescFuenteFinanciamiento, string CodigoFuenteFinanciamiento)
        {
            FuenteFinanciamientoDTO fuenteFinanciamientoDTO = new();
            fuenteFinanciamientoDTO.FuenteFinanciamientoId = FuenteFinanciamientoId;
            fuenteFinanciamientoDTO.DescFuenteFinanciamiento = DescFuenteFinanciamiento;
            fuenteFinanciamientoDTO.CodigoFuenteFinanciamiento = CodigoFuenteFinanciamiento;
            fuenteFinanciamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = fuenteFinanciamientoBL.ActualizarFuenteFinanciamiento(fuenteFinanciamientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarFuenteFinanciamiento(int FuenteFinanciamientoId)
        {
            FuenteFinanciamientoDTO fuenteFinanciamientoDTO = new();
            fuenteFinanciamientoDTO.FuenteFinanciamientoId = FuenteFinanciamientoId;
            fuenteFinanciamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = fuenteFinanciamientoBL.EliminarFuenteFinanciamiento(fuenteFinanciamientoDTO);

            return Content(IND_OPERACION);
        }
    }
}
