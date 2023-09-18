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
    public class FuncionPersonalController : Controller
    {
        readonly FuncionPersonalDAO funcionPersonalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "FuncionPersonal", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<FuncionPersonalDTO> listaFuncionPersonals = funcionPersonalBL.ObtenerFuncionPersonals();
            return Json(new { data = listaFuncionPersonals });
        }

        public ActionResult InsertarFuncionPersonal(string DescFuncionPersonal, string CodigoFuncionPersonal)
        {
            FuncionPersonalDTO funcionPersonalDTO = new();
            funcionPersonalDTO.DescFuncionPersonal = DescFuncionPersonal;
            funcionPersonalDTO.CodigoFuncionPersonal = CodigoFuncionPersonal;
            funcionPersonalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = funcionPersonalBL.AgregarFuncionPersonal(funcionPersonalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarFuncionPersonal(int FuncionPersonalId)
        {
            return Json(funcionPersonalBL.BuscarFuncionPersonalID(FuncionPersonalId));
        }

        public ActionResult ActualizarFuncionPersonal(int FuncionPersonalId, string DescFuncionPersonal, string CodigoFuncionPersonal)
        {
            FuncionPersonalDTO funcionPersonalDTO = new();
            funcionPersonalDTO.FuncionPersonalId = FuncionPersonalId;
            funcionPersonalDTO.DescFuncionPersonal = DescFuncionPersonal;
            funcionPersonalDTO.CodigoFuncionPersonal = CodigoFuncionPersonal;
            funcionPersonalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = funcionPersonalBL.ActualizarFuncionPersonal(funcionPersonalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarFuncionPersonal(int FuncionPersonalId)
        {
            FuncionPersonalDTO funcionPersonalDTO = new();
            funcionPersonalDTO.FuncionPersonalId = FuncionPersonalId;
            funcionPersonalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (funcionPersonalBL.EliminarFuncionPersonal(funcionPersonalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
