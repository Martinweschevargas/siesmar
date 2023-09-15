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
    public class Formula2CalificativoCentacController : Controller
    {
        readonly Formula2CalificativoCentacDAO formula2CalificativoCentacBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Formula2CalificativoCentac", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<Formula2CalificativoCentacDTO> listaFormula2CalificativoCentacs = formula2CalificativoCentacBL.ObtenerFormula2CalificativoCentacs();
            return Json(new { data = listaFormula2CalificativoCentacs });
        }

        public ActionResult InsertarFormula2CalificativoCentac(string DescFormula2CalificativoCentac, string CodigoFormula2CalificativoCentac)
        {
            Formula2CalificativoCentacDTO formula2CalificativoCentacDTO = new();
            formula2CalificativoCentacDTO.DescFormula2CalificativoCentac = DescFormula2CalificativoCentac;
            formula2CalificativoCentacDTO.CodigoFormula2CalificativoCentac = CodigoFormula2CalificativoCentac;
            formula2CalificativoCentacDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = formula2CalificativoCentacBL.AgregarFormula2CalificativoCentac(formula2CalificativoCentacDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarFormula2CalificativoCentac(int Formula2CalificativoCentacId)
        {
            return Json(formula2CalificativoCentacBL.BuscarFormula2CalificativoCentacID(Formula2CalificativoCentacId));
        }

        public ActionResult ActualizarFormula2CalificativoCentac(int Formula2CalificativoCentacId, string DescFormula2CalificativoCentac, string CodigoFormula2CalificativoCentac)
        {
            Formula2CalificativoCentacDTO formula2CalificativoCentacDTO = new();
            formula2CalificativoCentacDTO.Formula2CalificativoCentacId = Formula2CalificativoCentacId;
            formula2CalificativoCentacDTO.DescFormula2CalificativoCentac = DescFormula2CalificativoCentac;
            formula2CalificativoCentacDTO.CodigoFormula2CalificativoCentac = CodigoFormula2CalificativoCentac;
            formula2CalificativoCentacDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = formula2CalificativoCentacBL.ActualizarFormula2CalificativoCentac(formula2CalificativoCentacDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarFormula2CalificativoCentac(int Formula2CalificativoCentacId)
        {
            Formula2CalificativoCentacDTO formula2CalificativoCentacDTO = new();
            formula2CalificativoCentacDTO.Formula2CalificativoCentacId = Formula2CalificativoCentacId;
            formula2CalificativoCentacDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (formula2CalificativoCentacBL.EliminarFormula2CalificativoCentac(formula2CalificativoCentacDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
