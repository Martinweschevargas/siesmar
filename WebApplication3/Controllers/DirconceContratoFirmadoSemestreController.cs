using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dirconce;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dirconce;
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
    public class DirconceContratoFirmadoSemestreController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        ContratoFirmadoSemestre contratoFirmadoSemestreBL = new();
        Carga cargaBL = new();

        public DirconceContratoFirmadoSemestreController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Contratos que se Firmaron en el Semestre", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ContratoFirmadoSemestre");
            return Json(new { data1 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<ContratoFirmadoSemestreDTO> contratoFirmadoSemestreDTO = contratoFirmadoSemestreBL.ObtenerLista();
            return Json(new { data = contratoFirmadoSemestreDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar( int NumeroContratoFirmado, int CargaId, string Fecha)
        {
            ContratoFirmadoSemestreDTO contratoFirmadoSemestreDTO = new();
            contratoFirmadoSemestreDTO.NumeroContratoFirmado = NumeroContratoFirmado;
            contratoFirmadoSemestreDTO.CargaId = CargaId;
            contratoFirmadoSemestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = contratoFirmadoSemestreBL.AgregarRegistro(contratoFirmadoSemestreDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(contratoFirmadoSemestreBL.EditarFormado(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int ContratoFirmadoSemestreId, int NumeroContratoFirmado)
        {
            ContratoFirmadoSemestreDTO contratoFirmadoSemestreDTO = new();
            contratoFirmadoSemestreDTO.ContratoFirmadoSemestreId = ContratoFirmadoSemestreId;
            contratoFirmadoSemestreDTO.NumeroContratoFirmado = NumeroContratoFirmado;
            contratoFirmadoSemestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = contratoFirmadoSemestreBL.ActualizarFormato(contratoFirmadoSemestreDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ContratoFirmadoSemestreDTO contratoFirmadoSemestreDTO = new();
            contratoFirmadoSemestreDTO.ContratoFirmadoSemestreId = Id;
            contratoFirmadoSemestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (contratoFirmadoSemestreBL.EliminarFormato(contratoFirmadoSemestreDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ContratoFirmadoSemestreDTO contratoFirmadoSemestreDTO = new();
            contratoFirmadoSemestreDTO.CargaId = Id;
            contratoFirmadoSemestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (contratoFirmadoSemestreBL.EliminarCarga(contratoFirmadoSemestreDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ContratoFirmadoSemestreDTO> lista = new List<ContratoFirmadoSemestreDTO>();
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

                    lista.Add(new ContratoFirmadoSemestreDTO
                    {
                        NumeroContratoFirmado = int.Parse(fila.GetCell(0).ToString()),
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

            dt.Columns.AddRange(new DataColumn[2]
            {
                    new DataColumn("NumeroContratoFirmado", typeof(int)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = contratoFirmadoSemestreBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteCFS(int? CargaId = null)
        {

            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirconce\\ContratoFirmadoSemestre.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var contratoFirmadoSemestre = contratoFirmadoSemestreBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ContratoFirmadoSemestre", contratoFirmadoSemestre);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirconceContratoFirmadoSemestre.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirconceContratoFirmadoSemestre.xlsx");
        }
    }

}