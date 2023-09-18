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

    public class DimarEmisionNotaPrensaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EmisionNotaPrensa emisionNotaPrensaBL = new();
        TipoInformacionEmitida tipoInformacionEmitidaBL = new();
        PlataformaMedioComunicacion plataformaMedioComunicacionBL = new();
        PublicoObjetivo publicoObjetivoBL = new();
        Carga cargaBL = new();

        public DimarEmisionNotaPrensaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Emisión de notas de prensa", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoInformacionEmitidaDTO> tipoInformacionEmitidaDTO = tipoInformacionEmitidaBL.ObtenerTipoInformacionEmitidas();
            List<PlataformaMedioComunicacionDTO> plataformaMedioComunicacionDTO = plataformaMedioComunicacionBL.ObtenerPlataformaMedioComunicacions();
            List<PublicoObjetivoDTO> publicoObjetivoDTO = publicoObjetivoBL.ObtenerPublicoObjetivos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EmisionNotaPrensa");

            return Json(new
            {
                data1 = tipoInformacionEmitidaDTO,
                data2 = plataformaMedioComunicacionDTO,
                data3 = publicoObjetivoDTO,
                data4 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<EmisionNotaPrensaDTO> select = emisionNotaPrensaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string FechaEmision, int NumeroNotasProducidas, string CodigoTipoInformacionEmitida,
            string CodigoPlataformaMedioComunicacion, string CodigoPublicoObjetivo, int CargaId)
        {
            EmisionNotaPrensaDTO emisionNotaPrensaDTO = new();
            emisionNotaPrensaDTO.FechaEmision = FechaEmision;
            emisionNotaPrensaDTO.NumeroNotasProducidas = NumeroNotasProducidas;
            emisionNotaPrensaDTO.CodigoTipoInformacionEmitida = CodigoTipoInformacionEmitida;
            emisionNotaPrensaDTO.CodigoPlataformaMedioComunicacion = CodigoPlataformaMedioComunicacion;
            emisionNotaPrensaDTO.CodigoPublicoObjetivo = CodigoPublicoObjetivo;
            emisionNotaPrensaDTO.CargaId = CargaId;
            emisionNotaPrensaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = emisionNotaPrensaBL.AgregarRegistro(emisionNotaPrensaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(emisionNotaPrensaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaEmision, int NumeroNotasProducidas, string CodigoTipoInformacionEmitida,
            string CodigoPlataformaMedioComunicacion, string CodigoPublicoObjetivo)
        {
            EmisionNotaPrensaDTO emisionNotaPrensaDTO = new();
            emisionNotaPrensaDTO.EmisionNotaPrensaId = Id;
            emisionNotaPrensaDTO.FechaEmision = FechaEmision;
            emisionNotaPrensaDTO.NumeroNotasProducidas = NumeroNotasProducidas;
            emisionNotaPrensaDTO.CodigoTipoInformacionEmitida = CodigoTipoInformacionEmitida;
            emisionNotaPrensaDTO.CodigoPlataformaMedioComunicacion = CodigoPlataformaMedioComunicacion;
            emisionNotaPrensaDTO.CodigoPublicoObjetivo = CodigoPublicoObjetivo;

            emisionNotaPrensaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = emisionNotaPrensaBL.ActualizarFormato(emisionNotaPrensaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EmisionNotaPrensaDTO emisionNotaPrensaDTO = new();
            emisionNotaPrensaDTO.EmisionNotaPrensaId = Id;
            emisionNotaPrensaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (emisionNotaPrensaBL.EliminarFormato(emisionNotaPrensaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EmisionNotaPrensaDTO> lista = new List<EmisionNotaPrensaDTO>();
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

                    lista.Add(new EmisionNotaPrensaDTO
                    {
                        FechaEmision = fila.GetCell(0).ToString(),
                        NumeroNotasProducidas = int.Parse(fila.GetCell(1).ToString()),
                        CodigoTipoInformacionEmitida = fila.GetCell(2).ToString(),
                        CodigoPlataformaMedioComunicacion = fila.GetCell(3).ToString(),
                        CodigoPublicoObjetivo = fila.GetCell(4).ToString(),

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
                    new DataColumn("FechaEmision ", typeof(string)),
                    new DataColumn("NumeroNotasProducidas ", typeof(int)),
                    new DataColumn("CodigoTipoInformacionEmitida ", typeof(string)),
                    new DataColumn("CodigoPlataformaMedioComunicacion ", typeof(string)),
                    new DataColumn("CodigoPublicoObjetivo  ", typeof(string)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(

                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    int.Parse(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = emisionNotaPrensaBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDENP(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dimar\\EmisionNotaPrensa.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = emisionNotaPrensaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EmisionNotaPrensa", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\EmisionNotaPrensa.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "EmisionNotaPrensa.xlsx");
        }
    }

}
