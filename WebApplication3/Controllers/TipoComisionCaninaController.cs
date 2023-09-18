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
    public class TipoComisionCaninaController : Controller
    {
        readonly TipoComisionCaninaDAO tipoComisionCaninaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Comisiones Caninas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoComisionCaninaDTO> listaTipoComisionCaninas = tipoComisionCaninaBL.ObtenerTipoComisionCaninas();
            return Json(new { data = listaTipoComisionCaninas });
        }

        public ActionResult InsertarTipoComisionCanina(string DescTipoComisionCanina, string CodigoTipoComisionCanina)
        {
            TipoComisionCaninaDTO tipoComisionCaninaDTO = new();
            tipoComisionCaninaDTO.DescTipoComisionCanina = DescTipoComisionCanina;
            tipoComisionCaninaDTO.CodigoTipoComisionCanina = CodigoTipoComisionCanina;
            tipoComisionCaninaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoComisionCaninaBL.AgregarTipoComisionCanina(tipoComisionCaninaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoComisionCanina(int TipoComisionCaninaId)
        {
            return Json(tipoComisionCaninaBL.BuscarTipoComisionCaninaID(TipoComisionCaninaId));
        }

        public ActionResult ActualizarTipoComisionCanina(int TipoComisionCaninaId, string DescTipoComisionCanina, string CodigoTipoComisionCanina)
        {
            TipoComisionCaninaDTO tipoComisionCaninaDTO = new();
            tipoComisionCaninaDTO.TipoComisionCaninaId = TipoComisionCaninaId;
            tipoComisionCaninaDTO.DescTipoComisionCanina = DescTipoComisionCanina;
            tipoComisionCaninaDTO.CodigoTipoComisionCanina = CodigoTipoComisionCanina;
            tipoComisionCaninaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoComisionCaninaBL.ActualizarTipoComisionCanina(tipoComisionCaninaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoComisionCanina(int TipoComisionCaninaId)
        {
            TipoComisionCaninaDTO tipoComisionCaninaDTO = new();
            tipoComisionCaninaDTO.TipoComisionCaninaId = TipoComisionCaninaId;
            tipoComisionCaninaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoComisionCaninaBL.EliminarTipoComisionCanina(tipoComisionCaninaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
