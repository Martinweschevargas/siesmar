using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Comciberdef;
using Marina.Siesmar.Entidades.Formatos.Comciberdef;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comciberdef;
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

    public class ComciberdefCapacidadComandanciaCiberdefensaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        CapacidadComandanciaCiberdefensa capacidadComandanciaCiberdefensaBL = new();
        Carga cargaBL = new();
        public ComciberdefCapacidadComandanciaCiberdefensaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Capacidad de la Comandancia de Ciberdefensa", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }
        public IActionResult cargaCombs()
        {

            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("CapacidadComandanciaCiberdefensa");

            return Json(new { data1 = listaCargas });
        }


        public IActionResult CargaTabla()
        {
            List<CapacidadComandanciaCiberdefensaDTO> select = capacidadComandanciaCiberdefensaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar( int AnioCapacidadCiberdefensa, decimal CapacidadComandoControl, decimal CapacidadOperacionesDefensa, 
            decimal CapacidadOperacionesExplotacion, decimal CapacidadOperacionRespuesta, decimal CapacidadInvestigacionDigital, int CargaId)
        {
            CapacidadComandanciaCiberdefensaDTO capacidadComandanciaCiberdefensaDTO = new();
            capacidadComandanciaCiberdefensaDTO.AnioCapacidadCiberdefensa = AnioCapacidadCiberdefensa;
            capacidadComandanciaCiberdefensaDTO.CapacidadComandoControl = CapacidadComandoControl;
            capacidadComandanciaCiberdefensaDTO.CapacidadOperacionesDefensa = CapacidadOperacionesDefensa;
            capacidadComandanciaCiberdefensaDTO.CapacidadOperacionesExplotacion = CapacidadOperacionesExplotacion;
            capacidadComandanciaCiberdefensaDTO.CapacidadOperacionRespuesta = CapacidadOperacionRespuesta;
            capacidadComandanciaCiberdefensaDTO.CapacidadInvestigacionDigital = CapacidadInvestigacionDigital;
            capacidadComandanciaCiberdefensaDTO.CargaId = CargaId;
            capacidadComandanciaCiberdefensaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capacidadComandanciaCiberdefensaBL.AgregarRegistro(capacidadComandanciaCiberdefensaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(capacidadComandanciaCiberdefensaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int AnioCapacidadCiberdefensa, decimal CapacidadComandoControl, decimal CapacidadOperacionesDefensa,
            decimal CapacidadOperacionesExplotacion, decimal CapacidadOperacionRespuesta, decimal CapacidadInvestigacionDigital)
        {
            CapacidadComandanciaCiberdefensaDTO capacidadComandanciaCiberdefensaDTO = new();
            capacidadComandanciaCiberdefensaDTO.CapacidadComandanciaCiberdefensaId = Id;
            capacidadComandanciaCiberdefensaDTO.AnioCapacidadCiberdefensa = AnioCapacidadCiberdefensa;
            capacidadComandanciaCiberdefensaDTO.CapacidadComandoControl = CapacidadComandoControl;
            capacidadComandanciaCiberdefensaDTO.CapacidadOperacionesDefensa = CapacidadOperacionesDefensa;
            capacidadComandanciaCiberdefensaDTO.CapacidadOperacionesExplotacion = CapacidadOperacionesExplotacion;
            capacidadComandanciaCiberdefensaDTO.CapacidadOperacionRespuesta = CapacidadOperacionRespuesta;
            capacidadComandanciaCiberdefensaDTO.CapacidadInvestigacionDigital = CapacidadInvestigacionDigital;
            capacidadComandanciaCiberdefensaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capacidadComandanciaCiberdefensaBL.ActualizarFormato(capacidadComandanciaCiberdefensaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            CapacidadComandanciaCiberdefensaDTO capacidadComandanciaCiberdefensaDTO = new();
            capacidadComandanciaCiberdefensaDTO.CapacidadComandanciaCiberdefensaId = Id;
            capacidadComandanciaCiberdefensaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (capacidadComandanciaCiberdefensaBL.EliminarFormato(capacidadComandanciaCiberdefensaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<CapacidadComandanciaCiberdefensaDTO> lista = new List<CapacidadComandanciaCiberdefensaDTO>();
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
                    lista.Add(new CapacidadComandanciaCiberdefensaDTO
                    {
                        AnioCapacidadCiberdefensa = int.Parse(fila.GetCell(0).ToString()),
                        CapacidadComandoControl = decimal.Parse(fila.GetCell(1).ToString()),
                        CapacidadOperacionesDefensa = decimal.Parse(fila.GetCell(2).ToString()),
                        CapacidadOperacionesExplotacion = decimal.Parse(fila.GetCell(3).ToString()),
                        CapacidadOperacionRespuesta = decimal.Parse(fila.GetCell(4).ToString()),
                        CapacidadInvestigacionDigital = decimal.Parse(fila.GetCell(5).ToString())
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

            dt.Columns.AddRange(new DataColumn[7]
            {
                    new DataColumn("AnioCapacidadCiberdefensa", typeof(int)),
                    new DataColumn("CapacidadComandoControl", typeof(decimal)),
                    new DataColumn("CapacidadOperacionesDefensa", typeof(decimal)),
                    new DataColumn("CapacidadOperacionesExplotacion", typeof(decimal)),
                    new DataColumn("CapacidadOperacionRespuesta", typeof(decimal)),
                    new DataColumn("CapacidadInvestigacionDigital", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    decimal.Parse(fila.GetCell(1).ToString()),
                    decimal.Parse(fila.GetCell(2).ToString()),
                    decimal.Parse(fila.GetCell(3).ToString()),
                    decimal.Parse(fila.GetCell(4).ToString()),
                    decimal.Parse(fila.GetCell(5).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = capacidadComandanciaCiberdefensaBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteCCC(int? CargaId = null)
        {
   
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comciberdef\\ComciberdefVCapacidadComandanciaCiberdefensa.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var reporteCCC = capacidadComandanciaCiberdefensaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ComciberdefVCapacidadComandanciaCiberdefensa", reporteCCC);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComciberdefCapacidadComandanciaCiberdefensa.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComciberdefCapacidadComandanciaCiberdefensa.xlsx");
        }



    }

}

