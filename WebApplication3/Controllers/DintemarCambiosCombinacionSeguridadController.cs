using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dintemar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
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

    public class DintemarCambiosCombinacionSeguridadController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        CambiosCombinacionSeguridadDAO cambiosCombinacionSeguridadBL = new();
        MesDAO mesBL = new();
        ZonaNavalDAO zonaNavalBL = new();
        Carga cargaBL = new();

        public DintemarCambiosCombinacionSeguridadController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Cambios de Combinación de Cajas/Bóvedas de Seguridad", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> mesDTO = mesBL.ObtenerMess();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("CambiosCombinacionSeguridad");

            return Json(new { data1 = mesDTO, data2 = zonaNavalDTO, data3= listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<CambiosCombinacionSeguridadDTO> select = cambiosCombinacionSeguridadBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(int MesId, int AnioCambioCombinacion, string CodigoZonaNaval,
           int CambiosCombinacionSeguridad, int PorcentajeAvanceCambio, int CargaId)
        {
            CambiosCombinacionSeguridadDTO cambiosCombinacionSeguridadDTO = new();
            cambiosCombinacionSeguridadDTO.MesId = MesId;
            cambiosCombinacionSeguridadDTO.AnioCambioCombinacion = AnioCambioCombinacion;
            cambiosCombinacionSeguridadDTO.CodigoZonaNaval = CodigoZonaNaval;
            cambiosCombinacionSeguridadDTO.CambiosCombinacionSeguridad = CambiosCombinacionSeguridad;
            cambiosCombinacionSeguridadDTO.PorcentajeAvanceCambio = PorcentajeAvanceCambio;
            cambiosCombinacionSeguridadDTO.CargaId = CargaId;
            cambiosCombinacionSeguridadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = cambiosCombinacionSeguridadBL.AgregarRegistro(cambiosCombinacionSeguridadDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(cambiosCombinacionSeguridadBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int MesId, int AnioCambioCombinacion, string CodigoZonaNaval,
           int CambiosCombinacionSeguridad, int PorcentajeAvanceCambio)
        {
            CambiosCombinacionSeguridadDTO cambiosCombinacionSeguridadDTO = new();
            cambiosCombinacionSeguridadDTO.CambiosCombinacionSeguridadId = Id;
            cambiosCombinacionSeguridadDTO.MesId = MesId;
            cambiosCombinacionSeguridadDTO.AnioCambioCombinacion = AnioCambioCombinacion;
            cambiosCombinacionSeguridadDTO.CodigoZonaNaval = CodigoZonaNaval;
            cambiosCombinacionSeguridadDTO.CambiosCombinacionSeguridad = CambiosCombinacionSeguridad;
            cambiosCombinacionSeguridadDTO.PorcentajeAvanceCambio = PorcentajeAvanceCambio;
            cambiosCombinacionSeguridadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = cambiosCombinacionSeguridadBL.ActualizaFormato(cambiosCombinacionSeguridadDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            CambiosCombinacionSeguridadDTO cambiosCombinacionSeguridadDTO = new();
            cambiosCombinacionSeguridadDTO.CambiosCombinacionSeguridadId = Id;
            cambiosCombinacionSeguridadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (cambiosCombinacionSeguridadBL.EliminarFormato(cambiosCombinacionSeguridadDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<CambiosCombinacionSeguridadDTO> lista = new List<CambiosCombinacionSeguridadDTO>();
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

                    lista.Add(new CambiosCombinacionSeguridadDTO
                    {
                        MesId = int.Parse(fila.GetCell(0).ToString()),
                        AnioCambioCombinacion = int.Parse(fila.GetCell(1).ToString()),
                        CodigoZonaNaval = fila.GetCell(2).ToString(),
                        CambiosCombinacionSeguridad = int.Parse(fila.GetCell(3).ToString()),
                        PorcentajeAvanceCambio = int.Parse(fila.GetCell(4).ToString()),
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
                    new DataColumn("MesId", typeof(int)),
                    new DataColumn("AnioCambioCombinacion", typeof(int)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("CambiosCombinacionSeguridad ", typeof(int)),
                    new DataColumn("PorcentajeAvanceCambio", typeof(int)),
                
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    int.Parse(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    int.Parse(fila.GetCell(3).ToString()),
                    int.Parse(fila.GetCell(4).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = cambiosCombinacionSeguridadBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDCCS(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dintemar\\CambiosCombinacionSeguridad.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = cambiosCombinacionSeguridadBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("CambiosCombinacionSeguridad", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\CambiosCombinacionSeguridad.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "CambiosCombinacionSeguridad.xlsx");
        }
    }

}