using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class ObjetoContratacionController : Controller
    {
        readonly ObjetoContratacionDAO objetoContratacionBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ObjetoContratacionDTO> listaObjetoContratacions = objetoContratacionBL.ObtenerObjetoContratacions();
            return Json(new { data = listaObjetoContratacions });
        }

        public ActionResult InsertarObjetoContratacion(string DescObjetoContratacion, string CodigoObjetoContratacion)
        {
            ObjetoContratacionDTO objetoContratacionDTO = new();
            objetoContratacionDTO.DescObjetoContratacion = DescObjetoContratacion;
            objetoContratacionDTO.CodigoObjetoContratacion = CodigoObjetoContratacion;
            objetoContratacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = objetoContratacionBL.AgregarObjetoContratacion(objetoContratacionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarObjetoContratacion(int ObjetoContratacionId)
        {
            return Json(objetoContratacionBL.BuscarObjetoContratacionID(ObjetoContratacionId));
        }

        public ActionResult ActualizarObjetoContratacion(int ObjetoContratacionId, string DescObjetoContratacion, string CodigoObjetoContratacion)
        {
            ObjetoContratacionDTO objetoContratacionDTO = new();
            objetoContratacionDTO.ObjetoContratacionId = ObjetoContratacionId;
            objetoContratacionDTO.DescObjetoContratacion = DescObjetoContratacion;
            objetoContratacionDTO.CodigoObjetoContratacion = CodigoObjetoContratacion;
            objetoContratacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = objetoContratacionBL.ActualizarObjetoContratacion(objetoContratacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarObjetoContratacion(int ObjetoContratacionId)
        {
            string mensaje = "";

            if (objetoContratacionBL.EliminarObjetoContratacion(ObjetoContratacionId) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
