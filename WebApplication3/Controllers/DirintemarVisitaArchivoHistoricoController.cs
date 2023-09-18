using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dirintemar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Atp;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Security.Claims;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using System.Data;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DirintemarVisitaArchivoHistoricoController : Controller
    {

        CapitaniaDAO capitaniaBL = new();
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        VisitaArchivoHistoricoDAO visitaarchivoHBL = new();
        TipoVisitaGeneralDAO tipovistaBL = new();

        public DirintemarVisitaArchivoHistoricoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Visita Archivo Histórico de la Marina", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoVisitaGeneralDTO> tipovisita = tipovistaBL.ObtenerTipoVisitaGenerals();
            return Json(new { data= tipovisita });
        }

        public IActionResult CargaTabla()
        {
            List<VisitaArchivoHistoricoDTO> visitaArchivoHistoricoDTO = visitaarchivoHBL.ObtenerLista();
            return Json(new { data = visitaArchivoHistoricoDTO });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string FechaVisitaArchivoHistorico, string VisitanteArchivoHistorico, string DocIdentidadVisita,
           int TipoVisitaGeneralId, string EntidadVisita, string TemaArchivoHistorico, string NacionalidadVisitante)
        {
            VisitaArchivoHistoricoDTO visitaArchivoHistoricoDTO = new();
            visitaArchivoHistoricoDTO.FechaVisitaArchivoHistorico = FechaVisitaArchivoHistorico;
            visitaArchivoHistoricoDTO.VisitanteArchivoHistorico = VisitanteArchivoHistorico;
            visitaArchivoHistoricoDTO.DocIdentidadVisita = DocIdentidadVisita;
            visitaArchivoHistoricoDTO.TipoVisitaGeneralId = TipoVisitaGeneralId;
            visitaArchivoHistoricoDTO.EntidadVisita = EntidadVisita;
            visitaArchivoHistoricoDTO.TemaArchivoHistorico = TemaArchivoHistorico;
            visitaArchivoHistoricoDTO.NacionalidadVisitante = NacionalidadVisitante;
            visitaArchivoHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = visitaarchivoHBL.AgregarRegistro(visitaArchivoHistoricoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(visitaarchivoHBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaVisitaArchivoHistorico, string VisitanteArchivoHistorico, string DocIdentidadVisita,
           int TipoVisitaGeneralId, string EntidadVisita, string TemaArchivoHistorico, string NacionalidadVisitante)
        {
            VisitaArchivoHistoricoDTO visitaArchivoHistoricoDTO = new();
            visitaArchivoHistoricoDTO.VisitaArchivoHistoricoId = Id;
            visitaArchivoHistoricoDTO.FechaVisitaArchivoHistorico = FechaVisitaArchivoHistorico;
            visitaArchivoHistoricoDTO.VisitanteArchivoHistorico = VisitanteArchivoHistorico;
            visitaArchivoHistoricoDTO.DocIdentidadVisita = DocIdentidadVisita;
            visitaArchivoHistoricoDTO.TipoVisitaGeneralId = TipoVisitaGeneralId;
            visitaArchivoHistoricoDTO.EntidadVisita = EntidadVisita;
            visitaArchivoHistoricoDTO.TemaArchivoHistorico = TemaArchivoHistorico;
            visitaArchivoHistoricoDTO.NacionalidadVisitante = NacionalidadVisitante;
            visitaArchivoHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = visitaarchivoHBL.ActualizaFormato(visitaArchivoHistoricoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            VisitaArchivoHistoricoDTO visitaArchivoHistoricoDTO = new();
            visitaArchivoHistoricoDTO.VisitaArchivoHistoricoId = Id;
            visitaArchivoHistoricoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (visitaarchivoHBL.EliminarFormato(visitaArchivoHistoricoDTO) == true)
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

            List<VisitaArchivoHistoricoDTO> lista = new List<VisitaArchivoHistoricoDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new VisitaArchivoHistoricoDTO
                {
                    VisitaArchivoHistoricoId = int.Parse(fila.GetCell(0).ToString()),
                    FechaVisitaArchivoHistorico = fila.GetCell(1).ToString(),
                    VisitanteArchivoHistorico = fila.GetCell(2).ToString(),
                    DocIdentidadVisita = fila.GetCell(3).ToString(),
                    TipoVisitaGeneralId = int.Parse(fila.GetCell(4).ToString()),
                    EntidadVisita = fila.GetCell(5).ToString(),
                    TemaArchivoHistorico = fila.GetCell(6).ToString(),
                    NacionalidadVisitante = fila.GetCell(7).ToString()
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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("FechaVisitaArchivoHistorico", typeof(string)),
                    new DataColumn("VisitanteArchivoHistorico", typeof(string)),
                    new DataColumn("DocIdentidadVisita", typeof(string)),
                    new DataColumn("TipoVisitaGeneralId", typeof(int)),
                    new DataColumn("EntidadVisita", typeof(string)),
                    new DataColumn("TemaArchivoHistorico", typeof(string)),
                    new DataColumn("NacionalidadVisitante", typeof(string)),

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
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = visitaarchivoHBL.InsertarDatos(dt);
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
            var Capitanias = capitaniaBL.ObtenerCapitanias();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirintemarVisitaArchivoHistorico.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirintemarVisitaArchivoHistorico.xlsx");
        }

    }

}