using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comfuavinav;
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

    public class ComfuavinavEvaluacionAlistamientoEntrenamientoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EvaluacionAlistamientoEntrenamientoComfuavinav evaluacionAlistamientoEntrenamientoComfuavinavBL = new();
        UnidadNaval unidadNavalBL = new();
        NivelEntrenamiento nivelEntrenamientoBL = new();    
        CapacidadOperativa capacidadOperativaBL = new();
        EjercicioEntrenamiento ejercicioEntrenamientoBL = new();
        Carga cargaBL = new();

        public ComfuavinavEvaluacionAlistamientoEntrenamientoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Reporte de Ejercicios para el Alistamiento de Entrenamiento de las Unidades Aeronavales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<NivelEntrenamientoDTO> nivelEntrenamientoDTO = nivelEntrenamientoBL.ObtenerNivelEntrenamientos();
            List<CapacidadOperativaDTO> capacidadOperativaDTO = capacidadOperativaBL.ObtenerCapacidadOperativas();
            List<EjercicioEntrenamientoDTO> ejercicioEntrenamientoDTO = ejercicioEntrenamientoBL.ObtenerEjercicioEntrenamientos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EjercicioAlistamientoEntrenamientoComfuavinav");

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = nivelEntrenamientoDTO,
                data3 = capacidadOperativaDTO,
                data4 = ejercicioEntrenamientoDTO,
                data5 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionAlistamientoEntrenamientoComfuavinavDTO> select = evaluacionAlistamientoEntrenamientoComfuavinavBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoNivelEntrenamiento, string CodigoCapacidadOperativa, string TipoCapacidadOperativa, string CodigoEjercicioEntrenamiento,
            string FechaPeriodoEvaluar, string FechaRealizacionEjercicio, int TiempoVigencia, int CargaId, string Fecha)
        {
            EvaluacionAlistamientoEntrenamientoComfuavinavDTO evaluacionAlistamientoEntrenamientoComfuavinavDTO = new();
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoNivelEntrenamiento = CodigoNivelEntrenamiento;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.TipoCapacidadOperativa = TipoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoEjercicioEntrenamiento = CodigoEjercicioEntrenamiento;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.TiempoVigencia = TiempoVigencia;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.CargaId = CargaId;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComfuavinavBL.AgregarRegistro(evaluacionAlistamientoEntrenamientoComfuavinavDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistamientoEntrenamientoComfuavinavBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoNivelEntrenamiento, string CodigoCapacidadOperativa, string TipoCapacidadOperativa, string CodigoEjercicioEntrenamiento,
            string FechaPeriodoEvaluar, string FechaRealizacionEjercicio, int TiempoVigencia)
        {
            EvaluacionAlistamientoEntrenamientoComfuavinavDTO evaluacionAlistamientoEntrenamientoComfuavinavDTO = new();
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.EvaluacionAlistamientoEntrenamientoId = Id;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoNivelEntrenamiento = CodigoNivelEntrenamiento;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.TipoCapacidadOperativa = TipoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.CodigoEjercicioEntrenamiento = CodigoEjercicioEntrenamiento;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.TiempoVigencia = TiempoVigencia;

            evaluacionAlistamientoEntrenamientoComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComfuavinavBL.ActualizarFormato(evaluacionAlistamientoEntrenamientoComfuavinavDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoEntrenamientoComfuavinavDTO evaluacionAlistamientoEntrenamientoComfuavinavDTO = new();
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.EvaluacionAlistamientoEntrenamientoId = Id;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionAlistamientoEntrenamientoComfuavinavBL.EliminarFormato(evaluacionAlistamientoEntrenamientoComfuavinavDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoEntrenamientoComfuavinavDTO evaluacionAlistamientoEntrenamientoComfuavinavDTO = new();
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.CargaId = Id;
            evaluacionAlistamientoEntrenamientoComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (evaluacionAlistamientoEntrenamientoComfuavinavBL.EliminarCarga(evaluacionAlistamientoEntrenamientoComfuavinavDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionAlistamientoEntrenamientoComfuavinavDTO> lista = new List<EvaluacionAlistamientoEntrenamientoComfuavinavDTO>();
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
                    
                    lista.Add(new EvaluacionAlistamientoEntrenamientoComfuavinavDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoNivelEntrenamiento = fila.GetCell(1).ToString(),
                        CodigoCapacidadOperativa = fila.GetCell(2).ToString(),
                        TipoCapacidadOperativa   = fila.GetCell(3).ToString(),
                        CodigoEjercicioEntrenamiento = fila.GetCell(4).ToString(),
                        FechaPeriodoEvaluar = UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                        FechaRealizacionEjercicio = UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                        TiempoVigencia = int.Parse(fila.GetCell(7).ToString()),
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

            dt.Columns.AddRange(new DataColumn[9]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoNivelEntrenamiento", typeof(string)),
                    new DataColumn("CodigoCapacidadOperativa", typeof(string)),
                    new DataColumn("TipoCapacidadOperativa", typeof(string)),
                    new DataColumn("CodigoEjercicioEntrenamiento", typeof(string)),
                    new DataColumn("FechaPeriodoEvaluar", typeof(string)),
                    new DataColumn("FechaRealizacionEjercicio", typeof(string)),
                    new DataColumn("TiempoVigencia", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {             
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                    int.Parse(fila.GetCell(7).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComfuavinavBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = evaluacionAlistamientoEntrenamientoComfuavinavBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfuavinavEvaluacionAlistamientoEntrenamiento.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfuavinavEvaluacionAlistamientoEntrenamiento.xlsx");
        }
    }

}

