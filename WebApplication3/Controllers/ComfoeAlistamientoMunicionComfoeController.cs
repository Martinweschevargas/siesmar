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

    public class ComfoeAlistamientoMunicionComfoeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        AlistamientoMunicionComfoe alistamientoMunicionComfoeBL = new();
        UnidadNaval unidadNavalBL = new();
        AlistamientoMunicion alistamientoMunicionBL = new();
        Carga cargaBL = new();
        public ComfoeAlistamientoMunicionComfoeController(IWebHostEnvironment webHostEnvironment)
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
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoMunicionComfoe");

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = alistamientoMunicionDTO,
                data3 = listaCargas
            }); ;
        }

        public IActionResult CargaTabla()
        {
            List<AlistamientoMunicionComfoeDTO> select = alistamientoMunicionComfoeBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoAlistamientoMunicion, int CargaId, string Fecha)
        {
            AlistamientoMunicionComfoeDTO alistamientoMunicionComfoeDTO = new();
            alistamientoMunicionComfoeDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMunicionComfoeDTO.CodigoAlistamientoMunicion = CodigoAlistamientoMunicion;
            alistamientoMunicionComfoeDTO.CargaId = CargaId;
            alistamientoMunicionComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMunicionComfoeBL.AgregarRegistro(alistamientoMunicionComfoeDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistamientoMunicionComfoeBL.EditarFormado(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)
        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoAlistamientoMunicion)
        {
            AlistamientoMunicionComfoeDTO alistamientoMunicionComfoeDTO = new();
            alistamientoMunicionComfoeDTO.AlistamientoMunicionComfoeId = Id;
            alistamientoMunicionComfoeDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMunicionComfoeDTO.CodigoAlistamientoMunicion = CodigoAlistamientoMunicion;


            alistamientoMunicionComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMunicionComfoeBL.ActualizarFormato(alistamientoMunicionComfoeDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistamientoMunicionComfoeDTO alistamientoMunicionComfoeDTO = new();
            alistamientoMunicionComfoeDTO.AlistamientoMunicionComfoeId = Id;
            alistamientoMunicionComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistamientoMunicionComfoeBL.EliminarFormato(alistamientoMunicionComfoeDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }


        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AlistamientoMunicionComfoeDTO alistamientoMunicionComfoeDTO = new();
            alistamientoMunicionComfoeDTO.CargaId = Id;
            alistamientoMunicionComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (alistamientoMunicionComfoeBL.EliminarCarga(alistamientoMunicionComfoeDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistamientoMunicionComfoeDTO> lista = new List<AlistamientoMunicionComfoeDTO>();
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

                    lista.Add(new AlistamientoMunicionComfoeDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoAlistamientoMunicion = fila.GetCell(1).ToString(),

                    });
                }
            }
            catch (Exception )
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
            var IND_OPERACION = alistamientoMunicionComfoeBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = alistamientoMunicionComfoeBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfoeAlistamientoMunicionComfoe.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfoeAlistamientoMunicionComfoe.xlsx");
        }

    }

}

