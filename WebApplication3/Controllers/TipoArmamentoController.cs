using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class TipoArmamentoController : Controller
    {
        readonly TipoArmamentoDAO tipoArmamentoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Armamento", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoArmamentoDTO> listaTipoArmamentos = tipoArmamentoBL.ObtenerTipoArmamentos();
            return Json(new { data = listaTipoArmamentos });
        }

        public ActionResult InsertarTipoArmamento(string DescTipoArmamento, string CodigoTipoArmamento)
        {
            TipoArmamentoDTO tipoArmamentoDTO = new();
            tipoArmamentoDTO.DescTipoArmamento = DescTipoArmamento;
            tipoArmamentoDTO.CodigoTipoArmamento = CodigoTipoArmamento;
            tipoArmamentoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoArmamentoBL.AgregarTipoArmamento(tipoArmamentoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoArmamento(int TipoArmamentoId)
        {
            return Json(tipoArmamentoBL.BuscarTipoArmamentoID(TipoArmamentoId));
        }

        public ActionResult ActualizarTipoArmamento(int TipoArmamentoId, string DescTipoArmamento, string CodigoTipoArmamento)
        {
            TipoArmamentoDTO tipoArmamentoDTO = new();
            tipoArmamentoDTO.TipoArmamentoId = TipoArmamentoId;
            tipoArmamentoDTO.DescTipoArmamento = DescTipoArmamento;
            tipoArmamentoDTO.CodigoTipoArmamento = CodigoTipoArmamento;
            tipoArmamentoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoArmamentoBL.ActualizarTipoArmamento(tipoArmamentoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoArmamento(int TipoArmamentoId)
        {
            TipoArmamentoDTO tipoArmamentoDTO = new();
            tipoArmamentoDTO.TipoArmamentoId = TipoArmamentoId;
            tipoArmamentoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoArmamentoBL.EliminarTipoArmamento(tipoArmamentoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
