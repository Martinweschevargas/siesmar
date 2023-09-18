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
    public class SectorExtraInstitucionalController : Controller
    {
        readonly ILogger<SectorExtraInstitucionalController> _logger;

        public SectorExtraInstitucionalController(ILogger<SectorExtraInstitucionalController> logger)
        {
            _logger = logger;
        }

        readonly SectorExtraInstitucionalDAO SectorExtraInstitucionalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Sectores Extra Institucionales ", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SectorExtraInstitucionalDTO> listaSectorExtraInstitucionals = SectorExtraInstitucionalBL.ObtenerSectorExtraInstitucionals();
            return Json(new { data = listaSectorExtraInstitucionals });
        }

        public ActionResult InsertarSectorExtraInstitucional(string Descripcion, string Codigo)
        {
            var IND_OPERACION="";
            try
            {
                SectorExtraInstitucionalDTO SectorExtraInstitucionalDTO = new();
                SectorExtraInstitucionalDTO.DescSectorExtraInstitucional = Descripcion;
                SectorExtraInstitucionalDTO.CodigoSectorExtraInstitucional = Codigo;
                SectorExtraInstitucionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = SectorExtraInstitucionalBL.AgregarSectorExtraInstitucional(SectorExtraInstitucionalDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSectorExtraInstitucional(int SectorExtraInstitucionalId)
        {
            return Json(SectorExtraInstitucionalBL.BuscarSectorExtraInstitucionalID(SectorExtraInstitucionalId));
        }

        public ActionResult ActualizarSectorExtraInstitucional(int SectorExtraInstitucionalId, string Descripcion, string Codigo)
        {
            SectorExtraInstitucionalDTO SectorExtraInstitucionalDTO = new();
            SectorExtraInstitucionalDTO.SectorExtraInstitucionalId = SectorExtraInstitucionalId;
            SectorExtraInstitucionalDTO.DescSectorExtraInstitucional = Descripcion;
            SectorExtraInstitucionalDTO.CodigoSectorExtraInstitucional = Codigo;
            SectorExtraInstitucionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = SectorExtraInstitucionalBL.ActualizarSectorExtraInstitucional(SectorExtraInstitucionalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSectorExtraInstitucional(int SectorExtraInstitucionalId)
        {
            SectorExtraInstitucionalDTO SectorExtraInstitucionalDTO = new();
            SectorExtraInstitucionalDTO.SectorExtraInstitucionalId = SectorExtraInstitucionalId;
            SectorExtraInstitucionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = SectorExtraInstitucionalBL.EliminarSectorExtraInstitucional(SectorExtraInstitucionalDTO);

            return Content(IND_OPERACION);
        }
    }
}
