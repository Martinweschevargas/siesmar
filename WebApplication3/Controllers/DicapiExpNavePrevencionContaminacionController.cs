using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dicapi;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dicapi;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Data;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DicapiExpNavePrevencionContaminacionController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ExpNavePrevencionContaminacion expNavePrevencionContaminacionBL = new();
        DptoProteccionMedioAmbiente dptoProteccionMedioAmbienteBL = new();
        ClaseNave claseNaveBL = new();
        InstalacionTerrestreAcuatica instalacionTerrestreAcuaticaBL = new();
        PaisUbigeo paisUbigeoBL = new();
        Carga cargaBL = new();

        public DicapiExpNavePrevencionContaminacionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Expedición de Documentos para Naves en Prevención de la Contaminación", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DptoProteccionMedioAmbienteDTO> dptoProteccionMedioAmbienteDTO = dptoProteccionMedioAmbienteBL.ObtenerDptoProteccionMedioAmbientes(); 
            List<ClaseNaveDTO> claseNaveDTO = claseNaveBL.ObtenerClaseNaves();
            List<InstalacionTerrestreAcuaticaDTO> instalacionTerrestreAcuaticaDTO = instalacionTerrestreAcuaticaBL.ObtenerInstalacionTerrestreAcuaticas();
            List<PaisUbigeoDTO> paisUbigeoDTO = paisUbigeoBL.ObtenerPaisUbigeos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ExpNavePrevencionContaminacion");

            return Json(new
            {
                data1 = dptoProteccionMedioAmbienteDTO,
                data2 = claseNaveDTO,
                data3 = instalacionTerrestreAcuaticaDTO,
                data4 = paisUbigeoDTO,
                data5 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ExpNavePrevencionContaminacionDTO> expNavePrevencionContaminacionDTO = expNavePrevencionContaminacionBL.ObtenerLista();
            return Json(new { data = expNavePrevencionContaminacionDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int NumeroDocumento, string CodigoInstalacionTerrestreAcuatica, int DocumentoExpedido, string CodigoClaseNave, string NumericoPais, 
            string PropietarioNave, string NombreNaveArtefacto, string FechaIngresoSolicitud, string FechaAtencionSolicitud , string CodigoDptoProteccionMedioAmbiente, 
            string MatriculaNave,int CargaId)
        {
            ExpNavePrevencionContaminacionDTO expNavePrevencionContaminacionDTO = new();
            expNavePrevencionContaminacionDTO.NumeroDocumento = NumeroDocumento;
            expNavePrevencionContaminacionDTO.FechaIngresoSolicitud = FechaIngresoSolicitud;
            expNavePrevencionContaminacionDTO.CodigoDptoProteccionMedioAmbiente = CodigoDptoProteccionMedioAmbiente;
            expNavePrevencionContaminacionDTO.DocumentoExpedido = DocumentoExpedido;
            expNavePrevencionContaminacionDTO.NombreNaveArtefacto = NombreNaveArtefacto;
            expNavePrevencionContaminacionDTO.CodigoClaseNave = CodigoClaseNave;
            expNavePrevencionContaminacionDTO.CodigoInstalacionTerrestreAcuatica = CodigoInstalacionTerrestreAcuatica;
            expNavePrevencionContaminacionDTO.MatriculaNave = MatriculaNave;
            expNavePrevencionContaminacionDTO.PropietarioNave = PropietarioNave;
            expNavePrevencionContaminacionDTO.NumericoPais = NumericoPais;
            expNavePrevencionContaminacionDTO.FechaAtencionSolicitud = FechaAtencionSolicitud;
            expNavePrevencionContaminacionDTO.CargaId = CargaId;
            expNavePrevencionContaminacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = expNavePrevencionContaminacionBL.AgregarRegistro(expNavePrevencionContaminacionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(expNavePrevencionContaminacionBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int ExpNavePrevencionContaminacionId, int NumeroDocumento, string CodigoInstalacionTerrestreAcuatica, int DocumentoExpedido, string CodigoClaseNave, string NumericoPais,
            string PropietarioNave, string NombreNaveArtefacto, string FechaIngresoSolicitud, string FechaAtencionSolicitud, string CodigoDptoProteccionMedioAmbiente,
            string MatriculaNave)
        {
            ExpNavePrevencionContaminacionDTO expNavePrevencionContaminacionDTO = new();
            expNavePrevencionContaminacionDTO.ExpNavePrevencionContaminacionId = ExpNavePrevencionContaminacionId;
            expNavePrevencionContaminacionDTO.NumeroDocumento = NumeroDocumento;
            expNavePrevencionContaminacionDTO.FechaIngresoSolicitud = FechaIngresoSolicitud;
            expNavePrevencionContaminacionDTO.CodigoDptoProteccionMedioAmbiente = CodigoDptoProteccionMedioAmbiente;
            expNavePrevencionContaminacionDTO.DocumentoExpedido = DocumentoExpedido;
            expNavePrevencionContaminacionDTO.NombreNaveArtefacto = NombreNaveArtefacto;
            expNavePrevencionContaminacionDTO.CodigoClaseNave = CodigoClaseNave;
            expNavePrevencionContaminacionDTO.CodigoInstalacionTerrestreAcuatica = CodigoInstalacionTerrestreAcuatica;
            expNavePrevencionContaminacionDTO.MatriculaNave = MatriculaNave;
            expNavePrevencionContaminacionDTO.PropietarioNave = PropietarioNave;
            expNavePrevencionContaminacionDTO.NumericoPais = NumericoPais;
            expNavePrevencionContaminacionDTO.FechaAtencionSolicitud = FechaAtencionSolicitud;
            expNavePrevencionContaminacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = expNavePrevencionContaminacionBL.ActualizarFormato(expNavePrevencionContaminacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ExpNavePrevencionContaminacionDTO expNavePrevencionContaminacionDTO = new();
            expNavePrevencionContaminacionDTO.ExpNavePrevencionContaminacionId = Id;
            expNavePrevencionContaminacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (expNavePrevencionContaminacionBL.EliminarFormato(expNavePrevencionContaminacionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ExpNavePrevencionContaminacionDTO> lista = new List<ExpNavePrevencionContaminacionDTO>();
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

                    lista.Add(new ExpNavePrevencionContaminacionDTO
                    {
                        NumeroDocumento = int.Parse(fila.GetCell(0).ToString()),
                        FechaIngresoSolicitud = fila.GetCell(1).ToString(),
                        CodigoDptoProteccionMedioAmbiente = fila.GetCell(2).ToString(),
                        DocumentoExpedido = int.Parse(fila.GetCell(3).ToString()),
                        NombreNaveArtefacto = fila.GetCell(4).ToString(),
                        CodigoClaseNave = fila.GetCell(5).ToString(),
                        CodigoInstalacionTerrestreAcuatica = fila.GetCell(6).ToString(),
                        MatriculaNave = fila.GetCell(7).ToString(),
                        PropietarioNave = fila.GetCell(8).ToString(),
                        NumericoPais = fila.GetCell(9).ToString(),
                        FechaAtencionSolicitud = fila.GetCell(10).ToString()
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

            dt.Columns.AddRange(new DataColumn[12]
            {
                    new DataColumn("NumeroDocumento", typeof(int)),
                    new DataColumn("FechaIngresoSolicitud", typeof(string)),
                    new DataColumn("CodigoDptoProteccionMedioAmbiente", typeof(string)),
                    new DataColumn("DocumentoExpedido", typeof(string)),
                    new DataColumn("NombreNaveArtefacto", typeof(string)),
                    new DataColumn("CodigoClaseNave", typeof(string)),
                    new DataColumn("CodigoInstalacionTerrestreAcuatica", typeof(string)),
                    new DataColumn("MatriculaNave", typeof(string)),
                    new DataColumn("PropietarioNave", typeof(string)),
                    new DataColumn("NumericoPais", typeof(string)),
                    new DataColumn("FechaAtencionSolicitud", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(7).ToString()),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(11).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = expNavePrevencionContaminacionBL.InsertarDatos(dt);
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
            var Capitanias = expNavePrevencionContaminacionBL.ObtenerLista();
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