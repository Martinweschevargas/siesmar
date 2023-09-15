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
    public class EntidadConvocanteController : Controller
    {
        readonly ILogger<EntidadConvocanteController> _logger;

        public EntidadConvocanteController(ILogger<EntidadConvocanteController> logger)
        {
            _logger = logger;
        }

        readonly EntidadConvocanteDAO entidadConvocanteBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "EntidadConvocante", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EntidadConvocanteDTO> listaEntidadConvocantes = entidadConvocanteBL.ObtenerEntidadConvocantes();
            return Json(new { data = listaEntidadConvocantes });
        }

        public ActionResult InsertarEntidadConvocante(string DescEntidadConvocante, string CodigoEntidadConvocante)
        {
            var IND_OPERACION="";
            try
            {
                EntidadConvocanteDTO entidadConvocanteDTO = new();
                entidadConvocanteDTO.DescEntidadConvocante = DescEntidadConvocante;
                entidadConvocanteDTO.CodigoEntidadConvocante = CodigoEntidadConvocante;
                entidadConvocanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = entidadConvocanteBL.AgregarEntidadConvocante(entidadConvocanteDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEntidadConvocante(int EntidadConvocanteId)
        {
            return Json(entidadConvocanteBL.BuscarEntidadConvocanteID(EntidadConvocanteId));
        }

        public ActionResult ActualizarEntidadConvocante(int EntidadConvocanteId, string DescEntidadConvocante, string CodigoEntidadConvocante)
        {
            EntidadConvocanteDTO entidadConvocanteDTO = new();
            entidadConvocanteDTO.EntidadConvocanteId = EntidadConvocanteId;
            entidadConvocanteDTO.DescEntidadConvocante = DescEntidadConvocante;
            entidadConvocanteDTO.CodigoEntidadConvocante = CodigoEntidadConvocante;
            entidadConvocanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = entidadConvocanteBL.ActualizarEntidadConvocante(entidadConvocanteDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEntidadConvocante(int EntidadConvocanteId)
        {
            EntidadConvocanteDTO entidadConvocanteDTO = new();
            entidadConvocanteDTO.EntidadConvocanteId = EntidadConvocanteId;
            entidadConvocanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (entidadConvocanteBL.EliminarEntidadConvocante(entidadConvocanteDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
