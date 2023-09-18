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
    public class MarcaController : Controller
    {
        readonly ILogger<MarcaController> _logger;

        public MarcaController(ILogger<MarcaController> logger)
        {
            _logger = logger;
        }

        readonly MarcaDAO MarcaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Marcas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MarcaDTO> listaMarcas = MarcaBL.ObtenerMarcas();
            return Json(new { data = listaMarcas });
        }

        public ActionResult InsertarMarca(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                MarcaDTO MarcaDTO = new();
                MarcaDTO.DescMarca = Descripcion;
                MarcaDTO.CodigoMarca = Codigo;
                MarcaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = MarcaBL.AgregarMarca(MarcaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMarca(int MarcaId)
        {
            return Json(MarcaBL.BuscarMarcaID(MarcaId));
        }

        public ActionResult ActualizarMarca(int MarcaId, string Codigo, string Descripcion)
        {
            MarcaDTO MarcaDTO = new();
            MarcaDTO.MarcaId = MarcaId;
            MarcaDTO.DescMarca = Descripcion;
            MarcaDTO.CodigoMarca = Codigo;
            MarcaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = MarcaBL.ActualizarMarca(MarcaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMarca(int MarcaId)
        {
            MarcaDTO MarcaDTO = new();
            MarcaDTO.MarcaId = MarcaId;
            MarcaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = MarcaBL.EliminarMarca(MarcaDTO);

            return Content(IND_OPERACION);
        }
    }
}
