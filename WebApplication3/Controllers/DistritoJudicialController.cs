using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DistritoJudicialController : Controller
    {
        readonly DistritoJudicialDAO distritoJudicialBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DistritoJudicialDTO> listaDistritoJudiciales = distritoJudicialBL.ObtenerDistritoJudiciales();
            return Json(new { data = listaDistritoJudiciales });
        }

        public ActionResult InsertarDistritoJudicial(string DescDistritoJudicial, string CodigoDistritoJudicial)
        {
            DistritoJudicialDTO distritoJudicialDTO = new();
            distritoJudicialDTO.DescDistritoJudicial = DescDistritoJudicial;
            distritoJudicialDTO.CodigoDistritoJudicial = CodigoDistritoJudicial;
            distritoJudicialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = distritoJudicialBL.AgregarDistritoJudicial(distritoJudicialDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarBuscarDistritoJudicial(int DistritoJudicialId)
        {
            return Json(distritoJudicialBL.BuscarDistritoJudicialID(DistritoJudicialId));
        }

        public ActionResult ActualizarDistritoJudicial(int DistritoJudicialId, string DescDistritoJudicial, string CodigoDistritoJudicial)
        {
            DistritoJudicialDTO distritoJudicialDTO = new();
            distritoJudicialDTO.DistritoJudicialId = DistritoJudicialId;
            distritoJudicialDTO.DescDistritoJudicial = DescDistritoJudicial;
            distritoJudicialDTO.CodigoDistritoJudicial = CodigoDistritoJudicial;
            distritoJudicialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = distritoJudicialBL.ActualizarDistritoJudicial(distritoJudicialDTO);
              
            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDistritoJudicial(int DistritoJudicialId)
        {
            string mensaje = "";

            if (distritoJudicialBL.EliminarDistritoJudicial(DistritoJudicialId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
