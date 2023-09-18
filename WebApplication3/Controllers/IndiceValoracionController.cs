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
    public class IndiceValoracionController : Controller
    {
        readonly ILogger<IndiceValoracionController> _logger;

        public IndiceValoracionController(ILogger<IndiceValoracionController> logger)
        {
            _logger = logger;
        }

        readonly IndiceValoracion indiceValoracionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Índices Valoraciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<IndiceValoracionDTO> listaIndiceValoracions = indiceValoracionBL.ObtenerIndiceValoracions();
            return Json(new { data = listaIndiceValoracions });
        }

        public ActionResult InsertarIndiceValoracion(string Criterio, int Codigo, string Descripcion, char SI, char NO)
        {
            var IND_OPERACION = "";
            try
            {
                IndiceValoracionDTO indiceValoracionDTO = new();
                indiceValoracionDTO.DescIndiceValoracion = Descripcion;
                indiceValoracionDTO.Criterio = Criterio;
                indiceValoracionDTO.CodigoDependencia = Codigo;
                indiceValoracionDTO.SI = SI;
                indiceValoracionDTO.NO = NO;
                indiceValoracionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = indiceValoracionBL.AgregarIndiceValoracion(indiceValoracionDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarIndiceValoracion(int IndiceValoracionId)
        {
            return Json(indiceValoracionBL.BuscarIndiceValoracionID(IndiceValoracionId));
        }

        public ActionResult ActualizarIndiceValoracion(int IndiceValoracionId, string Criterio, int Codigo, string Descripcion, char SI, char NO)
        {
            IndiceValoracionDTO indiceValoracionDTO = new();
            indiceValoracionDTO.IndiceValoracionId = IndiceValoracionId;
            indiceValoracionDTO.DescIndiceValoracion = Descripcion;
            indiceValoracionDTO.Criterio = Criterio;
            indiceValoracionDTO.CodigoDependencia = Codigo;
            indiceValoracionDTO.SI = SI;
            indiceValoracionDTO.NO = NO;
            indiceValoracionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = indiceValoracionBL.ActualizarIndiceValoracion(indiceValoracionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarIndiceValoracion(int IndiceValoracionId)
        {
            IndiceValoracionDTO indiceValoracionDTO = new();
            indiceValoracionDTO.IndiceValoracionId = IndiceValoracionId;
            indiceValoracionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = indiceValoracionBL.EliminarIndiceValoracion(indiceValoracionDTO);

            return Content(IND_OPERACION);
        }
    }
}
