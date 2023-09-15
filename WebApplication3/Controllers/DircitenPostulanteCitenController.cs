using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dirciten;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Dirciten;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SixLabors.ImageSharp.ColorSpaces;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DircitenPostulanteCitenController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        PostulanteCitenDAO postulanteCitenBL = new();
        ZonaNavalDAO zonaNavalBL = new();
        Carga cargaBL = new();

        public DircitenPostulanteCitenController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Postulantes al Citen", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PostulanteCiten");

            return Json(new { dat1 = zonaNavalDTO, data2 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<PostulanteCitenDTO> select = postulanteCitenBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string DNIPostulanteCiten, string GeneroPostulanteCiten, string FechaNacimientoPostulanteCiten,
           string LugarNacimiento, string ProcedenciaPostulanteCiten, string TipoColegioProveniente, string ColegioProcedencia, string LugarColegio,
           string PadresEntidadMilitar, string ModalidadIngreso, string TipoPreparacion, string LugarPostulacion, string CodigoZonaNaval,
           string SituacionIngreso)
        {
            PostulanteCitenDTO postulanteCitenDTO = new();
            postulanteCitenDTO.DNIPostulanteCiten = DNIPostulanteCiten;
            postulanteCitenDTO.GeneroPostulanteCiten = GeneroPostulanteCiten;
            postulanteCitenDTO.FechaNacimientoPostulanteCiten = FechaNacimientoPostulanteCiten;
            postulanteCitenDTO.LugarNacimiento = LugarNacimiento;
            postulanteCitenDTO.ProcedenciaPostulanteCiten = ProcedenciaPostulanteCiten;
            postulanteCitenDTO.TipoColegioProveniente = TipoColegioProveniente;
            postulanteCitenDTO.ColegioProcedencia = ColegioProcedencia;
            postulanteCitenDTO.LugarColegio = LugarColegio;
            postulanteCitenDTO.PadresEntidadMilitar = PadresEntidadMilitar;
            postulanteCitenDTO.ModalidadIngreso = ModalidadIngreso;
            postulanteCitenDTO.TipoPreparacion = TipoPreparacion;
            postulanteCitenDTO.LugarPostulacion = LugarPostulacion;
            postulanteCitenDTO.CodigoZonaNaval = CodigoZonaNaval;
            postulanteCitenDTO.SituacionIngreso = SituacionIngreso;
            postulanteCitenDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = postulanteCitenBL.AgregarRegistro(postulanteCitenDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(postulanteCitenBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string DNIPostulanteCiten, string GeneroPostulanteCiten, string FechaNacimientoPostulanteCiten,
           string LugarNacimiento, string ProcedenciaPostulanteCiten, string TipoColegioProveniente, string ColegioProcedencia, string LugarColegio,
           string PadresEntidadMilitar, string ModalidadIngreso, string TipoPreparacion, string LugarPostulacion, string CodigoZonaNaval,
           string SituacionIngreso)
        {
            PostulanteCitenDTO postulanteCitenDTO = new();
            postulanteCitenDTO.PostulanteCitenId = Id;
            postulanteCitenDTO.DNIPostulanteCiten = DNIPostulanteCiten;
            postulanteCitenDTO.GeneroPostulanteCiten = GeneroPostulanteCiten;
            postulanteCitenDTO.FechaNacimientoPostulanteCiten = FechaNacimientoPostulanteCiten;
            postulanteCitenDTO.LugarNacimiento = LugarNacimiento;
            postulanteCitenDTO.ProcedenciaPostulanteCiten = ProcedenciaPostulanteCiten;
            postulanteCitenDTO.TipoColegioProveniente = TipoColegioProveniente;
            postulanteCitenDTO.ColegioProcedencia = ColegioProcedencia;
            postulanteCitenDTO.LugarColegio = LugarColegio;
            postulanteCitenDTO.PadresEntidadMilitar = PadresEntidadMilitar;
            postulanteCitenDTO.ModalidadIngreso = ModalidadIngreso;
            postulanteCitenDTO.TipoPreparacion = TipoPreparacion;
            postulanteCitenDTO.LugarPostulacion = LugarPostulacion;
            postulanteCitenDTO.CodigoZonaNaval = CodigoZonaNaval;
            postulanteCitenDTO.SituacionIngreso = SituacionIngreso;
            postulanteCitenDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = postulanteCitenBL.ActualizaFormato(postulanteCitenDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PostulanteCitenDTO postulanteCitenDTO = new();
            postulanteCitenDTO.PostulanteCitenId = Id;
            postulanteCitenDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (postulanteCitenBL.EliminarFormato(postulanteCitenDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<PostulanteCitenDTO> lista = new List<PostulanteCitenDTO>();
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

                    lista.Add(new PostulanteCitenDTO
                    {
                        DNIPostulanteCiten = fila.GetCell(0).ToString(),
                        GeneroPostulanteCiten = fila.GetCell(1).ToString(),
                        FechaNacimientoPostulanteCiten = fila.GetCell(2).ToString(),
                        LugarNacimiento = fila.GetCell(3).ToString(),
                        ProcedenciaPostulanteCiten = fila.GetCell(4).ToString(),
                        TipoColegioProveniente = fila.GetCell(5).ToString(),
                        ColegioProcedencia = fila.GetCell(6).ToString(),
                        LugarColegio = fila.GetCell(7).ToString(),
                        PadresEntidadMilitar = fila.GetCell(8).ToString(),
                        ModalidadIngreso = fila.GetCell(9).ToString(),
                        TipoPreparacion = fila.GetCell(10).ToString(),
                        LugarPostulacion = fila.GetCell(11).ToString(),
                        CodigoZonaNaval = fila.GetCell(12).ToString(),
                        SituacionIngreso = fila.GetCell(13).ToString()
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

            dt.Columns.AddRange(new DataColumn[15]
            {
                    new DataColumn("DNIPostulanteCiten", typeof(string)),
                    new DataColumn("GeneroPostulanteCiten", typeof(string)),
                    new DataColumn("FechaNacimientoPostulanteCiten", typeof(string)),
                    new DataColumn("LugarNacimiento", typeof(string)),
                    new DataColumn("ProcedenciaPostulanteCiten", typeof(string)),
                    new DataColumn("TipoColegioProveniente", typeof(string)),
                    new DataColumn("ColegioProcedencia", typeof(string)),
                    new DataColumn("LugarColegio", typeof(string)),
                    new DataColumn("PadresEntidadMilitar", typeof(string)),
                    new DataColumn("ModalidadIngreso", typeof(string)),
                    new DataColumn("TipoPreparacion", typeof(string)),
                    new DataColumn("LugarPostulacion", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("SituacionIngreso", typeof(string)),
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
                             fila.GetCell(6).ToString(),
                             UtilitariosGlobales.obtenerFecha(fila.GetCell(7).ToString()),
                             fila.GetCell(8).ToString(),
                             fila.GetCell(9).ToString(),
                             fila.GetCell(10).ToString(),
                             fila.GetCell(11).ToString(),
                             UtilitariosGlobales.obtenerFecha(fila.GetCell(12).ToString()),
                             fila.GetCell(13).ToString(),
                             User.obtenerUsuario());
            }
            var IND_OPERACION = postulanteCitenBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = postulanteCitenBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
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
        //    var estudioInvestigacionesHistoricasNavales = postulanteCitenBL.ObtenerLista();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("EstudioInvestigacionHistoricasNavales", estudioInvestigacionesHistoricasNavales);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

    }

}

