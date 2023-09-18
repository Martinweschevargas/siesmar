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

    public class DimarConsolidadoComisionCeremoniaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        ConsolidadoComisionCeremonia consolidadoComisionCeremoniaBL = new();
        UnidadMedida unidadMedidaBL = new();
        PublicoObjetivo publicoObjetivoBL = new();
        Carga cargaBL = new();

        public DimarConsolidadoComisionCeremoniaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Comisiones de audiovisuales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<UnidadMedidaDTO> unidadMedidaDTO = unidadMedidaBL.ObtenerUnidadMedidas();
            List<PublicoObjetivoDTO> publicoObjetivoDTO = publicoObjetivoBL.ObtenerPublicoObjetivos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ConsolidadoComisionCeremonia");

            return Json(new
            {
                data1 = unidadMedidaDTO,
                data2 = publicoObjetivoDTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ConsolidadoComisionCeremoniaDTO> select = consolidadoComisionCeremoniaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Consolidados de comisiones a ceremonias navales institucionales y extrainstitucionales")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string FechaActividad, string Actividad, string CodigoUnidadMedida, string CodigoPublicoObjetivo, 
            decimal Costo, int CargaId)
        {
            ConsolidadoComisionCeremoniaDTO consolidadoComisionCeremoniaDTO = new();
            consolidadoComisionCeremoniaDTO.FechaActividad = FechaActividad;
            consolidadoComisionCeremoniaDTO.Actividad = Actividad;
            consolidadoComisionCeremoniaDTO.CodigoUnidadMedida = CodigoUnidadMedida;
            consolidadoComisionCeremoniaDTO.CodigoPublicoObjetivo = CodigoPublicoObjetivo;
            consolidadoComisionCeremoniaDTO.Costo = Costo;
            consolidadoComisionCeremoniaDTO.CargaId = CargaId;
            consolidadoComisionCeremoniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = consolidadoComisionCeremoniaBL.AgregarRegistro(consolidadoComisionCeremoniaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(consolidadoComisionCeremoniaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaActividad, string Actividad, string CodigoUnidadMedida, string CodigoPublicoObjetivo,
            decimal Costo)
        {
            ConsolidadoComisionCeremoniaDTO consolidadoComisionCeremoniaDTO = new();
            consolidadoComisionCeremoniaDTO.ConsolidadoComisionCeremoniaId = Id;
            consolidadoComisionCeremoniaDTO.FechaActividad = FechaActividad;
            consolidadoComisionCeremoniaDTO.Actividad = Actividad;
            consolidadoComisionCeremoniaDTO.CodigoUnidadMedida = CodigoUnidadMedida;
            consolidadoComisionCeremoniaDTO.CodigoPublicoObjetivo = CodigoPublicoObjetivo;
            consolidadoComisionCeremoniaDTO.Costo = Costo;

            consolidadoComisionCeremoniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = consolidadoComisionCeremoniaBL.ActualizarFormato(consolidadoComisionCeremoniaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ConsolidadoComisionCeremoniaDTO consolidadoComisionCeremoniaDTO = new();
            consolidadoComisionCeremoniaDTO.ConsolidadoComisionCeremoniaId = Id;
            consolidadoComisionCeremoniaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (consolidadoComisionCeremoniaBL.EliminarFormato(consolidadoComisionCeremoniaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ConsolidadoComisionCeremoniaDTO> lista = new List<ConsolidadoComisionCeremoniaDTO>();
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

                    lista.Add(new ConsolidadoComisionCeremoniaDTO
                    {
                        FechaActividad = fila.GetCell(0).ToString(),
                        Actividad = fila.GetCell(1).ToString(),
                        CodigoUnidadMedida = fila.GetCell(2).ToString(),
                        CodigoPublicoObjetivo = fila.GetCell(3).ToString(),
                        Costo = decimal.Parse(fila.GetCell(4).ToString()),

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

            dt.Columns.AddRange(new DataColumn[6]
            {
                    new DataColumn("FechaActividad ", typeof(string)),
                    new DataColumn("Actividad ", typeof(string)),
                    new DataColumn("CodigoUnidadMedida ", typeof(string)),
                    new DataColumn("CodigoPublicoObjetivo ", typeof(string)),
                    new DataColumn("Costo", typeof(decimal)),

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
                    decimal.Parse(fila.GetCell(4).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = consolidadoComisionCeremoniaBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDCCC(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dimar\\ConsolidadoComisionCeremonia.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = consolidadoComisionCeremoniaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ConsolidadoComisionCeremonia", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ConsolidadoComisionCeremonia.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ConsolidadoComisionCeremonia.xlsx");
        }
    }

}