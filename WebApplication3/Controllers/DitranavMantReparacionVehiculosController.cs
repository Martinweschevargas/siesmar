using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Ditranav;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diali;
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
    public class DitranavMantReparacionVehiculosController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        MantenimientoReparacionVehiculosDAO mantreparacionvehiBL = new();

        MarcaVehiculoDAO marcaVehiculoBL = new();
        Carga cargaBL = new();

        public DitranavMantReparacionVehiculosController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Mantenimiento y Reparación Vehiculos de Transporte Terrestre ", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<MarcaVehiculoDTO> marcaVehiculoDTO = marcaVehiculoBL.ObtenerMarcaVehiculos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("MantenimientoReparacionVehiculo");
            return Json(new { data1 = marcaVehiculoDTO, data2 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<MantenimientoReparacionVehiculosDTO> select = mantreparacionvehiBL.ObtenerLista();
            return Json(new { data = select });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string PlacaVehiculoMantenimiento, string FechaIngresoMantenimiento, string ClasificacionFlotaVehiculoM, string CodigoMarcaVehiculo,
            int AnioFabricacionVehiculoM, int KilometrosVehiculoM, string DependenciaVehiculoM, string MotivoServicioVehiculo, string FechaSalidaVehiculoM,
            string RequerimientoRepuesto, decimal CostoRepuestos, string OrdenCompraServicio, int CargaId, string Fecha)
        { 
        
            MantenimientoReparacionVehiculosDTO mantReparacionVehiculosDTO = new();
            mantReparacionVehiculosDTO.PlacaVehiculoMantenimiento = PlacaVehiculoMantenimiento;
            mantReparacionVehiculosDTO.FechaIngresoMantenimiento = FechaIngresoMantenimiento;
            mantReparacionVehiculosDTO.ClasificacionFlotaVehiculoM = ClasificacionFlotaVehiculoM;
            mantReparacionVehiculosDTO.CodigoMarcaVehiculo = CodigoMarcaVehiculo;
            mantReparacionVehiculosDTO.AnioFabricacionVehiculoM = AnioFabricacionVehiculoM;
            mantReparacionVehiculosDTO.KilometrosVehiculoM = KilometrosVehiculoM;
            mantReparacionVehiculosDTO.DependenciaVehiculoM = DependenciaVehiculoM;
            mantReparacionVehiculosDTO.MotivoServicioVehiculo = MotivoServicioVehiculo;
            mantReparacionVehiculosDTO.FechaSalidaVehiculoM = FechaSalidaVehiculoM;
            mantReparacionVehiculosDTO.RequerimientoRepuesto = RequerimientoRepuesto;
            mantReparacionVehiculosDTO.CostoRepuestos = CostoRepuestos;
            mantReparacionVehiculosDTO.OrdenCompraServicio = OrdenCompraServicio;
            mantReparacionVehiculosDTO.CargaId = CargaId;
            mantReparacionVehiculosDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = mantreparacionvehiBL.AgregarRegistro(mantReparacionVehiculosDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(mantreparacionvehiBL.BuscarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string PlacaVehiculoMantenimiento, string FechaIngresoMantenimiento, string ClasificacionFlotaVehiculoM, string CodigoMarcaVehiculo,
            int AnioFabricacionVehiculoM, int KilometrosVehiculoM, string DependenciaVehiculoM, string MotivoServicioVehiculo, string FechaSalidaVehiculoM,
            string RequerimientoRepuesto, decimal CostoRepuestos, string OrdenCompraServicio)
        {

            MantenimientoReparacionVehiculosDTO mantReparacionVehiculosDTO = new();
            mantReparacionVehiculosDTO.MantenimientoReparacionVehiculoId = Id;
            mantReparacionVehiculosDTO.PlacaVehiculoMantenimiento = PlacaVehiculoMantenimiento;
            mantReparacionVehiculosDTO.FechaIngresoMantenimiento = FechaIngresoMantenimiento;
            mantReparacionVehiculosDTO.ClasificacionFlotaVehiculoM = ClasificacionFlotaVehiculoM;
            mantReparacionVehiculosDTO.CodigoMarcaVehiculo = CodigoMarcaVehiculo;
            mantReparacionVehiculosDTO.AnioFabricacionVehiculoM = AnioFabricacionVehiculoM;
            mantReparacionVehiculosDTO.KilometrosVehiculoM = KilometrosVehiculoM;
            mantReparacionVehiculosDTO.DependenciaVehiculoM = DependenciaVehiculoM;
            mantReparacionVehiculosDTO.MotivoServicioVehiculo = MotivoServicioVehiculo;
            mantReparacionVehiculosDTO.FechaSalidaVehiculoM = FechaSalidaVehiculoM;
            mantReparacionVehiculosDTO.RequerimientoRepuesto = RequerimientoRepuesto;
            mantReparacionVehiculosDTO.CostoRepuestos = CostoRepuestos;
            mantReparacionVehiculosDTO.OrdenCompraServicio = OrdenCompraServicio;
            mantReparacionVehiculosDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = mantreparacionvehiBL.ActualizaFormato(mantReparacionVehiculosDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            MantenimientoReparacionVehiculosDTO mantReparacionVehiculosDTO = new();
            mantReparacionVehiculosDTO.MantenimientoReparacionVehiculoId = Id;
            mantReparacionVehiculosDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (mantreparacionvehiBL.EliminarFormato(mantReparacionVehiculosDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            MantenimientoReparacionVehiculosDTO mantReparacionVehiculosDTO = new();
            mantReparacionVehiculosDTO.CargaId = Id;
            mantReparacionVehiculosDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (mantreparacionvehiBL.EliminarCarga(mantReparacionVehiculosDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {

            string Mensaje = "1";
            List<MantenimientoReparacionVehiculosDTO> lista = new List<MantenimientoReparacionVehiculosDTO>();
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

                    lista.Add(new MantenimientoReparacionVehiculosDTO
                    {
                        PlacaVehiculoMantenimiento = fila.GetCell(0).ToString(),
                        FechaIngresoMantenimiento = fila.GetCell(1).ToString(),
                        ClasificacionFlotaVehiculoM = fila.GetCell(2).ToString(),
                        CodigoMarcaVehiculo = fila.GetCell(3).ToString(),
                        AnioFabricacionVehiculoM = int.Parse(fila.GetCell(4).ToString()),
                        KilometrosVehiculoM = int.Parse(fila.GetCell(5).ToString()),
                        DependenciaVehiculoM = fila.GetCell(6).ToString(),
                        MotivoServicioVehiculo = fila.GetCell(7).ToString(),
                        FechaSalidaVehiculoM = fila.GetCell(8).ToString(),
                        RequerimientoRepuesto = fila.GetCell(9).ToString(),
                        CostoRepuestos = decimal.Parse(fila.GetCell(10).ToString()),
                        OrdenCompraServicio = fila.GetCell(11).ToString()

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
            var mensaje = "";

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
            DataTable dt = new();

            dt.Columns.AddRange(new DataColumn[13]
            {
                    new DataColumn("PlacaVehiculoMantenimiento", typeof(string)),
                    new DataColumn("FechaIngresoMantenimiento", typeof(string)),
                    new DataColumn("ClasificacionFlotaVehiculoM", typeof(string)),
                    new DataColumn("CodigoMarcaVehiculo", typeof(string)),
                    new DataColumn("AnioFabricacionVehiculoM", typeof(int)),      
                    new DataColumn("KilometrosVehiculoM", typeof(int)),
                    new DataColumn("DependenciaVehiculoM", typeof(string)),
                    new DataColumn("MotivoServicioVehiculo", typeof(string)),
                    new DataColumn("FechaSalidaVehiculoM", typeof(string)),
                    new DataColumn("RequerimientoRepuesto", typeof(string)),
                    new DataColumn("CostoRepuestos", typeof(decimal)),
                    new DataColumn("OrdenCompraServicio", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(

                             fila.GetCell(0).ToString(),
                             UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                             fila.GetCell(2).ToString(),
                             fila.GetCell(3).ToString(),
                             int.Parse(fila.GetCell(4).ToString()),
                             int.Parse(fila.GetCell(5).ToString()),
                             fila.GetCell(6).ToString(),
                             fila.GetCell(7).ToString(),
                             UtilitariosGlobales.obtenerFecha(fila.GetCell(8).ToString()),
                             fila.GetCell(9).ToString(),
                             decimal.Parse(fila.GetCell(10).ToString()),
                             fila.GetCell(11).ToString(),
                             User.obtenerUsuario()
                             );
            }
            var IND_OPERACION = mantreparacionvehiBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDMRV(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Ditranav\\MantenimientoReparacionVehiculo.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = mantreparacionvehiBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("MantenimientoReparacionVehiculo", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DitranavMantenimientoReparacionVehiculo.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DitranavMantenimientoReparacionVehiculo.xlsx");
        }

    }

}