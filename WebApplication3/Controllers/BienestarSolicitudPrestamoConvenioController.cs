using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Bienestar;
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

    public class BienestarSolicitudPrestamoConvenioController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        SolicitudPrestamoConvenio solicitudPrestamoConvenioBL = new();
        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EntidadFinanciera entidadFinancieraBL = new();
        TipoPrestamoConvenio tipoPrestamoConvenioBL = new();
        Carga cargaBL = new();

        public BienestarSolicitudPrestamoConvenioController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Solicitud de Préstamos por Convenio con Entidades Financieras del Personal Naval", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<EntidadFinancieraDTO> entidadFinancieraDTO = entidadFinancieraBL.ObtenerEntidadFinancieras();
            List<TipoPrestamoConvenioDTO> tipoPrestamoConvenioDTO = tipoPrestamoConvenioBL.ObtenerTipoPrestamoConvenios();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("SolicitudPrestamoConvenio");

            return Json(new { data1 = tipoPersonalMilitarDTO, 
                data2 = gradoPersonalMilitarDTO,
                data3 = entidadFinancieraDTO, 
                data4 = tipoPrestamoConvenioDTO,
                data5 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<SolicitudPrestamoConvenioDTO> select = solicitudPrestamoConvenioBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
           
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string FechaSolicitud, string DNIBeneficiario, string CIPBeneficiario, string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar,
            int AnioServicio, string ResultadoSolicitud, string CodigoTipoPrestamoConvenio, string CodigoEntidadFinanciera, decimal TasaInteresPrestamo,
            decimal ImporteCreditoSoles, int NumeroCuotas, int CargaId, string Fecha)
        {
            SolicitudPrestamoConvenioDTO solicitudPrestamoConvenioDTO = new();
            solicitudPrestamoConvenioDTO.FechaSolicitud = FechaSolicitud;
            solicitudPrestamoConvenioDTO.DNIBeneficiario = DNIBeneficiario;
            solicitudPrestamoConvenioDTO.CIPBeneficiario = CIPBeneficiario;
            solicitudPrestamoConvenioDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            solicitudPrestamoConvenioDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            solicitudPrestamoConvenioDTO.AnioServicio = AnioServicio;
            solicitudPrestamoConvenioDTO.ResultadoSolicitud = ResultadoSolicitud;
            solicitudPrestamoConvenioDTO.CodigoEntidadFinanciera = CodigoEntidadFinanciera;
            solicitudPrestamoConvenioDTO.CodigoTipoPrestamoConvenio = CodigoTipoPrestamoConvenio;
            solicitudPrestamoConvenioDTO.TasaInteresPrestamo = TasaInteresPrestamo;
            solicitudPrestamoConvenioDTO.ImporteCreditoSoles = ImporteCreditoSoles;
            solicitudPrestamoConvenioDTO.NumeroCuotas = NumeroCuotas;
            solicitudPrestamoConvenioDTO.CargaId = CargaId;
            solicitudPrestamoConvenioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = solicitudPrestamoConvenioBL.AgregarRegistro(solicitudPrestamoConvenioDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(solicitudPrestamoConvenioBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string FechaSolicitud, string DNIBeneficiario, string CIPBeneficiario, string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar,
            int AnioServicio, string ResultadoSolicitud, string CodigoTipoPrestamoConvenio, string CodigoEntidadFinanciera, decimal TasaInteresPrestamo,
            decimal ImporteCreditoSoles, int NumeroCuotas)
        {
            SolicitudPrestamoConvenioDTO solicitudPrestamoConvenioDTO = new();
            solicitudPrestamoConvenioDTO.SolicitudPrestamoConvenioId = Id;
            solicitudPrestamoConvenioDTO.FechaSolicitud = FechaSolicitud;
            solicitudPrestamoConvenioDTO.DNIBeneficiario = DNIBeneficiario;
            solicitudPrestamoConvenioDTO.CIPBeneficiario = CIPBeneficiario;
            solicitudPrestamoConvenioDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            solicitudPrestamoConvenioDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            solicitudPrestamoConvenioDTO.AnioServicio = AnioServicio;
            solicitudPrestamoConvenioDTO.ResultadoSolicitud = ResultadoSolicitud;
            solicitudPrestamoConvenioDTO.CodigoEntidadFinanciera = CodigoEntidadFinanciera;
            solicitudPrestamoConvenioDTO.CodigoTipoPrestamoConvenio = CodigoTipoPrestamoConvenio;
            solicitudPrestamoConvenioDTO.TasaInteresPrestamo = TasaInteresPrestamo;
            solicitudPrestamoConvenioDTO.ImporteCreditoSoles = ImporteCreditoSoles;
            solicitudPrestamoConvenioDTO.NumeroCuotas = NumeroCuotas;
            solicitudPrestamoConvenioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = solicitudPrestamoConvenioBL.ActualizarFormato(solicitudPrestamoConvenioDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            SolicitudPrestamoConvenioDTO solicitudPrestamoConvenioDTO = new();
            solicitudPrestamoConvenioDTO.SolicitudPrestamoConvenioId = Id;
            solicitudPrestamoConvenioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (solicitudPrestamoConvenioBL.EliminarFormato(solicitudPrestamoConvenioDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            SolicitudPrestamoConvenioDTO solicitudPrestamoConvenioDTO = new();
            solicitudPrestamoConvenioDTO.CargaId = Id;
            solicitudPrestamoConvenioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (solicitudPrestamoConvenioBL.EliminarCarga(solicitudPrestamoConvenioDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<SolicitudPrestamoConvenioDTO> lista = new List<SolicitudPrestamoConvenioDTO>();
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

                    lista.Add(new SolicitudPrestamoConvenioDTO
                    {
                        FechaSolicitud = fila.GetCell(0).ToString(),
                        DNIBeneficiario = fila.GetCell(1).ToString(),
                        CIPBeneficiario = fila.GetCell(2).ToString(),
                        CodigoTipoPersonalMilitar = fila.GetCell(3).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(4).ToString(),
                        AnioServicio = int.Parse(fila.GetCell(5).ToString()),
                        ResultadoSolicitud = fila.GetCell(6).ToString(),
                        CodigoEntidadFinanciera = fila.GetCell(7).ToString(),
                        CodigoTipoPrestamoConvenio = fila.GetCell(8).ToString(),
                        TasaInteresPrestamo = decimal.Parse(fila.GetCell(9).ToString()),
                        ImporteCreditoSoles = decimal.Parse(fila.GetCell(10).ToString()),
                        NumeroCuotas = int.Parse(fila.GetCell(11).ToString())
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
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string fecha)
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

            dt.Columns.AddRange(new DataColumn[13]
            {
                    new DataColumn("FechaSolicitud", typeof(string)),
                    new DataColumn("DNIBeneficiario", typeof(string)),
                    new DataColumn("CIPBeneficiario", typeof(string)),
                    new DataColumn("CodigoTipoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("AnioServicio", typeof(int)),
                    new DataColumn("ResultadoSolicitud", typeof(string)),
                    new DataColumn("CodigoEntidadFinanciera", typeof(string)),
                    new DataColumn("CodigoTipoPrestamoConvenio", typeof(string)),
                    new DataColumn("TasaInteresPrestamo", typeof(decimal)),
                    new DataColumn("ImporteCreditoSoles", typeof(decimal)),
                    new DataColumn("NumeroCuotas", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    int.Parse(fila.GetCell(5).ToString()),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    decimal.Parse(fila.GetCell(9).ToString()),
                    decimal.Parse(fila.GetCell(10).ToString()),
                    int.Parse(fila.GetCell(11).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = solicitudPrestamoConvenioBL.InsertarDatos(dt, fecha);
            return Content(IND_OPERACION);
        }

        //public IActionResult ReporteBSPC(int? idCarga=null, string? fechaInicio=null, string? fechafin=null)
        //{
        //    string mimtype = "";
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Bienestar\\SolicitudPrestamoConsumo.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    var solicitudPrestamoConvenios = solicitudPrestamoConvenioBL.BienestarVisualizacionSolicitudPrestamoConsumo(idCarga, fechaInicio, fechafin);
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("SolicitudPrestamoConsumo", solicitudPrestamoConvenios);
        //    var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\BienestarSolicitudPrestamoConvenio.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "BienestarSolicitudPrestamoConvenio.xlsx");
        }

    }

}

