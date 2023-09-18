using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comesguard;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comesguard;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class ComesguardIngresoDatoServicioApoyoMovilidadController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        IngresoDatoServicioApoyoMovilidad ingresoDatoServicioApoyoMovilidadBL = new();

        Dependencia dependenciaBL = new();
        ClaseVehiculo claseVehiculoBL = new();
        MarcaVehiculo marcaVehiculoBL = new();
        EstadoOperativo estadoOperativoBL = new();
        Carga cargaBL = new();
        public ComesguardIngresoDatoServicioApoyoMovilidadController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Formato para el ingreso de datos del servicio de apoyo con movilidad", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<ClaseVehiculoDTO> claseVehiculoDTO = claseVehiculoBL.ObtenerClaseVehiculos();
            List<MarcaVehiculoDTO> marcaVehiculoDTO = marcaVehiculoBL.ObtenerMarcaVehiculos();
            List<EstadoOperativoDTO> estadoOperativoDTO = estadoOperativoBL.ObtenerEstadoOperativos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("IngresoDatoServicioApoyoMovilidad");

            return Json(new
            {
                data1 = dependenciaDTO,
                data2 = claseVehiculoDTO,
                data3 = marcaVehiculoDTO,
                data4 = estadoOperativoDTO,
                data5 = listaCargas,
            });
        }

        public IActionResult CargaTabla()
        {
            List<IngresoDatoServicioApoyoMovilidadDTO> select = ingresoDatoServicioApoyoMovilidadBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string FechaInicio, string FechaTermino, string CodigoDependencia, string CodigoClaseVehiculo,
            string CodigoMarcaVehiculo, string PlacaVehiculo, string CodigoEstadoOperativo, int CargaId)
        {
            IngresoDatoServicioApoyoMovilidadDTO ingresoDatoServicioApoyoMovilidadDTO = new();
            ingresoDatoServicioApoyoMovilidadDTO.FechaInicio = FechaInicio;
            ingresoDatoServicioApoyoMovilidadDTO.FechaTermino = FechaTermino;
            ingresoDatoServicioApoyoMovilidadDTO.CodigoDependencia = CodigoDependencia;
            ingresoDatoServicioApoyoMovilidadDTO.CodigoClaseVehiculo = CodigoClaseVehiculo;
            ingresoDatoServicioApoyoMovilidadDTO.CodigoMarcaVehiculo = CodigoMarcaVehiculo;
            ingresoDatoServicioApoyoMovilidadDTO.PlacaVehiculo = PlacaVehiculo;
            ingresoDatoServicioApoyoMovilidadDTO.CodigoEstadoOperativo = CodigoEstadoOperativo;
            ingresoDatoServicioApoyoMovilidadDTO.CargaId = CargaId;
            
            ingresoDatoServicioApoyoMovilidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ingresoDatoServicioApoyoMovilidadBL.AgregarRegistro(ingresoDatoServicioApoyoMovilidadDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(ingresoDatoServicioApoyoMovilidadBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaInicio, string FechaTermino, string CodigoDependencia, string CodigoClaseVehiculo,
            string CodigoMarcaVehiculo, string PlacaVehiculo, string CodigoEstadoOperativo)
        {
            IngresoDatoServicioApoyoMovilidadDTO ingresoDatoServicioApoyoMovilidadDTO = new();
            ingresoDatoServicioApoyoMovilidadDTO.IngresoDatoServicioApoyoMovilidadId = Id;
            ingresoDatoServicioApoyoMovilidadDTO.FechaInicio = FechaInicio;
            ingresoDatoServicioApoyoMovilidadDTO.FechaTermino = FechaTermino;
            ingresoDatoServicioApoyoMovilidadDTO.CodigoDependencia = CodigoDependencia;
            ingresoDatoServicioApoyoMovilidadDTO.CodigoClaseVehiculo = CodigoClaseVehiculo;
            ingresoDatoServicioApoyoMovilidadDTO.CodigoMarcaVehiculo = CodigoMarcaVehiculo;
            ingresoDatoServicioApoyoMovilidadDTO.PlacaVehiculo = PlacaVehiculo;
            ingresoDatoServicioApoyoMovilidadDTO.CodigoEstadoOperativo = CodigoEstadoOperativo;

            ingresoDatoServicioApoyoMovilidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ingresoDatoServicioApoyoMovilidadBL.ActualizarFormato(ingresoDatoServicioApoyoMovilidadDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            IngresoDatoServicioApoyoMovilidadDTO ingresoDatoServicioApoyoMovilidadDTO = new();
            ingresoDatoServicioApoyoMovilidadDTO.IngresoDatoServicioApoyoMovilidadId = Id;
            ingresoDatoServicioApoyoMovilidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (ingresoDatoServicioApoyoMovilidadBL.EliminarFormato(ingresoDatoServicioApoyoMovilidadDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<IngresoDatoServicioApoyoMovilidadDTO> lista = new List<IngresoDatoServicioApoyoMovilidadDTO>();
            try
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

                for (int i = 1; i <= cantidadFilas; i++)
                {
                    IRow fila = HojaExcel.GetRow(i);

                    lista.Add(new IngresoDatoServicioApoyoMovilidadDTO
                    {
                        FechaInicio = fila.GetCell(0).ToString(),
                        FechaTermino = fila.GetCell(1).ToString(),
                        CodigoDependencia = fila.GetCell(2).ToString(),
                        CodigoClaseVehiculo = fila.GetCell(3).ToString(),
                        CodigoMarcaVehiculo = fila.GetCell(4).ToString(),
                        PlacaVehiculo = fila.GetCell(5).ToString(),
                        CodigoEstadoOperativo = fila.GetCell(6).ToString(),

                    });
                }
            }
            catch (Exception e)
            {
                Mensaje = "0";
            }
            return Json(new { data = Mensaje, data1 = lista });
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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("FechaInicio", typeof(string)),
                    new DataColumn("FechaTermino", typeof(string)),
                    new DataColumn("CodigoDependencia ", typeof(string)),
                    new DataColumn("CodigoClaseVehiculo ", typeof(string)),
                    new DataColumn("CodigoMarcaVehiculo ", typeof(string)),
                    new DataColumn("PlacaVehiculo ", typeof(string)),
                    new DataColumn("CodigoEstadoOperativo ", typeof(string)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                   
                    User.obtenerUsuario());
            }
            var IND_OPERACION = ingresoDatoServicioApoyoMovilidadBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteCIDSAM(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comesguard\\IngresoDatoServicioApoyoMovilidad.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = ingresoDatoServicioApoyoMovilidadBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("IngresoDatoServicioApoyoMovilidad", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\IngresoDatoServicioApoyoMovilidad.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "IngresoDatoServicioApoyoMovilidad.xlsx");
        }
    }

}


