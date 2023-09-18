using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dirintemar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Atp;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DirintemarRepresMonumentoHistoricoController : Controller
    {


        private readonly IWebHostEnvironment _webHostEnviroment;
        RepresMonumentoHistoricoDAO represMonumentoHistoricoBL = new();
        TipoRepresentacionBienHistoricoDAO tiporepresenbienhBL = new();
        TipoMaterialBienHistoricoDAO tipomaterialbienHBL = new();
        DistritoUbigeoDAO distritoUbigeoBL = new();
        ProvinciaUbigeoDAO provinciaUbigeoBL = new();
        DepartamentoUbigeoDAO departamentoUBL = new();
        PaisUbigeoDAO paisUbigeoBL = new();

        public DirintemarRepresMonumentoHistoricoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        [Breadcrumb(FromAction = "Index", Title = "Representaición y/o Monumentos Historicos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoMaterialBienHistoricoDTO> select1 = tipomaterialbienHBL.ObtenerTipoMaterialBienHistoricos();
            List<DistritoUbigeoDTO> select2 = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<ProvinciaUbigeoDTO> select3 = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<PaisUbigeoDTO> select4 = paisUbigeoBL.ObtenerPaisUbigeos();
            List<DepartamentoUbigeoDTO> select5 = departamentoUBL.ObtenerDepartamentoUbigeos();
            List<TipoRepresentacionBienHistoricoDTO> select6 = tiporepresenbienhBL.ObtenerTipoRepresentacionBienHistoricos();
            return Json(new { data1 = select1, data2 = select2, data3 = select3, data4 = select4, data5 = select5, data6 = select6 });
        }

        public IActionResult CargaTabla()
        {
            List<RepresMonumentoHistoricoDTO> represMonumentoHistoricoDTO = represMonumentoHistoricoBL.ObtenerLista();
            return Json(new { data = represMonumentoHistoricoDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]

        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(int TipoRepresentacionBienHistoricoId, string DenominacionRepresMonumentoHistorico, int TipoMaterialBienHistoricoId,
           string EstadoConservacion, string NombreEscultor, string FechaEntregaInaguracion, string UbicacionRepresentacion,
           int DistritoUbigeoId, string CustorioMonumentoHistorico,  string ReferenciaMonumentoHistorico, decimal InversionMonumentoHistorico)
        {
            RepresMonumentoHistoricoDTO represMonumentoHistoricoDTO = new();
            represMonumentoHistoricoDTO.TipoRepresentacionBienHistoricoId = TipoRepresentacionBienHistoricoId;
            represMonumentoHistoricoDTO.DenominacionRepresMonumentoHistorico = DenominacionRepresMonumentoHistorico;
            represMonumentoHistoricoDTO.TipoMaterialBienHistoricoId = TipoMaterialBienHistoricoId;
            represMonumentoHistoricoDTO.EstadoConservacion = EstadoConservacion;
            represMonumentoHistoricoDTO.NombreEscultor = NombreEscultor;
            represMonumentoHistoricoDTO.FechaEntregaInaguracion = FechaEntregaInaguracion;
            represMonumentoHistoricoDTO.UbicacionRepresentacion = UbicacionRepresentacion;
            represMonumentoHistoricoDTO.DistritoUbigeoId = DistritoUbigeoId;
            represMonumentoHistoricoDTO.CustorioMonumentoHistorico = CustorioMonumentoHistorico;
            represMonumentoHistoricoDTO.ReferenciaMonumentoHistorico = ReferenciaMonumentoHistorico;
            represMonumentoHistoricoDTO.InversionMonumentoHistorico = InversionMonumentoHistorico;
            represMonumentoHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = represMonumentoHistoricoBL.AgregarRegistro(represMonumentoHistoricoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(represMonumentoHistoricoBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int TipoRepresentacionBienHistoricoId, string DenominacionRepresMonumentoHistorico, int TipoMaterialBienHistoricoId,
           string EstadoConservacion, string NombreEscultor, string FechaEntregaInaguracion, string UbicacionRepresentacion,
           int DistritoUbigeoId, string CustorioMonumentoHistorico, string ReferenciaMonumentoHistorico, decimal InversionMonumentoHistorico)
        {
            RepresMonumentoHistoricoDTO represMonumentoHistoricoDTO = new();
            represMonumentoHistoricoDTO.RepresMonumentoHistoricoId = Id;
            represMonumentoHistoricoDTO.TipoRepresentacionBienHistoricoId = TipoRepresentacionBienHistoricoId;
            represMonumentoHistoricoDTO.DenominacionRepresMonumentoHistorico = DenominacionRepresMonumentoHistorico;
            represMonumentoHistoricoDTO.TipoMaterialBienHistoricoId = TipoMaterialBienHistoricoId;
            represMonumentoHistoricoDTO.EstadoConservacion = EstadoConservacion;
            represMonumentoHistoricoDTO.NombreEscultor = NombreEscultor;
            represMonumentoHistoricoDTO.FechaEntregaInaguracion = FechaEntregaInaguracion;
            represMonumentoHistoricoDTO.UbicacionRepresentacion = UbicacionRepresentacion;
            represMonumentoHistoricoDTO.DistritoUbigeoId = DistritoUbigeoId;
            represMonumentoHistoricoDTO.CustorioMonumentoHistorico = CustorioMonumentoHistorico;
            represMonumentoHistoricoDTO.ReferenciaMonumentoHistorico = ReferenciaMonumentoHistorico;
            represMonumentoHistoricoDTO.InversionMonumentoHistorico = InversionMonumentoHistorico;
            represMonumentoHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = represMonumentoHistoricoBL.ActualizaFormato(represMonumentoHistoricoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RepresMonumentoHistoricoDTO represMonumentoHistoricoDTO = new();
            represMonumentoHistoricoDTO.RepresMonumentoHistoricoId = Id;
            represMonumentoHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (represMonumentoHistoricoBL.EliminarFormato(represMonumentoHistoricoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
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

            List<RepresMonumentoHistoricoDTO> lista = new List<RepresMonumentoHistoricoDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new RepresMonumentoHistoricoDTO
                {
                    TipoRepresentacionBienHistoricoId = int.Parse(fila.GetCell(0).ToString()),
                    DenominacionRepresMonumentoHistorico = fila.GetCell(1).ToString(),
                    TipoMaterialBienHistoricoId = int.Parse(fila.GetCell(2).ToString()),
                    EstadoConservacion = fila.GetCell(3).ToString(),
                    NombreEscultor = fila.GetCell(4).ToString(),
                    FechaEntregaInaguracion = fila.GetCell(5).ToString(),
                    UbicacionRepresentacion = fila.GetCell(6).ToString(),
                    DistritoUbigeoId = int.Parse(fila.GetCell(7).ToString()),
                    CustorioMonumentoHistorico = fila.GetCell(11).ToString(),
                    ReferenciaMonumentoHistorico = fila.GetCell(12).ToString(),
                    InversionMonumentoHistorico = decimal.Parse(fila.GetCell(13).ToString()),
                });
            }
            return StatusCode(StatusCodes.Status200OK, lista);
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
                    new DataColumn("TipoRepresentacionBienHistoricoId", typeof(int)),
                    new DataColumn("DenominacionRepresMonumentoHistorico", typeof(string)),
                    new DataColumn("TipoMaterialBienHistoricoId", typeof(int)),
                    new DataColumn("EstadoConservacion", typeof(string)),
                    new DataColumn("NombreEscultor", typeof(string)),
                    new DataColumn("FechaEntregaInaguracion", typeof(string)),
                    new DataColumn("UbicacionRepresentacion", typeof(string)),
                    new DataColumn("DistritoUbigeoId", typeof(int)),
                    new DataColumn("CustorioMonumentoHistorico", typeof(string)),
                    new DataColumn("ReferenciaMonumentoHistorico", typeof(string)),
                    new DataColumn("InversionMonumentoHistorico", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    int.Parse(fila.GetCell(2).ToString()),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                    fila.GetCell(6).ToString(),
                    int.Parse(fila.GetCell(7).ToString()),
                    fila.GetCell(11).ToString(),
                    fila.GetCell(12).ToString(),
                    decimal.Parse(fila.GetCell(13).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = represMonumentoHistoricoBL.InsertarDatos(dt);
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
            var Capitanias = represMonumentoHistoricoBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirintemarRepresMonumentoHistorico.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirintemarRepresMonumentoHistorico.xlsx");
        }

    }

}