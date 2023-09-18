using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Fovimar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Fovimar;
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
    public class FovimarPrestamoHipotecarioNavalController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        PrestamoHipotecarioNaval prestamoHipotecarioNavalBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        MonedaDAO monedaBL = new();
        SituacionPersonalNaval situacionPersonalNavalBL = new();
        ModalidadPrestamo modalidadPrestamoBL = new();
        FinalidadPrestamo finalidadPrestamoBL = new();
        EntidadFinanciera entidadFinancieraBL = new();
        ProyectoFovimar proyectoFovimarBL = new();
        Carga cargaBL = new();

        public FovimarPrestamoHipotecarioNavalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Préstamos Hipotecarios del Personal Naval", FromController = typeof(HomeController))]
        public IActionResult Index()
        {           
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<MonedaDTO> monedaDTO = monedaBL.ObtenerMonedas();
            List<SituacionPersonalNavalDTO> situacionPersonalNavalDTO = situacionPersonalNavalBL.ObtenerSituacionPersonalNavals();
            List<ModalidadPrestamoDTO> modalidadPrestamoDTO = modalidadPrestamoBL.ObtenerModalidadPrestamos();
            List<FinalidadPrestamoDTO> finalidadPrestamoDTO = finalidadPrestamoBL.ObtenerFinalidadPrestamos();
            List<EntidadFinancieraDTO> entidadFinancieraDTO = entidadFinancieraBL.ObtenerEntidadFinancieras();
            List<ProyectoFovimarDTO> proyectoFovimarDTO = proyectoFovimarBL.ObtenerProyectoFovimars();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PrestamoHipotecarioNaval");
            return Json(new
            {
                data1 = gradoPersonalMilitarDTO,
                data2 = monedaDTO,
                data3 = situacionPersonalNavalDTO,
                data4 = modalidadPrestamoDTO,
                data5 = finalidadPrestamoDTO,
                data6 = entidadFinancieraDTO,
                data7 = proyectoFovimarDTO,
                data8 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<PrestamoHipotecarioNavalDTO> select  = prestamoHipotecarioNavalBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar( string DNIPersonalNaval, string CodigoGradoPersonalMilitar, 
            string CodigoSituacionPersonalNaval, decimal MontoPrestadoOtorgado, string CodigoMoneda, 
            int NroCuota, string CodigoModalidadPrestamo, string CodigoFinalidadPrestamo, 
            string CodigoEntidadFinanciera, decimal RentabilidadFinanciera, string CodigoProyectoFovimar, 
            string GarantiaConstituida, int CuotaPagada, string EstadoDeuda, decimal MontoMorosidad, 
            int CargaId, string Fecha)
        {
            PrestamoHipotecarioNavalDTO prestamoHipotecarioNavalDTO = new();
            prestamoHipotecarioNavalDTO.DNIPersonalNaval = DNIPersonalNaval;
            prestamoHipotecarioNavalDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            prestamoHipotecarioNavalDTO.CodigoSituacionPersonalNaval = CodigoSituacionPersonalNaval;
            prestamoHipotecarioNavalDTO.MontoPrestadoOtorgado = MontoPrestadoOtorgado;
            prestamoHipotecarioNavalDTO.CodigoMoneda = CodigoMoneda;
            prestamoHipotecarioNavalDTO.NroCuota = NroCuota;
            prestamoHipotecarioNavalDTO.CodigoModalidadPrestamo = CodigoModalidadPrestamo;
            prestamoHipotecarioNavalDTO.CodigoFinalidadPrestamo = CodigoFinalidadPrestamo;
            prestamoHipotecarioNavalDTO.CodigoEntidadFinanciera = CodigoEntidadFinanciera;
            prestamoHipotecarioNavalDTO.RentabilidadFinanciera = RentabilidadFinanciera;
            prestamoHipotecarioNavalDTO.CodigoProyectoFovimar = CodigoProyectoFovimar;
            prestamoHipotecarioNavalDTO.GarantiaConstituida = GarantiaConstituida;
            prestamoHipotecarioNavalDTO.CuotaPagada = CuotaPagada;
            prestamoHipotecarioNavalDTO.EstadoDeuda = EstadoDeuda;
            prestamoHipotecarioNavalDTO.MontoMorosidad = MontoMorosidad;
            prestamoHipotecarioNavalDTO.CargaId =  CargaId;
            prestamoHipotecarioNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = prestamoHipotecarioNavalBL.AgregarRegistro(prestamoHipotecarioNavalDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(prestamoHipotecarioNavalBL.BuscarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int PrestamoHipotecarioNavalId, string DNIPersonalNaval, string CodigoGradoPersonalMilitar, 
            string CodigoSituacionPersonalNaval, decimal MontoPrestadoOtorgado, string CodigoMoneda, int NroCuota, 
            string CodigoModalidadPrestamo, string CodigoFinalidadPrestamo, string CodigoEntidadFinanciera, decimal RentabilidadFinanciera , 
            string CodigoProyectoFovimar, string GarantiaConstituida, int CuotaPagada, string EstadoDeuda, decimal MontoMorosidad)
        {
            PrestamoHipotecarioNavalDTO prestamoHipotecarioNavalDTO = new();
            prestamoHipotecarioNavalDTO.PrestamoHipotecarioNavalId = PrestamoHipotecarioNavalId;
            prestamoHipotecarioNavalDTO.DNIPersonalNaval = DNIPersonalNaval;
            prestamoHipotecarioNavalDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            prestamoHipotecarioNavalDTO.CodigoSituacionPersonalNaval = CodigoSituacionPersonalNaval;
            prestamoHipotecarioNavalDTO.MontoPrestadoOtorgado = MontoPrestadoOtorgado;
            prestamoHipotecarioNavalDTO.CodigoMoneda = CodigoMoneda;
            prestamoHipotecarioNavalDTO.NroCuota = NroCuota;
            prestamoHipotecarioNavalDTO.CodigoModalidadPrestamo = CodigoModalidadPrestamo;
            prestamoHipotecarioNavalDTO.CodigoFinalidadPrestamo = CodigoFinalidadPrestamo;
            prestamoHipotecarioNavalDTO.CodigoEntidadFinanciera = CodigoEntidadFinanciera;
            prestamoHipotecarioNavalDTO.RentabilidadFinanciera = RentabilidadFinanciera;
            prestamoHipotecarioNavalDTO.CodigoProyectoFovimar = CodigoProyectoFovimar;
            prestamoHipotecarioNavalDTO.GarantiaConstituida = GarantiaConstituida;
            prestamoHipotecarioNavalDTO.CuotaPagada = CuotaPagada;
            prestamoHipotecarioNavalDTO.EstadoDeuda = EstadoDeuda;
            prestamoHipotecarioNavalDTO.MontoMorosidad = MontoMorosidad;
            prestamoHipotecarioNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = prestamoHipotecarioNavalBL.ActualizarFormato(prestamoHipotecarioNavalDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PrestamoHipotecarioNavalDTO prestamoHipotecarioNavalDTO = new();
            prestamoHipotecarioNavalDTO.PrestamoHipotecarioNavalId = Id;
            prestamoHipotecarioNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (prestamoHipotecarioNavalBL.EliminarFormato(prestamoHipotecarioNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            PrestamoHipotecarioNavalDTO prestamoHipotecarioNavalDTO = new();
            prestamoHipotecarioNavalDTO.CargaId = Id;
            prestamoHipotecarioNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (prestamoHipotecarioNavalBL.EliminarCarga(prestamoHipotecarioNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<PrestamoHipotecarioNavalDTO> lista = new List<PrestamoHipotecarioNavalDTO>();
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

                    lista.Add(new PrestamoHipotecarioNavalDTO
                    {
                        DNIPersonalNaval = fila.GetCell(0).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(1).ToString(),
                        CodigoSituacionPersonalNaval = fila.GetCell(2).ToString(),
                        MontoPrestadoOtorgado = decimal.Parse(fila.GetCell(3).ToString()),
                        CodigoMoneda = fila.GetCell(4).ToString(),
                        NroCuota = int.Parse(fila.GetCell(5).ToString()),
                        CodigoModalidadPrestamo = fila.GetCell(6).ToString(),
                        CodigoFinalidadPrestamo = fila.GetCell(7).ToString(),
                        CodigoEntidadFinanciera = fila.GetCell(8).ToString(),
                        RentabilidadFinanciera = decimal.Parse(fila.GetCell(9).ToString()),
                        CodigoProyectoFovimar = fila.GetCell(10).ToString(),
                        GarantiaConstituida = fila.GetCell(11).ToString(),
                        CuotaPagada = int.Parse(fila.GetCell(12).ToString()),
                        EstadoDeuda = fila.GetCell(13).ToString(),
                        MontoMorosidad = decimal.Parse(fila.GetCell(14).ToString()),
 
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
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string Fecha)
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

            dt.Columns.AddRange(new DataColumn[16]
            {
                    new DataColumn("DNIPersonalNaval", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoSituacionPersonalNaval", typeof(string)),
                    new DataColumn("MontoPrestadoOtorgado", typeof(decimal)),
                    new DataColumn("CodigoMoneda", typeof(string)),
                    new DataColumn("NroCuota", typeof(int)),
                    new DataColumn("CodigoModalidadPrestamo", typeof(string)),
                    new DataColumn("CodigoFinalidadPrestamo", typeof(string)),
                    new DataColumn("CodigoEntidadFinanciera", typeof(string)),
                    new DataColumn("RentabilidadFinanciera", typeof(decimal)),
                    new DataColumn("CodigoProyectoFovimar", typeof(string)),
                    new DataColumn("GarantiaConstituida", typeof(string)),
                    new DataColumn("CuotaPagada", typeof(int)),
                    new DataColumn("EstadoDeuda", typeof(string)),
                    new DataColumn("MontoMorosidad", typeof(decimal)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    decimal.Parse(fila.GetCell(3).ToString()),
                    fila.GetCell(4).ToString(),
                    int.Parse(fila.GetCell(5).ToString()),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    decimal.Parse(fila.GetCell(9).ToString()),
                    fila.GetCell(10).ToString(),
                    fila.GetCell(11).ToString(),
                    int.Parse(fila.GetCell(12).ToString()),
                    fila.GetCell(13).ToString(),
                    decimal.Parse(fila.GetCell(14).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = prestamoHipotecarioNavalBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            LocalReport localReport = new LocalReport(path);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DifovimarPrestamoHipotecarioNaval.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DifovimarPrestamoHipotecarioNaval.xlsx");
        }
    }

}