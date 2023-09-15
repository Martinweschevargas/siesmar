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
    public class GrupoComisionadoController : Controller
    {
        readonly ILogger<GrupoComisionadoController> _logger;

        public GrupoComisionadoController(ILogger<GrupoComisionadoController> logger)
        {
            _logger = logger;
        }

        readonly GrupoComisionadoDAO grupoComisionadoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Grupos Comisionados", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<GrupoComisionadoDTO> listaGrupoComisionados = grupoComisionadoBL.ObtenerGrupoComisionados();
            return Json(new { data = listaGrupoComisionados });
        }

        public ActionResult InsertarGrupoComisionado(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                GrupoComisionadoDTO grupoComisionadoDTO = new();
                grupoComisionadoDTO.DescGrupoComisionado = Descripcion;
                grupoComisionadoDTO.CodigoGrupoComisionado = Codigo;
                grupoComisionadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = grupoComisionadoBL.AgregarGrupoComisionado(grupoComisionadoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarGrupoComisionado(int GrupoComisionadoId)
        {
            return Json(grupoComisionadoBL.BuscarGrupoComisionadoID(GrupoComisionadoId));
        }

        public ActionResult ActualizarGrupoComisionado(int GrupoComisionadoId, string Codigo, string Descripcion)
        {
            GrupoComisionadoDTO grupoComisionadoDTO = new();
            grupoComisionadoDTO.GrupoComisionadoId = GrupoComisionadoId;
            grupoComisionadoDTO.DescGrupoComisionado = Descripcion;
            grupoComisionadoDTO.CodigoGrupoComisionado = Codigo;
            grupoComisionadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = grupoComisionadoBL.ActualizarGrupoComisionado(grupoComisionadoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarGrupoComisionado(int GrupoComisionadoId)
        {
            GrupoComisionadoDTO grupoComisionadoDTO = new();
            grupoComisionadoDTO.GrupoComisionadoId = GrupoComisionadoId;
            grupoComisionadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = grupoComisionadoBL.EliminarGrupoComisionado(grupoComisionadoDTO);

            return Content(IND_OPERACION);
        }
    }
}
