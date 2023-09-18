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
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class DimarRevistaInstitucionalMonitorGrumeteController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        RevistaInstitucionalMonitorGrumete revistaInstitucionalMonitorGrumeteBL = new();
        ProductoDimar productoDimarBL = new();
        FrecuenciaDifusion frecuenciaDifusionBL = new();
        TipoInformacionEmitida tipoInformacionEmitidaBL = new();
        PlataformaMedioComunicacion plataformaMedioComunicacionBL = new();
        PublicoObjetivo publicoObjetivoBL = new();
        Carga cargaBL = new();

        public DimarRevistaInstitucionalMonitorGrumeteController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Revistas Institucionales “El Monitor” y el “Grumete”", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<ProductoDimarDTO> productoDimarDTO = productoDimarBL.ObtenerProductoDimars();
            List<FrecuenciaDifusionDTO> frecuenciaDifusionDTO = frecuenciaDifusionBL.ObtenerFrecuenciaDifusions();
            List<TipoInformacionEmitidaDTO> tipoInformacionEmitidaDTO = tipoInformacionEmitidaBL.ObtenerTipoInformacionEmitidas();
            List<PlataformaMedioComunicacionDTO> plataformaMedioComunicacionDTO = plataformaMedioComunicacionBL.ObtenerPlataformaMedioComunicacions();
            List<PublicoObjetivoDTO> publicoObjetivoDTO = publicoObjetivoBL.ObtenerPublicoObjetivos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("RevistaInstitucionalMonitorGrumete");

            return Json(new
            {
                data1 = productoDimarDTO,
                data2 = frecuenciaDifusionDTO,
                data3 = tipoInformacionEmitidaDTO,
                data4 = plataformaMedioComunicacionDTO,
                data5 = publicoObjetivoDTO,
                data6 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<RevistaInstitucionalMonitorGrumeteDTO> select = revistaInstitucionalMonitorGrumeteBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string CodigoProductoDimar, string CodigoFrecuenciaDifusion, string FechaPublicacion, int NroEdicion,
            string CodigoTipoInformacionEmitida, string CodigoPlataformaMedioComunicacion, 
            string CodigoPublicoObjetivo, int CantidadProducida, int CargaId)
        {
            RevistaInstitucionalMonitorGrumeteDTO revistaInstitucionalMonitorGrumeteDTO = new();
            revistaInstitucionalMonitorGrumeteDTO.CodigoProductoDimar = CodigoProductoDimar;
            revistaInstitucionalMonitorGrumeteDTO.CodigoFrecuenciaDifusion = CodigoFrecuenciaDifusion;
            revistaInstitucionalMonitorGrumeteDTO.FechaPublicacion = FechaPublicacion;
            revistaInstitucionalMonitorGrumeteDTO.NroEdicion = NroEdicion;
            revistaInstitucionalMonitorGrumeteDTO.CodigoTipoInformacionEmitida = CodigoTipoInformacionEmitida;
            revistaInstitucionalMonitorGrumeteDTO.CodigoPlataformaMedioComunicacion = CodigoPlataformaMedioComunicacion;
            revistaInstitucionalMonitorGrumeteDTO.CodigoPublicoObjetivo = CodigoPublicoObjetivo;
            revistaInstitucionalMonitorGrumeteDTO.CantidadProducida = CantidadProducida;
            revistaInstitucionalMonitorGrumeteDTO.CargaId = CargaId;
            revistaInstitucionalMonitorGrumeteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = revistaInstitucionalMonitorGrumeteBL.AgregarRegistro(revistaInstitucionalMonitorGrumeteDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(revistaInstitucionalMonitorGrumeteBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoProductoDimar, string CodigoFrecuenciaDifusion, string FechaPublicacion, int NroEdicion,
            string CodigoTipoInformacionEmitida, string CodigoPlataformaMedioComunicacion,
            string CodigoPublicoObjetivo, int CantidadProducida)
        {
            RevistaInstitucionalMonitorGrumeteDTO revistaInstitucionalMonitorGrumeteDTO = new();
            revistaInstitucionalMonitorGrumeteDTO.RevistaInstitucionalMonitorGrumeteId = Id;
            revistaInstitucionalMonitorGrumeteDTO.CodigoProductoDimar = CodigoProductoDimar;
            revistaInstitucionalMonitorGrumeteDTO.CodigoFrecuenciaDifusion = CodigoFrecuenciaDifusion;
            revistaInstitucionalMonitorGrumeteDTO.FechaPublicacion = FechaPublicacion;
            revistaInstitucionalMonitorGrumeteDTO.NroEdicion = NroEdicion;
            revistaInstitucionalMonitorGrumeteDTO.CodigoTipoInformacionEmitida = CodigoTipoInformacionEmitida;
            revistaInstitucionalMonitorGrumeteDTO.CodigoPlataformaMedioComunicacion = CodigoPlataformaMedioComunicacion;
            revistaInstitucionalMonitorGrumeteDTO.CodigoPublicoObjetivo = CodigoPublicoObjetivo;
            revistaInstitucionalMonitorGrumeteDTO.CantidadProducida = CantidadProducida;

            
            revistaInstitucionalMonitorGrumeteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = revistaInstitucionalMonitorGrumeteBL.ActualizarFormato(revistaInstitucionalMonitorGrumeteDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RevistaInstitucionalMonitorGrumeteDTO revistaInstitucionalMonitorGrumeteDTO = new();
            revistaInstitucionalMonitorGrumeteDTO.RevistaInstitucionalMonitorGrumeteId = Id;
            revistaInstitucionalMonitorGrumeteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (revistaInstitucionalMonitorGrumeteBL.EliminarFormato(revistaInstitucionalMonitorGrumeteDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<RevistaInstitucionalMonitorGrumeteDTO> lista = new List<RevistaInstitucionalMonitorGrumeteDTO>();
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

                    lista.Add(new RevistaInstitucionalMonitorGrumeteDTO
                    {
                        CodigoProductoDimar = fila.GetCell(0).ToString(),
                        CodigoFrecuenciaDifusion = fila.GetCell(1).ToString(),
                        FechaPublicacion = fila.GetCell(2).ToString(),
                        NroEdicion = int.Parse(fila.GetCell(3).ToString()),
                        CodigoTipoInformacionEmitida = fila.GetCell(4).ToString(),
                        CodigoPlataformaMedioComunicacion = fila.GetCell(5).ToString(),
                        CodigoPublicoObjetivo = fila.GetCell(6).ToString(),
                        CantidadProducida = int.Parse(fila.GetCell(7).ToString()),

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
                    new DataColumn("CodigoProductoDimar", typeof(string)),
                    new DataColumn("CodigoFrecuenciaDifusion ", typeof(string)),
                    new DataColumn("FechaPublicacion ", typeof(string)),
                    new DataColumn("NroEdicion ", typeof(int)),
                    new DataColumn("CodigoTipoInformacionEmitida ", typeof(string)),
                    new DataColumn("CodigoPlataformaMedioComunicacion ", typeof(string)),
                    new DataColumn("CodigoPublicoObjetivo", typeof(string)),
                    new DataColumn("CantidadProducida ", typeof(int)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(

                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                    int.Parse(fila.GetCell(3).ToString()),
                    decimal.Parse(fila.GetCell(1).ToString()),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    int.Parse(fila.GetCell(7).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = revistaInstitucionalMonitorGrumeteBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDRIMG(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dimar\\RevistaInstitucionalMonitorGrumete.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = revistaInstitucionalMonitorGrumeteBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("RevistaInstitucionalMonitorGrumete", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\RevistaInstitucionalMonitorGrumete.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "RevistaInstitucionalMonitorGrumete.xlsx");
        }
    }

}

