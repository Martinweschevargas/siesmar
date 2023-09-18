using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard;
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

    public class ComoperguardActividadIlicitaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        ActividadIlicitaComoperguard actividadIlicitaComoperguardBL = new();
        JefaturaDistritoCapitania jefaturaDistritoCapitaniaBL = new();
        Capitania capitaniaBL = new();
        ActividadIlicita actividadIlicitaBL = new();
        TomaConocimiento tomaConocimientoBL = new();
        UnidadNaval unidadNavalBL = new();
        AmbitoNave ambitoNaveBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        PaisUbigeo paisUbigeoBL = new();
        TipoNave tipoNaveBL = new();
        MaterialIncautado materialIncautadoBL = new();
        UnidadMedida unidadMedidaBL = new();
        Carga cargaBL = new();

        public ComoperguardActividadIlicitaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Actividades Ilicitas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<JefaturaDistritoCapitaniaDTO> jefaturaDistritoCapitaniaDTO = jefaturaDistritoCapitaniaBL.ObtenerJefaturaDistritoCapitanias();
            List<CapitaniaDTO> capitaniaDTO = capitaniaBL.ObtenerCapitanias();
            List<ActividadIlicitaDTO> ActividadIlicitaDTO = actividadIlicitaBL.ObtenerActividadIlicitas();
            List<TomaConocimientoDTO> TomaConocimientoDTO = tomaConocimientoBL.ObtenerTomaConocimientos();
            List<UnidadNavalDTO> UnidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<AmbitoNaveDTO> AmbitoNaveDTO = ambitoNaveBL.ObtenerCapintanias();
            List<DistritoUbigeoDTO> DistritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<ProvinciaUbigeoDTO> ProvinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DepartamentoUbigeoDTO> DepartamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<PaisUbigeoDTO> PaisUbigeoDTO = paisUbigeoBL.ObtenerPaisUbigeos();
            List<TipoNaveDTO> TipoNaveDTO = tipoNaveBL.ObtenerTipoNaves();
            List<MaterialIncautadoDTO> MaterialIncautadoDTO = materialIncautadoBL.ObtenerCapintanias();
            List<UnidadMedidaDTO> UnidadMedidaDTO = unidadMedidaBL.ObtenerUnidadMedidas();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ActividadIlicita");

            return Json(new { data1 = jefaturaDistritoCapitaniaDTO, data2 = capitaniaDTO, data3 = ActividadIlicitaDTO, data4 = TomaConocimientoDTO,
                data5 = UnidadNavalDTO,data6 = AmbitoNaveDTO,data7 = DistritoUbigeoDTO, data8 = ProvinciaUbigeoDTO,data9 = DepartamentoUbigeoDTO,
                data10 = PaisUbigeoDTO,data11 = TipoNaveDTO, data12 = MaterialIncautadoDTO,data13 = UnidadMedidaDTO,
                data14 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ActividadIlicitaComoperguardDTO> select = actividadIlicitaComoperguardBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string CodigoJefaturaDistritoCapitania, string CodigoCapitania, string FechaIntervencion, string CodigoActividadIlicita,
            string CodigoTomaConocimiento, string CodigoUnidadNaval, int CascoNave, string LatitudUbicacionNave, string LongitudUbicacionNave, string CodigoAmbitoNave,
            string DistritoUbigeo, int ProvinciaUbigeoId, int DepartamentoUbigeoId, string NombreNave, string MatriculaNave, string NumericoPais,
            string CodigoTipoNave, int NumeroIntervenidos, string CodigoMaterialIncautado, int CantidadMaterialIncautado, string CodigoUnidadMedida,
            string DocumentoInformacion, string FechaDocumento, string ObservacionIntervencion)
        {
            ActividadIlicitaComoperguardDTO actividadIlicitaDTO = new();
            actividadIlicitaDTO.CodigoJefaturaDistritoCapitania = CodigoJefaturaDistritoCapitania;
            actividadIlicitaDTO.CodigoCapitania = CodigoCapitania;
            actividadIlicitaDTO.FechaIntervencion = FechaIntervencion;
            actividadIlicitaDTO.CodigoActividadIlicita = CodigoActividadIlicita;
            actividadIlicitaDTO.CodigoTomaConocimiento = CodigoTomaConocimiento;
            actividadIlicitaDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            actividadIlicitaDTO.CascoNave = CascoNave;
            actividadIlicitaDTO.LatitudUbicacionNave = LatitudUbicacionNave;
            actividadIlicitaDTO.LongitudUbicacionNave = LongitudUbicacionNave;
            actividadIlicitaDTO.CodigoAmbitoNave = CodigoAmbitoNave;
            actividadIlicitaDTO.DistritoUbigeo = DistritoUbigeo;
            actividadIlicitaDTO.NombreNave = NombreNave;
            actividadIlicitaDTO.MatriculaNave = MatriculaNave;
            actividadIlicitaDTO.NumericoPais = NumericoPais;
            actividadIlicitaDTO.CodigoTipoNave = CodigoTipoNave;
            actividadIlicitaDTO.NumeroIntervenidos = NumeroIntervenidos;
            actividadIlicitaDTO.CodigoMaterialIncautado = CodigoMaterialIncautado;
            actividadIlicitaDTO.CantidadMaterialIncautado = CantidadMaterialIncautado;
            actividadIlicitaDTO.CodigoUnidadMedida = CodigoUnidadMedida;
            actividadIlicitaDTO.DocumentoInformacion = DocumentoInformacion;
            actividadIlicitaDTO.FechaDocumento = FechaDocumento;
            actividadIlicitaDTO.ObservacionIntervencion = ObservacionIntervencion;
            actividadIlicitaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actividadIlicitaComoperguardBL.AgregarRegistro(actividadIlicitaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(actividadIlicitaComoperguardBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id,  string CodigoJefaturaDistritoCapitania, string CodigoCapitania, string FechaIntervencion, string CodigoActividadIlicita,
            string CodigoTomaConocimiento, string CodigoUnidadNaval, int CascoNave, string LatitudUbicacionNave, string LongitudUbicacionNave, string CodigoAmbitoNave,
            string DistritoUbigeo, int ProvinciaUbigeoId, int DepartamentoUbigeoId, string NombreNave, string MatriculaNave, string NumericoPais,
            string CodigoTipoNave, int NumeroIntervenidos, string CodigoMaterialIncautado, int CantidadMaterialIncautado, string CodigoUnidadMedida,
            string DocumentoInformacion, string FechaDocumento, string ObservacionIntervencion)
        {
            ActividadIlicitaComoperguardDTO actividadIlicitaDTO = new();
            actividadIlicitaDTO.FActividadIlicitaId = Id;
            actividadIlicitaDTO.CodigoJefaturaDistritoCapitania = CodigoJefaturaDistritoCapitania;
            actividadIlicitaDTO.CodigoCapitania = CodigoCapitania;
            actividadIlicitaDTO.FechaIntervencion = FechaIntervencion;
            actividadIlicitaDTO.CodigoActividadIlicita = CodigoActividadIlicita;
            actividadIlicitaDTO.CodigoTomaConocimiento = CodigoTomaConocimiento;
            actividadIlicitaDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            actividadIlicitaDTO.CascoNave = CascoNave;
            actividadIlicitaDTO.LatitudUbicacionNave = LatitudUbicacionNave;
            actividadIlicitaDTO.LongitudUbicacionNave = LongitudUbicacionNave;
            actividadIlicitaDTO.CodigoAmbitoNave = CodigoAmbitoNave;
            actividadIlicitaDTO.DistritoUbigeo = DistritoUbigeo;;
            actividadIlicitaDTO.NombreNave = NombreNave;
            actividadIlicitaDTO.MatriculaNave = MatriculaNave;
            actividadIlicitaDTO.NumericoPais = NumericoPais;
            actividadIlicitaDTO.CodigoTipoNave = CodigoTipoNave;
            actividadIlicitaDTO.NumeroIntervenidos = NumeroIntervenidos;
            actividadIlicitaDTO.CodigoMaterialIncautado = CodigoMaterialIncautado;
            actividadIlicitaDTO.CantidadMaterialIncautado = CantidadMaterialIncautado;
            actividadIlicitaDTO.CodigoUnidadMedida = CodigoUnidadMedida;
            actividadIlicitaDTO.DocumentoInformacion = DocumentoInformacion;
            actividadIlicitaDTO.FechaDocumento = FechaDocumento;
            actividadIlicitaDTO.ObservacionIntervencion = ObservacionIntervencion;
            actividadIlicitaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actividadIlicitaComoperguardBL.ActualizarFormato(actividadIlicitaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ActividadIlicitaComoperguardDTO actividadIlicitaDTO = new();
            actividadIlicitaDTO.FActividadIlicitaId = Id;
            actividadIlicitaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (actividadIlicitaComoperguardBL.EliminarFormato(actividadIlicitaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ActividadIlicitaComoperguardDTO> lista = new List<ActividadIlicitaComoperguardDTO>();
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

                    lista.Add(new ActividadIlicitaComoperguardDTO
                    {
                        CodigoJefaturaDistritoCapitania = fila.GetCell(0).ToString(),
                        CodigoCapitania = fila.GetCell(1).ToString(),
                        FechaIntervencion = fila.GetCell(2).ToString(),
                        CodigoActividadIlicita = fila.GetCell(3).ToString(),
                        CodigoTomaConocimiento = fila.GetCell(4).ToString(),
                        CodigoUnidadNaval = fila.GetCell(5).ToString(),
                        CascoNave = int.Parse(fila.GetCell(6).ToString()),
                        LatitudUbicacionNave = fila.GetCell(7).ToString(),
                        LongitudUbicacionNave = fila.GetCell(8).ToString(),
                        CodigoAmbitoNave = fila.GetCell(9).ToString(),
                        DistritoUbigeo = fila.GetCell(10).ToString(),
                        NombreNave = fila.GetCell(11).ToString(),
                        MatriculaNave = fila.GetCell(12).ToString(),
                        NumericoPais = fila.GetCell(13).ToString(),
                        CodigoTipoNave = fila.GetCell(14).ToString(),
                        NumeroIntervenidos = int.Parse(fila.GetCell(15).ToString()),
                        CodigoMaterialIncautado = fila.GetCell(16).ToString(),
                        CantidadMaterialIncautado = int.Parse(fila.GetCell(17).ToString()),
                        CodigoUnidadMedida = fila.GetCell(18).ToString(),
                        DocumentoInformacion = fila.GetCell(19).ToString(),
                        FechaDocumento = fila.GetCell(20).ToString(),
                        ObservacionIntervencion = fila.GetCell(21).ToString()
                        
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

            dt.Columns.AddRange(new DataColumn[6]
            {
                    new DataColumn("IdentificadorCiberataque", typeof(int)),
                    new DataColumn("CodigoAccionAnteCiberataque", typeof(string)),
                    new DataColumn("FechaCiberataques", typeof(string)),
                    new DataColumn("CodigoTipoCiberataque", typeof(string)),
                    new DataColumn("CodigoSeveridadCiberataque", typeof(string)),
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
                    User.obtenerUsuario());
            }
            var IND_OPERACION = actividadIlicitaComoperguardBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = actividadIlicitaComoperguardBL.ObtenerLista();
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
        //    var estudioInvestigacionesHistoricasNavales = documentoIntelFrenteInternoBL.ObtenerLista();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("EstudioInvestigacionHistoricasNavales", estudioInvestigacionesHistoricasNavales);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

    }

}

