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
    public class DirintemarTrabajoRestConservController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        TrabajoRestauracionConservacionDAO trabajoRestauracionConservacionBL = new();
        TrabajoRealizadoBienHistoricoDAO trabajorealizadosBL = new();
        public DirintemarTrabajoRestConservController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Trabajos de Restauración y/ó Conservación", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TrabajoRealizadoBienHistoricoDTO> TrabajoRealizadoBienHistoricoDTO = trabajorealizadosBL.ObtenerTrabajoRealizadoBienHistoricos();
            return Json(new { data= TrabajoRealizadoBienHistoricoDTO });
        }

        public IActionResult CargaTabla()
        {
            List<TrabajoRestauracionConservacionDTO> trabajoRestauracionConservacionDTO = trabajoRestauracionConservacionBL.ObtenerLista();
            return Json(new { data = trabajoRestauracionConservacionDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(int TrabajoRealizadoBienHistoricoId, int NroTrabajo, int NroPiezaTratada,
           int NroPersonaRealizanTrabajo, string FechaInicioTrabajoRestConserv, string FechaTerminoTrabajoRestConserv,
           string EncargadoTrabajoRestConserv,string DescripcionTrabajoRealizado, decimal InversionTrabajoRestConserv)
        {
            TrabajoRestauracionConservacionDTO trabajoRestauracionConservacionDTO = new();
            trabajoRestauracionConservacionDTO.TrabajoRealizadoBienHistoricoId = TrabajoRealizadoBienHistoricoId;
            trabajoRestauracionConservacionDTO.NroTrabajo = NroTrabajo;
            trabajoRestauracionConservacionDTO.NroPiezaTratada = NroPiezaTratada;
            trabajoRestauracionConservacionDTO.NroPersonaRealizanTrabajo = NroPersonaRealizanTrabajo;
            trabajoRestauracionConservacionDTO.FechaInicioTrabajoRestConserv = FechaInicioTrabajoRestConserv;
            trabajoRestauracionConservacionDTO.FechaTerminoTrabajoRestConserv = FechaTerminoTrabajoRestConserv;
            trabajoRestauracionConservacionDTO.EncargadoTrabajoRestConserv = EncargadoTrabajoRestConserv;
            trabajoRestauracionConservacionDTO.DescripcionTrabajoRealizado = DescripcionTrabajoRealizado;
            trabajoRestauracionConservacionDTO.InversionTrabajoRestConserv = InversionTrabajoRestConserv;
            trabajoRestauracionConservacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = trabajoRestauracionConservacionBL.AgregarRegistro(trabajoRestauracionConservacionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(trabajoRestauracionConservacionBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int TrabajoRealizadoBienHistoricoId, int NroTrabajo, int NroPiezaTratada,
           int NroPersonaRealizanTrabajo, string FechaInicioTrabajoRestConserv, string FechaTerminoTrabajoRestConserv,
           string EncargadoTrabajoRestConserv, string DescripcionTrabajoRealizado, decimal InversionTrabajoRestConserv)
        {
            TrabajoRestauracionConservacionDTO trabajoRestauracionConservacionDTO = new();
            trabajoRestauracionConservacionDTO.TrabajoRestauracionId = Id;
            trabajoRestauracionConservacionDTO.TrabajoRealizadoBienHistoricoId = TrabajoRealizadoBienHistoricoId;
            trabajoRestauracionConservacionDTO.NroTrabajo = NroTrabajo;
            trabajoRestauracionConservacionDTO.NroPiezaTratada = NroPiezaTratada;
            trabajoRestauracionConservacionDTO.NroPersonaRealizanTrabajo = NroPersonaRealizanTrabajo;
            trabajoRestauracionConservacionDTO.FechaInicioTrabajoRestConserv = FechaInicioTrabajoRestConserv;
            trabajoRestauracionConservacionDTO.FechaTerminoTrabajoRestConserv = FechaTerminoTrabajoRestConserv;
            trabajoRestauracionConservacionDTO.EncargadoTrabajoRestConserv = EncargadoTrabajoRestConserv;
            trabajoRestauracionConservacionDTO.DescripcionTrabajoRealizado = DescripcionTrabajoRealizado;
            trabajoRestauracionConservacionDTO.InversionTrabajoRestConserv = InversionTrabajoRestConserv;

            trabajoRestauracionConservacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = trabajoRestauracionConservacionBL.ActualizaFormato(trabajoRestauracionConservacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            TrabajoRestauracionConservacionDTO trabajoRestauracionConservacionDTO = new();
            trabajoRestauracionConservacionDTO.TrabajoRestauracionId = Id;
            trabajoRestauracionConservacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (trabajoRestauracionConservacionBL.EliminarFormato(trabajoRestauracionConservacionDTO) == true)
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

            List<TrabajoRestauracionConservacionDTO> lista = new List<TrabajoRestauracionConservacionDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new TrabajoRestauracionConservacionDTO
                {
                    TrabajoRealizadoBienHistoricoId = int.Parse(fila.GetCell(0).ToString()),
                    NroTrabajo = int.Parse(fila.GetCell(1).ToString()),
                    NroPiezaTratada = int.Parse(fila.GetCell(2).ToString()),
                    NroPersonaRealizanTrabajo = int.Parse(fila.GetCell(3).ToString()),
                    FechaInicioTrabajoRestConserv = fila.GetCell(4).ToString(),
                    FechaTerminoTrabajoRestConserv = fila.GetCell(5).ToString(),
                    EncargadoTrabajoRestConserv = fila.GetCell(6).ToString(),
                    DescripcionTrabajoRealizado = fila.GetCell(7).ToString(),
                    InversionTrabajoRestConserv = decimal.Parse(fila.GetCell(8).ToString())
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

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("TrabajoRealizadoBienHistoricoId", typeof(int)),
                    new DataColumn("NroTrabajo", typeof(int)),
                    new DataColumn("NroPiezaTratada", typeof(int)),
                    new DataColumn("NroPersonaRealizanTrabajo", typeof(int)),
                    new DataColumn("FechaInicioTrabajoRestConserv", typeof(string)),
                    new DataColumn("FechaTerminoTrabajoRestConserv", typeof(string)),
                    new DataColumn("EncargadoTrabajoRestConserv", typeof(string)),
                    new DataColumn("DescripcionTrabajoRealizado", typeof(string)),
                    new DataColumn("InversionTrabajoRestConserv", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    int.Parse(fila.GetCell(1).ToString()),
                    int.Parse(fila.GetCell(2).ToString()),
                    int.Parse(fila.GetCell(3).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(4).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    decimal.Parse(fila.GetCell(8).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = trabajoRestauracionConservacionBL.InsertarDatos(dt);
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
            var Capitanias = trabajoRestauracionConservacionBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirintemarTrabajoRestConserv.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirintemarTrabajoRestConserv.xlsx");
        }

    }

}