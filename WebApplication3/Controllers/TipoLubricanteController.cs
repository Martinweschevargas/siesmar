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
    public class TipoLubricanteController : Controller
    {
        readonly TipoLubricanteDAO tipoLubricanteBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Lubricantes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoLubricanteDTO> listaTipoLubricantes = tipoLubricanteBL.ObtenerTipoLubricantes();
            return Json(new { data = listaTipoLubricantes });
        }

        public ActionResult InsertarTipoLubricante(string DescTipoLubricante, string CodigoTipoLubricante)
        {
            TipoLubricanteDTO tipoLubricanteDTO = new();
            tipoLubricanteDTO.DescTipoLubricante = DescTipoLubricante;
            tipoLubricanteDTO.CodigoTipoLubricante = CodigoTipoLubricante;
            tipoLubricanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoLubricanteBL.AgregarTipoLubricante(tipoLubricanteDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoLubricante(int TipoLubricanteId)
        {
            return Json(tipoLubricanteBL.BuscarTipoLubricanteID(TipoLubricanteId));
        }

        public ActionResult ActualizarTipoLubricante(int TipoLubricanteId, string DescTipoLubricante, string CodigoTipoLubricante)
        {
            TipoLubricanteDTO tipoLubricanteDTO = new();
            tipoLubricanteDTO.TipoLubricanteId = TipoLubricanteId;
            tipoLubricanteDTO.DescTipoLubricante = DescTipoLubricante;
            tipoLubricanteDTO.CodigoTipoLubricante = CodigoTipoLubricante;
            tipoLubricanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoLubricanteBL.ActualizarTipoLubricante(tipoLubricanteDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoLubricante(int TipoLubricanteId)
        {
            TipoLubricanteDTO tipoLubricanteDTO = new();
            tipoLubricanteDTO.TipoLubricanteId = TipoLubricanteId;
            tipoLubricanteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoLubricanteBL.EliminarTipoLubricante(tipoLubricanteDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
