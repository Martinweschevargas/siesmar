using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comfasub;
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
    public class ComfasubProgramaRecorridoComfasubController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ProgramaRecorridoComfasub programaRecorridoComfasubBL = new();
        UnidadNaval unidadNavalBL = new();
        AlistamientoMaterialRequerido2N alistamientoMaterialRequerido2NBL = new ();
        Carga cargaBL = new();

        public ComfasubProgramaRecorridoComfasubController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Programa de Recorrido", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<AlistamientoMaterialRequerido2NDTO> alistamientoMaterialRequerido2NDTO = alistamientoMaterialRequerido2NBL.ObtenerAlistamientoMaterialRequerido2Ns();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ProgramaRecorridoComfasub");
            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = alistamientoMaterialRequerido2NDTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ProgramaRecorridoComfasubDTO> programaRecorridoComfasubDTO = programaRecorridoComfasubBL.ObtenerLista();
            return Json(new { data = programaRecorridoComfasubDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( string CodigoUnidadNaval, string CodigoAlistamientoMaterialRequerido2N,
            string FechaInicio, string FechaTermino, int RecorridoDia, int CargaId, string Fecha)
        {
            ProgramaRecorridoComfasubDTO programaRecorridoComfasubDTO = new();
            programaRecorridoComfasubDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            programaRecorridoComfasubDTO.CodigoAlistamientoMaterialRequerido2N = CodigoAlistamientoMaterialRequerido2N;
            programaRecorridoComfasubDTO.FechaInicio = FechaInicio;
            programaRecorridoComfasubDTO.FechaTermino = FechaTermino;
            programaRecorridoComfasubDTO.RecorridoDia = RecorridoDia;
            programaRecorridoComfasubDTO.CargaId = CargaId;
            programaRecorridoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = programaRecorridoComfasubBL.AgregarRegistro(programaRecorridoComfasubDTO,Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(programaRecorridoComfasubBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int ProgramaRecorridoComfasubId, string CodigoUnidadNaval, string CodigoAlistamientoMaterialRequerido2N, int Subclasificacion2,
            string FechaInicio, string FechaTermino, int RecorridoDia)
        {
            ProgramaRecorridoComfasubDTO programaRecorridoComfasubDTO = new();
            programaRecorridoComfasubDTO.ProgramaRecorridoComfasubId = ProgramaRecorridoComfasubId;
            programaRecorridoComfasubDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            programaRecorridoComfasubDTO.CodigoAlistamientoMaterialRequerido2N = CodigoAlistamientoMaterialRequerido2N;
            programaRecorridoComfasubDTO.FechaInicio = FechaInicio;
            programaRecorridoComfasubDTO.FechaTermino = FechaTermino;
            programaRecorridoComfasubDTO.RecorridoDia = RecorridoDia;
            programaRecorridoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = programaRecorridoComfasubBL.ActualizarFormato(programaRecorridoComfasubDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ProgramaRecorridoComfasubDTO programaRecorridoComfasubDTO = new();
            programaRecorridoComfasubDTO.ProgramaRecorridoComfasubId = Id;
            programaRecorridoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (programaRecorridoComfasubBL.EliminarFormato(programaRecorridoComfasubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ProgramaRecorridoComfasubDTO programaRecorridoComfasubDTO = new();
            programaRecorridoComfasubDTO.CargaId = Id;
            programaRecorridoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (programaRecorridoComfasubBL.EliminarCarga(programaRecorridoComfasubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ProgramaRecorridoComfasubDTO> lista = new List<ProgramaRecorridoComfasubDTO>();
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

                    lista.Add(new ProgramaRecorridoComfasubDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoAlistamientoMaterialRequerido2N = fila.GetCell(1).ToString(),
                        FechaInicio = UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                        FechaTermino = UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                        RecorridoDia = int.Parse(fila.GetCell(4).ToString())

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

            dt.Columns.AddRange(new DataColumn[6]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoAlistamientoMaterialRequerido2N", typeof(string)),
                    new DataColumn("FechaInicio", typeof(string)),
                    new DataColumn("FechaTermino", typeof(string)),
                    new DataColumn("RecorridoDia", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                    int.Parse(fila.GetCell(4).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = programaRecorridoComfasubBL.InsertarDatos(dt, Fecha);
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
            var result=localReport.Execute(RenderType.Pdf,extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        public IActionResult Print2()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report2.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            var Capitanias = programaRecorridoComfasubBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfasubProgramaRecorridoComfasub.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfasubProgramaRecorridoComfasub.xlsx");
        }
    }

}