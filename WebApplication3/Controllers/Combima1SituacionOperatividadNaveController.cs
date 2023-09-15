using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Combima1;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Formatos.Combima1;
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
    public class Combima1SituacionOperatividadNaveController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        SituacionOperatividadNaveCombima1 situacionOperativaNaveCombima1BL = new();

        TipoNave tipoNaveBL = new();
        TipoPlataformaNave tipoPlataformaNaveBL = new();
        Dependencia dependenciaBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        CapacidadOperativaRequerida capacidadOperativaRequeridaBL = new();
        Condicion condicionBL = new();

        public Combima1SituacionOperatividadNaveController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Situacion de Operatividad de Naves", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoNaveDTO> tipoNaveDTO = tipoNaveBL.ObtenerTipoNaves();
            List<TipoPlataformaNaveDTO> tipoPlataformaNaveDTO = tipoPlataformaNaveBL.ObtenerTipoPlataformaNaves();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<CapacidadOperativaRequeridaDTO> capacidadOperativaRequeridaDTO = capacidadOperativaRequeridaBL.ObtenerCapacidadOperativaRequeridas();
            List<CondicionDTO> condicionDTO = condicionBL.ObtenerCondicions();

            return Json(new
            {
                data1 = tipoNaveDTO,
                data2 = tipoPlataformaNaveDTO,
                data3 = dependenciaDTO,
                data4 = departamentoUbigeoDTO,
                data5 = provinciaUbigeoDTO,
                data6 = distritoUbigeoDTO,
                data7 = capacidadOperativaRequeridaDTO,
                data8 = condicionDTO

            });
        }

        public IActionResult CargaTabla()
        {
            List<SituacionOperatividadNaveCombima1DTO> situacionOperativaNaveCombima1DTO = situacionOperativaNaveCombima1BL.ObtenerLista();
            return Json(new { data = situacionOperativaNaveCombima1DTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int CascoNave, int TipoNaveId, int TipoPlataformaNaveId, int DepartamentoUbigeoId, 
            int DependenciaId, string Ubicacion, int CapacidadOperativaRequeridaId, int ProvinciaUbigeoId, int DistritoUbigeoId,
            int CondicionId, string Observacion)
        {
            SituacionOperatividadNaveCombima1DTO situacionOperativaNaveCombima1DTO = new();
            situacionOperativaNaveCombima1DTO.TipoNaveId = TipoNaveId;
            situacionOperativaNaveCombima1DTO.CascoNave = CascoNave;
            situacionOperativaNaveCombima1DTO.TipoPlataformaNaveId = TipoPlataformaNaveId;
            situacionOperativaNaveCombima1DTO.DependenciaId = DependenciaId;
            situacionOperativaNaveCombima1DTO.Ubicacion = Ubicacion;
            situacionOperativaNaveCombima1DTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            situacionOperativaNaveCombima1DTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            situacionOperativaNaveCombima1DTO.DistritoUbigeoId = DistritoUbigeoId;
            situacionOperativaNaveCombima1DTO.CapacidadOperativaRequeridaId = CapacidadOperativaRequeridaId;
            situacionOperativaNaveCombima1DTO.CondicionId = CondicionId;
            situacionOperativaNaveCombima1DTO.Observacion = Observacion;
            situacionOperativaNaveCombima1DTO.Año = DateTime.Now.Year; ;
            situacionOperativaNaveCombima1DTO.Mes = DateTime.Now.Month;
            situacionOperativaNaveCombima1DTO.Dia = DateTime.Now.Day;
            situacionOperativaNaveCombima1DTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperativaNaveCombima1BL.AgregarRegistro(situacionOperativaNaveCombima1DTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(situacionOperativaNaveCombima1BL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int CascoNave, int TipoNaveId, int TipoPlataformaNaveId, int DepartamentoUbigeoId,
            int DependenciaId, string Ubicacion, int CapacidadOperativaRequeridaId, int ProvinciaUbigeoId, int DistritoUbigeoId,
            int CondicionId, string Observacion)
        {
            SituacionOperatividadNaveCombima1DTO situacionOperativaNaveCombima1DTO = new();
            situacionOperativaNaveCombima1DTO.SituacionOperativaNaveCombima1Id = Id;
            situacionOperativaNaveCombima1DTO.TipoNaveId = TipoNaveId;
            situacionOperativaNaveCombima1DTO.CascoNave = CascoNave;
            situacionOperativaNaveCombima1DTO.TipoPlataformaNaveId = TipoPlataformaNaveId;
            situacionOperativaNaveCombima1DTO.DependenciaId = DependenciaId;
            situacionOperativaNaveCombima1DTO.Ubicacion = Ubicacion;
            situacionOperativaNaveCombima1DTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            situacionOperativaNaveCombima1DTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            situacionOperativaNaveCombima1DTO.DistritoUbigeoId = DistritoUbigeoId;
            situacionOperativaNaveCombima1DTO.CapacidadOperativaRequeridaId = CapacidadOperativaRequeridaId;
            situacionOperativaNaveCombima1DTO.CondicionId = CondicionId;
            situacionOperativaNaveCombima1DTO.Observacion = Observacion;
            situacionOperativaNaveCombima1DTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperativaNaveCombima1BL.ActualizarFormato(situacionOperativaNaveCombima1DTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            SituacionOperatividadNaveCombima1DTO situacionOperativaNaveCombima1DTO = new();
            situacionOperativaNaveCombima1DTO.SituacionOperativaNaveCombima1Id = Id;
            situacionOperativaNaveCombima1DTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (situacionOperativaNaveCombima1BL.EliminarFormato(situacionOperativaNaveCombima1DTO) == true)
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

            List<SituacionOperatividadNaveCombima1DTO> lista = new List<SituacionOperatividadNaveCombima1DTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new SituacionOperatividadNaveCombima1DTO
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
            List<SituacionOperatividadNaveCombima1DTO> lista = new List<SituacionOperatividadNaveCombima1DTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new SituacionOperatividadNaveCombima1DTO
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
                var estado = situacionOperativaNaveCombima1BL.InsercionMasiva(lista);
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
            var Capitanias = situacionOperativaNaveCombima1BL.ObtenerLista();
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