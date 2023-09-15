using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Formatos.Dirtel;
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
    public class DirtelRegistroServidorController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        RegistroServidor registroServidorBL = new();
        Marca marcaBL = new();
        ModeloBienServicioSubcampo modeloBienServicioSubcampoBL = new();
        ModeloBienServicioDenominacion modeloBienServicioDenominacionBL = new();
        Dependencia dependenciaBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();

        public DirtelRegistroServidorController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Servidores", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MarcaDTO> marcaDTO = marcaBL.ObtenerMarcas();
            List<ModeloBienServicioSubcampoDTO> modeloBienServicioSubcampoDTO = modeloBienServicioSubcampoBL.ObtenerModeloBienServicioSubcampos();
            List<ModeloBienServicioDenominacionDTO> modeloBienServicioDenominacionDTO = modeloBienServicioDenominacionBL.ObtenerModeloBienServicioDenominacions();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();


            return Json(new
            {
                data1 = modeloBienServicioSubcampoDTO,
                data2 = modeloBienServicioDenominacionDTO,
                data3 = marcaDTO,
                data4 = dependenciaDTO,
                data5 = departamentoUbigeoDTO,
            });
        }

        public IActionResult CargaTabla()
        {
            List<RegistroServidorDTO> registroServidorDTO = registroServidorBL.ObtenerLista();
            return Json(new { data = registroServidorDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( string CodigoIBPServidor, int MarcaId, int ModeloBienServicioSubcampoId,
            int ModeloBienServicioDenominacionId, string CapacidadMemoriaRam, string CapacidadDiscoDuro, string AnioAdquisicionServidor, string EstadoOperatividadServidor, int DependenciaId,
            int DepartamentoUbigeoId)
        {
            RegistroServidorDTO registroServidorDTO = new();
            registroServidorDTO.CodigoIBPServidor = CodigoIBPServidor;
            registroServidorDTO.MarcaId = MarcaId;
            registroServidorDTO.ModeloBienServicioSubcampoId = ModeloBienServicioSubcampoId;
            registroServidorDTO.ModeloBienServicioDenominacionId = ModeloBienServicioDenominacionId;
            registroServidorDTO.CapacidadMemoriaRam = CapacidadMemoriaRam;
            registroServidorDTO.CapacidadDiscoDuro = CapacidadDiscoDuro;
            registroServidorDTO.DependenciaId = DependenciaId;
            registroServidorDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            registroServidorDTO.AnioAdquisicionServidor = AnioAdquisicionServidor;
            registroServidorDTO.EstadoOperatividadServidor = EstadoOperatividadServidor;
            registroServidorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroServidorBL.AgregarRegistro(registroServidorDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(registroServidorBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int RegistroServidorId, string CodigoIBPServidor, int MarcaId, int ModeloBienServicioSubcampoId,
            int ModeloBienServicioDenominacionId, string CapacidadMemoriaRam, string CapacidadDiscoDuro, string AnioAdquisicionServidor, string EstadoOperatividadServidor, int DependenciaId,
            int DepartamentoUbigeoId)
        {
            RegistroServidorDTO registroServidorDTO = new();
            registroServidorDTO.RegistroServidorId = RegistroServidorId; 
            registroServidorDTO.CodigoIBPServidor = CodigoIBPServidor;
            registroServidorDTO.MarcaId = MarcaId;
            registroServidorDTO.ModeloBienServicioSubcampoId = ModeloBienServicioSubcampoId;
            registroServidorDTO.ModeloBienServicioDenominacionId = ModeloBienServicioDenominacionId;
            registroServidorDTO.CapacidadMemoriaRam = CapacidadMemoriaRam;
            registroServidorDTO.CapacidadDiscoDuro = CapacidadDiscoDuro;
            registroServidorDTO.DependenciaId = DependenciaId;
            registroServidorDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            registroServidorDTO.AnioAdquisicionServidor = AnioAdquisicionServidor;
            registroServidorDTO.EstadoOperatividadServidor = EstadoOperatividadServidor;
            registroServidorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroServidorBL.ActualizarFormato(registroServidorDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RegistroServidorDTO registroServidorDTO = new();
            registroServidorDTO.RegistroServidorId = Id;
            registroServidorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (registroServidorBL.EliminarFormato(registroServidorDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
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

            List<RegistroServidorDTO> lista = new List<RegistroServidorDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new RegistroServidorDTO
                {
                    //NombreTemaEstudioInvestigacion = fila.GetCell(0).ToString(),
                    //TipoEstudioInvestigacionId = int.Parse(fila.GetCell(1).ToString()),
                    //FechaInicio = fila.GetCell(2).ToString(),
                    //FechaTermino = fila.GetCell(3).ToString(),
                    //Responsable = fila.GetCell(4).ToString(),
                    //Solicitante = fila.GetCell(5).ToString()
                });
            }
            return StatusCode(StatusCodes.Status200OK, lista);
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

            dt.Columns.AddRange(new DataColumn[7]
            {
                    new DataColumn("NombreInvestigacion", typeof(string)),
                    new DataColumn("TipoEstudioInvestigacionId", typeof(int)),
                    new DataColumn("FechaInicioInvestigacion", typeof(string)),
                    new DataColumn("FechaTerminoInvestigacion", typeof(string)),
                    new DataColumn("ResponsableInvestigacion", typeof(string)),
                    new DataColumn("SolicitanteInvestigacion", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    int.Parse(fila.GetCell(1).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = registroServidorBL.InsertarDatos(dt);
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
            var Capitanias = registroServidorBL.ObtenerLista();
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