using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comfoe;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comfoe;
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

    public class ComfoeAlistamientoRepuestoCriticoComfoeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        AlistamientoRepuestoCriticoComfoe alistamientoRepuestoCriticoComfoeBL = new();

        UnidadNaval unidadNavalBL = new();
        AlistamientoRepuestoCritico alistamientoRepuestoCriticoBL = new();
        Carga cargaBL = new();

        public ComfoeAlistamientoRepuestoCriticoComfoeController(IWebHostEnvironment webHostEnvironment)
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
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoRepuestoCriticoComfoe");

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = alistamientoRepuestoCriticoDTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<AlistamientoRepuestoCriticoComfoeDTO> select = alistamientoRepuestoCriticoComfoeBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoAlistamientoRepuestoCritico, int CargaId, string Fecha)
        {
            AlistamientoRepuestoCriticoComfoeDTO alistamientoRepuestoCriticoComfoeDTO = new();
            alistamientoRepuestoCriticoComfoeDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoRepuestoCriticoComfoeDTO.CodigoAlistamientoRepuestoCritico = CodigoAlistamientoRepuestoCritico;
            alistamientoRepuestoCriticoComfoeDTO.CargaId = CargaId;
            alistamientoRepuestoCriticoComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoRepuestoCriticoComfoeBL.AgregarRegistro(alistamientoRepuestoCriticoComfoeDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistamientoRepuestoCriticoComfoeBL.EditarFormado(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoAlistamientoRepuestoCritico)
        {
            AlistamientoRepuestoCriticoComfoeDTO alistamientoRepuestoCriticoComfoeDTO = new();
            alistamientoRepuestoCriticoComfoeDTO.AlistamientoRepuestoCriticoComfoeId = Id;
            alistamientoRepuestoCriticoComfoeDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoRepuestoCriticoComfoeDTO.CodigoAlistamientoRepuestoCritico = CodigoAlistamientoRepuestoCritico;


            alistamientoRepuestoCriticoComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoRepuestoCriticoComfoeBL.ActualizarFormato(alistamientoRepuestoCriticoComfoeDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistamientoRepuestoCriticoComfoeDTO alistamientoRepuestoCriticoComfoeDTO = new();
            alistamientoRepuestoCriticoComfoeDTO.AlistamientoRepuestoCriticoComfoeId = Id;
            alistamientoRepuestoCriticoComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistamientoRepuestoCriticoComfoeBL.EliminarFormato(alistamientoRepuestoCriticoComfoeDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AlistamientoRepuestoCriticoComfoeDTO alistamientoRepuestoCriticoComfoeDTO = new();
            alistamientoRepuestoCriticoComfoeDTO.CargaId = Id;
            alistamientoRepuestoCriticoComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (alistamientoRepuestoCriticoComfoeBL.EliminarCarga(alistamientoRepuestoCriticoComfoeDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistamientoRepuestoCriticoComfoeDTO> lista = new List<AlistamientoRepuestoCriticoComfoeDTO>();
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

                    lista.Add(new AlistamientoRepuestoCriticoComfoeDTO
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
            var IND_OPERACION = alistamientoRepuestoCriticoComfoeBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = alistamientoRepuestoCriticoComfoeBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfoeAlistamientoRepuestoCriticoComfoe.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfoeAlistamientoRepuestoCriticoComfoe.xlsx");
        }

    }

}

