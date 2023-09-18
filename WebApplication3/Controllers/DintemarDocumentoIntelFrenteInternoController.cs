using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dintemar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dintemar;
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

    public class DintemarDocumentoIntelFrenteInternoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        DocumentoIntelFrenteInternoDAO documentoIntelFrenteInternoBL = new();
        MesDAO mesBL = new();
        DependenciaDAO dependenciaBL = new();
        ZonaNavalDAO zonaNavalBL = new();
        Carga cargaBL = new();

        public DintemarDocumentoIntelFrenteInternoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Documentos de Inteligencia para el Frente Interno", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> mesDTO = mesBL.ObtenerMess();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("DocumentoIntelFrenteInterno");

            return Json(new { data1 = mesDTO, data2 = dependenciaDTO, data3 = zonaNavalDTO, data4 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<DocumentoIntelFrenteInternoDTO> select = documentoIntelFrenteInternoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(int MesId, int AnioDocumentoFrenteInterno, string CodigoDependencia,
           string CodigoZonaNaval, int NotaInformacionProducidoFI, int NotaInteligenciaFI,int ApreciacionInteligenciaFI,
           int ResumenMensualInteligenciaFI, int EstudioInteligenciaFI, int BoletinInformacionFI,int OtrosEspecificarFI, int CargaId)
        {
            DocumentoIntelFrenteInternoDTO documentoIntelFrenteInternoDTO = new();
            documentoIntelFrenteInternoDTO.MesId = MesId;
            documentoIntelFrenteInternoDTO.AnioDocumentoFrenteInterno = AnioDocumentoFrenteInterno;
            documentoIntelFrenteInternoDTO.CodigoDependencia = CodigoDependencia;
            documentoIntelFrenteInternoDTO.CodigoZonaNaval = CodigoZonaNaval;
            documentoIntelFrenteInternoDTO.NotaInformacionProducidoFI = NotaInformacionProducidoFI;
            documentoIntelFrenteInternoDTO.NotaInteligenciaFI = NotaInteligenciaFI;
            documentoIntelFrenteInternoDTO.ApreciacionInteligenciaFI = ApreciacionInteligenciaFI;
            documentoIntelFrenteInternoDTO.ResumenMensualInteligenciaFI = ResumenMensualInteligenciaFI;
            documentoIntelFrenteInternoDTO.EstudioInteligenciaFI = EstudioInteligenciaFI;
            documentoIntelFrenteInternoDTO.BoletinInformacionFI = BoletinInformacionFI;
            documentoIntelFrenteInternoDTO.OtrosEspecificarFI = OtrosEspecificarFI;
            documentoIntelFrenteInternoDTO.CargaId = CargaId;
            documentoIntelFrenteInternoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = documentoIntelFrenteInternoBL.AgregarRegistro(documentoIntelFrenteInternoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(documentoIntelFrenteInternoBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int MesId, int AnioDocumentoFrenteInterno, string CodigoDependencia,
           string CodigoZonaNaval, int NotaInformacionProducidoFI, int NotaInteligenciaFI, int ApreciacionInteligenciaFI,
           int ResumenMensualInteligenciaFI, int EstudioInteligenciaFI, int BoletinInformacionFI, int OtrosEspecificarFI)
        {
            DocumentoIntelFrenteInternoDTO documentoIntelFrenteInternoDTO = new();
            documentoIntelFrenteInternoDTO.DocumentoInteligenciaFrenteInternoId = Id;
            documentoIntelFrenteInternoDTO.MesId = MesId;
            documentoIntelFrenteInternoDTO.AnioDocumentoFrenteInterno = AnioDocumentoFrenteInterno;
            documentoIntelFrenteInternoDTO.CodigoDependencia = CodigoDependencia;
            documentoIntelFrenteInternoDTO.CodigoZonaNaval = CodigoZonaNaval;
            documentoIntelFrenteInternoDTO.NotaInformacionProducidoFI = NotaInformacionProducidoFI;
            documentoIntelFrenteInternoDTO.NotaInteligenciaFI = NotaInteligenciaFI;
            documentoIntelFrenteInternoDTO.ApreciacionInteligenciaFI = ApreciacionInteligenciaFI;
            documentoIntelFrenteInternoDTO.ResumenMensualInteligenciaFI = ResumenMensualInteligenciaFI;
            documentoIntelFrenteInternoDTO.EstudioInteligenciaFI = EstudioInteligenciaFI;
            documentoIntelFrenteInternoDTO.BoletinInformacionFI = BoletinInformacionFI;
            documentoIntelFrenteInternoDTO.OtrosEspecificarFI = OtrosEspecificarFI;
            documentoIntelFrenteInternoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = documentoIntelFrenteInternoBL.ActualizaFormato(documentoIntelFrenteInternoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            DocumentoIntelFrenteInternoDTO documentoIntelFrenteInternoDTO = new();
            documentoIntelFrenteInternoDTO.DocumentoInteligenciaFrenteInternoId = Id;
            documentoIntelFrenteInternoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (documentoIntelFrenteInternoBL.EliminarFormato(documentoIntelFrenteInternoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<DocumentoIntelFrenteInternoDTO> lista = new List<DocumentoIntelFrenteInternoDTO>();
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

                    lista.Add(new DocumentoIntelFrenteInternoDTO
                    {
                        MesId = int.Parse(fila.GetCell(0).ToString()),
                        AnioDocumentoFrenteInterno = int.Parse(fila.GetCell(1).ToString()),
                        CodigoDependencia = fila.GetCell(2).ToString(),
                        CodigoZonaNaval = fila.GetCell(3).ToString(),
                        NotaInformacionProducidoFI = int.Parse(fila.GetCell(4).ToString()),
                        NotaInteligenciaFI = int.Parse(fila.GetCell(5).ToString()),
                        ApreciacionInteligenciaFI = int.Parse(fila.GetCell(6).ToString()),
                        ResumenMensualInteligenciaFI = int.Parse(fila.GetCell(7).ToString()),
                        EstudioInteligenciaFI = int.Parse(fila.GetCell(8).ToString()),
                        BoletinInformacionFI = int.Parse(fila.GetCell(9).ToString()),
                        OtrosEspecificarFI = int.Parse(fila.GetCell(10).ToString()),
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

            dt.Columns.AddRange(new DataColumn[12]
            {
                    new DataColumn("MesId", typeof(int)),
                    new DataColumn("AnioDocumentoFrenteInterno  ", typeof(int)),
                    new DataColumn("CodigoDependencia ", typeof(string)),
                    new DataColumn("CodigoZonaNaval  ", typeof(string)),
                    new DataColumn("NotaInformacionProducidoFI  ", typeof(int)),
                    new DataColumn("NotaInteligenciaFI  ", typeof(int)),
                    new DataColumn("ApreciacionInteligenciaFI  ", typeof(int)),
                    new DataColumn("ResumenMensualInteligenciaFI  ", typeof(int)),
                    new DataColumn("EstudioInteligenciaFI  ", typeof(int)),
                    new DataColumn("BoletinInformacionFI  ", typeof(int)),
                    new DataColumn("OtrosEspecificarFI  ", typeof(int)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    int.Parse(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    int.Parse(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    int.Parse(fila.GetCell(6).ToString()),
                    int.Parse(fila.GetCell(7).ToString()),
                    int.Parse(fila.GetCell(8).ToString()),
                    int.Parse(fila.GetCell(9).ToString()),
                    int.Parse(fila.GetCell(10).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = documentoIntelFrenteInternoBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDDIFI(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dintemar\\DocumentoIntelFrenteInterno.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = documentoIntelFrenteInternoBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DocumentoIntelFrenteInterno", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DocumentoIntelFrenteInterno.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DocumentoIntelFrenteInterno.xlsx");
        }
    }

}

