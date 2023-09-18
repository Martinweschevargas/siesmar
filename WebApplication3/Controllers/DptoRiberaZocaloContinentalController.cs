using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DptoRiberaZocaloContinentalController : Controller
    {
        readonly DptoRiberaZocaloContinentalDAO dptoRiberaZocaloContinentalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DptoRiberaZocaloContinentalDTO> listaDptoRiberaZocaloContinentals = dptoRiberaZocaloContinentalBL.ObtenerDptoRiberaZocaloContinentals();
            return Json(new { data = listaDptoRiberaZocaloContinentals });
        }

        public ActionResult InsertarDptoRiberaZocaloContinental(string CodigoDptoRiberaZocaloCont, string DescDptoRiberaZocaloCont)
        {
            DptoRiberaZocaloContinentalDTO dptoRiberaZocaloContinentalDTO = new();
            dptoRiberaZocaloContinentalDTO.CodigoDptoRiberaZocaloCont = CodigoDptoRiberaZocaloCont;
            dptoRiberaZocaloContinentalDTO.DescDptoRiberaZocaloCont = DescDptoRiberaZocaloCont;
            dptoRiberaZocaloContinentalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = dptoRiberaZocaloContinentalBL.AgregarDptoRiberaZocaloContinental(dptoRiberaZocaloContinentalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDptoRiberaZocaloContinental(int DptoRiberaZocaloContId)
        {
            return Json(dptoRiberaZocaloContinentalBL.BuscarDptoRiberaZocaloContinentalID(DptoRiberaZocaloContId));
        }

        public ActionResult ActualizarDptoRiberaZocaloContinental(int DptoRiberaZocaloContId, string CodigoDptoRiberaZocaloCont, string DescDptoRiberaZocaloCont)
        {
            DptoRiberaZocaloContinentalDTO dptoRiberaZocaloContinentalDTO = new();
            dptoRiberaZocaloContinentalDTO.DptoRiberaZocaloContId = DptoRiberaZocaloContId;
            dptoRiberaZocaloContinentalDTO.CodigoDptoRiberaZocaloCont = CodigoDptoRiberaZocaloCont;
            dptoRiberaZocaloContinentalDTO.DescDptoRiberaZocaloCont = DescDptoRiberaZocaloCont;
            dptoRiberaZocaloContinentalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = dptoRiberaZocaloContinentalBL.ActualizarDptoRiberaZocaloContinental(dptoRiberaZocaloContinentalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDptoRiberaZocaloContinental(int DptoRiberaZocaloContId)
        {
            DptoRiberaZocaloContinentalDTO dptoRiberaZocaloContinentalDTO = new();
            dptoRiberaZocaloContinentalDTO.DptoRiberaZocaloContId = DptoRiberaZocaloContId;
            dptoRiberaZocaloContinentalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (dptoRiberaZocaloContinentalBL.EliminarDptoRiberaZocaloContinental(dptoRiberaZocaloContinentalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
