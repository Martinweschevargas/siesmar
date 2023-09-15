using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Ipecamar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
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

    public class IpecamarReporteQuejasSugerPServMilitarController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        ReporteQuejasSugerPServMilitarDAO ReporteQuejasSugerPServMilitarBL = new();

        Dependencia dependenciaBL = new();
        ComandanciaDependencia comandanciaDependenciaBL = new();
        ZonaNaval zonaNavalBL = new();
        TipoNovedad tipoNovedad = new();
        Carga cargaBL = new();

        public IpecamarReporteQuejasSugerPServMilitarController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Reporte de quejas, Denuncias, Solicitudes, Sugerencias, Consultas y Requerimientos del Personal del Servicio Militar", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<ComandanciaDependenciaDTO> comandanciaDependenciaDTO = comandanciaDependenciaBL.ObtenerComandanciaDependencias();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<TipoNovedadDTO> tipoNovedadDTO = tipoNovedad.ObtenerTipoNovedads();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ReporteQuejasSugerPServMilitar");


            return Json(new { data1 = dependenciaDTO, data2 = comandanciaDependenciaDTO,  data3 = zonaNavalDTO,  data4 = tipoNovedadDTO ,  data5 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<ReporteQuejasSugerPServMilitarDTO> select = ReporteQuejasSugerPServMilitarBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string FechaRegistroQuejaSuger, string CodigoDependencia, string CodigoComandanciaDependencia, string CodigoZonaNaval,
           string CodigoTipoNovedad, string SituacionPersonalQuejasSuger, string CategoriaQuejasSuger, string AccionTomadaQuejasSuger)
        {
            ReporteQuejasSugerPServMilitarDTO reporteQuejasSugerPServMilitarDTO = new();
            reporteQuejasSugerPServMilitarDTO.FechaRegistroQuejaSuger = FechaRegistroQuejaSuger;
            reporteQuejasSugerPServMilitarDTO.CodigoDependencia = CodigoDependencia;
            reporteQuejasSugerPServMilitarDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            reporteQuejasSugerPServMilitarDTO.CodigoZonaNaval = CodigoZonaNaval;
            reporteQuejasSugerPServMilitarDTO.CodigoTipoNovedad = CodigoTipoNovedad;
            reporteQuejasSugerPServMilitarDTO.SituacionPersonalQuejasSuger = SituacionPersonalQuejasSuger;
            reporteQuejasSugerPServMilitarDTO.CategoriaQuejasSuger = CategoriaQuejasSuger;
            reporteQuejasSugerPServMilitarDTO.AccionTomadaQuejasSuger = AccionTomadaQuejasSuger;
            reporteQuejasSugerPServMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ReporteQuejasSugerPServMilitarBL.AgregarRegistro(reporteQuejasSugerPServMilitarDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(ReporteQuejasSugerPServMilitarBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaRegistroQuejaSuger, string CodigoDependencia, string CodigoComandanciaDependencia, string CodigoZonaNaval,
           string CodigoTipoNovedad, string SituacionPersonalQuejasSuger, string CategoriaQuejasSuger, string AccionTomadaQuejasSuger)
        {
            ReporteQuejasSugerPServMilitarDTO reporteQuejasSugerPServMilitarDTO = new();
            reporteQuejasSugerPServMilitarDTO.ReporteQuejaSugerPServMilitarId = Id;
            reporteQuejasSugerPServMilitarDTO.FechaRegistroQuejaSuger = FechaRegistroQuejaSuger;
            reporteQuejasSugerPServMilitarDTO.CodigoDependencia = CodigoDependencia;
            reporteQuejasSugerPServMilitarDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            reporteQuejasSugerPServMilitarDTO.CodigoZonaNaval = CodigoZonaNaval;
            reporteQuejasSugerPServMilitarDTO.CodigoTipoNovedad = CodigoTipoNovedad;
            reporteQuejasSugerPServMilitarDTO.SituacionPersonalQuejasSuger = SituacionPersonalQuejasSuger;
            reporteQuejasSugerPServMilitarDTO.CategoriaQuejasSuger = CategoriaQuejasSuger;
            reporteQuejasSugerPServMilitarDTO.AccionTomadaQuejasSuger = AccionTomadaQuejasSuger;
            reporteQuejasSugerPServMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ReporteQuejasSugerPServMilitarBL.ActualizaFormato(reporteQuejasSugerPServMilitarDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ReporteQuejasSugerPServMilitarDTO reporteQuejasSugerPServMilitarDTO = new();
            reporteQuejasSugerPServMilitarDTO.ReporteQuejaSugerPServMilitarId = Id;
            reporteQuejasSugerPServMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (ReporteQuejasSugerPServMilitarBL.EliminarFormato(reporteQuejasSugerPServMilitarDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ReporteQuejasSugerPServMilitarDTO> lista = new List<ReporteQuejasSugerPServMilitarDTO>();
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

                    lista.Add(new ReporteQuejasSugerPServMilitarDTO
                    {
                        FechaRegistroQuejaSuger = fila.GetCell(0).ToString(),
                        CodigoDependencia = fila.GetCell(1).ToString(),
                        CodigoComandanciaDependencia = fila.GetCell(2).ToString(),
                        CodigoZonaNaval = fila.GetCell(3).ToString(),
                        CodigoTipoNovedad = fila.GetCell(4).ToString(),
                        SituacionPersonalQuejasSuger = fila.GetCell(5).ToString(),
                        CategoriaQuejasSuger = fila.GetCell(6).ToString(),
                        AccionTomadaQuejasSuger = fila.GetCell(7).ToString()
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

            dt.Columns.AddRange(new DataColumn[9]
            {
                    new DataColumn("FechaRegistroQuejaSuger", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("CodigoComandanciaDependencia", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("CodigoTipoNovedad", typeof(string)),
                    new DataColumn("SituacionPersonalQuejasSuger", typeof(string)),
                    new DataColumn("CategoriaQuejasSuger", typeof(string)),
                    new DataColumn("AccionTomadaQuejasSuger", typeof(string)),
 
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
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = ReporteQuejasSugerPServMilitarBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\IpecamarReporteQuejasSugerPServMilitar.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "IpecamarReporteQuejasSugerPServMilitar.xlsx");
        }

        public IActionResult ReporteEIHN()
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = ReporteQuejasSugerPServMilitarBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }



    }

}

