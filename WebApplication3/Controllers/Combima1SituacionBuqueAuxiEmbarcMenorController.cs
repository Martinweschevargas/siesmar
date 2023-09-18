using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Combima1;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Formatos.Combima1;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using MathNet.Numerics.Distributions;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class Combima1SituacionBuqueAuxiEmbarcMenorController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        SituacionBuqueAuxiEmbarcMenorCombima1 situacionBuqueAuxiEmbarcMenorCombima1BL = new();

        TipoPlataformaNave tipoPlataformaNaveBL = new();
        Dependencia dependenciaBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        CapacidadOperativaRequerida capacidadOperativaRequeridaBL = new();
        Condicion condicionBL = new();

        public Combima1SituacionBuqueAuxiEmbarcMenorController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Situación de Buques Auxiliares y Embarcaciones Menores", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoPlataformaNaveDTO> tipoPlataformaNaveDTO = tipoPlataformaNaveBL.ObtenerTipoPlataformaNaves();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<CapacidadOperativaRequeridaDTO> capacidadOperativaRequeridaDTO = capacidadOperativaRequeridaBL.ObtenerCapacidadOperativaRequeridas();
            List<CondicionDTO> condicionDTO = condicionBL.ObtenerCondicions();

            return Json(new
            {
                data1 = tipoPlataformaNaveDTO,
                data2 = dependenciaDTO,
                data3 = departamentoUbigeoDTO,
                data4 = provinciaUbigeoDTO,
                data5 = distritoUbigeoDTO,
                data6 = capacidadOperativaRequeridaDTO,
                data7 = condicionDTO

            });
        }

        public IActionResult CargaTabla()
        {
            List<SituacionBuqueAuxiEmbarcMenorCombima1DTO> situacionBuqueAuxiEmbarcMenorCombima1DTO = situacionBuqueAuxiEmbarcMenorCombima1BL.ObtenerLista();
            return Json(new { data = situacionBuqueAuxiEmbarcMenorCombima1DTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int CodigoUnidad, string Categoria, int TipoPlataformaNaveId, int DepartamentoUbigeoId, 
            int DependenciaId, string Ubicacion, int CapacidadOperativaRequeridaId, int ProvinciaUbigeoId, int DistritoUbigeoId,
            int CondicionId, string Observacion)
        {
            SituacionBuqueAuxiEmbarcMenorCombima1DTO situacionBuqueAuxiEmbarcMenorCombima1DTO = new();
            situacionBuqueAuxiEmbarcMenorCombima1DTO.CodigoUnidad = CodigoUnidad;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.Categoria = Categoria;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.TipoPlataformaNaveId = TipoPlataformaNaveId;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.DependenciaId = DependenciaId;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.Ubicacion = Ubicacion;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.DistritoUbigeoId = DistritoUbigeoId;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.CapacidadOperativaRequeridaId = CapacidadOperativaRequeridaId;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.CondicionId = CondicionId;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.Observacion = Observacion;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.Año = DateTime.Now.Year; ;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.Mes = DateTime.Now.Month;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.Dia = DateTime.Now.Day;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionBuqueAuxiEmbarcMenorCombima1BL.AgregarRegistro(situacionBuqueAuxiEmbarcMenorCombima1DTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(situacionBuqueAuxiEmbarcMenorCombima1BL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int CodigoUnidad, string Categoria, int TipoPlataformaNaveId, int DepartamentoUbigeoId,
            int DependenciaId, string Ubicacion, int CapacidadOperativaRequeridaId, int ProvinciaUbigeoId, int DistritoUbigeoId,
            int CondicionId, string Observacion)
        {
            SituacionBuqueAuxiEmbarcMenorCombima1DTO situacionBuqueAuxiEmbarcMenorCombima1DTO = new();
            situacionBuqueAuxiEmbarcMenorCombima1DTO.SituacionBuqueAuxiliarEmbarcacionMenorId = Id;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.CodigoUnidad = CodigoUnidad;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.Categoria = Categoria;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.TipoPlataformaNaveId = TipoPlataformaNaveId;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.DependenciaId = DependenciaId;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.Ubicacion = Ubicacion;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.DistritoUbigeoId = DistritoUbigeoId;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.CapacidadOperativaRequeridaId = CapacidadOperativaRequeridaId;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.CondicionId = CondicionId;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.Observacion = Observacion;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionBuqueAuxiEmbarcMenorCombima1BL.ActualizarFormato(situacionBuqueAuxiEmbarcMenorCombima1DTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            SituacionBuqueAuxiEmbarcMenorCombima1DTO situacionBuqueAuxiEmbarcMenorCombima1DTO = new();
            situacionBuqueAuxiEmbarcMenorCombima1DTO.SituacionBuqueAuxiliarEmbarcacionMenorId = Id;
            situacionBuqueAuxiEmbarcMenorCombima1DTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (situacionBuqueAuxiEmbarcMenorCombima1BL.EliminarFormato(situacionBuqueAuxiEmbarcMenorCombima1DTO) == true)
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

            List<SituacionBuqueAuxiEmbarcMenorCombima1DTO> lista = new List<SituacionBuqueAuxiEmbarcMenorCombima1DTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new SituacionBuqueAuxiEmbarcMenorCombima1DTO
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
            List<SituacionBuqueAuxiEmbarcMenorCombima1DTO> lista = new List<SituacionBuqueAuxiEmbarcMenorCombima1DTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new SituacionBuqueAuxiEmbarcMenorCombima1DTO
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
                var estado = situacionBuqueAuxiEmbarcMenorCombima1BL.InsercionMasiva(lista);
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
            var Capitanias = situacionBuqueAuxiEmbarcMenorCombima1BL.ObtenerLista();
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