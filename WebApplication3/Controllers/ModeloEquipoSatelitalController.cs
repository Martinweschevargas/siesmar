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
    public class ModeloEquipoSatelitalController : Controller
    {
        readonly ModeloEquipoSatelitalDAO modeloEquipoSatelitalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Modelos Equipos Satelitales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ModeloEquipoSatelitalDTO> listaModeloEquipoSatelitals = modeloEquipoSatelitalBL.ObtenerModeloEquipoSatelitals();
            return Json(new { data = listaModeloEquipoSatelitals });
        }

        public ActionResult InsertarModeloEquipoSatelital(string DescModeloEquipoSatelital, string CodigoModeloEquipoSatelital)
        {
            ModeloEquipoSatelitalDTO modeloEquipoSatelitalDTO = new();
            modeloEquipoSatelitalDTO.DescModeloEquipoSatelital = DescModeloEquipoSatelital;
            modeloEquipoSatelitalDTO.CodigoModeloEquipoSatelital = CodigoModeloEquipoSatelital;
            modeloEquipoSatelitalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = modeloEquipoSatelitalBL.AgregarModeloEquipoSatelital(modeloEquipoSatelitalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarModeloEquipoSatelital(int ModeloEquipoSatelitalId)
        {
            return Json(modeloEquipoSatelitalBL.BuscarModeloEquipoSatelitalID(ModeloEquipoSatelitalId));
        }

        public ActionResult ActualizarModeloEquipoSatelital(int ModeloEquipoSatelitalId, string DescModeloEquipoSatelital, string CodigoModeloEquipoSatelital)
        {
            ModeloEquipoSatelitalDTO modeloEquipoSatelitalDTO = new();
            modeloEquipoSatelitalDTO.ModeloEquipoSatelitalId = ModeloEquipoSatelitalId;
            modeloEquipoSatelitalDTO.DescModeloEquipoSatelital = DescModeloEquipoSatelital;
            modeloEquipoSatelitalDTO.CodigoModeloEquipoSatelital = CodigoModeloEquipoSatelital;
            modeloEquipoSatelitalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = modeloEquipoSatelitalBL.ActualizarModeloEquipoSatelital(modeloEquipoSatelitalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarModeloEquipoSatelital(int ModeloEquipoSatelitalId)
        {
            string mensaje = "";

            if (modeloEquipoSatelitalBL.EliminarModeloEquipoSatelital(ModeloEquipoSatelitalId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
