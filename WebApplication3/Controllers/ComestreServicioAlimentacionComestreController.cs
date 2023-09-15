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
    public class ComestreServicioAlimentacionComestreController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        ServicioAlimentacionComestre servicioAlimentacionComestreBL = new();

        Mes mesBL = new();
        Dependencia dependenciaBL = new ();

        public ComestreServicioAlimentacionComestreController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Servicio de Alimentacion", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> mesDTO = mesBL.ObtenerMess();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();

            return Json(new
            {
                data1 = mesDTO,
                data2 = dependenciaDTO,
            });
        }

        public IActionResult CargaTabla()
        {
            List<ServicioAlimentacionComestreDTO> servicioAlimentacionComestreDTO = servicioAlimentacionComestreBL.ObtenerLista();
            return Json(new { data = servicioAlimentacionComestreDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int NumeroRacion, int MesId,   
            int PeriodoDias, int CantidadPersupe, int DependenciaId, int CantidadPersuba, int CantidadPermar, int CIP
            , int Vacacion, int TotalPersonalDiaHabil, int TotalPersonalDiaNoHabil, int DiaHabil, int DiaNoHabil)
        {
            ServicioAlimentacionComestreDTO servicioAlimentacionComestreDTO = new();
            servicioAlimentacionComestreDTO.NumeroRacion = NumeroRacion;
            servicioAlimentacionComestreDTO.MesId = MesId;
            servicioAlimentacionComestreDTO.PeriodoDias = PeriodoDias;
            servicioAlimentacionComestreDTO.DependenciaId = DependenciaId;
            servicioAlimentacionComestreDTO.CantidadPersupe = CantidadPersupe;
            servicioAlimentacionComestreDTO.CantidadPersuba = CantidadPersuba;
            servicioAlimentacionComestreDTO.CantidadPermar = CantidadPermar;
            servicioAlimentacionComestreDTO.Vacacion = Vacacion;
            servicioAlimentacionComestreDTO.TotalPersonalDiaHabil = TotalPersonalDiaHabil;
            servicioAlimentacionComestreDTO.TotalPersonalDiaNoHabil = TotalPersonalDiaNoHabil;
            servicioAlimentacionComestreDTO.DiaHabil = DiaHabil;
            servicioAlimentacionComestreDTO.DiaNoHabil = DiaNoHabil;
            servicioAlimentacionComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioAlimentacionComestreBL.AgregarRegistro(servicioAlimentacionComestreDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(servicioAlimentacionComestreBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int ServicioAlimentacionComestreId, int NumeroRacion, int MesId,
            int PeriodoDias, int CantidadPersupe, int DependenciaId, int CantidadPersuba, int CantidadPermar, int CIP
            , int Vacacion, int TotalPersonalDiaHabil, int TotalPersonalDiaNoHabil, int DiaHabil, int DiaNoHabil)
        {
            ServicioAlimentacionComestreDTO servicioAlimentacionComestreDTO = new();
            servicioAlimentacionComestreDTO.ServicioAlimentacionComestreId = ServicioAlimentacionComestreId;
            servicioAlimentacionComestreDTO.NumeroRacion = NumeroRacion;
            servicioAlimentacionComestreDTO.MesId = MesId;
            servicioAlimentacionComestreDTO.PeriodoDias = PeriodoDias;
            servicioAlimentacionComestreDTO.DependenciaId = DependenciaId;
            servicioAlimentacionComestreDTO.CantidadPersupe = CantidadPersupe;
            servicioAlimentacionComestreDTO.CantidadPersuba = CantidadPersuba;
            servicioAlimentacionComestreDTO.CantidadPermar = CantidadPermar;
            servicioAlimentacionComestreDTO.Vacacion = Vacacion;
            servicioAlimentacionComestreDTO.TotalPersonalDiaHabil = TotalPersonalDiaHabil;
            servicioAlimentacionComestreDTO.TotalPersonalDiaNoHabil = TotalPersonalDiaNoHabil;
            servicioAlimentacionComestreDTO.DiaHabil = DiaHabil;
            servicioAlimentacionComestreDTO.DiaNoHabil = DiaNoHabil;
            servicioAlimentacionComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioAlimentacionComestreBL.ActualizarFormato(servicioAlimentacionComestreDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ServicioAlimentacionComestreDTO servicioAlimentacionComestreDTO = new();
            servicioAlimentacionComestreDTO.ServicioAlimentacionComestreId = Id;
            servicioAlimentacionComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (servicioAlimentacionComestreBL.EliminarFormato(servicioAlimentacionComestreDTO) == true)
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

            List<ServicioAlimentacionComestreDTO> lista = new List<ServicioAlimentacionComestreDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new ServicioAlimentacionComestreDTO
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
            List<ServicioAlimentacionComestreDTO> lista = new List<ServicioAlimentacionComestreDTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new ServicioAlimentacionComestreDTO
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
                var estado = servicioAlimentacionComestreBL.InsercionMasiva(lista);
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
            var Capitanias = servicioAlimentacionComestreBL.ObtenerLista();
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