using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dihidronav;
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
    public class DihidronavEvaluacionExpedienteTecnicoController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        EvaluacionExpedienteTecnico evaluacionExpedienteTecnicoBL = new();
        TipoEstudio tipoEstudioBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        Carga cargaBL = new();

        public DihidronavEvaluacionExpedienteTecnicoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Evaluación de Expediente Técnico", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoEstudioDTO> tipoEstudioDTO = tipoEstudioBL.ObtenerTipoEstudios(); 
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EvaluacionExpedienteTecnico");

            return Json(new
            {
                data1 = tipoEstudioDTO,
                data2 = departamentoUbigeoDTO,
                data3 = provinciaUbigeoDTO,
                data4 = distritoUbigeoDTO,
                data5 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionExpedienteTecnicoDTO> evaluacionExpedienteTecnicoDTO = evaluacionExpedienteTecnicoBL.ObtenerLista();
            return Json(new { data = evaluacionExpedienteTecnicoDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int NumeroOrden, string CodigoTipoEstudio, string EmpresaRealizaTrabajo, 
            string DescripcionEstudio, string DocumentoRespuesta, string EmpresaPersonaSolicitante, string DistritoUbigeo, 
            string FechaTerminoEvaluacion, string CondicionEvaluacion, int CargaId)
        {
            EvaluacionExpedienteTecnicoDTO evaluacionExpedienteTecnicoDTO = new();
            evaluacionExpedienteTecnicoDTO.NumeroOrden = NumeroOrden;
            evaluacionExpedienteTecnicoDTO.CodigoTipoEstudio = CodigoTipoEstudio;
            evaluacionExpedienteTecnicoDTO.DescripcionEstudio = DescripcionEstudio;
            evaluacionExpedienteTecnicoDTO.DocumentoRespuesta = DocumentoRespuesta; 
            evaluacionExpedienteTecnicoDTO.FechaTerminoEvaluacion = FechaTerminoEvaluacion;
            evaluacionExpedienteTecnicoDTO.EmpresaPersonaSolicitante = EmpresaPersonaSolicitante;
            evaluacionExpedienteTecnicoDTO.EmpresaRealizaTrabajo = EmpresaRealizaTrabajo;
            evaluacionExpedienteTecnicoDTO.DistritoUbigeo = DistritoUbigeo;
            evaluacionExpedienteTecnicoDTO.CondicionEvaluacion = CondicionEvaluacion;
            evaluacionExpedienteTecnicoDTO.CargaId = CargaId;
            evaluacionExpedienteTecnicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionExpedienteTecnicoBL.AgregarRegistro(evaluacionExpedienteTecnicoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionExpedienteTecnicoBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int EvaluacionExpedienteTecnicoId, int NumeroOrden, string CodigoTipoEstudio, string EmpresaRealizaTrabajo,
            string DescripcionEstudio, string DocumentoRespuesta, string EmpresaPersonaSolicitante, string DistritoUbigeo,
            string FechaTerminoEvaluacion, string CondicionEvaluacion)
        {
            EvaluacionExpedienteTecnicoDTO evaluacionExpedienteTecnicoDTO = new();
            evaluacionExpedienteTecnicoDTO.EvaluacionExpedienteTecnicoId = EvaluacionExpedienteTecnicoId;
            evaluacionExpedienteTecnicoDTO.NumeroOrden = NumeroOrden;
            evaluacionExpedienteTecnicoDTO.CodigoTipoEstudio = CodigoTipoEstudio;
            evaluacionExpedienteTecnicoDTO.DescripcionEstudio = DescripcionEstudio;
            evaluacionExpedienteTecnicoDTO.DocumentoRespuesta = DocumentoRespuesta;
            evaluacionExpedienteTecnicoDTO.FechaTerminoEvaluacion = FechaTerminoEvaluacion;
            evaluacionExpedienteTecnicoDTO.EmpresaPersonaSolicitante = EmpresaPersonaSolicitante;
            evaluacionExpedienteTecnicoDTO.EmpresaRealizaTrabajo = EmpresaRealizaTrabajo;
            evaluacionExpedienteTecnicoDTO.DistritoUbigeo = DistritoUbigeo;
            evaluacionExpedienteTecnicoDTO.CondicionEvaluacion = CondicionEvaluacion;
            evaluacionExpedienteTecnicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionExpedienteTecnicoBL.ActualizarFormato(evaluacionExpedienteTecnicoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionExpedienteTecnicoDTO evaluacionExpedienteTecnicoDTO = new();
            evaluacionExpedienteTecnicoDTO.EvaluacionExpedienteTecnicoId = Id;
            evaluacionExpedienteTecnicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionExpedienteTecnicoBL.EliminarFormato(evaluacionExpedienteTecnicoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionExpedienteTecnicoDTO> lista = new List<EvaluacionExpedienteTecnicoDTO>();
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

                    lista.Add(new EvaluacionExpedienteTecnicoDTO
                    {
                        NumeroOrden = int.Parse(fila.GetCell(0).ToString()),
                        CodigoTipoEstudio = fila.GetCell(1).ToString(),
                        DescripcionEstudio = fila.GetCell(2).ToString(),
                        DocumentoRespuesta = fila.GetCell(3).ToString(),
                        FechaTerminoEvaluacion = fila.GetCell(4).ToString(),
                        EmpresaPersonaSolicitante = fila.GetCell(5).ToString(),
                        EmpresaRealizaTrabajo = fila.GetCell(6).ToString(),
                        DistritoUbigeo = fila.GetCell(7).ToString(),
                        CondicionEvaluacion = fila.GetCell(8).ToString()
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
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
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

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("NumeroOrden", typeof(int)),
                    new DataColumn("CodigoTipoEstudio", typeof(string)),
                    new DataColumn("DescripcionEstudio", typeof(string)),
                    new DataColumn("DocumentoRespuesta", typeof(string)),
                    new DataColumn("FechaTerminoEvaluacion", typeof(string)),
                    new DataColumn("EmpresaPersonaSolicitante", typeof(string)),
                    new DataColumn("EmpresaRealizaTrabajo", typeof(string)),
                    new DataColumn("DistritoUbigeo", typeof(string)),
                    new DataColumn("CondicionEvaluacion", typeof(string)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(4).ToString()),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    
                    User.obtenerUsuario());
            }
            var IND_OPERACION = evaluacionExpedienteTecnicoBL.InsertarDatos(dt);
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

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DihidronavEvaluacionExpedienteTecnico.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DihidronavEvaluacionExpedienteTecnico.xlsx");
        }
    }

}