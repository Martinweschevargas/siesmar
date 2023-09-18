using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dicapi;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dicapi;
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
    public class DicapiOtorgamientoDerechoAreaAcuaticaController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        OtorgamientoDerechoAreaAcuatica otorgamientoDerechoAreaAcuaticaBL = new();
        DptoRiberaZocaloContinental dptoRiberaZocaloContinentalBL = new();
        InstalacionTerrestreAcuatica instalacionTerrestreAcuaticaBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        Carga cargaBL = new();

        public DicapiOtorgamientoDerechoAreaAcuaticaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Otorgamiento de Derecho de uso de Areas Acuaticas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DptoRiberaZocaloContinentalDTO> dptoRiberaZocaloContinentalDTO = dptoRiberaZocaloContinentalBL.ObtenerDptoRiberaZocaloContinentals(); 
            List<InstalacionTerrestreAcuaticaDTO> instalacionTerrestreAcuaticaDTO = instalacionTerrestreAcuaticaBL.ObtenerInstalacionTerrestreAcuaticas();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("OtorgamientoDerechoUsoAreasAcuaticas");

            return Json(new
            {
                data1 = dptoRiberaZocaloContinentalDTO,
                data2 = instalacionTerrestreAcuaticaDTO,
                data3 = departamentoUbigeoDTO,
                data4 = provinciaUbigeoDTO,
                data5 = distritoUbigeoDTO,
                data6 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<OtorgamientoDerechoAreaAcuaticaDTO> otorgamientoDerechoAreaAcuaticaDTO = otorgamientoDerechoAreaAcuaticaBL.ObtenerLista();
            return Json(new { data = otorgamientoDerechoAreaAcuaticaDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int NumeroDocumento, string CodigoInstalacionTerrestreAcuatica, string CodigoDptoRiberaZocaloCont,
            string PropietarioNave, string FechaIngresoSolicitud, string FechaAtencionSolicitud ,
            string DistritoUbigeo, int TiempoConcesion , string TipoTiempo)
        {
            OtorgamientoDerechoAreaAcuaticaDTO otorgamientoDerechoAreaAcuaticaDTO = new();
            otorgamientoDerechoAreaAcuaticaDTO.NumeroDocumento = NumeroDocumento;
            otorgamientoDerechoAreaAcuaticaDTO.FechaIngresoSolicitud = FechaIngresoSolicitud;
            otorgamientoDerechoAreaAcuaticaDTO.CodigoDptoRiberaZocaloCont = CodigoDptoRiberaZocaloCont;
            otorgamientoDerechoAreaAcuaticaDTO.PropietarioNave = PropietarioNave;
            otorgamientoDerechoAreaAcuaticaDTO.CodigoInstalacionTerrestreAcuatica = CodigoInstalacionTerrestreAcuatica;
            otorgamientoDerechoAreaAcuaticaDTO.DistritoUbigeo = DistritoUbigeo;
            otorgamientoDerechoAreaAcuaticaDTO.TiempoConcesion = TiempoConcesion;
            otorgamientoDerechoAreaAcuaticaDTO.TipoTiempo = TipoTiempo;
            otorgamientoDerechoAreaAcuaticaDTO.FechaAtencionSolicitud = FechaAtencionSolicitud;
            otorgamientoDerechoAreaAcuaticaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = otorgamientoDerechoAreaAcuaticaBL.AgregarRegistro(otorgamientoDerechoAreaAcuaticaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(otorgamientoDerechoAreaAcuaticaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int OtorgamientoDerechoAreaAcuaticaId, int NumeroDocumento, string CodigoInstalacionTerrestreAcuatica, string CodigoDptoRiberaZocaloCont,
            string PropietarioNave, string FechaIngresoSolicitud, string FechaAtencionSolicitud,
            string DistritoUbigeo, int TiempoConcesion, string TipoTiempo)
        {
            OtorgamientoDerechoAreaAcuaticaDTO otorgamientoDerechoAreaAcuaticaDTO = new();
            otorgamientoDerechoAreaAcuaticaDTO.OtorgamientoDerechoAreaAcuaticaId = OtorgamientoDerechoAreaAcuaticaId;
            otorgamientoDerechoAreaAcuaticaDTO.NumeroDocumento = NumeroDocumento;
            otorgamientoDerechoAreaAcuaticaDTO.FechaIngresoSolicitud = FechaIngresoSolicitud;
            otorgamientoDerechoAreaAcuaticaDTO.CodigoDptoRiberaZocaloCont = CodigoDptoRiberaZocaloCont;
            otorgamientoDerechoAreaAcuaticaDTO.PropietarioNave = PropietarioNave;
            otorgamientoDerechoAreaAcuaticaDTO.CodigoInstalacionTerrestreAcuatica = CodigoInstalacionTerrestreAcuatica;
            otorgamientoDerechoAreaAcuaticaDTO.DistritoUbigeo = DistritoUbigeo;
            otorgamientoDerechoAreaAcuaticaDTO.TiempoConcesion = TiempoConcesion;
            otorgamientoDerechoAreaAcuaticaDTO.TipoTiempo = TipoTiempo;
            otorgamientoDerechoAreaAcuaticaDTO.FechaAtencionSolicitud = FechaAtencionSolicitud;
            otorgamientoDerechoAreaAcuaticaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = otorgamientoDerechoAreaAcuaticaBL.ActualizarFormato(otorgamientoDerechoAreaAcuaticaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            OtorgamientoDerechoAreaAcuaticaDTO otorgamientoDerechoAreaAcuaticaDTO = new();
            otorgamientoDerechoAreaAcuaticaDTO.OtorgamientoDerechoAreaAcuaticaId = Id;
            otorgamientoDerechoAreaAcuaticaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (otorgamientoDerechoAreaAcuaticaBL.EliminarFormato(otorgamientoDerechoAreaAcuaticaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<OtorgamientoDerechoAreaAcuaticaDTO> lista = new List<OtorgamientoDerechoAreaAcuaticaDTO>();
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

                    lista.Add(new OtorgamientoDerechoAreaAcuaticaDTO
                    {
                        NumeroDocumento = int.Parse(fila.GetCell(0).ToString()),
                        FechaIngresoSolicitud = fila.GetCell(1).ToString(),
                        CodigoDptoRiberaZocaloCont = fila.GetCell(2).ToString(),
                        PropietarioNave = fila.GetCell(3).ToString(),
                        CodigoInstalacionTerrestreAcuatica = fila.GetCell(4).ToString(),
                        DistritoUbigeo = fila.GetCell(5).ToString(),
                        TiempoConcesion = int.Parse(fila.GetCell(6).ToString()),
                        TipoTiempo = fila.GetCell(7).ToString(),
                        FechaAtencionSolicitud = fila.GetCell(8).ToString()
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
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
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

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("NumeroDocumento", typeof(int)),
                    new DataColumn("FechaIngresoSolicitud", typeof(string)),
                    new DataColumn("CodigoDptoRiberaZocaloCont", typeof(string)),
                    new DataColumn("PropietarioNave", typeof(string)),
                    new DataColumn("CodigoInstalacionTerrestreAcuatica", typeof(string)),
                    new DataColumn("DistritoUbigeo", typeof(string)),
                    new DataColumn("TiempoConcesion", typeof(string)),
                    new DataColumn("TipoTiempo", typeof(string)),
                    new DataColumn("FechaAtencionSolicitud", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(8).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = otorgamientoDerechoAreaAcuaticaBL.InsertarDatos(dt);
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
            var result=localReport.Execute(RenderType.Pdf,extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        public IActionResult Print2()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report2.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            var Capitanias = otorgamientoDerechoAreaAcuaticaBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirintemarActividadCultural.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirintemarActividadCultural.xlsx");
        }
    }

}