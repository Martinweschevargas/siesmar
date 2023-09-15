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

    public class DintemarProduccionDocumentosContraintelController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        ProduccionDocumentosContraintelDAO produccionDocumentosContraintelBL = new();
        MesDAO mesBL = new();
        DependenciaDAO dependenciaBL = new();
        ComandanciaDependenciaDAO comandanciaDependenciaBL = new();
        ZonaNavalDAO zonaNavalBL = new();
        Carga cargaBL = new();

        public DintemarProduccionDocumentosContraintelController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Producción de Documentos de Contrainteligencia", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> mesDTO = mesBL.ObtenerMess();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<DependenciaDTO> DependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<ComandanciaDependenciaDTO> ComandanciaDependenciaDTO = comandanciaDependenciaBL.ObtenerComandanciaDependencias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ProduccionDocumentosContraintel");


            return Json(new { data1 = mesDTO, data2 = zonaNavalDTO, data3 = DependenciaDTO, 
                data4 = ComandanciaDependenciaDTO , data5 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<ProduccionDocumentosContraintelDTO> select = produccionDocumentosContraintelBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(int MesId, int AnioProduccionDocumento, string CodigoDependencia, string CodigoComandanciaDependencia, 
            string CodigoZonaNaval, int NotasInformacionContrainteligencia, int NotasContrainteligenciaProducidas, 
            int ApreciacionesContrainteligenciaProducida, int CargaId)
        {
            ProduccionDocumentosContraintelDTO produccionDocumentosContraintelDTO = new();
            produccionDocumentosContraintelDTO.MesId = MesId;
            produccionDocumentosContraintelDTO.AnioProduccionDocumento = AnioProduccionDocumento;
            produccionDocumentosContraintelDTO.CodigoDependencia = CodigoDependencia;
            produccionDocumentosContraintelDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            produccionDocumentosContraintelDTO.CodigoZonaNaval = CodigoZonaNaval;
            produccionDocumentosContraintelDTO.NotasInformacionContrainteligencia = NotasInformacionContrainteligencia;
            produccionDocumentosContraintelDTO.NotasContrainteligenciaProducidas = NotasContrainteligenciaProducidas;
            produccionDocumentosContraintelDTO.ApreciacionesContrainteligenciaProducida = ApreciacionesContrainteligenciaProducida;
            produccionDocumentosContraintelDTO.CargaId = CargaId;
            produccionDocumentosContraintelDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = produccionDocumentosContraintelBL.AgregarRegistro(produccionDocumentosContraintelDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(produccionDocumentosContraintelBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int MesId, int AnioProduccionDocumento, string CodigoDependencia, string CodigoComandanciaDependencia,
            string CodigoZonaNaval, int NotasInformacionContrainteligencia, int NotasContrainteligenciaProducidas,
            int ApreciacionesContrainteligenciaProducida)
        {
            ProduccionDocumentosContraintelDTO produccionDocumentosContraintelDTO = new();
            produccionDocumentosContraintelDTO.ProduccionDocumentosContrainteligenciaId = Id;
            produccionDocumentosContraintelDTO.MesId = MesId;
            produccionDocumentosContraintelDTO.AnioProduccionDocumento = AnioProduccionDocumento;
            produccionDocumentosContraintelDTO.CodigoDependencia = CodigoDependencia;
            produccionDocumentosContraintelDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            produccionDocumentosContraintelDTO.CodigoZonaNaval = CodigoZonaNaval;
            produccionDocumentosContraintelDTO.NotasInformacionContrainteligencia = NotasInformacionContrainteligencia;
            produccionDocumentosContraintelDTO.NotasContrainteligenciaProducidas = NotasContrainteligenciaProducidas;
            produccionDocumentosContraintelDTO.ApreciacionesContrainteligenciaProducida = ApreciacionesContrainteligenciaProducida;
            produccionDocumentosContraintelDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = produccionDocumentosContraintelBL.ActualizaFormato(produccionDocumentosContraintelDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ProduccionDocumentosContraintelDTO produccionDocumentosContraintelDTO = new();
            produccionDocumentosContraintelDTO.ProduccionDocumentosContrainteligenciaId = Id;
            produccionDocumentosContraintelDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (produccionDocumentosContraintelBL.EliminarFormato(produccionDocumentosContraintelDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ProduccionDocumentosContraintelDTO> lista = new List<ProduccionDocumentosContraintelDTO>();
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

                    lista.Add(new ProduccionDocumentosContraintelDTO
                    {
                        MesId = int.Parse(fila.GetCell(0).ToString()),
                        AnioProduccionDocumento = int.Parse(fila.GetCell(1).ToString()),
                        CodigoDependencia = fila.GetCell(2).ToString(),
                        CodigoComandanciaDependencia = fila.GetCell(3).ToString(),
                        CodigoZonaNaval = fila.GetCell(4).ToString(),
                        NotasInformacionContrainteligencia = int.Parse(fila.GetCell(5).ToString()),
                        NotasContrainteligenciaProducidas = int.Parse(fila.GetCell(6).ToString()),
                        ApreciacionesContrainteligenciaProducida = int.Parse(fila.GetCell(7).ToString()),


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
                    new DataColumn("MesId", typeof(int)),
                    new DataColumn("AnioProduccionDocumento", typeof(int)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("CodigoComandanciaDependencia", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("NotasInformacionContrainteligencia", typeof(int)),
                    new DataColumn("NotasContrainteligenciaProducidas ", typeof(int)),
                    new DataColumn("ApreciacionesContrainteligenciaProducida", typeof(int)),

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

                    User.obtenerUsuario());
            }
            var IND_OPERACION = produccionDocumentosContraintelBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDPDC(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dintemar\\ProduccionDocumentosContraintel.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = produccionDocumentosContraintelBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ProduccionDocumentosContraintel", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ProduccionDocumentosContraintel.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ProduccionDocumentosContraintel.xlsx");
        }
    }

}


