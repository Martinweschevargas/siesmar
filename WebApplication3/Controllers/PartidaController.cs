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
    public class PartidaController : Controller
    {
        readonly PartidaDAO partidaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Partidas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<PartidaDTO> listaPartidas = partidaBL.ObtenerPartidas();
            return Json(new { data = listaPartidas });
        }

        public ActionResult InsertarPartida(string DescPartida, string CodigoPartida)
        {
            PartidaDTO partidaDTO = new();
            partidaDTO.DescPartida = DescPartida;
            partidaDTO.CodigoPartida = CodigoPartida;
            partidaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = partidaBL.AgregarPartida(partidaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarPartida(int PartidaId)
        {
            return Json(partidaBL.BuscarPartidaID(PartidaId));
        }

        public ActionResult ActualizarPartida(int PartidaId, string DescPartida, string CodigoPartida)
        {
            PartidaDTO partidaDTO = new();
            partidaDTO.PartidaId = PartidaId;
            partidaDTO.DescPartida = DescPartida;
            partidaDTO.CodigoPartida = CodigoPartida;
            partidaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = partidaBL.ActualizarPartida(partidaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarPartida(int PartidaId)
        {
            PartidaDTO partidaDTO = new();
            partidaDTO.PartidaId = PartidaId;
            partidaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = partidaBL.EliminarPartida(partidaDTO);

            return Content(IND_OPERACION);
        }

    }
}
