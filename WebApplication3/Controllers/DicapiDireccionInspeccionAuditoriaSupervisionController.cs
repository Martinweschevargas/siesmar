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
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DicapiDireccionInspeccionAuditoriaSupervisionController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        DireccionInspeccionAuditoriaSupervision direccionInspeccionAuditoriaSupervisionBL = new();
        Capitania capitaniaBL = new();
        Carga cargaBL = new();

        public DicapiDireccionInspeccionAuditoriaSupervisionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Direccion de Inspecciones, Auditorias y Supervisiones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<CapitaniaDTO> capitaniaDTO = capitaniaBL.ObtenerCapitanias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("DireccionInspeccionAuditoriaSupervision");

            return Json(new
            {
                data1 = capitaniaDTO, 
                data2 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<DireccionInspeccionAuditoriaSupervisionDTO> direccionInspeccionAuditoriaSupervisionDTO = direccionInspeccionAuditoriaSupervisionBL.ObtenerLista();
            return Json(new { data = direccionInspeccionAuditoriaSupervisionDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( string NumeroNombramiento, string Nombre1Inspector, string FechaInspeccion, 
            string Nombre2Inspector, string CodigoCapitania, int CargaId )
        {
            DireccionInspeccionAuditoriaSupervisionDTO direccionInspeccionAuditoriaSupervisionDTO = new();
            direccionInspeccionAuditoriaSupervisionDTO.NumeroNombramiento = NumeroNombramiento;
            direccionInspeccionAuditoriaSupervisionDTO.FechaInspeccion = FechaInspeccion;
            direccionInspeccionAuditoriaSupervisionDTO.CodigoCapitania = CodigoCapitania;
            direccionInspeccionAuditoriaSupervisionDTO.Nombre1Inspector = Nombre1Inspector;
            direccionInspeccionAuditoriaSupervisionDTO.Nombre2Inspector = Nombre2Inspector;
            direccionInspeccionAuditoriaSupervisionDTO.CargaId = CargaId;

            direccionInspeccionAuditoriaSupervisionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = direccionInspeccionAuditoriaSupervisionBL.AgregarRegistro(direccionInspeccionAuditoriaSupervisionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(direccionInspeccionAuditoriaSupervisionBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int DireccionInspeccionAuditoriaSupervisionId, string NumeroNombramiento, string Nombre1Inspector, string FechaInspeccion,
            string Nombre2Inspector, string CodigoCapitania)
        {
            DireccionInspeccionAuditoriaSupervisionDTO direccionInspeccionAuditoriaSupervisionDTO = new();
            direccionInspeccionAuditoriaSupervisionDTO.DireccionInspeccionAuditoriaSupervisionId = DireccionInspeccionAuditoriaSupervisionId;
            direccionInspeccionAuditoriaSupervisionDTO.NumeroNombramiento = NumeroNombramiento;
            direccionInspeccionAuditoriaSupervisionDTO.FechaInspeccion = FechaInspeccion;
            direccionInspeccionAuditoriaSupervisionDTO.CodigoCapitania = CodigoCapitania;
            direccionInspeccionAuditoriaSupervisionDTO.Nombre1Inspector = Nombre1Inspector;
            direccionInspeccionAuditoriaSupervisionDTO.Nombre2Inspector = Nombre2Inspector;;
            direccionInspeccionAuditoriaSupervisionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = direccionInspeccionAuditoriaSupervisionBL.ActualizarFormato(direccionInspeccionAuditoriaSupervisionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            DireccionInspeccionAuditoriaSupervisionDTO direccionInspeccionAuditoriaSupervisionDTO = new();
            direccionInspeccionAuditoriaSupervisionDTO.DireccionInspeccionAuditoriaSupervisionId = Id;
            direccionInspeccionAuditoriaSupervisionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (direccionInspeccionAuditoriaSupervisionBL.EliminarFormato(direccionInspeccionAuditoriaSupervisionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {

            string Mensaje = "1";
            List<DireccionInspeccionAuditoriaSupervisionDTO> lista = new List<DireccionInspeccionAuditoriaSupervisionDTO>();
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

                    lista.Add(new DireccionInspeccionAuditoriaSupervisionDTO
                    {
                        NumeroNombramiento = fila.GetCell(0).ToString(),
                        FechaInspeccion = fila.GetCell(1).ToString(),
                        CodigoCapitania = fila.GetCell(2).ToString(),
                        Nombre1Inspector = fila.GetCell(3).ToString(),
                        Nombre2Inspector = fila.GetCell(4).ToString()
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

            dt.Columns.AddRange(new DataColumn[6]
            {
                    new DataColumn("NumeroNombramiento", typeof(string)),
                    new DataColumn("FechaInspeccion", typeof(string)),
                    new DataColumn("CodigoCapitania", typeof(string)),
                    new DataColumn("Nombre1Inspector", typeof(string)),
                    new DataColumn("Nombre2Inspector", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = direccionInspeccionAuditoriaSupervisionBL.InsertarDatos(dt);
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
            var Capitanias = direccionInspeccionAuditoriaSupervisionBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DicapiDireccionInspeccionAuditoriaSupervision.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DicapiDireccionInspeccionAuditoriaSupervision.xlsx");
        }
    }

}