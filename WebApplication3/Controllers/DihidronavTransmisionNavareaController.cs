using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dihidronav;
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
    public class DihidronavTransmisionNavareaController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        TransmisionNavarea transmisionNavareaBL = new();
        Carga cargaBL = new();

        public DihidronavTransmisionNavareaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Transmisión de Navareas (Para navegantes en general en el área XVI, por sistema Inmarsat y Sistema Navtex)", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CargaTabla()
        {
            List<TransmisionNavareaDTO> transmisionNavareaDTO = transmisionNavareaBL.ObtenerLista();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("TransmisionNavarea");

            return Json(new { data1 = transmisionNavareaDTO, data2 = listaCargas });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int NumeroOrden, string NumeroNavarea, string RadioavisoNautico, string FechaTermino, 
            string FechaEmision, string Promotor,int CargaId)
        {
            TransmisionNavareaDTO transmisionNavareaDTO = new();
            transmisionNavareaDTO.NumeroOrden = NumeroOrden;
            transmisionNavareaDTO.NumeroNavarea = NumeroNavarea;
            transmisionNavareaDTO.RadioavisoNautico = RadioavisoNautico;
            transmisionNavareaDTO.FechaEmision = FechaEmision;
            transmisionNavareaDTO.Promotor = Promotor;
            transmisionNavareaDTO.FechaTermino = FechaTermino;
            transmisionNavareaDTO.CargaId = CargaId;
            transmisionNavareaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = transmisionNavareaBL.AgregarRegistro(transmisionNavareaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(transmisionNavareaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int TransmisionNavareaId, int NumeroOrden, string NumeroNavarea, string RadioavisoNautico, string FechaTermino,
            string FechaEmision, string Promotor)
        {
            TransmisionNavareaDTO transmisionNavareaDTO = new();
            transmisionNavareaDTO.TransmisionNavareaId = TransmisionNavareaId;
            transmisionNavareaDTO.NumeroOrden = NumeroOrden;
            transmisionNavareaDTO.NumeroNavarea = NumeroNavarea;
            transmisionNavareaDTO.RadioavisoNautico = RadioavisoNautico;
            transmisionNavareaDTO.FechaEmision = FechaEmision;
            transmisionNavareaDTO.Promotor = Promotor;
            transmisionNavareaDTO.FechaTermino = FechaTermino;
            transmisionNavareaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = transmisionNavareaBL.ActualizarFormato(transmisionNavareaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            TransmisionNavareaDTO transmisionNavareaDTO = new();
            transmisionNavareaDTO.TransmisionNavareaId = Id;
            transmisionNavareaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (transmisionNavareaBL.EliminarFormato(transmisionNavareaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<TransmisionNavareaDTO> lista = new List<TransmisionNavareaDTO>();
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

                    lista.Add(new TransmisionNavareaDTO
                    {
                        NumeroOrden = int.Parse(fila.GetCell(0).ToString()),
                        NumeroNavarea = fila.GetCell(1).ToString(),
                        RadioavisoNautico = fila.GetCell(2).ToString(),
                        FechaEmision = fila.GetCell(3).ToString(),
                        Promotor = fila.GetCell(4).ToString(),
                        FechaTermino = fila.GetCell(5).ToString()
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

            dt.Columns.AddRange(new DataColumn[7]
            {
                    new DataColumn("NumeroOrden", typeof(int)),
                    new DataColumn("NumeroNavarea", typeof(string)),
                    new DataColumn("RadioavisoNautico", typeof(string)),
                    new DataColumn("FechaEmision", typeof(string)),
                    new DataColumn("Promotor", typeof(string)),
                    new DataColumn("FechaTermino", typeof(string)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                    fila.GetCell(4).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = transmisionNavareaBL.InsertarDatos(dt);
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


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DihidronavTransmisionNavarea.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DihidronavTransmisionNavarea.xlsx");
        }
    }

}