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
    public class ComestreSituacionOperativaNaveComestreController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        SituacionOperativaNaveComestre situacionOperativaNaveComestreBL = new();

        TipoNave tipoNaveBL = new();
        TipoPlataformaNave tipoPlataformaNaveBL = new();
        Dependencia dependenciaBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();

        public ComestreSituacionOperativaNaveComestreController(IWebHostEnvironment webHostEnvironment)
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

            return Json(new
            {
                data1 = tipoNaveDTO,
                data2 = tipoPlataformaNaveDTO,
                data3 = dependenciaDTO,
                data4 = departamentoUbigeoDTO,
                data5 = provinciaUbigeoDTO,
                data6 = distritoUbigeoDTO,

            });
        }

        public IActionResult CargaTabla()
        {
            List<SituacionOperativaNaveComestreDTO> situacionOperativaNaveComestreDTO = situacionOperativaNaveComestreBL.ObtenerLista();
            return Json(new { data = situacionOperativaNaveComestreDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int CascoNave, int TipoNaveId, int TipoPlataformaNaveId, int DepartamentoUbigeoId, 
            int DependenciaId, string Ubicacion, string CapacidadOperativaNave, int ProvinciaUbigeoId, int DistritoUbigeoId, 
            string CondicionNave, string Observacion)
        {
            SituacionOperativaNaveComestreDTO situacionOperativaNaveComestreDTO = new();
            situacionOperativaNaveComestreDTO.TipoNaveId = TipoNaveId;
            situacionOperativaNaveComestreDTO.CascoNave = CascoNave;
            situacionOperativaNaveComestreDTO.TipoPlataformaNaveId = TipoPlataformaNaveId;
            situacionOperativaNaveComestreDTO.DependenciaId = DependenciaId;
            situacionOperativaNaveComestreDTO.Ubicacion = Ubicacion;
            situacionOperativaNaveComestreDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            situacionOperativaNaveComestreDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            situacionOperativaNaveComestreDTO.DistritoUbigeoId = DistritoUbigeoId;
            situacionOperativaNaveComestreDTO.CapacidadOperativaNave = CapacidadOperativaNave;
            situacionOperativaNaveComestreDTO.CondicionNave = CondicionNave;
            situacionOperativaNaveComestreDTO.Observacion = Observacion;
            situacionOperativaNaveComestreDTO.Año = DateTime.Now.Year; ;
            situacionOperativaNaveComestreDTO.Mes = DateTime.Now.Month;
            situacionOperativaNaveComestreDTO.Dia = DateTime.Now.Day;
            situacionOperativaNaveComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperativaNaveComestreBL.AgregarRegistro(situacionOperativaNaveComestreDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(situacionOperativaNaveComestreBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int SituacionOperativaNaveComestreId, int CascoNave, int TipoNaveId, int TipoPlataformaNaveId, int DepartamentoUbigeoId,
            int DependenciaId, string Ubicacion, string CapacidadOperativaNave, int ProvinciaUbigeoId, int DistritoUbigeoId,
            string CondicionNave, string Observacion)
        {
            SituacionOperativaNaveComestreDTO situacionOperativaNaveComestreDTO = new();
            situacionOperativaNaveComestreDTO.SituacionOperativaNaveComestreId = SituacionOperativaNaveComestreId;
            situacionOperativaNaveComestreDTO.TipoNaveId = TipoNaveId;
            situacionOperativaNaveComestreDTO.CascoNave = CascoNave;
            situacionOperativaNaveComestreDTO.TipoPlataformaNaveId = TipoPlataformaNaveId;
            situacionOperativaNaveComestreDTO.DependenciaId = DependenciaId;
            situacionOperativaNaveComestreDTO.Ubicacion = Ubicacion;
            situacionOperativaNaveComestreDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            situacionOperativaNaveComestreDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            situacionOperativaNaveComestreDTO.DistritoUbigeoId = DistritoUbigeoId;
            situacionOperativaNaveComestreDTO.CapacidadOperativaNave = CapacidadOperativaNave;
            situacionOperativaNaveComestreDTO.CondicionNave = CondicionNave;
            situacionOperativaNaveComestreDTO.Observacion = Observacion;
            situacionOperativaNaveComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperativaNaveComestreBL.ActualizarFormato(situacionOperativaNaveComestreDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            SituacionOperativaNaveComestreDTO situacionOperativaNaveComestreDTO = new();
            situacionOperativaNaveComestreDTO.SituacionOperativaNaveComestreId = Id;
            situacionOperativaNaveComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (situacionOperativaNaveComestreBL.EliminarFormato(situacionOperativaNaveComestreDTO) == true)
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

            List<SituacionOperativaNaveComestreDTO> lista = new List<SituacionOperativaNaveComestreDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new SituacionOperativaNaveComestreDTO
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
            List<SituacionOperativaNaveComestreDTO> lista = new List<SituacionOperativaNaveComestreDTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new SituacionOperativaNaveComestreDTO
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
                var estado = situacionOperativaNaveComestreBL.InsercionMasiva(lista);
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
            var Capitanias = situacionOperativaNaveComestreBL.ObtenerLista();
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