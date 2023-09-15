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
    public class ComestreSituacionEmbarcacionMenorComestreController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        SituacionEmbarcacionMenorComestre situacionEmbarcacionMenorComestreBL = new();

        UnidadNaval unidadNavalBL = new();
        TipoNave tipoNaveBL = new();
        TipoPlataformaNave tipoPlataformaNaveBL = new();
        Dependencia dependenciaBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();

        public ComestreSituacionEmbarcacionMenorComestreController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Situacion de Embarcaciones Menores", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals(); 
            List<TipoNaveDTO> tipoNaveDTO = tipoNaveBL.ObtenerTipoNaves();
            List<TipoPlataformaNaveDTO> tipoPlataformaNaveDTO = tipoPlataformaNaveBL.ObtenerTipoPlataformaNaves();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = tipoNaveDTO,
                data3 = tipoPlataformaNaveDTO,
                data4 = dependenciaDTO,
                data5 = departamentoUbigeoDTO,
                data6 = provinciaUbigeoDTO,
                data7 = distritoUbigeoDTO,
            });
        }

        public IActionResult CargaTabla()
        {
            List<SituacionEmbarcacionMenorComestreDTO> situacionEmbarcacionMenorComestreDTO = situacionEmbarcacionMenorComestreBL.ObtenerLista();
            return Json(new { data = situacionEmbarcacionMenorComestreDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int UnidadNavalId, int TipoNaveId, int TipoPlataformaNaveId, int DepartamentoUbigeoId, 
            int DependenciaId, string Ubicacion, string CapacidadOperativaNave, int ProvinciaUbigeoId, int DistritoUbigeoId, 
            string CondicionAeronave, string Observacion)
        {
            SituacionEmbarcacionMenorComestreDTO situacionEmbarcacionMenorComestreDTO = new();
            situacionEmbarcacionMenorComestreDTO.UnidadNavalId = UnidadNavalId;
            situacionEmbarcacionMenorComestreDTO.TipoNaveId = TipoNaveId;
            situacionEmbarcacionMenorComestreDTO.TipoPlataformaNaveId = TipoPlataformaNaveId;
            situacionEmbarcacionMenorComestreDTO.DependenciaId = DependenciaId;
            situacionEmbarcacionMenorComestreDTO.Ubicacion = Ubicacion;
            situacionEmbarcacionMenorComestreDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            situacionEmbarcacionMenorComestreDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            situacionEmbarcacionMenorComestreDTO.DistritoUbigeoId = DistritoUbigeoId;
            situacionEmbarcacionMenorComestreDTO.CapacidadOperativaNave = CapacidadOperativaNave;
            situacionEmbarcacionMenorComestreDTO.CondicionAeronave = CondicionAeronave;
            situacionEmbarcacionMenorComestreDTO.Observacion = Observacion;
            situacionEmbarcacionMenorComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionEmbarcacionMenorComestreBL.AgregarRegistro(situacionEmbarcacionMenorComestreDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(situacionEmbarcacionMenorComestreBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int SituacionEmbarcacionMenorComestreId, int UnidadNavalId, int TipoNaveId, int TipoPlataformaNaveId, int DepartamentoUbigeoId,
            int DependenciaId, string Ubicacion, string CapacidadOperativaNave, int ProvinciaUbigeoId, int DistritoUbigeoId,
            string CondicionAeronave, string Observacion)
        {
            SituacionEmbarcacionMenorComestreDTO situacionEmbarcacionMenorComestreDTO = new();
            situacionEmbarcacionMenorComestreDTO.SituacionEmbarcacionMenorComestreId = SituacionEmbarcacionMenorComestreId;
            situacionEmbarcacionMenorComestreDTO.UnidadNavalId = UnidadNavalId;
            situacionEmbarcacionMenorComestreDTO.TipoNaveId = TipoNaveId;
            situacionEmbarcacionMenorComestreDTO.TipoPlataformaNaveId = TipoPlataformaNaveId;
            situacionEmbarcacionMenorComestreDTO.DependenciaId = DependenciaId;
            situacionEmbarcacionMenorComestreDTO.Ubicacion = Ubicacion;
            situacionEmbarcacionMenorComestreDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            situacionEmbarcacionMenorComestreDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            situacionEmbarcacionMenorComestreDTO.DistritoUbigeoId = DistritoUbigeoId;
            situacionEmbarcacionMenorComestreDTO.CapacidadOperativaNave = CapacidadOperativaNave;
            situacionEmbarcacionMenorComestreDTO.CondicionAeronave = CondicionAeronave;
            situacionEmbarcacionMenorComestreDTO.Observacion = Observacion;
            situacionEmbarcacionMenorComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionEmbarcacionMenorComestreBL.ActualizarFormato(situacionEmbarcacionMenorComestreDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            SituacionEmbarcacionMenorComestreDTO situacionEmbarcacionMenorComestreDTO = new();
            situacionEmbarcacionMenorComestreDTO.SituacionEmbarcacionMenorComestreId = Id;
            situacionEmbarcacionMenorComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (situacionEmbarcacionMenorComestreBL.EliminarFormato(situacionEmbarcacionMenorComestreDTO) == true)
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

            List<SituacionEmbarcacionMenorComestreDTO> lista = new List<SituacionEmbarcacionMenorComestreDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new SituacionEmbarcacionMenorComestreDTO
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
            List<SituacionEmbarcacionMenorComestreDTO> lista = new List<SituacionEmbarcacionMenorComestreDTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new SituacionEmbarcacionMenorComestreDTO
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
                var estado = situacionEmbarcacionMenorComestreBL.InsercionMasiva(lista);
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
            var Capitanias = situacionEmbarcacionMenorComestreBL.ObtenerLista();
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