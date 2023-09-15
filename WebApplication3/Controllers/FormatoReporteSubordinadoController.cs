using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class FormatoReporteSubordinadoController : Controller
    {
        FormatoReporteSubordinado formatoreportesubordinadoBL = new();
        DependenciaSubordinado dependenciaSubordinadoBL = new();
        FormatoReporte formatoReporteBL = new();
        Usuario usuarioBL = new();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargarDatos()
        {
            List<FormatoReporteSubordinadoDTO> listaFormatoReporteSubordinados = formatoreportesubordinadoBL.ObtenerFormatoReporteSubordinados();
            return Json(listaFormatoReporteSubordinados);
        }
        public IActionResult cargarDatosFormatoReporteCB()
        {
            List<FormatoReporteDTO> listaFormatoReportes = formatoReporteBL.ObtenerFormatoReportes();
            return Json(listaFormatoReportes);
        }
        public IActionResult cargarDatosDependenciaSubordinadoCB()
        {
            List<DependenciaSubordinadoDTO> listaDependenciaSubordinados = dependenciaSubordinadoBL.ObtenerDependenciaSubordinados();
            return Json(listaDependenciaSubordinados);
        }
        public ActionResult InsertarFormatoReporteSubordinado(int FormatoReporteId, int DependenciaSubordinadoId)
        {
            FormatoReporteSubordinadoDTO formatoreportesubordinadoDTO = new();
            formatoreportesubordinadoDTO.FormatoReporteId = FormatoReporteId;
            formatoreportesubordinadoDTO.DependenciaSubordinadoId = DependenciaSubordinadoId;
            formatoreportesubordinadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";
            if (formatoreportesubordinadoBL.AgregarFormatoReporteSubordinado(formatoreportesubordinadoDTO) == true)
                mensaje = "..FormatoReporteSubordinado Resgistrada..";
            else
                mensaje = "..FormatoReporteSubordinado No Resgistrada..";

            return Content(mensaje);
        }
        public ActionResult MostrarFormatoReporteSubordinado(int FormatoReporteSubordinadoId)
        {
            return Json(formatoreportesubordinadoBL.EditarFormatoReporteSubordinado(FormatoReporteSubordinadoId));
        }


        public ActionResult ActualizarFormatoReporteSubordinado(int FormatoReporteSubordinadoId, int FormatoReporteId, 
            int DependenciaSubordinadoId)
        {
            FormatoReporteSubordinadoDTO formatoreportesubordinadoDTO = new();
            
            formatoreportesubordinadoDTO.FormatoReporteSubordinadoId = FormatoReporteSubordinadoId;
            formatoreportesubordinadoDTO.FormatoReporteId = FormatoReporteId;
            formatoreportesubordinadoDTO.DependenciaSubordinadoId = DependenciaSubordinadoId;

            string mensaje = "";

            if (formatoreportesubordinadoBL.ActualizaFormatoReporteSubordinado(formatoreportesubordinadoDTO) == true)
                mensaje = "..FormatoReporteSubordinado Actualizada..";
            else
                mensaje = "..FormatoReporteSubordinado No Actualizada..";

            return Content(mensaje);
        }

        public ActionResult EliminarFormatoReporteSubordinado(int FormatoReporteSubordinadoId)
        {
            string mensaje = "";

            if (formatoreportesubordinadoBL.EliminarFormatoReporteSubordinado(FormatoReporteSubordinadoId) == true)
                mensaje = "..FormatoReporteSubordinado Eliminada..";
            else
                mensaje = "..FormatoReporteSubordinado No Eliminada..";

            return Content(mensaje);
        }

    }

}
