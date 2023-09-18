using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Diresprom;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diresprom;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diresprom;
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

    public class DirespromPostulanteAsimiladoOficialServicioController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        PostulanteAsimiladoOficialServicio postulanteAsimiladoOficialServicioBL = new();
        InstitucionEducativaSuperiorDAO listaInstEducSuBL = new();
        CarreraUniversitariaEspecialidadDAO listCUniverEspecialidadBL = new();
        EspecialidadPostulacionDAO listEspecialPostulacionBL = new();
        ZonaNavalDAO zonaNavalBL = new();
        Carga cargaBL = new();

        public DirespromPostulanteAsimiladoOficialServicioController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Postulantes como Asimilados como Oficiales de Servicio", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<InstitucionEducativaSuperiorDTO> institucionEducativaSuDTO = listaInstEducSuBL.ObtenerInstitucionEducativaSuperiors();
            List<CarreraUniversitariaEspecialidadDTO> carreraUniversitariaEspecialidadDTO = listCUniverEspecialidadBL.ObtenerCarreraUniversitariaEspecialidads();
            List<EspecialidadPostulacionDTO> especialidadPostulacionDTO = listEspecialPostulacionBL.ObtenerEspecialidadPostulacions();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PostulanteAsimiladoOficialServicio");
            return Json(new { 
                data1 = institucionEducativaSuDTO, 
                data2 = carreraUniversitariaEspecialidadDTO, 
                data3 = especialidadPostulacionDTO, 
                data4 = zonaNavalDTO, 
                data5 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<PostulanteAsimiladoOficialServicioDTO> select = postulanteAsimiladoOficialServicioBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(int DNIPostulanteAsimilado, string SexoPostulanteAsimilado, string FechaNacimiento, string DistritoNacimiento, 
            string CodigoInstitucionEducativaSuperior, string CodigoCarreraUniversitariaEspecialidad, string CodigoEspecialidadPostulacion, string CodigoZonaNaval,
            string SituacionIngreso, int CargaId, string Fecha)
        {
            PostulanteAsimiladoOficialServicioDTO postulanteAsimiladoOficialServicioDTO = new();
            postulanteAsimiladoOficialServicioDTO.DNIPostulanteAsimilado = DNIPostulanteAsimilado;
            postulanteAsimiladoOficialServicioDTO.SexoPostulanteAsimilado = SexoPostulanteAsimilado;
            postulanteAsimiladoOficialServicioDTO.FechaNacimiento = FechaNacimiento;
            postulanteAsimiladoOficialServicioDTO.DistritoNacimiento = DistritoNacimiento;
            postulanteAsimiladoOficialServicioDTO.CodigoInstitucionEducativaSuperior = CodigoInstitucionEducativaSuperior;
            postulanteAsimiladoOficialServicioDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            postulanteAsimiladoOficialServicioDTO.CodigoEspecialidadPostulacion = CodigoEspecialidadPostulacion;
            postulanteAsimiladoOficialServicioDTO.CodigoZonaNaval = CodigoZonaNaval;
            postulanteAsimiladoOficialServicioDTO.SituacionIngreso = SituacionIngreso;
            postulanteAsimiladoOficialServicioDTO.CargaId = CargaId;
            postulanteAsimiladoOficialServicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = postulanteAsimiladoOficialServicioBL.AgregarRegistro(postulanteAsimiladoOficialServicioDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(postulanteAsimiladoOficialServicioBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int Id, int DNIPostulanteAsimilado, string SexoPostulanteAsimilado, string FechaNacimiento, string DistritoNacimiento, 
            string CodigoInstitucionEducativaSuperior, string CodigoCarreraUniversitariaEspecialidad, string CodigoEspecialidadPostulacion, string CodigoZonaNaval,
            string SituacionIngreso)
        {
            PostulanteAsimiladoOficialServicioDTO postulanteAsimiladoOficialServicioDTO = new();
            postulanteAsimiladoOficialServicioDTO.PostulanteAsimiladoOficialServicioId = Id;
            postulanteAsimiladoOficialServicioDTO.DNIPostulanteAsimilado = DNIPostulanteAsimilado;
            postulanteAsimiladoOficialServicioDTO.SexoPostulanteAsimilado = SexoPostulanteAsimilado;
            postulanteAsimiladoOficialServicioDTO.FechaNacimiento = FechaNacimiento;
            postulanteAsimiladoOficialServicioDTO.DistritoNacimiento = DistritoNacimiento;
            postulanteAsimiladoOficialServicioDTO.CodigoInstitucionEducativaSuperior = CodigoInstitucionEducativaSuperior;
            postulanteAsimiladoOficialServicioDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            postulanteAsimiladoOficialServicioDTO.CodigoEspecialidadPostulacion = CodigoEspecialidadPostulacion;
            postulanteAsimiladoOficialServicioDTO.CodigoZonaNaval = CodigoZonaNaval;
            postulanteAsimiladoOficialServicioDTO.SituacionIngreso = SituacionIngreso;
            postulanteAsimiladoOficialServicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = postulanteAsimiladoOficialServicioBL.ActualizarFormato(postulanteAsimiladoOficialServicioDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PostulanteAsimiladoOficialServicioDTO postulanteAsimiladoOficialServicioDTO = new();
            postulanteAsimiladoOficialServicioDTO.PostulanteAsimiladoOficialServicioId = Id;
            postulanteAsimiladoOficialServicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (postulanteAsimiladoOficialServicioBL.EliminarFormato(postulanteAsimiladoOficialServicioDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            PostulanteAsimiladoOficialServicioDTO postulanteAsimiladoOficialServicioDTO = new();
            postulanteAsimiladoOficialServicioDTO.CargaId = Id;
            postulanteAsimiladoOficialServicioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (postulanteAsimiladoOficialServicioBL.EliminarCarga(postulanteAsimiladoOficialServicioDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<PostulanteAsimiladoOficialServicioDTO> lista = new List<PostulanteAsimiladoOficialServicioDTO>();
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

                    lista.Add(new PostulanteAsimiladoOficialServicioDTO
                    {
                        DNIPostulanteAsimilado = int.Parse(fila.GetCell(0).ToString()),
                        SexoPostulanteAsimilado = fila.GetCell(1).ToString(),
                        FechaNacimiento = fila.GetCell(2).ToString(),
                        DistritoNacimiento = fila.GetCell(3).ToString(),
                        CodigoInstitucionEducativaSuperior = fila.GetCell(4).ToString(),
                        CodigoCarreraUniversitariaEspecialidad = fila.GetCell(5).ToString(),
                        CodigoEspecialidadPostulacion = fila.GetCell(6).ToString(),
                        CodigoZonaNaval = fila.GetCell(7).ToString(),
                        SituacionIngreso = fila.GetCell(8).ToString()
                       
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
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string Fecha)
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

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("DNIPostulanteAsimilado", typeof(int)),
                    new DataColumn("SexoPostulanteAsimilado", typeof(string)),
                    new DataColumn("FechaNacimiento", typeof(string)),
                    new DataColumn("DistritoNacimiento", typeof(string)),
                    new DataColumn("CodigoInstitucionEducativaSuperior", typeof(string)),
                    new DataColumn("CodigoCarreraUniversitariaEspecialidad", typeof(string)),
                    new DataColumn("CodigoEspecialidadPostulacion", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("SituacionIngreso", typeof(string)),
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
                         fila.GetCell(5).ToString(),
                         fila.GetCell(6).ToString(),
                         fila.GetCell(7).ToString(),
                         fila.GetCell(8).ToString(),
                        User.obtenerUsuario());
            }
            var IND_OPERACION = postulanteAsimiladoOficialServicioBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = postulanteAsimiladoOficialServicioBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirespromPostulanteAsimiladoOficialServicio.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirespromPostulanteAsimiladoOficialServicio.xlsx");
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

    }

}

