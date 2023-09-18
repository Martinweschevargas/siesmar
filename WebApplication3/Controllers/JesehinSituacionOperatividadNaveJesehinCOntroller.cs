using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Jesehin;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Formatos.Jesehin;
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
    public class JesehinSituacionOperatividadNaveJesehinController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        SituacionOperatividadNaveJesehin situacionOperatividadNaveJesehinBL = new();

        TipoNave tipoNaveBL = new();
        TipoPlataformaNave tipoPlataformaNaveBL = new();
        Dependencia dependenciaBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        CapacidadOperativaRequerida capacidadOperativaRequeridaBL = new();
        Condicion condicionBL = new();

        public JesehinSituacionOperatividadNaveJesehinController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Situación de Operatividad de Naves", FromController = typeof(HomeController))]
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
                data8 = condicionDTO,

            });
        }

        public IActionResult CargaTabla()
        {
            List<SituacionOperatividadNaveJesehinDTO> situacionOperatividadNaveJesehinDTO = situacionOperatividadNaveJesehinBL.ObtenerLista();
            return Json(new { data = situacionOperatividadNaveJesehinDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int TipoNaveId, int CascoNaval, int DependenciaId, int DepartamentoUbigeoId, 
            int TipoPlataformaNaveId, int CapacidadOperativaRequeridaId, int CondicionId, int ProvinciaUbigeoId, int DistritoUbigeoId, 
            string Ubicacion, string Observacion)
        {
            SituacionOperatividadNaveJesehinDTO situacionOperatividadNaveJesehinDTO = new();
            situacionOperatividadNaveJesehinDTO.TipoNaveId = TipoNaveId;
            situacionOperatividadNaveJesehinDTO.CascoNaval = CascoNaval;
            situacionOperatividadNaveJesehinDTO.TipoPlataformaNaveId = TipoPlataformaNaveId;
            situacionOperatividadNaveJesehinDTO.DependenciaId = DependenciaId;
            situacionOperatividadNaveJesehinDTO.Ubicacion = Ubicacion;
            situacionOperatividadNaveJesehinDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            situacionOperatividadNaveJesehinDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            situacionOperatividadNaveJesehinDTO.DistritoUbigeoId = DistritoUbigeoId;
            situacionOperatividadNaveJesehinDTO.CapacidadOperativaRequeridaId = CapacidadOperativaRequeridaId;
            situacionOperatividadNaveJesehinDTO.CondicionId = CondicionId;
            situacionOperatividadNaveJesehinDTO.Observacion = Observacion;
            situacionOperatividadNaveJesehinDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperatividadNaveJesehinBL.AgregarRegistro(situacionOperatividadNaveJesehinDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(situacionOperatividadNaveJesehinBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int SituacionOperatividadNaveJesehinId, int TipoNaveId, int CascoNaval, int DependenciaId, int DepartamentoUbigeoId,
            int TipoPlataformaNaveId, int CapacidadOperativaRequeridaId, int CondicionId, int ProvinciaUbigeoId, int DistritoUbigeoId,
            string Ubicacion, string Observacion)
        {
            SituacionOperatividadNaveJesehinDTO situacionOperatividadNaveJesehinDTO = new();
            situacionOperatividadNaveJesehinDTO.SituacionOperatividadNaveJesehinId = SituacionOperatividadNaveJesehinId;
            situacionOperatividadNaveJesehinDTO.TipoNaveId = TipoNaveId;
            situacionOperatividadNaveJesehinDTO.CascoNaval = CascoNaval;
            situacionOperatividadNaveJesehinDTO.TipoPlataformaNaveId = TipoPlataformaNaveId;
            situacionOperatividadNaveJesehinDTO.DependenciaId = DependenciaId;
            situacionOperatividadNaveJesehinDTO.Ubicacion = Ubicacion;
            situacionOperatividadNaveJesehinDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            situacionOperatividadNaveJesehinDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            situacionOperatividadNaveJesehinDTO.DistritoUbigeoId = DistritoUbigeoId;
            situacionOperatividadNaveJesehinDTO.CapacidadOperativaRequeridaId = CapacidadOperativaRequeridaId;
            situacionOperatividadNaveJesehinDTO.CondicionId = CondicionId;
            situacionOperatividadNaveJesehinDTO.Observacion = Observacion;
            situacionOperatividadNaveJesehinDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperatividadNaveJesehinBL.ActualizarFormato(situacionOperatividadNaveJesehinDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            SituacionOperatividadNaveJesehinDTO situacionOperatividadNaveJesehinDTO = new();
            situacionOperatividadNaveJesehinDTO.SituacionOperatividadNaveJesehinId = Id;
            situacionOperatividadNaveJesehinDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (situacionOperatividadNaveJesehinBL.EliminarFormato(situacionOperatividadNaveJesehinDTO) == true)
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

            List<SituacionOperatividadNaveJesehinDTO> lista = new List<SituacionOperatividadNaveJesehinDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new SituacionOperatividadNaveJesehinDTO
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
            List<SituacionOperatividadNaveJesehinDTO> lista = new List<SituacionOperatividadNaveJesehinDTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new SituacionOperatividadNaveJesehinDTO
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
                var estado = situacionOperatividadNaveJesehinBL.InsercionMasiva(lista);
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
            var Capitanias = situacionOperatividadNaveJesehinBL.ObtenerLista();
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