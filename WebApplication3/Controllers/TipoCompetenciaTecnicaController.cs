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
    public class TipoCompetenciaTecnicaController : Controller
    {
        readonly ILogger<TipoCompetenciaTecnicaController> _logger;

        public TipoCompetenciaTecnicaController(ILogger<TipoCompetenciaTecnicaController> logger)
        {
            _logger = logger;
        }

        readonly TipoCompetenciaTecnicaDAO tipoCompetenciaTecnicaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Competencias Técnicas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoCompetenciaTecnicaDTO> listaTipoCompetenciaTecnicas = tipoCompetenciaTecnicaBL.ObtenerTipoCompetenciaTecnicas();
            return Json(new { data = listaTipoCompetenciaTecnicas });
        }

        public ActionResult InsertarTipoCompetenciaTecnica(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                TipoCompetenciaTecnicaDTO tipoCompetenciaTecnicaDTO = new();
                tipoCompetenciaTecnicaDTO.DescTipoCompetenciaTecnica = Descripcion;
                tipoCompetenciaTecnicaDTO.CodigoTipoCompetenciaTecnica = Codigo;
                tipoCompetenciaTecnicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = tipoCompetenciaTecnicaBL.AgregarTipoCompetenciaTecnica(tipoCompetenciaTecnicaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoCompetenciaTecnica(int TipoCompetenciaTecnicaId)
        {
            return Json(tipoCompetenciaTecnicaBL.BuscarTipoCompetenciaTecnicaID(TipoCompetenciaTecnicaId));
        }

        public ActionResult ActualizarTipoCompetenciaTecnica(int TipoCompetenciaTecnicaId, string Codigo, string Descripcion)
        {
            TipoCompetenciaTecnicaDTO tipoCompetenciaTecnicaDTO = new();
            tipoCompetenciaTecnicaDTO.TipoCompetenciaTecnicaId = TipoCompetenciaTecnicaId;
            tipoCompetenciaTecnicaDTO.DescTipoCompetenciaTecnica = Descripcion;
            tipoCompetenciaTecnicaDTO.CodigoTipoCompetenciaTecnica = Codigo;
            tipoCompetenciaTecnicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoCompetenciaTecnicaBL.ActualizarTipoCompetenciaTecnica(tipoCompetenciaTecnicaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoCompetenciaTecnica(int TipoCompetenciaTecnicaId)
        {
            TipoCompetenciaTecnicaDTO tipoCompetenciaTecnicaDTO = new();
            tipoCompetenciaTecnicaDTO.TipoCompetenciaTecnicaId = TipoCompetenciaTecnicaId;
            tipoCompetenciaTecnicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoCompetenciaTecnicaBL.EliminarTipoCompetenciaTecnica(tipoCompetenciaTecnicaDTO);

            return Content(IND_OPERACION);
        }
    }
}
