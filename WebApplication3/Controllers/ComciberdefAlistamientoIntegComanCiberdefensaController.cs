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

    public class ComciberdefAlistamientoIntegComanCiberdefensaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        AlistamientoIntegralComandanciaCiberdefensa alistamientoICCiberdefensaBL = new();

        Carga cargaBL = new();
        public ComciberdefAlistamientoIntegComanCiberdefensaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Alistamiento Integral de la Comandancia de Ciberdefensa", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }
        public IActionResult cargaCombs()
        {

            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoIntegralComandanciaCiberdefensa");

            return Json(new { data1 = listaCargas });
        }


        public IActionResult CargaTabla()
        {
            List<AlistamientoIntegralComandanciaCiberdefensaDTO> select = alistamientoICCiberdefensaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(int AnioAlistamiento, string SemestreAlistamiento, decimal AlistamientoPersonal, 
            decimal AlistamientoEntretenimiento, decimal AlistamientoMaterial, decimal AlistamientoLogistico, int CargaId)
        {
            AlistamientoIntegralComandanciaCiberdefensaDTO alistamientoICCiberdefensaDTO = new();
            alistamientoICCiberdefensaDTO.AnioAlistamiento = AnioAlistamiento;
            alistamientoICCiberdefensaDTO.SemestreAlistamiento = SemestreAlistamiento;
            alistamientoICCiberdefensaDTO.AlistamientoPersonal = AlistamientoPersonal;
            alistamientoICCiberdefensaDTO.AlistamientoEntretenimiento = AlistamientoEntretenimiento;
            alistamientoICCiberdefensaDTO.AlistamientoMaterial = AlistamientoMaterial;
            alistamientoICCiberdefensaDTO.AlistamientoLogistico = AlistamientoLogistico;
            alistamientoICCiberdefensaDTO.CargaId = CargaId;
            alistamientoICCiberdefensaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoICCiberdefensaBL.AgregarRegistro(alistamientoICCiberdefensaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistamientoICCiberdefensaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int AnioAlistamiento, string SemestreAlistamiento, decimal AlistamientoPersonal,
            decimal AlistamientoEntretenimiento, decimal AlistamientoMaterial, decimal AlistamientoLogistico)
        {
            AlistamientoIntegralComandanciaCiberdefensaDTO alistamientoICCiberdefensaDTO = new();
            alistamientoICCiberdefensaDTO.AlistamientoIntegralCiberdefensaId = Id;
            alistamientoICCiberdefensaDTO.AnioAlistamiento = AnioAlistamiento;
            alistamientoICCiberdefensaDTO.SemestreAlistamiento = SemestreAlistamiento;
            alistamientoICCiberdefensaDTO.AlistamientoPersonal = AlistamientoPersonal;
            alistamientoICCiberdefensaDTO.AlistamientoEntretenimiento = AlistamientoEntretenimiento;
            alistamientoICCiberdefensaDTO.AlistamientoMaterial = AlistamientoMaterial;
            alistamientoICCiberdefensaDTO.AlistamientoLogistico = AlistamientoLogistico;
            alistamientoICCiberdefensaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoICCiberdefensaBL.ActualizarFormato(alistamientoICCiberdefensaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistamientoIntegralComandanciaCiberdefensaDTO alistamientoICCiberdefensaDTO = new();
            alistamientoICCiberdefensaDTO.AlistamientoIntegralCiberdefensaId = Id;
            alistamientoICCiberdefensaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistamientoICCiberdefensaBL.EliminarFormato(alistamientoICCiberdefensaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistamientoIntegralComandanciaCiberdefensaDTO> lista = new List<AlistamientoIntegralComandanciaCiberdefensaDTO>();
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
                    lista.Add(new AlistamientoIntegralComandanciaCiberdefensaDTO
                    {
                        AnioAlistamiento = int.Parse(fila.GetCell(0).ToString()),
                        SemestreAlistamiento = fila.GetCell(1).ToString(),
                        AlistamientoPersonal = decimal.Parse(fila.GetCell(2).ToString()),
                        AlistamientoEntretenimiento = decimal.Parse(fila.GetCell(3).ToString()),
                        AlistamientoMaterial = decimal.Parse(fila.GetCell(4).ToString()),
                        AlistamientoLogistico = decimal.Parse(fila.GetCell(5).ToString())
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
                    new DataColumn("AnioAlistamiento", typeof(int)),
                    new DataColumn("SemestreAlistamiento", typeof(string)),
                    new DataColumn("AlistamientoPersonal", typeof(decimal)),
                    new DataColumn("AlistamientoEntretenimiento", typeof(decimal)),
                    new DataColumn("AlistamientoMaterial", typeof(decimal)),
                    new DataColumn("AlistamientoLogistico", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    decimal.Parse(fila.GetCell(2).ToString()),
                    decimal.Parse(fila.GetCell(3).ToString()),
                    decimal.Parse(fila.GetCell(4).ToString()),
                    decimal.Parse(fila.GetCell(5).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = alistamientoICCiberdefensaBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteACC(int? CargaId = null)
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comciberdef\\ComciberdefVAlistIntegComandanciaCiberdefensa.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var reporteACC = alistamientoICCiberdefensaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ComciberdefVAlistIntegComandanciaCiberdefensa", reporteACC);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComciberdefAlistamientoICCiberdefensaBL.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComciberdefAlistamientoICCiberdefensaBL.xlsx");
        }


    }

}

