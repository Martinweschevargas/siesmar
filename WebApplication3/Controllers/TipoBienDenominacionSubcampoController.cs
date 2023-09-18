using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using MathNet.Numerics.Distributions;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class TipoBienDenominacionSubcampoController : Controller
    {
        readonly ILogger<TipoBienDenominacionSubcampoController> _logger;

        public TipoBienDenominacionSubcampoController(ILogger<TipoBienDenominacionSubcampoController> logger)
        {
            _logger = logger;
        }

        readonly TipoBienDenominacionSubcampo tipoBienDenominacionSubcampoBL = new();
        TipoBienSubcampo tipoBienSubcampoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Bienes Denominaciones Subcampos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult cargaCombs()
        {
            List<TipoBienSubcampoDTO> tipoBienSubcampoDTO = tipoBienSubcampoBL.ObtenerTipoBienSubcampos();
            return Json(new { data = tipoBienSubcampoDTO });
        }

        public JsonResult CargarDatos()
        {
            List<TipoBienDenominacionSubcampoDTO> listaTipoBienDenominacionSubcampoes = tipoBienDenominacionSubcampoBL.ObtenerTipoBienDenominacionSubcampos();
            return Json(new { data = listaTipoBienDenominacionSubcampoes });
        }

        public ActionResult InsertarTipoBienDenominacionSubcampo(string Descripcion, string Codigo, int TipoBienSubcampoId)
        {
            var IND_OPERACION = "";
            try
            {
                TipoBienDenominacionSubcampoDTO tipoBienDenominacionSubcampoDTO = new();
                tipoBienDenominacionSubcampoDTO.DescTipoBienDenominacionSubcampo = Descripcion;
                tipoBienDenominacionSubcampoDTO.CodigoTipoBienDenominacionSubcampo = Codigo;
                tipoBienDenominacionSubcampoDTO.TipoBienSubcampoId = TipoBienSubcampoId;
                tipoBienDenominacionSubcampoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoBienDenominacionSubcampoBL.AgregarTipoBienDenominacionSubcampo(tipoBienDenominacionSubcampoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoBienDenominacionSubcampo(int TipoBienDenominacionSubcampoId)
        {
            return Json(tipoBienDenominacionSubcampoBL.BuscarTipoBienDenominacionSubcampoID(TipoBienDenominacionSubcampoId));
        }

        public ActionResult ActualizarTipoBienDenominacionSubcampo(int TipoBienDenominacionSubcampoId, string Descripcion, string Codigo, int TipoBienSubcampoId)
        {
            TipoBienDenominacionSubcampoDTO tipoBienDenominacionSubcampoDTO = new();
            tipoBienDenominacionSubcampoDTO.TipoBienDenominacionSubcampoId = TipoBienDenominacionSubcampoId;
            tipoBienDenominacionSubcampoDTO.DescTipoBienDenominacionSubcampo = Descripcion;
            tipoBienDenominacionSubcampoDTO.CodigoTipoBienDenominacionSubcampo = Codigo;
            tipoBienDenominacionSubcampoDTO.TipoBienSubcampoId = TipoBienSubcampoId;
            tipoBienDenominacionSubcampoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoBienDenominacionSubcampoBL.ActualizarTipoBienDenominacionSubcampo(tipoBienDenominacionSubcampoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoBienDenominacionSubcampo(int TipoBienDenominacionSubcampoId)
        {
            TipoBienDenominacionSubcampoDTO tipoBienDenominacionSubcampoDTO = new();
            tipoBienDenominacionSubcampoDTO.TipoBienDenominacionSubcampoId = TipoBienDenominacionSubcampoId;
            tipoBienDenominacionSubcampoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoBienDenominacionSubcampoBL.EliminarTipoBienDenominacionSubcampo(tipoBienDenominacionSubcampoDTO);

            return Content(IND_OPERACION);
        }
    }
}
