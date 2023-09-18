using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comzouno;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzouno;
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

    public class ComzounoEvaluacionAlistamientoEntrenamientoComzounoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EvaluacionAlistamientoEntrenamientoComzouno evaluacionAlistamientoEntrenamientoComzounoBL = new();
        UnidadNaval unidadNavalBL = new();
        NivelEntrenamiento nivelEntrenamientoBL = new();
        CapacidadOperativa capacidadOperativaBL = new();
        EjercicioEntrenamientoAspecto ejercicioEntrenamientoAspectoBL = new();
        CalificativoAsignadoEjercicio calificativoAsignadoEjercicioBL = new();
        Carga cargaBL = new();

        public ComzounoEvaluacionAlistamientoEntrenamientoComzounoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Evaluación del Alistamiento del entrenamiento", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<NivelEntrenamientoDTO> nivelEntrenamientoDTO = nivelEntrenamientoBL.ObtenerNivelEntrenamientos();
            List<CapacidadOperativaDTO> capacidadOperativaDTO = capacidadOperativaBL.ObtenerCapacidadOperativas();
            List<EjercicioEntrenamientoAspectoDTO> ejercicioEntrenamientoAspectoDTO = ejercicioEntrenamientoAspectoBL.ObtenerEjercicioEntrenamientoAspectos();
            List<CalificativoAsignadoEjercicioDTO> calificativoAsignadoEjercicioDTO = calificativoAsignadoEjercicioBL.ObtenerCalificativoAsignadoEjercicios();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EvaluacionAlistamientoEntrenamientoComzouno");

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = nivelEntrenamientoDTO,
                data3 = capacidadOperativaDTO,
                data4 = ejercicioEntrenamientoAspectoDTO,
                data5 = calificativoAsignadoEjercicioDTO,
                data6 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionAlistamientoEntrenamientoComzounoDTO> select = evaluacionAlistamientoEntrenamientoComzounoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoNivelEntrenamiento, string CodigoCapacidadOperativa, 
            string TipoCapacidadOperativa, string CodigoEjercicioEntrenamientoAspecto, string CodigoCalificativoAsignadoEjercicio, 
            string FechaPeriodoEvaluar, string FechaRealizacionEjercicio, int TiempoVigencia,
            string FechaCaducidadEjercicio, int PuntajeObtenidoEjercicio, int CargaId, string Fecha)
        {
            EvaluacionAlistamientoEntrenamientoComzounoDTO evaluacionAlistamientoEntrenamientoComzounoDTO = new();
            evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoNivelEntrenamiento = CodigoNivelEntrenamiento;
            evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComzounoDTO.TipoCapacidadOperativa = TipoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoEjercicioEntrenamientoAspecto = CodigoEjercicioEntrenamientoAspecto;
            evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoCalificativoAsignadoEjercicio = CodigoCalificativoAsignadoEjercicio;
            evaluacionAlistamientoEntrenamientoComzounoDTO.PuntajeObtenidoEjercicio = PuntajeObtenidoEjercicio;
            evaluacionAlistamientoEntrenamientoComzounoDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistamientoEntrenamientoComzounoDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistamientoEntrenamientoComzounoDTO.TiempoVigencia = TiempoVigencia;
            evaluacionAlistamientoEntrenamientoComzounoDTO.FechaCaducidadEjercicio = FechaCaducidadEjercicio;
            evaluacionAlistamientoEntrenamientoComzounoDTO.CargaId = CargaId;
            evaluacionAlistamientoEntrenamientoComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComzounoBL.AgregarRegistro(evaluacionAlistamientoEntrenamientoComzounoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistamientoEntrenamientoComzounoBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoNivelEntrenamiento, string CodigoCapacidadOperativa,
            string TipoCapacidadOperativa, string CodigoEjercicioEntrenamientoAspecto, string CodigoCalificativoAsignadoEjercicio,
            string FechaPeriodoEvaluar, string FechaRealizacionEjercicio, int TiempoVigencia,
            string FechaCaducidadEjercicio, int PuntajeObtenidoEjercicio)
        {
            EvaluacionAlistamientoEntrenamientoComzounoDTO evaluacionAlistamientoEntrenamientoComzounoDTO = new();
            evaluacionAlistamientoEntrenamientoComzounoDTO.EvaluacionAlistamientoEntrenamientoId = Id;
            evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoNivelEntrenamiento = CodigoNivelEntrenamiento;
            evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComzounoDTO.TipoCapacidadOperativa = TipoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoEjercicioEntrenamientoAspecto = CodigoEjercicioEntrenamientoAspecto;
            evaluacionAlistamientoEntrenamientoComzounoDTO.CodigoCalificativoAsignadoEjercicio = CodigoCalificativoAsignadoEjercicio;
            evaluacionAlistamientoEntrenamientoComzounoDTO.PuntajeObtenidoEjercicio = PuntajeObtenidoEjercicio;
            evaluacionAlistamientoEntrenamientoComzounoDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistamientoEntrenamientoComzounoDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistamientoEntrenamientoComzounoDTO.TiempoVigencia = TiempoVigencia;
            evaluacionAlistamientoEntrenamientoComzounoDTO.FechaCaducidadEjercicio = FechaCaducidadEjercicio;
            evaluacionAlistamientoEntrenamientoComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComzounoBL.ActualizarFormato(evaluacionAlistamientoEntrenamientoComzounoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoEntrenamientoComzounoDTO evaluacionAlistamientoEntrenamientoComzounoDTO = new();
            evaluacionAlistamientoEntrenamientoComzounoDTO.EvaluacionAlistamientoEntrenamientoId = Id;
            evaluacionAlistamientoEntrenamientoComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionAlistamientoEntrenamientoComzounoBL.EliminarFormato(evaluacionAlistamientoEntrenamientoComzounoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoEntrenamientoComzounoDTO evaluacionAlistamientoEntrenamientoComzounoDTO = new();
            evaluacionAlistamientoEntrenamientoComzounoDTO.CargaId = Id;
            evaluacionAlistamientoEntrenamientoComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (evaluacionAlistamientoEntrenamientoComzounoBL.EliminarCarga(evaluacionAlistamientoEntrenamientoComzounoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionAlistamientoEntrenamientoComzounoDTO> lista = new List<EvaluacionAlistamientoEntrenamientoComzounoDTO>();
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

                    lista.Add(new EvaluacionAlistamientoEntrenamientoComzounoDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoNivelEntrenamiento = fila.GetCell(1).ToString(),
                        CodigoCapacidadOperativa = fila.GetCell(2).ToString(),
                        TipoCapacidadOperativa = fila.GetCell(3).ToString(),
                        CodigoEjercicioEntrenamientoAspecto = fila.GetCell(4).ToString(),
                        CodigoCalificativoAsignadoEjercicio = fila.GetCell(5).ToString(),
                        PuntajeObtenidoEjercicio = int.Parse(fila.GetCell(6).ToString()),
                        FechaPeriodoEvaluar = UtilitariosGlobales.obtenerFecha(fila.GetCell(7).ToString()),
                        FechaRealizacionEjercicio = UtilitariosGlobales.obtenerFecha(fila.GetCell(8).ToString()),
                        TiempoVigencia = int.Parse(fila.GetCell(9).ToString()),
                        FechaCaducidadEjercicio = UtilitariosGlobales.obtenerFecha(fila.GetCell(10).ToString())
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

            dt.Columns.AddRange(new DataColumn[12]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoNivelEntrenamiento", typeof(string)),
                    new DataColumn("CodigoCapacidadOperativa", typeof(string)),
                    new DataColumn("TipoCapacidadOperativa", typeof(string)),
                    new DataColumn("CodigoEjercicioEntrenamientoAspecto", typeof(string)),
                    new DataColumn("CodigoCalificativoAsignadoEjercicio", typeof(string)),
                    new DataColumn("PuntajeObtenidoEjercicio", typeof(int)),
                    new DataColumn("FechaPeriodoEvaluar", typeof(string)),
                    new DataColumn("FechaRealizacionEjercicio", typeof(string)),
                    new DataColumn("TiempoVigencia", typeof(int)),
                    new DataColumn("FechaCaducidadEjercicio", typeof(string)),
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
                    fila.GetCell(5).ToString(),
                    int.Parse(fila.GetCell(6).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(7).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(8).ToString()),
                    int.Parse(fila.GetCell(9).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(10).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComzounoBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }


        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = evaluacionAlistamientoEntrenamientoComzounoBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComzounoEvaluacionAlistamientoEntrenamientoComzouno.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComzounoEvaluacionAlistamientoEntrenamientoComzouno.xlsx");
        }

    }

}

