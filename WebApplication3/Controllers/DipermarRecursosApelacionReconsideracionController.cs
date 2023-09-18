using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dipermar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dipermar;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Presentacion.Filters;
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

    public class DipermarRecursosApelacionReconsideracionController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        RecursosApelacionReconsideracion recursosApelacionReconsideracionBL = new();
        Dependencia dependenciaBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        AsuntoApelacionReconsideracion asuntoApelacionReconsideracionBL = new();
        ResultadoApelacionReconsideracion resultadoApelacionReconsideracionBL = new();
        Carga cargaBL = new();

        public DipermarRecursosApelacionReconsideracionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Recursos de Apelación y Reconsideración Presentados", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<AsuntoApelacionReconsideracionDTO> asuntoApelacionDTO = asuntoApelacionReconsideracionBL.ObtenerAsuntoApelacionReconsideracions();
            List<ResultadoApelacionReconsideracionDTO> resultadoApelacionDTO = resultadoApelacionReconsideracionBL.ObtenerResultadoApelacionReconsideracions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("RecursosApelacionReconsideracion");

            return Json(new { data1 = dependenciaDTO, data2 = gradoPersonalMilitarDTO,  data3 = asuntoApelacionDTO,  data4 = resultadoApelacionDTO, data5 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<RecursosApelacionReconsideracionDTO> select = recursosApelacionReconsideracionBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 627, Permiso: 1)]//Registrar
        public ActionResult Insertar(string NroDocumento, string FechaDocumento, string CodigoDependencia, string FechaIngresoDocumento,
            string CodigoGradoPersonalMilitar, string TipoRecurso, string CodigoAsuntoApelacionReconsideracion, string DescripcionApelacion,
            string CodigoResultadoApelacionReconsideracion, string DocumentoResolutivo, string FechaDocumentoResolutivo, string FechaNotificacion, int CargaId, string Fecha)
        {
            RecursosApelacionReconsideracionDTO recursosApelacionReconsideracionDTO = new();
            recursosApelacionReconsideracionDTO.NroDocumento = NroDocumento;
            recursosApelacionReconsideracionDTO.FechaDocumento = FechaDocumento;
            recursosApelacionReconsideracionDTO.CodigoDependencia = CodigoDependencia;
            recursosApelacionReconsideracionDTO.FechaIngresoDocumento = FechaIngresoDocumento;
            recursosApelacionReconsideracionDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            recursosApelacionReconsideracionDTO.TipoRecurso = TipoRecurso;
            recursosApelacionReconsideracionDTO.CodigoAsuntoApelacionReconsideracion = CodigoAsuntoApelacionReconsideracion;
            recursosApelacionReconsideracionDTO.DescripcionApelacion = DescripcionApelacion;
            recursosApelacionReconsideracionDTO.CodigoResultadoApelacionReconsideracion = CodigoResultadoApelacionReconsideracion;
            recursosApelacionReconsideracionDTO.DocumentoResolutivo = DocumentoResolutivo;
            recursosApelacionReconsideracionDTO.FechaDocumentoResolutivo = FechaDocumentoResolutivo;
            recursosApelacionReconsideracionDTO.FechaNotificacion = FechaNotificacion;
            recursosApelacionReconsideracionDTO.CargaId = CargaId;
            recursosApelacionReconsideracionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = recursosApelacionReconsideracionBL.AgregarRegistro(recursosApelacionReconsideracionDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(recursosApelacionReconsideracionBL.BuscarFormato(Id));
        }

        //[AuthorizePermission(Formato: 627, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string NroDocumento, string FechaDocumento, string CodigoDependencia, string FechaIngresoDocumento,
            string CodigoGradoPersonalMilitar, string TipoRecurso, string CodigoAsuntoApelacionReconsideracion, string DescripcionApelacion,
            string CodigoResultadoApelacionReconsideracion, string DocumentoResolutivo, string FechaDocumentoResolutivo, string FechaNotificacion)
        {
            RecursosApelacionReconsideracionDTO recursosApelacionReconsideracionDTO = new();
            recursosApelacionReconsideracionDTO.RecursoApelacionReconsideracionId = Id;
            recursosApelacionReconsideracionDTO.NroDocumento = NroDocumento;
            recursosApelacionReconsideracionDTO.FechaDocumento = FechaDocumento;
            recursosApelacionReconsideracionDTO.CodigoDependencia = CodigoDependencia;
            recursosApelacionReconsideracionDTO.FechaIngresoDocumento = FechaIngresoDocumento;
            recursosApelacionReconsideracionDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            recursosApelacionReconsideracionDTO.TipoRecurso = TipoRecurso;
            recursosApelacionReconsideracionDTO.CodigoAsuntoApelacionReconsideracion = CodigoAsuntoApelacionReconsideracion;
            recursosApelacionReconsideracionDTO.DescripcionApelacion = DescripcionApelacion;
            recursosApelacionReconsideracionDTO.CodigoResultadoApelacionReconsideracion = CodigoResultadoApelacionReconsideracion;
            recursosApelacionReconsideracionDTO.DocumentoResolutivo = DocumentoResolutivo;
            recursosApelacionReconsideracionDTO.FechaDocumentoResolutivo = FechaDocumentoResolutivo;
            recursosApelacionReconsideracionDTO.FechaNotificacion = FechaNotificacion;
            recursosApelacionReconsideracionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = recursosApelacionReconsideracionBL.ActualizarFormato(recursosApelacionReconsideracionDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 627, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RecursosApelacionReconsideracionDTO recursosApelacionReconsideracionDTO = new();
            recursosApelacionReconsideracionDTO.RecursoApelacionReconsideracionId = Id;
            recursosApelacionReconsideracionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (recursosApelacionReconsideracionBL.EliminarFormato(recursosApelacionReconsideracionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 627, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            RecursosApelacionReconsideracionDTO recursosApelacionReconsideracionDTO = new();
            recursosApelacionReconsideracionDTO.CargaId = Id;
            recursosApelacionReconsideracionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (recursosApelacionReconsideracionBL.EliminarCarga(recursosApelacionReconsideracionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<RecursosApelacionReconsideracionDTO> lista = new List<RecursosApelacionReconsideracionDTO>();
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

                    lista.Add(new RecursosApelacionReconsideracionDTO
                    {
                        NroDocumento = fila.GetCell(0).ToString(),
                        FechaDocumento = fila.GetCell(1).ToString(),
                        CodigoDependencia = fila.GetCell(2).ToString(),
                        FechaIngresoDocumento = fila.GetCell(3).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(4).ToString(),
                        TipoRecurso = fila.GetCell(5).ToString(),
                        CodigoAsuntoApelacionReconsideracion = fila.GetCell(6).ToString(),
                        DescripcionApelacion = fila.GetCell(7).ToString(),
                        CodigoResultadoApelacionReconsideracion = fila.GetCell(8).ToString(),
                        DocumentoResolutivo = fila.GetCell(9).ToString(),
                        FechaDocumentoResolutivo = fila.GetCell(10).ToString(),
                        FechaNotificacion = fila.GetCell(11).ToString()
 
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
        //[AuthorizePermission(Formato: 627, Permiso: 4)]//Registrar Masivo

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

            dt.Columns.AddRange(new DataColumn[13]
            {
                    new DataColumn("NroDocumento", typeof(string)),
                    new DataColumn("FechaDocumento", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("FechaIngresoDocumento", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("TipoRecurso", typeof(string)),
                    new DataColumn("CodigoAsuntoApelacionReconsideracion", typeof(string)),
                    new DataColumn("DescripcionApelacion", typeof(string)),
                    new DataColumn("CodigoResultadoApelacionReconsideracion", typeof(string)),
                    new DataColumn("DocumentoResolutivo", typeof(string)),
                    new DataColumn("FechaDocumentoResolutivo", typeof(string)),
                    new DataColumn("FechaNotificacion", typeof(string)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(10).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(11).ToString()),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = recursosApelacionReconsideracionBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteRAR(int? CargaId = null)
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dipermar\\RecursosApelacionReconsideracion.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var recursosApelacionReconsideracion = recursosApelacionReconsideracionBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("RecursosApelacionReconsideracion", recursosApelacionReconsideracion);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DipermarRecursosApelacionReconsideracion.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DipermarRecursosApelacionReconsideracion.xlsx");
        }
    }

}

