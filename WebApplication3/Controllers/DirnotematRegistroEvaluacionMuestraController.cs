using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dirnotemat;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dirnotemat;
using Marina.Siesmar.Entidades.Seguridad;
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
    public class DirnotematRegistroEvaluacionMuestraController : Controller
    {

        CapitaniaDAO capitaniaBL = new();
        private readonly IWebHostEnvironment _webHostEnviroment;
        RegistroEvaluacionMuestraDAO registroEvaluacionMuestraBL = new();
        Carga cargaBL = new();

        public DirnotematRegistroEvaluacionMuestraController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Registro de Evaluación de Muestra", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("RegistroEvaluacionMuestra");
            return Json(new { data1  = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<RegistroEvaluacionMuestraDTO> select = registroEvaluacionMuestraBL.ObtenerLista();
            return Json(new { data = select });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string DescProcesoEvaluacion, string NroProcesoEvaluacion, int NroMuestrasEvaluacion, 
            int MuestrasCumpleEvaluacion, int MuestaNoCumpleEvaluacion, string FechaInicioEvaluacion,
            string FechaTerminoEvaluacion, string LaboratorioEvaluacion,int CargaId, string Fecha)
        {
            RegistroEvaluacionMuestraDTO registroEvaluacionMuestraDTO = new();
            registroEvaluacionMuestraDTO.DescProcesoEvaluacion = DescProcesoEvaluacion;
            registroEvaluacionMuestraDTO.NroProcesoEvaluacion = NroProcesoEvaluacion;
            registroEvaluacionMuestraDTO.NroMuestrasEvaluacion = NroMuestrasEvaluacion;
            registroEvaluacionMuestraDTO.MuestrasCumpleEvaluacion = MuestrasCumpleEvaluacion;
            registroEvaluacionMuestraDTO.MuestaNoCumpleEvaluacion = MuestaNoCumpleEvaluacion;
            registroEvaluacionMuestraDTO.FechaInicioEvaluacion = FechaInicioEvaluacion;
            registroEvaluacionMuestraDTO.FechaTerminoEvaluacion = FechaTerminoEvaluacion;
            registroEvaluacionMuestraDTO.LaboratorioEvaluacion = LaboratorioEvaluacion;
            registroEvaluacionMuestraDTO.CargaId = CargaId;
            registroEvaluacionMuestraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroEvaluacionMuestraBL.AgregarRegistro(registroEvaluacionMuestraDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(registroEvaluacionMuestraBL.BuscarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string DescProcesoEvaluacion, string NroProcesoEvaluacion, int NroMuestrasEvaluacion,
            int MuestrasCumpleEvaluacion, int MuestaNoCumpleEvaluacion, string FechaInicioEvaluacion,
            string FechaTerminoEvaluacion, string LaboratorioEvaluacion)
        {

            RegistroEvaluacionMuestraDTO registroEvaluacionMuestraDTO = new();
            registroEvaluacionMuestraDTO.RegistroEvaluacionMuestraId = Id;
            registroEvaluacionMuestraDTO.DescProcesoEvaluacion = DescProcesoEvaluacion;
            registroEvaluacionMuestraDTO.NroProcesoEvaluacion = NroProcesoEvaluacion;
            registroEvaluacionMuestraDTO.NroMuestrasEvaluacion = NroMuestrasEvaluacion;
            registroEvaluacionMuestraDTO.MuestrasCumpleEvaluacion = MuestrasCumpleEvaluacion;
            registroEvaluacionMuestraDTO.MuestaNoCumpleEvaluacion = MuestaNoCumpleEvaluacion;
            registroEvaluacionMuestraDTO.FechaInicioEvaluacion = FechaInicioEvaluacion;
            registroEvaluacionMuestraDTO.FechaTerminoEvaluacion = FechaTerminoEvaluacion;
            registroEvaluacionMuestraDTO.LaboratorioEvaluacion = LaboratorioEvaluacion;
            registroEvaluacionMuestraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroEvaluacionMuestraBL.ActualizaFormato(registroEvaluacionMuestraDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RegistroEvaluacionMuestraDTO registroEvaluacionMuestraDTO = new();
            registroEvaluacionMuestraDTO.RegistroEvaluacionMuestraId = Id;
            registroEvaluacionMuestraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (registroEvaluacionMuestraBL.EliminarFormato(registroEvaluacionMuestraDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            RegistroEvaluacionMuestraDTO registroEvaluacionMuestraDTO = new();
            registroEvaluacionMuestraDTO.CargaId = Id;
            registroEvaluacionMuestraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (registroEvaluacionMuestraBL.EliminarCarga(registroEvaluacionMuestraDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<RegistroEvaluacionMuestraDTO> lista = new List<RegistroEvaluacionMuestraDTO>();
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

                    lista.Add(new RegistroEvaluacionMuestraDTO
                    {
                        DescProcesoEvaluacion = fila.GetCell(0).ToString(),
                        NroProcesoEvaluacion = fila.GetCell(1).ToString(),
                        NroMuestrasEvaluacion = int.Parse(fila.GetCell(2).ToString()),
                        MuestrasCumpleEvaluacion = int.Parse(fila.GetCell(3).ToString()),
                        MuestaNoCumpleEvaluacion = int.Parse(fila.GetCell(4).ToString()),
                        FechaInicioEvaluacion = fila.GetCell(5).ToString(),
                        FechaTerminoEvaluacion = fila.GetCell(6).ToString(),
                        LaboratorioEvaluacion = fila.GetCell(7).ToString()
 
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

            dt.Columns.AddRange(new DataColumn[9]
            {
                    new DataColumn("DescProcesoEvaluacion", typeof(string)),
                    new DataColumn("NroProcesoEvaluacion", typeof(string)),
                    new DataColumn("NroMuestrasEvaluacion", typeof(int)),
                    new DataColumn("MuestrasCumpleEvaluacion", typeof(int)),
                    new DataColumn("MuestaNoCumpleEvaluacion", typeof(int)),
                    new DataColumn("FechaInicioEvaluacion", typeof(string)),
                    new DataColumn("FechaTerminoEvaluacion", typeof(string)),
                    new DataColumn("LaboratorioEvaluacion", typeof(string)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    int.Parse(fila.GetCell(2).ToString()),
                    int.Parse(fila.GetCell(3).ToString()),
                    int.Parse(fila.GetCell(4).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                    fila.GetCell(7).ToString(),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = registroEvaluacionMuestraBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirnotematRegistroEvaluacionMuestra.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirnotematRegistroEvaluacionMuestra.xlsx");
        }
    }

}