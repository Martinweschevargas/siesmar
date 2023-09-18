using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comestre;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Formatos.Comestre;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class ComestreServicioMovilidadComestreController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        ServicioMovilidadComestre servicioMovilidadComestreBL = new();
        Dependencia dependenciaBL = new ();
        ClaseVehiculo claseVehiculoBL = new();
        MarcaVehiculo marcaVehiculoBL = new();

        public ComestreServicioMovilidadComestreController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Servicio de Apoyo con Movilidades", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<ClaseVehiculoDTO> claseVehiculoDTO = claseVehiculoBL.ObtenerClaseVehiculos();
            List<MarcaVehiculoDTO> marcaVehiculoDTO = marcaVehiculoBL.ObtenerMarcaVehiculos();

            return Json(new
            {
                data1 = dependenciaDTO,
                data2 = claseVehiculoDTO,
                data3 = marcaVehiculoDTO,
            });
        }

        public IActionResult CargaTabla()
        {
            List<ServicioMovilidadComestreDTO> servicioMovilidadComestreDTO = servicioMovilidadComestreBL.ObtenerLista();
            return Json(new { data = servicioMovilidadComestreDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( string EstadoOperatividad,   
            string FechaInicio, string Carroceria, int DependenciaId, string PlacaRodaje, 
            string FechaTermino, int ClaseVehiculoId, int MarcaVehiculoId)
        {
            ServicioMovilidadComestreDTO servicioMovilidadComestreDTO = new();
            servicioMovilidadComestreDTO.FechaInicio = FechaInicio;
            servicioMovilidadComestreDTO.FechaTermino = FechaTermino;
            servicioMovilidadComestreDTO.DependenciaId = DependenciaId;
            servicioMovilidadComestreDTO.ClaseVehiculoId = ClaseVehiculoId;
            servicioMovilidadComestreDTO.MarcaVehiculoId = MarcaVehiculoId;
            servicioMovilidadComestreDTO.Carroceria = Carroceria;
            servicioMovilidadComestreDTO.PlacaRodaje = PlacaRodaje;
            servicioMovilidadComestreDTO.EstadoOperatividad = EstadoOperatividad;
            servicioMovilidadComestreDTO.Año = DateTime.Now.Year; ;
            servicioMovilidadComestreDTO.Mes = DateTime.Now.Month;
            servicioMovilidadComestreDTO.Dia = DateTime.Now.Day;
            servicioMovilidadComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioMovilidadComestreBL.AgregarRegistro(servicioMovilidadComestreDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(servicioMovilidadComestreBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int ServicioMovilidadComestreId, string EstadoOperatividad,
            string FechaInicio, string Carroceria, int DependenciaId, string PlacaRodaje,
            string FechaTermino, int ClaseVehiculoId, int MarcaVehiculoId)
        {
            ServicioMovilidadComestreDTO servicioMovilidadComestreDTO = new();
            servicioMovilidadComestreDTO.ServicioMovilidadComestreId = ServicioMovilidadComestreId;
            servicioMovilidadComestreDTO.FechaInicio = FechaInicio;
            servicioMovilidadComestreDTO.FechaTermino = FechaTermino;
            servicioMovilidadComestreDTO.DependenciaId = DependenciaId;
            servicioMovilidadComestreDTO.ClaseVehiculoId = ClaseVehiculoId;
            servicioMovilidadComestreDTO.MarcaVehiculoId = MarcaVehiculoId;
            servicioMovilidadComestreDTO.Carroceria = Carroceria;
            servicioMovilidadComestreDTO.PlacaRodaje = PlacaRodaje;
            servicioMovilidadComestreDTO.EstadoOperatividad = EstadoOperatividad;
            servicioMovilidadComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioMovilidadComestreBL.ActualizarFormato(servicioMovilidadComestreDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ServicioMovilidadComestreDTO servicioMovilidadComestreDTO = new();
            servicioMovilidadComestreDTO.ServicioMovilidadComestreId = Id;
            servicioMovilidadComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (servicioMovilidadComestreBL.EliminarFormato(servicioMovilidadComestreDTO) == true)
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

            List<ServicioMovilidadComestreDTO> lista = new List<ServicioMovilidadComestreDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new ServicioMovilidadComestreDTO
                {/*
                    NombreActividadCultural = fila.GetCell(0).ToString(),
                    TipoActividadCulturalId = fila.GetCell(1).ToString(),
                    FechaInicioActCultural = fila.GetCell(2).ToString(),
                    FechaTerminoActCultural = fila.GetCell(3).ToString(),
                    LugarActCultural = fila.GetCell(4).ToString(),
                    AuspiciadoresActCultural = fila.GetCell(5).ToString(),
                    NParticipantesActCultural = fila.GetCell(4).ToString(),
                    InversionActCultural = fila.GetCell(5).ToString()*/
                });
            }
            return StatusCode(StatusCodes.Status200OK, lista);
        }


        [HttpPost]
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
        {
            Stream stream = ArchivoExcel.OpenReadStream();
            var mensaje="";

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
            List<ServicioMovilidadComestreDTO> lista = new List<ServicioMovilidadComestreDTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new ServicioMovilidadComestreDTO
                {/*
                    NombreActividadCultural = fila.GetCell(0).ToString(),
                    TipoActividadCulturalId = fila.GetCell(1).ToString(),
                    FechaInicioActCultural = fila.GetCell(2).ToString(),
                    FechaTerminoActCultural = fila.GetCell(3).ToString(),
                    LugarActCultural = fila.GetCell(4).ToString(),
                    AuspiciadoresActCultural = fila.GetCell(5).ToString(),
                    NParticipantesActCultural = fila.GetCell(4).ToString(),
                    InversionActCultural = fila.GetCell(5).ToString(),
                    UsuarioIngresoRegistro = User.obtenerUsuario(),*/
                });
            }
            try
            {
                var estado = servicioMovilidadComestreBL.InsercionMasiva(lista);
                if (estado==true)
                {
                    mensaje = "ok";
                }
                else
                {
                    mensaje = "error";
                }
                 
            }
            catch(Exception e)
            {
                mensaje = e.Message;
            }
            return StatusCode(StatusCodes.Status200OK, new { mensaje });
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
            var Capitanias = servicioMovilidadComestreBL.ObtenerLista();
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