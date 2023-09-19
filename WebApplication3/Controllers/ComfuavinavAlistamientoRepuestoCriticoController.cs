using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Formatos.Comfuavinav;
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

    public class ComfuavinavAlistamientoRepuestoCriticoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        AlistamientoRepuestoCriticoComfuavinav alistamientoRepuestoCriticoComfuavinavBL = new();

        UnidadNaval unidadNavalBL = new();
        AlistamientoRepuestoCritico alistamientoRepuestoCriticoBL = new();

        public ComfuavinavAlistamientoRepuestoCriticoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Alistamiento de repuestos críticos (ARC)", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<AlistamientoRepuestoCriticoDTO> alistamientoRepuestoCriticoDTO = alistamientoRepuestoCriticoBL.ObtenerAlistamientoRepuestoCriticos();

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = alistamientoRepuestoCriticoDTO,
            });
        }

        public IActionResult CargaTabla()
        {
            List<AlistamientoRepuestoCriticoComfuavinavDTO> select = alistamientoRepuestoCriticoComfuavinavBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Insertar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoAlistamientoRepuestoCritico, int CargaId, string Fecha)
        {
            AlistamientoRepuestoCriticoComfuavinavDTO alistamientoRepuestoCriticoComfuavinavDTO = new();
            alistamientoRepuestoCriticoComfuavinavDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoRepuestoCriticoComfuavinavDTO.CodigoAlistamientoRepuestoCritico = CodigoAlistamientoRepuestoCritico;
            alistamientoRepuestoCriticoComfuavinavDTO.CargaId = CargaId;
            alistamientoRepuestoCriticoComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoRepuestoCriticoComfuavinavBL.AgregarRegistro(alistamientoRepuestoCriticoComfuavinavDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistamientoRepuestoCriticoComfuavinavBL.BuscarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoAlistamientoRepuestoCritico)
        {
            AlistamientoRepuestoCriticoComfuavinavDTO alistamientoRepuestoCriticoComfuavinavDTO = new();
            alistamientoRepuestoCriticoComfuavinavDTO.AlistamientoRepuestoCriticoComfuavinavId = Id;
            alistamientoRepuestoCriticoComfuavinavDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoRepuestoCriticoComfuavinavDTO.CodigoAlistamientoRepuestoCritico = CodigoAlistamientoRepuestoCritico;
            alistamientoRepuestoCriticoComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoRepuestoCriticoComfuavinavBL.ActualizarFormato(alistamientoRepuestoCriticoComfuavinavDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistamientoRepuestoCriticoComfuavinavDTO alistamientoRepuestoCriticoComfuavinavDTO = new();
            alistamientoRepuestoCriticoComfuavinavDTO.AlistamientoRepuestoCriticoComfuavinavId = Id;
            alistamientoRepuestoCriticoComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistamientoRepuestoCriticoComfuavinavBL.EliminarFormato(alistamientoRepuestoCriticoComfuavinavDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //EliminarCarga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AlistamientoRepuestoCriticoComfuavinavDTO alistamientoRepuestoCriticoComfuavinavDTO = new();
            alistamientoRepuestoCriticoComfuavinavDTO.CargaId = Id;
            alistamientoRepuestoCriticoComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (alistamientoRepuestoCriticoComfuavinavBL.EliminarCarga(alistamientoRepuestoCriticoComfuavinavDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistamientoRepuestoCriticoComfuavinavDTO> lista = new List<AlistamientoRepuestoCriticoComfuavinavDTO>();
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

                    lista.Add(new AlistamientoRepuestoCriticoComfuavinavDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoAlistamientoRepuestoCritico = fila.GetCell(1).ToString()
                    });
                }
            }
            catch (Exception)
            {
                Mensaje = "0";
            }
            return Json(new { data = Mensaje, data1 = lista });
        }

        [HttpPost]
        //Registrar Masivo[AuthorizePermission(Formato: 43, Permiso: 4)]
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

            dt.Columns.AddRange(new DataColumn[3]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoAlistamientoRepuestoCritico", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = alistamientoRepuestoCriticoComfuavinavBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfuavinavAlistamientoRepuestoCritico.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfuavinavAlistamientoRepuestoCritico.xlsx");
        }
    }

}