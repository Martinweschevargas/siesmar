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
    public class ValorReferencialController : Controller
    {
        readonly ValorReferencialDAO valorReferencialBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Valores Referenciales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ValorReferencialDTO> listaValorReferencials = valorReferencialBL.ObtenerValorReferencials();
            return Json(new { data = listaValorReferencials });
        }

        public ActionResult InsertarValorReferencial(string DescValorReferencial, string CodigoValorReferencial)
        {
            ValorReferencialDTO valorReferencialDTO = new();
            valorReferencialDTO.DescValorReferencial = DescValorReferencial;
            valorReferencialDTO.CodigoValorReferencial = CodigoValorReferencial;
            valorReferencialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = valorReferencialBL.AgregarValorReferencial(valorReferencialDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarValorReferencial(int ValorReferencialId)
        {
            return Json(valorReferencialBL.BuscarValorReferencialID(ValorReferencialId));
        }

        public ActionResult ActualizarValorReferencial(int ValorReferencialId, string DescValorReferencial, string CodigoValorReferencial)
        {
            ValorReferencialDTO valorReferencialDTO = new();
            valorReferencialDTO.ValorReferencialId = ValorReferencialId;
            valorReferencialDTO.DescValorReferencial = DescValorReferencial;
            valorReferencialDTO.CodigoValorReferencial = CodigoValorReferencial;
            valorReferencialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = valorReferencialBL.ActualizarValorReferencial(valorReferencialDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarValorReferencial(int ValorReferencialId)
        {
            ValorReferencialDTO valorReferencialDTO = new();
            valorReferencialDTO.ValorReferencialId = ValorReferencialId;
            valorReferencialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (valorReferencialBL.EliminarValorReferencial(valorReferencialDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
