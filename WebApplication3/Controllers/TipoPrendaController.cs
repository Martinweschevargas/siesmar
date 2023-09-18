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
    public class TipoPrendaController : Controller
    {
        readonly TipoPrendaDAO tipoPrendaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Prendas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoPrendaDTO> listaTipoPrendas = tipoPrendaBL.ObtenerTipoPrendas();
            return Json(new { data = listaTipoPrendas });
        }

        public ActionResult InsertarTipoPrenda(string DescTipoPrenda, string CodigoTipoPrenda)
        {
            TipoPrendaDTO tipoPrendaDTO = new();
            tipoPrendaDTO.DescTipoPrenda = DescTipoPrenda;
            tipoPrendaDTO.CodigoTipoPrenda = CodigoTipoPrenda;
            tipoPrendaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoPrendaBL.AgregarTipoPrenda(tipoPrendaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoPrenda(int TipoPrendaId)
        {
            return Json(tipoPrendaBL.BuscarTipoPrendaID(TipoPrendaId));
        }

        public ActionResult ActualizarTipoPrenda(int TipoPrendaId, string DescTipoPrenda, string CodigoTipoPrenda)
        {
            TipoPrendaDTO tipoPrendaDTO = new();
            tipoPrendaDTO.TipoPrendaId = TipoPrendaId;
            tipoPrendaDTO.DescTipoPrenda = DescTipoPrenda;
            tipoPrendaDTO.CodigoTipoPrenda = CodigoTipoPrenda;
            tipoPrendaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoPrendaBL.ActualizarTipoPrenda(tipoPrendaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoPrenda(int TipoPrendaId)
        {
            TipoPrendaDTO tipoPrendaDTO = new();
            tipoPrendaDTO.TipoPrendaId = TipoPrendaId;
            tipoPrendaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoPrendaBL.EliminarTipoPrenda(tipoPrendaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
