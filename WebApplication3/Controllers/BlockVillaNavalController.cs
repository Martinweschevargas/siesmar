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
    public class BlockVillaNavalController : Controller
    {
        readonly ILogger<BlockVillaNavalController> _logger;

        public BlockVillaNavalController(ILogger<BlockVillaNavalController> logger)
        {
            _logger = logger;
        }

        readonly BlockVillaNaval blockVillaNavalBL = new();
        Usuario usuarioBL = new();

        VillaNaval villaNavalBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Block Villas Navales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<VillaNavalDTO> villaNavalDTO = villaNavalBL.ObtenerVillaNavals();

            return Json(new { data = villaNavalDTO });
        }

        public JsonResult CargarDatos()
        {
            List<BlockVillaNavalDTO> listaBlockVillaNavales = blockVillaNavalBL.ObtenerBlockVillaNavals();
            return Json(new { data = listaBlockVillaNavales });
        }

        public ActionResult InsertarBlockVillaNaval(string CodigoBlockVillaNaval, string DescBlockVillaNaval, string CodigoVillaNaval)
        {
            var IND_OPERACION = "";
            try
            {
                BlockVillaNavalDTO blockVillaNavalDTO = new();
                blockVillaNavalDTO.CodigoBlockVillaNaval = CodigoBlockVillaNaval;
                blockVillaNavalDTO.DescBlockVillaNaval = DescBlockVillaNaval;
                blockVillaNavalDTO.CodigoVillaNaval = CodigoVillaNaval;
                blockVillaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = blockVillaNavalBL.AgregarBlockVillaNaval(blockVillaNavalDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarBlockVillaNaval(int BlockCodigoVillaNaval)
        {
            return Json(blockVillaNavalBL.BuscarBlockVillaNavalID(BlockCodigoVillaNaval));
        }

        public ActionResult ActualizarBlockVillaNaval(int BlockVillaNavalId, string CodigoBlockVillaNaval, string DescBlockVillaNaval, string CodigoVillaNaval)
        {
            BlockVillaNavalDTO blockVillaNavalDTO = new();
            blockVillaNavalDTO.BlockVillaNavalId = BlockVillaNavalId;
            blockVillaNavalDTO.CodigoBlockVillaNaval = CodigoBlockVillaNaval;
            blockVillaNavalDTO.DescBlockVillaNaval = DescBlockVillaNaval;
            blockVillaNavalDTO.CodigoVillaNaval = CodigoVillaNaval;
            blockVillaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = blockVillaNavalBL.ActualizarBlockVillaNaval(blockVillaNavalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarBlockVillaNaval(int BlockVillaNavalId)
        {
            BlockVillaNavalDTO blockVillaNavalDTO = new();
            blockVillaNavalDTO.BlockVillaNavalId = BlockVillaNavalId;
            blockVillaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = blockVillaNavalBL.EliminarBlockVillaNaval(blockVillaNavalDTO);

            return Content(IND_OPERACION);
        }
    }
}
