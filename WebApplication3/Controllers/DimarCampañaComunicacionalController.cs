using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dimar;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class DimarCampañaComunicacionalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        CampañaComunicacional campañaComunicacionalBL = new();
        ProductoDimar productoDimarBL = new();
        Dependencia dependenciaBL = new();
        TipoInformacionEmitida tipoInformacionEmitidaBL = new();
        PublicoObjetivo publicoObjetivoBL = new();
        FrecuenciaDifusion frecuenciaDifusionBL = new();
        Carga cargaBL = new();
        public DimarCampañaComunicacionalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Campañas comunicacionales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<ProductoDimarDTO> productoDimarDTO = productoDimarBL.ObtenerProductoDimars();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<TipoInformacionEmitidaDTO> tipoInformacionEmitidaDTO = tipoInformacionEmitidaBL.ObtenerTipoInformacionEmitidas();
            List<PublicoObjetivoDTO> publicoObjetivoDTO = publicoObjetivoBL.ObtenerPublicoObjetivos();
            List<FrecuenciaDifusionDTO> frecuenciaDifusionDTO = frecuenciaDifusionBL.ObtenerFrecuenciaDifusions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("CampañaComunicacional");

            return Json(new
            {
                data1 = productoDimarDTO,
                data2 = dependenciaDTO,
                data3 = tipoInformacionEmitidaDTO,
                data4 = publicoObjetivoDTO,
                data5 = frecuenciaDifusionDTO,
                data6 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<CampañaComunicacionalDTO> select = campañaComunicacionalBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            
            return View();
        }
        public ActionResult Insertar(string CodigoProductoDimar, string FechaPublicacion, string CodigoDependencia,
            string PlataformaMedioPublicacion, string CodigoTipoInformacionEmitida, string CodigoPublicoObjetivo, int CantidadProducida,
            string CodigoFrecuenciaDifusion, decimal CostoCampania, int CargaId)
        {
            CampañaComunicacionalDTO campaniaComunicacionalDTO = new();
            campaniaComunicacionalDTO.CodigoProductoDimar = CodigoProductoDimar;
            campaniaComunicacionalDTO.FechaPublicacion = FechaPublicacion;
            campaniaComunicacionalDTO.CodigoDependencia = CodigoDependencia;
            campaniaComunicacionalDTO.PlataformaMedioPublicacion = PlataformaMedioPublicacion;
            campaniaComunicacionalDTO.CodigoTipoInformacionEmitida = CodigoTipoInformacionEmitida;
            campaniaComunicacionalDTO.CodigoPublicoObjetivo = CodigoPublicoObjetivo;
            campaniaComunicacionalDTO.CantidadProducida = CantidadProducida;
            campaniaComunicacionalDTO.CodigoFrecuenciaDifusion = CodigoFrecuenciaDifusion;
            campaniaComunicacionalDTO.CostoCampania = CostoCampania;
            campaniaComunicacionalDTO.CargaId = CargaId;

            campaniaComunicacionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = campañaComunicacionalBL.AgregarRegistro(campaniaComunicacionalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(campañaComunicacionalBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoProductoDimar, string FechaPublicacion, string CodigoDependencia,
            string PlataformaMedioPublicacion, string CodigoTipoInformacionEmitida, string CodigoPublicoObjetivo, int CantidadProducida,
            string CodigoFrecuenciaDifusion, decimal CostoCampania)
        {
            CampañaComunicacionalDTO campaniaComunicacionalDTO = new();
            campaniaComunicacionalDTO.CampaniaComunicacionalId = Id;
            campaniaComunicacionalDTO.CodigoProductoDimar = CodigoProductoDimar;
            campaniaComunicacionalDTO.FechaPublicacion = FechaPublicacion;
            campaniaComunicacionalDTO.CodigoDependencia = CodigoDependencia;
            campaniaComunicacionalDTO.PlataformaMedioPublicacion = PlataformaMedioPublicacion;
            campaniaComunicacionalDTO.CodigoTipoInformacionEmitida = CodigoTipoInformacionEmitida;
            campaniaComunicacionalDTO.CodigoPublicoObjetivo = CodigoPublicoObjetivo;
            campaniaComunicacionalDTO.CantidadProducida = CantidadProducida;
            campaniaComunicacionalDTO.CodigoFrecuenciaDifusion = CodigoFrecuenciaDifusion;
            campaniaComunicacionalDTO.CostoCampania = CostoCampania;

            campaniaComunicacionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = campañaComunicacionalBL.ActualizarFormato(campaniaComunicacionalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            CampañaComunicacionalDTO campaniaComunicacionalDTO = new();
            campaniaComunicacionalDTO.CampaniaComunicacionalId = Id;
            campaniaComunicacionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (campañaComunicacionalBL.EliminarFormato(campaniaComunicacionalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<CampañaComunicacionalDTO> lista = new List<CampañaComunicacionalDTO>();
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

                    lista.Add(new CampañaComunicacionalDTO
                    {
                        CodigoProductoDimar = fila.GetCell(0).ToString(),
                        FechaPublicacion = fila.GetCell(1).ToString(),
                        CodigoDependencia = fila.GetCell(2).ToString(),
                        PlataformaMedioPublicacion = fila.GetCell(3).ToString(),
                        CodigoTipoInformacionEmitida = fila.GetCell(4).ToString(),
                        CodigoPublicoObjetivo = fila.GetCell(5).ToString(),
                        CantidadProducida = int.Parse(fila.GetCell(6).ToString()),
                        CodigoFrecuenciaDifusion = fila.GetCell(7).ToString(),
                        CostoCampania = decimal.Parse(fila.GetCell(8).ToString()),

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

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("CodigoProductoDimar ", typeof(string)),
                    new DataColumn("FechaPublicacion ", typeof(string)),
                    new DataColumn("CodigoDependencia ", typeof(int)),
                    new DataColumn("PlataformaMedioPublicacion ", typeof(string)),
                    new DataColumn("CodigoTipoInformacionEmitida ", typeof(decimal)),
                    new DataColumn("CodigoPublicoObjetivo ", typeof(string)),
                    new DataColumn("CantidadProducida", typeof(int)),
                    new DataColumn("CodigoFrecuenciaDifusion", typeof(string)),
                    new DataColumn("CostoCampania", typeof(decimal)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    
                    fila.GetCell(0).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    int.Parse(fila.GetCell(6).ToString()),
                    fila.GetCell(7).ToString(),
                    decimal.Parse(fila.GetCell(8).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = campañaComunicacionalBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDCC(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dimar\\CampañaComunicacional.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = campañaComunicacionalBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("CampañaComunicacional", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\CampañaComunicacional.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "CampañaComunicacional.xlsx");
        }
    }

}


