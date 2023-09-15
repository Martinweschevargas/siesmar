using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dincydet;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
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
    public class DincydetArchivoPublicaSuscripRevistasController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ArchivoPublicaSuscripRevistas archivoPublicaSuscripRevistasBL = new();
        AreaCT areaCTBL = new();
        Carga cargaBL = new();

        public DincydetArchivoPublicaSuscripRevistasController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Archivo Publicación y Suscripciones de Artículos Científicos de C.T en Revistas Especializadas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<AreaCTDTO> AreaCTDTO = areaCTBL.ObtenerAreaCTs();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ArchivoPublicaSuscripRevista");
            return Json(new { data1 = AreaCTDTO, data2 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<ArchivoPublicaSuscripRevistasDTO> select = archivoPublicaSuscripRevistasBL.ObtenerLista();
            return Json(new { data = select });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 43, Permiso: 1)]//Registrar
        public ActionResult Insertar(string NombreArticuloRevista, string TipoArticuloRevista, string CodigoAreaCT, int CargaId, string Fecha)
        {
            ArchivoPublicaSuscripRevistasDTO archivoPublicaSuscripRevistasDTO = new();
            archivoPublicaSuscripRevistasDTO.NombreArticuloRevista = NombreArticuloRevista;
            archivoPublicaSuscripRevistasDTO.TipoArticuloRevista = TipoArticuloRevista;
            archivoPublicaSuscripRevistasDTO.CodigoAreaCT = CodigoAreaCT;
            archivoPublicaSuscripRevistasDTO.CargaId = CargaId;
            archivoPublicaSuscripRevistasDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = archivoPublicaSuscripRevistasBL.AgregarRegistro(archivoPublicaSuscripRevistasDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(archivoPublicaSuscripRevistasBL.BuscarFormato(Id));
        }

        //[AuthorizePermission(Formato: 43, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string NombreArticuloRevista, string TipoArticuloRevista, string CodigoAreaCT)
        {
            ArchivoPublicaSuscripRevistasDTO archivoPublicaSuscripRevistasDTO = new();
            archivoPublicaSuscripRevistasDTO.ArchivoPublicaSuscripRevistaId = Id;
            archivoPublicaSuscripRevistasDTO.NombreArticuloRevista = NombreArticuloRevista;
            archivoPublicaSuscripRevistasDTO.TipoArticuloRevista = TipoArticuloRevista;
            archivoPublicaSuscripRevistasDTO.CodigoAreaCT = CodigoAreaCT;
            archivoPublicaSuscripRevistasDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = archivoPublicaSuscripRevistasBL.ActualizarFormato(archivoPublicaSuscripRevistasDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ArchivoPublicaSuscripRevistasDTO archivoPublicaSuscripRevistasDTO = new();
            archivoPublicaSuscripRevistasDTO.ArchivoPublicaSuscripRevistaId = Id;
            archivoPublicaSuscripRevistasDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (archivoPublicaSuscripRevistasBL.EliminarFormato(archivoPublicaSuscripRevistasDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ArchivoPublicaSuscripRevistasDTO archivoPublicaSuscripRevistasDTO = new();
            archivoPublicaSuscripRevistasDTO.CargaId = Id;
            archivoPublicaSuscripRevistasDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (archivoPublicaSuscripRevistasBL.EliminarCarga(archivoPublicaSuscripRevistasDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ArchivoPublicaSuscripRevistasDTO> lista = new List<ArchivoPublicaSuscripRevistasDTO>();
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

                    lista.Add(new ArchivoPublicaSuscripRevistasDTO
                    {
                        NombreArticuloRevista = fila.GetCell(0).ToString(),
                        TipoArticuloRevista = fila.GetCell(1).ToString(),
                        CodigoAreaCT = fila.GetCell(2).ToString()
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

            dt.Columns.AddRange(new DataColumn[4]
            {
                    new DataColumn("NombreArticuloRevista", typeof(string)),
                    new DataColumn("TipoArticuloRevista", typeof(string)),
                    new DataColumn("CodigoAreaCT", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = archivoPublicaSuscripRevistasBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DincydetArchivoPublicaSuscripRevistas.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DincydetArchivoPublicaSuscripRevistas.xlsx");
        }
    }

}