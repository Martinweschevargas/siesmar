using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comfoe;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comfoe;
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
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class ComfoeAlistamientoCombustibleLubricanteComfoeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        AlistamientoCombustibleLubricanteComfoe alistamientoCombustibleLubricanteComfoeBL = new();

        UnidadNaval unidadNavalBL = new();
        AlistamientoCombustibleLubricante alistamientoCombustibleLubricanteBL = new();
        Carga cargaBL = new();
        public ComfoeAlistamientoCombustibleLubricanteComfoeController(IWebHostEnvironment webHostEnvironment)
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
            List<AlistamientoCombustibleLubricanteDTO> alistamientoCombustibleLubricanteDTO = alistamientoCombustibleLubricanteBL.ObtenerAlistamientoCombustibleLubricantes();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoCombustibleLubricanteComfoe");
            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = alistamientoCombustibleLubricanteDTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<AlistamientoCombustibleLubricanteComfoeDTO> select = alistamientoCombustibleLubricanteComfoeBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 140, Permiso: 1)]
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoAlistamientoCombustibleLubricante, int CargaId, string Fecha)
        {
            AlistamientoCombustibleLubricanteComfoeDTO alistamientoCombustibleLubricanteComfoeDTO = new();
            alistamientoCombustibleLubricanteComfoeDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoCombustibleLubricanteComfoeDTO.CodigoAlistamientoCombustibleLubricante = CodigoAlistamientoCombustibleLubricante;
            alistamientoCombustibleLubricanteComfoeDTO.CargaId = CargaId;
            alistamientoCombustibleLubricanteComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoCombustibleLubricanteComfoeBL.AgregarRegistro(alistamientoCombustibleLubricanteComfoeDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistamientoCombustibleLubricanteComfoeBL.EditarFormado(Id));
        }

        //[AuthorizePermission(Formato: 140, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoAlistamientoCombustibleLubricante)
        {
            AlistamientoCombustibleLubricanteComfoeDTO alistamientoCombustibleLubricanteComfoeDTO = new();
            alistamientoCombustibleLubricanteComfoeDTO.AlistamientoCombustibleLubricanteComfoeId = Id;
            alistamientoCombustibleLubricanteComfoeDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoCombustibleLubricanteComfoeDTO.CodigoAlistamientoCombustibleLubricante = CodigoAlistamientoCombustibleLubricante;


            alistamientoCombustibleLubricanteComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoCombustibleLubricanteComfoeBL.ActualizarFormato(alistamientoCombustibleLubricanteComfoeDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 140, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistamientoCombustibleLubricanteComfoeDTO alistamientoCombustibleLubricanteComfoeDTO = new();
            alistamientoCombustibleLubricanteComfoeDTO.AlistamientoCombustibleLubricanteComfoeId = Id;
            alistamientoCombustibleLubricanteComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistamientoCombustibleLubricanteComfoeBL.EliminarFormato(alistamientoCombustibleLubricanteComfoeDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 140, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AlistamientoCombustibleLubricanteComfoeDTO alistamientoCombustibleLubricanteComfoeDTO = new();
            alistamientoCombustibleLubricanteComfoeDTO.CargaId = Id;
            alistamientoCombustibleLubricanteComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (alistamientoCombustibleLubricanteComfoeBL.EliminarCarga(alistamientoCombustibleLubricanteComfoeDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistamientoCombustibleLubricanteComfoeDTO> lista = new List<AlistamientoCombustibleLubricanteComfoeDTO>();
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

                    lista.Add(new AlistamientoCombustibleLubricanteComfoeDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoAlistamientoCombustibleLubricante = fila.GetCell(1).ToString(),

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
        //[AuthorizePermission(Formato: 140, Permiso: 4)]
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
                    new DataColumn("CodigoAlistamientoCombustibleLubricante", typeof(string)),
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
            var IND_OPERACION = alistamientoCombustibleLubricanteComfoeBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = alistamientoCombustibleLubricanteComfoeBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfoeAlistamientoCombustibleLubricanteComfoe.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfoeAlistamientoCombustibleLubricanteComfoe.xlsx");
        }
    }

}

