using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dintemar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
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

    public class DintemarDocumentoIntelFrenteExternoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        DocumentoIntelFrenteExternoDAO documentoIntelFrenteExternoBL = new();
        MesDAO mesBL = new();
        DependenciaDAO dependenciaBL = new();
        ZonaNavalDAO zonaNavalBL = new();
        PaisUbigeoDAO paisUbigeoBL = new();
        Carga cargaBL = new();

        public DintemarDocumentoIntelFrenteExternoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = " Documentos de Inteligencia para el Frente Externo", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> mesDTO = mesBL.ObtenerMess();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<PaisUbigeoDTO> paisUbigeoDTO = paisUbigeoBL.ObtenerPaisUbigeos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("DocumentoIntelFrenteExterno");

            return Json(new { data1 = mesDTO, data2 = dependenciaDTO, data3 = zonaNavalDTO, 
                data4 = paisUbigeoDTO, data5= listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<DocumentoIntelFrenteExternoDTO> select = documentoIntelFrenteExternoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(int MesId, int AnioDocumentoFrenteExterno, string CodigoDependencia,
           string CodigoZonaNaval, string NumericoPais, int NotaInformacionProducidasFE, int NotaInteligenciaFE,
           int ApreciacionInteligenciaFE, int ResumenMensualInteligenciaFE, int EstudioInteligenciaFE, int BoletinInformacionFE,
           int OtrosEspecificarFE, int CargaId)
        {
            DocumentoIntelFrenteExternoDTO documentoIntelFrenteExternoDTO = new();
            documentoIntelFrenteExternoDTO.MesId = MesId;
            documentoIntelFrenteExternoDTO.AnioDocumentoFrenteExterno = AnioDocumentoFrenteExterno;
            documentoIntelFrenteExternoDTO.CodigoDependencia = CodigoDependencia;
            documentoIntelFrenteExternoDTO.CodigoZonaNaval = CodigoZonaNaval;
            documentoIntelFrenteExternoDTO.NumericoPais = NumericoPais;
            documentoIntelFrenteExternoDTO.NotaInformacionProducidasFE = NotaInformacionProducidasFE;
            documentoIntelFrenteExternoDTO.NotaInteligenciaFE = NotaInteligenciaFE;
            documentoIntelFrenteExternoDTO.ApreciacionInteligenciaFE = ApreciacionInteligenciaFE;
            documentoIntelFrenteExternoDTO.ResumenMensualInteligenciaFE = ResumenMensualInteligenciaFE;
            documentoIntelFrenteExternoDTO.EstudioInteligenciaFE = EstudioInteligenciaFE;
            documentoIntelFrenteExternoDTO.BoletinInformacionFE = BoletinInformacionFE;
            documentoIntelFrenteExternoDTO.OtrosEspecificarFE = OtrosEspecificarFE;
            documentoIntelFrenteExternoDTO.CargaId = CargaId;
            documentoIntelFrenteExternoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = documentoIntelFrenteExternoBL.AgregarRegistro(documentoIntelFrenteExternoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(documentoIntelFrenteExternoBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int MesId, int AnioDocumentoFrenteExterno, string CodigoDependencia,
           string CodigoZonaNaval, string NumericoPais, int NotaInformacionProducidasFE, int NotaInteligenciaFE,
           int ApreciacionInteligenciaFE, int ResumenMensualInteligenciaFE, int EstudioInteligenciaFE, int BoletinInformacionFE,
           int OtrosEspecificarFE)
        {
            DocumentoIntelFrenteExternoDTO documentoIntelFrenteExternoDTO = new();
            documentoIntelFrenteExternoDTO.DocumentoInteligenciaFrenteExternoId = Id;
            documentoIntelFrenteExternoDTO.MesId = MesId;
            documentoIntelFrenteExternoDTO.AnioDocumentoFrenteExterno = AnioDocumentoFrenteExterno;
            documentoIntelFrenteExternoDTO.CodigoDependencia = CodigoDependencia;
            documentoIntelFrenteExternoDTO.CodigoZonaNaval = CodigoZonaNaval;
            documentoIntelFrenteExternoDTO.NumericoPais = NumericoPais;
            documentoIntelFrenteExternoDTO.NotaInformacionProducidasFE = NotaInformacionProducidasFE;
            documentoIntelFrenteExternoDTO.NotaInteligenciaFE = NotaInteligenciaFE;
            documentoIntelFrenteExternoDTO.ApreciacionInteligenciaFE = ApreciacionInteligenciaFE;
            documentoIntelFrenteExternoDTO.ResumenMensualInteligenciaFE = ResumenMensualInteligenciaFE;
            documentoIntelFrenteExternoDTO.EstudioInteligenciaFE = EstudioInteligenciaFE;
            documentoIntelFrenteExternoDTO.BoletinInformacionFE = BoletinInformacionFE;
            documentoIntelFrenteExternoDTO.OtrosEspecificarFE = OtrosEspecificarFE;
            documentoIntelFrenteExternoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = documentoIntelFrenteExternoBL.ActualizaFormato(documentoIntelFrenteExternoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            DocumentoIntelFrenteExternoDTO documentoIntelFrenteExternoDTO = new();
            documentoIntelFrenteExternoDTO.DocumentoInteligenciaFrenteExternoId = Id;
            documentoIntelFrenteExternoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (documentoIntelFrenteExternoBL.EliminarFormato(documentoIntelFrenteExternoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<DocumentoIntelFrenteExternoDTO> lista = new List<DocumentoIntelFrenteExternoDTO>();
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

                    lista.Add(new DocumentoIntelFrenteExternoDTO
                    {
                        MesId = int.Parse(fila.GetCell(0).ToString()),
                        AnioDocumentoFrenteExterno = int.Parse(fila.GetCell(1).ToString()),
                        CodigoDependencia = fila.GetCell(2).ToString(),
                        CodigoZonaNaval = fila.GetCell(3).ToString(),
                        NumericoPais = fila.GetCell(4).ToString(),
                        NotaInformacionProducidasFE = int.Parse(fila.GetCell(5).ToString()),
                        NotaInteligenciaFE = int.Parse(fila.GetCell(6).ToString()),
                        ApreciacionInteligenciaFE = int.Parse(fila.GetCell(7).ToString()),
                        ResumenMensualInteligenciaFE = int.Parse(fila.GetCell(8).ToString()),
                        EstudioInteligenciaFE = int.Parse(fila.GetCell(9).ToString()),
                        BoletinInformacionFE = int.Parse(fila.GetCell(10).ToString()),
                        OtrosEspecificarFE = int.Parse(fila.GetCell(11).ToString()),
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

            dt.Columns.AddRange(new DataColumn[13]
            {
                    new DataColumn("MesId", typeof(int)),
                    new DataColumn("AnioDocumentoFrenteExterno ", typeof(int)),
                    new DataColumn("CodigoDependencia ", typeof(string)),
                    new DataColumn("CodigoZonaNaval  ", typeof(string)),
                    new DataColumn("NumericoPais ", typeof(string)),
                    new DataColumn("NotaInformacionProducidasFE ", typeof(int)),
                    new DataColumn("NotaInteligenciaFE ", typeof(int)),
                    new DataColumn("ApreciacionInteligenciaFE ", typeof(int)),
                    new DataColumn("ResumenMensualInteligenciaFE ", typeof(int)),
                    new DataColumn("EstudioInteligenciaFE ", typeof(int)),
                    new DataColumn("BoletinInformacionFE ", typeof(int)),
                    new DataColumn("OtrosEspecificarFE ", typeof(int)),

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
                    fila.GetCell(4).ToString(),
                    int.Parse(fila.GetCell(5).ToString()),
                    int.Parse(fila.GetCell(6).ToString()),
                    int.Parse(fila.GetCell(7).ToString()),
                    int.Parse(fila.GetCell(8).ToString()),
                    int.Parse(fila.GetCell(9).ToString()),
                    int.Parse(fila.GetCell(10).ToString()),
                    int.Parse(fila.GetCell(11).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = documentoIntelFrenteExternoBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDDIFE(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dintemar\\DocumentoIntelFrenteExterno.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = documentoIntelFrenteExternoBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DocumentoIntelFrenteExterno", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DocumentoIntelFrenteExterno.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DocumentoIntelFrenteExterno.xlsx");
        }
    }

}

