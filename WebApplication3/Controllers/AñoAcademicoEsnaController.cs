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
    public class AñoAcademicoEsnaController : Controller
    {
        readonly ILogger<AñoAcademicoEsnaController> _logger;

        public AñoAcademicoEsnaController(ILogger<AñoAcademicoEsnaController> logger)
        {
            _logger = logger;
        }

        readonly AñoAcademicoEsnaDAO añoAcademicoEsnaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Años Academicos Esnas", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<AñoAcademicoEsnaDTO> listaAñoAcademicoEsnas = añoAcademicoEsnaBL.ObtenerAñoAcademicoEsnas();
            return Json(new { data = listaAñoAcademicoEsnas });
        }

        public ActionResult InsertarAñoAcademicoEsna(string DescAñoAcademicoEsna, string CodigoAñoAcademicoEsna)
        {
            var IND_OPERACION="";
            try
            {
                AñoAcademicoEsnaDTO añoAcademicoEsnaDTO = new();
                añoAcademicoEsnaDTO.DescAñoAcademicoEsna = DescAñoAcademicoEsna;
                añoAcademicoEsnaDTO.CodigoAñoAcademicoEsna = CodigoAñoAcademicoEsna;
                añoAcademicoEsnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = añoAcademicoEsnaBL.AgregarAñoAcademicoEsna(añoAcademicoEsnaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarAñoAcademicoEsna(int AñoAcademicoEsnaId)
        {
            return Json(añoAcademicoEsnaBL.BuscarAñoAcademicoEsnaID(AñoAcademicoEsnaId));
        }

        public ActionResult ActualizarAñoAcademicoEsna(int AñoAcademicoEsnaId, string DescAñoAcademicoEsna, string CodigoAñoAcademicoEsna)
        {
            AñoAcademicoEsnaDTO añoAcademicoEsnaDTO = new();
            añoAcademicoEsnaDTO.AñoAcademicoEsnaId = AñoAcademicoEsnaId;
            añoAcademicoEsnaDTO.DescAñoAcademicoEsna = DescAñoAcademicoEsna;
            añoAcademicoEsnaDTO.CodigoAñoAcademicoEsna = CodigoAñoAcademicoEsna;
            añoAcademicoEsnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = añoAcademicoEsnaBL.ActualizarAñoAcademicoEsna(añoAcademicoEsnaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarAñoAcademicoEsna(int AñoAcademicoEsnaId)
        {
            AñoAcademicoEsnaDTO añoAcademicoEsnaDTO = new();
            añoAcademicoEsnaDTO.AñoAcademicoEsnaId = AñoAcademicoEsnaId;
            añoAcademicoEsnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = añoAcademicoEsnaBL.EliminarAñoAcademicoEsna(añoAcademicoEsnaDTO);

            return Content(IND_OPERACION);
        }
    }
}
