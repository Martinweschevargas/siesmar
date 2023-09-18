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
    public class MaterialRepBienHistoricoController : Controller
    {
        readonly MaterialRepBienHistoricoDAO materialRepBienHistoricoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "MaterialRepBienHistorico", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MaterialRepBienHistoricoDTO> listaMaterialRepBienHistoricos = materialRepBienHistoricoBL.ObtenerMaterialRepBienHistoricos();
            return Json(new { data = listaMaterialRepBienHistoricos });
        }

        public ActionResult InsertarMaterialRepBienHistorico(string DescMaterialRepBienHistorico, string CodigoMaterialRepBienHistorico)
        {
            MaterialRepBienHistoricoDTO materialRepBienHistoricoDTO = new();
            materialRepBienHistoricoDTO.DescMaterialRepBienHistorico = DescMaterialRepBienHistorico;
            materialRepBienHistoricoDTO.CodigoMaterialRepBienHistorico = CodigoMaterialRepBienHistorico;
            materialRepBienHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = materialRepBienHistoricoBL.AgregarMaterialRepBienHistorico(materialRepBienHistoricoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMaterialRepBienHistorico(int MaterialRepBienHistoricoId)
        {
            return Json(materialRepBienHistoricoBL.BuscarMaterialRepBienHistoricoID(MaterialRepBienHistoricoId));
        }

        public ActionResult ActualizarMaterialRepBienHistorico(int MaterialRepBienHistoricoId, string DescMaterialRepBienHistorico, string CodigoMaterialRepBienHistorico)
        {
            MaterialRepBienHistoricoDTO materialRepBienHistoricoDTO = new();
            materialRepBienHistoricoDTO.MaterialRepBienHistoricoId = MaterialRepBienHistoricoId;
            materialRepBienHistoricoDTO.DescMaterialRepBienHistorico = DescMaterialRepBienHistorico;
            materialRepBienHistoricoDTO.CodigoMaterialRepBienHistorico = CodigoMaterialRepBienHistorico;
            materialRepBienHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = materialRepBienHistoricoBL.ActualizarMaterialRepBienHistorico(materialRepBienHistoricoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMaterialRepBienHistorico(int MaterialRepBienHistoricoId)
        {
            MaterialRepBienHistoricoDTO materialRepBienHistoricoDTO = new();
            materialRepBienHistoricoDTO.MaterialRepBienHistoricoId = MaterialRepBienHistoricoId;
            materialRepBienHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (materialRepBienHistoricoBL.EliminarMaterialRepBienHistorico(materialRepBienHistoricoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
