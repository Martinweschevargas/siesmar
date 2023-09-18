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
    public class ModeloEquipoComunicacionController : Controller
    {
        readonly ModeloEquipoComunicacionDAO modeloEquipoComunicacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Modelos Equipos Comunicaciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ModeloEquipoComunicacionDTO> listaModeloEquipoComunicacions = modeloEquipoComunicacionBL.ObtenerModeloEquipoComunicacions();
            return Json(new { data = listaModeloEquipoComunicacions });
        }

        public ActionResult InsertarModeloEquipoComunicacion(string DescModeloEquipoComunicacion, string CodigoModeloEquipoComunicacion)
        {
            ModeloEquipoComunicacionDTO modeloEquipoComunicacionDTO = new();
            modeloEquipoComunicacionDTO.DescModeloEquipoComunicacion = DescModeloEquipoComunicacion;
            modeloEquipoComunicacionDTO.CodigoModeloEquipoComunicacion = CodigoModeloEquipoComunicacion;
            modeloEquipoComunicacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = modeloEquipoComunicacionBL.AgregarModeloEquipoComunicacion(modeloEquipoComunicacionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarModeloEquipoComunicacion(int ModeloEquipoComunicacionId)
        {
            return Json(modeloEquipoComunicacionBL.BuscarModeloEquipoComunicacionID(ModeloEquipoComunicacionId));
        }

        public ActionResult ActualizarModeloEquipoComunicacion(int ModeloEquipoComunicacionId, string DescModeloEquipoComunicacion, string CodigoModeloEquipoComunicacion)
        {
            ModeloEquipoComunicacionDTO modeloEquipoComunicacionDTO = new();
            modeloEquipoComunicacionDTO.ModeloEquipoComunicacionId = ModeloEquipoComunicacionId;
            modeloEquipoComunicacionDTO.DescModeloEquipoComunicacion = DescModeloEquipoComunicacion;
            modeloEquipoComunicacionDTO.CodigoModeloEquipoComunicacion = CodigoModeloEquipoComunicacion;
            modeloEquipoComunicacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = modeloEquipoComunicacionBL.ActualizarModeloEquipoComunicacion(modeloEquipoComunicacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarModeloEquipoComunicacion(int ModeloEquipoComunicacionId)
        {
            string mensaje = "";

            if (modeloEquipoComunicacionBL.EliminarModeloEquipoComunicacion(ModeloEquipoComunicacionId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
