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
    public class TemaAcademicoController : Controller
    {
        readonly ILogger<TemaAcademicoController> _logger;

        public TemaAcademicoController(ILogger<TemaAcademicoController> logger)
        {
            _logger = logger;
        }

        readonly TemaAcademicoDAO temaAcademicoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Temas Academicos", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TemaAcademicoDTO> listaTemaAcademicos = temaAcademicoBL.ObtenerTemaAcademicos();
            return Json(new { data = listaTemaAcademicos });
        }

        public ActionResult InsertarTemaAcademico(string DescTemaAcademico, string CodigoTemaAcademico)
        {
            var IND_OPERACION="";
            try
            {
                TemaAcademicoDTO temaAcademicoDTO = new();
                temaAcademicoDTO.DescTemaAcademico = DescTemaAcademico;
                temaAcademicoDTO.CodigoTemaAcademico = CodigoTemaAcademico;
                temaAcademicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = temaAcademicoBL.AgregarTemaAcademico(temaAcademicoDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTemaAcademico(int TemaAcademicoId)
        {
            return Json(temaAcademicoBL.BuscarTemaAcademicoID(TemaAcademicoId));
        }

        public ActionResult ActualizarTemaAcademico(int TemaAcademicoId, string DescTemaAcademico, string CodigoTemaAcademico)
        {
            TemaAcademicoDTO temaAcademicoDTO = new();
            temaAcademicoDTO.TemaAcademicoId = TemaAcademicoId;
            temaAcademicoDTO.DescTemaAcademico = DescTemaAcademico;
            temaAcademicoDTO.CodigoTemaAcademico = CodigoTemaAcademico;
            temaAcademicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = temaAcademicoBL.ActualizarTemaAcademico(temaAcademicoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTemaAcademico(int TemaAcademicoId)
        {
            TemaAcademicoDTO temaAcademicoDTO = new();
            temaAcademicoDTO.TemaAcademicoId = TemaAcademicoId;
            temaAcademicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = temaAcademicoBL.EliminarTemaAcademico(temaAcademicoDTO);

            return Content(IND_OPERACION);
        }
    }
}
