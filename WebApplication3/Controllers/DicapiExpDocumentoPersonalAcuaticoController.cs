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
    public class DicapiExpDocumentoPersonalAcuaticoController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ExpDocumentoPersonalAcuatico expDocumentoPersonalAcuaticoBL = new();
        DptoPersonalAcuatico dptoPersonalAcuaticoBL = new();
        TipoPersonalAcuatico tipoPersonalAcuaticoBL = new();
        TipoActividadEmpresa tipoActividadEmpresaBL = new();
        Carga cargaBL = new();

        public DicapiExpDocumentoPersonalAcuaticoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Expedición de Documentos al Personal Acuatico", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DptoPersonalAcuaticoDTO> dptoPersonalAcuaticoDTO = dptoPersonalAcuaticoBL.ObtenerDptoPersonalAcuaticos(); 
            List<TipoPersonalAcuaticoDTO> tipoPersonalAcuaticoDTO = tipoPersonalAcuaticoBL.ObtenerTipoPersonalAcuaticos();
            List<TipoActividadEmpresaDTO> tipoActividadEmpresaDTO = tipoActividadEmpresaBL.ObtenerTipoActividadEmpresas();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ExpoDocumentoPersonalAcuatico");

            return Json(new
            {
                data1 = dptoPersonalAcuaticoDTO,
                data2 = tipoPersonalAcuaticoDTO,
                data3 = tipoActividadEmpresaDTO,
                data4 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ExpDocumentoPersonalAcuaticoDTO> expDocumentoPersonalAcuaticoDTO = expDocumentoPersonalAcuaticoBL.ObtenerLista();
            return Json(new { data = expDocumentoPersonalAcuaticoDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int NumeroDocumento, string CodigoDptoPersonalAcuatico, int DocumentoExpedido, string CodigoTipoPersonalAcuatico, string CodigoTipoActividadEmpresa, 
            string ExpedidoA, string NombreApellidoAcuatico, string FechaIngresoSolicitud, string FechaAtencionSolicitud, int CargaId)
        {
            ExpDocumentoPersonalAcuaticoDTO expDocumentoPersonalAcuaticoDTO = new();
            expDocumentoPersonalAcuaticoDTO.NumeroDocumento = NumeroDocumento;
            expDocumentoPersonalAcuaticoDTO.FechaIngresoSolicitud = FechaIngresoSolicitud;
            expDocumentoPersonalAcuaticoDTO.CodigoDptoPersonalAcuatico = CodigoDptoPersonalAcuatico;
            expDocumentoPersonalAcuaticoDTO.DocumentoExpedido = DocumentoExpedido;
            expDocumentoPersonalAcuaticoDTO.ExpedidoA = ExpedidoA;
            expDocumentoPersonalAcuaticoDTO.NombreApellidoAcuatico = NombreApellidoAcuatico;
            expDocumentoPersonalAcuaticoDTO.CodigoTipoPersonalAcuatico = CodigoTipoPersonalAcuatico;
            expDocumentoPersonalAcuaticoDTO.CodigoTipoActividadEmpresa = CodigoTipoActividadEmpresa;
            expDocumentoPersonalAcuaticoDTO.FechaAtencionSolicitud = FechaAtencionSolicitud;
            expDocumentoPersonalAcuaticoDTO.CargaId = CargaId;
            expDocumentoPersonalAcuaticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = expDocumentoPersonalAcuaticoBL.AgregarRegistro(expDocumentoPersonalAcuaticoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(expDocumentoPersonalAcuaticoBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int ExpDocumentoPersonalAcuaticoId, int NumeroDocumento, string CodigoDptoPersonalAcuatico, int DocumentoExpedido, string CodigoTipoPersonalAcuatico, string CodigoTipoActividadEmpresa,
            string ExpedidoA, string NombreApellidoAcuatico, string FechaIngresoSolicitud, string FechaAtencionSolicitud)
        {
            ExpDocumentoPersonalAcuaticoDTO expDocumentoPersonalAcuaticoDTO = new();
            expDocumentoPersonalAcuaticoDTO.ExpDocumentoPersonalAcuaticoId = ExpDocumentoPersonalAcuaticoId;
            expDocumentoPersonalAcuaticoDTO.NumeroDocumento = NumeroDocumento;
            expDocumentoPersonalAcuaticoDTO.FechaIngresoSolicitud = FechaIngresoSolicitud;
            expDocumentoPersonalAcuaticoDTO.CodigoDptoPersonalAcuatico = CodigoDptoPersonalAcuatico;
            expDocumentoPersonalAcuaticoDTO.DocumentoExpedido = DocumentoExpedido;
            expDocumentoPersonalAcuaticoDTO.ExpedidoA = ExpedidoA;
            expDocumentoPersonalAcuaticoDTO.NombreApellidoAcuatico = NombreApellidoAcuatico;
            expDocumentoPersonalAcuaticoDTO.CodigoTipoPersonalAcuatico = CodigoTipoPersonalAcuatico;
            expDocumentoPersonalAcuaticoDTO.CodigoTipoActividadEmpresa = CodigoTipoActividadEmpresa;
            expDocumentoPersonalAcuaticoDTO.FechaAtencionSolicitud = FechaAtencionSolicitud;
            expDocumentoPersonalAcuaticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = expDocumentoPersonalAcuaticoBL.ActualizarFormato(expDocumentoPersonalAcuaticoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ExpDocumentoPersonalAcuaticoDTO expDocumentoPersonalAcuaticoDTO = new();
            expDocumentoPersonalAcuaticoDTO.ExpDocumentoPersonalAcuaticoId = Id;
            expDocumentoPersonalAcuaticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (expDocumentoPersonalAcuaticoBL.EliminarFormato(expDocumentoPersonalAcuaticoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ExpDocumentoPersonalAcuaticoDTO> lista = new List<ExpDocumentoPersonalAcuaticoDTO>();
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

                    lista.Add(new ExpDocumentoPersonalAcuaticoDTO
                    {
                        NumeroDocumento = int.Parse(fila.GetCell(0).ToString()),
                        FechaIngresoSolicitud = fila.GetCell(1).ToString(),
                        CodigoDptoPersonalAcuatico = fila.GetCell(2).ToString(),
                        ExpedidoA = fila.GetCell(3).ToString(),
                        NombreApellidoAcuatico = fila.GetCell(4).ToString(),
                        CodigoTipoPersonalAcuatico = fila.GetCell(5).ToString(),
                        CodigoTipoActividadEmpresa = fila.GetCell(6).ToString(),
                        FechaAtencionSolicitud = fila.GetCell(7).ToString()
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

            dt.Columns.AddRange(new DataColumn[9]
            {
                    new DataColumn("NumeroDocumento", typeof(int)),
                    new DataColumn("FechaIngresoSolicitud", typeof(string)),
                    new DataColumn("CodigoDptoPersonalAcuatico", typeof(string)),
                    new DataColumn("ExpedidoA", typeof(string)),
                    new DataColumn("NombreApellidoAcuatico", typeof(string)),
                    new DataColumn("CodigoTipoPersonalAcuatico", typeof(string)),
                    new DataColumn("CodigoTipoActividadEmpresa", typeof(string)),
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
                    User.obtenerUsuario());
            }
            var IND_OPERACION = expDocumentoPersonalAcuaticoBL.InsertarDatos(dt);
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
            var Capitanias = expDocumentoPersonalAcuaticoBL.ObtenerLista();
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