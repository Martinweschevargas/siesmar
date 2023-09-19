using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comfuavinav;
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

    public class ComfuavinavAlistamientoCombustibleLubricanteController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        AlistamientoCombustibleLubricanteComfuavinav alistamientoCombustibleLubricanteComfuavinavBL = new();

        UnidadNaval unidadNavalBL = new();
        AlistamientoCombustibleLubricante alistamientoCombustibleLubricanteBL = new();
        Carga cargaBL = new();

        public ComfuavinavAlistamientoCombustibleLubricanteController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Alistamiento de combustibles y lubricantes (ACL)", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<AlistamientoCombustibleLubricanteDTO> alistamientoCombustibleLubricanteDTO = alistamientoCombustibleLubricanteBL.ObtenerAlistamientoCombustibleLubricantes();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoCombustibleLubricanteComfuavinav");

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = alistamientoCombustibleLubricanteDTO,
                data3 = listaCargas
            }); ;
        }

        public IActionResult CargaTabla()
        {
            List<AlistamientoCombustibleLubricanteComfuavinavDTO> select = alistamientoCombustibleLubricanteComfuavinavBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 149, Permiso: 1)]//Registrar
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoAlistamientoCombustibleLubricante, int CargaId, string Fecha)
        {
            AlistamientoCombustibleLubricanteComfuavinavDTO alistamientoCombustibleLubricanteComfuavinavDTO = new();
            alistamientoCombustibleLubricanteComfuavinavDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoCombustibleLubricanteComfuavinavDTO.CodigoAlistamientoCombustibleLubricante = CodigoAlistamientoCombustibleLubricante;
            alistamientoCombustibleLubricanteComfuavinavDTO.CargaId = CargaId;
            alistamientoCombustibleLubricanteComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoCombustibleLubricanteComfuavinavBL.AgregarRegistro(alistamientoCombustibleLubricanteComfuavinavDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistamientoCombustibleLubricanteComfuavinavBL.EditarFormado(Id));
        }

        //[AuthorizePermission(Formato: 149, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoAlistamientoCombustibleLubricante)
        {
            AlistamientoCombustibleLubricanteComfuavinavDTO alistamientoCombustibleLubricanteComfuavinavDTO = new();
            alistamientoCombustibleLubricanteComfuavinavDTO.AlistamientoCombustibleLubricanteComfuavinavId = Id;
            alistamientoCombustibleLubricanteComfuavinavDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoCombustibleLubricanteComfuavinavDTO.CodigoAlistamientoCombustibleLubricante = CodigoAlistamientoCombustibleLubricante;
            alistamientoCombustibleLubricanteComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoCombustibleLubricanteComfuavinavBL.ActualizarFormato(alistamientoCombustibleLubricanteComfuavinavDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 149, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistamientoCombustibleLubricanteComfuavinavDTO alistamientoCombustibleLubricanteComfuavinavDTO = new();
            alistamientoCombustibleLubricanteComfuavinavDTO.AlistamientoCombustibleLubricanteComfuavinavId = Id;
            alistamientoCombustibleLubricanteComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistamientoCombustibleLubricanteComfuavinavBL.EliminarFormato(alistamientoCombustibleLubricanteComfuavinavDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 149, Permiso: 5)]//Registrar
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AlistamientoCombustibleLubricanteComfuavinavDTO alistamientoCombustibleLubricanteComfuavinavDTO = new();
            alistamientoCombustibleLubricanteComfuavinavDTO.CargaId = Id;
            alistamientoCombustibleLubricanteComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (alistamientoCombustibleLubricanteComfuavinavBL.EliminarCarga(alistamientoCombustibleLubricanteComfuavinavDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistamientoCombustibleLubricanteComfuavinavDTO> lista = new List<AlistamientoCombustibleLubricanteComfuavinavDTO>();
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

                    lista.Add(new AlistamientoCombustibleLubricanteComfuavinavDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoAlistamientoCombustibleLubricante = fila.GetCell(1).ToString()
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
        //[AuthorizePermission(Formato: 149, Permiso: 4)]//Registrar
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string Fecha)
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

            dt.Columns.AddRange(new DataColumn[3]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoAlistamientoCombustibleLubricante", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = alistamientoCombustibleLubricanteComfuavinavBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            LocalReport localReport = new LocalReport(path);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfuavinavAlistamientoCombustibleLubricante.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfuavinavAlistamientoCombustibleLubricante.xlsx");
        }
    }

}

//public IActionResult ReportePMPIACR()
//{
//    //PROMEDIO MENSUAL DE PARTICIPANTES Y DE INVERSIÓN EN ACTIVIDADES CULTURALES REALIZADAS
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMPIACR.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReportePII()
//{
//    //PUBLICACIONES DE INTERÉS INSTITUCIONAL
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePII.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReportePMCB()
//{
//    //PROMEDIO MENSUAL DE CONSULTAS BIBLIOGRÁFICAS
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMCB.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReportePMVAHM()
//{
//    //PROMEDIO MENSUAL DE VISITAS AL ARCHIVO HISTÓRICO DE LA MARINA
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMVAHM.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReportePMVRMN()
//{
//    //PROMEDIO MENSUAL DE VISITAS REGISTRADAS A LOS MUSEOS NAVALES
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMVRMN.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReporteTRC()
//{
//    //TRABAJOS DE RESTAURACIÓN Y/O CONSERVACIÓN
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReporteTRC.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReporteRMHPRM()
//{
//    //REPRESENTACIÓN Y/ O MONUMENTOS HISTORICOS EN EL PAIS RELACIONADOS A LA MARINA
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReporteRMHPRM.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReporteAAD()
//{
//    //APOYO A LAS ACTIVIDADES DE DIFUSIÓN
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReporteAAD.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReportePMPADRIM()
//{
//    //PROMEDIO MENSUAL DE PARTICIPANTES A ACTIVIDADES DE DIFUSIÓN DE REALIDAD E INTERESES MARITIMOS
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMPADRIM.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    //localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReportePMPOADRIM()
//{
//    //PROMEDIO MENSUAL DE PARTICIPANTES A OTRAS ACTIVIDADES DE DIFUSIÓN DE REALIDAD E INTERESES MARITIMOS
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMPOADRIM.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    var estudioInvestigacionesHistoricasNavales = documentoIntelFrenteInternoBL.ObtenerLista();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("EstudioInvestigacionHistoricasNavales", estudioInvestigacionesHistoricasNavales);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}
