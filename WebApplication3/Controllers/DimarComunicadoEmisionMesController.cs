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

    public class DimarComunicadoEmisionMesController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        ComunicadoEmisionMes comunicadoEmisionMesBL = new();
        TipoInformacionEmitida tipoInformacionEmitidaBL = new();
        PublicoObjetivo publicoObjetivoBL = new();
        Carga cargaBL = new();

        public DimarComunicadoEmisionMesController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Comunicados (N.º de emisión de comunicados por mes)", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoInformacionEmitidaDTO> tipoInformacionEmitidaDTO = tipoInformacionEmitidaBL.ObtenerTipoInformacionEmitidas();
            List<PublicoObjetivoDTO> publicoObjetivoDTO = publicoObjetivoBL.ObtenerPublicoObjetivos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ComunicadoEmisionMes");

            return Json(new
            {
                data1 = tipoInformacionEmitidaDTO,
                data2 = publicoObjetivoDTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ComunicadoEmisionMesDTO> select = comunicadoEmisionMesBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string FechaEmisionComunicado, int NumeroComunicados, string CodigoTipoInformacionEmitida,
            string CodigoPublicoObjetivo, int CargaId)
        {
            ComunicadoEmisionMesDTO comunicadoEmisionMesDTO = new();
            comunicadoEmisionMesDTO.FechaEmisionComunicado = FechaEmisionComunicado;
            comunicadoEmisionMesDTO.NumeroComunicados = NumeroComunicados;
            comunicadoEmisionMesDTO.CodigoTipoInformacionEmitida = CodigoTipoInformacionEmitida;
            comunicadoEmisionMesDTO.CodigoPublicoObjetivo = CodigoPublicoObjetivo;
            comunicadoEmisionMesDTO.CargaId = CargaId;
            comunicadoEmisionMesDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = comunicadoEmisionMesBL.AgregarRegistro(comunicadoEmisionMesDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(comunicadoEmisionMesBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaEmisionComunicado, int NumeroComunicados, string CodigoTipoInformacionEmitida,
            string CodigoPublicoObjetivo)
        {
            ComunicadoEmisionMesDTO comunicadoEmisionMesDTO = new();
            comunicadoEmisionMesDTO.ComunicadoEmisionMesId = Id;
            comunicadoEmisionMesDTO.FechaEmisionComunicado = FechaEmisionComunicado;
            comunicadoEmisionMesDTO.NumeroComunicados = NumeroComunicados;
            comunicadoEmisionMesDTO.CodigoTipoInformacionEmitida = CodigoTipoInformacionEmitida;
            comunicadoEmisionMesDTO.CodigoPublicoObjetivo = CodigoPublicoObjetivo;

            comunicadoEmisionMesDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = comunicadoEmisionMesBL.ActualizarFormato(comunicadoEmisionMesDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ComunicadoEmisionMesDTO comunicadoEmisionMesDTO = new();
            comunicadoEmisionMesDTO.ComunicadoEmisionMesId = Id;
            comunicadoEmisionMesDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (comunicadoEmisionMesBL.EliminarFormato(comunicadoEmisionMesDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ComunicadoEmisionMesDTO> lista = new List<ComunicadoEmisionMesDTO>();
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

                    lista.Add(new ComunicadoEmisionMesDTO
                    {
                        FechaEmisionComunicado = fila.GetCell(0).ToString(),
                        NumeroComunicados = int.Parse(fila.GetCell(1).ToString()),
                        CodigoTipoInformacionEmitida = fila.GetCell(2).ToString(),
                        CodigoPublicoObjetivo = fila.GetCell(3).ToString(),
               

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

            dt.Columns.AddRange(new DataColumn[5]
            {
                    new DataColumn("FechaEmisionComunicado ", typeof(string)),
                    new DataColumn("NumeroComunicados ", typeof(int)),
                    new DataColumn("CodigoTipoInformacionEmitida ", typeof(string)),
                    new DataColumn("CodigoPublicoObjetivo ", typeof(string)),

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

                    User.obtenerUsuario());
            }
            var IND_OPERACION = comunicadoEmisionMesBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDCEM(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dimar\\ComunicadoEmisionMes.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = comunicadoEmisionMesBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ComunicadoEmisionMes", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComunicadoEmisionMes.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComunicadoEmisionMes.xlsx");
        }
    }

}

