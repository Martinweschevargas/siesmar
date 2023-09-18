using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class FormatoReporteController : Controller
    {
        readonly FormatoReporte formatoReporteBL = new();
        readonly Periodo periodoBL = new();
        readonly Dependencia dependenciaBL = new();
        readonly DependenciaSubordinado dependenciaSubordinadoBL = new();
        readonly ILogger<FormatoReporteController> _logger;

        public FormatoReporteController(ILogger<FormatoReporteController> logger)
        {
            _logger = logger;
        }

        [Breadcrumb(FromAction = "Index", Title = "Formatos Reportes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CargarCombos()
        {
            List<PeriodoDTO> listaPeriodos = periodoBL.ObtenerPeriodos();
            List<DependenciaDTO> listaDependencia = dependenciaBL.ObtenerDependenciasSegundoNivel();
            List<DependenciaSubordinadoDTO> listaDependenciaSubordinado = dependenciaSubordinadoBL.ObtenerDependenciaSubordinados();
            return Json(new
            {
                lstPeriodos = listaPeriodos,
                lstDependencia = listaDependencia,
                lstDependenciaSubordinado = listaDependenciaSubordinado
            });
        }

        public IActionResult CargarLista()
        {
            List<FormatoReporteDTO> listaFormatoReportes = formatoReporteBL.ObtenerFormatoReportes();
            return Json(new { data = listaFormatoReportes });
        }

        public ActionResult InsertarFormatoReporte(string Nombre, string Controlador, int PeriodoId, string Flag, string Dependencia, string DependenciaSubordinada, int Nivel)
        {
            var IND_OPERACION = "";
            try
            {
                FormatoReporteDTO formatoReporteDTO = new FormatoReporteDTO();
                formatoReporteDTO.NombreFormatoReporte = Nombre;
                formatoReporteDTO.ControladorFormatoReporte = Controlador;
                formatoReporteDTO.PeriodoId = PeriodoId;
                formatoReporteDTO.Flag = Flag;
                if (Nivel == 0)
                {
                    formatoReporteDTO.DependenciaId = null;
                    formatoReporteDTO.DependenciaSubordinadaId = null;
                }
                if (Nivel == 1)
                {
                    formatoReporteDTO.DependenciaId = Dependencia;
                    formatoReporteDTO.DependenciaSubordinadaId = null;
                }
                if (Nivel == 2)
                {
                    formatoReporteDTO.DependenciaId = null;
                    formatoReporteDTO.DependenciaSubordinadaId = DependenciaSubordinada;
                }
                formatoReporteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = formatoReporteBL.AgregarFormatoReporte(formatoReporteDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }
        public ActionResult MostrarFormatoReporte(int FormatoReporteId)
        {
            return Json(formatoReporteBL.BuscarFormatoReporte(FormatoReporteId));
        }

        public ActionResult ActualizarFormatoReporte(int Codigo, string Nombre, string Controlador, int PeriodoId, string Flag, string Dependencia, string DpendenciaSubordinada, int Nivel)
        {
            var IND_OPERACION = "";
            try
            {
                FormatoReporteDTO formatoReporteDTO = new FormatoReporteDTO();
                formatoReporteDTO.FormatoReporteId = Codigo;
                formatoReporteDTO.ControladorFormatoReporte = Controlador;
                formatoReporteDTO.NombreFormatoReporte = Nombre;
                formatoReporteDTO.PeriodoId = PeriodoId;
                formatoReporteDTO.Flag = Flag;
                if (Nivel == 0)
                {
                    formatoReporteDTO.DependenciaId = null;
                    formatoReporteDTO.DependenciaSubordinadaId = null;
                }
                if (Nivel == 1)
                {
                    formatoReporteDTO.DependenciaId = Dependencia;
                    formatoReporteDTO.DependenciaSubordinadaId = null;
                }
                if (Nivel == 2)
                {
                    formatoReporteDTO.DependenciaId = null;
                    formatoReporteDTO.DependenciaSubordinadaId = DpendenciaSubordinada;
                }
                formatoReporteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = formatoReporteBL.ActualizaFormatoReporte(formatoReporteDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarFormatoReporte(int FormatoReporteId)
        {
            var IND_OPERACION = "";
            try
            {
                FormatoReporteDTO formatoReporteDTO = new FormatoReporteDTO();

                formatoReporteDTO.FormatoReporteId = FormatoReporteId;
                formatoReporteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = formatoReporteBL.EliminarFormatoReporte(formatoReporteDTO);

                //_logger.LogWarning(IND_OPERACION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Content(IND_OPERACION);
        }
    }

}
