using Marina.Siesmar.AccesoDatos.Seguridad;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace Marina.Siesmar.Presentacion.Controllers
{
    public class PeriodoController : Controller
    {
        readonly PeriodoDAO periodoBL = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargarDatos()
        {
            List<PeriodoDTO> listaPeriodos = periodoBL.ObtenerPeriodos();
            return Json(new { data = listaPeriodos });
        }

        public ActionResult InsertarPeriodo(string Nombre)
        {
            PeriodoDTO periodoDTO = new();

            periodoDTO.Nombre = Nombre;
            periodoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = periodoBL.AgregarPeriodo(periodoDTO);
            return Content(IND_OPERACION);
        }
        public ActionResult MostrarPeriodo(int PeriodoId)
        {
            return Json(periodoBL.BuscarPeriodoID(PeriodoId));
        }


        public ActionResult ActualizarPeriodo(int PeriodoId, string Nombre)
        {

            PeriodoDTO periodoDTO = new();
            periodoDTO.PeriodoId = PeriodoId;
            periodoDTO.Nombre = Nombre;
            periodoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = periodoBL.ActualizarPeriodo(periodoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPeriodo(int PeriodoId)
        {
            string mensaje = "";

            if (periodoBL.EliminarPeriodo(PeriodoId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

    }

}
