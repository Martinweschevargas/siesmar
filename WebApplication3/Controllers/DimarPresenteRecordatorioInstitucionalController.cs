using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dimar;
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

    public class DimarPresenteRecordatorioInstitucionalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        PresenteRecordatorioInstitucional presenteRecordatorioInstitucionalBL = new();
        TipoPresenteProtocolar tipoPresenteProtocolarBL = new();
        UnidadMedida unidadMedidaBL = new();
        FrecuenciaDifusion frecuenciaDifusionBL = new();
        PublicoObjetivo publicoObjetivoBL = new();
        Carga cargaBL = new();

        public DimarPresenteRecordatorioInstitucionalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Presentes recordatorios institucionales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoPresenteProtocolarDTO> tipoPresenteProtocolarDTO = tipoPresenteProtocolarBL.ObtenerTipoPresenteProtocolars();
            List<UnidadMedidaDTO> unidadMedidaDTO = unidadMedidaBL.ObtenerUnidadMedidas();
            List<FrecuenciaDifusionDTO> frecuenciaDifusionDTO = frecuenciaDifusionBL.ObtenerFrecuenciaDifusions();
            List<PublicoObjetivoDTO> publicoObjetivoDTO = publicoObjetivoBL.ObtenerPublicoObjetivos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PresenteRecordatorioInstitucional");

            return Json(new
            {
                data1 = tipoPresenteProtocolarDTO,
                data2 = unidadMedidaDTO,
                data3 = frecuenciaDifusionDTO,
                data4 = publicoObjetivoDTO,
                data5 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<PresenteRecordatorioInstitucionalDTO> select = presenteRecordatorioInstitucionalBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string FechaAdquisicion, string CodigoTipoPresenteProtocolar, int Cantidad, string CodigoUnidadMedida, 
            decimal CostoUnitario, string CodigoFrecuenciaDifusion, string CodigoPublicoObjetivo,int CargaId)
        {
            PresenteRecordatorioInstitucionalDTO presenteRecordatorioInstitucionalDTO = new();
            presenteRecordatorioInstitucionalDTO.FechaAdquisicion = FechaAdquisicion;
            presenteRecordatorioInstitucionalDTO.CodigoTipoPresenteProtocolar = CodigoTipoPresenteProtocolar;
            presenteRecordatorioInstitucionalDTO.Cantidad = Cantidad;
            presenteRecordatorioInstitucionalDTO.CodigoUnidadMedida = CodigoUnidadMedida;
            presenteRecordatorioInstitucionalDTO.CostoUnitario = CostoUnitario;
            presenteRecordatorioInstitucionalDTO.CodigoFrecuenciaDifusion = CodigoFrecuenciaDifusion;
            presenteRecordatorioInstitucionalDTO.CodigoPublicoObjetivo = CodigoPublicoObjetivo;
            presenteRecordatorioInstitucionalDTO.CargaId = CargaId;

            presenteRecordatorioInstitucionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = presenteRecordatorioInstitucionalBL.AgregarRegistro(presenteRecordatorioInstitucionalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(presenteRecordatorioInstitucionalBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaAdquisicion, string CodigoTipoPresenteProtocolar, int Cantidad, string CodigoUnidadMedida,
            decimal CostoUnitario, string CodigoFrecuenciaDifusion, string CodigoPublicoObjetivo)
        {
            PresenteRecordatorioInstitucionalDTO presenteRecordatorioInstitucionalDTO = new();
            presenteRecordatorioInstitucionalDTO.PresenteRecordatorioInstitucionalId = Id;
            presenteRecordatorioInstitucionalDTO.FechaAdquisicion = FechaAdquisicion;
            presenteRecordatorioInstitucionalDTO.CodigoTipoPresenteProtocolar = CodigoTipoPresenteProtocolar;
            presenteRecordatorioInstitucionalDTO.Cantidad = Cantidad;
            presenteRecordatorioInstitucionalDTO.CodigoUnidadMedida = CodigoUnidadMedida;
            presenteRecordatorioInstitucionalDTO.CostoUnitario = CostoUnitario;
            presenteRecordatorioInstitucionalDTO.CodigoFrecuenciaDifusion = CodigoFrecuenciaDifusion;
            presenteRecordatorioInstitucionalDTO.CodigoPublicoObjetivo = CodigoPublicoObjetivo;

            presenteRecordatorioInstitucionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = presenteRecordatorioInstitucionalBL.ActualizarFormato(presenteRecordatorioInstitucionalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PresenteRecordatorioInstitucionalDTO presenteRecordatorioInstitucionalDTO = new();
            presenteRecordatorioInstitucionalDTO.PresenteRecordatorioInstitucionalId = Id;
            presenteRecordatorioInstitucionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (presenteRecordatorioInstitucionalBL.EliminarFormato(presenteRecordatorioInstitucionalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<PresenteRecordatorioInstitucionalDTO> lista = new List<PresenteRecordatorioInstitucionalDTO>();
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

                    lista.Add(new PresenteRecordatorioInstitucionalDTO
                    {
                        FechaAdquisicion = fila.GetCell(0).ToString(),
                        CodigoTipoPresenteProtocolar = fila.GetCell(1).ToString(),
                        Cantidad = int.Parse(fila.GetCell(2).ToString()),
                        CodigoUnidadMedida = fila.GetCell(3).ToString(),
                        CostoUnitario = decimal.Parse(fila.GetCell(4).ToString()),
                        CodigoFrecuenciaDifusion = fila.GetCell(5).ToString(),
                        CodigoPublicoObjetivo = fila.GetCell(6).ToString(),

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
                    new DataColumn("FechaAdquisicion ", typeof(string)),
                    new DataColumn("CodigoTipoPresenteProtocolar ", typeof(string)),
                    new DataColumn("Cantidad", typeof(int)),
                    new DataColumn("CodigoUnidadMedida", typeof(string)),
                    new DataColumn("CostoUnitario ", typeof(decimal)),
                    new DataColumn("CodigoFrecuenciaDifusion ", typeof(string)),
                    new DataColumn("CodigoPublicoObjetivo", typeof(string)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(

                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    int.Parse(fila.GetCell(2).ToString()),
                    fila.GetCell(3).ToString(),
                    decimal.Parse(fila.GetCell(4).ToString()),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = presenteRecordatorioInstitucionalBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDPRI(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dimar\\PresenteRecordatorioInstitucional.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = presenteRecordatorioInstitucionalBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("PresenteRecordatorioInstitucional", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\PresenteRecordatorioInstitucional.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "PresenteRecordatorioInstitucional.xlsx");
        }
    }

}
