using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Ditranav;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Ditranav;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Data;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DitranavVehiculosTerActividadInstiController : Controller
    {

        CapitaniaDAO capitaniaBL = new();
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        VehiculosTerActividadInstitucionDAO vehiculosTerActividadInstBL = new();
        ZonaNavalDAO zonaNavalBL = new();
        MarcaVehiculoDAO  marcaVehiculoBL = new();
        Carga cargaBL = new();

        public DitranavVehiculosTerActividadInstiController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Vehículos de transporte terrestre actividades de la Institución", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<MarcaVehiculoDTO> marcaVehiculoDTO = marcaVehiculoBL.ObtenerMarcaVehiculos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("VehiculosTerActividadInstitucion");
            return Json(new { data1 = zonaNavalDTO, data2 = marcaVehiculoDTO , data3 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<VehiculosTerActividadInstitucionDTO> select = vehiculosTerActividadInstBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string PlacaVehiculo, string ClasificacionFlotaVehiculo, string CodigoZonaNaval, string CodigoMarcaVehiculo,
            int AnioFabricacionVehiculo, string DependenciaAsignadaVehiculo, string EstadoOperatividadVehiculo, int CargaId, string Fecha)
        {
            VehiculosTerActividadInstitucionDTO vehiculosTerActividadInstiDTO = new();
            vehiculosTerActividadInstiDTO.PlacaVehiculo = PlacaVehiculo;
            vehiculosTerActividadInstiDTO.ClasificacionFlotaVehiculo = ClasificacionFlotaVehiculo;
            vehiculosTerActividadInstiDTO.CodigoZonaNaval = CodigoZonaNaval;
            vehiculosTerActividadInstiDTO.CodigoMarcaVehiculo = CodigoMarcaVehiculo;
            vehiculosTerActividadInstiDTO.AnioFabricacionVehiculo = AnioFabricacionVehiculo;
            vehiculosTerActividadInstiDTO.DependenciaAsignadaVehiculo = DependenciaAsignadaVehiculo;
            vehiculosTerActividadInstiDTO.EstadoOperatividadVehiculo = EstadoOperatividadVehiculo;
            vehiculosTerActividadInstiDTO.CargaId = CargaId;
            vehiculosTerActividadInstiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = vehiculosTerActividadInstBL.AgregarRegistro(vehiculosTerActividadInstiDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(vehiculosTerActividadInstBL.BuscarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string PlacaVehiculo, string ClasificacionFlotaVehiculo, string CodigoZonaNaval, string CodigoMarcaVehiculo,
            int AnioFabricacionVehiculo, string DependenciaAsignadaVehiculo, string EstadoOperatividadVehiculo)
        {
            
            VehiculosTerActividadInstitucionDTO vehiculosTerActividadInstiDTO = new();
            vehiculosTerActividadInstiDTO.VehiculosTerActividadInstitucionId = Id;
            vehiculosTerActividadInstiDTO.PlacaVehiculo = PlacaVehiculo;
            vehiculosTerActividadInstiDTO.ClasificacionFlotaVehiculo = ClasificacionFlotaVehiculo;
            vehiculosTerActividadInstiDTO.CodigoZonaNaval = CodigoZonaNaval;
            vehiculosTerActividadInstiDTO.CodigoMarcaVehiculo = CodigoMarcaVehiculo;
            vehiculosTerActividadInstiDTO.AnioFabricacionVehiculo = AnioFabricacionVehiculo;
            vehiculosTerActividadInstiDTO.DependenciaAsignadaVehiculo = DependenciaAsignadaVehiculo;
            vehiculosTerActividadInstiDTO.EstadoOperatividadVehiculo = EstadoOperatividadVehiculo;
            vehiculosTerActividadInstiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = vehiculosTerActividadInstBL.ActualizaFormato(vehiculosTerActividadInstiDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            VehiculosTerActividadInstitucionDTO vehiculosTerActividadInstiDTO = new();
            vehiculosTerActividadInstiDTO.VehiculosTerActividadInstitucionId = Id;
            vehiculosTerActividadInstiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (vehiculosTerActividadInstBL.EliminarFormato(vehiculosTerActividadInstiDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            VehiculosTerActividadInstitucionDTO vehiculosTerActividadInstiDTO = new();
            vehiculosTerActividadInstiDTO.CargaId = Id;
            vehiculosTerActividadInstiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (vehiculosTerActividadInstBL.EliminarCarga(vehiculosTerActividadInstiDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<VehiculosTerActividadInstitucionDTO> lista = new List<VehiculosTerActividadInstitucionDTO>();
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

                    lista.Add(new VehiculosTerActividadInstitucionDTO
                    {
                        PlacaVehiculo = fila.GetCell(0).ToString(),
                        ClasificacionFlotaVehiculo = fila.GetCell(1).ToString(),
                        CodigoZonaNaval = fila.GetCell(2).ToString(),
                        CodigoMarcaVehiculo = fila.GetCell(3).ToString(),
                        AnioFabricacionVehiculo = int.Parse(fila.GetCell(4).ToString()),
                        DependenciaAsignadaVehiculo = fila.GetCell(5).ToString(),
                        EstadoOperatividadVehiculo = fila.GetCell(6).ToString()

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
        //Registrar Masivo[AuthorizePermission(Formato: 43, Permiso: 4)]
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string Fecha)
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
                    new DataColumn("PlacaVehiculo ", typeof(string)),
                    new DataColumn("ClasificacionFlotaVehiculo ", typeof(string)),
                    new DataColumn("CodigoZonaNaval ", typeof(string)),
                    new DataColumn("CodigoMarcaVehiculo ", typeof(string)),
                    new DataColumn("AnioFabricacionVehiculo ", typeof(int)),
                    new DataColumn("DependenciaAsignadaVehiculo ", typeof(string)),
                    new DataColumn("EstadoOperatividadVehiculo ", typeof(string)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(

                             fila.GetCell(0).ToString(),
                             fila.GetCell(1).ToString(),
                             fila.GetCell(2).ToString(),
                             fila.GetCell(3).ToString(),
                             int.Parse(fila.GetCell(4).ToString()),
                             fila.GetCell(5).ToString(),
                             fila.GetCell(6).ToString(),

                             User.obtenerUsuario());
            }
            var IND_OPERACION = vehiculosTerActividadInstBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);


        }

        public IActionResult ReporteDVTAI(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Ditranav\\VehiculosTerActividadInstitucion.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = vehiculosTerActividadInstBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("VehiculosTerActividadInstitucion", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DitranavVehiculosTerActividadInsti.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DitranavVehiculosTerActividadInsti.xlsx");
        }

    }

}