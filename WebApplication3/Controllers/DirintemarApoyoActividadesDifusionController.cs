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
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using System.Data;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DirintemarApoyoActividadesDifusionController : Controller
    {

  
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        ApoyoActividadesDifusionDAO actividaddifusionBL = new();
        TipoActividadDifusionDAO TipoActividadDifusionBL = new();
        DepartamentoUbigeoDAO departamentoUBL = new();
        DirigidoADAO dirigidoABL = new();
        public DirintemarApoyoActividadesDifusionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        [Breadcrumb(FromAction = "Index", Title = "Apoyo Actividades Difusión", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }
                [Breadcrumb(FromAction = "Index", Title = "Actividades Culturales Realizadas", FromController = typeof(HomeController))]
        public IActionResult cargaCombs()
        {
            List<TipoActividadDifusionDTO> tipoactividaddifusion = TipoActividadDifusionBL.ObtenerTipoActividadDifusions();
            List<DepartamentoUbigeoDTO> departamentoUbigeo = departamentoUBL.ObtenerDepartamentoUbigeos();
            List<DirigidoADTO> dirigidoADTO = dirigidoABL.ObtenerDirigidoAs();
            return Json(new { data1= tipoactividaddifusion, data2= departamentoUbigeo, data3 = dirigidoADTO });
        }

        public IActionResult CargaTabla()
        {
            List<ApoyoActividadesDifusionDTO> apoyoActividadesDifusionDTO = actividaddifusionBL.ObtenerLista();
            return Json(new { data = apoyoActividadesDifusionDTO });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string CodigoTipoActividadDifusion, string NombreApoyoActividadDifusion, string LugarApoyoActividadDifusion,
           string DepartamentoUbigeo, int DirigidoAId, string InicioApoyoActividadDifusion, string TerminoApoyoActividadDifusion,
           int InversionApoyoActividadDifusion)
        {
            ApoyoActividadesDifusionDTO apoyoActividadesDifusionDTO = new();
            apoyoActividadesDifusionDTO.CodigoTipoActividadDifusion = CodigoTipoActividadDifusion;
            apoyoActividadesDifusionDTO.NombreApoyoActividadDifusion = NombreApoyoActividadDifusion;
            apoyoActividadesDifusionDTO.LugarApoyoActividadDifusion = LugarApoyoActividadDifusion;
            apoyoActividadesDifusionDTO.DepartamentoUbigeo = DepartamentoUbigeo;
            apoyoActividadesDifusionDTO.DirigidoAId = DirigidoAId;
            apoyoActividadesDifusionDTO.InicioApoyoActividadDifusion = InicioApoyoActividadDifusion;
            apoyoActividadesDifusionDTO.TerminoApoyoActividadDifusion = TerminoApoyoActividadDifusion;
            apoyoActividadesDifusionDTO.InversionApoyoActividadDifusion = InversionApoyoActividadDifusion;
            apoyoActividadesDifusionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actividaddifusionBL.AgregarRegistro(apoyoActividadesDifusionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(actividaddifusionBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id,string CodigoTipoActividadDifusion, string NombreApoyoActividadDifusion, string LugarApoyoActividadDifusion,
           string DepartamentoUbigeo, int DirigidoAId, string InicioApoyoActividadDifusion, string TerminoApoyoActividadDifusion,
           int InversionApoyoActividadDifusion)
        {
            ApoyoActividadesDifusionDTO apoyoActividadesDifusionDTO = new();
            apoyoActividadesDifusionDTO.ApoyoActividadDifusionId = Id;
            apoyoActividadesDifusionDTO.CodigoTipoActividadDifusion = CodigoTipoActividadDifusion;
            apoyoActividadesDifusionDTO.NombreApoyoActividadDifusion = NombreApoyoActividadDifusion;
            apoyoActividadesDifusionDTO.LugarApoyoActividadDifusion = LugarApoyoActividadDifusion;
            apoyoActividadesDifusionDTO.DepartamentoUbigeo = DepartamentoUbigeo;
            apoyoActividadesDifusionDTO.DirigidoAId = DirigidoAId;
            apoyoActividadesDifusionDTO.InicioApoyoActividadDifusion = InicioApoyoActividadDifusion;
            apoyoActividadesDifusionDTO.TerminoApoyoActividadDifusion = TerminoApoyoActividadDifusion;
            apoyoActividadesDifusionDTO.InversionApoyoActividadDifusion = InversionApoyoActividadDifusion;
            apoyoActividadesDifusionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actividaddifusionBL.ActualizaFormato(apoyoActividadesDifusionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ApoyoActividadesDifusionDTO apoyoActividadesDifusionDTO = new();
            apoyoActividadesDifusionDTO.ApoyoActividadDifusionId = Id;
            apoyoActividadesDifusionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (actividaddifusionBL.EliminarFormato(apoyoActividadesDifusionDTO) == true)
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

            List<ApoyoActividadesDifusionDTO> lista = new List<ApoyoActividadesDifusionDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new ApoyoActividadesDifusionDTO
                {
                    ApoyoActividadDifusionId = int.Parse(fila.GetCell(0).ToString()),
                    CodigoTipoActividadDifusion = fila.GetCell(1).ToString(),
                    NombreApoyoActividadDifusion = fila.GetCell(2).ToString(),
                    LugarApoyoActividadDifusion = fila.GetCell(3).ToString(),
                    DepartamentoUbigeo = fila.GetCell(4).ToString(),
                    DirigidoAId = int.Parse(fila.GetCell(5).ToString()),
                    InicioApoyoActividadDifusion = fila.GetCell(6).ToString(),
                    TerminoApoyoActividadDifusion = fila.GetCell(7).ToString(),
                    InversionApoyoActividadDifusion = int.Parse(fila.GetCell(8).ToString())
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
                    new DataColumn("CodigoTipoActividadDifusion", typeof(int)),
                    new DataColumn("NombreApoyoActividadDifusion", typeof(string)),
                    new DataColumn("LugarApoyoActividadDifusion", typeof(string)),
                    new DataColumn("DepartamentoUbigeo", typeof(int)),
                    new DataColumn("DirigidoAId", typeof(int)),
                    new DataColumn("InicioApoyoActividadDifusion", typeof(string)),
                    new DataColumn("TerminoApoyoActividadDifusion", typeof(string)),
                    new DataColumn("InversionApoyoActividadDifusion", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    int.Parse(fila.GetCell(3).ToString()),
                    int.Parse(fila.GetCell(4).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                    int.Parse(fila.GetCell(7).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = actividaddifusionBL.InsertarDatos(dt);
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
            var Capitanias = actividaddifusionBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirintemarApoyoActividadesDifusion.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirintemarApoyoActividadesDifusion.xlsx");
        }

    }

}