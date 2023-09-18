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
    public class ComestreSituacionOperatividadEquipoController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        SituacionOperatividadEquipoComestre situacionOperatividadEquipoComestreBL = new();

        DescripcionMaterial descripcionMaterialBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();

        public ComestreSituacionOperatividadEquipoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Formato de Situacion de Operatividad de Equipo XS", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DescripcionMaterialDTO> descripcionMaterialDTO = descripcionMaterialBL.ObtenerDescripcionMaterials();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();

            return Json(new
            {
                data1 = descripcionMaterialDTO,
                data2 = departamentoUbigeoDTO,
                data3 = provinciaUbigeoDTO,
                data4 = distritoUbigeoDTO,
            });
        }

        public IActionResult CargaTabla()
        {
            List<SituacionOperatividadEquipoComestreDTO> situacionOperatividadEquipoComestreDTO = situacionOperatividadEquipoComestreBL.ObtenerLista();
            return Json(new { data = situacionOperatividadEquipoComestreDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int DescripcionMaterialId, int Cantidad, string CodigoUnidad, int DepartamentoUbigeoId, 
            string Ubicacion, string Condicion,int ProvinciaUbigeoId, int DistritoUbigeoId, string Observacion)
        {
            SituacionOperatividadEquipoComestreDTO situacionOperatividadEquipoComestreDTO = new();
            situacionOperatividadEquipoComestreDTO.DescripcionMaterialId = DescripcionMaterialId;
            situacionOperatividadEquipoComestreDTO.Cantidad = Cantidad;
            situacionOperatividadEquipoComestreDTO.CodigoUnidad = CodigoUnidad;
            situacionOperatividadEquipoComestreDTO.Ubicacion = Ubicacion;
            situacionOperatividadEquipoComestreDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            situacionOperatividadEquipoComestreDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            situacionOperatividadEquipoComestreDTO.DistritoUbigeoId = DistritoUbigeoId;
            situacionOperatividadEquipoComestreDTO.Condicion = Condicion;
            situacionOperatividadEquipoComestreDTO.Observacion = Observacion;
            situacionOperatividadEquipoComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperatividadEquipoComestreBL.AgregarRegistro(situacionOperatividadEquipoComestreDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(situacionOperatividadEquipoComestreBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int SituacionOperatividadEquipoId, int DescripcionMaterialId, int Cantidad, string CodigoUnidad, int DepartamentoUbigeoId,
            string Ubicacion, string Condicion, int ProvinciaUbigeoId, int DistritoUbigeoId, string Observacion)
        {
            SituacionOperatividadEquipoComestreDTO situacionOperatividadEquipoComestreDTO = new();
            situacionOperatividadEquipoComestreDTO.SituacionOperatividadEquipoId = SituacionOperatividadEquipoId;
            situacionOperatividadEquipoComestreDTO.DescripcionMaterialId = DescripcionMaterialId;
            situacionOperatividadEquipoComestreDTO.Cantidad = Cantidad;
            situacionOperatividadEquipoComestreDTO.CodigoUnidad = CodigoUnidad;
            situacionOperatividadEquipoComestreDTO.Ubicacion = Ubicacion;
            situacionOperatividadEquipoComestreDTO.DepartamentoUbigeoId = DepartamentoUbigeoId;
            situacionOperatividadEquipoComestreDTO.ProvinciaUbigeoId = ProvinciaUbigeoId;
            situacionOperatividadEquipoComestreDTO.DistritoUbigeoId = DistritoUbigeoId;
            situacionOperatividadEquipoComestreDTO.Condicion = Condicion;
            situacionOperatividadEquipoComestreDTO.Observacion = Observacion;
            situacionOperatividadEquipoComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperatividadEquipoComestreBL.ActualizarFormato(situacionOperatividadEquipoComestreDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            SituacionOperatividadEquipoComestreDTO situacionOperatividadEquipoComestreDTO = new();
            situacionOperatividadEquipoComestreDTO.SituacionOperatividadEquipoId = Id;
            situacionOperatividadEquipoComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (situacionOperatividadEquipoComestreBL.EliminarFormato(situacionOperatividadEquipoComestreDTO) == true)
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

            List<SituacionOperatividadEquipoComestreDTO> lista = new List<SituacionOperatividadEquipoComestreDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new SituacionOperatividadEquipoComestreDTO
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
            List<SituacionOperatividadEquipoComestreDTO> lista = new List<SituacionOperatividadEquipoComestreDTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new SituacionOperatividadEquipoComestreDTO
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
                var estado = situacionOperatividadEquipoComestreBL.InsercionMasiva(lista);
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
            var Capitanias = situacionOperatividadEquipoComestreBL.ObtenerLista();
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