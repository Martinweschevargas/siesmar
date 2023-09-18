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
    public class DicapiExpDocumentoNaveArtefactoController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ExpDocumentoNaveArtefacto expDocumentoNaveArtefactoBL = new();
        DptoMaterialAcuatico dptoMaterialAcuaticoBL = new();
        ClaseNave claseNaveBL = new();
        PaisUbigeo paisUbigeoBL = new();
        Capitania capitaniaBL = new();
        Carga cargaBL = new();

        public DicapiExpDocumentoNaveArtefactoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Expedición de Documentos de Naves y Artefactos Navales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DptoMaterialAcuaticoDTO> dptoMaterialAcuaticoDTO = dptoMaterialAcuaticoBL.ObtenerDptoMaterialAcuaticos(); 
            List<ClaseNaveDTO> claseNaveDTO = claseNaveBL.ObtenerClaseNaves();
            List<PaisUbigeoDTO> paisUbigeoDTO = paisUbigeoBL.ObtenerPaisUbigeos();
            List<CapitaniaDTO> capitaniaDTO = capitaniaBL.ObtenerCapitanias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ExpDocumentoNaveArtefacto");

            return Json(new
            {
                data1 = dptoMaterialAcuaticoDTO,
                data2 = claseNaveDTO,
                data3 = paisUbigeoDTO,
                data4 = capitaniaDTO,
                data5 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ExpDocumentoNaveArtefactoDTO> expDocumentoNaveArtefactoDTO = expDocumentoNaveArtefactoBL.ObtenerLista();
            return Json(new { data = expDocumentoNaveArtefactoDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int NumeroDocumento, string CodigoDptoMaterialAcuatico, int DocumentoExpedido, string CodigoClaseNave, string NumericoPais, 
            string PropietarioNave, string NombreNaveArtefacto, string FechaIngresoSolicitud, string FechaAtencionSolicitud, string ResponsableDocumentoExpedido
            , string Observacion , string CodigoCapitania , string RazonSocial , string MatriculaNave, int CargaId)
        {
            ExpDocumentoNaveArtefactoDTO expDocumentoNaveArtefactoDTO = new();
            expDocumentoNaveArtefactoDTO.NumeroDocumento = NumeroDocumento;
            expDocumentoNaveArtefactoDTO.FechaIngresoSolicitud = FechaIngresoSolicitud;
            expDocumentoNaveArtefactoDTO.CodigoDptoMaterialAcuatico = CodigoDptoMaterialAcuatico;
            expDocumentoNaveArtefactoDTO.NombreNaveArtefacto = NombreNaveArtefacto;
            expDocumentoNaveArtefactoDTO.PropietarioNave = PropietarioNave;
            expDocumentoNaveArtefactoDTO.RazonSocial = RazonSocial;
            expDocumentoNaveArtefactoDTO.CodigoClaseNave = CodigoClaseNave;
            expDocumentoNaveArtefactoDTO.MatriculaNave = MatriculaNave;
            expDocumentoNaveArtefactoDTO.NumericoPais = NumericoPais;
            expDocumentoNaveArtefactoDTO.FechaAtencionSolicitud = FechaAtencionSolicitud;
            expDocumentoNaveArtefactoDTO.Observacion = Observacion;
            expDocumentoNaveArtefactoDTO.ResponsableDocumentoExpedido = ResponsableDocumentoExpedido;
            expDocumentoNaveArtefactoDTO.CodigoCapitania = CodigoCapitania;
            expDocumentoNaveArtefactoDTO.CargaId = CargaId;

            expDocumentoNaveArtefactoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = expDocumentoNaveArtefactoBL.AgregarRegistro(expDocumentoNaveArtefactoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(expDocumentoNaveArtefactoBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int ExpDocumentoNaveArtefactoId, int NumeroDocumento, string CodigoDptoMaterialAcuatico, int DocumentoExpedido, string CodigoClaseNave, string NumericoPais,
            string PropietarioNave, string NombreNaveArtefacto, string FechaIngresoSolicitud, string FechaAtencionSolicitud, string ResponsableDocumentoExpedido
            , string Observacion, string CodigoCapitania, string RazonSocial, string MatriculaNave)
        {
            ExpDocumentoNaveArtefactoDTO expDocumentoNaveArtefactoDTO = new();
            expDocumentoNaveArtefactoDTO.ExpDocumentoNaveArtefactoId = ExpDocumentoNaveArtefactoId;
            expDocumentoNaveArtefactoDTO.NumeroDocumento = NumeroDocumento;
            expDocumentoNaveArtefactoDTO.FechaIngresoSolicitud = FechaIngresoSolicitud;
            expDocumentoNaveArtefactoDTO.CodigoDptoMaterialAcuatico = CodigoDptoMaterialAcuatico;
            expDocumentoNaveArtefactoDTO.NombreNaveArtefacto = NombreNaveArtefacto;
            expDocumentoNaveArtefactoDTO.PropietarioNave = PropietarioNave;
            expDocumentoNaveArtefactoDTO.RazonSocial = RazonSocial;
            expDocumentoNaveArtefactoDTO.CodigoClaseNave = CodigoClaseNave;
            expDocumentoNaveArtefactoDTO.MatriculaNave = MatriculaNave;
            expDocumentoNaveArtefactoDTO.NumericoPais = NumericoPais;
            expDocumentoNaveArtefactoDTO.FechaAtencionSolicitud = FechaAtencionSolicitud;
            expDocumentoNaveArtefactoDTO.Observacion = Observacion;
            expDocumentoNaveArtefactoDTO.ResponsableDocumentoExpedido = ResponsableDocumentoExpedido;
            expDocumentoNaveArtefactoDTO.CodigoCapitania = CodigoCapitania;
            expDocumentoNaveArtefactoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = expDocumentoNaveArtefactoBL.ActualizarFormato(expDocumentoNaveArtefactoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ExpDocumentoNaveArtefactoDTO expDocumentoNaveArtefactoDTO = new();
            expDocumentoNaveArtefactoDTO.ExpDocumentoNaveArtefactoId = Id;
            expDocumentoNaveArtefactoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (expDocumentoNaveArtefactoBL.EliminarFormato(expDocumentoNaveArtefactoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ExpDocumentoNaveArtefactoDTO> lista = new List<ExpDocumentoNaveArtefactoDTO>();
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

                    lista.Add(new ExpDocumentoNaveArtefactoDTO
                    {
                        NumeroDocumento = int.Parse(fila.GetCell(0).ToString()),
                        FechaIngresoSolicitud = fila.GetCell(1).ToString(),
                        CodigoDptoMaterialAcuatico = fila.GetCell(2).ToString(),
                        NombreNaveArtefacto = fila.GetCell(3).ToString(),
                        PropietarioNave = fila.GetCell(4).ToString(),
                        RazonSocial = fila.GetCell(5).ToString(),
                        CodigoClaseNave = fila.GetCell(6).ToString(),
                        MatriculaNave = fila.GetCell(7).ToString(),
                        NumericoPais = fila.GetCell(8).ToString(),
                        FechaAtencionSolicitud = fila.GetCell(9).ToString(),
                        Observacion = fila.GetCell(10).ToString(),
                        ResponsableDocumentoExpedido = fila.GetCell(11).ToString(),
                        CodigoCapitania = fila.GetCell(12).ToString()
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
                    new DataColumn("NumeroDocumento", typeof(int)),
                    new DataColumn("FechaIngresoSolicitud", typeof(string)),
                    new DataColumn("CodigoDptoMaterialAcuatico", typeof(string)),
                    new DataColumn("DocumentoExpedido", typeof(int)),
                    new DataColumn("NombreNaveArtefacto", typeof(string)),
                    new DataColumn("PropietarioNave", typeof(string)),
                    new DataColumn("RazonSocial", typeof(string)),
                    new DataColumn("CodigoClaseNave", typeof(string)),
                    new DataColumn("MatriculaNave", typeof(string)),
                    new DataColumn("NumericoPais", typeof(string)),
                    new DataColumn("FechaAtencionSolicitud", typeof(string)),
                    new DataColumn("Observacion", typeof(string)),
                    new DataColumn("ResponsableDocumentoExpedido", typeof(string)),
                    new DataColumn("CodigoCapitania", typeof(string)),
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
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(9).ToString()),
                    fila.GetCell(10).ToString(),
                    fila.GetCell(11).ToString(),
                    fila.GetCell(12).ToString(),
                    fila.GetCell(13).ToString(),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = expDocumentoNaveArtefactoBL.InsertarDatos(dt);
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
            var Capitanias = expDocumentoNaveArtefactoBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ DicapiExpDocumentoNaveArtefacto.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", " DicapiExpDocumentoNaveArtefacto.xlsx");
        }
    }

}