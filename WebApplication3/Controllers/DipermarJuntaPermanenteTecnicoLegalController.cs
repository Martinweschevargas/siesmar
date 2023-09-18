using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dipermar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
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
using SixLabors.ImageSharp.ColorSpaces;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class DipermarJuntaPermanenteTecnicoLegalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        JuntaPermanenteTecnicoLegal juntaPermanenteTecnicoLegalBL = new();
        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        Afeccion afeccionBL = new();
        Carga cargaBL = new();

        public DipermarJuntaPermanenteTecnicoLegalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Junta Permanente Tecnico Legal del Personal Superior y Subalterno de la Marina de Guerra del Perú", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<AfeccionDTO> afeccionDTO = afeccionBL.ObtenerAfeccions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("JuntaPermanenteTecnicoLegal");
            return Json(new { data1 = gradoPersonalMilitarDTO, data2 = tipoPersonalMilitarDTO,  data3 = afeccionDTO, data4 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<JuntaPermanenteTecnicoLegalDTO> select = juntaPermanenteTecnicoLegalBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
             return View();
        }

        //[AuthorizePermission(Formato: 625, Permiso: 1)]//Registrar
        public ActionResult Insertar( string NroDocumentoJunta, string FechaDocumentoJunta,
            string DocumentacionCompleta, string FechaIngresoDocumento, string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar,
            string SexoPersonal, string CodigoAfeccion, string SituacionActualJunta, string NroActa, string FechaActa, string ConclusionJunta, int CargaId, string Fecha)
        {
            JuntaPermanenteTecnicoLegalDTO juntaPermanenteTecnicoLegalDTO = new();
            juntaPermanenteTecnicoLegalDTO.NroDocumentoJunta = NroDocumentoJunta;
            juntaPermanenteTecnicoLegalDTO.FechaDocumentoJunta = FechaDocumentoJunta;
            juntaPermanenteTecnicoLegalDTO.DocumentacionCompleta = DocumentacionCompleta;
            juntaPermanenteTecnicoLegalDTO.FechaIngresoDocumento = FechaIngresoDocumento;
            juntaPermanenteTecnicoLegalDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            juntaPermanenteTecnicoLegalDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            juntaPermanenteTecnicoLegalDTO.SexoPersonal = SexoPersonal;
            juntaPermanenteTecnicoLegalDTO.CodigoAfeccion = CodigoAfeccion;
            juntaPermanenteTecnicoLegalDTO.SituacionActualJunta = SituacionActualJunta;
            juntaPermanenteTecnicoLegalDTO.NroActa = NroActa;
            juntaPermanenteTecnicoLegalDTO.FechaActa = FechaActa;
            juntaPermanenteTecnicoLegalDTO.ConclusionJunta = ConclusionJunta;
            juntaPermanenteTecnicoLegalDTO.CargaId = CargaId;
            juntaPermanenteTecnicoLegalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = juntaPermanenteTecnicoLegalBL.AgregarRegistro(juntaPermanenteTecnicoLegalDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(juntaPermanenteTecnicoLegalBL.BuscarFormato(Id));
        }

        //[AuthorizePermission(Formato: 625, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string NroDocumentoJunta, string FechaDocumentoJunta,
            string DocumentacionCompleta, string FechaIngresoDocumento, string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar,
            string SexoPersonal, string CodigoAfeccion, string SituacionActualJunta, string NroActa, string FechaActa, string ConclusionJunta)
        {
            JuntaPermanenteTecnicoLegalDTO juntaPermanenteTecnicoLegalDTO = new();
            juntaPermanenteTecnicoLegalDTO.JuntaPermanenteTecnicoLegalId = Id;
            juntaPermanenteTecnicoLegalDTO.NroDocumentoJunta = NroDocumentoJunta;
            juntaPermanenteTecnicoLegalDTO.FechaDocumentoJunta = FechaDocumentoJunta;
            juntaPermanenteTecnicoLegalDTO.DocumentacionCompleta = DocumentacionCompleta;
            juntaPermanenteTecnicoLegalDTO.FechaIngresoDocumento = FechaIngresoDocumento;
            juntaPermanenteTecnicoLegalDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            juntaPermanenteTecnicoLegalDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            juntaPermanenteTecnicoLegalDTO.SexoPersonal = SexoPersonal;
            juntaPermanenteTecnicoLegalDTO.CodigoAfeccion = CodigoAfeccion;
            juntaPermanenteTecnicoLegalDTO.SituacionActualJunta = SituacionActualJunta;
            juntaPermanenteTecnicoLegalDTO.NroActa = NroActa;
            juntaPermanenteTecnicoLegalDTO.FechaActa = FechaActa;
            juntaPermanenteTecnicoLegalDTO.ConclusionJunta = ConclusionJunta;
            juntaPermanenteTecnicoLegalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = juntaPermanenteTecnicoLegalBL.ActualizarFormato(juntaPermanenteTecnicoLegalDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 625, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            JuntaPermanenteTecnicoLegalDTO juntaPermanenteTecnicoLegalDTO = new();
            juntaPermanenteTecnicoLegalDTO.JuntaPermanenteTecnicoLegalId = Id;
            juntaPermanenteTecnicoLegalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (juntaPermanenteTecnicoLegalBL.EliminarFormato(juntaPermanenteTecnicoLegalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 625, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            JuntaPermanenteTecnicoLegalDTO juntaPermanenteTecnicoLegalDTO = new();
            juntaPermanenteTecnicoLegalDTO.CargaId = Id;
            juntaPermanenteTecnicoLegalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (juntaPermanenteTecnicoLegalBL.EliminarCarga(juntaPermanenteTecnicoLegalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<JuntaPermanenteTecnicoLegalDTO> lista = new List<JuntaPermanenteTecnicoLegalDTO>();
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

                    lista.Add(new JuntaPermanenteTecnicoLegalDTO
                    {
                        NroDocumentoJunta = fila.GetCell(0).ToString(),
                        FechaDocumentoJunta = fila.GetCell(1).ToString(),
                        DocumentacionCompleta = fila.GetCell(2).ToString(),
                        FechaIngresoDocumento = fila.GetCell(3).ToString(),
                        CodigoTipoPersonalMilitar = fila.GetCell(4).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(5).ToString(),
                        SexoPersonal = fila.GetCell(6).ToString(),
                        CodigoAfeccion = fila.GetCell(7).ToString(),
                        SituacionActualJunta = fila.GetCell(8).ToString(),
                        NroActa = fila.GetCell(9).ToString(),
                        FechaActa = fila.GetCell(10).ToString(),
                        ConclusionJunta = fila.GetCell(11).ToString()
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
        //[AuthorizePermission(Formato: 625, Permiso: 4)]//Registrar Masivo
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
                 new DataColumn("NroDocumentoJunta", typeof(string)),
                 new DataColumn("FechaDocumentoJunta", typeof(string)),
                 new DataColumn("DocumentacionCompleta", typeof(string)),
                 new DataColumn("FechaIngresoDocumento", typeof(string)),
                 new DataColumn("CodigoTipoPersonalMilitar", typeof(string)),
                 new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                 new DataColumn("SexoPersonal", typeof(string)),
                 new DataColumn("CodigoAfeccion", typeof(string)),
                 new DataColumn("SituacionActualJunta", typeof(string)),
                 new DataColumn("NroActa", typeof(string)),
                 new DataColumn("FechaActa", typeof(string)),
                 new DataColumn("ConclusionJunta", typeof(string)),
 
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
                    fila.GetCell(11).ToString(),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = juntaPermanenteTecnicoLegalBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DipermarJuntaPermanenteTecnicoLegal.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DipermarJuntaPermanenteTecnicoLegal.xlsx");
        }

        public IActionResult ReporteJPTC(int? CargaId = null)
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dipermar\\JuntaPermanenteTecnicoLegal.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var juntaPermanenteTecnicoLegal = juntaPermanenteTecnicoLegalBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("JuntaPermanenteTecnicoLegal", juntaPermanenteTecnicoLegal);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }



    }

}

