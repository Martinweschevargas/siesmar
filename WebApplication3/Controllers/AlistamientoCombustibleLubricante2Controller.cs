using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using SQLitePCL;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class AlistamientoCombustibleLubricante2Controller : Controller
    {
        readonly ILogger<AlistamientoCombustibleLubricante2Controller> _logger;

        public AlistamientoCombustibleLubricante2Controller(ILogger<AlistamientoCombustibleLubricante2Controller> logger)
        {
            _logger = logger;
        }

        readonly AlistamientoCombustibleLubricante2 AlistamientoCombustibleLubricante2BL = new();
        Usuario usuarioBL = new();

        UnidadMedida UnidadMedidaBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Alistamientos Combustibles Lubricantes 2", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult cargaCombs()
        {

            List<UnidadMedidaDTO> UnidadMedidaDTO = UnidadMedidaBL.ObtenerUnidadMedidas();

            return Json(new { data = UnidadMedidaDTO });
        }

        public JsonResult CargarDatos()
        {
            List<AlistamientoCombustibleLubricante2DTO> listaAlistamientoCombustibleLubricante2es = AlistamientoCombustibleLubricante2BL.ObtenerAlistamientoCombustibleLubricante2s();
            return Json(new { data = listaAlistamientoCombustibleLubricante2es });
        }

        public ActionResult InsertarAlistamientoCombustibleLubricante2(string Articulo, string CodigoAlistamientoCombustibleLubricante2, string Equipo, string CodigoUnidadMedida, int Cargo, int Aumento, int Consumo, int Existencia )
        {
            var IND_OPERACION = "";
            try
            {
                AlistamientoCombustibleLubricante2DTO AlistamientoCombustibleLubricante2DTO = new();
                AlistamientoCombustibleLubricante2DTO.CodigoAlistamientoCombustibleLubricante2 = CodigoAlistamientoCombustibleLubricante2;
                AlistamientoCombustibleLubricante2DTO.Articulo = Articulo;
                AlistamientoCombustibleLubricante2DTO.Equipo = Equipo;
                AlistamientoCombustibleLubricante2DTO.CodigoUnidadMedida = CodigoUnidadMedida;
                AlistamientoCombustibleLubricante2DTO.Cargo = Cargo;
                AlistamientoCombustibleLubricante2DTO.Aumento = Aumento;
                AlistamientoCombustibleLubricante2DTO.Consumo = Consumo;
                AlistamientoCombustibleLubricante2DTO.Existencia = Existencia;
                AlistamientoCombustibleLubricante2DTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = AlistamientoCombustibleLubricante2BL.AgregarAlistamientoCombustibleLubricante2(AlistamientoCombustibleLubricante2DTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAlistamientoCombustibleLubricante2(int AlistamientoCombustibleLubricante2Id)
        {
            return Json(AlistamientoCombustibleLubricante2BL.BuscarAlistamientoCombustibleLubricante2ID(AlistamientoCombustibleLubricante2Id));
        }

        public ActionResult ActualizarAlistamientoCombustibleLubricante2(int AlistamientoCombustibleLubricante2Id, string CodigoAlistamientoCombustibleLubricante2, string Articulo, string Equipo, string CodigoUnidadMedida, int Cargo, int Aumento, int Consumo, int Existencia)
        {
            AlistamientoCombustibleLubricante2DTO AlistamientoCombustibleLubricante2DTO = new();
            AlistamientoCombustibleLubricante2DTO.AlistamientoCombustibleLubricante2Id = AlistamientoCombustibleLubricante2Id;
            AlistamientoCombustibleLubricante2DTO.CodigoAlistamientoCombustibleLubricante2 = CodigoAlistamientoCombustibleLubricante2;
            AlistamientoCombustibleLubricante2DTO.Articulo = Articulo;
            AlistamientoCombustibleLubricante2DTO.Equipo = Equipo;
            AlistamientoCombustibleLubricante2DTO.CodigoUnidadMedida = CodigoUnidadMedida;
            AlistamientoCombustibleLubricante2DTO.Cargo = Cargo;
            AlistamientoCombustibleLubricante2DTO.Aumento = Aumento;
            AlistamientoCombustibleLubricante2DTO.Consumo = Consumo;
            AlistamientoCombustibleLubricante2DTO.Existencia = Existencia;
            AlistamientoCombustibleLubricante2DTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AlistamientoCombustibleLubricante2BL.ActualizarAlistamientoCombustibleLubricante2(AlistamientoCombustibleLubricante2DTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAlistamientoCombustibleLubricante2(int AlistamientoCombustibleLubricante2Id)
        {
            AlistamientoCombustibleLubricante2DTO AlistamientoCombustibleLubricante2DTO = new();
            AlistamientoCombustibleLubricante2DTO.AlistamientoCombustibleLubricante2Id = AlistamientoCombustibleLubricante2Id;
            AlistamientoCombustibleLubricante2DTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = AlistamientoCombustibleLubricante2BL.EliminarAlistamientoCombustibleLubricante2(AlistamientoCombustibleLubricante2DTO);

            return Content(IND_OPERACION);
        }
    }
}
