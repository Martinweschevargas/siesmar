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
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class ComfasubEvaluacionAlistamientoEntrenamientoComfasubController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EvaluacionAlistamientoEntrenamientoComfasub evaluacionAlistamientoEntrenamientoComfasubBL = new();

        UnidadNaval unidadNavalBL = new();
        NivelEntrenamiento nivelEntrenamientoBL = new();
        CapacidadOperativa capacidadOperativaBL = new();
        EjercicioEntrenamientoComfasub ejercicioEntrenamientoComfasubBL = new();
        CalificativoAsignadoEjercicio calificativoAsignadoEjercicioBL = new();
        Carga cargaBL = new();
        public ComfasubEvaluacionAlistamientoEntrenamientoComfasubController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Evaluación del alistamiento del entrenamiento", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<NivelEntrenamientoDTO> nivelEntrenamientoDTO = nivelEntrenamientoBL.ObtenerNivelEntrenamientos();
            List<CapacidadOperativaDTO> capacidadOperativaDTO = capacidadOperativaBL.ObtenerCapacidadOperativas();
            List<EjercicioEntrenamientoComfasubDTO> ejercicioEntrenamientoComfasubDTO = ejercicioEntrenamientoComfasubBL.ObtenerEjercicioEntrenamientoComfasubs();
            List<CalificativoAsignadoEjercicioDTO> calificativoAsignadoEjercicioDTO = calificativoAsignadoEjercicioBL.ObtenerCalificativoAsignadoEjercicios();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EvaluacionAlistamientoEntrenamientoComfasub");

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = nivelEntrenamientoDTO,
                data3 = capacidadOperativaDTO,
                data4 = ejercicioEntrenamientoComfasubDTO,
                data5 = calificativoAsignadoEjercicioDTO,
                data6 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionAlistamientoEntrenamientoComfasubDTO> select = evaluacionAlistamientoEntrenamientoComfasubBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoNivelEntrenamiento, string CodigoCapacidadOperativa,
            string TipoCapacidadOperativa, string EjercicioEntrenamientoAspectos, string PesoAspectosEjercicio, string CodigoEjercicioEntrenamientoComfasub, string CodigoCalificativoAsignadoEjercicio, 
            string FechaPeriodoEvaluar, string FechaRealizacionEjercicio, int TiempoVigencia, int HoraNavegacionUnidad, int OperativoDespliegueRealizado, int CargaId, string Fecha)
        {
            EvaluacionAlistamientoEntrenamientoComfasubDTO evaluacionAlistamientoEntrenamientoComfasubDTO = new();
            evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoNivelEntrenamiento = CodigoNivelEntrenamiento;
            evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComfasubDTO.TipoCapacidadOperativa = TipoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoEjercicioEntrenamientoComfasub = CodigoEjercicioEntrenamientoComfasub;
            evaluacionAlistamientoEntrenamientoComfasubDTO.EjercicioEntrenamientoAspectos = EjercicioEntrenamientoAspectos;
            evaluacionAlistamientoEntrenamientoComfasubDTO.PesoAspectosEjercicio = PesoAspectosEjercicio;
            evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoCalificativoAsignadoEjercicio = CodigoCalificativoAsignadoEjercicio;
            evaluacionAlistamientoEntrenamientoComfasubDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistamientoEntrenamientoComfasubDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistamientoEntrenamientoComfasubDTO.TiempoVigencia = TiempoVigencia;
            evaluacionAlistamientoEntrenamientoComfasubDTO.HoraNavegacionUnidad = HoraNavegacionUnidad;
            evaluacionAlistamientoEntrenamientoComfasubDTO.OperativoDespliegueRealizado = OperativoDespliegueRealizado;
            evaluacionAlistamientoEntrenamientoComfasubDTO.CargaId = CargaId;
            evaluacionAlistamientoEntrenamientoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComfasubBL.AgregarRegistro(evaluacionAlistamientoEntrenamientoComfasubDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistamientoEntrenamientoComfasubBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoNivelEntrenamiento, string CodigoCapacidadOperativa,
            string TipoCapacidadOperativa, string EjercicioEntrenamientoAspectos, string PesoAspectosEjercicio, string CodigoEjercicioEntrenamientoComfasub, string CodigoCalificativoAsignadoEjercicio,
            string FechaPeriodoEvaluar, string FechaRealizacionEjercicio, int TiempoVigencia, int HoraNavegacionUnidad, int OperativoDespliegueRealizado)
        {
            EvaluacionAlistamientoEntrenamientoComfasubDTO evaluacionAlistamientoEntrenamientoComfasubDTO = new();
            evaluacionAlistamientoEntrenamientoComfasubDTO.EvaluacionAlistamientoEntrenamientoId = Id;
            evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoNivelEntrenamiento = CodigoNivelEntrenamiento;
            evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComfasubDTO.TipoCapacidadOperativa = TipoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoEjercicioEntrenamientoComfasub = CodigoEjercicioEntrenamientoComfasub;
            evaluacionAlistamientoEntrenamientoComfasubDTO.EjercicioEntrenamientoAspectos = EjercicioEntrenamientoAspectos;
            evaluacionAlistamientoEntrenamientoComfasubDTO.PesoAspectosEjercicio = PesoAspectosEjercicio;
            evaluacionAlistamientoEntrenamientoComfasubDTO.CodigoCalificativoAsignadoEjercicio = CodigoCalificativoAsignadoEjercicio;
            evaluacionAlistamientoEntrenamientoComfasubDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistamientoEntrenamientoComfasubDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistamientoEntrenamientoComfasubDTO.TiempoVigencia = TiempoVigencia;
            evaluacionAlistamientoEntrenamientoComfasubDTO.HoraNavegacionUnidad = HoraNavegacionUnidad;
            evaluacionAlistamientoEntrenamientoComfasubDTO.OperativoDespliegueRealizado = OperativoDespliegueRealizado;
            evaluacionAlistamientoEntrenamientoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComfasubBL.ActualizarFormato(evaluacionAlistamientoEntrenamientoComfasubDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoEntrenamientoComfasubDTO evaluacionAlistamientoEntrenamientoComfasubDTO = new();
            evaluacionAlistamientoEntrenamientoComfasubDTO.EvaluacionAlistamientoEntrenamientoId = Id;
            evaluacionAlistamientoEntrenamientoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionAlistamientoEntrenamientoComfasubBL.EliminarFormato(evaluacionAlistamientoEntrenamientoComfasubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoEntrenamientoComfasubDTO evaluacionAlistamientoEntrenamientoComfasubDTO = new();
            evaluacionAlistamientoEntrenamientoComfasubDTO.CargaId = Id;
            evaluacionAlistamientoEntrenamientoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (evaluacionAlistamientoEntrenamientoComfasubBL.EliminarCarga(evaluacionAlistamientoEntrenamientoComfasubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionAlistamientoEntrenamientoComfasubDTO> lista = new List<EvaluacionAlistamientoEntrenamientoComfasubDTO>();
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

                    lista.Add(new EvaluacionAlistamientoEntrenamientoComfasubDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoNivelEntrenamiento = fila.GetCell(1).ToString(),
                        CodigoCapacidadOperativa = fila.GetCell(2).ToString(),
                        TipoCapacidadOperativa = fila.GetCell(3).ToString(),
                        CodigoEjercicioEntrenamientoComfasub = fila.GetCell(4).ToString(),
                        EjercicioEntrenamientoAspectos = fila.GetCell(5).ToString(),
                        PesoAspectosEjercicio = fila.GetCell(6).ToString(),
                        CodigoCalificativoAsignadoEjercicio = fila.GetCell(7).ToString(),
                        FechaPeriodoEvaluar = UtilitariosGlobales.obtenerFecha(fila.GetCell(8).ToString()),
                        FechaRealizacionEjercicio = UtilitariosGlobales.obtenerFecha(fila.GetCell(9).ToString()),
                        TiempoVigencia = int.Parse(fila.GetCell(10).ToString()),
                        HoraNavegacionUnidad = int.Parse(fila.GetCell(11).ToString()),
                        OperativoDespliegueRealizado = int.Parse(fila.GetCell(12).ToString())
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

            dt.Columns.AddRange(new DataColumn[14]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoNivelEntrenamiento", typeof(string)),
                    new DataColumn("CodigoCapacidadOperativa", typeof(string)),
                    new DataColumn("TipoCapacidadOperativa", typeof(string)),
                    new DataColumn("CodigoEjercicioEntrenamientoComfasub", typeof(string)),
                    new DataColumn("EjercicioEntrenamientoAspectos", typeof(string)),
                    new DataColumn("PesoAspectosEjercicio", typeof(string)),
                    new DataColumn("CodigoCalificativoAsignadoEjercicio", typeof(string)),
                    new DataColumn("FechaPeriodoEvaluar", typeof(string)),
                    new DataColumn("FechaRealizacionEjercicio", typeof(string)),
                    new DataColumn("TiempoVigencia", typeof(int)),
                    new DataColumn("HoraNavegacionUnidad", typeof(int)),
                    new DataColumn("OperativoDespliegueRealizado", typeof(int)),
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
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(8).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(9).ToString()),
                    int.Parse(fila.GetCell(10).ToString()),
                    int.Parse(fila.GetCell(11).ToString()),
                    int.Parse(fila.GetCell(12).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComfasubBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfasubEvaluacionAlistamientoEntrenamientoComfasub.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfasubEvaluacionAlistamientoEntrenamientoComfasub.xlsx");
        }
        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = evaluacionAlistamientoEntrenamientoComfasubBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

    }

}

