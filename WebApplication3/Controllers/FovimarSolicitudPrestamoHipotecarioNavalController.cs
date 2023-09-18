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
    public class FovimarSolicitudPrestamoHipotecarioNavalController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        SolicitudPrestamoHipotecarioNaval solicitudPrestamoHipotecarioNavalBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        SituacionPersonalNaval situacionPersonalNavalBL = new();
        ModalidadPrestamo modalidadPrestamoBL = new();
        FinalidadPrestamo finalidadPrestamoBL = new();
        EntidadFinanciera entidadFinancieraBL = new();
        ProyectoFovimar proyectoFovimarBL = new();
        MonedaDAO monedaBL = new();
        Carga cargaBL = new();
        public FovimarSolicitudPrestamoHipotecarioNavalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Solicitud de Préstamos Hipotecarios del Personal Naval", FromController = typeof(HomeController))]
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
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("SolicitudPrestamoHipotecariosNaval");

            return Json(new
            {
                data1 = gradoPersonalMilitarDTO,
                data2 = monedaDTO,
                data3 = situacionPersonalNavalDTO,
                data4 = modalidadPrestamoDTO,
                data5 = finalidadPrestamoDTO,
                data6 = entidadFinancieraDTO,
                data7 = proyectoFovimarDTO,
                data8 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<SolicitudPrestamoHipotecarioNavalDTO> select = solicitudPrestamoHipotecarioNavalBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string DNIPersonalNaval, string CodigoGradoPersonalMilitar, 
            string CodigoSituacionPersonalNaval, string CodigoMoneda, string CodigoFinalidadPrestamo, 
            string Prestario, decimal MontoSolicitado, string FechaDesembolso, string CodigoModalidadPrestamo, 
            string CodigoEntidadFinanciera, string FechaSolicitud, int NroCuota, string FechaAprobacion, 
            string AprobacionSolicitud, string CodigoProyectoFovimar , decimal RentabilidadFinanciera, 
            string EstadoSolicitudPrestamo, string GarantiaConstituida, int CargaId, string Fecha)
        {
            SolicitudPrestamoHipotecarioNavalDTO solicitudPrestamoHipotecarioNavalDTO = new();
            solicitudPrestamoHipotecarioNavalDTO.DNIPersonalNaval = DNIPersonalNaval;
            solicitudPrestamoHipotecarioNavalDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            solicitudPrestamoHipotecarioNavalDTO.CodigoSituacionPersonalNaval = CodigoSituacionPersonalNaval;
            solicitudPrestamoHipotecarioNavalDTO.Prestario = Prestario;
            solicitudPrestamoHipotecarioNavalDTO.MontoSolicitado = MontoSolicitado;
            solicitudPrestamoHipotecarioNavalDTO.CodigoMoneda = CodigoMoneda;
            solicitudPrestamoHipotecarioNavalDTO.FechaSolicitud = FechaSolicitud;
            solicitudPrestamoHipotecarioNavalDTO.AprobacionSolicitud = AprobacionSolicitud;
            solicitudPrestamoHipotecarioNavalDTO.FechaAprobacion = FechaAprobacion;
            solicitudPrestamoHipotecarioNavalDTO.FechaDesembolso = FechaDesembolso;
            solicitudPrestamoHipotecarioNavalDTO.NroCuota = NroCuota;
            solicitudPrestamoHipotecarioNavalDTO.CodigoModalidadPrestamo = CodigoModalidadPrestamo;
            solicitudPrestamoHipotecarioNavalDTO.CodigoFinalidadPrestamo = CodigoFinalidadPrestamo;
            solicitudPrestamoHipotecarioNavalDTO.CodigoEntidadFinanciera = CodigoEntidadFinanciera;
            solicitudPrestamoHipotecarioNavalDTO.RentabilidadFinanciera = RentabilidadFinanciera;
            solicitudPrestamoHipotecarioNavalDTO.CodigoProyectoFovimar = CodigoProyectoFovimar;
            solicitudPrestamoHipotecarioNavalDTO.EstadoSolicitudPrestamo = EstadoSolicitudPrestamo;
            solicitudPrestamoHipotecarioNavalDTO.GarantiaConstituida = GarantiaConstituida;
            solicitudPrestamoHipotecarioNavalDTO.CargaId = CargaId;
            solicitudPrestamoHipotecarioNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = solicitudPrestamoHipotecarioNavalBL.AgregarRegistro(solicitudPrestamoHipotecarioNavalDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(solicitudPrestamoHipotecarioNavalBL.EditarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int SolicitudPrestamoHipotecarioNavalId, string DNIPersonalNaval, 
            string CodigoGradoPersonalMilitar, string CodigoSituacionPersonalNaval, string CodigoMoneda, 
            string CodigoFinalidadPrestamo, string Prestario, decimal MontoSolicitado, string FechaDesembolso, 
            string CodigoModalidadPrestamo, string CodigoEntidadFinanciera, string FechaSolicitud, int NroCuota, 
            string FechaAprobacion, string AprobacionSolicitud, string CodigoProyectoFovimar, 
            decimal RentabilidadFinanciera, string EstadoSolicitudPrestamo, string GarantiaConstituida)
        {
            SolicitudPrestamoHipotecarioNavalDTO solicitudPrestamoHipotecarioNavalDTO = new();
            solicitudPrestamoHipotecarioNavalDTO.SolicitudPrestamoHipotecarioNavalId = SolicitudPrestamoHipotecarioNavalId;
            solicitudPrestamoHipotecarioNavalDTO.DNIPersonalNaval = DNIPersonalNaval;
            solicitudPrestamoHipotecarioNavalDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            solicitudPrestamoHipotecarioNavalDTO.CodigoSituacionPersonalNaval = CodigoSituacionPersonalNaval;
            solicitudPrestamoHipotecarioNavalDTO.Prestario = Prestario;
            solicitudPrestamoHipotecarioNavalDTO.MontoSolicitado = MontoSolicitado;
            solicitudPrestamoHipotecarioNavalDTO.CodigoMoneda = CodigoMoneda;
            solicitudPrestamoHipotecarioNavalDTO.FechaSolicitud = FechaSolicitud;
            solicitudPrestamoHipotecarioNavalDTO.AprobacionSolicitud = AprobacionSolicitud;
            solicitudPrestamoHipotecarioNavalDTO.FechaAprobacion = FechaAprobacion;
            solicitudPrestamoHipotecarioNavalDTO.FechaDesembolso = FechaDesembolso;
            solicitudPrestamoHipotecarioNavalDTO.NroCuota = NroCuota;
            solicitudPrestamoHipotecarioNavalDTO.CodigoModalidadPrestamo = CodigoModalidadPrestamo;
            solicitudPrestamoHipotecarioNavalDTO.CodigoFinalidadPrestamo = CodigoFinalidadPrestamo;
            solicitudPrestamoHipotecarioNavalDTO.CodigoEntidadFinanciera = CodigoEntidadFinanciera;
            solicitudPrestamoHipotecarioNavalDTO.RentabilidadFinanciera = RentabilidadFinanciera;
            solicitudPrestamoHipotecarioNavalDTO.CodigoProyectoFovimar = CodigoProyectoFovimar;
            solicitudPrestamoHipotecarioNavalDTO.EstadoSolicitudPrestamo = EstadoSolicitudPrestamo;
            solicitudPrestamoHipotecarioNavalDTO.GarantiaConstituida = GarantiaConstituida;
            solicitudPrestamoHipotecarioNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = solicitudPrestamoHipotecarioNavalBL.ActualizarFormato(solicitudPrestamoHipotecarioNavalDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            SolicitudPrestamoHipotecarioNavalDTO solicitudPrestamoHipotecarioNavalDTO = new();
            solicitudPrestamoHipotecarioNavalDTO.SolicitudPrestamoHipotecarioNavalId = Id;
            solicitudPrestamoHipotecarioNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (solicitudPrestamoHipotecarioNavalBL.EliminarFormato(solicitudPrestamoHipotecarioNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            SolicitudPrestamoHipotecarioNavalDTO solicitudPrestamoHipotecarioNavalDTO = new();
            solicitudPrestamoHipotecarioNavalDTO.CargaId = Id;
            solicitudPrestamoHipotecarioNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (solicitudPrestamoHipotecarioNavalBL.EliminarCarga(solicitudPrestamoHipotecarioNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<SolicitudPrestamoHipotecarioNavalDTO> lista = new List<SolicitudPrestamoHipotecarioNavalDTO>();
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

                    lista.Add(new SolicitudPrestamoHipotecarioNavalDTO
                    {
                        DNIPersonalNaval = fila.GetCell(0).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(1).ToString(),
                        CodigoSituacionPersonalNaval = fila.GetCell(2).ToString(),
                        Prestario = fila.GetCell(3).ToString(),
                        MontoSolicitado = decimal.Parse(fila.GetCell(4).ToString()),
                        CodigoMoneda = fila.GetCell(5).ToString(),
                        FechaSolicitud = fila.GetCell(6).ToString(),
                        AprobacionSolicitud = fila.GetCell(7).ToString(),
                        FechaAprobacion = fila.GetCell(8).ToString(),
                        FechaDesembolso = fila.GetCell(9).ToString(),
                        NroCuota = int.Parse(fila.GetCell(10).ToString()),
                        CodigoModalidadPrestamo = fila.GetCell(11).ToString(),
                        CodigoFinalidadPrestamo = fila.GetCell(12).ToString(),
                        CodigoEntidadFinanciera = fila.GetCell(13).ToString(),
                        RentabilidadFinanciera = decimal.Parse(fila.GetCell(14).ToString()),
                        CodigoProyectoFovimar = fila.GetCell(15).ToString(),
                        EstadoSolicitudPrestamo = fila.GetCell(16).ToString(),
                        GarantiaConstituida = fila.GetCell(17).ToString()
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

            dt.Columns.AddRange(new DataColumn[19]
            {
                    new DataColumn("DNIPersonalNaval", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoSituacionPersonalNaval", typeof(string)),
                    new DataColumn("Prestario", typeof(string)),
                    new DataColumn("MontoSolicitado", typeof(decimal)),
                    new DataColumn("CodigoMoneda", typeof(string)),
                    new DataColumn("FechaSolicitud", typeof(string)),
                    new DataColumn("AprobacionSolicitud", typeof(string)),
                    new DataColumn("FechaAprobacion", typeof(string)),
                    new DataColumn("FechaDesembolso", typeof(string)),
                    new DataColumn("NroCuota", typeof(int)),
                    new DataColumn("CodigoModalidadPrestamo", typeof(string)),
                    new DataColumn("CodigoFinalidadPrestamo", typeof(string)),
                    new DataColumn("CodigoEntidadFinanciera", typeof(string)),
                    new DataColumn("RentabilidadFinanciera", typeof(decimal)),
                    new DataColumn("CodigoProyectoFovimar", typeof(string)),
                    new DataColumn("EstadoSolicitudPrestamo", typeof(string)),
                    new DataColumn("GarantiaConstituida", typeof(string)),
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
                    decimal.Parse(fila.GetCell(4).ToString()),
                    fila.GetCell(5).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                    fila.GetCell(7).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(8).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(9).ToString()),
                    int.Parse(fila.GetCell(10).ToString()),
                    fila.GetCell(11).ToString(),
                    fila.GetCell(12).ToString(),
                    fila.GetCell(13).ToString(),
                    decimal.Parse(fila.GetCell(14).ToString()),
                    fila.GetCell(15).ToString(),
                    fila.GetCell(16).ToString(),
                    fila.GetCell(17).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = solicitudPrestamoHipotecarioNavalBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DifovimarSolicitudPrestamoHipotecarioNaval.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DifovimarSolicitudPrestamoHipotecarioNaval.xlsx");
        }
    }

}