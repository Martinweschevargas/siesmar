using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Ipecamar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Ipecamar;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SixLabors.ImageSharp.ColorSpaces;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class IpecamarReporteAcademiaServMilitarController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        ReporteAcademiaServMilitar reporteAcademiaServMilitarBL = new();

        Dependencia dependenciaBL = new();
        ComandanciaDependencia comandanciaDependenciaBL = new();
        ZonaNaval zonaNavalBL = new();
        TemaAcademico temasAcademicosBL = new();
        Carga cargaBL = new();
        public IpecamarReporteAcademiaServMilitarController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Reporte de Academias al Personal del Servicio Militar", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<ComandanciaDependenciaDTO> comandanciaDependenciaDTO = comandanciaDependenciaBL.ObtenerComandanciaDependencias();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<TemaAcademicoDTO> temaAcademicoDTO = temasAcademicosBL.ObtenerCapintanias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ReporteAcademiaServMilitar");

            return Json(new { data1 = dependenciaDTO, data2 = comandanciaDependenciaDTO,  data3 = zonaNavalDTO, data4 = temaAcademicoDTO, data5 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<ReporteAcademiaServMilitarDTO> select = reporteAcademiaServMilitarBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string FechaRegistroReporteAcad, string CodigoDependencia, string CodigoComandanciaDependencia, string CodigoZonaNaval,
           string CodigoTemasAcademicos, int EfectivoActualPerMarReporteAcad, int ParticipantesReporteAcad,int CargaId)
        {
            ReporteAcademiaServMilitarDTO reporteAcademiaServMilitarDTO = new();
            reporteAcademiaServMilitarDTO.FechaRegistroReporteAcad = FechaRegistroReporteAcad;
            reporteAcademiaServMilitarDTO.CodigoDependencia = CodigoDependencia;
            reporteAcademiaServMilitarDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            reporteAcademiaServMilitarDTO.CodigoZonaNaval = CodigoZonaNaval;
            reporteAcademiaServMilitarDTO.CodigoTemasAcademicos = CodigoTemasAcademicos;
            reporteAcademiaServMilitarDTO.EfectivoActualPerMarReporteAcad = EfectivoActualPerMarReporteAcad;
            reporteAcademiaServMilitarDTO.ParticipantesReporteAcad = ParticipantesReporteAcad;
            reporteAcademiaServMilitarDTO.CargaId = CargaId;
            reporteAcademiaServMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = reporteAcademiaServMilitarBL.AgregarRegistro(reporteAcademiaServMilitarDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(reporteAcademiaServMilitarBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaRegistroReporteAcad, string CodigoDependencia, string CodigoComandanciaDependencia, string CodigoZonaNaval,
           string CodigoTemasAcademicos, int EfectivoActualPerMarReporteAcad, int ParticipantesReporteAcad)
        {
            ReporteAcademiaServMilitarDTO reporteAcademiaServMilitarDTO = new();
            reporteAcademiaServMilitarDTO.ReporteAcademiaServMilitarId = Id;
            reporteAcademiaServMilitarDTO.FechaRegistroReporteAcad = FechaRegistroReporteAcad;
            reporteAcademiaServMilitarDTO.CodigoDependencia = CodigoDependencia;
            reporteAcademiaServMilitarDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            reporteAcademiaServMilitarDTO.CodigoZonaNaval = CodigoZonaNaval;
            reporteAcademiaServMilitarDTO.CodigoTemasAcademicos = CodigoTemasAcademicos;
            reporteAcademiaServMilitarDTO.EfectivoActualPerMarReporteAcad = EfectivoActualPerMarReporteAcad;
            reporteAcademiaServMilitarDTO.ParticipantesReporteAcad = ParticipantesReporteAcad;
            reporteAcademiaServMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = reporteAcademiaServMilitarBL.ActualizarFormato(reporteAcademiaServMilitarDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ReporteAcademiaServMilitarDTO reporteAcademiaServMilitarDTO = new();
            reporteAcademiaServMilitarDTO.ReporteAcademiaServMilitarId = Id;
            reporteAcademiaServMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (reporteAcademiaServMilitarBL.EliminarFormato(reporteAcademiaServMilitarDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ReporteAcademiaServMilitarDTO> lista = new List<ReporteAcademiaServMilitarDTO>();
            try
            {
                Stream stream = ArchivoExcel.OpenReadStream();
                IWorkbook? MiExcel = null;

                if (Path.GetExtension(ArchivoExcel.FileName) == ".xlsx")
                {
                    MiExcel = new XSSFWorkbook(stream);
                }
                else
                {
                    MiExcel = new HSSFWorkbook(stream);
                }
                ISheet HojaExcel = MiExcel.GetSheetAt(0);
                int cantidadFilas = HojaExcel.LastRowNum;

                for (int i = 1; i <= cantidadFilas; i++)
                {
                    IRow fila = HojaExcel.GetRow(i);

                    lista.Add(new ReporteAcademiaServMilitarDTO
                    {
                        FechaRegistroReporteAcad = fila.GetCell(0).ToString(),
                        CodigoDependencia = fila.GetCell(1).ToString(),
                        CodigoComandanciaDependencia = fila.GetCell(2).ToString(),
                        CodigoZonaNaval = fila.GetCell(3).ToString(),
                        CodigoTemasAcademicos = fila.GetCell(4).ToString(),
                        EfectivoActualPerMarReporteAcad = int.Parse(fila.GetCell(5).ToString()),
                        ParticipantesReporteAcad = int.Parse(fila.GetCell(6).ToString())
 
                    });
                }
            }
            catch (Exception e)
            {
                Mensaje = "0";
            }
            return Json(new { data = Mensaje, data1 = lista });
        }

        [HttpPost]
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
        {
            Stream stream = ArchivoExcel.OpenReadStream();
            IWorkbook MiExcel = null;

            if (Path.GetExtension(ArchivoExcel.FileName) == ".xlsx")
                MiExcel = new XSSFWorkbook(stream);
            else
                MiExcel = new HSSFWorkbook(stream);

            ISheet HojaExcel = MiExcel.GetSheetAt(0);
            int cantidadFilas = HojaExcel.LastRowNum;

            DataTable dt = new();

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("FechaRegistroReporteAcad", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("CodigoComandanciaDependencia", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("CodigoTemasAcademicos", typeof(string)),
                    new DataColumn("EfectivoActualPerMarReporteAcad", typeof(int)),
                    new DataColumn("ParticipantesReporteAcad", typeof(int)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    int.Parse(fila.GetCell(5).ToString()),
                    int.Parse(fila.GetCell(6).ToString()),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = reporteAcademiaServMilitarBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = reporteAcademiaServMilitarBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\IpecamarReporteAcademiaServMilitar.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "IpecamarReporteAcademiaServMilitar.xlsx");
        }
    }

}

