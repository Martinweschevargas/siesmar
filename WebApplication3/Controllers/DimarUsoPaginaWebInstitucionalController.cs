using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dimar;
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

    public class DimarUsoPaginaWebInstitucionalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        UsoPaginaWebInstitucional usoPaginaWebInstitucionalBL = new();
        TipoInformacion tipoInformacionBL = new();
        Carga cargaBL = new();

        public DimarUsoPaginaWebInstitucionalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Uso de la página web Institucional", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoInformacionDTO> tipoInformacionDTO = tipoInformacionBL.ObtenerTipoInformacions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("UsoPaginaWebInstitucional");

            return Json(new
            {
                data1 = tipoInformacionDTO,
                data2 = listaCargas,
            });
        }

        public IActionResult CargaTabla()
        {
            List<UsoPaginaWebInstitucionalDTO> select = usoPaginaWebInstitucionalBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string CodigoTipoInformacion, int NumeroPublicaciones, string FechaPublicacion,int CargaId)
        {
            UsoPaginaWebInstitucionalDTO usoPaginaWebInstitucionalDTO = new();
            usoPaginaWebInstitucionalDTO.CodigoTipoInformacion = CodigoTipoInformacion;
            usoPaginaWebInstitucionalDTO.NumeroPublicaciones = NumeroPublicaciones;
            usoPaginaWebInstitucionalDTO.FechaPublicacion = FechaPublicacion;
            usoPaginaWebInstitucionalDTO.CargaId = CargaId;
            usoPaginaWebInstitucionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = usoPaginaWebInstitucionalBL.AgregarRegistro(usoPaginaWebInstitucionalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(usoPaginaWebInstitucionalBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoTipoInformacion, int NumeroPublicaciones, string FechaPublicacion)
        {
            UsoPaginaWebInstitucionalDTO usoPaginaWebInstitucionalDTO = new();
            usoPaginaWebInstitucionalDTO.UsoPaginaWebInstitucionalId = Id;
            usoPaginaWebInstitucionalDTO.CodigoTipoInformacion = CodigoTipoInformacion;
            usoPaginaWebInstitucionalDTO.NumeroPublicaciones = NumeroPublicaciones;
            usoPaginaWebInstitucionalDTO.FechaPublicacion = FechaPublicacion;
            
            usoPaginaWebInstitucionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = usoPaginaWebInstitucionalBL.ActualizarFormato(usoPaginaWebInstitucionalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            UsoPaginaWebInstitucionalDTO usoPaginaWebInstitucionalDTO = new();
            usoPaginaWebInstitucionalDTO.UsoPaginaWebInstitucionalId = Id;
            usoPaginaWebInstitucionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (usoPaginaWebInstitucionalBL.EliminarFormato(usoPaginaWebInstitucionalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<UsoPaginaWebInstitucionalDTO> lista = new List<UsoPaginaWebInstitucionalDTO>();
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

                    lista.Add(new UsoPaginaWebInstitucionalDTO
                    {
                        CodigoTipoInformacion = fila.GetCell(0).ToString(),
                        NumeroPublicaciones = int.Parse(fila.GetCell(1).ToString()),
                        FechaPublicacion = fila.GetCell(2).ToString(),

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

            dt.Columns.AddRange(new DataColumn[4]
            {
                    new DataColumn("CodigoTipoInformacion ", typeof(string)),
                    new DataColumn("NumeroPublicaciones ", typeof(int)),
                    new DataColumn("FechaPublicacion ", typeof(string)),
              
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(

                    fila.GetCell(0).ToString(),
                    int.Parse(fila.GetCell(1).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                   

                    User.obtenerUsuario());
            }
            var IND_OPERACION = usoPaginaWebInstitucionalBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDUPWI(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dimar\\UsoPaginaWebInstitucional.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = usoPaginaWebInstitucionalBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("UsoPaginaWebInstitucional", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\UsoPaginaWebInstitucional.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "UsoPaginaWebInstitucional.xlsx");
        }
    }

}

