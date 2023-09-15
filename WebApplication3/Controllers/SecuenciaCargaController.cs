using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class SecuenciaCargaController : Controller
    {
        readonly ILogger<SecuenciaCargaController> _logger;

        public SecuenciaCargaController(ILogger<SecuenciaCargaController> logger)
        {
            _logger = logger;
        }

        readonly SecuenciaCarga secuenciaCargaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Secuencias Cargas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SecuenciaCargaDTO> listaSecuenciaCargas = secuenciaCargaBL.ObtenerSecuenciaCargas();
            return Json(new { data = listaSecuenciaCargas });
        }

        public ActionResult InsertarSecuenciaCarga(string NOM_TABLA, int NUM_SECUENCIA, string FEC_REGISTRO, int USR_REGISTRO,
                                        string FEC_ACTUALIZO, int USR_ACTUALIZO)
        {
            var IND_OPERACION = "";
            try
            {
                SecuenciaCargaDTO secuenciaCargaDTO = new();
                secuenciaCargaDTO.NOM_TABLA = NOM_TABLA;
                secuenciaCargaDTO.NUM_SECUENCIA = NUM_SECUENCIA;
                secuenciaCargaDTO.FEC_REGISTRO = FEC_REGISTRO;
                secuenciaCargaDTO.USR_REGISTRO = USR_REGISTRO;
                secuenciaCargaDTO.FEC_ACTUALIZO = FEC_ACTUALIZO;
                secuenciaCargaDTO.USR_ACTUALIZO = USR_ACTUALIZO;
                secuenciaCargaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = secuenciaCargaBL.AgregarSecuenciaCarga(secuenciaCargaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSecuenciaCarga(string NOM_TABLA)
        {
            return Json(secuenciaCargaBL.BuscarSecuenciaCargaID(NOM_TABLA));
        }

        public ActionResult ActualizarSecuenciaCarga(string NOM_TABLA, int NUM_SECUENCIA, string FEC_REGISTRO, int USR_REGISTRO,
                                            string FEC_ACTUALIZO, int USR_ACTUALIZO)
        {
            SecuenciaCargaDTO secuenciaCargaDTO = new();
            secuenciaCargaDTO.NOM_TABLA = NOM_TABLA;
            secuenciaCargaDTO.NUM_SECUENCIA = NUM_SECUENCIA;
            secuenciaCargaDTO.FEC_REGISTRO = FEC_REGISTRO;
            secuenciaCargaDTO.USR_REGISTRO = USR_REGISTRO;
            secuenciaCargaDTO.FEC_ACTUALIZO = FEC_ACTUALIZO;
            secuenciaCargaDTO.USR_ACTUALIZO = USR_ACTUALIZO;
            secuenciaCargaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = secuenciaCargaBL.ActualizarSecuenciaCarga(secuenciaCargaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSecuenciaCarga(string NOM_TABLA)
        {
            SecuenciaCargaDTO secuenciaCargaDTO = new();
            secuenciaCargaDTO.NOM_TABLA = NOM_TABLA;
            secuenciaCargaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = secuenciaCargaBL.EliminarSecuenciaCarga(secuenciaCargaDTO);

            return Content(IND_OPERACION);
        }
    }
}
