using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dicapi;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dicapi;
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
    public class DicapiExpTransporteMercanciaSustanciaController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ExpTransporteMercanciaSustancia expTransporteMercanciaSustanciaBL = new();
        DptoMercanciaPeligrosa dptoMercanciaPeligrosaBL = new();
        ClaseNave claseNaveBL = new();
        PaisUbigeo paisUbigeoBL = new();
        Carga cargaBL = new();

        public DicapiExpTransporteMercanciaSustanciaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Expedición de Documentos para el Transporte Marítimo de Mercancías y Sustancias Peligrosas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DptoMercanciaPeligrosaDTO> dptoMercanciaPeligrosaDTO = dptoMercanciaPeligrosaBL.ObtenerDptoMercanciaPeligrosas(); 
            List<ClaseNaveDTO> claseNaveDTO = claseNaveBL.ObtenerClaseNaves();
            List<PaisUbigeoDTO> paisUbigeoDTO = paisUbigeoBL.ObtenerPaisUbigeos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ExpTransporteMercanciaSustancia");

            return Json(new
            {
                data1 = dptoMercanciaPeligrosaDTO,
                data2 = claseNaveDTO,
                data3 = paisUbigeoDTO,
                data4 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ExpTransporteMercanciaSustanciaDTO> expTransporteMercanciaSustanciaDTO = expTransporteMercanciaSustanciaBL.ObtenerLista();
            return Json(new { data = expTransporteMercanciaSustanciaDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int NumeroDocumento, string CodigoDptoMercanciaPeligrosa, int DocumentoExpedido, string CodigoClaseNave, string NumericoPais, 
            string PropietarioNave, string NombreNave, string FechaIngresoSolicitud, string FechaAtencionSolicitud , string RazonSocial , 
            string MatriculaNave)
        {
            ExpTransporteMercanciaSustanciaDTO expTransporteMercanciaSustanciaDTO = new();
            expTransporteMercanciaSustanciaDTO.NumeroDocumento = NumeroDocumento;
            expTransporteMercanciaSustanciaDTO.FechaIngresoSolicitud = FechaIngresoSolicitud;
            expTransporteMercanciaSustanciaDTO.CodigoDptoMercanciaPeligrosa = CodigoDptoMercanciaPeligrosa;
            expTransporteMercanciaSustanciaDTO.DocumentoExpedido = DocumentoExpedido;
            expTransporteMercanciaSustanciaDTO.NombreNave = NombreNave;
            expTransporteMercanciaSustanciaDTO.PropietarioNave = PropietarioNave;
            expTransporteMercanciaSustanciaDTO.RazonSocial = RazonSocial;
            expTransporteMercanciaSustanciaDTO.CodigoClaseNave = CodigoClaseNave;
            expTransporteMercanciaSustanciaDTO.MatriculaNave = MatriculaNave;
            expTransporteMercanciaSustanciaDTO.NumericoPais = NumericoPais;
            expTransporteMercanciaSustanciaDTO.FechaAtencionSolicitud = FechaAtencionSolicitud;
            expTransporteMercanciaSustanciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = expTransporteMercanciaSustanciaBL.AgregarRegistro(expTransporteMercanciaSustanciaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(expTransporteMercanciaSustanciaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int ExpTransporteMercanciaSustanciaId, int NumeroDocumento, string CodigoDptoMercanciaPeligrosa, int DocumentoExpedido, string CodigoClaseNave, string NumericoPais,
            string PropietarioNave, string NombreNave, string FechaIngresoSolicitud, string FechaAtencionSolicitud, string RazonSocial,
            string MatriculaNave)
        {
            ExpTransporteMercanciaSustanciaDTO expTransporteMercanciaSustanciaDTO = new();
            expTransporteMercanciaSustanciaDTO.ExpTransporteMercanciaSustanciaId = ExpTransporteMercanciaSustanciaId;
            expTransporteMercanciaSustanciaDTO.NumeroDocumento = NumeroDocumento;
            expTransporteMercanciaSustanciaDTO.FechaIngresoSolicitud = FechaIngresoSolicitud;
            expTransporteMercanciaSustanciaDTO.CodigoDptoMercanciaPeligrosa = CodigoDptoMercanciaPeligrosa;
            expTransporteMercanciaSustanciaDTO.DocumentoExpedido = DocumentoExpedido;
            expTransporteMercanciaSustanciaDTO.NombreNave = NombreNave;
            expTransporteMercanciaSustanciaDTO.PropietarioNave = PropietarioNave;
            expTransporteMercanciaSustanciaDTO.RazonSocial = RazonSocial;
            expTransporteMercanciaSustanciaDTO.CodigoClaseNave = CodigoClaseNave;
            expTransporteMercanciaSustanciaDTO.MatriculaNave = MatriculaNave;
            expTransporteMercanciaSustanciaDTO.NumericoPais = NumericoPais;
            expTransporteMercanciaSustanciaDTO.FechaAtencionSolicitud = FechaAtencionSolicitud;
            expTransporteMercanciaSustanciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = expTransporteMercanciaSustanciaBL.ActualizarFormato(expTransporteMercanciaSustanciaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ExpTransporteMercanciaSustanciaDTO expTransporteMercanciaSustanciaDTO = new();
            expTransporteMercanciaSustanciaDTO.ExpTransporteMercanciaSustanciaId = Id;
            expTransporteMercanciaSustanciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (expTransporteMercanciaSustanciaBL.EliminarFormato(expTransporteMercanciaSustanciaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ExpTransporteMercanciaSustanciaDTO> lista = new List<ExpTransporteMercanciaSustanciaDTO>();
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

                    lista.Add(new ExpTransporteMercanciaSustanciaDTO
                    {
                        NumeroDocumento = int.Parse(fila.GetCell(0).ToString()),
                        FechaIngresoSolicitud = fila.GetCell(1).ToString(),
                        CodigoDptoMercanciaPeligrosa = fila.GetCell(2).ToString(),
                        DocumentoExpedido = int.Parse(fila.GetCell(3).ToString()),
                        NombreNave = fila.GetCell(4).ToString(),
                        PropietarioNave = fila.GetCell(5).ToString(),
                        RazonSocial = fila.GetCell(6).ToString(),
                        CodigoClaseNave = fila.GetCell(7).ToString(),
                        MatriculaNave = fila.GetCell(8).ToString(),
                        NumericoPais = fila.GetCell(9).ToString(),
                        FechaAtencionSolicitud = fila.GetCell(10).ToString()
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
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
        {
            Stream stream = ArchivoExcel.OpenReadStream();
            var mensaje = "";

            IWorkbook MiExcel = null;

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
            DataTable dt = new();

            dt.Columns.AddRange(new DataColumn[12]
            {
                    new DataColumn("NumeroDocumento", typeof(int)),
                    new DataColumn("FechaIngresoSolicitud", typeof(string)),
                    new DataColumn("CodigoDptoMercanciaPeligrosa", typeof(string)),
                    new DataColumn("DocumentoExpedido", typeof(string)),
                    new DataColumn("NombreNave", typeof(string)),
                    new DataColumn("PropietarioNave", typeof(int)),
                    new DataColumn("RazonSocial", typeof(string)),
                    new DataColumn("CodigoClaseNave", typeof(string)),
                    new DataColumn("MatriculaNave", typeof(string)),
                    new DataColumn("NumericoPais", typeof(string)),
                    new DataColumn("FechaAtencionSolicitud", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = expTransporteMercanciaSustanciaBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            LocalReport localReport = new LocalReport(path);
            var result=localReport.Execute(RenderType.Pdf,extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        public IActionResult Print2()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report2.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            var Capitanias = expTransporteMercanciaSustanciaBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirintemarActividadCultural.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirintemarActividadCultural.xlsx");
        }
    }

}