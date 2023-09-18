using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Formatos.Dirtel;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
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
    public class DirtelRegistroEquipoComunicacionEnlaceController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        RegistroEquipoComunicacionEnlace registroEquipoComunicacionEnlaceBL = new();
        Marca marcaBL = new();
        Dependencia dependenciaBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();

        public DirtelRegistroEquipoComunicacionEnlaceController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Equipos de Comunicacion de Enlaces", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MarcaDTO> marcaDTO = marcaBL.ObtenerMarcas();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();

            return Json(new
            {
                data1 = marcaDTO,
                data2 = dependenciaDTO,
                data3 = departamentoUbigeoDTO,
            });
        }

        public IActionResult CargaTabla()
        {
            List<RegistroEquipoComunicacionEnlaceDTO> registroEquipoComunicacionEnlaceDTO = registroEquipoComunicacionEnlaceBL.ObtenerLista();
            return Json(new { data = registroEquipoComunicacionEnlaceDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( string CodigoIBPEquipoEnlace, int MarcaId, int NumeroCanalEquipo,
            string ModeloEquipoEnlace, string ModoEquipoEnlace, string AnchoBanda, string TipoEquipoComunicacionEnlace, string EstadoOperatividadEnlace, string AnioAdquisicion,
            int DepartamentoUbigeoId, int DependenciaId )
        {
            RegistroEquipoComunicacionEnlaceDTO registroEquipoComunicacionEnlaceDTO = new();
            registroEquipoComunicacionEnlaceDTO.CodigoIBPEquipoEnlace = CodigoIBPEquipoEnlace;
            registroEquipoComunicacionEnlaceDTO.MarcaId = MarcaId;
            registroEquipoComunicacionEnlaceDTO.ModeloEquipoEnlace = ModeloEquipoEnlace;
            registroEquipoComunicacionEnlaceDTO.ModoEquipoEnlace = ModoEquipoEnlace;
            registroEquipoComunicacionEnlaceDTO.NumeroCanalEquipo = NumeroCanalEquipo;
            registroEquipoComunicacionEnlaceDTO.AnchoBanda = AnchoBanda;
            registroEquipoComunicacionEnlaceDTO.TipoEquipoComunicacionEnlace = TipoEquipoComunicacionEnlace;
            registroEquipoComunicacionEnlaceDTO.EstadoOperatividadEnlace = EstadoOperatividadEnlace;
            registroEquipoComunicacionEnlaceDTO.AnioAdquisicion = AnioAdquisicion;
            registroEquipoComunicacionEnlaceDTO.DependenciaId = DependenciaId;
            registroEquipoComunicacionEnlaceDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            registroEquipoComunicacionEnlaceDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroEquipoComunicacionEnlaceBL.AgregarRegistro(registroEquipoComunicacionEnlaceDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(registroEquipoComunicacionEnlaceBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int RegistroEquipoComunicacionEnlaceId, string CodigoIBPEquipoEnlace, int MarcaId, int NumeroCanalEquipo,
            string ModeloEquipoEnlace, string ModoEquipoEnlace, string AnchoBanda, string TipoEquipoComunicacionEnlace, string EstadoOperatividadEnlace, string AnioAdquisicion,
            int DepartamentoUbigeoId, int DependenciaId)
        {
            RegistroEquipoComunicacionEnlaceDTO registroEquipoComunicacionEnlaceDTO = new();
            registroEquipoComunicacionEnlaceDTO.RegistroEquipoComunicacionEnlaceId = RegistroEquipoComunicacionEnlaceId;
            registroEquipoComunicacionEnlaceDTO.CodigoIBPEquipoEnlace = CodigoIBPEquipoEnlace;
            registroEquipoComunicacionEnlaceDTO.MarcaId = MarcaId;
            registroEquipoComunicacionEnlaceDTO.ModeloEquipoEnlace = ModeloEquipoEnlace;
            registroEquipoComunicacionEnlaceDTO.ModoEquipoEnlace = ModoEquipoEnlace;
            registroEquipoComunicacionEnlaceDTO.NumeroCanalEquipo = NumeroCanalEquipo;
            registroEquipoComunicacionEnlaceDTO.AnchoBanda = AnchoBanda;
            registroEquipoComunicacionEnlaceDTO.TipoEquipoComunicacionEnlace = TipoEquipoComunicacionEnlace;
            registroEquipoComunicacionEnlaceDTO.EstadoOperatividadEnlace = EstadoOperatividadEnlace;
            registroEquipoComunicacionEnlaceDTO.AnioAdquisicion = AnioAdquisicion;
            registroEquipoComunicacionEnlaceDTO.DependenciaId = DependenciaId;
            registroEquipoComunicacionEnlaceDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            registroEquipoComunicacionEnlaceDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroEquipoComunicacionEnlaceBL.ActualizarFormato(registroEquipoComunicacionEnlaceDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RegistroEquipoComunicacionEnlaceDTO registroEquipoComunicacionEnlaceDTO = new();
            registroEquipoComunicacionEnlaceDTO.RegistroEquipoComunicacionEnlaceId = Id;
            registroEquipoComunicacionEnlaceDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (registroEquipoComunicacionEnlaceBL.EliminarFormato(registroEquipoComunicacionEnlaceDTO) == true)
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

            List<RegistroEquipoComunicacionEnlaceDTO> lista = new List<RegistroEquipoComunicacionEnlaceDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new RegistroEquipoComunicacionEnlaceDTO
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
            var IND_OPERACION = registroEquipoComunicacionEnlaceBL.InsertarDatos(dt);
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
            var Capitanias = registroEquipoComunicacionEnlaceBL.ObtenerLista();
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