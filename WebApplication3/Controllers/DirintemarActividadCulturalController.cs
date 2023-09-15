using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dirintemar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Dirciten;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Formatos.Dirintemar;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
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
    public class DirintemarActividadCulturalController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        ActividadCultural actividadCulturalBL = new();
        TipoActividadCultural tipoactividadculturalBL = new();
        public DirintemarActividadCulturalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Actividades Culturales Realizadas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoActividadCulturalDTO> tipoActividadCulturalDTO = tipoactividadculturalBL.ObtenerTipoActividadCulturals();
            return Json(new { data = tipoActividadCulturalDTO }); 
        }

        public IActionResult CargaTabla()
        {
            List<ActividadCulturalDTO> actividadCulturalDTO = actividadCulturalBL.ObtenerLista();
            return Json(new { data = actividadCulturalDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string NombreActividadCultural, int TipoActividadCulturalId, string FechaInicioActCultural,
           string FechaTerminoActCultural, string LugarActCultural, string AuspiciadoresActCultural, int NParticipantesActCultural,
           decimal InversionActCultural)
        {
            ActividadCulturalDTO actividadCulturalDTO = new();
            actividadCulturalDTO.NombreActividadCultural = NombreActividadCultural;
            actividadCulturalDTO.TipoActividadCulturalId = TipoActividadCulturalId;
            actividadCulturalDTO.FechaInicioActCultural = FechaInicioActCultural;
            actividadCulturalDTO.FechaTerminoActCultural = FechaTerminoActCultural;
            actividadCulturalDTO.LugarActCultural = LugarActCultural;
            actividadCulturalDTO.AuspiciadoresActCultural = AuspiciadoresActCultural;
            actividadCulturalDTO.NParticipantesActCultural = NParticipantesActCultural;
            actividadCulturalDTO.InversionActCultural = InversionActCultural;
            actividadCulturalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actividadCulturalBL.AgregarRegistro(actividadCulturalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(actividadCulturalBL.EditarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string NombreActividadCultural, int TipoActividadCulturalId, string FechaInicioActCultural,
           string FechaTerminoActCultural, string LugarActCultural, string AuspiciadoresActCultural, int NParticipantesActCultural,
           decimal InversionActCultural)
        {
            ActividadCulturalDTO actividadCulturalDTO = new();
            actividadCulturalDTO.ActividadCulturalId = Id;
            actividadCulturalDTO.NombreActividadCultural = NombreActividadCultural;
            actividadCulturalDTO.TipoActividadCulturalId = TipoActividadCulturalId;
            actividadCulturalDTO.FechaInicioActCultural = FechaInicioActCultural;
            actividadCulturalDTO.FechaTerminoActCultural = FechaTerminoActCultural;
            actividadCulturalDTO.LugarActCultural = LugarActCultural;
            actividadCulturalDTO.AuspiciadoresActCultural = AuspiciadoresActCultural;
            actividadCulturalDTO.NParticipantesActCultural = NParticipantesActCultural;
            actividadCulturalDTO.InversionActCultural = InversionActCultural;
            actividadCulturalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actividadCulturalBL.ActualizarFormato(actividadCulturalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ActividadCulturalDTO actividadCulturalDTO = new();
            actividadCulturalDTO.ActividadCulturalId = Id;
            actividadCulturalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (actividadCulturalBL.EliminarFormato(actividadCulturalDTO) == true)
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

            List<ActividadCulturalDTO> lista = new List<ActividadCulturalDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new ActividadCulturalDTO
                {
                    ActividadCulturalId = int.Parse(fila.GetCell(0).ToString()),
                    NombreActividadCultural = fila.GetCell(1).ToString(),
                    TipoActividadCulturalId = int.Parse(fila.GetCell(2).ToString()),
                    FechaInicioActCultural = fila.GetCell(3).ToString(),
                    FechaTerminoActCultural = fila.GetCell(4).ToString(),
                    LugarActCultural = fila.GetCell(5).ToString(),
                    AuspiciadoresActCultural = fila.GetCell(6).ToString(),
                    NParticipantesActCultural = int.Parse(fila.GetCell(7).ToString()),
                    InversionActCultural = decimal.Parse(fila.GetCell(8).ToString())
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

            dt.Columns.AddRange(new DataColumn[9]
            {
                    new DataColumn("NombreActividadCultural", typeof(string)),
                    new DataColumn("TipoActividadCulturalId", typeof(int)),
                    new DataColumn("FechaInicioActCultural", typeof(string)),
                    new DataColumn("FechaTerminoActCultural", typeof(string)),
                    new DataColumn("LugarActCultural", typeof(string)),
                    new DataColumn("AuspiciadoresActCultural", typeof(string)),
                    new DataColumn("NParticipantesActCultural", typeof(int)),
                    new DataColumn("InversionActCultural", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    int.Parse(fila.GetCell(1).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    int.Parse(fila.GetCell(6).ToString()),
                    decimal.Parse(fila.GetCell(7).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = actividadCulturalBL.InsertarDatos(dt);
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
            var Capitanias = actividadCulturalBL.ObtenerLista();
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