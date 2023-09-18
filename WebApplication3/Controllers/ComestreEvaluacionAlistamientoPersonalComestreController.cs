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
    public class ComestreEvaluacionAlistamientoPersonalComestreController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        EvaluacionAlistamientoPersonalComestre evaluacionAlistamientoPersonalComestreBL = new();

        UnidadNaval unidadNavalBL = new ();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EspecialidadGenericaPersonal especialidadGenericaPersonalBL = new();

        public ComestreEvaluacionAlistamientoPersonalComestreController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Evaluacion de Alistamiento del Personal", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = gradoPersonalMilitarDTO,
                data3 = especialidadGenericaPersonalDTO,
            });
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionAlistamientoPersonalComestreDTO> evaluacionAlistamientoPersonalComestreDTO = evaluacionAlistamientoPersonalComestreBL.ObtenerLista();
            return Json(new { data = evaluacionAlistamientoPersonalComestreDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int UnidadNavalId, string FechaEvaluacion, int DNIPersonal,
            int CIPPersonal, string CargoPersonal, int GradoPersonalMilitarEsperado, int EspecialidadGenericaPersonalEsperado, 
            int EspecialidadGenericaPersonalActual, int GradoPersonalMilitarActual, int GradoJerarquico, decimal ServicioExperiencia,
            decimal EspecializacionProfesional, decimal CursoProfesionalRequerido, decimal TotalPuntaje)
        {
            EvaluacionAlistamientoPersonalComestreDTO evaluacionAlistamientoPersonalComestreDTO = new();
            evaluacionAlistamientoPersonalComestreDTO.UnidadNavalId = UnidadNavalId;
            evaluacionAlistamientoPersonalComestreDTO.FechaEvaluacion = FechaEvaluacion;
            evaluacionAlistamientoPersonalComestreDTO.DNIPersonal = DNIPersonal;
            evaluacionAlistamientoPersonalComestreDTO.CIPPersonal = CIPPersonal;
            //evaluacionAlistamientoPersonalComestreDTO.CargoPersonal = CargoPersonal;
            evaluacionAlistamientoPersonalComestreDTO.GradoPersonalMilitarEsperado = GradoPersonalMilitarEsperado;
            evaluacionAlistamientoPersonalComestreDTO.EspecialidadGenericaPersonalEsperado = EspecialidadGenericaPersonalEsperado;
            evaluacionAlistamientoPersonalComestreDTO.GradoPersonalMilitarActual = GradoPersonalMilitarActual;
            evaluacionAlistamientoPersonalComestreDTO.EspecialidadGenericaPersonalActual = EspecialidadGenericaPersonalActual;
            evaluacionAlistamientoPersonalComestreDTO.GradoJerarquico = GradoJerarquico;
            evaluacionAlistamientoPersonalComestreDTO.ServicioExperiencia = ServicioExperiencia;
            evaluacionAlistamientoPersonalComestreDTO.EspecializacionProfesional = EspecializacionProfesional;
            evaluacionAlistamientoPersonalComestreDTO.CursoProfesionalRequerido = CursoProfesionalRequerido;
            evaluacionAlistamientoPersonalComestreDTO.TotalPuntaje = TotalPuntaje;
            evaluacionAlistamientoPersonalComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoPersonalComestreBL.AgregarRegistro(evaluacionAlistamientoPersonalComestreDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistamientoPersonalComestreBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int EvaluacionAlistamientoPersonalComestreId, int UnidadNavalId, string FechaEvaluacion, int DNIPersonal,
            int CIPPersonal, string CargoPersonal, int GradoPersonalMilitarEsperado, int EspecialidadGenericaPersonalEsperado,
            int EspecialidadGenericaPersonalActual, int GradoPersonalMilitarActual, int GradoJerarquico, decimal ServicioExperiencia,
            decimal EspecializacionProfesional, decimal CursoProfesionalRequerido, decimal TotalPuntaje)
        {
            EvaluacionAlistamientoPersonalComestreDTO evaluacionAlistamientoPersonalComestreDTO = new();
            evaluacionAlistamientoPersonalComestreDTO.EvaluacionAlistamientoPersonalComestreId = EvaluacionAlistamientoPersonalComestreId;
            evaluacionAlistamientoPersonalComestreDTO.UnidadNavalId = UnidadNavalId;
            evaluacionAlistamientoPersonalComestreDTO.FechaEvaluacion = FechaEvaluacion;
            evaluacionAlistamientoPersonalComestreDTO.DNIPersonal = DNIPersonal;
            evaluacionAlistamientoPersonalComestreDTO.CIPPersonal = CIPPersonal;
            //evaluacionAlistamientoPersonalComestreDTO.CargoPersonal = CargoPersonal;
            evaluacionAlistamientoPersonalComestreDTO.GradoPersonalMilitarEsperado = GradoPersonalMilitarEsperado;
            evaluacionAlistamientoPersonalComestreDTO.EspecialidadGenericaPersonalEsperado = EspecialidadGenericaPersonalEsperado;
            evaluacionAlistamientoPersonalComestreDTO.GradoPersonalMilitarActual = GradoPersonalMilitarActual;
            evaluacionAlistamientoPersonalComestreDTO.EspecialidadGenericaPersonalActual = EspecialidadGenericaPersonalActual;
            evaluacionAlistamientoPersonalComestreDTO.GradoJerarquico = GradoJerarquico;
            evaluacionAlistamientoPersonalComestreDTO.ServicioExperiencia = ServicioExperiencia;
            evaluacionAlistamientoPersonalComestreDTO.EspecializacionProfesional = EspecializacionProfesional;
            evaluacionAlistamientoPersonalComestreDTO.CursoProfesionalRequerido = CursoProfesionalRequerido;
            evaluacionAlistamientoPersonalComestreDTO.TotalPuntaje = TotalPuntaje;
            evaluacionAlistamientoPersonalComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoPersonalComestreBL.ActualizarFormato(evaluacionAlistamientoPersonalComestreDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoPersonalComestreDTO evaluacionAlistamientoPersonalComestreDTO = new();
            evaluacionAlistamientoPersonalComestreDTO.EvaluacionAlistamientoPersonalComestreId = Id;
            evaluacionAlistamientoPersonalComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionAlistamientoPersonalComestreBL.EliminarFormato(evaluacionAlistamientoPersonalComestreDTO) == true)
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

            List<EvaluacionAlistamientoPersonalComestreDTO> lista = new List<EvaluacionAlistamientoPersonalComestreDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new EvaluacionAlistamientoPersonalComestreDTO
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
            List<EvaluacionAlistamientoPersonalComestreDTO> lista = new List<EvaluacionAlistamientoPersonalComestreDTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new EvaluacionAlistamientoPersonalComestreDTO
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
                var estado = evaluacionAlistamientoPersonalComestreBL.InsercionMasiva(lista);
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
            var Capitanias = evaluacionAlistamientoPersonalComestreBL.ObtenerLista();
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