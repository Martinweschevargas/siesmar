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
    public class TipoServicioSastreriaController : Controller
    {
        readonly ILogger<TipoServicioSastreriaController> _logger;

        public TipoServicioSastreriaController(ILogger<TipoServicioSastreriaController> logger)
        {
            _logger = logger;
        }

        readonly TipoServicioSastreriaDAO tipoServicioSastreriaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Servicios Sastrerías", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoServicioSastreriaDTO> listaTipoServicioSastrerias = tipoServicioSastreriaBL.ObtenerTipoServicioSastrerias();
            return Json(new { data = listaTipoServicioSastrerias });
        }

        public ActionResult InsertarTipoServicioSastreria(string DescServicioSastreria)
        {
            var IND_OPERACION = "";
            try
            {
                TipoServicioSastreriaDTO tipoServicioSastreriaDTO = new();
                tipoServicioSastreriaDTO.DescServicioSastreria = DescServicioSastreria;
                tipoServicioSastreriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoServicioSastreriaBL.AgregarTipoServicioSastreria(tipoServicioSastreriaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoServicioSastreria(int TipoServicioSastreriaId)
        {
            return Json(tipoServicioSastreriaBL.BuscarTipoServicioSastreriaID(TipoServicioSastreriaId));
        }

        public ActionResult ActualizarTipoServicioSastreria(int TipoServicioSastreriaId, string DescServicioSastreria)
        {
            TipoServicioSastreriaDTO tipoServicioSastreriaDTO = new();
            tipoServicioSastreriaDTO.TipoServicioSastreriaId = TipoServicioSastreriaId;
            tipoServicioSastreriaDTO.DescServicioSastreria = DescServicioSastreria;
            tipoServicioSastreriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoServicioSastreriaBL.ActualizarTipoServicioSastreria(tipoServicioSastreriaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoServicioSastreria(int TipoServicioSastreriaId)
        {
            TipoServicioSastreriaDTO tipoServicioSastreriaDTO = new();
            tipoServicioSastreriaDTO.TipoServicioSastreriaId = TipoServicioSastreriaId;
            tipoServicioSastreriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoServicioSastreriaBL.EliminarTipoServicioSastreria(tipoServicioSastreriaDTO);

            return Content(IND_OPERACION);
        }
    }
}
