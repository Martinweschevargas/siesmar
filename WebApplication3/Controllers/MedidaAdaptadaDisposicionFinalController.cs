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
    public class MedidaAdaptadaDisposicionFinalController : Controller
    {
        readonly ILogger<MedidaAdaptadaDisposicionFinalController> _logger;

        public MedidaAdaptadaDisposicionFinalController(ILogger<MedidaAdaptadaDisposicionFinalController> logger)
        {
            _logger = logger;
        }

        readonly MedidaAdaptadaDisposicionFinalDAO MedidaAdaptadaDisposicionFinalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Medidas Adaptadas Disposiciones Finales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<MedidaAdaptadaDisposicionFinalDTO> listaMedidaAdaptadaDisposicionFinals = MedidaAdaptadaDisposicionFinalBL.ObtenerMedidaAdaptadaDisposicionFinals();
            return Json(new { data = listaMedidaAdaptadaDisposicionFinals });
        }

        public ActionResult InsertarMedidaAdaptadaDisposicionFinal(string Codigo, string Descripcion)
        {
            var IND_OPERACION = "";
            try
            {
                MedidaAdaptadaDisposicionFinalDTO MedidaAdaptadaDisposicionFinalDTO = new();
                MedidaAdaptadaDisposicionFinalDTO.DescMedidaAdaptadaDisposicionFinal = Descripcion;
                MedidaAdaptadaDisposicionFinalDTO.CodigoMedidaAdaptadaDisposicionFinal = Codigo;
                MedidaAdaptadaDisposicionFinalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = MedidaAdaptadaDisposicionFinalBL.AgregarMedidaAdaptadaDisposicionFinal(MedidaAdaptadaDisposicionFinalDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarMedidaAdaptadaDisposicionFinal(int MedidaAdaptadaDisposicionFinalId)
        {
            return Json(MedidaAdaptadaDisposicionFinalBL.BuscarMedidaAdaptadaDisposicionFinalID(MedidaAdaptadaDisposicionFinalId));
        }

        public ActionResult ActualizarMedidaAdaptadaDisposicionFinal(int MedidaAdaptadaDisposicionFinalId, string Codigo, string Descripcion)
        {
            MedidaAdaptadaDisposicionFinalDTO MedidaAdaptadaDisposicionFinalDTO = new();
            MedidaAdaptadaDisposicionFinalDTO.MedidaAdaptadaDisposicionFinalId = MedidaAdaptadaDisposicionFinalId;
            MedidaAdaptadaDisposicionFinalDTO.DescMedidaAdaptadaDisposicionFinal = Descripcion;
            MedidaAdaptadaDisposicionFinalDTO.CodigoMedidaAdaptadaDisposicionFinal = Codigo;
            MedidaAdaptadaDisposicionFinalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = MedidaAdaptadaDisposicionFinalBL.ActualizarMedidaAdaptadaDisposicionFinal(MedidaAdaptadaDisposicionFinalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarMedidaAdaptadaDisposicionFinal(int MedidaAdaptadaDisposicionFinalId)
        {
            MedidaAdaptadaDisposicionFinalDTO MedidaAdaptadaDisposicionFinalDTO = new();
            MedidaAdaptadaDisposicionFinalDTO.MedidaAdaptadaDisposicionFinalId = MedidaAdaptadaDisposicionFinalId;
            MedidaAdaptadaDisposicionFinalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = MedidaAdaptadaDisposicionFinalBL.EliminarMedidaAdaptadaDisposicionFinal(MedidaAdaptadaDisposicionFinalDTO);

            return Content(IND_OPERACION);
        }
    }
}
