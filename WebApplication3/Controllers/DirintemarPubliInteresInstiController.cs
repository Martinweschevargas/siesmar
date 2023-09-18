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
    public class DirintemarPubliInteresInstiController : Controller
    {

        CapitaniaDAO capitaniaBL = new();
        private readonly IWebHostEnvironment _webHostEnviroment;
        PublicacionInteresInstitucionalDAO publicacionInteresBL = new();
        TipoPublicacionDAO tipopublicacicon = new();

        public DirintemarPubliInteresInstiController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        [Breadcrumb(FromAction = "Index", Title = "Publicación Interés Institucional", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoPublicacionDTO> select = tipopublicacicon.ObtenerTipoPublicacions();
            return Json(new { data=select});
        }
        
        public IActionResult CargaTabla()
        {
            List<PublicacionInteresInstitucionalDTO> publicacionInteresInstitucionalDTO = publicacionInteresBL.ObtenerLista();
            return Json(new { data = publicacionInteresInstitucionalDTO });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(int TipoPublicacionId, string DenominacionTemaPublicacion, string NroPublicacion,
           string FechaPublicacion, int NumeroEjemplaresPublicados, int NroSuscriptores, string PromotorPublicaciones,
           string ResponsablePublicacion, decimal InversionPublicacion)
        {
            PublicacionInteresInstitucionalDTO publicacionInteresInstitucionalDTO = new();
            publicacionInteresInstitucionalDTO.TipoPublicacionId = TipoPublicacionId;
            publicacionInteresInstitucionalDTO.DenominacionTemaPublicacion = DenominacionTemaPublicacion;
            publicacionInteresInstitucionalDTO.NroPublicacion = NroPublicacion;
            publicacionInteresInstitucionalDTO.FechaPublicacion = FechaPublicacion;
            publicacionInteresInstitucionalDTO.NumeroEjemplaresPublicados = NumeroEjemplaresPublicados;
            publicacionInteresInstitucionalDTO.NroSuscriptores = NroSuscriptores;
            publicacionInteresInstitucionalDTO.PromotorPublicaciones = PromotorPublicaciones;
            publicacionInteresInstitucionalDTO.ResponsablePublicacion = ResponsablePublicacion;
            publicacionInteresInstitucionalDTO.InversionPublicacion = InversionPublicacion;
            publicacionInteresInstitucionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = publicacionInteresBL.AgregarRegistro(publicacionInteresInstitucionalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(publicacionInteresBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int TipoPublicacionId, string DenominacionTemaPublicacion, string NroPublicacion,
           string FechaPublicacion, int NumeroEjemplaresPublicados, int NroSuscriptores, string PromotorPublicaciones,
           string ResponsablePublicacion, decimal InversionPublicacion)
        {
            PublicacionInteresInstitucionalDTO publicacionInteresInstitucionalDTO = new();
            publicacionInteresInstitucionalDTO.PublicacionInteresInstitucionalId = Id;
            publicacionInteresInstitucionalDTO.TipoPublicacionId = TipoPublicacionId;
            publicacionInteresInstitucionalDTO.DenominacionTemaPublicacion = DenominacionTemaPublicacion;
            publicacionInteresInstitucionalDTO.NroPublicacion = NroPublicacion;
            publicacionInteresInstitucionalDTO.FechaPublicacion = FechaPublicacion;
            publicacionInteresInstitucionalDTO.NumeroEjemplaresPublicados = NumeroEjemplaresPublicados;
            publicacionInteresInstitucionalDTO.NroSuscriptores = NroSuscriptores;
            publicacionInteresInstitucionalDTO.PromotorPublicaciones = PromotorPublicaciones;
            publicacionInteresInstitucionalDTO.ResponsablePublicacion = ResponsablePublicacion;
            publicacionInteresInstitucionalDTO.InversionPublicacion = InversionPublicacion;
            publicacionInteresInstitucionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = publicacionInteresBL.ActualizaFormato(publicacionInteresInstitucionalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PublicacionInteresInstitucionalDTO publicacionInteresInstitucionalDTO = new();
            publicacionInteresInstitucionalDTO.PublicacionInteresInstitucionalId = Id;
            publicacionInteresInstitucionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (publicacionInteresBL.EliminarFormato(publicacionInteresInstitucionalDTO) == true)
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

            List<PublicacionInteresInstitucionalDTO> lista = new List<PublicacionInteresInstitucionalDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new PublicacionInteresInstitucionalDTO
                {
                    PublicacionInteresInstitucionalId = int.Parse(fila.GetCell(0).ToString()),
                    TipoPublicacionId = int.Parse(fila.GetCell(1).ToString()),
                    DenominacionTemaPublicacion = fila.GetCell(2).ToString(),
                    NroPublicacion = fila.GetCell(3).ToString(),
                    FechaPublicacion = fila.GetCell(4).ToString(),
                    NumeroEjemplaresPublicados = int.Parse(fila.GetCell(5).ToString()),
                    NroSuscriptores = int.Parse(fila.GetCell(6).ToString()),
                    PromotorPublicaciones = fila.GetCell(7).ToString(),
                    ResponsablePublicacion = fila.GetCell(8).ToString(),
                    InversionPublicacion = decimal.Parse(fila.GetCell(9).ToString())
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
                    new DataColumn("TipoPublicacionId", typeof(int)),
                    new DataColumn("DenominacionTemaPublicacion", typeof(string)),
                    new DataColumn("NroPublicacion", typeof(string)),
                    new DataColumn("FechaPublicacion", typeof(string)),
                    new DataColumn("NumeroEjemplaresPublicados", typeof(int)),
                    new DataColumn("NroSuscriptores", typeof(int)),
                    new DataColumn("PromotorPublicaciones", typeof(string)),
                    new DataColumn("ResponsablePublicacion", typeof(string)),
                    new DataColumn("InversionPublicacion", typeof(decimal)),
                   
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                    int.Parse(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    decimal.Parse(fila.GetCell(8).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = publicacionInteresBL.InsertarDatos(dt);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirintemarPubliInteresInsti.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirintemarPubliInteresInsti.xlsx");
        }
    }

}