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

    public class DimarEmisionFotografiaVideoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EmisionFotografiaVideo emisionFotografiaVideoBL = new();
        ProductoDimar productoDimarBL = new();
        Carga cargaBL = new();

        public DimarEmisionFotografiaVideoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Emisión de fotografías y videos institucionales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<ProductoDimarDTO> productoDimarDTO = productoDimarBL.ObtenerProductoDimars();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EmisionFotografiaVideo");

            return Json(new
            {
                data1 = productoDimarDTO,
                data2 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<EmisionFotografiaVideoDTO> select = emisionFotografiaVideoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string FechaEmisionFotoVideo, string TipoCosto, string CodigoProductoDimar,
            int Cantidad, decimal MontoRecaudado, int CargaId)
        {
            EmisionFotografiaVideoDTO emisionFotografiaVideoDTO = new();
            emisionFotografiaVideoDTO.FechaEmisionFotoVideo = FechaEmisionFotoVideo;
            emisionFotografiaVideoDTO.TipoCosto = TipoCosto;
            emisionFotografiaVideoDTO.CodigoProductoDimar = CodigoProductoDimar;
            emisionFotografiaVideoDTO.Cantidad = Cantidad;
            emisionFotografiaVideoDTO.MontoRecaudado = MontoRecaudado;
            emisionFotografiaVideoDTO.CargaId = CargaId;
            emisionFotografiaVideoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = emisionFotografiaVideoBL.AgregarRegistro(emisionFotografiaVideoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(emisionFotografiaVideoBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaEmisionFotoVideo, string TipoCosto, string CodigoProductoDimar,
            int Cantidad, decimal MontoRecaudado)
        {
            EmisionFotografiaVideoDTO emisionFotografiaVideoDTO = new();
            emisionFotografiaVideoDTO.EmisionFotografiaVideoId = Id;
            emisionFotografiaVideoDTO.FechaEmisionFotoVideo = FechaEmisionFotoVideo;
            emisionFotografiaVideoDTO.TipoCosto = TipoCosto;
            emisionFotografiaVideoDTO.CodigoProductoDimar = CodigoProductoDimar;
            emisionFotografiaVideoDTO.Cantidad = Cantidad;
            emisionFotografiaVideoDTO.MontoRecaudado = MontoRecaudado;
            
            emisionFotografiaVideoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = emisionFotografiaVideoBL.ActualizarFormato(emisionFotografiaVideoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EmisionFotografiaVideoDTO emisionFotografiaVideoDTO = new();
            emisionFotografiaVideoDTO.EmisionFotografiaVideoId = Id;
            emisionFotografiaVideoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (emisionFotografiaVideoBL.EliminarFormato(emisionFotografiaVideoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EmisionFotografiaVideoDTO> lista = new List<EmisionFotografiaVideoDTO>();
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

                    lista.Add(new EmisionFotografiaVideoDTO
                    {
                        FechaEmisionFotoVideo = fila.GetCell(0).ToString(),
                        TipoCosto = fila.GetCell(1).ToString(),
                        CodigoProductoDimar = fila.GetCell(2).ToString(),
                        Cantidad = int.Parse(fila.GetCell(3).ToString()),
                        MontoRecaudado = decimal.Parse(fila.GetCell(4).ToString()),

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

            dt.Columns.AddRange(new DataColumn[6]
            {
                    new DataColumn("FechaEmisionFotoVideo ", typeof(string)),
                    new DataColumn("TipoCosto ", typeof(string)),
                    new DataColumn("CodigoProductoDimar ", typeof(string)),
                    new DataColumn("Cantidad ", typeof(int)),
                    new DataColumn("MontoRecaudado ", typeof(decimal)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(

                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    int.Parse(fila.GetCell(3).ToString()),
                    decimal.Parse(fila.GetCell(4).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = emisionFotografiaVideoBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDEFV(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dimar\\EmisionFotografiaVideo.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = emisionFotografiaVideoBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EmisionFotografiaVideo", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\EmisionFotografiaVideo.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "EmisionFotografiaVideo.xlsx");
        }
    }

}