using AspNetCore.Reporting;
using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using Marina.Siesmar.Entidades.Formatos.Comzouno;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzouno;
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

    public class ComzounoAlistamientoCombustibleLubricanteComzounoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        AlistamientoCombustibleLubricanteComzouno alistamientoCombustibleLubricanteComzounoBL = new();
        UnidadNaval unidadNavalBL = new();
        AlistamientoCombustibleLubricante2 alistamientoCombustibleLubricante2BL = new();
        Carga cargaBL = new();

        public ComzounoAlistamientoCombustibleLubricanteComzounoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Alistamiento de combustibles y lubricantes (ACL)", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<AlistamientoCombustibleLubricante2DTO> alistamientoCombustibleLubricante2DTO = alistamientoCombustibleLubricante2BL.ObtenerAlistamientoCombustibleLubricante2s();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoCombustibleLubricanteComzouno");

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = alistamientoCombustibleLubricante2DTO,
                data3 = listaCargas
            }); 
        }

        public IActionResult CargaTabla()
        {
            List<AlistamientoCombustibleLubricanteComzounoDTO> lista = alistamientoCombustibleLubricanteComzounoBL.ObtenerLista();
            return Json(new { data = lista });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoAlistamientoCombustibleLubricante2, decimal PromedioPonderado,
            decimal SubPromedioParcial, int CargaId, string Fecha)
        {
            AlistamientoCombustibleLubricanteComzounoDTO alistamientoCombustibleLubricanteComzounoDTO = new();
            alistamientoCombustibleLubricanteComzounoDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoCombustibleLubricanteComzounoDTO.CodigoAlistamientoCombustibleLubricante2 = CodigoAlistamientoCombustibleLubricante2;
            alistamientoCombustibleLubricanteComzounoDTO.PromedioPonderado = PromedioPonderado;
            alistamientoCombustibleLubricanteComzounoDTO.SubPromedioParcial = SubPromedioParcial;
            alistamientoCombustibleLubricanteComzounoDTO.CargaId = CargaId;
            alistamientoCombustibleLubricanteComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();


            var IND_OPERACION = alistamientoCombustibleLubricanteComzounoBL.AgregarRegistro(alistamientoCombustibleLubricanteComzounoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistamientoCombustibleLubricanteComzounoBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoAlistamientoCombustibleLubricante2, decimal PromedioPonderado,
            decimal SubPromedioParcial)
        {
            AlistamientoCombustibleLubricanteComzounoDTO alistamientoCombustibleLubricanteComzounoDTO = new();
            alistamientoCombustibleLubricanteComzounoDTO.AlistamientoCombustibleLubricanteId = Id;
            alistamientoCombustibleLubricanteComzounoDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoCombustibleLubricanteComzounoDTO.CodigoAlistamientoCombustibleLubricante2 = CodigoAlistamientoCombustibleLubricante2;
            alistamientoCombustibleLubricanteComzounoDTO.PromedioPonderado = PromedioPonderado;
            alistamientoCombustibleLubricanteComzounoDTO.SubPromedioParcial = SubPromedioParcial;
            alistamientoCombustibleLubricanteComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoCombustibleLubricanteComzounoBL.ActualizarFormato(alistamientoCombustibleLubricanteComzounoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistamientoCombustibleLubricanteComzounoDTO alistamientoCombustibleLubricanteComzounoDTO = new();
            alistamientoCombustibleLubricanteComzounoDTO.AlistamientoCombustibleLubricanteId = Id;
            alistamientoCombustibleLubricanteComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistamientoCombustibleLubricanteComzounoBL.EliminarFormato(alistamientoCombustibleLubricanteComzounoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AlistamientoCombustibleLubricanteComzounoDTO alistamientoCombustibleLubricanteComzounoDTO = new();
            alistamientoCombustibleLubricanteComzounoDTO.CargaId = Id;
            alistamientoCombustibleLubricanteComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (alistamientoCombustibleLubricanteComzounoBL.EliminarCarga(alistamientoCombustibleLubricanteComzounoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistamientoCombustibleLubricanteComzounoDTO> lista = new List<AlistamientoCombustibleLubricanteComzounoDTO>();
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

                    lista.Add(new AlistamientoCombustibleLubricanteComzounoDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoAlistamientoCombustibleLubricante2 = fila.GetCell(1).ToString(),
                        PromedioPonderado = decimal.Parse(fila.GetCell(2).ToString()),
                        SubPromedioParcial = decimal.Parse(fila.GetCell(3).ToString())

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
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string Fecha)
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
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoAlistamientoCombustibleLubricante2", typeof(string)),
                    new DataColumn("PromedioPonderado", typeof(decimal)),
                    new DataColumn("SubPromedioParcial", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    decimal.Parse(fila.GetCell(2).ToString()),
                    decimal.Parse(fila.GetCell(3).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = alistamientoCombustibleLubricanteComzounoBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            LocalReport localReport = new LocalReport(path);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComzounoAlistamientoCombustibleLubricanteComzouno.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComzounoAlistamientoCombustibleLubricanteComzouno.xlsx");
        }

    }
}

