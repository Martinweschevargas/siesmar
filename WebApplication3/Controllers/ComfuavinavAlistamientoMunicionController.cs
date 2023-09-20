using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
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

    public class ComfuavinavAlistamientoMunicionController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        AlistamientoMunicionComfuavinav alistamientoMunicionComfuavinavBL = new();

        UnidadNaval unidadNavalBL = new();
        AlistamientoMunicion alistamientoMunicionBL = new();
        Carga cargaBL = new();

        public ComfuavinavAlistamientoMunicionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Alistamiento de munición (AMU)", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<AlistamientoMunicionDTO> alistamientoMunicionDTO = alistamientoMunicionBL.ObtenerAlistamientoMunicions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoMunicionComfuavinav");

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = alistamientoMunicionDTO,
                data3 = listaCargas
            }); ;
        }

        public IActionResult CargaTabla()
        {
            List<AlistamientoMunicionComfuavinavDTO> select = alistamientoMunicionComfuavinavBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 150, Permiso: 1)]//Registrar
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoAlistamientoMunicion, int CargaId, string Fecha)
        {
            AlistamientoMunicionComfuavinavDTO alistamientoMunicionComfuavinavDTO = new();
            alistamientoMunicionComfuavinavDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMunicionComfuavinavDTO.CodigoAlistamientoMunicion = CodigoAlistamientoMunicion;
            alistamientoMunicionComfuavinavDTO.CargaId = CargaId;
            alistamientoMunicionComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMunicionComfuavinavBL.AgregarRegistro(alistamientoMunicionComfuavinavDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Codigo)
        {
            return Json(alistamientoMunicionComfuavinavBL.EditarFormado(Codigo));
        }

        //[AuthorizePermission(Formato: 150, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoAlistamientoMunicion)
        {
            AlistamientoMunicionComfuavinavDTO alistamientoMunicionComfuavinavDTO = new();
            alistamientoMunicionComfuavinavDTO.AlistamientoMunicionComfuavinavId = Id;
            alistamientoMunicionComfuavinavDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMunicionComfuavinavDTO.CodigoAlistamientoMunicion = CodigoAlistamientoMunicion;
            alistamientoMunicionComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMunicionComfuavinavBL.ActualizarFormato(alistamientoMunicionComfuavinavDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 150, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistamientoMunicionComfuavinavDTO alistamientoMunicionComfuavinavDTO = new();
            alistamientoMunicionComfuavinavDTO.AlistamientoMunicionComfuavinavId = Id;
            alistamientoMunicionComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistamientoMunicionComfuavinavBL.EliminarFormato(alistamientoMunicionComfuavinavDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 150, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AlistamientoMunicionComfuavinavDTO alistamientoMunicionComfuavinavDTO = new();
            alistamientoMunicionComfuavinavDTO.CargaId = Id;
            alistamientoMunicionComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (alistamientoMunicionComfuavinavBL.EliminarCarga(alistamientoMunicionComfuavinavDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistamientoMunicionComfuavinavDTO> lista = new List<AlistamientoMunicionComfuavinavDTO>();
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

                    lista.Add(new AlistamientoMunicionComfuavinavDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoAlistamientoMunicion = fila.GetCell(1).ToString()

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
        //[AuthorizePermission(Formato: 150, Permiso: 4)]//Registrar Masivo
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
                    new DataColumn("CodigoAlistamientoMunicion", typeof(string)),
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
            var IND_OPERACION = alistamientoMunicionComfuavinavBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfuavinavAlistamientoMunicion.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfuavinavAlistamientoMunicion.xlsx");
        }
    }

}