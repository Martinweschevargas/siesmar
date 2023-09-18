using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class FaseInversionController : Controller
    {
        readonly ILogger<FaseInversionController> _logger;

        public FaseInversionController(ILogger<FaseInversionController> logger)
        {
            _logger = logger;
        }

        readonly FaseInversionDAO faseInversionBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Fases Inversiones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<FaseInversionDTO> listaFaseInversions = faseInversionBL.ObtenerFaseInversions();
            return Json(new { data = listaFaseInversions });
        }

        public ActionResult InsertarFaseInversion(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                FaseInversionDTO faseInversionDTO = new();
                faseInversionDTO.DescFaseInversion = Descripcion;
                faseInversionDTO.CodigoFaseInversion = Codigo;
                faseInversionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = faseInversionBL.AgregarFaseInversion(faseInversionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarFaseInversion(int FaseInversionId)
        {
            return Json(faseInversionBL.BuscarFaseInversionID(FaseInversionId));
        }

        public ActionResult ActualizarFaseInversion(int FaseInversionId, string Codigo, string Descripcion)
        {
            FaseInversionDTO faseInversionDTO = new();
            faseInversionDTO.FaseInversionId = FaseInversionId;
            faseInversionDTO.DescFaseInversion = Descripcion;
            faseInversionDTO.CodigoFaseInversion = Codigo;
            faseInversionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            var IND_OPERACION = faseInversionBL.ActualizarFaseInversion(faseInversionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarFaseInversion(int FaseInversionId)
        {
            FaseInversionDTO faseInversionDTO = new();
            faseInversionDTO.FaseInversionId = FaseInversionId;
            faseInversionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = faseInversionBL.EliminarFaseInversion(faseInversionDTO);

            return Content(IND_OPERACION);
        }
    }
}
