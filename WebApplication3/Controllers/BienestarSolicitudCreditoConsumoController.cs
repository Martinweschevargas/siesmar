using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
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
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class BienestarSolicitudCreditoConsumoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;        
        SolicitudCreditoConsumo solicitudCreditoConsumoBL = new();
        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EntidadFinanciera entidadFinancieraBL = new();
        Carga cargaBL = new();

        public BienestarSolicitudCreditoConsumoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Solicitud de Créditos por Consumo", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<EntidadFinancieraDTO> entidadFinancieraDTO = entidadFinancieraBL.ObtenerEntidadFinancieras();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("SolicitudCreditoConsumo");
            return Json(new { data1 = tipoPersonalMilitarDTO, data2 = gradoPersonalMilitarDTO, data3 = entidadFinancieraDTO, data4 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<SolicitudCreditoConsumoDTO> select = solicitudCreditoConsumoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string FechaSolicitudCredito, string DNISolicitante, string CIPSolicitante, string CodigoTipoPersonalMilitar,
            string CodigoGradoPersonalMilitar, int AnioServicio, string ResultadoSolicitud, string CodigoEntidadFinanciera, int NumeroCuotas, decimal ImporteCredito,
            decimal TasaInteresCredito, int CargaId, string Fecha)
        {
            SolicitudCreditoConsumoDTO solicitudCreditoConsumoDTO = new();
            solicitudCreditoConsumoDTO.FechaSolicitudCredito = FechaSolicitudCredito;
            solicitudCreditoConsumoDTO.DNISolicitante = DNISolicitante;
            solicitudCreditoConsumoDTO.CIPSolicitante = CIPSolicitante;
            solicitudCreditoConsumoDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            solicitudCreditoConsumoDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            solicitudCreditoConsumoDTO.AnioServicio = AnioServicio;
            solicitudCreditoConsumoDTO.ResultadoSolicitud = ResultadoSolicitud;
            solicitudCreditoConsumoDTO.CodigoEntidadFinanciera = CodigoEntidadFinanciera;
            solicitudCreditoConsumoDTO.NumeroCuotas = NumeroCuotas;
            solicitudCreditoConsumoDTO.ImporteCredito = ImporteCredito;
            solicitudCreditoConsumoDTO.TasaInteresCredito = TasaInteresCredito;
            solicitudCreditoConsumoDTO.CargaId = CargaId;
            solicitudCreditoConsumoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = solicitudCreditoConsumoBL.AgregarRegistro(solicitudCreditoConsumoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(solicitudCreditoConsumoBL.EditarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaSolicitudCredito, string DNISolicitante, string CIPSolicitante, string CodigoTipoPersonalMilitar,
            string CodigoGradoPersonalMilitar, int AnioServicio, string ResultadoSolicitud, string CodigoEntidadFinanciera, int NumeroCuotas, decimal ImporteCredito,
            decimal TasaInteresCredito)
        {
            SolicitudCreditoConsumoDTO solicitudCreditoConsumoDTO = new();
            solicitudCreditoConsumoDTO.SolicitudCreditoConsumoId = Id;
            solicitudCreditoConsumoDTO.FechaSolicitudCredito = FechaSolicitudCredito;
            solicitudCreditoConsumoDTO.DNISolicitante = DNISolicitante;
            solicitudCreditoConsumoDTO.CIPSolicitante = CIPSolicitante;
            solicitudCreditoConsumoDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            solicitudCreditoConsumoDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            solicitudCreditoConsumoDTO.AnioServicio = AnioServicio;
            solicitudCreditoConsumoDTO.ResultadoSolicitud = ResultadoSolicitud;
            solicitudCreditoConsumoDTO.CodigoEntidadFinanciera = CodigoEntidadFinanciera;
            solicitudCreditoConsumoDTO.NumeroCuotas = NumeroCuotas;
            solicitudCreditoConsumoDTO.ImporteCredito = ImporteCredito;
            solicitudCreditoConsumoDTO.TasaInteresCredito = TasaInteresCredito;
            solicitudCreditoConsumoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = solicitudCreditoConsumoBL.ActualizarFormato(solicitudCreditoConsumoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            SolicitudCreditoConsumoDTO solicitudCreditoConsumoDTO = new();
            solicitudCreditoConsumoDTO.SolicitudCreditoConsumoId = Id;
            solicitudCreditoConsumoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (solicitudCreditoConsumoBL.EliminarFormato(solicitudCreditoConsumoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            SolicitudCreditoConsumoDTO solicitudCreditoConsumoDTO = new();
            solicitudCreditoConsumoDTO.CargaId = Id;
            solicitudCreditoConsumoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (solicitudCreditoConsumoBL.EliminarCarga(solicitudCreditoConsumoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<SolicitudCreditoConsumoDTO> lista = new List<SolicitudCreditoConsumoDTO>();
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

                    lista.Add(new SolicitudCreditoConsumoDTO
                    {
                        FechaSolicitudCredito = fila.GetCell(0).ToString(),
                        DNISolicitante = fila.GetCell(1).ToString(),
                        CIPSolicitante = fila.GetCell(2).ToString(),
                        CodigoTipoPersonalMilitar = fila.GetCell(3).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(4).ToString(),
                        AnioServicio = int.Parse(fila.GetCell(5).ToString()),
                        ResultadoSolicitud = fila.GetCell(6).ToString(),
                        CodigoEntidadFinanciera = fila.GetCell(7).ToString(),
                        NumeroCuotas = int.Parse(fila.GetCell(8).ToString()),
                        ImporteCredito = decimal.Parse(fila.GetCell(9).ToString()),
                        TasaInteresCredito = decimal.Parse(fila.GetCell(10).ToString())
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

            dt.Columns.AddRange(new DataColumn[12]
            {
                    new DataColumn("FechaSolicitudCredito", typeof(string)),
                    new DataColumn("DNISolicitante", typeof(string)),
                    new DataColumn("CIPSolicitante", typeof(string)),
                    new DataColumn("CodigoTipoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("AnioServicio", typeof(int)),
                    new DataColumn("ResultadoSolicitud", typeof(string)),
                    new DataColumn("CodigoEntidadFinanciera", typeof(string)),
                    new DataColumn("NumeroCuotas", typeof(int)),
                    new DataColumn("ImporteCredito", typeof(decimal)),
                    new DataColumn("TasaInteresCredito", typeof(decimal)),
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
                     int.Parse(fila.GetCell(8).ToString()),
                     decimal.Parse(fila.GetCell(9).ToString()),
                     decimal.Parse(fila.GetCell(10).ToString()),
                     User.obtenerUsuario());
            }
            var IND_OPERACION = solicitudCreditoConsumoBL.InsertarDatos(dt, fecha);
            return Content(IND_OPERACION);
        }

        //public IActionResult ReporteBSCC(int? idCarga=null, string? fechaInicio=null, string? fechaFin=null)
        //{
        //    string mimtype = "";
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Bienestar\\SolicitudCreditoConsumo.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    var solicitudCreditoConsumos = solicitudCreditoConsumoBL.BienestarVisualizacionSolicitudCreditoConsumo(idCarga, fechaInicio, fechaFin);
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("SolicitudCreditoConsumo", solicitudCreditoConsumos);
        //    var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\BienestarSolicitudCreditoConsumo.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "BienestarSolicitudCreditoConsumo.xlsx");
        }

    }

}

