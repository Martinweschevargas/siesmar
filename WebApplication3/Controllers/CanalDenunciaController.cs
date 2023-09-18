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
    public class CanalDenunciaController : Controller
    {
        readonly ILogger<CanalDenunciaController> _logger;

        public CanalDenunciaController(ILogger<CanalDenunciaController> logger)
        {
            _logger = logger;
        }

        readonly CanalDenunciaDAO canalDenunciaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Canales Denuncias", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<CanalDenunciaDTO> listaCanalDenuncias = canalDenunciaBL.ObtenerCanalDenuncias();
            return Json(new { data = listaCanalDenuncias });
        }

        public ActionResult InsertarCanalDenuncia(string DescCanalDenuncia, string CodigoCanalDenuncia)
        {
            var IND_OPERACION="";
            try
            {
                CanalDenunciaDTO canalDenunciaDTO = new();
                canalDenunciaDTO.DescCanalDenuncia = DescCanalDenuncia;
                canalDenunciaDTO.CodigoCanalDenuncia = CodigoCanalDenuncia;
                canalDenunciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = canalDenunciaBL.AgregarCanalDenuncia(canalDenunciaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarCanalDenuncia(int CanalDenunciaId)
        {
            return Json(canalDenunciaBL.BuscarCanalDenunciaID(CanalDenunciaId));
        }

        public ActionResult ActualizarCanalDenuncia(int CanalDenunciaId, string DescCanalDenuncia, string CodigoCanalDenuncia)
        {
            CanalDenunciaDTO canalDenunciaDTO = new();
            canalDenunciaDTO.CanalDenunciaId = CanalDenunciaId;
            canalDenunciaDTO.DescCanalDenuncia = DescCanalDenuncia;
            canalDenunciaDTO.CodigoCanalDenuncia = CodigoCanalDenuncia;
            canalDenunciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = canalDenunciaBL.ActualizarCanalDenuncia(canalDenunciaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarCanalDenuncia(int CanalDenunciaId)
        {
            CanalDenunciaDTO canalDenunciaDTO = new();
            canalDenunciaDTO.CanalDenunciaId = CanalDenunciaId;
            canalDenunciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = canalDenunciaBL.EliminarCanalDenuncia(canalDenunciaDTO);

            return Content(IND_OPERACION);
        }
    }
}
