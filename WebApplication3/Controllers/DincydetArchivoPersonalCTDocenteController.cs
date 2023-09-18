using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dincydet;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Presentacion.Filters;
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
    public class DincydetArchivoPersonalCTDocenteController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ArchivoPersonalCTDocente archivoPersonalCTDocenteBL = new();
        AreaCT areaCTBL = new();
        Carga cargaBL = new();

        public DincydetArchivoPersonalCTDocenteController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Archivo Personal en Ciencia y Tecnología Docencia", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<AreaCTDTO> AreaCTDTO = areaCTBL.ObtenerAreaCTs();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ArchivoPersonalCTDocente");
            return Json(new { data1 = AreaCTDTO, data2 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<ArchivoPersonalCTDocenteDTO> select = archivoPersonalCTDocenteBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 43, Permiso: 1)]//registrar
        public ActionResult Insertar(string DNIPersonalCTDocente, string CodigoInstitucionEjerce, string CodigoAreaCT, 
            int AniosDocenciaPersonalCTDocente, int CargaId, string Fecha)
        {
            ArchivoPersonalCTDocenteDTO archivoPersonalCTDocenteDTO = new();
            archivoPersonalCTDocenteDTO.DNIPersonalCTDocente = DNIPersonalCTDocente;
            archivoPersonalCTDocenteDTO.CodigoInstitucionEjerce = CodigoInstitucionEjerce;
            archivoPersonalCTDocenteDTO.CodigoAreaCT = CodigoAreaCT;
            archivoPersonalCTDocenteDTO.AniosDocenciaPersonalCTDocente = AniosDocenciaPersonalCTDocente;
            archivoPersonalCTDocenteDTO.CargaId = CargaId;
            archivoPersonalCTDocenteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = archivoPersonalCTDocenteBL.AgregarRegistro(archivoPersonalCTDocenteDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(archivoPersonalCTDocenteBL.BuscarFormato(Id));
        }

        //[AuthorizePermission(Formato: 43, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string DNIPersonalCTDocente, string CodigoInstitucionEjerce, string CodigoAreaCT,
            int AniosDocenciaPersonalCTDocente)
        {
            
            ArchivoPersonalCTDocenteDTO archivoPersonalCTDocenteDTO = new();
            archivoPersonalCTDocenteDTO.ArchivoPersonalCTDocenteId = Id;
            archivoPersonalCTDocenteDTO.DNIPersonalCTDocente = DNIPersonalCTDocente;
            archivoPersonalCTDocenteDTO.CodigoInstitucionEjerce = CodigoInstitucionEjerce;
            archivoPersonalCTDocenteDTO.CodigoAreaCT = CodigoAreaCT;
            archivoPersonalCTDocenteDTO.AniosDocenciaPersonalCTDocente = AniosDocenciaPersonalCTDocente;
            archivoPersonalCTDocenteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = archivoPersonalCTDocenteBL.ActualizarFormato(archivoPersonalCTDocenteDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ArchivoPersonalCTDocenteDTO archivoPersonalCTDocenteDTO = new();
            archivoPersonalCTDocenteDTO.ArchivoPersonalCTDocenteId = Id;
            archivoPersonalCTDocenteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (archivoPersonalCTDocenteBL.EliminarFormato(archivoPersonalCTDocenteDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }


        //[AuthorizePermission(Formato: 43, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ArchivoPersonalCTDocenteDTO archivoPersonalCTDocenteDTO = new();
            archivoPersonalCTDocenteDTO.CargaId = Id;
            archivoPersonalCTDocenteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (archivoPersonalCTDocenteBL.EliminarCarga(archivoPersonalCTDocenteDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ArchivoPersonalCTDocenteDTO> lista = new List<ArchivoPersonalCTDocenteDTO>();
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

                    lista.Add(new ArchivoPersonalCTDocenteDTO
                    {
                        DNIPersonalCTDocente = fila.GetCell(0).ToString(),
                        CodigoInstitucionEjerce = fila.GetCell(1).ToString(),
                        CodigoAreaCT = fila.GetCell(2).ToString(),
                        AniosDocenciaPersonalCTDocente = int.Parse(fila.GetCell(3).ToString()),
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
        //[AuthorizePermission(Formato: 43, Permiso: 4)]//Registrar Masivo
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
                    new DataColumn("DNIPersonalCTDocente", typeof(string)),
                    new DataColumn("CodigoInstitucionEjerce", typeof(string)),
                    new DataColumn("CodigoAreaCT", typeof(string)),
                    new DataColumn("AniosDocenciaPersonalCTDocente", typeof(int)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    int.Parse(fila.GetCell(3).ToString()),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = archivoPersonalCTDocenteBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteAPCTD(int? CargaId = null)
        {

            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dincydet\\ArchivoPersonalCTDocente.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var archivoPersonalCTDocente = archivoPersonalCTDocenteBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ArchivoPersonalCTDocente", archivoPersonalCTDocente);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DincydetArchivoPersonalCTDocente.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DincydetArchivoPersonalCTDocente.xlsx");
        }

    }

}