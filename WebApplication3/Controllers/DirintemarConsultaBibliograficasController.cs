using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dirintemar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Atp;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Security.Claims;
using WebApplication3.Controllers;
using SmartBreadcrumbs.Attributes;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using System.Data;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DirintemarConsultaBibliograficasController : Controller
    {

        CapitaniaDAO capitaniaBL = new();
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        ConsultaBibliograficasDAO consultabibliograficasBL = new();

        public DirintemarConsultaBibliograficasController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        [Breadcrumb(FromAction = "Index", Title = "Consultas Bibliográficas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<ConsultaBibliograficasDTO> select = consultabibliograficasBL.ObtenerLista();
            return Json(new { data=select});
        }

        public IActionResult CargaTabla()
        {
            List<ConsultaBibliograficasDTO> consultaBibliograficasDAO = consultabibliograficasBL.ObtenerLista();
            return Json(new { data = consultaBibliograficasDAO });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string FechaConsultaBibliografica, int LibroPrestadoConsultaB, int PublicacionPrestadaConsultaB,
           int RevistaPrestada, int FolletoPrestado, int LecturaInterna, int ReferenciaBibliografica,
           int BusquedaEnSistema, int TotalConsultaBibliografica, int UsuariosLectoresConsultasB)
        {
            ConsultaBibliograficasDTO consultaBibliograficasDAO = new();
            consultaBibliograficasDAO.FechaConsultaBibliografica = FechaConsultaBibliografica;
            consultaBibliograficasDAO.LibroPrestadoConsultaB = LibroPrestadoConsultaB;
            consultaBibliograficasDAO.PublicacionePrestadaConsultaB = PublicacionPrestadaConsultaB;
            consultaBibliograficasDAO.RevistaPrestada = RevistaPrestada;
            consultaBibliograficasDAO.FolletoPrestado = FolletoPrestado;
            consultaBibliograficasDAO.LecturaInterna = LecturaInterna;
            consultaBibliograficasDAO.ReferenciaBibliografica = ReferenciaBibliografica;
            consultaBibliograficasDAO.BusquedaEnSistema = BusquedaEnSistema;
            consultaBibliograficasDAO.TotalConsultaBibliografica = TotalConsultaBibliografica;
            consultaBibliograficasDAO.UsuariosLectoresConsultasB = UsuariosLectoresConsultasB;
            consultaBibliograficasDAO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = consultabibliograficasBL.AgregarRegistro(consultaBibliograficasDAO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(consultabibliograficasBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaConsultaBibliografica, int LibroPrestadoConsultaB, int PublicacionePrestadaConsultaB,
           int RevistaPrestada, int FolletoPrestado, int LecturaInterna, int ReferenciaBibliografica,
           int BusquedaEnSistema, int TotalConsultaBibliografica, int UsuariosLectoresConsultasB)
        {
            ConsultaBibliograficasDTO consultaBibliograficasDAO = new();
            consultaBibliograficasDAO.ConsultaBibliograficaId = Id;
            consultaBibliograficasDAO.FechaConsultaBibliografica = FechaConsultaBibliografica;
            consultaBibliograficasDAO.LibroPrestadoConsultaB = LibroPrestadoConsultaB;
            consultaBibliograficasDAO.PublicacionePrestadaConsultaB = PublicacionePrestadaConsultaB;
            consultaBibliograficasDAO.RevistaPrestada = RevistaPrestada;
            consultaBibliograficasDAO.FolletoPrestado = FolletoPrestado;
            consultaBibliograficasDAO.LecturaInterna = LecturaInterna;
            consultaBibliograficasDAO.ReferenciaBibliografica = ReferenciaBibliografica;
            consultaBibliograficasDAO.BusquedaEnSistema = BusquedaEnSistema;
            consultaBibliograficasDAO.TotalConsultaBibliografica = TotalConsultaBibliografica;
            consultaBibliograficasDAO.UsuariosLectoresConsultasB = UsuariosLectoresConsultasB;
            consultaBibliograficasDAO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = consultabibliograficasBL.ActualizaFormato(consultaBibliograficasDAO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ConsultaBibliograficasDTO consultaBibliograficasDAO = new();
            consultaBibliograficasDAO.ConsultaBibliograficaId = Id;
            consultaBibliograficasDAO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (consultabibliograficasBL.EliminarFormato(consultaBibliograficasDAO) == true)
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

            List<ConsultaBibliograficasDTO> lista = new List<ConsultaBibliograficasDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new ConsultaBibliograficasDTO
                {
                    ConsultaBibliograficaId = int.Parse(fila.GetCell(0).ToString()),
                    FechaConsultaBibliografica = fila.GetCell(1).ToString(),
                    LibroPrestadoConsultaB = int.Parse(fila.GetCell(2).ToString()),
                    PublicacionePrestadaConsultaB = int.Parse(fila.GetCell(3).ToString()),
                    RevistaPrestada = int.Parse(fila.GetCell(4).ToString()),
                    FolletoPrestado = int.Parse(fila.GetCell(5).ToString()),
                    LecturaInterna = int.Parse(fila.GetCell(6).ToString()),
                    ReferenciaBibliografica = int.Parse(fila.GetCell(7).ToString()),
                    BusquedaEnSistema = int.Parse(fila.GetCell(8).ToString()),
                    TotalConsultaBibliografica = int.Parse(fila.GetCell(9).ToString()),
                    UsuariosLectoresConsultasB = int.Parse(fila.GetCell(10).ToString()),
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

            dt.Columns.AddRange(new DataColumn[11]
            {
                    new DataColumn("FechaConsultaBibliografica", typeof(string)),
                    new DataColumn("LibroPrestadoConsultaB", typeof(int)),
                    new DataColumn("PublicacionePrestadaConsultaB", typeof(int)),
                    new DataColumn("RevistaPrestada", typeof(int)),
                    new DataColumn("FolletoPrestado", typeof(int)),
                    new DataColumn("LecturaInterna", typeof(int)),
                    new DataColumn("ReferenciaBibliografica", typeof(int)),
                    new DataColumn("BusquedaEnSistema", typeof(int)),
                    new DataColumn("TotalConsultaBibliografica", typeof(int)),
                    new DataColumn("UsuariosLectoresConsultasB", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    int.Parse(fila.GetCell(1).ToString()),
                    int.Parse(fila.GetCell(2).ToString()),
                    int.Parse(fila.GetCell(3).ToString()),
                    int.Parse(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    int.Parse(fila.GetCell(6).ToString()),
                    int.Parse(fila.GetCell(7).ToString()),
                    int.Parse(fila.GetCell(8).ToString()),
                    int.Parse(fila.GetCell(9).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = consultabibliograficasBL.InsertarDatos(dt);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirintemarConsultaBibliograficas.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirintemarConsultaBibliograficas.xlsx");
        }
    }

}