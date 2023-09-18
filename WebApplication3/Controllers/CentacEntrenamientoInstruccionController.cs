using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Centac;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Centac;
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

    public class CentacEntrenamientoInstruccionController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EntrenamientoInstruccion entrenamientoInstruccionBL = new();
        Dependencia dependenciaBL = new();
        Carga cargaBL = new();

        public CentacEntrenamientoInstruccionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Entrenamiento de Instrucción", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EntrenamientoInstruccion");

            return Json(new { 
                data1 = dependenciaDTO, 
                data2 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<EntrenamientoInstruccionDTO> select = entrenamientoInstruccionBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            
            return View();
        }
        public ActionResult Insertar( string FechaEntrenamiento, string CodigoDependencia, int DuracionHoras, 
            int NumeroParticipantes, int CargaId, string Fecha)
        {
            EntrenamientoInstruccionDTO entrenamientoInstruccionDTO = new();
            entrenamientoInstruccionDTO.FechaEntrenamiento = FechaEntrenamiento;
            entrenamientoInstruccionDTO.CodigoDependencia = CodigoDependencia;
            entrenamientoInstruccionDTO.DuracionHoras = DuracionHoras;
            entrenamientoInstruccionDTO.NumeroParticipantes = NumeroParticipantes;
            entrenamientoInstruccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            entrenamientoInstruccionDTO.CargaId = CargaId;

            var IND_OPERACION = entrenamientoInstruccionBL.AgregarRegistro(entrenamientoInstruccionDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(entrenamientoInstruccionBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int Id,  string FechaEntrenamiento, string CodigoDependencia, int DuracionHoras, int NumeroParticipantes)
        {
            EntrenamientoInstruccionDTO entrenamientoInstruccionDTO = new();
            entrenamientoInstruccionDTO.EntrenamientoInstruccionId = Id;
            entrenamientoInstruccionDTO.FechaEntrenamiento = FechaEntrenamiento;
            entrenamientoInstruccionDTO.CodigoDependencia = CodigoDependencia;
            entrenamientoInstruccionDTO.DuracionHoras = DuracionHoras;
            entrenamientoInstruccionDTO.NumeroParticipantes = NumeroParticipantes;
            entrenamientoInstruccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = entrenamientoInstruccionBL.ActualizarFormato(entrenamientoInstruccionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EntrenamientoInstruccionDTO entrenamientoInstruccionDTO = new();
            entrenamientoInstruccionDTO.EntrenamientoInstruccionId = Id;
            entrenamientoInstruccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (entrenamientoInstruccionBL.EliminarFormato(entrenamientoInstruccionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EntrenamientoInstruccionDTO entrenamientoInstruccionDTO = new();
            entrenamientoInstruccionDTO.CargaId = Id;
            entrenamientoInstruccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (entrenamientoInstruccionBL.EliminarCarga(entrenamientoInstruccionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EntrenamientoInstruccionDTO> lista = new List<EntrenamientoInstruccionDTO>();
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

                    lista.Add(new EntrenamientoInstruccionDTO
                    {
                        FechaEntrenamiento = fila.GetCell(0).ToString(),
                        CodigoDependencia = fila.GetCell(1).ToString(),
                        DuracionHoras = int.Parse(fila.GetCell(2).ToString()),
                        NumeroParticipantes = int.Parse(fila.GetCell(3).ToString()),
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
                    new DataColumn("FechaEntrenamiento", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("DuracionHoras", typeof(int)),
                    new DataColumn("NumeroParticipantes", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    int.Parse(fila.GetCell(2).ToString()),
                    int.Parse(fila.GetCell(3).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = entrenamientoInstruccionBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }


        public IActionResult ReporteCEI(int CargaId)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Centac\\EntrenamientoInstruccion.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var alquilerAreaCentroEsparcimientoS = entrenamientoInstruccionBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EntrenamientoInstruccion", alquilerAreaCentroEsparcimientoS);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\CentacEntrenamientoInstruccion.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "CentacEntrenamientoInstruccion.xlsx");
        }
    }

}

