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
    public class DptoMaterialAcuaticoController : Controller
    {
        readonly ILogger<DptoMaterialAcuaticoController> _logger;

        public DptoMaterialAcuaticoController(ILogger<DptoMaterialAcuaticoController> logger)
        {
            _logger = logger;
        }

        readonly DptoMaterialAcuaticoDAO DptoMaterialAcuaticoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Dptos Materiales Acuaticos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<DptoMaterialAcuaticoDTO> listaDptoMaterialAcuaticos = DptoMaterialAcuaticoBL.ObtenerDptoMaterialAcuaticos();
            return Json(new { data = listaDptoMaterialAcuaticos });
        }

        public ActionResult InsertarDptoMaterialAcuatico(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                DptoMaterialAcuaticoDTO DptoMaterialAcuaticoDTO = new();
                DptoMaterialAcuaticoDTO.DescDptoMaterialAcuatico = Descripcion;
                DptoMaterialAcuaticoDTO.CodigoDptoMaterialAcuatico = Codigo;
                DptoMaterialAcuaticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = DptoMaterialAcuaticoBL.AgregarDptoMaterialAcuatico(DptoMaterialAcuaticoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarDptoMaterialAcuatico(int DptoMaterialAcuaticoId)
        {
            return Json(DptoMaterialAcuaticoBL.BuscarDptoMaterialAcuaticoID(DptoMaterialAcuaticoId));
        }

        public ActionResult ActualizarDptoMaterialAcuatico(int DptoMaterialAcuaticoId, string Codigo, string Descripcion)
        {
            DptoMaterialAcuaticoDTO DptoMaterialAcuaticoDTO = new();
            DptoMaterialAcuaticoDTO.DptoMaterialAcuaticoId = DptoMaterialAcuaticoId;
            DptoMaterialAcuaticoDTO.DescDptoMaterialAcuatico = Descripcion;
            DptoMaterialAcuaticoDTO.CodigoDptoMaterialAcuatico = Codigo;
            DptoMaterialAcuaticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = DptoMaterialAcuaticoBL.ActualizarDptoMaterialAcuatico(DptoMaterialAcuaticoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarDptoMaterialAcuatico(int DptoMaterialAcuaticoId)
        {
            DptoMaterialAcuaticoDTO DptoMaterialAcuaticoDTO = new();
            DptoMaterialAcuaticoDTO.DptoMaterialAcuaticoId = DptoMaterialAcuaticoId;
            DptoMaterialAcuaticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = DptoMaterialAcuaticoBL.EliminarDptoMaterialAcuatico(DptoMaterialAcuaticoDTO);

            return Content(IND_OPERACION);
        }
    }
}
