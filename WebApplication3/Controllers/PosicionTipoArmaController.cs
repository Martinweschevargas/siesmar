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
    public class PosicionTipoArmaController : Controller
    {
        readonly ILogger<PosicionTipoArmaController> _logger;

        public PosicionTipoArmaController(ILogger<PosicionTipoArmaController> logger)
        {
            _logger = logger;
        }

        readonly PosicionTipoArmaDAO posicionTipoArmaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Posiciones Tipos Armas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<PosicionTipoArmaDTO> listaPosicionTipoArmas = posicionTipoArmaBL.ObtenerPosicionTipoArmas();
            return Json(new { data = listaPosicionTipoArmas });
        }

        public ActionResult InsertarPosicionTipoArma(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                PosicionTipoArmaDTO posicionTipoArmaDTO = new();
                posicionTipoArmaDTO.DescPosicionTipoArma = Descripcion;
                posicionTipoArmaDTO.CodigoPosicionTipoArma = Codigo;
                posicionTipoArmaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = posicionTipoArmaBL.AgregarPosicionTipoArma(posicionTipoArmaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarPosicionTipoArma(int PosicionTipoArmaId)
        {
            return Json(posicionTipoArmaBL.BuscarPosicionTipoArmaID(PosicionTipoArmaId));
        }

        public ActionResult ActualizarPosicionTipoArma(int PosicionTipoArmaId, string Codigo, string Descripcion)
        {
            PosicionTipoArmaDTO posicionTipoArmaDTO = new();
            posicionTipoArmaDTO.PosicionTipoArmaId = PosicionTipoArmaId;
            posicionTipoArmaDTO.DescPosicionTipoArma = Descripcion;
            posicionTipoArmaDTO.CodigoPosicionTipoArma = Codigo;
            posicionTipoArmaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = posicionTipoArmaBL.ActualizarPosicionTipoArma(posicionTipoArmaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPosicionTipoArma(int PosicionTipoArmaId)
        {
            PosicionTipoArmaDTO posicionTipoArmaDTO = new();
            posicionTipoArmaDTO.PosicionTipoArmaId = PosicionTipoArmaId;
            posicionTipoArmaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = posicionTipoArmaBL.EliminarPosicionTipoArma(posicionTipoArmaDTO);

            return Content(IND_OPERACION);
        }
    }
}
