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
    public class GrupoOcupacionalController : Controller
    {
        readonly GrupoOcupacionalDAO grupoOcupacionalBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "GrupoOcupacional", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<GrupoOcupacionalDTO> listaGrupoOcupacionals = grupoOcupacionalBL.ObtenerGrupoOcupacionals();
            return Json(new { data = listaGrupoOcupacionals });
        }

        public ActionResult InsertarGrupoOcupacional(string DescGrupoOcupacional, string CodigoGrupoOcupacional)
        {
            GrupoOcupacionalDTO grupoOcupacionalDTO = new();
            grupoOcupacionalDTO.DescGrupoOcupacional = DescGrupoOcupacional;
            grupoOcupacionalDTO.CodigoGrupoOcupacional = CodigoGrupoOcupacional;
            grupoOcupacionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = grupoOcupacionalBL.AgregarGrupoOcupacional(grupoOcupacionalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarGrupoOcupacional(int GrupoOcupacionalId)
        {
            return Json(grupoOcupacionalBL.BuscarGrupoOcupacionalID(GrupoOcupacionalId));
        }

        public ActionResult ActualizarGrupoOcupacional(int GrupoOcupacionalId, string DescGrupoOcupacional, string CodigoGrupoOcupacional)
        {
            GrupoOcupacionalDTO grupoOcupacionalDTO = new();
            grupoOcupacionalDTO.GrupoOcupacionalId = GrupoOcupacionalId;
            grupoOcupacionalDTO.DescGrupoOcupacional = DescGrupoOcupacional;
            grupoOcupacionalDTO.CodigoGrupoOcupacional = CodigoGrupoOcupacional;
            grupoOcupacionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = grupoOcupacionalBL.ActualizarGrupoOcupacional(grupoOcupacionalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarGrupoOcupacional(int GrupoOcupacionalId)
        {
            GrupoOcupacionalDTO grupoOcupacionalDTO = new();
            grupoOcupacionalDTO.GrupoOcupacionalId = GrupoOcupacionalId;
            grupoOcupacionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (grupoOcupacionalBL.EliminarGrupoOcupacional(grupoOcupacionalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
