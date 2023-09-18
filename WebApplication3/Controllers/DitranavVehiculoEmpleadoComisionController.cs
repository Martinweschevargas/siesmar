using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Ditranav;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Ditranav;
using Marina.Siesmar.Entidades.Formatos.Procumar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Atp;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DitranavVehiculoEmpleadoComisionController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        CapitaniaDAO capitaniaBL = new();
        VehiculoEmpleadoComisionDAO vehiculoEmpleadoComisionBL = new();
        MarcaVehiculoDAO marcaVehiculoBL = new();
        TipoVehiculoTransporteDAO  tipoVehiculoTransporteBL = new();
        Carga cargaBL = new();

        public DitranavVehiculoEmpleadoComisionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Vehículo de Transporte Empleados en Comisiones a las Unidades y Dependencias", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MarcaVehiculoDTO> marcaVehiculoDTO = marcaVehiculoBL.ObtenerMarcaVehiculos();
            List<TipoVehiculoTransporteDTO> tipoVehiculoTransporteDTO = tipoVehiculoTransporteBL.ObtenerTipoVehiculoTransportes();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("VehiculoEmpleadoComision");
            return Json(new { data1 = marcaVehiculoDTO, data2 = tipoVehiculoTransporteDTO, data3 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<VehiculoEmpleadoComisionDTO> select = vehiculoEmpleadoComisionBL.ObtenerLista();
            return Json(new { data = select });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string PlacaVehiculoComision, string ClasificacionFlotaComision, string CodigoMarcaVehiculo, string FechaComisionVehiculo,
            string CodigoTipoVehiculoTransporte, string DependenciaSolicitante, int CargaId, string Fecha)
        {
            VehiculoEmpleadoComisionDTO vehiculoEmpleadoComisionDTO = new();
            vehiculoEmpleadoComisionDTO.PlacaVehiculoComision = PlacaVehiculoComision;
            vehiculoEmpleadoComisionDTO.ClasificacionFlotaComision = ClasificacionFlotaComision;
            vehiculoEmpleadoComisionDTO.CodigoMarcaVehiculo = CodigoMarcaVehiculo;
            vehiculoEmpleadoComisionDTO.FechaComisionVehiculo = FechaComisionVehiculo;
            vehiculoEmpleadoComisionDTO.CodigoTipoVehiculoTransporte = CodigoTipoVehiculoTransporte;
            vehiculoEmpleadoComisionDTO.DependenciaSolicitante = DependenciaSolicitante;
            vehiculoEmpleadoComisionDTO.CargaId = CargaId;
            vehiculoEmpleadoComisionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = vehiculoEmpleadoComisionBL.AgregarRegistro(vehiculoEmpleadoComisionDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(vehiculoEmpleadoComisionBL.BuscarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string PlacaVehiculoComision, string ClasificacionFlotaComision, string CodigoMarcaVehiculo, string FechaComisionVehiculo,
            string CodigoTipoVehiculoTransporte, string DependenciaSolicitante)
        {
            
            VehiculoEmpleadoComisionDTO vehiculoEmpleadoComisionDTO = new();
            vehiculoEmpleadoComisionDTO.VehiculoEmpleadoComisionId = Id;
            vehiculoEmpleadoComisionDTO.PlacaVehiculoComision = PlacaVehiculoComision;
            vehiculoEmpleadoComisionDTO.ClasificacionFlotaComision = ClasificacionFlotaComision;
            vehiculoEmpleadoComisionDTO.CodigoMarcaVehiculo = CodigoMarcaVehiculo;
            vehiculoEmpleadoComisionDTO.FechaComisionVehiculo = FechaComisionVehiculo;
            vehiculoEmpleadoComisionDTO.CodigoTipoVehiculoTransporte = CodigoTipoVehiculoTransporte;
            vehiculoEmpleadoComisionDTO.DependenciaSolicitante = DependenciaSolicitante;
            vehiculoEmpleadoComisionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = vehiculoEmpleadoComisionBL.ActualizaFormato(vehiculoEmpleadoComisionDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            VehiculoEmpleadoComisionDTO vehiculoEmpleadoComisionDTO = new();
            vehiculoEmpleadoComisionDTO.VehiculoEmpleadoComisionId = Id;
            vehiculoEmpleadoComisionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (vehiculoEmpleadoComisionBL.EliminarFormato(vehiculoEmpleadoComisionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            VehiculoEmpleadoComisionDTO vehiculoEmpleadoComisionDTO = new();
            vehiculoEmpleadoComisionDTO.CargaId = Id;
            vehiculoEmpleadoComisionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (vehiculoEmpleadoComisionBL.EliminarCarga(vehiculoEmpleadoComisionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<VehiculoEmpleadoComisionDTO> lista = new List<VehiculoEmpleadoComisionDTO>();
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

                    lista.Add(new VehiculoEmpleadoComisionDTO
                    {
                        PlacaVehiculoComision = fila.GetCell(0).ToString(),
                        ClasificacionFlotaComision = fila.GetCell(1).ToString(),
                        CodigoMarcaVehiculo = fila.GetCell(2).ToString(),
                        FechaComisionVehiculo = fila.GetCell(3).ToString(),
                        CodigoTipoVehiculoTransporte = fila.GetCell(4).ToString(),
                        DependenciaSolicitante = fila.GetCell(5).ToString()
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

            dt.Columns.AddRange(new DataColumn[7]
            {
                    new DataColumn("PlacaVehiculoComision", typeof(string)),
                    new DataColumn("ClasificacionFlotaComision", typeof(string)),
                    new DataColumn("CodigoMarcaVehiculo", typeof(string)),
                    new DataColumn("FechaComisionVehiculo", typeof(string)),
                    new DataColumn("CodigoTipoVehiculoTransporte", typeof(string)),
                    new DataColumn("DependenciaSolicitante", typeof(string)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                             fila.GetCell(0).ToString(),
                             fila.GetCell(1).ToString(),
                             fila.GetCell(2).ToString(),
                             UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                             fila.GetCell(4).ToString(),
                             fila.GetCell(5).ToString(),
                             User.obtenerUsuario());
            }
            var IND_OPERACION = vehiculoEmpleadoComisionBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteDVEC(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Ditranav\\VehiculoEmpleadoComision.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = vehiculoEmpleadoComisionBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("VehiculoEmpleadoComision", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DitranavVehiculoEmpleadoComision.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DitranavVehiculoEmpleadoComision.xlsx");
        }

    }

}