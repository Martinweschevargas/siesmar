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
    public class TipoCargaController : Controller
    {
        readonly ILogger<TipoCargaController> _logger;

        public TipoCargaController(ILogger<TipoCargaController> logger)
        {
            _logger = logger;
        }

        readonly TipoCargaDAO TipoCargaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Cargas", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoCargaDTO> listaTipoCargas = TipoCargaBL.ObtenerTipoCargas();
            return Json(new { data = listaTipoCargas });
        }

        public ActionResult InsertarTipoCarga(string Descripcion, string Codigo)
        {
            var IND_OPERACION="";
            try
            {
                TipoCargaDTO TipoCargaDTO = new();
                TipoCargaDTO.DescTipoCarga = Descripcion;
                TipoCargaDTO.CodigoTipoCarga = Codigo;
                TipoCargaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = TipoCargaBL.AgregarTipoCarga(TipoCargaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoCarga(int TipoCargaId)
        {
            return Json(TipoCargaBL.BuscarTipoCargaID(TipoCargaId));
        }

        public ActionResult ActualizarTipoCarga(int TipoCargaId, string Descripcion, string Codigo)
        {
            TipoCargaDTO TipoCargaDTO = new();
            TipoCargaDTO.TipoCargaId = TipoCargaId;
            TipoCargaDTO.DescTipoCarga = Descripcion;
            TipoCargaDTO.CodigoTipoCarga = Codigo;
            TipoCargaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoCargaBL.ActualizarTipoCarga(TipoCargaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoCarga(int TipoCargaId)
        {
            TipoCargaDTO TipoCargaDTO = new();
            TipoCargaDTO.TipoCargaId = TipoCargaId;
            TipoCargaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = TipoCargaBL.EliminarTipoCarga(TipoCargaDTO);

            return Content(IND_OPERACION);
        }
    }
}
