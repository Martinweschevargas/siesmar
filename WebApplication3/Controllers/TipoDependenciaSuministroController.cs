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
    public class TipoDependenciaSuministroController : Controller
    {
        readonly TipoDependenciaSuministroDAO tipoDependenciaSuministroBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Tipos Dependencias Suministros", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<TipoDependenciaSuministroDTO> listaTipoDependenciaSuministros = tipoDependenciaSuministroBL.ObtenerTipoDependenciaSuministros();
            return Json(new { data = listaTipoDependenciaSuministros });
        }

        public ActionResult InsertarTipoDependenciaSuministro(string DescTipoDependenciaSuministro, string CodigoTipoDependenciaSuministro)
        {
            TipoDependenciaSuministroDTO tipoDependenciaSuministroDTO = new();
            tipoDependenciaSuministroDTO.DescTipoDependenciaSuministro = DescTipoDependenciaSuministro;
            tipoDependenciaSuministroDTO.CodigoTipoDependenciaSuministro = CodigoTipoDependenciaSuministro;
            tipoDependenciaSuministroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoDependenciaSuministroBL.AgregarTipoDependenciaSuministro(tipoDependenciaSuministroDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarTipoDependenciaSuministro(int TipoDependenciaSuministroId)
        {
            return Json(tipoDependenciaSuministroBL.BuscarTipoDependenciaSuministroID(TipoDependenciaSuministroId));
        }

        public ActionResult ActualizarTipoDependenciaSuministro(int TipoDependenciaSuministroId, string DescTipoDependenciaSuministro, string CodigoTipoDependenciaSuministro)
        {
            TipoDependenciaSuministroDTO tipoDependenciaSuministroDTO = new();
            tipoDependenciaSuministroDTO.TipoDependenciaSuministroId = TipoDependenciaSuministroId;
            tipoDependenciaSuministroDTO.DescTipoDependenciaSuministro = DescTipoDependenciaSuministro;
            tipoDependenciaSuministroDTO.CodigoTipoDependenciaSuministro = CodigoTipoDependenciaSuministro;
            tipoDependenciaSuministroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = tipoDependenciaSuministroBL.ActualizarTipoDependenciaSuministro(tipoDependenciaSuministroDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarTipoDependenciaSuministro(int TipoDependenciaSuministroId)
        {
            TipoDependenciaSuministroDTO tipoDependenciaSuministroDTO = new();
            tipoDependenciaSuministroDTO.TipoDependenciaSuministroId = TipoDependenciaSuministroId;
            tipoDependenciaSuministroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (tipoDependenciaSuministroBL.EliminarTipoDependenciaSuministro(tipoDependenciaSuministroDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
