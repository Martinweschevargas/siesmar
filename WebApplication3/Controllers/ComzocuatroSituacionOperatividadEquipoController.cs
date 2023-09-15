using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzocuatro;
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

    public class ComzocuatroSituacionOperatividadEquipoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        SituacionOperatividadEquipoComzocuatro situacionOperatividadEquipoComzocuatroBL = new();

        DescripcionMaterial descripcionMaterialBL = new();
        UnidadNaval unidadNavalBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        Condicion condicionBL = new();

        Carga cargaBL = new();

        public ComzocuatroSituacionOperatividadEquipoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Formato de Situación de Operatividad de Equipos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<DescripcionMaterialDTO> descripcionMaterialDTO = descripcionMaterialBL.ObtenerDescripcionMaterials();
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<CondicionDTO> condicionDTO = condicionBL.ObtenerCondicions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("SituacionOperatividadEquipoComzocuatro");

            return Json(new { data1 = descripcionMaterialDTO, data2 = unidadNavalDTO, data3 = distritoUbigeoDTO, data4 = condicionDTO, data5 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<SituacionOperatividadEquipoComzocuatroDTO> select = situacionOperatividadEquipoComzocuatroBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar( string CodigoDescripcionMaterial, int Cantidad, string CodigoUnidadNaval, string Ubicacion, string DistritoUbigeo,
            string CodigoCondicion, string Observacion, int CargaId)
        {
            SituacionOperatividadEquipoComzocuatroDTO aituacionOperatividadEquipoComzocuatroDTO = new();
            aituacionOperatividadEquipoComzocuatroDTO.CodigoDescripcionMaterial = CodigoDescripcionMaterial;
            aituacionOperatividadEquipoComzocuatroDTO.Cantidad = Cantidad;
            aituacionOperatividadEquipoComzocuatroDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            aituacionOperatividadEquipoComzocuatroDTO.Ubicacion = Ubicacion;
            aituacionOperatividadEquipoComzocuatroDTO.DistritoUbigeo = DistritoUbigeo;
            aituacionOperatividadEquipoComzocuatroDTO.CodigoCondicion = CodigoCondicion;
            aituacionOperatividadEquipoComzocuatroDTO.Observacion = Observacion;
            aituacionOperatividadEquipoComzocuatroDTO.CargaId = CargaId;
            aituacionOperatividadEquipoComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperatividadEquipoComzocuatroBL.AgregarRegistro(aituacionOperatividadEquipoComzocuatroDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(situacionOperatividadEquipoComzocuatroBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoDescripcionMaterial, int Cantidad, string CodigoUnidadNaval, string Ubicacion, string DistritoUbigeo,
            string CodigoCondicion, string Observacion)
        {
            SituacionOperatividadEquipoComzocuatroDTO aituacionOperatividadEquipoComzocuatroDTO = new();
            aituacionOperatividadEquipoComzocuatroDTO.SituacionOperatividadEquipoId = Id;
            aituacionOperatividadEquipoComzocuatroDTO.CodigoDescripcionMaterial = CodigoDescripcionMaterial;
            aituacionOperatividadEquipoComzocuatroDTO.Cantidad = Cantidad;
            aituacionOperatividadEquipoComzocuatroDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            aituacionOperatividadEquipoComzocuatroDTO.Ubicacion = Ubicacion;
            aituacionOperatividadEquipoComzocuatroDTO.DistritoUbigeo = DistritoUbigeo;
            aituacionOperatividadEquipoComzocuatroDTO.CodigoCondicion = CodigoCondicion;
            aituacionOperatividadEquipoComzocuatroDTO.Observacion = Observacion;
            aituacionOperatividadEquipoComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperatividadEquipoComzocuatroBL.ActualizarFormato(aituacionOperatividadEquipoComzocuatroDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            SituacionOperatividadEquipoComzocuatroDTO aituacionOperatividadEquipoComzocuatroDTO = new();
            aituacionOperatividadEquipoComzocuatroDTO.SituacionOperatividadEquipoId = Id;
            aituacionOperatividadEquipoComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (situacionOperatividadEquipoComzocuatroBL.EliminarFormato(aituacionOperatividadEquipoComzocuatroDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<SituacionOperatividadEquipoComzocuatroDTO> lista = new List<SituacionOperatividadEquipoComzocuatroDTO>();
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

                    lista.Add(new SituacionOperatividadEquipoComzocuatroDTO
                    {
                        CodigoDescripcionMaterial =fila.GetCell(0).ToString(),
                        Cantidad = int.Parse(fila.GetCell(1).ToString()),
                        CodigoUnidadNaval = fila.GetCell(2).ToString(),
                        Ubicacion = fila.GetCell(3).ToString(),
                        DistritoUbigeo = fila.GetCell(4).ToString(),
                        CodigoCondicion = fila.GetCell(5).ToString(),
                        Observacion = fila.GetCell(6).ToString()
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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("CodigoDescripcionMaterial", typeof(string)),
                    new DataColumn("Cantidad", typeof(int)),
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("Ubicacion", typeof(string)),
                    new DataColumn("DistritoUbigeo", typeof(string)),
                    new DataColumn("CodigoCondicion", typeof(string)),
                    new DataColumn("Observacion", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                         fila.GetCell(0).ToString(),
                         int.Parse(fila.GetCell(1).ToString()),
                         fila.GetCell(2).ToString(),
                         fila.GetCell(3).ToString(),
                         fila.GetCell(4).ToString(),
                         fila.GetCell(5).ToString(),
                         fila.GetCell(6).ToString(),
                         User.obtenerUsuario());
            }
            var IND_OPERACION = situacionOperatividadEquipoComzocuatroBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = situacionOperatividadEquipoComzocuatroBL.ObtenerLista();
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

