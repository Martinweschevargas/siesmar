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
    public class GrupoCodificacionMaterialController : Controller
    {
        readonly GrupoCodificacionMaterialDAO grupoCodificacionMaterialBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "GrupoCodificacionMaterial", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<GrupoCodificacionMaterialDTO> listaGrupoCodificacionMaterials = grupoCodificacionMaterialBL.ObtenerGrupoCodificacionMaterials();
            return Json(new { data = listaGrupoCodificacionMaterials });
        }

        public ActionResult InsertarGrupoCodificacionMaterial(string DescGrupoCodificacionMaterial, string CodigoGrupoCodificacionMaterial)
        {
            GrupoCodificacionMaterialDTO grupoCodificacionMaterialDTO = new();
            grupoCodificacionMaterialDTO.DescGrupoCodificacionMaterial = DescGrupoCodificacionMaterial;
            grupoCodificacionMaterialDTO.CodigoGrupoCodificacionMaterial = CodigoGrupoCodificacionMaterial;
            grupoCodificacionMaterialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = grupoCodificacionMaterialBL.AgregarGrupoCodificacionMaterial(grupoCodificacionMaterialDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarGrupoCodificacionMaterial(int GrupoCodificacionMaterialId)
        {
            return Json(grupoCodificacionMaterialBL.BuscarGrupoCodificacionMaterialID(GrupoCodificacionMaterialId));
        }

        public ActionResult ActualizarGrupoCodificacionMaterial(int GrupoCodificacionMaterialId, string DescGrupoCodificacionMaterial, string CodigoGrupoCodificacionMaterial)
        {
            GrupoCodificacionMaterialDTO grupoCodificacionMaterialDTO = new();
            grupoCodificacionMaterialDTO.GrupoCodificacionMaterialId = GrupoCodificacionMaterialId;
            grupoCodificacionMaterialDTO.DescGrupoCodificacionMaterial = DescGrupoCodificacionMaterial;
            grupoCodificacionMaterialDTO.CodigoGrupoCodificacionMaterial = CodigoGrupoCodificacionMaterial;
            grupoCodificacionMaterialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = grupoCodificacionMaterialBL.ActualizarGrupoCodificacionMaterial(grupoCodificacionMaterialDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarGrupoCodificacionMaterial(int GrupoCodificacionMaterialId)
        {
            GrupoCodificacionMaterialDTO grupoCodificacionMaterialDTO = new();
            grupoCodificacionMaterialDTO.GrupoCodificacionMaterialId = GrupoCodificacionMaterialId;
            grupoCodificacionMaterialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (grupoCodificacionMaterialBL.EliminarGrupoCodificacionMaterial(grupoCodificacionMaterialDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
