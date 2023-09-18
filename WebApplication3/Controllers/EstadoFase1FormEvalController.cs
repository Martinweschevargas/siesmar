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
    public class EstadoFase1FormEvalController : Controller
    {
        readonly EstadoFase1FormEvalDAO estadoFase1FormEvalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Estado Fase1 Form Eval", FromController = typeof(HomeController))]

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EstadoFase1FormEvalDTO> listaEstadoFase1FormEvals = estadoFase1FormEvalBL.ObtenerEstadoFase1FormEvals();
            return Json(new { data = listaEstadoFase1FormEvals });
        }

        public ActionResult InsertarEstadoFase1FormEval(string DescEstadoFase1FormEval, string CodigoEstadoFase1FormEval)
        {
            EstadoFase1FormEvalDTO estadoFase1FormEvalDTO = new();
            estadoFase1FormEvalDTO.DescEstadoFase1FormEval = DescEstadoFase1FormEval;
            estadoFase1FormEvalDTO.CodigoEstadoFase1FormEval = CodigoEstadoFase1FormEval;
            estadoFase1FormEvalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = estadoFase1FormEvalBL.AgregarEstadoFase1FormEval(estadoFase1FormEvalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEstadoFase1FormEval(int EstadoFase1FormEvalId)
        {
            return Json(estadoFase1FormEvalBL.BuscarEstadoFase1FormEvalID(EstadoFase1FormEvalId));
        }

        public ActionResult ActualizarEstadoFase1FormEval(int EstadoFase1FormEvalId, string DescEstadoFase1FormEval, string CodigoEstadoFase1FormEval)
        {
            EstadoFase1FormEvalDTO estadoFase1FormEvalDTO = new();
            estadoFase1FormEvalDTO.EstadoFase1FormEvalId = EstadoFase1FormEvalId;
            estadoFase1FormEvalDTO.DescEstadoFase1FormEval = DescEstadoFase1FormEval;
            estadoFase1FormEvalDTO.CodigoEstadoFase1FormEval = CodigoEstadoFase1FormEval;
            estadoFase1FormEvalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = estadoFase1FormEvalBL.ActualizarEstadoFase1FormEval(estadoFase1FormEvalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEstadoFase1FormEval(int EstadoFase1FormEvalId)
        {
            EstadoFase1FormEvalDTO estadoFase1FormEvalDTO = new();
            estadoFase1FormEvalDTO.EstadoFase1FormEvalId = EstadoFase1FormEvalId;
            estadoFase1FormEvalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (estadoFase1FormEvalBL.EliminarEstadoFase1FormEval(estadoFase1FormEvalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
