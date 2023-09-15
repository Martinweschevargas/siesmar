using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dimar;
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

    public class DimarAccesoInformacionPublicaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        AccesoInformacionPublica accesoInformacionPublicaBL = new();
        Carga cargaBL = new();

        public DimarAccesoInformacionPublicaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Pedido de Acceso a la información Pública ", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AccesoInformacionPublica");

            return Json(new
            {
                data1 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<AccesoInformacionPublicaDTO> select = accesoInformacionPublicaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string FechaRecepcion, string NumeroDocumento, string FechaDocumento, 
            string Administrado, string Asunto, string DocumentoRespuesta, string FechaUsuario, 
            decimal MontoRecaudado, int TiempoRespuestaDias, int CargaId)
        {
            AccesoInformacionPublicaDTO acesoInformacionPublicaDTO = new();
            acesoInformacionPublicaDTO.FechaRecepcion = FechaRecepcion;
            acesoInformacionPublicaDTO.NumeroDocumento = NumeroDocumento;
            acesoInformacionPublicaDTO.FechaDocumento = FechaDocumento;
            acesoInformacionPublicaDTO.Administrado = Administrado;
            acesoInformacionPublicaDTO.Asunto = Asunto;
            acesoInformacionPublicaDTO.DocumentoRespuesta = DocumentoRespuesta;
            acesoInformacionPublicaDTO.FechaUsuario = FechaUsuario;
            acesoInformacionPublicaDTO.MontoRecaudado = MontoRecaudado;
            acesoInformacionPublicaDTO.TiempoRespuestaDias = TiempoRespuestaDias;
            acesoInformacionPublicaDTO.CargaId = CargaId;

            acesoInformacionPublicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = accesoInformacionPublicaBL.AgregarRegistro(acesoInformacionPublicaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(accesoInformacionPublicaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaRecepcion, string NumeroDocumento, string FechaDocumento, string Administrado, string Asunto, string DocumentoRespuesta, string FechaUsuario, decimal MontoRecaudado, int TiempoRespuestaDias)
        {
            AccesoInformacionPublicaDTO acesoInformacionPublicaDTO = new();
            acesoInformacionPublicaDTO.AccesoInformacionPublicaId = Id;
            acesoInformacionPublicaDTO.FechaRecepcion = FechaRecepcion;
            acesoInformacionPublicaDTO.NumeroDocumento = NumeroDocumento;
            acesoInformacionPublicaDTO.FechaDocumento = FechaDocumento;
            acesoInformacionPublicaDTO.Administrado = Administrado;
            acesoInformacionPublicaDTO.Asunto = Asunto;
            acesoInformacionPublicaDTO.DocumentoRespuesta = DocumentoRespuesta;
            acesoInformacionPublicaDTO.FechaUsuario = FechaUsuario;
            acesoInformacionPublicaDTO.MontoRecaudado = MontoRecaudado;
            acesoInformacionPublicaDTO.TiempoRespuestaDias = TiempoRespuestaDias;
            
            acesoInformacionPublicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = accesoInformacionPublicaBL.ActualizarFormato(acesoInformacionPublicaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AccesoInformacionPublicaDTO acesoInformacionPublicaDTO = new();
            acesoInformacionPublicaDTO.AccesoInformacionPublicaId = Id;
            acesoInformacionPublicaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (accesoInformacionPublicaBL.EliminarFormato(acesoInformacionPublicaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AccesoInformacionPublicaDTO> lista = new List<AccesoInformacionPublicaDTO>();
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

                    lista.Add(new AccesoInformacionPublicaDTO
                    {
                        FechaRecepcion = fila.GetCell(0).ToString(),
                        NumeroDocumento = fila.GetCell(1).ToString(),
                        FechaDocumento = fila.GetCell(2).ToString(),
                        Administrado = fila.GetCell(3).ToString(),
                        Asunto = fila.GetCell(4).ToString(),
                        DocumentoRespuesta = fila.GetCell(5).ToString(),
                        FechaUsuario = fila.GetCell(6).ToString(),
                        MontoRecaudado = decimal.Parse(fila.GetCell(7).ToString()),
                        TiempoRespuestaDias = int.Parse(fila.GetCell(8).ToString()),

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
                    new DataColumn("FechaRecepcion ", typeof(string)),
                    new DataColumn("NumeroDocumento ", typeof(string)),
                    new DataColumn("FechaDocumento ", typeof(string)),
                    new DataColumn("Administrado", typeof(string)),
                    new DataColumn("Asunto ", typeof(string)),
                    new DataColumn("DocumentoRespuesta", typeof(string)),
                    new DataColumn("FechaUsuario", typeof(string)),
                    new DataColumn("MontoRecaudado", typeof(decimal)),
                    new DataColumn("TiempoRespuestaDias", typeof(int)),


                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                    decimal.Parse(fila.GetCell(7).ToString()),
                    int.Parse(fila.GetCell(8).ToString()),
                   

                    User.obtenerUsuario());
            }
            var IND_OPERACION = accesoInformacionPublicaBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDAIP(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dimar\\AccesoInformacionPublica.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = accesoInformacionPublicaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("AccesoInformacionPublica", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\AccesoInformacionPublica.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "AccesoInformacionPublica.xlsx");
        }
    }

}

